using System.Linq;
using System.Web.Http;
using WebAPI_Orders.Models;

namespace WebAPI_Orders.Controllers
{
    [RoutePrefix("api/orders")]
    public class OrdersController : ApiController
    {
        northwindEntities3 db = new northwindEntities3();

        public OrdersController()
        {
            db.Configuration.LazyLoadingEnabled = false;
            db.Configuration.ProxyCreationEnabled = false;
        }

        [HttpGet]
        [Route("employee-five-orders")]
        public IHttpActionResult GetOrdersOfEmployeeFive()
        {
            var orders = db.Orders
                           .Where(o => o.EmployeeID == 5)
                           .Select(o => new
                           {
                               o.OrderID,
                               o.OrderDate,
                               o.ShipName,
                               o.ShipCountry
                           })
                           .ToList();

            return Ok(orders);
        }


        [HttpGet]
        [Route("customersbycountry")]
        public IHttpActionResult GetCustomersByCountry(string country)
        {
            var customers = db.GetCustomersByCountry(country).ToList();
            return Ok(customers);
        }
    }
}
