using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tayana.Backend
{
  public partial class AddUser : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      
    }

    private string UploadPhoto()
    {
      string fileName = "";
      if (user_img.HasFile)
      {
        if (user_img.PostedFile.ContentType.IndexOf("image") == -1)
        {
          UploadStatusLabel.Text = "檔案型態錯誤!";
        }
        
        //取得副檔名
        string Extension = user_img.FileName.Split('.')[user_img.FileName.Split('.').Length - 1];
        //新檔案名稱
        //fileName = String.Format("{0:yyyyMMddhhmm}.{1}", DateTime.Now, Extension);
        fileName = $"{DateTime.Now.ToString("yyyyMMddhhmmss")}.{Extension}";
        string savePath = Server.MapPath("~/Upload/images/");
        string saveResult = savePath + fileName;
        user_img.SaveAs(saveResult);
      }
      else
      {
        UploadStatusLabel.Text = "You did not specify a file to upload.";
      }
      return fileName;
    }

    protected void Submit_btn_Click(object sender, EventArgs e)
    {
      string radioValue = Radio1.Checked ? Radio1.Value : Radio2.Value;
      #region
      //string checkBoxValue = "";
      //foreach (ListItem li in CheckBoxList.Items)
      //{
      //  if (li.Selected)
      //  {
      //    checkBoxValue += li.Value + ",";
      //  }
      //}
      #endregion
      string fileName = UploadPhoto();
      
      string strSQL = "";
      string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
      using (SqlConnection conn = new SqlConnection(config))
      {
        //先判斷是否有重複的帳號或 email
        strSQL = "SELECT * FROM [Users] WHERE (name = @name) or (email = @email)";
        SqlCommand cmd1 = new SqlCommand(strSQL, conn);
        SqlDataAdapter sda = new SqlDataAdapter(cmd1);
        cmd1.Parameters.AddWithValue("@name", name.Text.Trim());
        cmd1.Parameters.AddWithValue("@email", email.Text.Trim());
        DataTable dt = new DataTable();
        sda.Fill(dt);
        if (dt.Rows.Count > 0)
        {
          foreach (DataRow row in dt.Rows)
          {
            if (row["name"].ToString() == name.Text.Trim())
            {
              accountMessage.Text = "帳號已存在!";
            }
            if (row["email"].ToString() == email.Text.Trim())
            {
              emailMessage.Text = "Email已存在!";
            }
          }
        }
        else
        {
          //沒有重複的帳號或 email 才寫入資料庫
          strSQL = "INSERT INTO Users (user_identity,name,email,password,permission,photo) VALUES (@identity,@name,@email,@password,@permission,@photo)";
          SqlCommand cmd = new SqlCommand(strSQL, conn);
          conn.Open();

          string hashPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(password.Text.Trim(), "SHA1");
          //string hashPwd = GetSwcSHA1(password.Text.Trim());

          //cmd.Parameters.AddWithValue("@identity", RadioButtonList1.SelectedValue);
          //cmd.Parameters.AddWithValue("@permission", checkBoxValue);
          cmd.Parameters.AddWithValue("@identity", radioValue);
          cmd.Parameters.AddWithValue("@name", name.Text);
          cmd.Parameters.AddWithValue("@email", email.Text.Trim());
          cmd.Parameters.AddWithValue("@password", hashPwd);
          cmd.Parameters.AddWithValue("@permission", Permission.Value);
          cmd.Parameters.AddWithValue("@photo", fileName);
          cmd.ExecuteNonQuery();
          Response.Redirect("admin.aspx");
          //conn.Close();
        }
      }
    }
    
    protected void Cancel_btn_Click(object sender, EventArgs e)
    {
      Session.Clear();
      Response.Redirect("admin.aspx");
    }

    public enum Identity
    {
      [Description("管理者")]
      Admin = 1,

      [Description("一般使用者")]
      User = 2,
    }

    public static string GetSwcSHA1(string value)
    {
      SHA1 algorithm = SHA1.Create();
      byte[] data = algorithm.ComputeHash(Encoding.UTF8.GetBytes(value));
      string sh1 = "";
      for (int i = 0; i < data.Length; i++)
      {
        sh1 += data[i].ToString("x2").ToUpperInvariant();
      }
      return sh1;
    }
  }
}