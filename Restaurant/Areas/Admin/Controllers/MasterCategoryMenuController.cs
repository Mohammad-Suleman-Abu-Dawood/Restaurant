using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using Restaurant.Areas.Admin.ViewModels;
using Restaurant.Models;
using Restaurant.Models.Repositories;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MasterCategoryMenuController : Controller
    {
        public IRepository<MasterCategoryMenu> MasterCategoryMenus { get; }
        public UserManager<IdentityUser> UserManagers { get; }

        public MasterCategoryMenuController(IRepository<MasterCategoryMenu> MasterCategoryMenus, UserManager<IdentityUser> UserManagers)
        {
            this.MasterCategoryMenus = MasterCategoryMenus;
            this.UserManagers = UserManagers;
        }


        // GET: MasterCategoryMenuController
        public ActionResult Index()
        {
            List<MasterCategoryMenu> menu = MasterCategoryMenus.View();

            var data = menu.Select(x => new MasterCategoryMenuModel
            {
                IsActive = x.IsActive,
                MasterCategoryMenuId = x.MasterCategoryMenuId,
                MasterCategoryMenuName = x.MasterCategoryMenuName,

            });


            return View(data);
        }

        // GET: MasterCategoryMenuController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MasterCategoryMenuController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: MasterCategoryMenuController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MasterCategoryMenuModel collection)
        {
            try
            {
                var user = await UserManagers.FindByNameAsync(User.Identity.Name);
                var data = new MasterCategoryMenu
                {
                    MasterCategoryMenuId = collection.MasterCategoryMenuId,
                    MasterCategoryMenuName = collection.MasterCategoryMenuName,
                    CreateDate = DateTime.Now,
                    CreateId = user.Id,
                };

                MasterCategoryMenus.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterCategoryMenuController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterCategoryMenus.Find(id);

            var newdata = new MasterCategoryMenuModel
            {
                MasterCategoryMenuId = data.MasterCategoryMenuId,
                MasterCategoryMenuName = data.MasterCategoryMenuName,
            };

            return View(data);

        }

        // POST: MasterCategoryMenuController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MasterCategoryMenuModel collection)
        {
            try
            {
                var user = await UserManagers.FindByNameAsync(User.Identity.Name);

                var data = MasterCategoryMenus.Find(id);
                data.EditId = user.Id;
                data.EditDate = DateTime.Now;
                data.MasterCategoryMenuId = collection.MasterCategoryMenuId;
                data.MasterCategoryMenuName = collection.MasterCategoryMenuName;

                MasterCategoryMenus.Update(id, data);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterCategoryMenuController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MasterCategoryMenuController/Delete/5
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
        public ActionResult Active(int id)
        {
            MasterCategoryMenus.Active(id);
            return RedirectToAction(nameof(Index));
        }
        public ActionResult IsDelete(int idDelete)
        {
            MasterCategoryMenus.Delete(idDelete, new Models.MasterCategoryMenu());
            return RedirectToAction(nameof(Index));
        }
    }
}
