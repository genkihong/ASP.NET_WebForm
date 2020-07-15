using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using Newtonsoft.Json;

namespace Tayana.Backend
{
  /// <summary>
  /// GetRegion 的摘要描述
  /// </summary>
  public class GetRegion : IHttpHandler
  {
    public void ProcessRequest(HttpContext context)
    {
      context.Response.ContentType = "application/json";
      string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
      using (SqlConnection conn = new SqlConnection(config))
      {
        using (SqlCommand cmd = new SqlCommand($"SELECT * FROM [Region] WHERE country_id = @id", conn))
        {
          cmd.Parameters.AddWithValue("@id", context.Request["id"]);
          SqlDataAdapter sda = new SqlDataAdapter(cmd);
          DataTable dt = new DataTable();
          sda.Fill(dt);
          if (dt.Rows.Count > 0)
          {
            string json = JsonConvert.SerializeObject(dt);
            context.Response.Write(json);
          }
          else
          {
            string json = JsonConvert.SerializeObject(new
            {
              message = "Oops" //匿名類型
            });
            context.Response.Write(json);
          }
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