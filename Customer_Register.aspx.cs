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
    public partial class Customer_Register : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //function to check password complexity
        private bool ValidatePassword(string password)
        {
            //need to have 1 lower case, 1 upper case, 1 number, 1 special character, at least 8 characters
            bool hasUpperCaseLetter = false;
            bool hasLowerCaseLetter = false;
            bool hasDecimalDigit = false;
            bool hasSpecialChar = false;

            if (password.Length < 8)
                return false;

            foreach (char c in password)
            {
                if (char.IsUpper(c))
                    hasUpperCaseLetter = true;
                else if (char.IsLower(c))
                    hasLowerCaseLetter = true;
                else if (char.IsDigit(c))
                    hasDecimalDigit = true;
                else
                    hasSpecialChar = true;

                if (hasUpperCaseLetter && hasLowerCaseLetter && hasDecimalDigit && hasSpecialChar)
                    return true;
            }
            return false;
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            //Server side password complexity check 
            string passwordcheck = password.Text;
            bool validate = ValidatePassword(passwordcheck);
            if (validate == true) //means meet password requirements 
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
                    string insertQuery = "INSERT INTO Customers (name, email, phoneNo, hashedPassword, passwordAge, PasswordSalt, dateCreated) " +
                    "values (@name, @email, @phone, @password, @age, @salt, @created)";
                    //Create Salt
                    var salt = Hash.CreateSalt();
                    string storedsalt = Convert.ToBase64String(salt);
                    var hash = Hash.HashPassword(password.Text, salt);
                    string storedhash = Convert.ToBase64String(hash);
                    SqlCommand com = new SqlCommand(insertQuery, conn);
                    com.Parameters.AddWithValue("@name", name.Text);
                    com.Parameters.AddWithValue("@email", email.Text);
                    com.Parameters.AddWithValue("@phone", phone.Text);
                    com.Parameters.AddWithValue("@password", storedhash);
                    com.Parameters.AddWithValue("@age", 1);
                    com.Parameters.AddWithValue("@salt", storedsalt);
                    com.Parameters.AddWithValue("@created", dt);
                    com.ExecuteNonQuery();

                    //Now need to do the authentication thing 
                    string code = GenerateCode();
                    SendCode(email.Text, code);
                    Session["code"] = code;
                    Session["emailotp"] = email.Text;
                    Response.Redirect("Customer_EmailVerfication.aspx");


                }
                conn.Close();
                name.Text = "";
                email.Text = "";
                phone.Text = "";
                password.Text = "";
                password2.Text = "";
            }
            else
            {
                Response.Write("<script>alert('Please enter a valid password, need to have 1 lower case, 1 upper case, 1 number, 1 special character, at least 8 characters');</script>");
            }

        }

        //2FA authentication stuff
        //generate random code 
        static string GenerateCode()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var buffer = new byte[4];
                rng.GetBytes(buffer);
                int result = BitConverter.ToInt32(buffer, 0);

                return result.ToString("D6");
            }
        }
        //send email stuff 
        static void SendCode(string email, string code)
        {
            // Setup SMTP client
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("AWADtest123@gmail.com", "ivfsqbqeehuueita");

            // Create email message
            MailMessage message = new MailMessage();
            message.From = new MailAddress("AWADtest123@gmail.com");
            message.To.Add(email);
            message.Subject = "Two-Factor Authentication Code";
            message.Body = "Your authentication code is: " + code;

            // Send email
            client.Send(message);
        }
    }
}