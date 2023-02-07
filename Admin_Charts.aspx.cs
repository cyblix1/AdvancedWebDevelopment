using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace AdvancedWebDevelopment
{
    public partial class Admin_Charts : System.Web.UI.Page
    {
        public string lineData;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadDataOfLineChart();
        }

        public void LoadDataOfLineChart()
        {
            string strConnectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            SqlConnection myConnect = new SqlConnection(strConnectionString);
            //Open sql connection
            myConnect.Open();

            string strCommandtext = "SELECT MonthValue, TotalMonthlyCount FROM MonthlyStatistics WHERE EventType = 'highTemp'";

            SqlCommand comm = new SqlCommand(strCommandtext, myConnect);

            //Load data into data tablew
            DataTable dt = new DataTable();
            dt.Load(comm.ExecuteReader());
            //Load data into gridview
            gvLineChart.DataSource = dt;
            gvLineChart.DataBind();

            //populate lineData with data required to make chart
            //data format is [ [x1,y1], [x2, y2], ....]
            lineData = "[";
            foreach (DataRow dr in dt.Rows)
            {
                lineData += "[" + dr["MonthValue"] + "," + dr["TotalMonthlyCount"] + "],";
            }
            lineData = lineData.Remove(lineData.Length - 1) + ']';
        }
    }
}