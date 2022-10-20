using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Shoppingweb.GUI
{
  
    public partial class AdminProducesPage : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        SqlDataReader reader;
        DataSet ds;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            BoundField bfield = new BoundField();
            bfield.HeaderText = "Id";
            bfield.DataField = "Id";
            datagrid.Columns.Add(bfield);

            BoundField bfield1 = new BoundField();
            bfield1.HeaderText = "Title";
            bfield1.DataField = "Title";
            datagrid.Columns.Add(bfield1);

            BoundField bfield4 = new BoundField();
            bfield4.HeaderText = "Image";
            bfield4.DataField = "Image";
            datagrid.Columns.Add(bfield4);

            BoundField bfield5 = new BoundField();
            bfield5.HeaderText = "Price";
            bfield5.DataField = "Price";
            datagrid.Columns.Add(bfield5);

            BoundField bfield6 = new BoundField();
            bfield6.HeaderText = "Num";
            bfield6.DataField = "Num";
            datagrid.Columns.Add(bfield6);

            BoundField bfield2 = new BoundField();
            bfield1.HeaderText = "Time";
            bfield1.DataField = "Time";
            datagrid.Columns.Add(bfield2);

            string State = "unapproved";
            BoundField bfield7 = new BoundField();
            bfield1.HeaderText = "State";
            bfield1.DataField = "State";
            datagrid.Columns.Add(bfield7);

            con = new SqlConnection(ConfigurationManager.ConnectionStrings["Shopping"].ConnectionString);
            cmd = new SqlCommand("Select * from Produces where State = @State", con);
            cmd.Parameters.AddWithValue("@State", State);
            con.Open();
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                datagrid.DataSource = dt;
                datagrid.DataBind();
                adapter.Dispose();
                cmd.Dispose();
                con.Close();
                lbldisplay.Text = "";
            }
            else
            {
                lbldisplay.Text = "You don't have anything need to be solved";
            }
        }

        protected void datagrid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void datagrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }
        }
}