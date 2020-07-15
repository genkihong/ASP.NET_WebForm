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
  public partial class news_detail : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
      string strSQL = "SELECT news_title, news_content FROM [News] WHERE (id = @id)";
      using (SqlConnection conn = new SqlConnection(config))
      {
        using(SqlCommand cmd = new SqlCommand(strSQL, conn))
        {
          conn.Open();
          cmd.Parameters.AddWithValue("@id", Request.QueryString["id"]);
          SqlDataReader dr = cmd.ExecuteReader();
          if (dr.HasRows)
          {
            while (dr.Read())
            {
              NewsTitle.Text = dr["news_title"].ToString();
              NewsContent.Text = dr["news_content"].ToString();
            }
          }
          else
          {
            NewsTitle.Text = "Oops...";
          }
          dr.Close();
        }        
      }
    }
  }
}