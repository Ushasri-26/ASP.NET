using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElectricityBilling_Prj
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnAddBill_Click(object sender, EventArgs e)
        {
            Response.Redirect("Billing.aspx");
        }

        protected void btnViewBills_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewBills.aspx");
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("LoginForm.aspx");
        }
    }
}