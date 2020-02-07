using System;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebPage.Entity;

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
            SignUpEntity SignUpObject = new SignUpEntity();
            SignUpObject.fName = txtFirst.Text;
            SignUpObject.lName = txtLast.Text;
            SignUpObject.mail = mail.Text;
            SignUpObject.mobile = long.Parse(mobileNum.Text);
            SignUpObject.location = txtlocation.Text;
            SignUpObject.password = txtConPassword.Text;
            Response.Write("Signup Successfull");
            int rows = SignUpObject.CustomerDbConnection(SignUpObject);
            //Response.Write("Done process" + rows);
        }
    }
}