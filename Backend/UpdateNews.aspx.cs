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
  public partial class UpdateNews : System.Web.UI.Page
  {
    string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        BindNews();
      }
    }

    private void BindNews()
    {
      using (SqlConnection conn = new SqlConnection(config))
      {
        using (SqlCommand cmd = new SqlCommand("SELECT * FROM [News] WHERE (id = @id)", conn))
        {
          conn.Open();
          cmd.Parameters.AddWithValue("@id", Request.QueryString["id"]);
          SqlDataReader dr = cmd.ExecuteReader();
          if (dr.HasRows)
          {
            while (dr.Read())
            {
              if (dr["news_top"].ToString() == "1")
              {
                Radio1.Checked = true;
              }
              else
              {
                Radio2.Checked = true;
              }
              Response.Cookies["news_img"].Value = dr["news_img"].ToString();
              NewsImage.ImageUrl = $"../Upload/images/{dr["news_img"]}";
              news_date.Text = dr["news_date"].ToString().Replace("/", "-");
              news_title.Text = dr["news_title"].ToString();
              news_summary.Text = dr["news_summary"].ToString();
              news_content.Text = dr["news_content"].ToString();
            }
          }
          dr.Close();
        }
      }
    }

    private string UploadPhoto()
    {
      string fileName = "";
      if (news_img.HasFile)
      {
        if (news_img.PostedFile.ContentType.IndexOf("image") == -1)
        {
          UploadStatusLabel.Text = "檔案型態錯誤!";
        }
        //取得副檔名
        string Extension = news_img.FileName.Split('.')[news_img.FileName.Split('.').Length - 1];
        //新檔案名稱
        //fileName = String.Format("{0:yyyyMMddhhmm}.{1}", DateTime.Now, Extension);
        fileName = $"{DateTime.Now.ToString("yyyyMMddhhmmss")}.{Extension}";
        string savePath = Server.MapPath("~/Upload/images/");
        string saveResult = savePath + fileName;
        news_img.SaveAs(saveResult);
      }
      else
      {
        fileName = Request.Cookies["news_img"].Value;
        UploadStatusLabel.Text = "You did not specify a file to upload.";
      }
      return fileName;
    }

    protected void UpdateNews_btn_Click(object sender, EventArgs e)
    {
      string radioValue = Radio1.Checked ? Radio1.Value : Radio2.Value;
      string fileName = UploadPhoto();

      using (SqlConnection conn = new SqlConnection(config))
      {
        string strSQL = "UPDATE [News] SET news_top = @top, news_img = @img, news_date = @date, news_title = @title, news_summary = @summary, news_content = @content WHERE (id = @id)";
        SqlCommand cmd = new SqlCommand(strSQL, conn);
        conn.Open();
        cmd.Parameters.AddWithValue("@id", Request.QueryString["id"]);
        cmd.Parameters.AddWithValue("@img", fileName);
        cmd.Parameters.AddWithValue("@date", news_date.Text.Replace("-", "/"));
        cmd.Parameters.AddWithValue("@title", news_title.Text);
        cmd.Parameters.AddWithValue("@summary", news_summary.Text);
        cmd.Parameters.AddWithValue("@top", radioValue);
        cmd.Parameters.AddWithValue("@content", news_content.Text);
        cmd.ExecuteNonQuery();
        int page = Convert.ToInt32(Request.QueryString["page"] ?? "1");
        Response.Redirect($"newslist.aspx?page={page}");
      }
    }

    protected void Cancel_btn_Click(object sender, EventArgs e)
    {
      int page = Convert.ToInt32(Request.QueryString["page"] ?? "1");
      Response.Redirect($"newslist.aspx?page={page}");
    }
  }
}