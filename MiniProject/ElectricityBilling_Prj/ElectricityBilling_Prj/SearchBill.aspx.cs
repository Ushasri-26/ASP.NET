using ElectricityBilling_Prj.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElectricityBilling_Prj
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        DBHandler db = new DBHandler();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("LoginForm.aspx");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection con = db.GetConnection();
            SqlCommand cmd;
            if (rblReportType.SelectedValue == "M")
            {
                if (string.IsNullOrWhiteSpace(txtMonth.Text) ||
                    string.IsNullOrWhiteSpace(txtYear.Text))
                {
                    lblMsg.Text = "Please enter both Month and Year for Monthly Report";
                    return;
                }
                cmd = new SqlCommand(
                    @"SELECT consumer_num, consumer_name,
                             units_consumed, bill_amount, bill_date
                      FROM ElectricityBill
                      WHERE consumer_num=@num
                      AND bill_month=@m AND bill_year=@y order by bill_date ", con);
                cmd.Parameters.AddWithValue("@num", txtConsumerNumber.Text);
                cmd.Parameters.AddWithValue("@m", int.Parse(txtMonth.Text));
                cmd.Parameters.AddWithValue("@y", int.Parse(txtYear.Text));
            }
            else if (rblReportType.SelectedValue == "Y")
            {
                if (string.IsNullOrWhiteSpace(txtYear.Text))
                {
                    lblMsg.Text = "Please enter Year for Yearly Report";
                    return;
                }
                cmd = new SqlCommand(
                                   @"SELECT consumer_num, consumer_name,
                             units_consumed, bill_amount, bill_date
                      FROM ElectricityBill
                      WHERE consumer_num=@num
                      AND bill_year=@y
                      ORDER BY bill_date DESC", con);
                cmd.Parameters.AddWithValue("@num", txtConsumerNumber.Text);
                cmd.Parameters.AddWithValue("@y", int.Parse(txtYear.Text));
            }
            else
            {
                lblMsg.Text = "Please select a report type";
                return;
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    lblMsg.Text = "No records found";
                    gvBills.DataSource = null;
                    gvBills.DataBind();
                }
                else
                {
                    lblMsg.Text = "";
                    gvBills.DataSource = dt;
                    gvBills.DataBind();
                }
            }
        }
    
}