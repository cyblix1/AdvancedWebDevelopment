using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Configuration;
using PasswordHashing;

namespace AdvancedWebDevelopment
{
    public partial class Customer_Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Session["Email"] = email.Text;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);
            conn.Open();
            string checkuser = "SELECT COUNT(*) FROM Customers WHERE email = @email";
            SqlCommand com = new SqlCommand(checkuser, conn);
            com.Parameters.AddWithValue("@email", email.Text);
            int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
            conn.Close();
            //check if account exists
            if (temp == 1)
            {
                conn.Open();
                string checkPasswordQuery = "SELECT hashedPassword FROM Customers WHERE email = @email2";
                SqlCommand pwcomm = new SqlCommand(checkPasswordQuery, conn);
                pwcomm.Parameters.AddWithValue("@email2", email.Text);
                string password2 = pwcomm.ExecuteScalar().ToString();
                //Test 
                var salt = Hash.CreateSalt();
                var salt2 = Hash.CreateSalt();
                var h1 = Hash.HashPassword("password", salt);
                //Hashing here (must have same salt)
                bool flag = Hash.VerifyHash(password.Text, salt2, h1);
                if (flag)
                {
                    Response.Redirect("Customer_Index.aspx");
                    Response.Write("<script language=javascript>alert('Successful logged in')</script>");
                }
                else
                {
                    Response.Write("<script language=javascript>alert('Password or UserName is not correct')</script>");
                }
            }
            else
            {
                Response.Write("<script language=javascript>alert('Password or UserName is not correct')</script>");
            }
            email.Text = "";
            password.Text = "";
        }
    }
}