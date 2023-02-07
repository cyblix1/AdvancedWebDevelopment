using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdvancedWebDevelopment
{
    public partial class AfterLogin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblAfterLogin.Text = Session["Email"].ToString();
        }

        protected void btnSignOut_Click(object sender, EventArgs e)
        {
            Session["CHANGE_MASTERPAGE2"] = "~/CustomerMaster.Master";
            Session["CHANGE_MASTERPAGE"] = null;
            Session["Email"] = null;
            Response.Redirect("Login");
        }
    }
}