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
    public partial class Customer_ForgetPassword : System.Web.UI.Page
    {
        public string a1;
        public string a2;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
            string email = Session["email"].ToString();

            //get questions 
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);
            conn.Open();
            //must check who is it (get customerID)
            SqlCommand who = new SqlCommand("SELECT question1,question2,answer1,answer2 FROM SecurityQuestions WHERE email = @email", conn);
            who.Parameters.AddWithValue("@email", email);
            SqlDataReader reader = who.ExecuteReader();
            reader.Read();
            string q1 = reader["question1"].ToString();
            string q2 = reader["question2"].ToString();
            a1 = reader["answer1"].ToString();
            a2 = reader["answer2"].ToString();
            System.Diagnostics.Debug.WriteLine(a1);
            System.Diagnostics.Debug.WriteLine(a2);
            System.Diagnostics.Debug.WriteLine(q1);
            System.Diagnostics.Debug.WriteLine(q2);
            lblquestion1.Text = q1;
            lblquestion2.Text = q2;
            
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login");
        }

        protected void btnSubmit_CLick(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(a2);
            //need check if correct 
            if (txtanswer1.Text == a1)
            {
                if (txtanswer2.Text == a2)
                {
                    //change password site
                    Response.Write("<script language=javascript>alert('Change password!');</script>");
                    Response.Redirect("Changepassword");
                }
                else
                {
                    Response.Write("<script language=javascript>alert('Incorrect Answers');</script>");
                }
            }
            else
            {
                Response.Write("<script language=javascript>alert('Incorrect Answers');</script>");
            }
            txtanswer1.Text = "";
            txtanswer2.Text = "";
        }
    }
}