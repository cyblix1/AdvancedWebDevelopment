using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdvancedWebDevelopment
{
    public partial class Customer_EmailVerfication : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnsubmitotp_Click(object sender, EventArgs e)
        {
            string otp1 = Session["code"].ToString();
            string otp2 = txtOTP.Text;
            string email = Session["emailotp"].ToString();
            if (otp1 == otp2)
            {
                //these stuff is after the autentication is done 
                Session["code"] = null;
                Session["emailotp"] = null;
                Session["CHANGE_MASTERPAGE"] = "~/AfterLogin.Master";
                Session["CHANGE_MASTERPAGE2"] = null;
                Session["Email"] = email;
                Response.Redirect("Home");
                Response.Write("<script>alert('Successfully created account! Welcome! ');</script>");
            }
            else
            {
                Response.Write("<script>alert('Incorrect OTP!');</script>");
            }
        }
    }
}