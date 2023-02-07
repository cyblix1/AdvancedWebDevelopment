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
        public string lineData2;
        public string shoeData;
        public string shirtData;
        public string ass;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadDataOfLineChart();
            LoadDataOfLineChart2();
            LoadShoes();
            LoadShirts();
            LoadAss();
        }

        public void LoadShoes()
        {
            string strConnectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            SqlConnection myConnect = new SqlConnection(strConnectionString);
            //Open sql connection
            myConnect.Open();
            string strCommandtext = "SELECT Shoes FROM Sold";
            SqlCommand comm = new SqlCommand(strCommandtext, myConnect);
            DataTable dt = new DataTable();
            dt.Load(comm.ExecuteReader());
            //populate
            shoeData = "[";
            foreach (DataRow dr in dt.Rows)
            {
                shoeData += dr["Shoes"] + ",";
            }
            shoeData = shoeData.Remove(shoeData.Length - 1) + ']';

        }


        public void LoadShirts()
        {
            string strConnectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            SqlConnection myConnect = new SqlConnection(strConnectionString);
            //Open sql connection
            myConnect.Open();
            string strCommandtext = "SELECT Shirts FROM Sold";
            SqlCommand comm = new SqlCommand(strCommandtext, myConnect);
            DataTable dt = new DataTable();
            dt.Load(comm.ExecuteReader());
            //populate
            shirtData = "[";
            foreach (DataRow dr in dt.Rows)
            {
                shirtData += dr["Shirts"] + ",";
            }
            shirtData = shirtData.Remove(shirtData.Length - 1) + ']';

        }


        public void LoadAss()
        {
            string strConnectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            SqlConnection myConnect = new SqlConnection(strConnectionString);
            //Open sql connection
            myConnect.Open();
            string strCommandtext = "SELECT Assessories FROM Sold";
            SqlCommand comm = new SqlCommand(strCommandtext, myConnect);
            DataTable dt = new DataTable();
            dt.Load(comm.ExecuteReader());
            //populate
            ass = "[";
            foreach (DataRow dr in dt.Rows)
            {
                ass += dr["Assessories"] + ",";
            }
            ass = ass.Remove(ass.Length - 1) + ']';

        }



        public void LoadDataOfLineChart()
        {
            string strConnectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            SqlConnection myConnect = new SqlConnection(strConnectionString);
            myConnect.Open();

            string strCommandtext = "SELECT MonthValue, TotalMonthlyCount FROM MonthlyStatistics WHERE EventType = 'highTemp'";

            SqlCommand comm = new SqlCommand(strCommandtext, myConnect);

            DataTable dt = new DataTable();
            dt.Load(comm.ExecuteReader());

            lineData = "[";
            foreach (DataRow dr in dt.Rows)
            {
                lineData += "[" + dr["MonthValue"] + "," + dr["TotalMonthlyCount"] + "],";
            }
            lineData = lineData.Remove(lineData.Length - 1) + ']';
        }

        public void LoadDataOfLineChart2()
        {
            string strConnectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            SqlConnection myConnect = new SqlConnection(strConnectionString);
            //Open sql connection
            myConnect.Open();

            string strCommandtext = "SELECT month, profit FROM ProfitMain";

            SqlCommand comm = new SqlCommand(strCommandtext, myConnect);

            //Load data into data tablew
            DataTable dt = new DataTable();
            dt.Load(comm.ExecuteReader());
            //Load data into gridview
            //populate lineData with data required to make chart
            //data format is [ [x1,y1], [x2, y2], ....]
            lineData2 = "[";
            foreach (DataRow dr in dt.Rows)
            {
                lineData2 += dr["profit"] + ",";
            }
            lineData2 = lineData2.Remove(lineData2.Length - 1) + ']';
        }
    }
}