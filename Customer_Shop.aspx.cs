using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace AdvancedWebDevelopment
{
    public partial class Customer_Shop : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet shirts = GetShirt();
            DataSet shoes = GetShoes();
            DataSet Accessories = GetAccessories();
            Repeater1.DataSource = shirts;
            Repeater2.DataSource = shoes;
            Repeater3.DataSource = Accessories;
            Repeater1.DataBind();
            Repeater2.DataBind();
            Repeater3.DataBind();
        }

        //for Shirt 
        private DataSet GetShirt()
        {
            string d = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(d))
            {
                SqlDataAdapter cmd = new SqlDataAdapter("SELECT * FROM Products WHERE category='Shirt'", conn);
                DataSet prod = new DataSet();
                cmd.Fill(prod);
                return prod;
            }
        }

        private DataSet GetShoes()
        {
            string d = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(d))
            {
                SqlDataAdapter cmd = new SqlDataAdapter("SELECT * FROM Products WHERE category='Shoes'", conn);
                DataSet prod = new DataSet();
                cmd.Fill(prod);
                return prod;
            }
        }

        private DataSet GetAccessories()
        {
            string d = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(d))
            {
                SqlDataAdapter cmd = new SqlDataAdapter("SELECT * FROM Products WHERE category='Accessories'", conn);
                DataSet prod = new DataSet();
                cmd.Fill(prod);
                return prod;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Session["Search"] = txtSearch.Text;
            Response.Redirect("Customer_Search.aspx");
        }
    }
}