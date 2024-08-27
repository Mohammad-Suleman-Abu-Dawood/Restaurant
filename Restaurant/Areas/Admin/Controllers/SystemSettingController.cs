using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Areas.Admin.ViewModels;
using Restaurant.Models;
using Restaurant.Models.Repositories;
using System.Security.Claims;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class SystemSettingController : Controller
    {
        public IRepository<SystemSetting> SystemSetting { get; }
        public Microsoft.AspNetCore.Hosting.IHostingEnvironment Host { get; }

        public SystemSettingController(IRepository<SystemSetting> _SystemSetting, Microsoft.AspNetCore.Hosting.IHostingEnvironment _Host)
        {
            SystemSetting = _SystemSetting;
            Host = _Host;
        }
        // GET: SystemSettingController
        public ActionResult Index()
        {
            var data = SystemSetting.View();
            return View(data);
        }


        // GET: SystemSettingController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SystemSettingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SystemSettingModel collection)
        {
            try
            {
                collection.CreateId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                collection.CreateDate= DateTime.Now;
                string ImageSave1 = SaveImage(collection.File1);
                string ImageSave2 = SaveImage(collection.File2);
                string ImageSave3 = SaveImage(collection.File3);
                ImageSave1 = ImageSave1 != null ? ImageSave1 : collection.SystemSettingLogoImageUrl;
                ImageSave1 = ImageSave2 != null ? ImageSave2 : collection.SystemSettingLogoImageUrl2;
                ImageSave1 = ImageSave3 != null ? ImageSave3 : collection.SystemSettingWelcomeNoteImageUrl;
                var data = new SystemSetting
                { 
                SystemSettingWelcomeNoteImageUrl = ImageSave1,
                SystemSettingLogoImageUrl = ImageSave2,
                SystemSettingLogoImageUrl2 = ImageSave3,
                SystemSettingCopyright=collection.SystemSettingCopyright,
                SystemSettingId=collection.SystemSettingId,
                SystemSettingMapLocation=collection.SystemSettingMapLocation,
                SystemSettingWelcomeNoteBreef=collection.SystemSettingWelcomeNoteBreef,
                SystemSettingWelcomeNoteDesc=collection.SystemSettingWelcomeNoteDesc,
                SystemSettingWelcomeNoteTitle=collection.SystemSettingWelcomeNoteTitle,
                SystemSettingWelcomeNoteUrl=collection.SystemSettingWelcomeNoteUrl,
                };
                SystemSetting.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SystemSettingController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = SystemSetting.Find(id);
            var datan = new SystemSettingModel
            {
                SystemSettingWelcomeNoteImageUrl = data.SystemSettingWelcomeNoteImageUrl,
                SystemSettingLogoImageUrl = data.SystemSettingLogoImageUrl,
                SystemSettingLogoImageUrl2 = data.SystemSettingLogoImageUrl2,
                SystemSettingCopyright = data.SystemSettingCopyright,
                SystemSettingId = data.SystemSettingId,
                SystemSettingMapLocation = data.SystemSettingMapLocation,
                SystemSettingWelcomeNoteBreef = data.SystemSettingWelcomeNoteBreef,
                SystemSettingWelcomeNoteDesc = data.SystemSettingWelcomeNoteDesc,
                SystemSettingWelcomeNoteTitle = data.SystemSettingWelcomeNoteTitle,
                SystemSettingWelcomeNoteUrl = data.SystemSettingWelcomeNoteUrl,


            };
            return View(datan);
        }

        // POST: SystemSettingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SystemSettingModel collection)
        {
            try
            {
                collection.EditId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                collection.EditDate = DateTime.Now;
                string ImageSave1 = "";
                string ImageSave2 = "";
                string ImageSave3 = "";
                if (collection.File1!=null)
                {
                    string PathImage = Path.Combine(Host.WebRootPath, "images");
                    FileInfo FileInfo = new FileInfo(collection.File1.FileName);
                    ImageSave1 = Guid.NewGuid().ToString() + FileInfo.Extension;
                    string FullPath = Path.Combine(PathImage, ImageSave1);
                    collection.File1.CopyTo(new FileStream(FullPath, FileMode.Create));
                }
                else if(collection.File2!=null) 
                {
                    string PathImage = Path.Combine(Host.WebRootPath, "images");
                    FileInfo FileInfo = new FileInfo(collection.File2.FileName);
                    ImageSave1 = Guid.NewGuid().ToString() + FileInfo.Extension;
                    string FullPath = Path.Combine(PathImage, ImageSave2);
                    collection.File2.CopyTo(new FileStream(FullPath, FileMode.Create));


                }
                else if(collection.File3!=null) 
                {
                    string PathImage = Path.Combine(Host.WebRootPath, "images");
                    FileInfo FileInfo = new FileInfo(collection.File3.FileName);
                    ImageSave1 = Guid.NewGuid().ToString() + FileInfo.Extension;
                    string FullPath = Path.Combine(PathImage, ImageSave3);
                    collection.File3.CopyTo(new FileStream(FullPath, FileMode.Create));
                }
                else
                {
                    ImageSave1 = collection.SystemSettingLogoImageUrl;
                    ImageSave2 = collection.SystemSettingLogoImageUrl2;
                    ImageSave3 = collection.SystemSettingWelcomeNoteImageUrl;
                }
                var data = new SystemSetting
                {
                    SystemSettingWelcomeNoteImageUrl = ImageSave1,
                    SystemSettingLogoImageUrl = ImageSave2,
                    SystemSettingLogoImageUrl2 = ImageSave3,
                    SystemSettingCopyright = collection.SystemSettingCopyright,
                    SystemSettingId = collection.SystemSettingId,
                    SystemSettingMapLocation = collection.SystemSettingMapLocation,
                    SystemSettingWelcomeNoteBreef = collection.SystemSettingWelcomeNoteBreef,
                    SystemSettingWelcomeNoteDesc = collection.SystemSettingWelcomeNoteDesc,
                    SystemSettingWelcomeNoteTitle = collection.SystemSettingWelcomeNoteTitle,
                    SystemSettingWelcomeNoteUrl = collection.SystemSettingWelcomeNoteUrl,


                };
                SystemSetting.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SystemSettingController/Delete/5
        public ActionResult Delete(int id)
        {
            SystemSetting.Delete(id, new Models.SystemSetting());
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Active(int id)
        {
            SystemSetting.Active(id);
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
