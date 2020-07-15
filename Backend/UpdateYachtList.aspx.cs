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
  public partial class UpdateYachtList : System.Web.UI.Page
  {
    string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        BindYachtModel();
        BindYachtDetail();
      }
    }
    private void BindYachtModel()
    {
      using (SqlConnection conn = new SqlConnection(config))
      {
        string strSQL = "SELECT YachtDetail.id, YachtModel.model FROM YachtDetail " +
                        "INNER JOIN YachtModel ON YachtDetail.yacht_id = YachtModel.id where YachtDetail.id=@id";
        SqlCommand cmd = new SqlCommand(strSQL, conn);
        conn.Open();
        cmd.Parameters.AddWithValue("@id", Request.QueryString["id"]);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
          Literal1.Text = dr["model"].ToString();
        }
        dr.Close();
      }
    }

    private void BindYachtDetail()
    {
      using (SqlConnection conn = new SqlConnection(config))
      {
        using (SqlCommand cmd = new SqlCommand("SELECT * FROM [YachtDetail] WHERE (id = @id)", conn))
        {
          conn.Open();
          cmd.Parameters.AddWithValue("@id", Request.QueryString["id"]);
          SqlDataReader dr = cmd.ExecuteReader();
          if (dr.HasRows)
          {
            while (dr.Read())
            {
              YachtOverview.Text = dr["overview"].ToString();
              YachtDimensions.Text = dr["dimensions"].ToString();
              YachtLayout.Text = dr["layout"].ToString();
              YachtSpecification.Text = dr["specification"].ToString();
            }
          }
          dr.Close();
        }
      }
    }

    protected void Submit_btn_Click(object sender, EventArgs e)
    {
      using (SqlConnection conn = new SqlConnection(config))
      {
        string strSQL = "UPDATE [YachtDetail] SET overview = @overview, dimensions = @dimensions, layout = @layout, specification = @specification where id = @id";
        SqlCommand cmd = new SqlCommand(strSQL, conn);
        conn.Open();
        cmd.Parameters.AddWithValue("@id", Request.QueryString["id"]);
        cmd.Parameters.AddWithValue("@overview", YachtOverview.Text);
        cmd.Parameters.AddWithValue("@dimensions", YachtDimensions.Text);
        cmd.Parameters.AddWithValue("@layout", YachtLayout.Text);
        cmd.Parameters.AddWithValue("@specification", YachtSpecification.Text);
        cmd.ExecuteNonQuery();
        int page = Convert.ToInt32(Request.QueryString["page"] ?? "1");
        Response.Redirect($"YachtList.aspx?page={page}");
      }
    }

    protected void Cancel_btn_Click(object sender, EventArgs e)
    {
      int page = Convert.ToInt32(Request.QueryString["page"] ?? "1");
      Response.Redirect($"YachtList.aspx?page={page}");
    }
  }
}