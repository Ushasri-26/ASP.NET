using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectricityBilling_Prj.Utilities
{
    public class BillValidator
    {
        public string ValidateUnitsConsumed(int units)
        {
            if (units < 0)
            {
                return "Given units is invalid";
            }
            return "Valid";
        }
    }
}