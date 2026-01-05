using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Exception_Prj
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds.ReadXml("~/Employee.xml");
            GridView1.DataSource= ds;
            GridView1.DataBind();
        //}
        //catch (System.IO.FileNotFoundException fnf)
        //{
        //    Label1.Text = "The requested file is not found";
        }
        //protected void Page_Error(object sender, EventArgs e)
        //{
        //    Exception ex = Server.GetLastError();
        //    Server.ClearError();
        //    // Response.Write(ex.GetType()); this gives specific details

        //    // Response.Write(Server.GetLastError());  // this gives a very detailed error info.
        //    Server.Transfer("~/err.aspx");

        //}

    }
}