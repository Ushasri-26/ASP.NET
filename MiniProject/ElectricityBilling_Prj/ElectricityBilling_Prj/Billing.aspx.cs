using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ElectricityBilling_Prj.Models;
using ElectricityBilling_Prj.Utilities;
namespace ElectricityBilling_Prj
{
    public partial class Billing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("LoginForm.aspx");
            }
        }
        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                ElectricityBill eb = new ElectricityBill();
                BillValidator validator = new BillValidator();
                ElectricityBoard board = new ElectricityBoard();

                eb.ConsumerNumber = txtConsumerNumber.Text;
                eb.ConsumerName = txtConsumerName.Text;

                int units = int.Parse(txtUnits.Text);

                string msg = validator.ValidateUnitsConsumed(units);
                if (msg != "Valid")
                {
                    lblResult.Text = msg;
                    return;
                }

                eb.UnitsConsumed = units;
                board.CalculateBill(eb);
                board.AddBill(eb);

                lblResult.Text =
                    eb.ConsumerNumber + " " +
                    eb.ConsumerName + " " +
                    eb.UnitsConsumed +
                    " Bill Amount : " + eb.BillAmount;
            }
            catch (FormatException ex)
            {
                lblResult.Text = ex.Message;
            }
            catch (Exception ex)
            {
                lblResult.Text = ex.Message;
            }

        }
    }
}