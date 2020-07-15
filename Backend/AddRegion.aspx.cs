using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tayana.Backend
{
  public partial class AddRegion : System.Web.UI.Page
  {
    string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        BindCountry();
      }
    }
    private void BindCountry()
    {
      using (SqlConnection conn = new SqlConnection(config))
      {
        SqlCommand cmd = new SqlCommand("SELECT * FROM [Country]", conn);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        DropDownList1.DataSource = dr;
        DropDownList1.DataValueField = "country_id";
        DropDownList1.DataTextField = "country";
        DropDownList1.DataBind();
        dr.Close();
      }
    }
    
    protected void Submit_btn_Click(object sender, EventArgs e)
    {      
      using (SqlConnection conn = new SqlConnection(config))
      {
        SqlCommand command = new SqlCommand("INSERT INTO [Region] (country_id, region) VALUES (@country_id, @region)", conn);
        conn.Open();
        command.Parameters.AddWithValue("@country_id", DropDownList1.SelectedValue);        
        command.Parameters.AddWithValue("@region", region.Text);
        command.ExecuteNonQuery();
        Response.Redirect("RegionList.aspx");
      }
    }

    protected void Cancel_btn_Click(object sender, EventArgs e)
    {
      Response.Redirect("RegionList.aspx");
    }   
  }
}