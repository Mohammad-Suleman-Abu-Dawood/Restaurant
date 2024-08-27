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
    public class MasterItemMenuController : Controller
    {
        public IRepository<MasterItemMenu> MasterItemMenus { get; }
        public IRepository<MasterCategoryMenu> MasterCategoryMenus { get; }
        public Microsoft.AspNetCore.Hosting.IHostingEnvironment Host { get; }
        public UserManager<IdentityUser> UserManagers { get; }

        public MasterItemMenuController(IRepository<MasterItemMenu> MasterItemMenus, IRepository<MasterCategoryMenu> MasterCategoryMenus, Microsoft.AspNetCore.Hosting.IHostingEnvironment Host, UserManager<IdentityUser> UserManagers)
        {
            this.MasterItemMenus = MasterItemMenus;
            this.MasterCategoryMenus = MasterCategoryMenus;
            this.Host = Host;
            this.UserManagers = UserManagers;
        }

        // GET: MasterItemMenuController
        public ActionResult Index()
        {
            List<MasterItemMenu> menu = MasterItemMenus.View();
            var data = menu.Select(x => new MasterItemMenuModel
            {
                IsActive = x.IsActive,
                MasterCategoryMenuId = x.MasterCategoryMenuId,
                MasterItemMenuBreef = x.MasterItemMenuBreef,
                MasterItemMenuDate = x.MasterItemMenuDate,
                MasterItemMenuImageUrl = x.MasterItemMenuImageUrl,
                MasterItemMenuPrice = x.MasterItemMenuPrice,
                MasterItemMenuTitle = x.MasterItemMenuTitle,
                MasterItemMenuId = x.MasterItemMenuId,
                MasterItemMenuDesc = x.MasterItemMenuDesc,
                MasterCategoryMenulink = x.MasterCategoryMenu,
                MasterItemMenuInfo = x.MasterItemMenuInfo,
            });




            return View(data);
        }

        // GET: MasterItemMenuController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MasterItemMenuController/Create
        public ActionResult Create()
        {
            ViewBag.ListOfCategoryMenu = MasterCategoryMenus.View();
            return View();
        }

        // POST: MasterItemMenuController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MasterItemMenuModel collection)
        {
            try
            {


                string ImageSave = SaveImage(collection.Files);
                ImageSave = ImageSave != "" ? ImageSave : collection.MasterItemMenuImageUrl;
                var user = await UserManagers.FindByNameAsync(User.Identity.Name);
                var data = new MasterItemMenu
                {
                    MasterItemMenuDesc = collection.MasterItemMenuDesc,
                    MasterCategoryMenuId = collection.MasterCategoryMenuId,
                    MasterItemMenuDate = collection.MasterItemMenuDate,
                    MasterItemMenuBreef = collection.MasterItemMenuBreef,
                    MasterItemMenuId = collection.MasterItemMenuId,
                    MasterItemMenuImageUrl = ImageSave,
                    MasterItemMenuPrice = collection.MasterItemMenuPrice,
                    MasterItemMenuTitle = collection.MasterItemMenuTitle,
                    CreateDate = DateTime.Now,
                    CreateId = user.Id,
                    MasterItemMenuInfo = collection.MasterItemMenuInfo,
                };

                MasterItemMenus.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterItemMenuController/Edit/5
        public ActionResult Edit(int id)
        {

            ViewBag.ListOfCategoryMenu = MasterCategoryMenus.View();
            var data = MasterItemMenus.Find(id);

            var newdata = new MasterItemMenuModel
            {
                MasterCategoryMenuId = data.MasterCategoryMenuId,
                MasterItemMenuBreef = data.MasterItemMenuBreef,
                MasterItemMenuDate = data.MasterItemMenuDate,
                MasterItemMenuDesc = data.MasterItemMenuDesc,
                MasterItemMenuId = data.MasterItemMenuId,
                MasterItemMenuImageUrl = data.MasterItemMenuImageUrl,
                MasterItemMenuPrice = data.MasterItemMenuPrice,
                MasterItemMenuTitle = data.MasterItemMenuTitle,
                MasterItemMenuInfo = data.MasterItemMenuInfo,

            };

            return View(newdata);
        }

        // POST: MasterItemMenuController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MasterItemMenuModel collection)
        {

            try
            {
                string ImageSave = "";

                if (collection.Files != null)
                {
                    ImageSave = SaveImage(collection.Files);
                    ImageSave = ImageSave != "" ? ImageSave : collection.MasterItemMenuImageUrl;
                }
                else
                {
                    ImageSave = collection.MasterItemMenuImageUrl;
                }

                var user = await UserManagers.FindByNameAsync(User.Identity.Name);

                var newdata = MasterItemMenus.Find(id);
                newdata.MasterItemMenuPrice = collection.MasterItemMenuPrice;
                newdata.MasterItemMenuTitle = collection.MasterItemMenuTitle;
                newdata.MasterItemMenuId = collection.MasterItemMenuId;
                newdata.MasterItemMenuDate = collection.MasterItemMenuDate;
                newdata.MasterCategoryMenuId = collection.MasterCategoryMenuId;
                newdata.MasterItemMenuImageUrl = ImageSave;
                newdata.MasterItemMenuDesc = collection.MasterItemMenuDesc;
                newdata.MasterItemMenuBreef = collection.MasterItemMenuBreef;
                newdata.EditId = user.Id;
                newdata.EditDate = DateTime.Now;
                newdata.MasterItemMenuInfo = collection.MasterItemMenuInfo;
                MasterItemMenus.Update(id, newdata);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterItemMenuController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MasterItemMenuController/Delete/5
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

            MasterItemMenus.Active(id);
            return RedirectToAction(nameof(Index));
        }
        public ActionResult IsDelete(int idDelete)
        {
            MasterItemMenus.Delete(idDelete, new Models.MasterItemMenu());
            return RedirectToAction(nameof(Index));
        }
    }
}
