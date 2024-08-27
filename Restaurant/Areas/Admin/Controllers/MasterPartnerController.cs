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
    public class MasterPartnerController : Controller
    {
        public IRepository<MasterPartner> MasterPartner { get; }
        public Microsoft.AspNetCore.Hosting.IHostingEnvironment Host { get; }

        public MasterPartnerController(IRepository<MasterPartner> _MasterPartner, Microsoft.AspNetCore.Hosting.IHostingEnvironment _Host)
        {
            MasterPartner = _MasterPartner;
            Host = _Host;
        }
        // GET: MasterPartnerController
        public ActionResult Index()
        {
            var data = MasterPartner.View();
            return View(data);
        }


        // GET: MasterPartnerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterPartnerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterPartnerModel collection)
        {
            try
            {
                collection.CreateId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                collection.CreateDate = DateTime.Now;
                string ImageSave = SaveImage(collection.File1);
                ImageSave = ImageSave != null ? ImageSave : collection.MasterPartnerLogoImageUrl;
                var data = new MasterPartner
                { 
                MasterPartnerLogoImageUrl = ImageSave,
                MasterPartnerId=collection.MasterPartnerId,
                MasterPartnerName=collection.MasterPartnerName,
                MasterPartnerWebsiteUrl=collection.MasterPartnerWebsiteUrl,
                };
                MasterPartner.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterPartnerController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterPartner.Find(id);
            var datan = new MasterPartnerModel
            {
                MasterPartnerLogoImageUrl = data.MasterPartnerLogoImageUrl,
                MasterPartnerId = data.MasterPartnerId,
                MasterPartnerName = data.MasterPartnerName,
                MasterPartnerWebsiteUrl = data.MasterPartnerWebsiteUrl,


            };
            return View(datan);
        }

        // POST: MasterPartnerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterPartnerModel collection)
        {
            try
            {
                collection.EditId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                collection.EditDate = DateTime.Now;
                string ImageSave = "";
                if (collection.File1 != null)
                {
                    string PathImage = Path.Combine(Host.WebRootPath, "Images");
                    FileInfo FileInfo = new FileInfo(collection.File1.FileName);
                    ImageSave = Guid.NewGuid().ToString() + FileInfo.Extension;
                    string FullPath = Path.Combine(PathImage, ImageSave);
                    collection.File1.CopyTo(new FileStream(FullPath, FileMode.Create));


                }
                else
                {
                    ImageSave = collection.MasterPartnerLogoImageUrl;
                }
                var data = new MasterPartner
                {
                    MasterPartnerLogoImageUrl = ImageSave,
                    MasterPartnerId = collection.MasterPartnerId,
                    MasterPartnerName = collection.MasterPartnerName,
                    MasterPartnerWebsiteUrl = collection.MasterPartnerWebsiteUrl,

                };
                MasterPartner.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterPartnerController/Delete/5
        public ActionResult Delete(int id)
        {
            MasterPartner.Delete(id, new Models.MasterPartner());
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
        public ActionResult Active(int id)
        {
            MasterPartner.Active(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
