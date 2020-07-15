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
  public partial class AddYachtModel : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Submit_btn_Click(object sender, EventArgs e)
    {
      string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
      string radio = Radio1.Checked ? Radio1.Value : Radio2.Value;
      using (SqlConnection conn = new SqlConnection(config))
      {
        SqlCommand cmd = new SqlCommand("INSERT INTO [YachtModel] (model, newest) VALUES (@model, @newest)", conn);
        conn.Open();
        cmd.Parameters.AddWithValue("@model", yacht_model.Text);
        cmd.Parameters.AddWithValue("@newest", radio);
        cmd.ExecuteNonQuery();
        Response.Redirect("YachtModel.aspx");
      }
    }

    protected void Cancel_btn_Click(object sender, EventArgs e)
    {
      Response.Redirect("YachtModel.aspx");
    }
  }
}