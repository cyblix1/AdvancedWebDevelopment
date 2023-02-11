using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace AdvancedWebDevelopment
{
    public partial class Customer_Search : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtSearch.Text = Session["Search"].ToString();

                string strConnectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
                SqlConnection myConnect = new SqlConnection(strConnectionString);
                myConnect.Open();
                string checksearch = "SELECT COUNT(*) FROM [Products] WHERE name LIKE @search or category LIKE @search";
                SqlCommand com = new SqlCommand(checksearch, myConnect);
                com.Parameters.AddWithValue("@search", txtSearch.Text);
                com.Parameters["@search"].Value = "%" + txtSearch.Text + "%";
                int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
                myConnect.Close();
                if (temp > 0)
                {
                    string strCommandText = "SELECT *";
                    strCommandText += " FROM Products WHERE name LIKE @name OR Category LIKE @category";
                    SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@name"].Value = "%" + txtSearch.Text + "%";
                    cmd.Parameters.Add("@category", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@category"].Value = "%" + txtSearch.Text + "%";
                    myConnect.Open();
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Title");
                    Repeater1.DataSource = ds;
                    Repeater1.DataBind();
                    myConnect.Close();
                }
                else
                {
                    lblnoresult.Visible = true;
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //problem cannot re - search
            Session["Search"] = txtSearch.Text;
            Response.Redirect("Customer_Search.aspx");
        }

    }

}