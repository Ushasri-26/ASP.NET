using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls.WebParts;
using context = System.Web.HttpContext;

namespace Exception_Prj
{
    public static class ExceptionLoggingDb
    {
        static string exepurl;
        static SqlConnection con;

        static void getConnection()
        {
            string constr = ConfigurationManager.ConnectionStrings["dblogconn"].ToString();
            con = new SqlConnection(constr);
            con.Open();
        }
        public static void WriteErrorLogToDB(Exception exdb)
        {
            getConnection();
            exepurl = context.Current.Request.Url.ToString();

            SqlCommand cmd = new SqlCommand("ExceptionLoggingTodatabase", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@excmsg", exdb.Message.ToString());
            cmd.Parameters.AddWithValue("@exctype", exdb.GetType().Name.ToString());
            cmd.Parameters.AddWithValue("@excsrc", exdb.StackTrace.ToString());
            cmd.Parameters.AddWithValue("@excurl", exepurl);
            cmd.ExecuteNonQuery();
        }
    }
}