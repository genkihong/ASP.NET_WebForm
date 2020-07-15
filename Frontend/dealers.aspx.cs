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
  public partial class dealers : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
      string strSQL = "SELECT Dealers.id, Country.country, Region.region, Dealers.* FROM Country " +
                      "INNER JOIN Dealers ON Country.country_id = Dealers.country_id INNER JOIN Region ON Country.country_id = Region.country_id AND Dealers.region_id = Region.region_id " +
                      "WHERE Country.country_id = @id";
      using (SqlConnection conn = new SqlConnection(config))
      {
        //經銷商所有資訊
        using (SqlCommand cmd = new SqlCommand(strSQL, conn))
        {
          cmd.Parameters.AddWithValue("@id", Request.QueryString["id"] ?? "1");
          SqlDataAdapter sda = new SqlDataAdapter(cmd);
          DataTable dt = new DataTable();
          sda.Fill(dt);
          Repeater1.DataSource = dt;
          Repeater1.DataBind();
        }
        //經銷商國家名
        using(SqlCommand cmd = new SqlCommand("select * from Country where country_id = @id", conn))
        {
          conn.Open();
          cmd.Parameters.AddWithValue("@id", Request.QueryString["id"] ?? "1");
          SqlDataReader dr = cmd.ExecuteReader();
          if (dr.HasRows)
          {
            while (dr.Read())
            {
              Label1.Text = dr["country"].ToString();
              Label2.Text = dr["country"].ToString();
            }
          }
          dr.Close();
        }
      }
    }
  }
}