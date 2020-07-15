using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Tayana.Backend
{
  /// <summary>
  /// CheckAccount 的摘要描述
  /// </summary>
  public class CheckAccount : IHttpHandler
  {
    public void ProcessRequest(HttpContext context)
    {
      context.Response.ContentType = "text/plain";
      string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
      using (SqlConnection conn = new SqlConnection(config))
      {
        using (SqlCommand cmd = new SqlCommand("SELECT * FROM [Users] WHERE name = @name", conn))
        {
          cmd.Parameters.AddWithValue("@name", context.Request["name"]);
          SqlDataAdapter sda = new SqlDataAdapter(cmd);
          DataTable dt = new DataTable();
          sda.Fill(dt);
          context.Response.Write(dt.Rows.Count > 0 ? "1" : "0");
        }
      }
    }

    public bool IsReusable
    {
      get
      {
        return false;
      }
    }
  }
}