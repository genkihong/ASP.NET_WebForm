using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tayana.Backend
{
  public partial class UpdateUser : System.Web.UI.Page
  {
    string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        BindUser();
      }
    }

    private void BindUser()
    {
      string strSQL = "SELECT * FROM [Users] WHERE (id = @id)";
      using (SqlConnection conn = new SqlConnection(config))
      {
        using (SqlCommand cmd = new SqlCommand(strSQL, conn))
        {
          conn.Open();
          cmd.Parameters.AddWithValue("@id", Request.QueryString["id"]);
          SqlDataReader dr = cmd.ExecuteReader();
          if (dr.HasRows)
          {
            while (dr.Read())
            {
              if (dr["user_identity"].ToString() == "2")
              {
                Radio1.Checked = true;
              }
              else
              {
                Radio2.Checked = true;
              }

              Response.Cookies["photo"].Value = dr["photo"].ToString();
              UserImage.ImageUrl = $"../Upload/images/{dr["photo"]}";
              name.Text = dr["name"].ToString();
              email.Text = dr["email"].ToString();
              Session["pwd"] = dr["password"].ToString();
              //password.Value = dr["password"].ToString();
              //password.Attributes["type"] = "password";
            }
          }
          dr.Close();
        }
      }
    }

    protected void UpdateUser_btn_Click(object sender, EventArgs e)
    {
      //登入權限
      string radioValue = "";
      if (Radio1.Checked)
      {
        radioValue = Radio1.Value;
      }
      else
      {
        radioValue = Radio2.Value;
      }

      //上傳圖片
      string fileName = "";
      if (user_img.HasFile)
      {
        if (user_img.PostedFile.ContentType.IndexOf("image") == -1)
        {
          UploadStatusLabel.Text = "檔案型態錯誤!";
          return;
        }
        //取得副檔名
        string Extension = user_img.FileName.Split('.')[user_img.FileName.Split('.').Length - 1];
        //新檔案名稱
        fileName = String.Format("{0:yyyyMMddhhmmss}.{1}", DateTime.Now, Extension);
        string savePath = Server.MapPath("~/Upload/images/");
        string saveResult = savePath + fileName;
        user_img.SaveAs(saveResult);
      }
      else
      {
        fileName = Request.Cookies["photo"].Value;
        UploadStatusLabel.Text = "You did not specify a file to upload.";
      }

      string strSQL = "UPDATE [Users] SET user_identity = @identity, name = @name, email = @email, password = @password, permission = @permission, photo = @photo WHERE (id = @id)";
      using (SqlConnection conn = new SqlConnection(config))
      {
        SqlCommand cmd = new SqlCommand(strSQL, conn);
        conn.Open();
        string hashPwd = "";
        if (password.Text.Trim() != "")
        {
          hashPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(password.Text.Trim(), "SHA1");
        }
        else
        {
          hashPwd = Session["pwd"].ToString();
        }
        cmd.Parameters.AddWithValue("@id", Request.QueryString["id"]);
        cmd.Parameters.AddWithValue("@identity", radioValue);
        cmd.Parameters.AddWithValue("@name", name.Text);
        cmd.Parameters.AddWithValue("@email", email.Text.Trim());
        cmd.Parameters.AddWithValue("@password", hashPwd);
        cmd.Parameters.AddWithValue("@permission", Permission.Value);
        cmd.Parameters.AddWithValue("@photo", fileName);
        cmd.ExecuteNonQuery();
        int page = Convert.ToInt32(Request.QueryString["page"] ?? "1");
        Response.Redirect($"admin.aspx?page={page}");
      }
    }

    protected void Cancel_btn_Click(object sender, EventArgs e)
    {
      int page = Convert.ToInt32(Request.QueryString["page"] ?? "1");
      Response.Redirect($"admin.aspx?page={page}");
    }
  }
}