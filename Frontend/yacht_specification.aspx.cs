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
  public partial class yachts03 : System.Web.UI.Page
  {
    string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
      BindYachtModel();
      BindYachtSpecification();
    }
    private void BindYachtModel()
    {
      using (SqlConnection conn = new SqlConnection(config))
      {
        //左側選單
        using (SqlCommand cmd = new SqlCommand("SELECT * FROM [YachtModel]", conn))
        {
          SqlDataAdapter sda = new SqlDataAdapter(cmd);
          DataTable dt = new DataTable();
          sda.Fill(dt);
          YachtRepeater.DataSource = dt;
          YachtRepeater.DataBind();
        }

        //船型號
        using (SqlCommand cmd = new SqlCommand("SELECT * FROM [YachtModel] where id = @id", conn))
        {
          conn.Open();
          cmd.Parameters.AddWithValue("@id", Request.QueryString["id"] ?? "1");
          SqlDataReader dr = cmd.ExecuteReader();
          if (dr.HasRows)
          {
            while (dr.Read())
            {
              overview.NavigateUrl = $"yacht_overview.aspx?id={dr["id"]}";
              layout.NavigateUrl = $"yacht_layout.aspx?id={dr["id"]}";
              specification.NavigateUrl = $"yacht_specification.aspx?id={dr["id"]}";
              breadcrumb.Text = dr["model"].ToString();
              title.Text = dr["model"].ToString();
            }
          }
          dr.Close();
        }
      }
    }

    private void BindYachtSpecification()
    {
      using (SqlConnection conn = new SqlConnection(config))
      {
        using (SqlCommand cmd = new SqlCommand("SELECT * FROM YachtDetail WHERE yacht_id = @id", conn))
        {
          conn.Open();
          cmd.Parameters.AddWithValue("@id", Request.QueryString["id"] ?? "1");
          SqlDataReader dr = cmd.ExecuteReader();
          while (dr.Read())
          {
            content.Text = dr["specification"].ToString();
          }
          dr.Close();
        }
      }
    }
  }
}