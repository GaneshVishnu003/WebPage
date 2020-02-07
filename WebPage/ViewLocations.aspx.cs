using System;
using System.Data;
using WebPage.Entity;

namespace WebPage
{
    public partial class ViewLocations : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            dataTable = Repository.ViewLocation();
            idLocationView1.DataSource = dataTable;
            idLocationView1.DataBind();
        }
    }
}