using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Forms;
using Shoppingweb.BLL;
using Shoppingweb.DAL;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Shoppingweb.GUI
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }

        }

        protected void btnreg_Click(object sender, EventArgs e)
        {
            User user = new User();
            string emailcode = (string)Session["emailcode"];
            if (txtusername.Text == null)
            {
                ClientScript.RegisterStartupScript(GetType(), "Empty", "<script>alert('Input invalid UserName! Please try again!');</script>");
            }
            else if (UserDB.IsOnlyUser(txtusername.Text)) {
                ClientScript.RegisterStartupScript(GetType(), "Duplicate username", "<script>alert('Input invalid UserName! Please try again!');</script>");

            }
            else if (txtpsw.Text == null)
            {
                ClientScript.RegisterStartupScript(GetType(), "Empty", "<script>alert('Input invalid PassWord! Please try again!');</script>");

            }
            else if (txtrepsw.Text != txtpsw.Text)
            {
                ClientScript.RegisterStartupScript(GetType(), "Empty", "<script>alert('Input invalid Re-Password! Please try again!');</script>");

            }
            else if (txtname.Text == null)
            {
                ClientScript.RegisterStartupScript(GetType(), "Empty", "<script>alert('Input invalid Name! Please try again!');</script>");

            }
            else if (txtaddress.Text == null)
            {
                ClientScript.RegisterStartupScript(GetType(), "Empty", "<script>alert('Input invalid Address! Please try again!');</script>");

            }
            else if (dropListsex.SelectedItem == null)
            {
                ClientScript.RegisterStartupScript(GetType(), "Empty", "<script>alert('Input invalid Sex!! Please try again!');</script>");
            }
            else if (txtemail.Text == null)
            {
                ClientScript.RegisterStartupScript(GetType(), "Empty", "<script>alert('Input invalid Email!! Please try again!');</script>");
            }
            else if (txtphonenum.Text == null)
            {
                ClientScript.RegisterStartupScript(GetType(), "Empty", "<script>alert('Input invalid PhoneNumber!! Please try again!');</script>");
            }
            else if (txtverfication.Text != emailcode)
            {
                ClientScript.RegisterStartupScript(GetType(), "Invalid Code", "<script>alert('Invalid Email Verify Code! Please try again!');</script>");

            }
            else
            {
                user.Username = this.txtusername.Text;
                user.Password = this.txtpsw.Text;
                user.Name = this.txtname.Text;
                user.Address = this.txtaddress.Text;
                user.Sex = int.Parse(this.dropListsex.Text);
                user.Phonenumber = this.txtphonenum.Text;
                user.Email = this.txtemail.Text;
                user.SaveUser(user);
                MessageBox.Show("Register Successful!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.None);
                Response.Redirect("LoginPage.aspx");
            }
            
        }

        protected void btnsendemail_Click1(object sender, EventArgs e)
        {
            SendEmailToNewAccount(txtemail.Text, txtusername.Text, txtname.Text);
        }
        public void SendEmailToNewAccount(string emailAddress, string fname, string lname)
        {
            Random randomInt = new Random();
            string emailcode = randomInt.Next(0, 9999).ToString();
            MailMessage emailMessage = new MailMessage();
            emailMessage.To.Add(emailAddress);
            emailMessage.From = new MailAddress("xchen.montreal@outlook.com", "Shopping Coffee website", Encoding.UTF8);
            emailMessage.Subject = "Verification code for registration";
            emailMessage.Body = $"Hello, {fname} {lname}\n" +
                $"Please enter the verification vode below to finish registration process\n" +
                $"{emailcode}\n" +
                $"Regards, \nHolly";
            emailMessage.Priority = MailPriority.High;
            SmtpClient smtpClient = new SmtpClient("smtp-mail.outlook.com", 587);
            smtpClient.Credentials = new NetworkCredential("xchen.montreal@outlook.com", "chenxiao713");
            smtpClient.EnableSsl = true;
            try
            {
                Session["EmailCode"] = emailcode;
                smtpClient.Send(emailMessage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        protected void txtverfication_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtemail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}