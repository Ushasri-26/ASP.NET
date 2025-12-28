using ElectricityBilling_Prj.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ElectricityBilling_Prj.DataAccess;


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
                "INSERT INTO ElectricityBill(consumer_num,consumer_name,units_consumed,bill_amount) VALUES(@cno,@cname,@units,@amount)", con);

            cmd.Parameters.AddWithValue("@cno", eb.ConsumerNumber);
            cmd.Parameters.AddWithValue("@cname", eb.ConsumerName);
            cmd.Parameters.AddWithValue("@units", eb.UnitsConsumed);
            cmd.Parameters.AddWithValue("@amount", eb.BillAmount);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public List<ElectricityBill> Generate_N_BillDetails(int n)
        {
            List<ElectricityBill> list = new List<ElectricityBill>();

            SqlConnection con = db.GetConnection();

            SqlCommand cmd = new SqlCommand("select top (@n) consumer_num, consumer_name, units_consumed, bill_amount " +
            "from ElectricityBill order by bill_date desc", con);

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

                list.Add(eb);
            }

            con.Close();
            return list;
        }

    }
}