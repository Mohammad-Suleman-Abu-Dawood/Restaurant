using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Areas.Admin.ViewModels;
using Restaurant.Models;
using Restaurant.Models.Repositories;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Restaurant.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class MasterSliderController : Controller
    {
        public IRepository<MasterSlider> MasterSliders { get; }
        public IHostingEnvironment Host { get; }
        public UserManager<IdentityUser> UserManagers { get; }

        public MasterSliderController(IRepository<MasterSlider> MasterSliders, IHostingEnvironment Host, UserManager<IdentityUser> UserManagers)
        {
            this.MasterSliders = MasterSliders;
            this.Host = Host;
            this.UserManagers = UserManagers;
        }

        // GET: MasterSliderController
        public ActionResult Index()
        {
            List<MasterSlider> master = MasterSliders.View();
            var data = master.Select(x => new MasterSliderModel
            {
                MasterSliderBreef = x.MasterSliderBreef,
                MasterSliderDesc = x.MasterSliderDesc,
                MasterSliderId = x.MasterSliderId,
                MasterSliderTitle = x.MasterSliderTitle,
                MasterSliderUrl = x.MasterSliderUrl,
                MasterSliderUrl2 = x.MasterSliderUrl2,
                Active = x.IsActive,
            });


            return View(data);
        }

        // GET: MasterSliderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MasterSliderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterSliderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MasterSliderModel collection)
        {
            try
            {
                string ImageSave = SaveImage(collection.files);
                ImageSave = ImageSave != "" ? ImageSave : collection.MasterSliderUrl;
                var user = await UserManagers.FindByNameAsync(User.Identity.Name);

                var data = new MasterSlider
                {
                    MasterSliderDesc = collection.MasterSliderDesc,
                    MasterSliderId = collection.MasterSliderId,
                    MasterSliderTitle = collection.MasterSliderTitle,
                    MasterSliderUrl = ImageSave,
                    MasterSliderUrl2 = collection.MasterSliderUrl2,
                    MasterSliderBreef = collection.MasterSliderBreef,
                    CreateDate = DateTime.Now,
                    CreateId = user.Id
                };

                MasterSliders.Add(data);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterSliderController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterSliders.Find(id);
            var newdata = new MasterSliderModel
            {
                MasterSliderBreef = data.MasterSliderBreef,
                MasterSliderDesc = data.MasterSliderDesc,
                MasterSliderId = data.MasterSliderId,
                MasterSliderTitle = data.MasterSliderTitle,
                MasterSliderUrl = data.MasterSliderUrl,
                MasterSliderUrl2 = data.MasterSliderUrl2,

            };

            return View(newdata);
        }

        // POST: MasterSliderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MasterSliderModel collection)
        {
            try
            {
                string ImageSave = "";

                if (collection.files != null)
                {
                    ImageSave = SaveImage(collection.files);
                    ImageSave = ImageSave != "" ? ImageSave : collection.MasterSliderUrl;
                }
                else
                {
                    ImageSave = collection.MasterSliderUrl;
                }
                var user = await UserManagers.FindByNameAsync(User.Identity.Name);

                var data = MasterSliders.Find(id);
                data.MasterSliderTitle = collection.MasterSliderTitle;
                data.EditDate = DateTime.Now;
                data.EditId = user.Id;
                data.MasterSliderUrl2 = collection.MasterSliderUrl2;
                data.MasterSliderId = collection.MasterSliderId;
                data.MasterSliderUrl = ImageSave;
                data.MasterSliderBreef = collection.MasterSliderBreef;
                data.MasterSliderDesc = collection.MasterSliderDesc;

                MasterSliders.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterSliderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MasterSliderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public string SaveImage(IFormFile Files)
        {
            string ImageSave = "";
            if (Files != null)
            {

                string PathImage = Path.Combine(Host.WebRootPath, "images");
                FileInfo FileInfo = new FileInfo(Files.FileName);
                //ImageSave = DateTime.Now.ToString().Replace("-","").Replace("/","").Replace(":","").Replace(" ","") + FileInfo.Extension;
                ImageSave = Guid.NewGuid().ToString() + FileInfo.Extension;


                string FullPath = Path.Combine(PathImage, ImageSave);

                Files.CopyTo(new FileStream(FullPath, FileMode.Create));

            }
            return ImageSave;
        }
        public ActionResult Active(int id)
        {
            MasterSliders.Active(id);
            return RedirectToAction(nameof(Index));
        }
        public ActionResult IsDelete(int idDelete)
        {
            MasterSliders.Delete(idDelete, new Models.MasterSlider());
            return RedirectToAction(nameof(Index));
        }
    }
}
