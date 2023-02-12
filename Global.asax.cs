using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

using System.Web.Routing;
using System.Data;

namespace AdvancedWebDevelopment
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
        }

        static void RegisterRoutes(RouteCollection routes)
        {
            //routes.MapPageRoute("Uniquename", "Name to shown on Adddress bar AND for redirecting", "Physical Path to the page");
            routes.MapPageRoute("Home", "Home", "~/Customer_Index.aspx");
            routes.MapPageRoute("Products", "Shop", "~/Customer_Shop.aspx");
            routes.MapPageRoute("Login", "Login", "~/Customer_Login.aspx");
            routes.MapPageRoute("Registration", "Registration", "~/Customer_Register.aspx");
            routes.MapPageRoute("Search", "Search", "~/Customer_Search.aspx");
            routes.MapPageRoute("Product", "Product", "~/ProductDetails.aspx");
            routes.MapPageRoute("OTP", "EmailVerfication", "~/Customer_EmailVerfication.aspx");
            routes.MapPageRoute("Security", "SecurityQuestions", "~/Customer_Security.aspx");
            routes.MapPageRoute("SecurityEmail", "EmailInput", "~/Customer_ForgetPasswordEmailInput.aspx");
            routes.MapPageRoute("Forgetpass", "forgetpass", "~/Customer_ForgetPassword.aspx");
            routes.MapPageRoute("changepass", "Changepassword", "~/Customer_ChangePassword.aspx");
            routes.MapPageRoute("Cart", "ShoppingCart", "~/Customer_Cart.aspx");
        }


        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}