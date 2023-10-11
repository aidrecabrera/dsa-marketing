using dsa_marketing.Models;
using Microsoft.AspNetCore.Mvc;

namespace dsa_marketing.Controllers
{
    public class TransactionDocumentsController : Controller
    {
        private DsaClusterContext _context;
        public TransactionDocumentsController(DsaClusterContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            return View(_context.TransactionDocuments.ToList());
        }
    }
}
