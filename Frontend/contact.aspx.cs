using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Linq;

namespace Tayana.Frontend
{
  public partial class contact : System.Web.UI.Page
  {
    string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        BindData();
      }
    }
    private void BindData()
    {
      using (SqlConnection conn = new SqlConnection(config))
      {
        SqlCommand cmd = new SqlCommand("SELECT * FROM [Country]", conn);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        CountryDropDownList.DataSource = dr;
        CountryDropDownList.DataValueField = "country_id";
        CountryDropDownList.DataTextField = "country";
        CountryDropDownList.DataBind();
        dr.Close();
      }

      using (SqlConnection conn = new SqlConnection(config))
      {
        SqlCommand cmd = new SqlCommand("SELECT * FROM [YachtModel]", conn);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        YachtModelDropDownList.DataSource = dr;
        YachtModelDropDownList.DataValueField = "id";
        YachtModelDropDownList.DataTextField = "model";
        YachtModelDropDownList.DataBind();
        dr.Close();
      }
    }

    /// <summary>
    /// 寄信函數
    /// </summary>
    /// <param name="body">信件內容</param>
    /// <param name="receiveMail">收件人信箱</param>
    public static void SendEmail(string body, string receiveMail)
    {
      // 寄信人Email
      string sendMail = ConfigurationManager.AppSettings["sendMail"].Trim();
      // 收信人Email(多筆用逗號隔開)
      //string receiveMails = ConfigurationManager.AppSettings["receiveMails"].Trim();
      // 寄信smtp server
      string smtpServer = ConfigurationManager.AppSettings["smtpServer"].Trim();
      // 寄信smtp server的Port，預設25
      int smtpPort = Convert.ToInt32(ConfigurationManager.AppSettings["smtpPort"].Trim());
      // 寄信帳號
      string mailAccount = ConfigurationManager.AppSettings["mailAccount"].Trim();
      // 寄信密碼
      string mailPwd = ConfigurationManager.AppSettings["mailPwd"].Trim();

      MailMessage Mail = new MailMessage();

      Mail.From = new MailAddress(mailAccount);//設定寄件者Email
      Mail.To.Add(receiveMail); //設定收件者Email
      //Mail.Bcc.Add("密件副本的收件者Mail"); //加入密件副本的Mail          
      Mail.Subject = "Email Test";
      Mail.Body = body; //設定信件內容
      Mail.IsBodyHtml = true; //是否使用html格式

      SmtpClient SMTP = new SmtpClient();
      SMTP.Host = smtpServer;
      SMTP.Port = smtpPort;
      SMTP.EnableSsl = true;
      SMTP.Credentials = new NetworkCredential(mailAccount, mailPwd);
      try
      {
        SMTP.Send(Mail);
        Mail.Dispose(); //釋放資源
      }
      catch (Exception ex)
      {
        ex.ToString();
      }
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
      string userEmail = email.Text;
      string template = File.ReadAllText(Server.MapPath("/Frontend/MailForm.html"));
      template = template.Replace("@name", name.Text)
        .Replace("@email", email.Text)
        .Replace("@phone", phone.Text)
        .Replace("@country", CountryDropDownList.SelectedItem.Text)
        .Replace("@yacht", YachtModelDropDownList.SelectedItem.Text)
        .Replace("@comment", comments.Text.Replace("\n", "<br>"));
      SendEmail(template, userEmail);
    }
  }
}