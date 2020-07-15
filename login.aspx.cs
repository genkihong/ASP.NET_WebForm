using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;

namespace Tayana
{
  public partial class login : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      //if (!User.Identity.IsAuthenticated)
      //{

      //}
    }

    protected void SignIn_btn_Click(object sender, EventArgs e)
    {
      string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
      using (SqlConnection conn = new SqlConnection(config))
      {
        using (SqlCommand cmd = new SqlCommand("SELECT * FROM [Users] WHERE (name = @name) AND (password = @password)", conn))
        {
          SqlDataAdapter sda = new SqlDataAdapter(cmd);
         
          string hashPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(password.Text.Trim(), "SHA1");

          cmd.Parameters.AddWithValue("@name", username.Text.Trim());
          cmd.Parameters.AddWithValue("@password", hashPwd); ;
          DataTable dt = new DataTable();
          sda.Fill(dt);
          //假如DataTable從資料庫有找到資料
          if (dt.Rows.Count > 0)
          {
            //創類別物件
            Userinformation Userinformation = new Userinformation();

            //替類別存入內容(下面是用DataTable從資料庫取得資料)
            Userinformation.identity = Convert.ToInt32(dt.Rows[0]["user_identity"]);
            Userinformation.username = dt.Rows[0]["name"].ToString();
            Userinformation.email = dt.Rows[0]["email"].ToString();
            Userinformation.permission = dt.Rows[0]["permission"].ToString();
            Userinformation.photo = dt.Rows[0]["photo"].ToString();

            //將物件序列化成字串
            string userData = JsonConvert.SerializeObject(Userinformation);

            //副程式SetAuthenTicket 創立一張驗證票跟存入Cookie
            SetAuthenTicket(userData, username.Text);//使用者資訊和使用者名稱

            var identityAdmin = (int)Identity.Admin;
            
            //跳轉至登入後的頁面
            if (Userinformation.identity == identityAdmin)//管理者
            {
              Response.Redirect("Backend/admin.aspx");
            }
            else
            {
              Response.Redirect("Backend/index.aspx");
            }
          }
          //登入失敗
          else
          {
            //某個Label顯示登入失敗
            LoginLabel.Text = "登入失敗，請檢查帳號或密碼!";
          }
        }
      }
    }

    //副程式SetAuthenTicket 創立一張驗證票跟存入Cookie 
    void SetAuthenTicket(string userData, string userId)
    {
      //宣告一個驗證票
      FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
      1,//版本
      userId,//使用者名稱
      DateTime.Now,//發行時間
      DateTime.Now.AddHours(3),//有效時間
      false,  //是否將 Cookie 設定成 Session Cookie，如果是則會在瀏覽器關閉後移除。
      userData,//使用者資訊(可以想成備註欄);
      FormsAuthentication.FormsCookiePath);//存放於 Cookie 中的路徑

      //加密驗證票
      String encryptedTicket = FormsAuthentication.Encrypt(ticket);

      //建立Cookie
      HttpCookie authenticationcookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
      authenticationcookie.Expires = DateTime.Now.AddHours(3);

      //將Cookie寫入回應
      Response.Cookies.Add(authenticationcookie);
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