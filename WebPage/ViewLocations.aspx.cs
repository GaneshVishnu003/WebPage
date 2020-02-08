using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebPage.Entity;

namespace WebPage
{
    public partial class ViewLocations : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Refresh();
        }
        protected void Refresh()
        {
            DataTable dataTable = new DataTable();
            dataTable = Repository.ViewLocation();
            idLocationView1.DataSource = dataTable;
            idLocationView1.DataBind();
        }
        protected void CallAdd(object sender, ImageClickEventArgs e)
        {
                string newLocation =(idLocationView1.FooterRow.FindControl("txtLocationFooter") as TextBox).Text.Trim();
                DataTable dataTable = new DataTable();
                dataTable=Repository.Addnew(newLocation);
                Refresh();
                lblSuccess.Text = "Successfully added";
                lblFailure.Text = "";
    }

    protected void idLocationView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}