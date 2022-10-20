using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Shoppingweb.GUI
{
    public partial class HomePage : System.Web.UI.Page
    {
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
      
        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["Shopping"].ConnectionString);
            string sql = "Select Title,Price, Num,Image,Information FROM Produces";
            if (!string.IsNullOrEmpty(txtsearch.Text.Trim())) {
                sql += " WHERE Title LIKE @Title + '%'";
                cmd.Parameters.AddWithValue("@Title", txtsearch.Text.Trim());
            }
            cmd.CommandText = sql;
            cmd.Connection = con;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            gvProduces.DataSource = dt;
            gvProduces.DataBind();
        }

        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {

        }
    }
}