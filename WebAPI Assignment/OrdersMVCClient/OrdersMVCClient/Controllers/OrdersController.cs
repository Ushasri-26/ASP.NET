using OrdersMVCClient.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OrdersMvcClient.Controllers
{
    public class OrdersController : Controller
    {
        private readonly string apiBaseUrl = "http://localhost:51559/api/orders/";

        public async Task<ActionResult> Index()
        {
            List<EmployeeOrderView> ordersList = new List<EmployeeOrderView>();

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new System.Uri(apiBaseUrl);

                HttpResponseMessage response =
                    await client.GetAsync("employee-five-orders");

                if (response.IsSuccessStatusCode)
                {
                    ordersList =
                        await response.Content
                        .ReadAsAsync<List<EmployeeOrderView>>();
                }
            }

            return View(ordersList);
        }
    }
}