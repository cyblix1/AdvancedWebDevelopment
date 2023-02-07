using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for Product
/// </summary>
public class Product
{
    //system.Configuration.ConnectionStringSettings _connStr;
    string _connStr = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
    private string _Id = null;
    private string _name = string.Empty;
    private string _description = "";
    private decimal _price = 0;
    private string _image = "";
    private string _category = "";

    public Product()
    {
    }

    public Product(string prodID, string prodName, string prodDesc,
                   decimal unitPrice, string prodImage, string prodCat)
    {
        _Id = prodID;
        _name = prodName;
        _description = prodDesc;
        _price = unitPrice;
        _image = prodImage;
        _category = prodCat;
    }

    //get/set the attributes of the Product object.
    //note the attribute name (e.g. Product_ID) is same as the actual database field name.
    //this is for ease of referencing.
    public string Product_ID
    {
        get { return _Id; }
        set { _Id = value; }
    }
    public string Product_Name
    {
        get { return _name; }
        set { _name = value; }
    }
    public string Product_Desc
    {
        get { return _description; }
        set { _description = value; }
    }
    public decimal Unit_Price
    {
        get { return _price; }
        set { _price = value; }
    }
    public string Product_Image
    {
        get { return _image; }
        set { _image = value; }
    }

    public string Product_Category
    {
        get { return _category; }
        set { _category = value; }
    }


    //below as the Class methods for some DB operations. 
    public Product getProduct(string prodID)
    {
        Product prodDetail = null;

        string prod_Name, prod_Desc, Prod_Image, Prod_Cat;
        decimal unit_Price;

        string queryStr = "SELECT * FROM Products WHERE Id = @ProdID";

        SqlConnection conn = new SqlConnection(_connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@ProdID", prodID);

        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();

        if (dr.Read())
        {
            prod_Name = dr["name"].ToString();
            prod_Desc = dr["description"].ToString();
            Prod_Image = dr["image"].ToString();
            unit_Price = decimal.Parse(dr["price"].ToString());
            Prod_Cat = dr["category"].ToString();


            prodDetail = new Product(prodID, prod_Name, prod_Desc, unit_Price, Prod_Image, Prod_Cat);
        }
        else
        {
            prodDetail = null;
        }

        conn.Close();
        dr.Close();
        dr.Dispose();

        return prodDetail;
    }

    public int UserDelete(string ID)
    {
        string queryStr = "DELETE FROM Customers WHERE customerId=@ID";
        SqlConnection conn = new SqlConnection(_connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@ID", ID);
        conn.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        conn.Close();
        return nofRow;
    }

    public int ProductInsert()
    {
        int result = 0;
        string queryStr = "INSERT INTO Products(name,description,price,image,category)" + "values (@name, @desc, @price, @img, @cat)";

        SqlConnection conn = new SqlConnection(_connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@name", this.Product_Name);
        cmd.Parameters.AddWithValue("@desc", this.Product_Desc);
        cmd.Parameters.AddWithValue("@price", this.Unit_Price);
        cmd.Parameters.AddWithValue("@img", this.Product_Image);
        cmd.Parameters.AddWithValue("@cat", this.Product_Category);

        conn.Open();
        result += cmd.ExecuteNonQuery();
        conn.Close();

        return result;
    }//end Insert


}