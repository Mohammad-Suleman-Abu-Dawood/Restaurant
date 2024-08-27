using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Restaurant.Areas.Admin.ViewModels;
using Restaurant.Models;
using Restaurant.Models.Repositories;
using System.Collections.ObjectModel;
using System.Security.Claims;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MasterOfferController : Controller
    {


        public IRepository<MasterOffer> MasterOffer { get; set; }
        public Microsoft.AspNetCore.Hosting.IHostingEnvironment Host { get; }

        public MasterOfferController(IRepository<MasterOffer> _MasterOffer, Microsoft.AspNetCore.Hosting.IHostingEnvironment _host)
        {
            MasterOffer = _MasterOffer;
            Host = _host;
        }
        // GET: MasterOfferController
        public ActionResult Index()
        {
            var data = MasterOffer.View();
            return View(data);
        }

        //// GET: MasterOfferController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: MasterOfferController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterOfferController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterOfferViews collection)
        {
            try
            {
                collection.CreateId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                collection.CreateDate = DateTime.Now;

                string ImageSave = SaveImage(collection.Files);
                ImageSave = ImageSave != null ? ImageSave : collection.MasterOfferImageUrl;
                var data = new MasterOffer
                {
                    MasterOfferId = collection.MasterOfferId,
                    MasterOfferBreef = collection.MasterOfferBreef,
                    MasterOfferDesc = collection.MasterOfferDesc,

                    MasterOfferTitle = collection.MasterOfferTitle,
                    MasterOfferImageUrl = ImageSave,



                };
                MasterOffer.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterOfferController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterOffer.Find(id);
            var datarr = new MasterOfferViews
            {
                MasterOfferId = data.MasterOfferId,
                MasterOfferBreef = data.MasterOfferBreef,
                MasterOfferDesc = data.MasterOfferDesc,
                MasterOfferTitle = data.MasterOfferTitle,
                MasterOfferImageUrl = data.MasterOfferImageUrl,
            };
            return View(datarr);
        }

        // POST: MasterOfferController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterOfferViews collection)
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
                    ImageSave = collection.MasterOfferImageUrl;
                }
                var data = new MasterOffer
                { 
                MasterOfferImageUrl= ImageSave,
                MasterOfferBreef=collection.MasterOfferBreef,
                MasterOfferTitle=collection.MasterOfferTitle,
                MasterOfferId=collection.MasterOfferId,
                MasterOfferDesc=collection.MasterOfferDesc,
                
                };
                MasterOffer.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterOfferController/Delete/5
        public ActionResult Delete(int id)
        {
            //MasterSlider.Delete(id, new Models.MasterSlider());
            //return View();

            var slider = MasterOffer.Find(id);
            if (slider == null)
            {
                return NotFound();
            }
            MasterOffer.Delete(id, slider);
            //return View(slider);
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
            MasterOffer.Active(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
