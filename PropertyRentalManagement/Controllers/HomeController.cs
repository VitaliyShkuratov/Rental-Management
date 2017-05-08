using PropertyRentalManagement.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using PropertyRentalManagement.ViewModels;
using System.Collections.Generic;

namespace PropertyRentalManagement.Controllers
{
    public class HomeController : Controller
    {
        public ApplicationDbContext _context;
        public HomeController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index(int page = 1, string searchTerm = null)
        {
            var propertyInfo = new List<HomeIndexViewModel>();

            var listProperties = _context.Properties
                .OrderBy(p => p.Price)
                .Include(p => p.BuildingType)
                .Where(p => ((p.Available == true)
                        && (searchTerm == null ||
                            p.Address.Contains(searchTerm) ||
                            p.BuildingType.Name.Contains(searchTerm) ||
                            p.NumberRooms.Contains(searchTerm) ||
                            p.Description.Contains(searchTerm) ||
                            (p.Price.ToString()).Equals(searchTerm))))
                .ToList();
            string imageFileName = "";
            foreach (var item in listProperties)
            {
                var listImages = _context.PropertyImageModels
                            .Where(im => im.PropertyId == item.Id)
                            .Select(im => im.ImageModelId)
                            .ToList();

                foreach (var imageFile in _context.ImageModels)
                {
                    if (listImages.Contains(imageFile.Id))
                    {
                        imageFileName = Constants.pathToImages + imageFile.FileName;
                        break;
                    }
                }

                propertyInfo.Add(new HomeIndexViewModel()
                {
                    Property = item,
                    ImageFileName = imageFileName
                });
            }

            return View(propertyInfo.ToPagedList(page, 10));
        }
        public ActionResult Detail(int id)
        {
            List<string> listFileNames = new List<string>();

            var property = _context.Properties
                .Include(p => p.BuildingType)
                .SingleOrDefault(p => p.Id == id);


            var listImages = _context.PropertyImageModels
                        .Where(im => im.PropertyId == property.Id)
                        .Select(im => im.ImageModelId)
                        .ToList();

            foreach (var imageFile in _context.ImageModels)
            {
                if (listImages.Contains(imageFile.Id))
                {
                    listFileNames.Add(Constants.pathToImages + imageFile.FileName);
                }
            }
            var viewModel = new HomeDetailViewModel()
            {
                Property = property,
                ImageFileNames = listFileNames
            };
            return View(viewModel);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "";

            return View();
        }
    }
}