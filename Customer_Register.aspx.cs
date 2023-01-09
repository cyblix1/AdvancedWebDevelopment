using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Configuration;


namespace AdvancedWebDevelopment
{
    public partial class Customer_Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);
            conn.Open();
            bool exists = false;
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM [Customers] WHERE email = @email", conn))
            {
                //checks if the email that the user has entered exists in the database table
                cmd.Parameters.AddWithValue("Email", email.Text);
                exists = (int)cmd.ExecuteScalar() > 0;
            }
            //Check if email exists
            if (exists)
            {
                Response.Write("<script>Alert('Sorry, Email is already taken!');</script>");
            }
            else
            {
                string insertQuery = "INSERT INTO Customers (name, email, phoneNo, hashedPassword, passwordAge, dateCreated) " +
                "values (@name, @email, @phone, @password, @age, @created)";
                //------------IMP (hashing/password comparison not done)-------------
                SqlCommand com = new SqlCommand(insertQuery, conn);
                com.Parameters.AddWithValue("@name", name.Text);
                com.Parameters.AddWithValue("@email", email.Text);
                com.Parameters.AddWithValue("@phone", phone.Text);
                com.Parameters.AddWithValue("@password", password.Text);
                com.Parameters.AddWithValue("@age", 1);
                com.Parameters.AddWithValue("@created", dt);
                com.ExecuteNonQuery();
                Response.Redirect("Customer_Index.aspx");
                Response.Write("<script>alert('Successfully created account! Welcome! ');</script>");
            }
            conn.Close();
            name.Text = "";
            email.Text = "";
            phone.Text = "";
            password.Text = "";
            password2.Text = "";
        }
    }
}