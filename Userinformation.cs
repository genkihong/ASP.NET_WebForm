using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;

namespace Tayana
{
  public class Userinformation
  {
    //public int id { get; set; }//主Key
    //public string name { get; set; }//暱稱
    public int identity { get; set; } //使用者身分
    public string username { get; set; }//使用者名稱
    public string email { get; set; } //信箱 email
    public string permission { get; set; }//權限
    public string photo { get; set; }//照片
  }  
}