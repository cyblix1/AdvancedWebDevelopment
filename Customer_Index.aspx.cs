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
    public partial class Customer_Index : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet c = GetPics();
            Repeater1.DataSource = c;
            Repeater1.DataBind();
        }

        private DataSet GetPics()
        {
            string d = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(d))
            {
                SqlDataAdapter cmd = new SqlDataAdapter("SELECT * FROM Carousell", conn);
                DataSet data = new DataSet();
                cmd.Fill(data);
                return data;
            }
        }

    }
}