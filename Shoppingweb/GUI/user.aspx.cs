using Shoppingweb.BLL;
using Shoppingweb.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shoppingweb.GUI
{
    public partial class user : System.Web.UI.Page
    {
        SqlCommand cmd;
        SqlConnection con;
        DataTable dt;
        SqlDataAdapter adapter;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BuildGridView();
            }
        }
        private void BuildGridView() {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["Shopping"].ConnectionString);
            cmd = new SqlCommand("SELECT * FROM t_user", con);
            con.Open();
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
                adapter.Dispose();
                cmd.Dispose();
                con.Close();
            }
            else {
                
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }
       
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            User deluser = new User();
            try
            {
                deluser.DeleteUser(Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString()));
                BuildGridView();
                lblSuccessMessage.Text = "Selected Record Deleted";
                lblErrorMessage.Text = "";
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }


        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BuildGridView();

        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            User user = new User();
            try
            {
                user.Username = (GridView1.Rows[e.RowIndex].FindControl("txtUsernameFooter") as TextBox).Text.Trim();
                user.Password = (GridView1.Rows[e.RowIndex].FindControl("txtPasswordFooter") as TextBox).Text.Trim();
                user.Name = (GridView1.Rows[e.RowIndex].FindControl("txtNameFooter") as TextBox).Text.Trim();
                user.Address = (GridView1.Rows[e.RowIndex].FindControl("txtAddressFooter") as TextBox).Text.Trim();
                user.Sex = Convert.ToInt32((GridView1.Rows[e.RowIndex].FindControl("txtSexFooter") as TextBox).Text.Trim());
                user.Phonenumber = (GridView1.Rows[e.RowIndex].FindControl("txtPhonenumberFooter") as TextBox).Text.Trim();
                user.Email = (GridView1.Rows[e.RowIndex].FindControl("txtEmailFooter") as TextBox).Text.Trim();
                user.UpdateUser(user);
                GridView1.EditIndex = -1;
                BuildGridView();
                lblSuccessMessage.Text = "Selected Record Updated";
                lblErrorMessage.Text = "";
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BuildGridView();
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e) {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {
                    User user = new User();
                    //user.Id = Convert.ToInt32((GridView1.FooterRow.FindControl("txtIdFooter") as TextBox).Text.Trim());
                    user.Username = (GridView1.FooterRow.FindControl("txtUsernameFooter") as TextBox).Text.Trim();
                    user.Password = (GridView1.FooterRow.FindControl("txtPasswordFooter") as TextBox).Text.Trim();
                    user.Name = (GridView1.FooterRow.FindControl("txtNameFooter") as TextBox).Text.Trim();
                    user.Address = (GridView1.FooterRow.FindControl("txtAddressFooter") as TextBox).Text.Trim();
                    user.Sex = Convert.ToInt32((GridView1.FooterRow.FindControl("txtSexFooter") as TextBox).Text.Trim());
                    user.Phonenumber = (GridView1.FooterRow.FindControl("txtPhonenumberFooter") as TextBox).Text.Trim();
                    user.Email = (GridView1.FooterRow.FindControl("txtEmailFooter") as TextBox).Text.Trim();
                    user.SaveUser(user);
                    BuildGridView();
                    lblSuccessMessage.Text = "New Record Added";
                    lblErrorMessage.Text = "";
                }
            }
            catch (Exception ex){
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }

       
    }
}