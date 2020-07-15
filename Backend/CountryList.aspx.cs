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
  public partial class CountryList : System.Web.UI.Page
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
        SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM [Country]", conn);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
      }
    }
    
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
      GridView1.EditIndex = e.NewEditIndex;
      BindData();
    }
    //更新資料
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
      #region
      using (SqlConnection conn = new SqlConnection(config))
      {
        int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
        string country = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[1].Controls[0])).Text;
        conn.Open();
        SqlCommand cmd = new SqlCommand($"UPDATE [Country] SET country = @country WHERE (country_id = {id})", conn);
        cmd.Parameters.AddWithValue("@country", country);        
        cmd.ExecuteNonQuery();
      }
      GridView1.EditIndex = -1;
      BindData();
      #endregion
    }
    //取消編輯
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
      GridView1.EditIndex = -1; //編輯索引賦值為-1，變回正常顯示狀態
      BindData();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
      using (SqlConnection conn = new SqlConnection(config))
      {
        int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);        
        SqlCommand cmd = new SqlCommand($"DELETE FROM [Country] WHERE (country_id = {id})", conn);        
        conn.Open();
        cmd.ExecuteNonQuery();       

        //重新整理頁面
        //Response.Redirect(Request.Url.ToString());
      }
      BindData();
    }

    protected void AddCountry_btn_Click(object sender, EventArgs e)
    {
      Response.Redirect("AddCountry.aspx");
    }
  }  
}
