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
  public partial class DealersList : System.Web.UI.Page
  {
    private const int pageSize = 3;
    string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        //因為每次查詢都會重新載入網頁，因此搜尋地區隱藏欄位的值會被清除，所以必須在網頁重新載入時，將Session的值存到搜尋地區隱藏欄位
        //再由JavaScript判斷搜尋地區隱藏欄位的值和所選取的地區是否一樣
        //regionValue.Value = Session["region"] == null ? "" : Session["region"].ToString();
        if (Session["region"] != null)
        {
          regionValue.Value = Session["region"].ToString();
        }
        BindData();
        BindCountry();
        CountPage();
      }
    }

    private void BindData()
    {
      string strSQL = "";
      string country = "";
      string region = "";
      int page = Convert.ToInt32(Request.QueryString["page"] ?? "1");
      if (Session["country"] != null && Session["region"] == null)//只查詢國家
      {
        country = Session["country"].ToString();
        strSQL = "with cte as (SELECT ROW_NUMBER() OVER (ORDER BY Dealers.region_id) as RowID, Country.country, Region.region, Dealers.* " +
                 "FROM Country INNER JOIN Dealers ON Country.country_id = Dealers.country_id INNER JOIN Region ON Country.country_id = Region.country_id AND Dealers.region_id = Region.region_id " +
                 $"WHERE Dealers.country_id = {country}) " +
                 "select * from cte where RowID >=@start and RowID <=@end";
                 //"select * from cte where RowID >=((@page - 1) * 3 + 1) and RowID <=(@page * 3)";
      }
      else if (Session["country"] != null && Session["region"] != null)//同時查詢國家和地區
      {
        country = Session["country"].ToString();
        region = Session["region"].ToString();
        strSQL = "with cte as (SELECT ROW_NUMBER() OVER (ORDER BY Dealers.region_id) as RowID, Country.country, Region.region, Dealers.* " +
                 "FROM Country INNER JOIN Dealers ON Country.country_id = Dealers.country_id INNER JOIN Region ON Country.country_id = Region.country_id AND Dealers.region_id = Region.region_id " +
                 $"WHERE Dealers.country_id = {country} AND Dealers.region_id = {region}) " +
                 "select * from cte where RowID >=@start and RowID <=@end";
                 //"select * from cte where RowID >=((@page - 1) * 3 + 1) and RowID <=(@page * 3)";
      }
      else//所有地區
      {
        strSQL = "with cte as (SELECT ROW_NUMBER() OVER (ORDER BY Dealers.dealer_name) as RowID, Country.country, Region.region, Dealers.*" +
                 "FROM Country INNER JOIN Dealers ON Country.country_id = Dealers.country_id INNER JOIN Region ON Country.country_id = Region.country_id AND Dealers.region_id = Region.region_id)" +
                 "select * from cte where RowID >=@start and RowID <=@end";
                 //"select * from cte where RowID >=((@page - 1) * 3 + 1) and RowID <=(@page * 3)";
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
          DealersRepeater.DataSource = dt;
          DealersRepeater.DataBind();
          if (dt.Rows.Count == 0)
          {
            Result.Visible = true;
            SearchResult.Text = "Oops! 查無資料喔!";
          }
        }
      }
    }

    // <summary>
    /// 繫結國家
    /// </summary>
    private void BindCountry()
    {
      using (SqlConnection conn = new SqlConnection(config))
      {
        string strSQL = "SELECT * FROM [Country]";
        SqlCommand cmd = new SqlCommand(strSQL, conn);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        countrySelect.DataSource = dr;
        countrySelect.DataValueField = "country_id";
        countrySelect.DataTextField = "country";
        countrySelect.DataBind();
        dr.Close();
        if (Session["country"] != null)
        {
          countrySelect.SelectedValue = Session["country"].ToString();
        }
      }
    }

    protected void CountPage()
    {
      string strSQL = "";
      string country = "";
      string region = "";
      if (Session["country"] != null && Session["region"] == null)
      {
        country = Session["country"].ToString();
        strSQL = $"SELECT COUNT(*) AS total FROM Dealers WHERE Dealers.country_id = {country}";
      }
      else if(Session["country"] != null && Session["region"] != null)
      {
        country = Session["country"].ToString();
        region = Session["region"].ToString();
        strSQL = $"SELECT COUNT(*) AS total FROM Dealers WHERE Dealers.country_id = {country} AND Dealers.region_id = {region}";
      }
      else
      {
        strSQL = "SELECT COUNT(*) AS total FROM Dealers WHERE 1=1";
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
          BackstagePagination.limit = 3;//一頁幾筆
          BackstagePagination.targetpage = "DealersList.aspx";//分頁位置
          BackstagePagination.showPageControls();//顯示分頁控制項
        }
      }
    }

    protected void Search_btn_Click(object sender, EventArgs e)
    {
      //string region1 = countrySelect.SelectedValue;
      //string region2 = regionValue.Value;
      Session["country"] = countrySelect.SelectedValue;//國家
      //Session["region"] = Request.Form["region"] == "0" ? null : Request.Form["region"];
      Session["region"] = regionValue.Value == "0" ? null : regionValue.Value;//將搜尋地區隱藏欄位的值存到Session
      Response.Redirect(Request.Url.ToString().Replace("page", "page1"));//只要查詢就回到第一頁
    }

    protected void Reset_btn_Click(object sender, EventArgs e)
    {
      Result.Visible = false;
      Session.Clear();
      Response.Redirect(Request.Url.ToString());
    }

    protected void DealersRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
      int id = Convert.ToInt32(e.CommandArgument);
      int page = Convert.ToInt32(Request.QueryString["page"] ?? "1");
      //編輯
      if (e.CommandName == "Edit")
      {
        Response.Redirect($"UpdateDealers.aspx?id={id}&page={page}");
      }
      //刪除
      if (e.CommandName == "Delete")
      {
        using (SqlConnection conn = new SqlConnection(config))
        {
          string strSQL = $"DELETE FROM [Dealers] WHERE (id = {id})";
          SqlCommand cmd = new SqlCommand(strSQL, conn);
          conn.Open();
          cmd.ExecuteNonQuery();
        }
        Response.Redirect(Request.Url.ToString());
      }
    }

    protected void AddDealer_btn_Click(object sender, EventArgs e)
    {
      int page = Convert.ToInt32(Request.QueryString["page"] ?? "1");
      Response.Redirect($"AddDealers.aspx?page={page}");
    }

    //編輯(gridview)
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
      //int id = Convert.ToInt32(GridView1.DataKeys[e.NewEditIndex].Value);
      //Response.Redirect($"UpdateDealers.aspx?id={id}");
    }
    //刪除(gridview)
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
      //using (SqlConnection conn = new SqlConnection(config))
      //{
      //  int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
      //  string strSQL = $"DELETE FROM [Dealers] WHERE (id = {id})";
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