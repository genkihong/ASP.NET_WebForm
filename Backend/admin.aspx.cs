using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tayana
{
  public partial class admin : System.Web.UI.Page
  {
    private const int pageSize = 6;
    string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
      if (HttpContext.Current.User.Identity.Name != "admin")
      {
        Response.Redirect("index.aspx");
      }
      if (!IsPostBack)//第一次或切換頁面時，判斷是否有Session
      {
        if (Session["searchUser"] != null)//有Session
        {
          SearchUser.Text = Session["searchUser"].ToString();
        }
        BindData();
        CountPage();
      }
    }

    private void BindData()
    {
      string query = "";
      int page = Convert.ToInt32(Request.QueryString["page"] ?? "1");
      if (Session["searchUser"] != null)
      {
        string search = Session["searchUser"].ToString();
        query = $"with cte as (SELECT ROW_NUMBER() OVER (ORDER BY Users.user_identity) as RowID, Users.* FROM Users WHERE Users.name like '%{search}%') " +
                "select * from cte where RowID >=@start and RowID <=@end";
                //"select * from cte where RowID >=((@page - 1) * 6 + 1) and RowID <=(@page * 6)";
      }
      else
      {
        query = "with cte as (SELECT ROW_NUMBER() OVER (ORDER BY Users.name) as RowID, Users.* FROM Users) " +
                 "select * from cte where RowID >=@start and RowID <=@end";
                 //"select * from cte where RowID >=((@page - 1) * 6 + 1) and RowID <=(@page * 6)";
      }

      using (SqlConnection conn = new SqlConnection(config))
      {
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
          //cmd.Parameters.AddWithValue("@page", Convert.ToInt32(Request.QueryString["page"] ?? "1"));
          //cmd.Parameters.AddWithValue("@search", SearchText.Text.Trim());
          cmd.Parameters.AddWithValue("@start", (page - 1) * pageSize + 1);
          cmd.Parameters.AddWithValue("@end", page * pageSize);

          SqlDataAdapter sda = new SqlDataAdapter(cmd);
          DataTable dt = new DataTable();
          sda.Fill(dt);
          UserRepeater.DataSource = dt;
          UserRepeater.DataBind();

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
      string query = "";
      if (Session["searchUser"] != null)
      {
        string search = Session["searchUser"].ToString();
        query = $"SELECT COUNT(*) AS total FROM Users WHERE name like '%{search}%'";
      }
      else
      {
        query = "SELECT COUNT(*) AS total FROM Users WHERE 1=1";
      }

      using (SqlConnection connection = new SqlConnection(config))
      {
        using (SqlCommand command = new SqlCommand(query, connection))
        {
          connection.Open();
          //command.Parameters.AddWithValue("@search", SearchText.Text.Trim());
          int itemsCount = Convert.ToInt32(command.ExecuteScalar());

          //SqlDataAdapter sda = new SqlDataAdapter(command);
          //DataTable dt = new DataTable();
          //sda.Fill(dt);

          //int itemsCount = dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0][0].ToString()) : 0;//分頁控制項丟入參數做測試
          BackstagePagination.totalitems = itemsCount;//共有幾筆
          BackstagePagination.limit = pageSize;//一頁幾筆
          BackstagePagination.targetpage = "admin.aspx";//分頁位置
          BackstagePagination.showPageControls();//顯示分頁控制項
          connection.Close();
        }
      }
    }

    protected void Search_btn_Click(object sender, EventArgs e)
    {
      //if (SearchUser.Text == "") return;
      Session["searchUser"] = SearchUser.Text == "" ? null : SearchUser.Text;
      Response.Redirect(Request.Url.ToString().Replace("page", "page1"));//只要查詢就回到第一頁
    }

    protected void Reset_btn_Click(object sender, EventArgs e)
    {
      SearchUser.Text = "";
      Result.Visible = false;
      Session.Clear();
      Response.Redirect(Request.Url.ToString());
    }

    protected void UserRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
      int id = Convert.ToInt32(e.CommandArgument);
      int page = Convert.ToInt32(Request.QueryString["page"] ?? "1");
      //編輯
      if (e.CommandName == "Edit")
      {
        Response.Redirect($"UpdateUser.aspx?id={id}&page={page}");
      }
      //刪除
      if (e.CommandName == "Delete")
      {
        using (SqlConnection conn = new SqlConnection(config))
        {
          string strSQL = $"DELETE FROM [Users] WHERE (id = {id})";
          SqlCommand cmd = new SqlCommand(strSQL, conn);
          conn.Open();
          cmd.ExecuteNonQuery();
        }
        Response.Redirect(Request.Url.ToString());
        //BindData();
        //CountPage();
      }
    }

    protected void AddUser_btn_Click(object sender, EventArgs e)
    {
      Response.Redirect("AddUser.aspx");
    }

    //刪除某列資料
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
      //using (SqlConnection conn = new SqlConnection(config))
      //{
      //  int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);//取得點擊這列的id     
      //  string strSQL = $"DELETE FROM [Users] WHERE (id = {id})";
      //  SqlCommand cmd = new SqlCommand(strSQL, conn);
      //  conn.Open();
      //  cmd.ExecuteNonQuery();

      //  //重新整理頁面
      //  //Response.Redirect(Request.Url.ToString());
      //}
      //BindData();
    }
    //編輯資料，利用e.NewEditIndex獲取當前編輯行索引
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
      //int id = Convert.ToInt32(GridView1.DataKeys[e.NewEditIndex].Value);
      //Response.Redirect($"UpdateUser.aspx?id={id}");
      //GridView1.EditIndex = e.NewEditIndex;
      //GridView1.EditIndex = GridView1.SelectedIndex;
      //BindData();
    }
    //更新資料
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
      #region
      //using (SqlConnection conn = new SqlConnection(config))
      //{
      //  int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);//獲取主鍵，需要設置 DataKeyNames，這裏設為 id
      //  /* 獲取要更新的數據 */
      //  string identity = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[1].Controls[0])).Text;
      //  string name = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[2].Controls[0])).Text;
      //  string email = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[3].Controls[0])).Text;
      //  string permission = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[4].Controls[0])).Text;
      //  //string pwd = (GridView1.Rows[e.RowIndex].Cells[5].Controls[0] as TextBox).Text.ToString();
      //  //string photo = (GridView1.Rows[e.RowIndex].Cells[7].Controls[0] as TextBox).Text.ToString();
      //  //string date = (GridView1.Rows[e.RowIndex].Cells[8].Controls[0] as TextBox).Text.ToString();
      //  string strSQL = $"UPDATE [Users] SET user_identity = @identity, name = @name, email = @email, permission = @permission WHERE (id = {id})";
      //  SqlCommand cmd = new SqlCommand(strSQL, conn);
      //  conn.Open();
      //  cmd.Parameters.AddWithValue("@identity", identity);
      //  cmd.Parameters.AddWithValue("@name", name);
      //  cmd.Parameters.AddWithValue("@email", email);
      //  cmd.Parameters.AddWithValue("@permission", permission);
      //  cmd.ExecuteNonQuery();
      //}
      //GridView1.EditIndex = -1;
      //BindData();
      #endregion
    }
    //取消編輯
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
      //GridView1.EditIndex = -1; //編輯索引賦值為-1，變回正常顯示狀態
      //BindData();
    }
  }
}