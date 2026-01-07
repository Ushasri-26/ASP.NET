using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Products_Assignment
{
    public partial class Products : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void GetProductsByName(string productname)
        {
            SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB; initial catalog=productdb;" +
                "integrated security=true;");
    //        SqlConnection con = new SqlConnection(
    //ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("spGetProductByName", con);
            da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "@Productname";
            param1.Value = productname;
            da.SelectCommand.Parameters.Add(param1);
            ds.Clear();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
            if (ds.Tables[0].Rows.Count > 0)
            {
                img.ImageUrl = ds.Tables[0].Rows[0]["ImagePath"].ToString();
            }

        }

        protected void ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetProductsByName(ddl.SelectedValue);
            lbl.Text = "";

        }

        protected void btn_Click(object sender, EventArgs e)
        {
            GetProductsByName(ddl.SelectedValue);
            lbl.Text = "Price : RS." + ds.Tables[0].Rows[0]["Price"].ToString();
        }
    }
}