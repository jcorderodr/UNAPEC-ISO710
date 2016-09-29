using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UNAPECIso710.WebExcelCRUD.Helpers;
using UNAPECIso710.WebExcelCRUD.Models;

namespace UNAPECIso710.WebExcelCRUD.Controllers
{
    public class CompanyController : Controller
    {

        private DataContext _dataContext;

        public ActionResult Index()
        {
            _dataContext = new DataContext(Server.MapPath("/"));

            var customers = _dataContext.Customers.Count();
            var categories = _dataContext.Categories.Count();
            var products = _dataContext.Products.Count();
            var orders = _dataContext.Sales.Count();

            var model = new CompanyDetail
            {
                Categories = categories,
                Customers = customers,
                Products = products,
                Orders = orders
            };

            return View(model);
        }

        public ActionResult Customer()
        {
            _dataContext = new DataContext(Server.MapPath("/"));
            var customers = _dataContext.Customers.AsList<Customer>();

            return View(customers);
        }

        public ActionResult Product()
        {
            _dataContext = new DataContext(Server.MapPath("/"));
            var categories = _dataContext.Categories.AsList<Category>();
            var entites = _dataContext.Products.AsList<Product>();

            return View(entites);
        }

        public ActionResult Client()
        {
            _dataContext = new DataContext(Server.MapPath("/"));
            var entites = _dataContext.Clients.AsList<Client>();

            return View(entites);
        }

        public ActionResult Sales()
        {
            _dataContext = new DataContext(Server.MapPath("/"));
            var entites = _dataContext.Sales.AsList<Sale>();

            return View(entites);
        }

        public ActionResult AddSale()
        {
            _dataContext = new DataContext(Server.MapPath("/"));
            var entites = _dataContext.Clients.AsList<Client>();

            ViewData["Users"] = new SelectList(entites, "Id", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddSale(Sale entity)
        {
            _dataContext = new DataContext(Server.MapPath("/"));
            
            return View();
        }

    }
}