using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrdersMVCClient.Models
{
    public class EmployeeOrderView
    {
        public int OrderID { get; set; }
        public DateTime? OrderDate { get; set; }
        public string ShipName { get; set; }
        public string ShipCountry { get; set; }
    }
}