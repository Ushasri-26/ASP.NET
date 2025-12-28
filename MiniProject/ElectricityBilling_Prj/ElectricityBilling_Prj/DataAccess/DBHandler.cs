using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ElectricityBilling_Prj.DataAccess
{
    public class DBHandler
    {
        public SqlConnection GetConnection()
        {
            return new SqlConnection(
                ConfigurationManager.ConnectionStrings["EBConnection"].ConnectionString);
        }
    }
}