using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using Restaurant.Models.Repositories;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class TransactionBookTableController : Controller
    { 
        public IRepository<TransactionBookTable> TransactionBookTable { get; }
        public TransactionBookTableController(IRepository<TransactionBookTable> _TransactionBookTable)
        {
            TransactionBookTable = _TransactionBookTable;
        }

       

        public IActionResult Index()
        {
            var data = TransactionBookTable.View();
            return View(data);
        }
    }
}
