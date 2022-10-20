using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using System.Text.RegularExpressions;
using Shoppingweb.BLL;
using System.Data.SqlClient;
using Shoppingweb.DAL;

namespace Shoppingweb.GUI
{
    public partial class LoginPage : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLoginSignIN_Click(object sender, EventArgs e)
        {
            User user = new User();
            string validateCode = (string)Session["ValidateCode"];
            if (txtboxLoginSignIn.Text == null)
            {
                ClientScript.RegisterStartupScript(GetType(), "Empty", "<script>alert('Please enter your username!');</script>");
            }
            else if (txtboxPasswordSignIN.Text == null)
            {
                ClientScript.RegisterStartupScript(GetType(), "Empty", "<script>alert('Please enter your password!');</script>");
            }
            else if (TxtCheckCode.Text == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Empty", "<script>alert('Please enter the verification code!');</script>");
            }
            else if (TxtCheckCode.Text != validateCode)
            {

                ClientScript.RegisterStartupScript(GetType(), "Empty", "<script>alert('Please enter the verification code!');</script>");
            }
            else {
                if (user.IsValidateLogin(txtboxPasswordSignIN.Text, (txtboxPasswordSignIN.Text)) == true)
                {
                    string sessionusername = txtboxPasswordSignIN.Text;
                    Session["username"] = sessionusername;
                    SqlConnection conn = UtilityDB.ConnectDB();
                    SqlCommand cmdSearchPassword = new SqlCommand();
                    cmdSearchPassword.Connection = conn;
                    cmdSearchPassword.CommandText = "SELECT * FROM t_user WHERE Username = @Username;";
                    cmdSearchPassword.Parameters.AddWithValue("@Username", txtboxPasswordSignIN.Text);
                    SqlDataReader reader = cmdSearchPassword.ExecuteReader();
                    if (reader.Read())
                    {
                        if (Request.Cookies["CheckCode"] != null)
                        {
                            string CheckCodeimg = Request.Cookies["CheckCode"].Value;
                            CheckCodeimg = Server.HtmlEncode(CheckCodeimg);
                            if (TxtCheckCode.Text == CheckCodeimg)
                            {
                                Response.Redirect("MenuPage.aspx");
                            }
                            else
                            {
                                ClientScript.RegisterStartupScript(GetType(), "Incorrect", "<script>alert('Verification code incorrect!');</script>");
                                TxtCheckCode.Text = "";
                            }
                        }
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "Incorrect", "<script>alert('Invalid Username or Password!');</script>");
                }
            }

        }
    }
}