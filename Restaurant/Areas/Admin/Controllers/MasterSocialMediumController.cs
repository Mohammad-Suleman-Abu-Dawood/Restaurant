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
    public class MasterSocialMediumController : Controller
    {
        public IRepository<MasterSocialMedium> MasterSocialMedium { get; }
        public Microsoft.AspNetCore.Hosting.IHostingEnvironment Host { get; }

        public MasterSocialMediumController(IRepository<MasterSocialMedium> _MasterSocialMedium, Microsoft.AspNetCore.Hosting.IHostingEnvironment _Host)
        {
            MasterSocialMedium = _MasterSocialMedium;
            Host = _Host;
        }
        // GET: MasterSocialMediumController
        public ActionResult Index()
        {
            var data = MasterSocialMedium.View();
            return View(data);
        }

        

        // GET: MasterSocialMediumController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterSocialMediumController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterSocialMediumModel collection)
        {
            try
            {
                collection.CreateId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                collection.CreateDate = DateTime.Now;
                string ImageSave = SaveImage(collection.Files);
                ImageSave = ImageSave != null ? ImageSave : collection.MasterSocialMediumImageUrl;
                var data = new MasterSocialMedium
                {
                  MasterSocialMediumId=collection.MasterSocialMediumId,
                  MasterSocialMediumImageUrl=ImageSave,
                  MasterSocialMediumUrl=collection.MasterSocialMediumUrl

                };
                MasterSocialMedium.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterSocialMediumController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterSocialMedium.Find(id);
            var datan = new MasterSocialMediumModel
            {
                MasterSocialMediumId = data.MasterSocialMediumId,
                MasterSocialMediumImageUrl = data.MasterSocialMediumImageUrl,
                MasterSocialMediumUrl = data.MasterSocialMediumUrl


            };
            return View(datan);
        }

        // POST: MasterSocialMediumController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterSocialMediumModel collection)
        {
            try
            {
                collection.EditId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                collection.EditDate = DateTime.Now;
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
                    ImageSave = collection.MasterSocialMediumImageUrl;
                }
                var data = new MasterSocialMedium
                {
                    MasterSocialMediumId = collection.MasterSocialMediumId,
                    MasterSocialMediumImageUrl = ImageSave,
                    MasterSocialMediumUrl = collection.MasterSocialMediumUrl

                };
                MasterSocialMedium.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterSocialMediumController/Delete/5
        public ActionResult Delete(int id)
        {
            MasterSocialMedium.Delete(id, new Models.MasterSocialMedium());
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Active(int id)
        {
            MasterSocialMedium.Active(id);
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
