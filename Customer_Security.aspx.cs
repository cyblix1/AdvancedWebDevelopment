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
    public partial class Customer_Security : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //confirmed clicked
        protected void Button1_Click(object sender, EventArgs e)
        {
            string email = Session["email"].ToString();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);
            conn.Open();
            //must check who is it (get customerID)
            SqlCommand who = new SqlCommand("SELECT customerId FROM Customers WHERE email = @email", conn);
            who.Parameters.AddWithValue("@email", email);
            SqlDataReader reader = who.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                string id = reader["customerId"].ToString();
                reader.Close();
                //get asnwers 
                string q1 = DropDownList1.SelectedValue;
                string q2 = DropDownList3.SelectedValue;
                string a1 = answer1.Text;
                string a2 = answer2.Text;
                //Now need to save stuff 
                string insertQuery = "INSERT INTO SecurityQuestions (Id, email, question1, question2, answer1, answer2) " +
                    "values (@id, @email, @q1, @q2, @a1, @a2)";
                SqlCommand com = new SqlCommand(insertQuery, conn);
                com.Parameters.AddWithValue("@id", id);
                com.Parameters.AddWithValue("@email", email);
                com.Parameters.AddWithValue("@q1", q1);
                com.Parameters.AddWithValue("@q2", q2);
                com.Parameters.AddWithValue("@a1", a1);
                com.Parameters.AddWithValue("@a2", a2);
                com.ExecuteNonQuery();
                conn.Close();
                Response.Write("<script>Alert('Questions Saved');</script>");
                Response.Redirect("Home");
            }
            conn.Close();
        }
    }
}