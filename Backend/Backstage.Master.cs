using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace Tayana
{
  public partial class Backstage : System.Web.UI.MasterPage
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      CheckUser();
    }

    /// <summary>
    /// 登入權限判斷
    /// </summary>
    private void CheckUser()
    {
      //確認使用者是否有驗證票，現在是否登入，假如沒有就跳回Login頁面。

      if (!HttpContext.Current.User.Identity.IsAuthenticated)
      {
        Response.Redirect("../login.aspx");
      }
      //string strLoginID = User.Identity.Name;

      //要取得驗證票內所存的使用者的資料，先將UserData反序列化成物件才能控制

      //取得UserData
      string strUserData = ((FormsIdentity)(HttpContext.Current.User.Identity)).Ticket.UserData;
      //string[] userData = ((FormsIdentity)(HttpContext.Current.User.Identity)).Ticket.UserData.Split(new Char[]{','});
      //userData[0] = 帳號
      //userData[1] = Email

      //反序列化為物件，其名為currentUser
      Userinformation currentUser = JsonConvert.DeserializeObject<Userinformation>(strUserData);

      //取得票卷上的username
      UserLabel.Text = HttpContext.Current.User.Identity.Name;
      //UserLabel1.Text = currentUser.username;

      //取得UserData內的使用者資訊      
      UserImage.ImageUrl = $"../Upload/images/{currentUser.photo}";
      EmailLabel.Text = currentUser.email;

      var identityUser = (int)Identity.User;

      if (currentUser.identity == identityUser)//一般使用者
      {
        //AdminImage.Visible = false;
        member.Visible = false;
        yachts.Visible = false;
        news.Visible = false;
        dealers.Visible = false;

        if (currentUser.permission.Contains("01"))//船型管理
        {
          yachts.Visible = true;
        }
        if (currentUser.permission.IndexOf("02") != -1)//新聞管理
        {
          news.Visible = true;
        }
        if (currentUser.permission.IndexOf("03") != -1)//經銷商管理
        {
          dealers.Visible = true;
        }
      }
    }

    protected void Signout_btn_Click(object sender, EventArgs e)
    {
      //登出表單驗證票卷
      FormsAuthentication.SignOut();

      //跳轉回使用者登入頁面
      Response.Redirect("../login.aspx");
    }

    public enum Identity
    {
      [Description("管理者")]
      Admin = 1,

      [Description("一般使用者")]
      User = 2,
    }

    public enum Permission
    {
      [Description("遊艇管理")]
      Yacht = 01,

      [Description("新聞管理")]
      News = 02,

      [Description("經銷商管理")]
      Dealer = 03,
    }
  }
}