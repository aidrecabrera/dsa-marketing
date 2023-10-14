using dsa_marketing.Models;
using Microsoft.AspNetCore.Mvc;

namespace dsa_marketing.Controllers
{
    public class TransactionsController : Controller
    {
        private DsaClusterContext _context;
        public TransactionsController(DsaClusterContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            return View(_context.Transactions.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                _context.Transactions.Add(transaction);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transaction);
        }
    }
}
