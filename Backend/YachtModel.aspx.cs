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
  public partial class YachtModel : System.Web.UI.Page
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
        SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM [YachtModel]", conn);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        YachtModeRepeater.DataSource = dt;
        YachtModeRepeater.DataBind();
      }
    }


    protected void YachtModelRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
      int id = Convert.ToInt32(e.CommandArgument);
      int page = Convert.ToInt32(Request.QueryString["page"] ?? "1");
      //編輯
      if (e.CommandName == "Edit")
      {
        Response.Redirect($"UpdateYachtModel.aspx?id={id}&page={page}");
      }
      //刪除
      if (e.CommandName == "Delete")
      {
        using (SqlConnection conn = new SqlConnection(config))
        {
          string strSQL = $"DELETE FROM [YachtModel] WHERE (id = {id})";
          SqlCommand cmd = new SqlCommand(strSQL, conn);
          conn.Open();
          cmd.ExecuteNonQuery();
        }
        BindData();
        //重新整理頁面
        //Response.Redirect(Request.Url.ToString());
      }
      //最新船型
      if (e.CommandName == "Newest")
      {
        using (SqlConnection conn = new SqlConnection(config))
        {
          string newest = "";
          conn.Open();
          using (SqlCommand cmd = new SqlCommand($"SELECT * FROM YachtModel WHERE id = {id}", conn))
          {
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
              newest = dr["newest"].ToString();
            }
            dr.Close();
          }
          using (SqlCommand cmd = new SqlCommand($"UPDATE [YachtModel] SET newest = @newest WHERE (id = {id})", conn))
          {
            cmd.Parameters.AddWithValue("@newest", newest == "1" ? "0" : "1");
            cmd.ExecuteNonQuery();
          }
        }
        BindData();
      }
    }

    protected void AddYachtModel_btn_Click(object sender, EventArgs e)
    {
      Response.Redirect("AddYachtModel.aspx");
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
      //GridView1.EditIndex = e.NewEditIndex;
      //BindData();
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
      #region
      //using (SqlConnection conn = new SqlConnection(config))
      //{
      //  int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
      //  string model = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[2].Controls[0])).Text;
      //  string newest = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[3].Controls[0])).Text;
      //  conn.Open();
      //  SqlCommand cmd = new SqlCommand($"UPDATE [YachtModel] SET model = @model, newest = @newest WHERE (id = {id})", conn);
      //  cmd.Parameters.AddWithValue("@model", model);
      //  cmd.Parameters.AddWithValue("@newest", newest);
      //  cmd.ExecuteNonQuery();
      //}
      //GridView1.EditIndex = -1;
      //BindData();
      #endregion
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
      //GridView1.EditIndex = -1; //編輯索引賦值為-1，變回正常顯示狀態
      //BindData();
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
      //using (SqlConnection conn = new SqlConnection(config))
      //{
      //  int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
      //  SqlCommand cmd = new SqlCommand($"DELETE FROM [YachtModel] WHERE (id = {id})", conn);
      //  conn.Open();
      //  cmd.ExecuteNonQuery();

      //  //重新整理頁面
      //  //Response.Redirect(Request.Url.ToString());
      //}
      //BindData();
    }
  }
}