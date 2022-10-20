using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shoppingweb.DAL;
using System.Data;
namespace Shoppingweb.GUI
{
    public partial class cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["addproduct"].ToString() == "true")
            {
                Session["addproduct"] = "false";
                DataTable dt = new DataTable();
                DataRow dr;
                dt.Columns.Add("ProductId");
                dt.Columns.Add("ProductImage");
                dt.Columns.Add("productname");
                dt.Columns.Add("Quantity");
                dt.Columns.Add("ProductPrice");
                dt.Columns.Add("TotalPrice");


                if (Request.QueryString["id"] != null)
                {
                    if (Session["Buyitems"] == null)
                    {

                        dr = dt.NewRow();
                        SqlConnection con = UtilityDB.ConnectDB();
                        String myquery = "select * from t_shoppingCar where Produceid=" + Request.QueryString["id"];
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandText = myquery;
                        cmd.Connection = con;
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        dr["ProductId"] = ds.Tables[0].Rows[0]["ProductId"].ToString(); ;
                        dr["ProductImage"] = ds.Tables[0].Rows[0]["ProductImage"].ToString();
                        dr["productname"] = ds.Tables[0].Rows[0]["productname"].ToString();
                        dr["Quantity"] = ds.Tables[0].Rows[0]["Quantity"].ToString();
                        dr["ProductPrice"] = ds.Tables[0].Rows[0]["ProductPrice"].ToString();
                        dr["TotalPrice"] = ds.Tables[0].Rows[0]["TotalPrice"].ToString();
                        dt.Rows.Add(dr);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["buyitems"] = dt;
                    }
                    else
                    {

                        dt = (DataTable)Session["buyitems"];  
                        dr = dt.NewRow();
                        SqlConnection con = UtilityDB.ConnectDB();
                        String myquery = "select * from t_shoppingCar where Produceid=" + Request.QueryString["id"];
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandText = myquery;
                        cmd.Connection = con;
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        dr["ProductId"] = ds.Tables[0].Rows[0]["ProductId"].ToString(); ;
                        dr["ProductImage"] = ds.Tables[0].Rows[0]["ProductImage"].ToString();
                        dr["productname"] = ds.Tables[0].Rows[0]["productname"].ToString();
                        dr["Quantity"] = ds.Tables[0].Rows[0]["Quantity"].ToString();
                        dr["ProductPrice"] = ds.Tables[0].Rows[0]["ProductPrice"].ToString();
                        dr["TotalPrice"] = ds.Tables[0].Rows[0]["TotalPrice"].ToString();
                        dt.Rows.Add(dr);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["buyitems"] = dt;

                    }
                }


            }
            else
            {
                DataTable dt;
                dt = (DataTable)Session["buyitems"];
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }

            CalculateTotalAmount();
        }

        private void CalculateTotalAmount()
        {

            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmd = new SqlCommand("select sum(TotalPrice) from t_shoppingCar where Produceid='" + Session.SessionID + "'", conn);
            lblTotalAmount.Text = cmd.ExecuteScalar().ToString();
            cmd.Dispose();
            conn.Close();
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            SqlConnection con = UtilityDB.ConnectDB();
            string query = "insert into o_Order (UserID, Adddate, Amount) values (1, GETDATE() , " + Decimal.Parse(lblTotalAmount.Text) + "); SELECT SCOPE_IDENTITY();";
            SqlCommand cmd = new SqlCommand(query, con);

            int ID = Convert.ToInt32(cmd.ExecuteScalar());

            query = "insert into OrderDetails (OrderID, ProductID, Quantity, Amount) select " + ID + " AS OrderID, ProductID, Quantity, Amount from t_ShoppingCart where Produceid='" + Session.SessionID + "'";

            cmd = new SqlCommand(query, con);

            cmd.ExecuteNonQuery();

            query = "delete from Cart where Produceid='" + Session.SessionID + "'";

            cmd = new SqlCommand(query, con);

            cmd.ExecuteNonQuery();

            cmd.Dispose();
            con.Close();
        }

        protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            CalculateTotalAmount();
        }

        protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            CalculateTotalAmount();
        }
    }
}