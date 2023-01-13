﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using PasswordHashing;
using System.Security.Cryptography;
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
                string checkPasswordQuery = "SELECT hashedPassword, PasswordSalt FROM Customers WHERE email = @email2";
                SqlCommand pwcomm = new SqlCommand(checkPasswordQuery, conn);
                pwcomm.Parameters.AddWithValue("@email2", email.Text);
                string password2 = pwcomm.ExecuteScalar().ToString();
                SqlDataReader reader = pwcomm.ExecuteReader();
                string hashvalue = reader.GetString(0);
                string saltvalue = reader.GetString(1);
                var hashvalue2 = Convert.FromBase64String(hashvalue);
                var saltvalue2 = Convert.FromBase64String(saltvalue);
                //Hashing here (
                bool flag = Hash.VerifyHash(password.Text, saltvalue2,hashvalue2);
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