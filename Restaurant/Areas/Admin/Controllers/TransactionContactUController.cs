using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using Restaurant.Models.Repositories;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class TransactionContactUController : Controller
    {
        public IRepository<TransactionContactU> TransactionContactU { get; }
        public TransactionContactUController(IRepository<TransactionContactU> _TransactionContactU)
        {
            TransactionContactU = _TransactionContactU;
        }

       

        public IActionResult Index()
        {
            var data = TransactionContactU.View();
            return View(data);
        }
    }
}
