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
  public partial class news_list : System.Web.UI.Page
  {
    string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
      BindNewsList();
      dataListCountCS();
    }
    private void BindNewsList()
    {
      //string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
      string strSQL = "WITH cte as (SELECT ROW_NUMBER() OVER (ORDER BY news_date desc) as RowID, id, news_img, news_date, news_title, news_summary FROM [News])" +
                      "SELECT * FROM cte where RowID >=((@page - 1) * 6 + 1) and RowID <=(@page * 6)";
      using (SqlConnection conn = new SqlConnection(config))
      {
        using (SqlCommand cmd = new SqlCommand(strSQL, conn))
        {
          SqlDataAdapter sda = new SqlDataAdapter(cmd);
          //cmd.Parameters.AddWithValue("@page", Convert.ToInt32(Request.QueryString["page"] ?? "1"));
          cmd.Parameters.AddWithValue("@page", Convert.ToInt32(Request.QueryString["page"] == null ? "1" : Request.QueryString["page"]));
          DataTable dt = new DataTable();
          sda.Fill(dt);
          Repeater1.DataSource = dt;
          Repeater1.DataBind();
        }
      }
    }    
    protected void dataListCountCS()
    {
      string strSQL = "SELECT COUNT(*) AS total FROM News WHERE 1=1";
      using (SqlConnection connection = new SqlConnection(config))
      {
        using (SqlCommand command = new SqlCommand(strSQL, connection))
        {
          SqlDataAdapter sda = new SqlDataAdapter(command);
          DataTable dt = new DataTable();
          sda.Fill(dt);
          
          int itemsCount = dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0][0].ToString()) : 0;//分頁控制項丟入參數做測試
          Pagination.totalitems = itemsCount;//共有幾筆
          Pagination.limit = 6;//一頁幾筆
          Pagination.targetpage = "news_list.aspx";//分頁位置
          Pagination.showPageControls();//顯示分頁控制項
        }
      }
    }
  }
}