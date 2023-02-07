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
    public partial class ProductDetails : BasePage
    {
        Product prod = null;
        string constr = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            Product aProd = new Product();
            //request stuff
            string prodID = Request.QueryString["ProdID"].ToString();
            prod = aProd.getProduct(prodID);

            lblname.Text = prod.Product_Name;
            lbldesc.Text = prod.Product_Desc;
            lblprice.Text = prod.Unit_Price.ToString("C");
            imgProductDetails.ImageUrl = prod.Product_Image;
        }
    }
}