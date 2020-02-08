using System;
using OnlineCabBooking.Entity;
using OnlineCabBooking.DAL;

namespace WebPage
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Response.Write("welcome");
        }
        protected void signup_Click(object sender, EventArgs e)
        {
            CustomerEntity SignUpObject = new CustomerEntity();
            SignUpObject.fName = txtFirst.Text;
            SignUpObject.lName = txtLast.Text;
            SignUpObject.mail = mail.Text;
            SignUpObject.mobile = long.Parse(mobileNum.Text);
            SignUpObject.location = txtlocation.Text;
            SignUpObject.password = txtConPassword.Text;
            int rows = CustomerDAL.CustomerDbConnection(SignUpObject);
            Response.Write("Signup Successfull");
        }
    }
}