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
  public partial class index : System.Web.UI.Page
  {
    string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
      BindYachtPhoto();
      BindTopNews();
    }

    private void BindTopNews()
    {
      using (SqlConnection conn = new SqlConnection(config))
      {
        SqlDataAdapter sda = new SqlDataAdapter("SELECT TOP 3 * FROM News order by news_top desc, news_date desc", conn);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        TopNewsRepeater.DataSource = dt;
        TopNewsRepeater.DataBind();
      }
    }

    private void BindYachtPhoto()
    {
      using (SqlConnection conn = new SqlConnection(config))
      {
        string strSQL = "SELECT YachtModel.model, YachtModel.newest, (select top 1 YachtPhoto.photo from YachtPhoto where YachtModel.id = YachtPhoto.yacht_id) as photo " +
                        "FROM YachtModel where (select COUNT(*) from YachtPhoto where YachtModel.id = YachtPhoto.yacht_id) > 0";
        SqlDataAdapter sda = new SqlDataAdapter(strSQL, conn);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        BannerRepeater.DataSource = dt;
        BannerRepeater.DataBind();
        ThumbnailRepeater.DataSource = dt;
        ThumbnailRepeater.DataBind();
      }
    }
  }
}