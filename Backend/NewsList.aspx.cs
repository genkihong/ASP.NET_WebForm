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
  public partial class NewsList : System.Web.UI.Page
  {
    string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
    private const int pageSize = 6;
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        if (Session["searchNews"] != null)
        {
          SearchNews.Text = Session["searchNews"].ToString();
        }
        if (Session["date1"] != null && Session["date2"] != null)
        {
          Literal1.Text = Session["date1"].ToString();
          Literal2.Text = Session["date2"].ToString();
          SearchdDate1.Text = Session["date1"].ToString().Replace("/", "-");
          SearchdDate2.Text = Session["date2"].ToString().Replace("/", "-");
        }
        BindData();
        CountPage();
      }
    }

    //顯示所有新聞
    private void BindData()
    {
      string strSQL = "";
      int page = Convert.ToInt32(Request.QueryString["page"] ?? "1");
      if (Session["searchNews"] != null && Session["date1"] == null && Session["date2"] == null)//只查詢關鍵字
      {
        string search = Session["searchNews"].ToString();
        strSQL = "with cte as (SELECT ROW_NUMBER() OVER (ORDER BY News.news_date desc) as RowID, News.* FROM News " +
                 $"WHERE news_title like '%{search}%') " +
                 "select * from cte where RowID >=@start and RowID <=@end";
                 //"select * from cte where RowID >=((@page - 1) * 6 + 1) and RowID <=(@page * 6)";
      }
      else if (Session["searchNews"] == null && Session["date1"] != null && Session["date2"] != null)//只查詢日期
      {
        string date1 = Session["date1"].ToString();
        string date2 = Session["date2"].ToString();
        strSQL = "with cte as (SELECT ROW_NUMBER() OVER (ORDER BY News.news_date desc) as RowID, News.* FROM News " +
                 $"WHERE news_date BETWEEN '{date1}' AND '{date2}') " +
                 "select * from cte where RowID >=@start and RowID <=@end";
                 //"select * from cte where RowID >=((@page - 1) * 6 + 1) and RowID <=(@page * 6)";
      }
      else if (Session["searchNews"] != null && Session["date1"] != null && Session["date2"] != null)//查詢關鍵字+日期
      {
        string search = Session["searchNews"].ToString();
        string date1 = Session["date1"].ToString();
        string date2 = Session["date2"].ToString();
        strSQL = "with cte as (SELECT ROW_NUMBER() OVER (ORDER BY News.news_date desc) as RowID, News.* FROM News " +
                 $"WHERE news_title like '%{search}%' AND news_date BETWEEN '{date1}' AND '{date2}') " +
                 "select * from cte where RowID >=@start and RowID <=@end";
                 //"select * from cte where RowID >=((@page - 1) * 6 + 1) and RowID <=(@page * 6)";
      }
      else
      {
        strSQL = "with cte as (SELECT ROW_NUMBER() OVER (ORDER BY News.news_date desc) as RowID, News.* FROM News) " +
                 "select * from cte where RowID >=@start and RowID <=@end";
                 //"select * from cte where RowID >=((@page - 1) * 6 + 1) and RowID <=(@page * 6)";
      }

      using (SqlConnection conn = new SqlConnection(config))
      {
        using (SqlCommand cmd = new SqlCommand(strSQL, conn))
        {
          //cmd.Parameters.AddWithValue("@page", Convert.ToInt32(Request.QueryString["page"] ?? "1"));
          cmd.Parameters.AddWithValue("@start", (page - 1) * pageSize + 1);
          cmd.Parameters.AddWithValue("@end", page * pageSize);
          SqlDataAdapter sda = new SqlDataAdapter(cmd);
          DataTable dt = new DataTable();
          sda.Fill(dt);
          NewsRepeater.DataSource = dt;
          NewsRepeater.DataBind();
          if (dt.Rows.Count == 0)
          {
            Result.Visible = true;
            SearchResult.Text = "Oops! 查無資料喔!";
          }
        }
      }
    }

    protected void CountPage()
    {
      string strSQL = "";
      if (Session["searchNews"] != null && Session["date1"] == null && Session["date2"] == null)//只查詢關鍵字
      {
        string search = Session["searchNews"].ToString();
        strSQL = $"SELECT COUNT(*) AS total FROM News WHERE news_title like '%{search}%'";
      }
      else if (Session["searchNews"] == null && Session["date1"] != null && Session["date2"] != null)//只查詢日期
      {
        string date1 = Session["date1"].ToString();
        string date2 = Session["date2"].ToString();
        strSQL = $"SELECT COUNT(*) AS total FROM News WHERE news_date BETWEEN '{date1}' AND '{date2}'";
      }
      else if (Session["searchNews"] != null && Session["date1"] != null && Session["date2"] != null)//查詢關鍵字+日期
      {
        string search = Session["searchNews"].ToString();
        string date1 = Session["date1"].ToString();
        string date2 = Session["date2"].ToString();
        strSQL = $"SELECT COUNT(*) AS total FROM News WHERE news_title like '%{search}%' AND news_date BETWEEN '{date1}' AND '{date2}'";
      }
      else
      {
        strSQL = "SELECT COUNT(*) AS total FROM News WHERE 1=1";
      }

      using (SqlConnection connection = new SqlConnection(config))
      {
        using (SqlCommand command = new SqlCommand(strSQL, connection))
        {
          SqlDataAdapter sda = new SqlDataAdapter(command);
          DataTable dt = new DataTable();
          sda.Fill(dt);

          int itemsCount = dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0][0].ToString()) : 0;//分頁控制項丟入參數做測試
          BackstagePagination.totalitems = itemsCount;//共有幾筆
          BackstagePagination.limit = 6;//一頁幾筆
          BackstagePagination.targetpage = "NewsList.aspx";//分頁位置
          BackstagePagination.showPageControls();//顯示分頁控制項
        }
      }
    }

    protected void Search_btn_Click(object sender, EventArgs e)
    {
      Session["searchNews"] = SearchNews.Text == "" ? null : SearchNews.Text;
      Session["date1"] = SearchdDate1.Text == "" ? null : SearchdDate1.Text.Replace("-", "/");
      Session["date2"] = SearchdDate2.Text == "" ? null : SearchdDate2.Text.Replace("-", "/");
      Response.Redirect(Request.Url.ToString().Replace("page", "page1"));//只要查詢就回到第一頁
    }

    protected void Reset_btn_Click(object sender, EventArgs e)
    {
      SearchNews.Text = "";
      SearchdDate1.Text = "";
      SearchdDate2.Text = "";
      Result.Visible = false;
      Session.Clear();
      Response.Redirect(Request.Url.ToString());
    }

    protected void NewsRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
      int id = Convert.ToInt32(e.CommandArgument);
      int page = Convert.ToInt32(Request.QueryString["page"] ?? "1");
      //編輯
      if (e.CommandName == "Edit")
      {
        Response.Redirect($"UpdateNews.aspx?id={id}&page={page}");
      }
      //刪除
      if (e.CommandName == "Delete")
      {
        using (SqlConnection conn = new SqlConnection(config))
        {
          string strSQL = $"DELETE FROM [News] WHERE (id = {id})";
          SqlCommand cmd = new SqlCommand(strSQL, conn);
          conn.Open();
          cmd.ExecuteNonQuery();
        }
        Response.Redirect(Request.Url.ToString());
      }
      //置頂
      if (e.CommandName == "Top")
      {
        using (SqlConnection conn = new SqlConnection(config))
        {
          string top = "";
          conn.Open();
          using (SqlCommand cmd = new SqlCommand($"SELECT * FROM News WHERE id = {id}", conn))
          {
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
              top = dr["news_top"].ToString();
            }
            dr.Close();
          }
          using (SqlCommand cmd = new SqlCommand($"UPDATE [News] SET news_top=@top WHERE (id = {id})", conn))
          {
            cmd.Parameters.AddWithValue("@top", top == "1" ? "0" : "1");
            cmd.ExecuteNonQuery();
          };
        }
        Response.Redirect(Request.Url.ToString());
        //BindData();
      }
    }


    protected void AddNews_btn_Click(object sender, EventArgs e)
    {
      Response.Redirect("AddNews.aspx");
    }

    //編輯新聞
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
      //int id = Convert.ToInt32(GridView1.DataKeys[e.NewEditIndex].Value);
      //Response.Redirect($"UpdateNews.aspx?id={id}");
    }
    //刪除新聞
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
      //using (SqlConnection conn = new SqlConnection(config))
      //{
      //  int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);//取得點擊這列的id     
      //  string strSQL = $"DELETE FROM [News] WHERE (id = {id})";
      //  SqlCommand cmd = new SqlCommand(strSQL, conn);
      //  conn.Open();
      //  cmd.ExecuteNonQuery();

      //  //重新整理頁面
      //  //Response.Redirect(Request.Url.ToString());
      //}
      //BindData();
    }
  }
}