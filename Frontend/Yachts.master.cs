using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tayana.Frontend
{
  public partial class Yachts : System.Web.UI.MasterPage
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
      string strSQL = "SELECT * FROM [YachtPhoto] WHERE yacht_id = @id";
      using (SqlConnection conn = new SqlConnection(config))
      {
        using (SqlCommand cmd = new SqlCommand(strSQL, conn))
        {
          cmd.Parameters.AddWithValue("@id", Request.QueryString["id"] ?? "1");
          SqlDataAdapter sda = new SqlDataAdapter(cmd);
          DataTable dt = new DataTable();
          sda.Fill(dt);
          YachtPhotoRepeater.DataSource = dt;
          YachtPhotoRepeater.DataBind();
        }
      }
    }
  }
}