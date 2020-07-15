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
  public partial class Dealers : System.Web.UI.MasterPage
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
      string strSQL = "SELECT * FROM [Country]";
      using (SqlConnection conn = new SqlConnection(config))
      {
        SqlDataAdapter sda = new SqlDataAdapter(strSQL, conn);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        DealerRepeater.DataSource = dt;
        DealerRepeater.DataBind();
      }
    }
  }
}