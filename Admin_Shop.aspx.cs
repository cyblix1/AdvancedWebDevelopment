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
    public partial class Admin_Shop : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindRepeater();
            }
        }
        private void BindRepeater()
        {
            string constr = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("Product_CRUD"))
                {
                    cmd.Parameters.AddWithValue("@Action", "SELECT");
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            Repeater1.DataSource = dt;
                            Repeater1.DataBind();
                        }
                    }
                }
            }
        }

        protected void OnEdit(object sender, EventArgs e)
        {
            //Find the reference of the Repeater Item.
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            this.ToggleElements(item, true);
        }

        private void ToggleElements(RepeaterItem item, bool isEdit)
        {
            //Toggle Buttons.
            item.FindControl("lnkEdit").Visible = !isEdit;
            item.FindControl("lnkUpdate").Visible = isEdit;
            item.FindControl("lnkCancel").Visible = isEdit;


            //Toggle Labels.
            item.FindControl("lblname").Visible = !isEdit;
            item.FindControl("lblprice").Visible = !isEdit;

            //Toggle TextBoxes.
            item.FindControl("txtname").Visible = isEdit;
            item.FindControl("txtdesc").Visible = isEdit;
            item.FindControl("txtimg").Visible = isEdit;
            item.FindControl("txtprice").Visible = isEdit;
        }

        protected void OnCancel(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            this.ToggleElements(item, false);
        }

        protected void OnUpdate(object sender, EventArgs e)
        {
            //Find the reference of the Repeater Item.
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;

            //Finds the matching BS_ID in the row of data
            int Id = int.Parse((item.FindControl("prodID") as Label).Text);
            //Trim() allows data to be modified
            string name = (item.FindControl("txtname") as TextBox).Text.Trim();
            string desc = (item.FindControl("txtdesc") as TextBox).Text.Trim();
            string image = (item.FindControl("txtimg") as TextBox).Text.Trim();
            string price = (item.FindControl("txtprice") as TextBox).Text.Trim();

            string constr = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                //using stored procedure
                using (SqlCommand cmd = new SqlCommand("Product_CRUD"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    //call the action UPDATE
                    cmd.Parameters.AddWithValue("@Action", "UPDATE");
                    //pass in new values
                    cmd.Parameters.AddWithValue("@ProductId", Id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@description", desc);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@Image", image);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            //display
            this.BindRepeater();
        }

        protected void OnDelete(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            int Id = int.Parse((item.FindControl("prodID") as Label).Text);

            string constr = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("Product_CRUD"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "DELETE");
                    cmd.Parameters.AddWithValue("@ProductId", Id);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            this.BindRepeater();
        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Session["Search"] = txtSearch.Text;
            Response.Redirect("Customer_Search.aspx");
        }

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin_AddProduct.aspx");
        }
    }
}