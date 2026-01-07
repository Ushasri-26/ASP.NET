using ElectricityBilling_Prj.Models;
using ElectricityBilling_Prj.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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
              
                DateTime billDate = Convert.ToDateTime(txtBillDate.Text);
                string dateMsg = validator.ValidateBillDate(billDate);
                if (dateMsg != "Valid")
                {
                    lblResult.Text = dateMsg;
                    return;
                }
                eb.BillDate = billDate;
             
                if (!board.IsConsumerValid(eb.ConsumerNumber, eb.ConsumerName))
                {
                    lblResult.Text = "This consumer number belongs to another customer!";
                    return;
                }
                if (board.IsDuplicateMonthlyBill(
                       eb.ConsumerNumber,
                       eb.BillMonth,
                       eb.BillYear))
                {
                    lblResult.Text = "Bill already exists for this consumer for this month!";
                    return;
                }
               
                double lastAmount = board.GetLastMonthAmount(eb.ConsumerNumber);
                if (lastAmount == -1)
                    lblLastMonthBill.Text = "No previous bill";
                else
                    lblLastMonthBill.Text = lastAmount.ToString();
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
        }
    }
}

