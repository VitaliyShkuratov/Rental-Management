using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PagedList;
using PropertyRentalManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PropertyRentalManagement.ViewModels;
using System.Web.Security;

namespace PropertyRentalManagement.Controllers
{
    [Authorize(Roles = "admin")]
    public class PersonController : Controller
    {
        public ApplicationDbContext _context;
        UserStore<ApplicationUser> userStore;
        UserManager<ApplicationUser> userManager;

        public PersonController()
        {
            _context = new ApplicationDbContext();
            userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
            userManager = new UserManager<ApplicationUser>(userStore);
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index(int page = 1, string searchTerm = null)
        {
            var persons = _context.Users
                .OrderBy(u => u.LastName)
                .Where(u => (searchTerm == null ||
                        u.FirstName.Contains(searchTerm) ||
                        u.LastName.Contains(searchTerm) ||
                        u.Email.Contains(searchTerm) ||
                        u.PhoneNumber.Contains(searchTerm)))
                .Select(u => new UserViewModel
                    {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Phone = u.PhoneNumber,
                    Email = u.Email,
                })
                .ToList();

            foreach (var item in persons)
            {
                item.RoleName = userManager.GetRoles(item.Id);
            }
            return View(persons.ToPagedList(page, 10));
        }


        public ActionResult Details(string id)
        {
            var person = _context.Users.SingleOrDefault(u => u.Id == id);
            if (person == null)
            {
                return HttpNotFound();
            }
            var viewModel = new DetailUserViewModel
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Phone = person.PhoneNumber,
                PhoneConfirmed = person.PhoneNumberConfirmed,
                Email = person.Email,
                EmailConfirmed = person.EmailConfirmed,
                RoleName = userManager.GetRoles(person.Id).ToList()
            };
            return View(viewModel);
        }
        public ActionResult Edit(string id)
        {
            var person = _context.Users.SingleOrDefault(u => u.Id == id);

            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(ApplicationUser person)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", person);
            }

            if (String.IsNullOrEmpty(person.Id))
            {
                _context.Users.Add(person);
            }
            else
            {
                var personInDb = _context.Users
                    .Single(u => u.Id == person.Id);

                personInDb.FirstName = person.FirstName;
                personInDb.LastName = person.LastName;
                personInDb.Email = person.Email;
                personInDb.EmailConfirmed = person.EmailConfirmed;
                personInDb.UserName = person.Email;
                personInDb.PhoneNumber = person.PhoneNumber;
                personInDb.PhoneNumberConfirmed = person.PhoneNumberConfirmed;
                personInDb.LockoutEnabled = person.LockoutEnabled;
                personInDb.AccessFailedCount = person.AccessFailedCount;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Person");
        }
        public ActionResult Delete(string id)
        {
            _context.Users.Remove(_context.Users.Find(id));
            _context.SaveChanges();

            return RedirectToAction("Index", "Person");
        }
    }
}