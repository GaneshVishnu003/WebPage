using System;
using System.Data;
using System.Web.UI.WebControls;
using OnlineCabBooking.BL;
using OnlineCabBooking.DAL;

namespace WebPage
{
    public partial class ViewLocations : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            Refresh();
        }
        protected void Refresh()
        {
            DataTable dataTable = new DataTable();
            dataTable = CustomerDAL.ViewLocation();
            idLocationView1.DataSource = dataTable;
            idLocationView1.DataBind();
        }
        protected void EditTable(object sender, GridViewEditEventArgs e)
        {
            idLocationView1.EditIndex = e.NewEditIndex;
            Refresh();
            
        }

        protected void CancelEdit(object sender, GridViewCancelEditEventArgs e)
        {
            idLocationView1.EditIndex = -1;
            Refresh();
        }
        protected void UpdateTable(object sender, GridViewUpdateEventArgs e)
        {
            TextBox txtLocation = (idLocationView1.Rows[e.RowIndex].FindControl("txtLocation") as TextBox);
            int id = Convert.ToInt16(idLocationView1.DataKeys[e.RowIndex].Values["id"].ToString());
            CustomerBL.UpdateRow(txtLocation.Text, id);
            idLocationView1.EditIndex = -1;
            Refresh();
            lblSuccess.Text = "Successfully updated";
            lblFailure.Text = "";
        }
        protected void DeleteRow(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt16(idLocationView1.DataKeys[e.RowIndex].Values["id"].ToString());
            CustomerBL.DeleteRow(id);
            lblFailure.Text = "One Location Removed";
            Refresh();
        }
        protected void InsertRow(object sender, EventArgs e)
        {
            string location = (idLocationView1.FooterRow.FindControl("txtLocationFooter") as TextBox).Text;
            CustomerBL.InsertRow(location);
            idLocationView1.EditIndex = -1;
            lblSuccess.Text= "Location added successfully";
            Refresh();
        }

    }
}