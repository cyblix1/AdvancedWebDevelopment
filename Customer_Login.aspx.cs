using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using PasswordHashing;
using System.Security.Cryptography;
namespace AdvancedWebDevelopment
{
    public partial class Customer_Login : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //here have SQL injection prevention using stored procedures 
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Session["Email"] = email.Text;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);
            conn.Open();
            //need to check if this account is admin and if it exists 

            //stored
            SqlCommand comadmin = new SqlCommand("GetAdminCountByEmail", conn);
            comadmin.CommandType = CommandType.StoredProcedure;
            comadmin.Parameters.Add(new SqlParameter("@email", email.Text));
            int tempadmin = Convert.ToInt32(comadmin.ExecuteScalar().ToString());
            //admin account exists 
            if (tempadmin == 1)
            {
                //check for admin account 

                //Stored
                SqlCommand pwcommadmin = new SqlCommand("GetAdminByEmail", conn);
                pwcommadmin.CommandType = CommandType.StoredProcedure;
                pwcommadmin.Parameters.Add(new SqlParameter("@email", email.Text));


                SqlDataReader readeradmin = pwcommadmin.ExecuteReader();
                if (readeradmin.HasRows)
                {
                    readeradmin.Read();
                    string password2 = readeradmin["password"].ToString();
                    if (password2 == password.Text)
                    {
                        //means admin account is correct
                        Response.Redirect("Admin_Index.aspx");
                    }
                    else
                    {
                        //incorrect password
                        Response.Write("<script language=javascript>alert('Password or UserName is not correct')</script>");
                    }
                }
            }
            else
            {
                //check for customer account 
                SqlCommand com = new SqlCommand("GetCustomerCountByEmail2", conn);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add(new SqlParameter("@email", email.Text));

                int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
                conn.Close();
                bool flag = false;
                //check if account exists
                if (temp == 1)
                {
                    SqlCommand pwcomm = new SqlCommand("GetCustomerByEmail2", conn);
                    pwcomm.CommandType = CommandType.StoredProcedure;
                    pwcomm.Parameters.Add(new SqlParameter("@email", email.Text));
                    conn.Open();
                    SqlDataReader reader = pwcomm.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        string hashvalue = reader.GetString(0);
                        string saltvalue = reader.GetString(1);
                        var hashvalue2 = Convert.FromBase64String(hashvalue);
                        var saltvalue2 = Convert.FromBase64String(saltvalue);

                        //Hashing here (
                        flag = Hash.VerifyHash(password.Text, saltvalue2, hashvalue2);
                    }
                    else
                    {
                        Console.WriteLine("No data found ");
                    }

                    //Hashing here (
                    if (flag == true)
                    {
                        Session["CHANGE_MASTERPAGE"] = "~/AfterLogin.Master";
                        Session["CHANGE_MASTERPAGE2"] = null;
                        Response.Write("<script language=javascript>alert('Successful logged in')</script>");
                        //Changed masterpage 
                        Response.Redirect("Home");
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
                flag = false;
            }
        }


    }
}