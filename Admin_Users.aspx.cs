using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using System.Data.SqlClient;
using System.Data;
namespace AdvancedWebDevelopment
{
    public partial class Admin_Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gvUsers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       

        protected void gvUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int result = 0;
            Product prod = new Product();
            string UserID = gvUsers.DataKeys[e.RowIndex].Value.ToString();
            result = prod.UserDelete(UserID);

            if (result > 0)
            {
                Response.Write("<script>alert('User Removed successfully');</script>");
            }
            else
            {
                Response.Write("<script>alert('User Removal NOT successful');</script>");
            }

            Response.Redirect("Admin_Users.aspx");

        }



    }
}