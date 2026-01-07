using ElectricityBilling_Prj.DataAccess;
using ElectricityBilling_Prj.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;


namespace ElectricityBilling_Prj.Utilities
{
    public class ElectricityBoard
    {
        DBHandler db = new DBHandler();

        public void CalculateBill(ElectricityBill eb)
        {
            int units = eb.UnitsConsumed;
            double amount = 0;

            if (units > 100)
                amount += Math.Min(units - 100, 200) * 1.5;

            if (units > 300)
                amount += Math.Min(units - 300, 300) * 3.5;

            if (units > 600)
                amount += Math.Min(units - 600, 400) * 5.5;

            if (units > 1000)
                amount += (units - 1000) * 7.5;

            eb.BillAmount = amount;
        }

        public void AddBill(ElectricityBill eb)
        {
            SqlConnection con = db.GetConnection();

            SqlCommand cmd = new SqlCommand(
                "INSERT INTO ElectricityBill(consumer_num,consumer_name,units_consumed,bill_amount,bill_date,bill_month,bill_year) VALUES(@cno,@cname,@units,@amount,@date,@month,@year)", con);

            cmd.Parameters.AddWithValue("@cno", eb.ConsumerNumber);
            cmd.Parameters.AddWithValue("@cname", eb.ConsumerName);
            cmd.Parameters.AddWithValue("@units", eb.UnitsConsumed);
            cmd.Parameters.AddWithValue("@amount", eb.BillAmount);
            cmd.Parameters.AddWithValue("@date", eb.BillDate);
            cmd.Parameters.AddWithValue("@month", eb.BillMonth);
            cmd.Parameters.AddWithValue("@year",eb.BillYear);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public bool IsConsumerValid(string consumerNum,string consumerName)
        {
            SqlConnection con= db.GetConnection();
            SqlCommand cmd = new SqlCommand("select distinct consumer_name from ElectricityBill where consumer_num=@num", con);
            cmd.Parameters.AddWithValue("@num",consumerNum);
            con.Open();
            var result = cmd.ExecuteScalar();
            con.Close();
            if (result == null)
                return true;

            return result.ToString().Trim()
                .Equals(consumerName.Trim(), StringComparison.OrdinalIgnoreCase);
        }

        public bool IsDuplicateMonthlyBill(string consumerNum,int month,int year)
        {
            SqlConnection con = db.GetConnection();
            SqlCommand cmd = new SqlCommand("select count(*) from ElectricityBill " +
                "where consumer_num=@num and bill_month=@m and bill_year=@y", con);
            cmd.Parameters.AddWithValue("@num", consumerNum);
            cmd.Parameters.AddWithValue("@m", month);
            cmd.Parameters.AddWithValue("@y", year);

            con.Open();
            int count = (int)cmd.ExecuteScalar();
            con.Close();
            return count > 0;
        }
        public double GetLastMonthAmount(string consumerNumber)
        {
            SqlConnection con = db.GetConnection();

            SqlCommand cmd = new SqlCommand(
                "SELECT TOP 1 bill_amount FROM ElectricityBill " +
                "WHERE consumer_num=@num ORDER BY created_date DESC", con);
            cmd.Parameters.AddWithValue("@num", consumerNumber);
            con.Open();
            object result = cmd.ExecuteScalar();
            con.Close();

            if (result == null)
                return -1;
            return Convert.ToDouble(result);

        }
        public List<ElectricityBill> Generate_N_BillDetails(int n)
        {
            List<ElectricityBill> list = new List<ElectricityBill>();

            SqlConnection con = db.GetConnection();

            SqlCommand cmd = new SqlCommand("select top (@n) consumer_num, consumer_name, units_consumed, bill_amount,bill_date " +
            "from ElectricityBill order by created_date desc", con);

            cmd.Parameters.AddWithValue("@n", n);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ElectricityBill eb = new ElectricityBill();

                eb.ConsumerNumber = dr["consumer_num"].ToString();
                eb.ConsumerName = dr["consumer_name"].ToString();
                eb.UnitsConsumed = Convert.ToInt32(dr["units_consumed"]);
                eb.BillAmount = Convert.ToDouble(dr["bill_amount"]);
                eb.BillDate = Convert.ToDateTime(dr["bill_date"]);
                list.Add(eb);
            }

            con.Close();
            return list;
        }

    }
}