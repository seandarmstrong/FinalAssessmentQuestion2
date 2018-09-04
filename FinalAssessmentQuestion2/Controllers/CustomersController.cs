using FinalAssessmentQuestion2.DAL;
using FinalAssessmentQuestion2.Models;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace FinalAssessmentQuestion2.Controllers
{
    public class CustomersController : Controller
    {
        private NorthwindDbContext db = new NorthwindDbContext();

        // GET: Customers
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        //GET: Customers with only selected columns
        public ActionResult CustomerView()
        {
            var customers = db.Customers.ToList().Select(p => new CustomerViewModel
            {
                CustomerId = p.CustomerID,
                CompanyName = p.CompanyName
            });

            return View(customers);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
