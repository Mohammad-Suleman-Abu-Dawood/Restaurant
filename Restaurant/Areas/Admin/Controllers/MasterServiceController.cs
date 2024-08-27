using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Restaurant.Areas.Admin.ViewModels;
using Restaurant.Models;
using Restaurant.Models.Repositories;
using System.Security.Claims;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MasterServiceController : Controller
    {
        public IRepository<MasterService> MasterService { get; }
        public Microsoft.AspNetCore.Hosting.IHostingEnvironment Host { get; }

        public MasterServiceController(IRepository<MasterService> _MasterService, Microsoft.AspNetCore.Hosting.IHostingEnvironment _Host)
        {
            MasterService = _MasterService;
            Host = _Host;
        }
        // GET: MasterServiceController
        public ActionResult Index()
        {
            var data = MasterService.View();
            return View(data);
        }

        

        // GET: MasterServiceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterServiceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterServiceModel collection)
        {
            try
            {
                collection.CreateId=User.FindFirstValue(ClaimTypes.NameIdentifier);
                collection.CreateDate=DateTime.Now;
                string ImageSave = SaveImage(collection.Files);
                var data = new MasterService
                { 
                MasterServiceId = collection.MasterServiceId,
                MasterServicesDesc = collection.MasterServicesDesc,
                MasterServicesImage = ImageSave,
                MasterServicesTitle = collection.MasterServicesTitle,
                };
                MasterService.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterServiceController/Edit/5
        public ActionResult Edit(int id)
        {
            var data= MasterService.Find(id);
            var datan = new MasterServiceModel
            {
                MasterServiceId = data.MasterServiceId,
                MasterServicesDesc = data.MasterServicesDesc,
                MasterServicesImage = data.MasterServicesImage,
                MasterServicesTitle = data.MasterServicesTitle,


            };
            return View(datan);
        }

        // POST: MasterServiceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterServiceModel collection)
        {
            try
            {
                collection.EditId=User.FindFirstValue(ClaimTypes.NameIdentifier);
                collection.EditDate=DateTime.Now;
                string ImageSave = "";
                if (collection.Files != null)
                {
                    string PathImage = Path.Combine(Host.WebRootPath, "Images");
                    FileInfo FileInfo = new FileInfo(collection.Files.FileName);
                    ImageSave = Guid.NewGuid().ToString() + FileInfo.Extension;
                    string FullPath = Path.Combine(PathImage, ImageSave);
                    collection.Files.CopyTo(new FileStream(FullPath, FileMode.Create));


                }
                else
                {
                    ImageSave = collection.MasterServicesImage;
                }
                var data = new MasterService
                {
                    MasterServiceId = collection.MasterServiceId,
                    MasterServicesDesc = collection.MasterServicesDesc,
                    MasterServicesImage = ImageSave,
                    MasterServicesTitle = collection.MasterServicesTitle,

                };
                MasterService.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterServiceController/Delete/5
        public ActionResult Delete(int id)
        {
            MasterService.Delete(id,new Models.MasterService());
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Active(int id)
        {
            MasterService.Active(id);
            return RedirectToAction(nameof(Index));
        }
        public string SaveImage(IFormFile Files)
        {
            string ImageSave = "";
            if (Files != null)
            {
                string PathImage = Path.Combine(Host.WebRootPath, "images");
                FileInfo FileInfo = new FileInfo(Files.FileName);
                ImageSave = Guid.NewGuid().ToString() + FileInfo.Extension;
                string FullPath = Path.Combine(PathImage, ImageSave);
                Files.CopyTo(new FileStream(FullPath, FileMode.Create));
            }

            return ImageSave;
        }
    }
}
