using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Application.Models;

namespace MVC_Application.Controllers
{
    public class CodeController : Controller
    {
        northwindEntities1 db = new northwindEntities1 (); 
        // GET: Code
        public ActionResult CustomersFromGermany()
        {
            var customers = db.Customers.Where(c => c.Country == "Germany").ToList();
            return View(customers);
        }
        public ActionResult CustomerByOrder()
        {
            var customer = (from o in db.Orders
                            join c in db.Customers
                            on o.CustomerID equals c.CustomerID
                            where o.OrderID == 10248
                            select c).FirstOrDefault();
            return View(customer);
        }
    }
}