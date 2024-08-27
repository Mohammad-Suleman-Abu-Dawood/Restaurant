using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using Restaurant.Models.Repositories;
using System.Security.Claims;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MasterWorkingHourController : Controller
    {
        public IRepository<MasterWorkingHour> MasterWorkingHour { get; }

        public MasterWorkingHourController(IRepository<MasterWorkingHour> _MasterWorkingHour)
        {
            MasterWorkingHour = _MasterWorkingHour;
        }
        // GET: MasterWorkingHourController
        public ActionResult Index()
        {
            var data = MasterWorkingHour.View();
            return View(data);
        }

        

        // GET: MasterWorkingHourController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterWorkingHourController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterWorkingHour collection)
        {
            try
            {
                collection.CreateId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                collection.CreateDate = DateTime.Now;
                MasterWorkingHour.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterWorkingHourController/Edit/5
        public ActionResult Edit(int id)
        {
            var data= MasterWorkingHour.Find(id);
            return View(data);
        }

        // POST: MasterWorkingHourController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterWorkingHour collection)
        {
            try
            {
                collection.EditId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                collection.EditDate = DateTime.Now;
                MasterWorkingHour.Update(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterWorkingHourController/Delete/5
        public ActionResult Delete(int id)
        {
            MasterWorkingHour.Delete(id, new Models.MasterWorkingHour());
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Active(int id)
        {
            MasterWorkingHour.Active(id);
            return RedirectToAction(nameof(Index));
        }


    }
}
