using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shoppingweb.DAL;
using Shoppingweb.BLL;
using System.IO;

namespace Shoppingweb.GUI
{
    public partial class AdminPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRelease_Click(object sender, EventArgs e)
        {
            
            Produces produces = new Produces();
            if (txtTitle.Text == null)
            {
                ClientScript.RegisterStartupScript(GetType(), "Empty", "<script>alert('Input Title! Please try again!');</script>");
            }
            else if(!uploadImg.HasFile) {
               
            }
            else if (txtPrice.Text == null)
            {
                ClientScript.RegisterStartupScript(GetType(), "Empty", "<script>alert('Input Price! Please try again!');</script>");

            }
            else if (txtNum.Text == null)
            {
                ClientScript.RegisterStartupScript(GetType(), "Empty", "<script>alert('Input number! Please try again!');</script>");
            }
            else if (txtstate.Text == null)
            {
                ClientScript.RegisterStartupScript(GetType(), "Empty", "<script>alert('Input state! Please try again!');</script>");
            }
            else if (txtInfo.Text == null)
            {
                ClientScript.RegisterStartupScript(GetType(), "Empty", "<script>alert('Input Produces' Information! Please try again!');</script>");
            }
            else {
                 string filename = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString()
                    + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString()
                    + Path.GetExtension(uploadImg.FileName);
                 string filePath = "~/Images/admin_img/" + filename;
                uploadImg.SaveAs(MapPath(filePath));
                produces.Title = this.txtTitle.Text.Trim();
                produces.Price = this.txtPrice.Text.Trim();
                produces.Num = int.Parse(this.txtNum.Text.Trim());
                produces.Information = this.txtInfo.Text.Trim();
                produces.State = this.txtstate.Text.Trim();
                produces.Image = filePath;
                produces.Date = DateTime.Now;
                produces.addProduces(produces);
                ClientScript.RegisterStartupScript(GetType(), "Successfully", "<script>alert('Success to upload!!!');</script>");
                Response.Redirect("LoginPage.aspx");

            }


        }
    }
}