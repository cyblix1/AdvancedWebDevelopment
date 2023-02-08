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
    public partial class Customer_ForgetPasswordEmailInput : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            //check if email exists 
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);
            conn.Open();
            //must check who is it (get customerID)
            SqlCommand who = new SqlCommand("SELECT * FROM SecurityQuestions WHERE email = @email", conn);
            who.Parameters.AddWithValue("@email", txtemail.Text);
            SqlDataReader reader = who.ExecuteReader();
            if (reader.HasRows)
            {
                Session["email"] = txtemail.Text;
                Response.Redirect("forgetpass");
            }
            else
            {
                txtemail.Text = "";
                Response.Write("<script language=javascript>alert('Incorrect Email');</script>");
            }
            reader.Close();
            conn.Close();

        }
    }
}