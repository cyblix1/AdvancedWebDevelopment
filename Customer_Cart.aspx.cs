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
    public partial class Customer_Cart : BasePage
    {
        ShoppingCart myCart;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                myCart = (ShoppingCart)Session["myCart"];
                FillData();
            }
        }

        private void FillData()
        {
            if (myCart == null)
            {
                myCart = new ShoppingCart();
                Session["myCart"] = myCart;
            }
            Repeater1.DataSource = myCart.Items;
            Repeater1.DataBind();
            if (myCart.Items.Count == 0)
            {
                lblGrandTotal.Text = "$0";
            }
            else
            {
                lblGrandTotal.Text = Convert.ToString(myCart.GrandTotal);
            }
        }

        protected void DeleteRow(object sender, EventArgs e)
        {
            myCart = (ShoppingCart)Session["myCart"];
            LinkButton deleteButton = (LinkButton)sender;
            int productId = Convert.ToInt32(deleteButton.CommandArgument);
            myCart.Delete(productId);
            FillData();
            Session["myCart"] = myCart;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            myCart = (ShoppingCart)Session["myCart"];

            foreach (RepeaterItem item in Repeater1.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    TextBox txtQuantity = (TextBox)item.FindControl("txtQuantity");
                    TextBox txtProductID = (TextBox)item.FindControl("txtId");
                    int productID = Convert.ToInt32(txtProductID.Text);
                    int quantity = Convert.ToInt32(txtQuantity.Text);
                    myCart.Update(productID, quantity);
                }
            }

            FillData();
            Session["myCart"] = myCart;
        }
    }
}