using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tayana.Backend
{
  public partial class UpdateYachtModel : System.Web.UI.Page
  {
    string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        BindYachtModel();
      }
    }

    private void BindYachtModel()
    {
      using (SqlConnection conn = new SqlConnection(config))
      {
        using (SqlCommand cmd = new SqlCommand("SELECT * FROM [YachtModel] where id = @id", conn))
        {
          conn.Open();
          cmd.Parameters.AddWithValue("@id", Request.QueryString["id"]);
          SqlDataReader dr = cmd.ExecuteReader();
          if (dr.HasRows)
          {
            while (dr.Read())
            {
              if (dr["newest"].ToString() == "1")
              {
                Radio1.Checked = true;
              }
              else
              {
                Radio2.Checked = true;
              }
              yacht_model.Text = dr["model"].ToString();
            }
          }
          dr.Close();
        }
      }
    }

    protected void Submit_btn_Click(object sender, EventArgs e)
    {
      string radio = Radio1.Checked ? Radio1.Value : Radio2.Value;
      using (SqlConnection conn = new SqlConnection(config))
      {
        SqlCommand cmd = new SqlCommand("update YachtModel set model = @model, newest = @newest where id = @id", conn);
        conn.Open();
        cmd.Parameters.AddWithValue("@id", Request.QueryString["id"]);
        cmd.Parameters.AddWithValue("@model", yacht_model.Text);
        cmd.Parameters.AddWithValue("@newest", radio);
        cmd.ExecuteNonQuery();
        Response.Redirect("YachtModel.aspx");
      }
    }

    protected void Cancel_btn_Click(object sender, EventArgs e)
    {
      Response.Redirect("YachtModel.aspx");
    }
  }
}