using PagedList;
using PropertyRentalManagement.Models;
using PropertyRentalManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace PropertyRentalManagement.Controllers
{
    [Authorize(Roles = "admin, manager")]
    public class PropertyController : Controller
    {
        public ApplicationDbContext _context;
        public static List<int> _listImageId = new List<int>();
        public static List<string> _listFileNames = new List<string>();
        public static List<string> _listFileNamesRemoved = new List<string>();

        public static List<HttpPostedFileBase> _httpPostedFileBase = new List<HttpPostedFileBase>();
        public int i = 0;
        public PropertyController()
        {
            _context = new ApplicationDbContext();

        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index(int page = 1, string searchTerm = null)
        {
            var listProperties = _context.Properties
                .OrderBy(p => p.Price)
                .Include(p => p.BuildingType)
                .Where(p => (searchTerm == null ||
                            p.Address.Contains(searchTerm) ||
                            p.BuildingType.Name.Contains(searchTerm) ||
                            p.NumberRooms.Contains(searchTerm) ||
                            p.Description.Contains(searchTerm) ||
                            (p.Price.ToString()).Equals(searchTerm)))
                .ToPagedList(page, 10);

            return View(listProperties);
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

        public ActionResult Create()
        {
            var viewModel = new PropertyViewModel()
            {
                Property = new Property(),
                BuildingTypes = _context.BuildingTypes.ToList(),
                ImageModel = new ImageModel(),
                ListFilesNames = _listFileNames
            };

            return View("Create", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var property = _context.Properties.SingleOrDefault(p => p.Id == id);
            if (property == null)
            {
                return HttpNotFound();
            }

            var listImages = _context.PropertyImageModels
                            .Where(im => im.PropertyId == id)
                            .Select(im => im.ImageModelId).ToList();

             var tempListFileNames = _context.ImageModels.Where(im => listImages.Contains(im.Id))
                .Select(im => im.FileName)
                .ToList();
            tempListFileNames.AddRange(_listFileNames);

            tempListFileNames.RemoveAll(im => _listFileNamesRemoved.Contains(im));

            var viewModel = new PropertyViewModel()
            {
                Property = property,
                BuildingTypes = _context.BuildingTypes.ToList(),
                ImageModel = new ImageModel(),
                ListFilesNames = tempListFileNames
            };

            return View("Edit", viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveCreate(Property property)
        {
            if (!ModelState.IsValid)
            {
                return View("Create");
            }
                _context.Properties.Add(property);

            foreach (var item in _httpPostedFileBase)
            {
                ImageModel imageModel = new ImageModel();

                string fileName = item.FileName;

                string filePath = Path.Combine(
                  Server.MapPath(Constants.pathToImages), item.FileName);
              int lastId = 0;
              // check if file exist in folder already
              if (!System.IO.File.Exists(filePath))
              {
                  imageModel.FileName = fileName;
                  imageModel.Size = item.ContentLength;

                  item.SaveAs(filePath);

                  _context.ImageModels.Add(imageModel);
                  _context.SaveChanges();

                  lastId = _context.ImageModels
                      .OrderByDescending(i => i.Id)
                      .FirstOrDefault().Id;
              }
              else
              {
                  lastId = _context.ImageModels
                      .Where(i => i.FileName == fileName)
                      .SingleOrDefault().Id;
              }

              _listImageId.Add(lastId);
            }


            var lastPropertyId = _context.Properties
                .OrderByDescending(p => p.Id)
                .FirstOrDefault().Id;


            foreach (var item in _listImageId)
            {
                var propertyImageModel = new PropertyImageModel()
                {
                    ImageModelId = item,
                    PropertyId = lastPropertyId
                };
                _context.PropertyImageModels.Add(propertyImageModel);

            }
            _context.SaveChanges();

            // clear previous data from static list
            _listImageId.Clear();
            _listFileNames.Clear();
            _httpPostedFileBase.Clear();
            return RedirectToAction("Index", "Property");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveEdit(Property property)
        {
            var propertyId = Convert.ToInt32(Request.Form["propertyId"]);
            if (!ModelState.IsValid)
            {
                return View("Edit");
            }

            var propertyInDb = _context.Properties
                .SingleOrDefault(a => a.Id == propertyId);
            if (propertyInDb != null)
            {
                propertyInDb.Address = property.Address;
                propertyInDb.AppartmentNumber = property.AppartmentNumber;
                propertyInDb.NumberRooms = property.NumberRooms;
                propertyInDb.BuildingTypeId = property.BuildingTypeId;
                propertyInDb.RentStarted = property.RentStarted;
                propertyInDb.RentFinished = property.RentFinished;
                propertyInDb.Description = property.Description;
                propertyInDb.Available = property.Available;
            }

            _context.SaveChanges();

            foreach (var item in _httpPostedFileBase)
            {
                ImageModel imageModel = new ImageModel();

                string fileName = item.FileName;

                string filePath = Path.Combine(
                  Server.MapPath(Constants.pathToImages), item.FileName);
                int lastId = 0;
                // check if file exist in folder already
                if (!System.IO.File.Exists(filePath))
                {
                    imageModel.FileName = fileName;
                    imageModel.Size = item.ContentLength;

                    item.SaveAs(filePath);

                    _context.ImageModels.Add(imageModel);

                    _context.SaveChanges();

                    lastId = _context.ImageModels
                        .OrderByDescending(i => i.Id)
                        .FirstOrDefault().Id;
                }
                else
                {
                    lastId = _context.ImageModels
                        .Where(i => i.FileName == fileName)
                        .SingleOrDefault().Id;
                }

                _listImageId.Add(lastId);
            }


            var lastPropertyId = _context.Properties
                .OrderByDescending(p => p.Id)
                .FirstOrDefault().Id;

            foreach (var item in _listImageId)
            {
                var propertyImageModel = new PropertyImageModel()
                {
                    ImageModelId = item,
                    PropertyId = lastPropertyId
                };
                _context.PropertyImageModels.Add(propertyImageModel);
            }

            foreach (var item in _listFileNamesRemoved)
            {
                foreach (var im in _context.ImageModels)
                {
                    if (item == im.FileName)
                    {
                        _context.PropertyImageModels.Remove(_context.PropertyImageModels.Single(pim => pim.ImageModelId == im.Id && pim.PropertyId == propertyId));
                        break;
                    }
                }
            }
            _context.SaveChanges();

            // clear previous data from static list
            _listImageId.Clear();
            _listFileNames.Clear();
            _httpPostedFileBase.Clear();
            _listFileNamesRemoved.Clear();

            return RedirectToAction("Index", "Property");
        }

        public ActionResult Delete(int id)
        {
            var listImageModelId = _context.PropertyImageModels
                .Where(pi => pi.PropertyId == id)
                .ToList();

            // for cascade deleting
            foreach (var item in listImageModelId)
            {
                string fileName = "";

                if (_context.PropertyImageModels
                    .Where(pi => pi.ImageModelId == item.ImageModelId)
                    .Count() == 1)
                {
                    foreach (var currentFile in _context.ImageModels)
                    {
                        if (currentFile.Id == item.ImageModelId)
                        {
                            fileName = currentFile.FileName;
                            break;
                        }
                    }
                        string filePath = Path.Combine(
                          Server.MapPath(Constants.pathToImages), fileName);

                        // remove file from server
                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(filePath);
                        }
                        _context.ImageModels.Remove(_context.ImageModels.Find(item.ImageModelId));
                        _context.SaveChanges();
                }
                // remove from Many-to-Many
                _context.PropertyImageModels.RemoveRange
                    (_context.PropertyImageModels
                        .Where(i => (i.PropertyId == id && i.ImageModelId == item.ImageModelId)));
            }

            // remove property
            _context.Properties.Remove(_context.Properties.Find(id));
            _context.SaveChanges();

            return RedirectToAction("Index", "Property");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadImage(HttpPostedFileBase imageFile)
        {
            var propertyId = Convert.ToInt32(Request.Form["propertyId"]);

            if (imageFile != null)
            {
                if (imageFile.ContentLength > (2 * 1024 * 1024))
                {
                    ModelState.AddModelError("CustomError", "File size must be less than 2 MB");
                    ViewBag.Message = "File size must be less than 2 MB";
                    return RedirectToAction("Create", "Property");
                }
                if (imageFile.ContentType != "image/jpeg" &&
                    imageFile.ContentType != "image/png" &&
                    imageFile.ContentType != "image/jpg" &&
                    imageFile.ContentType != "image/gif")
                {
                    ModelState.AddModelError("CustomError", "File type allowed : jpeg/jpg/png/gif");

                    if (propertyId == 0)
                    {
                        return RedirectToAction("Create", "Property");
                    }
                    return RedirectToAction("Edit", "Property", new { id = propertyId });
                }

                _httpPostedFileBase.Add(imageFile);
                _listFileNames.Add(imageFile.FileName.ToString());
            }
            if (propertyId == 0)
            {
                return RedirectToAction("Create", "Property");
            }
            return RedirectToAction("Edit", "Property", new { id = propertyId });
        }
        [Route("property/DeleteImageName/{id}/{fileName}")]
        public ActionResult DeleteImageName(int id, string fileName)
        {
            foreach (var item in _httpPostedFileBase)
            {
                if (item.FileName == fileName)
                {
                    _httpPostedFileBase.Remove(item);
                    break;
                }
            }
            _listFileNamesRemoved.Add(fileName);

            if (id == 0)
            {
                return RedirectToAction("Create", "Property");
            }
            return RedirectToAction("Edit", "Property", new { id });
        }
    }
}