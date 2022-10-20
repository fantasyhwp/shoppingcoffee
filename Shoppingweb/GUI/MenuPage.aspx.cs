using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Shoppingweb.DAL;
using System.Configuration;

namespace Shoppingweb.GUI
{
    
    public partial class MenuPage : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["addproduct"] = "false";
        }

      

        protected void productsDisplay_ItemCommand(object source, DataListCommandEventArgs e)
        {
            Session["addproduct"] = "true";
            Response.Redirect("cart.aspx?id=" + e.CommandArgument.ToString());
        }

        protected void productsDisplay_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            
        }

        protected void sortPrice_SelectedIndexChanged1(object sender, EventArgs e)
        {
            productsDisplay.DataSourceID = null;
            if (sortPrice.SelectedItem.Text == "Low to High")
            {
                productsDisplay.DataSource = SqlDataSource3;
                productsDisplay.DataBind();
            }
            else if (sortPrice.SelectedItem.Text == "High to Low")
            {
                productsDisplay.DataSource = SqlDataSource4;
                productsDisplay.DataBind();
            }
            else
            {
                productsDisplay.DataSource = SqlDataSource1;
                productsDisplay.DataBind();
            }
        }

       
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (searchProducts.ToString() != null)
            {
                productsDisplay.DataSourceID = null;
                productsDisplay.DataSource = SqlDataSource2;
                productsDisplay.DataBind();
            }
        }

        protected void productsDisplay_SelectedIndexChanged1(object sender, EventArgs e)
        {
            productsDisplay.DataSourceID = null;
            if (sortPrice.SelectedItem.Text == "Low to High")
            {
                productsDisplay.DataSource = SqlDataSource3;
                productsDisplay.DataBind();
            }
            else if (sortPrice.SelectedItem.Text == "High to Low")
            {
                productsDisplay.DataSource = SqlDataSource4;
                productsDisplay.DataBind();
            }
            else
            {
                productsDisplay.DataSource = SqlDataSource1;
                productsDisplay.DataBind();
            }
        }

        protected void sortPrice_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlQuantity_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}