using FinalAssessmentQuestion2.DAL;
using FinalAssessmentQuestion2.Models;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace FinalAssessmentQuestion2.Controllers
{
    public class OrdersController : Controller
    {
        private NorthwindDbContext db = new NorthwindDbContext();

        // GET: Orders
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.Customer).Include(o => o.Employee).Include(o => o.Shipper);
            return View(orders.ToList());
        }

        //GET: Orders with only selected columns
        public ActionResult OrderView()
        {
            var orders = db.Orders.ToList().Select(p => new OrderViewModel
            {
                OrderId = p.OrderID,
                OrderDate = p.OrderDate,
                ShipCity = p.ShipCity
            });

            return View(orders);
        }

        //GET: Orders with only selected columns using overloaded Action method taking in search query string
        [HttpPost]
        public ActionResult OrderView(string searchQuery)
        {
            var orders = db.Orders.ToList().Select(p => new OrderViewModel
            {
                OrderId = p.OrderID,
                OrderDate = p.OrderDate,
                ShipCity = p.ShipCity
            }).Where(p => p.ShipCity.Contains(searchQuery));
            return View(orders);
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
