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
  public partial class AddYachtLayout : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Submit_btn_Click(object sender, EventArgs e)
    {
      string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
      using (SqlConnection conn = new SqlConnection(config))
      {
        SqlCommand command = new SqlCommand("INSERT INTO [YachtDetail] (yacht_layout) VALUES (@layout)", conn);
        conn.Open();
        command.Parameters.AddWithValue("@layout", yacht_layout.Text);
        command.ExecuteNonQuery();
        Response.Redirect("YachtLayout.aspx");
      }
    }

    protected void Cancel_btn_Click(object sender, EventArgs e)
    {
      Response.Redirect("YachtLayout.aspx");
    }
  }
}