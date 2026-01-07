using ElectricityBilling_Prj.Models;
using ElectricityBilling_Prj.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElectricityBilling_Prj
{
    public partial class ViewBills : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("LoginForm.aspx");
            }
        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            int n = int.Parse(txtCount.Text);

            ElectricityBoard board = new ElectricityBoard();
            List<ElectricityBill> list = board.Generate_N_BillDetails(n);

            GridView1.DataSource = list;
            GridView1.DataBind();
        }
    }
}