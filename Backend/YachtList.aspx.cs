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
  public partial class YachtList : System.Web.UI.Page
  {
    string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        BindData();
        dataListCountCS();
      }
    }
    private void BindData()
    {
      string strSQL = "with cte as (SELECT ROW_NUMBER() OVER (ORDER BY YachtModel.id) as RowID, YachtModel.model, YachtModel.newest, YachtDetail.* " +
                      "FROM YachtModel INNER JOIN YachtDetail ON YachtModel.id = YachtDetail.yacht_id) " +
                      "select * from cte where RowID >=((@page - 1) * 2 + 1) and RowID <=(@page * 2)";
      using (SqlConnection conn = new SqlConnection(config))
      {
        using (SqlCommand cmd = new SqlCommand(strSQL, conn))
        {
          cmd.Parameters.AddWithValue("@page", Convert.ToInt32(Request.QueryString["page"] ?? "1"));
          SqlDataAdapter sda = new SqlDataAdapter(cmd);
          DataTable dt = new DataTable();
          sda.Fill(dt);
          YachtRepeater.DataSource = dt;
          YachtRepeater.DataBind();
        }
      }
    }
    
    protected void dataListCountCS()
    {
      string strSQL = "SELECT COUNT(*) AS total FROM [YachtDetail] WHERE 1=1";
      using (SqlConnection connection = new SqlConnection(config))
      {
        using (SqlCommand command = new SqlCommand(strSQL, connection))
        {
          SqlDataAdapter sda = new SqlDataAdapter(command);
          DataTable dt = new DataTable();
          sda.Fill(dt);

          int itemsCount = dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0][0].ToString()) : 0;//分頁控制項丟入參數做測試
          BackstagePagination.totalitems = itemsCount;//共有幾筆
          BackstagePagination.limit = 2;//一頁幾筆
          BackstagePagination.targetpage = "YachtList.aspx";//分頁位置
          BackstagePagination.showPageControls();//顯示分頁控制項
        }
      }
    }

    protected void YachtRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
      int id = Convert.ToInt32(e.CommandArgument);
      int page = Convert.ToInt32(Request.QueryString["page"] ?? "1");

      switch (e.CommandName)
      {
        //編輯
        case "Edit":
          Response.Redirect($"UpdateYachtList.aspx?id={id}&page={page}");
          break;
        //刪除
        case "Delete":
          using (SqlConnection conn = new SqlConnection(config))
          {
            string strSQL = $"DELETE FROM [YachtDetail] WHERE (id = {id})";
            SqlCommand cmd = new SqlCommand(strSQL, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
          }
          BindData();
          dataListCountCS();
          break;
          #region
          //最新船型
          //case "Newest":
          //  using (SqlConnection conn = new SqlConnection(config))
          //  {
          //    string newest = "";
          //    conn.Open();
          //    using (SqlCommand cmd = new SqlCommand($"SELECT * FROM YachtDetail WHERE id = {id}", conn))
          //    {
          //      SqlDataReader dr = cmd.ExecuteReader();
          //      while (dr.Read())
          //      {
          //        newest = dr["newest"].ToString();
          //      }
          //      dr.Close();
          //    }

          //    using (SqlCommand cmd = new SqlCommand($"UPDATE [YachtDetail] SET newest = @newest WHERE (id = {id})", conn))
          //    {
          //      cmd.Parameters.AddWithValue("@newest", newest == "1" ? "0" : "1");
          //      cmd.ExecuteNonQuery();
          //    };
          //  }
          //  BindData();
          //  break;
          #endregion
      }
    }
    protected void AddYacht_btn_Click(object sender, EventArgs e)
    {
      Response.Redirect($"AddYachtList.aspx");
    }
  }
}