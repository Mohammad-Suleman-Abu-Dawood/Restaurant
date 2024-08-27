using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Areas.Admin.ViewModels;
using Restaurant.Models;
using Restaurant.Models.Repositories;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class FeedBackController : Controller
    {

        public IRepository<FeedBack> FeedBacks { get; set; }
        public Microsoft.AspNetCore.Hosting.IHostingEnvironment Host { get; }
        public UserManager<IdentityUser> UserManager { get; }

        public FeedBackController(IRepository<FeedBack> FeedBacks, Microsoft.AspNetCore.Hosting.IHostingEnvironment Host, UserManager<IdentityUser> UserManager)
        {
            this.FeedBacks = FeedBacks;
            this.Host = Host;
            this.UserManager = UserManager;
        }



        // GET: FeedBackController
        public ActionResult Index()
        {
            List<FeedBack> menu = FeedBacks.View();

            var data = menu.Select(x => new FeedBackModel
            {
                IsActive = x.IsActive,
                FeedBackId = x.FeedBackId,
                FeedBackImgUrl = x.FeedBackImgUrl,
                FeedBackMessage = x.FeedBackMessage,
                FeedBackName = x.FeedBackName,
                FeedBackRole = x.FeedBackRole,

            });
            return View(data);
        }

        // GET: FeedBackController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FeedBackController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FeedBackController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FeedBackModel collection)
        {
            try
            {
                var user = await UserManager.FindByNameAsync(User.Identity.Name);
                string ImageSave = SaveImage(collection.Files);
                ImageSave = ImageSave != null ? ImageSave : collection.FeedBackImgUrl;
                var data = new FeedBack
                {
                    FeedBackMessage = collection.FeedBackMessage,
                    FeedBackRole = collection.FeedBackRole,
                    FeedBackName = collection.FeedBackName,
                    CreateId = user.Id,
                    FeedBackImgUrl = ImageSave,

                };
                FeedBacks.Add(data);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FeedBackController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = FeedBacks.Find(id);
            var newdata = new FeedBackModel
            {
                FeedBackImgUrl = data.FeedBackImgUrl,
                FeedBackMessage = data.FeedBackMessage,
                FeedBackName = data.FeedBackName,
                FeedBackRole = data.FeedBackRole,
            };


            return View(newdata);
        }

        // POST: FeedBackController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, FeedBackModel collection)
        {
            try
            {
                var user = await UserManager.FindByNameAsync(User.Identity.Name);
                string ImageSave = SaveImage(collection.Files);
                ImageSave = ImageSave != null ? ImageSave : collection.FeedBackImgUrl;

                var data = FeedBacks.Find(id);
                data.FeedBackName = collection.FeedBackName;
                data.FeedBackMessage = collection.FeedBackMessage;
                data.FeedBackRole = collection.FeedBackRole;
                data.FeedBackImgUrl = ImageSave;
                data.EditId = user.Id;
                FeedBacks.Update(id, data);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FeedBackController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FeedBackController/Delete/5
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
            string ImageSave = null;
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
            FeedBacks.Active(id);
            return RedirectToAction(nameof(Index));
        }
        public ActionResult IsDelete(int idDelete)
        {
            FeedBacks.Delete(idDelete, new Models.FeedBack());
            return RedirectToAction(nameof(Index));
        }
    }
}
