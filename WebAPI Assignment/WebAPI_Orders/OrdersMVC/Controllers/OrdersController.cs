using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;

namespace OrdersMVC.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Orders
        public ActionResult Index()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44377");
                var response = client.GetAsync("api/orders/employee5").Result;
                ViewBag.Data = response.Content.ReadAsStringAsync().Result;
            }
            return View();
        }
    }
}