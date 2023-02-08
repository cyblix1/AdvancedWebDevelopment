using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using PasswordHashing;

using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;


namespace AdvancedWebDevelopment
{
    public partial class Customer_ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnchangepw_Click(object sender, EventArgs e)
        {
            string p = password.Text;
            var salt = Hash.CreateSalt();
            string storedsalt = Convert.ToBase64String(salt);
            var hash = Hash.HashPassword(password.Text, salt);
            string storedhash = Convert.ToBase64String(hash);
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);
            string updateSql = "UPDATE Customers SET hashedPassword = @hashedPassword, PasswordSalt = @PasswordSalt WHERE email = @email";
            conn.Open();
            SqlCommand cmd = new SqlCommand(updateSql, conn);
            cmd.Parameters.AddWithValue("@hashedPassword", storedhash);
            cmd.Parameters.AddWithValue("@PasswordSalt", storedsalt);
            cmd.Parameters.AddWithValue("@email", Session["email"].ToString());
            int row = cmd.ExecuteNonQuery();
            conn.Close();
            Session["email"] = null;
            Response.Redirect("Login");

        }
    }
}