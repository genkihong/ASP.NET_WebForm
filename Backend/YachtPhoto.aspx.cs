using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tayana.Backend
{
  public partial class YachtPhoto : System.Web.UI.Page
  {
    string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        BindData();
      }
    }

    private void BindData()
    {
      using (SqlConnection conn = new SqlConnection(config))
      {
        string strSQL = "SELECT YachtModel.model, YachtPhoto.* FROM YachtPhoto INNER JOIN YachtModel ON YachtPhoto.yacht_id = YachtModel.id";
        using (SqlCommand cmd = new SqlCommand(strSQL, conn))
        {
          SqlDataAdapter sda = new SqlDataAdapter(cmd);
          DataTable dt = new DataTable();
          sda.Fill(dt);
          YachtPhotoRepeater.DataSource = dt;
          YachtPhotoRepeater.DataBind();
        }
      }
    }

    protected void AddYachtPhoto_btn_Click(object sender, EventArgs e)
    {
      Response.Redirect("AddYachtPhoto.aspx");
    }

    protected void YachtPhotoRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
      int id = Convert.ToInt32(e.CommandArgument);
      int page = Convert.ToInt32(Request.QueryString["page"] ?? "1");
      switch (e.CommandName)
      {
        //編輯
        case "Edit":
          Response.Redirect($"UpdateYachtPhoto.aspx?id={id}&page={page}");
          break;
        //刪除
        case "Delete":
          using (SqlConnection conn = new SqlConnection(config))
          {
            string strSQL = $"DELETE FROM [YachtPhoto] WHERE (id = {id})";
            SqlCommand cmd = new SqlCommand(strSQL, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
          }
          Response.Redirect(Request.Url.ToString());
          //BindData();
          break;
      }
    }
  }
}