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
  public partial class AddNews : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {

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
        UploadStatusLabel.Text = "You did not specify a file to upload.";
      }
      return fileName;
    }

    protected void Submit_btn_Click(object sender, EventArgs e)
    {
      string fileName = UploadPhoto();
      string radioValue = Radio1.Checked ? Radio1.Value : Radio2.Value;
      string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
      using (SqlConnection conn = new SqlConnection(config))
      {
        string strSQL = "INSERT INTO [News] (news_top, news_img, news_date, news_title, news_summary, news_content) VALUES (@top, @img, @date, @title, @summary, @content)";
        SqlCommand cmd = new SqlCommand(strSQL, conn);
        conn.Open();
        cmd.Parameters.AddWithValue("@img", fileName);
        //cmd.Parameters.AddWithValue("@date", news_date.Text.Replace("-", "/"));
        cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy/MM/dd"));
        cmd.Parameters.AddWithValue("@title", news_title.Text);
        cmd.Parameters.AddWithValue("@summary", news_summary.Text);
        cmd.Parameters.AddWithValue("@top", radioValue);
        cmd.Parameters.AddWithValue("@content", news_content.Text);
        cmd.ExecuteNonQuery();
        Response.Redirect("NewsList.aspx");        
      }
    }

    protected void Cancel_btn_Click(object sender, EventArgs e)
    {
      Session.Clear();
      Response.Redirect("NewsList.aspx");
    }
  }
}