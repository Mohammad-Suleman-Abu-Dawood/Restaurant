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
    public class MasterContactUsInformationController : Controller
    {
        public IRepository<MasterContactUsInformation> MasterContactUsInformation { get; }
        public Microsoft.AspNetCore.Hosting.IHostingEnvironment Host { get; }

        public MasterContactUsInformationController(IRepository<MasterContactUsInformation> _MasterContactUsInformation , Microsoft.AspNetCore.Hosting.IHostingEnvironment _Host)
        {
            MasterContactUsInformation = _MasterContactUsInformation;
            Host = _Host;
        }

        // GET: MasterContactUsInformationController
        public ActionResult Index()
        {
            var data = MasterContactUsInformation.View();
            return View(data);
        }

       
     

        // GET: MasterContactUsInformationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterContactUsInformationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterContactUsInformationModel collection)
        {
            try
            {
                string ImageSave = "";
                if (collection.Files != null)
                {
                    string PathImage = Path.Combine(Host.WebRootPath, "Images");
                    FileInfo FileInfo = new FileInfo(collection.Files.FileName);
                    ImageSave = Guid.NewGuid().ToString() + FileInfo.Extension;
                    string FullPath = Path.Combine(PathImage, ImageSave);
                    collection.Files.CopyTo(new FileStream(FullPath, FileMode.Create));
                }
                var data = new MasterContactUsInformation
                {
                  MasterContactUsInformationId = collection.MasterContactUsInformationId,
                  MasterContactUsInformationIdesc = collection.MasterContactUsInformationIdesc,
                  MasterContactUsInformationImageUrl = ImageSave,
                  MasterContactUsInformationRedirect=collection.MasterContactUsInformationRedirect,
                    ourMail = collection.ourMail,
                    ourphone = collection.ourphone,
                    ourLocation = collection.ourLocation,

                };
                MasterContactUsInformation.Add(data);
                return RedirectToAction(nameof(Index)); ;
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterContactUsInformationController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterContactUsInformation.Find(id);
            var dataPr = new MasterContactUsInformationModel
            {
                MasterContactUsInformationId = data.MasterContactUsInformationId,
                MasterContactUsInformationIdesc = data.MasterContactUsInformationIdesc,
                MasterContactUsInformationImageUrl = data.MasterContactUsInformationImageUrl,
                MasterContactUsInformationRedirect = data.MasterContactUsInformationRedirect,
                ourMail = data.ourMail,
                ourphone = data.ourphone,
                ourLocation = data.ourLocation,
            };
            return View(dataPr);
        }

        // POST: MasterContactUsInformationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterContactUsInformationModel collection)
        {
            try
            {
                collection.EditDate= DateTime.Now;
                collection.EditId = User.FindFirstValue(ClaimTypes.NameIdentifier);
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

                    ImageSave = collection.MasterContactUsInformationImageUrl;
                }
                var data = new MasterContactUsInformation
                {
                    MasterContactUsInformationId = collection.MasterContactUsInformationId,
                    MasterContactUsInformationIdesc = collection.MasterContactUsInformationIdesc,
                    MasterContactUsInformationImageUrl = ImageSave,
                    MasterContactUsInformationRedirect = collection.MasterContactUsInformationRedirect,
                    ourMail = collection.ourMail,
                    ourphone = collection.ourphone,
                    ourLocation = collection.ourLocation,

                };
                MasterContactUsInformation.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterContactUsInformationController/Delete/5
        public ActionResult Delete(int id)
        {
            MasterContactUsInformation.Delete(id, new Models.MasterContactUsInformation());
            return RedirectToAction(nameof(Index));
        }

       
        public ActionResult Active(int id)
        {
            MasterContactUsInformation.Active(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
