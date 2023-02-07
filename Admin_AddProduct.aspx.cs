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
    public partial class Admin_AddProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInsertProduct_Click(object sender, EventArgs e)
        {
            int result = 0;
            string image = "";

            if (FileUpload1.HasFile == true)
            {
                image = "images/" + FileUpload1.FileName;
            }

            Product prod = new Product("0", txtname.Text, txtdesc.Text,
            decimal.Parse(txtprice.Text),
            image, txtcategory.Text);
            result = prod.ProductInsert();

            if (result > 0)
            {
                string saveimg = Server.MapPath(" ") + "\\" + image;
                FileUpload1.SaveAs(saveimg);
                //loadProductInfo();
                //loadProduct();
                //clear1();
                Response.Write("<script>alert('Insert Successful');</script>");
            }
            else 
            {
                Response.Write("<script>alert('Failed to Insert');</script>"); 
            }
            

            txtname.Text = "";
            txtdesc.Text = "";
            txtprice.Text = "";
            txtcategory.Text = "";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin_shop.aspx");
        }
    }
}