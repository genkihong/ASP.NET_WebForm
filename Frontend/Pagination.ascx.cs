using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tayana.Frontend
{
  public partial class Pagination : System.Web.UI.UserControl
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    private int _Totalitems;
    public int totalitems
    {
      get
      {
        return _Totalitems;
      }
      set
      {
        _Totalitems = value;
      }
    }
    private int _Limit;
    public int limit
    {
      get
      {
        return _Limit;
      }
      set
      {
        _Limit = value;
      }
    }
    private string _Targetpage;
    public string targetpage
    {
      get
      {
        return _Targetpage;
      }
      set
      {
        _Targetpage = value;
      }
    }
    //protected void Page_Load(object sender, EventArgs e)
    //{
    //    showPageControls();
    //}
    public void showPageControls()
    {
      LiteralPage.Text = "";//清空
      int page = 1;
      if (!string.IsNullOrEmpty(Request["page"]))
      {
        if (IsNumber(Request["page"]))
        {
          page = Convert.ToInt16(Request["page"]);
        }
      }
      if (totalitems == 0)
      {
        return;
      }
      if (limit == 0)
      {
        return;
      }
      targetpage = targetpage ?? System.IO.Path.GetFileName(Request.PhysicalPath);
      LiteralPage.Text = getPaginationString(page, totalitems, limit, 2, targetpage);
    }
    #region "判斷是否為數字"
    /// <summary>
    /// 判斷是否為數字
    /// </summary>
    /// <param name="inputData">輸入字串</param>
    /// <returns>bool</returns>
    bool IsNumber(string inputData)
    {
      return System.Text.RegularExpressions.Regex.IsMatch(inputData, "^[0-9]+$");
    }
    #endregion
    #region "產生分頁控制項"
    /// <summary>
    /// 產生分頁控制項
    /// </summary>
    /// <param name="page">目前第幾頁</param>
    /// <param name="totalitems">共有幾筆</param>
    /// <param name="limit">一頁幾筆</param>
    /// <param name="adjacents">不知道，傳2~5都OK</param>
    /// <param name="targetpage">連結文字，例:pagination.aspx?foo=bar</param>
    /// <returns></returns>
    public static string getPaginationString(int page, int totalitems, int limit, int adjacents, string targetpage)
    {
      //defaults
      targetpage = targetpage.IndexOf('?') != -1 ? targetpage + "&" : targetpage + "?";
      string margin = "";
      string padding = "";
      //other vars
      int prev = page - 1;
      //previous page is page - 1
      int nextPage = page + 1;
      //nextPage page is page + 1
      Double value = Convert.ToDouble((decimal)totalitems / limit);
      int lastpage = Convert.ToInt16(Math.Ceiling(value));
      //lastpage is = total items / items per page, rounded up.
      int lpm1 = lastpage - 1;
      //last page minus 1
      int counter = 0;
      // Now we apply our rules and draw the pagination object. 
      // We're actually saving the code to a variable in case we want to draw it more than once.
      StringBuilder paginationBuilder = new StringBuilder();
      if (lastpage > 1)
      {
        paginationBuilder.Append("<div class=\"pagination\"");
        if (!string.IsNullOrEmpty(margin) | !string.IsNullOrEmpty(padding))
        {
          paginationBuilder.Append(" style=\"");
          if (!string.IsNullOrEmpty(margin))
          {
            paginationBuilder.Append("margin: margin");
          }
          if (!string.IsNullOrEmpty(padding))
          {
            paginationBuilder.Append("padding: padding");
          }
          paginationBuilder.Append("\"");
        }
        paginationBuilder.Append(">共<span style=\"color:red\" >" + totalitems + "</span>筆資料");
        //previous button
        paginationBuilder.Append(page > 1 ? string.Format("<a href=\"{0}page={1}\">上一頁</a>", targetpage, prev) : "<span class=\"disabled\">上一頁</span>");
        //pages 
        if (lastpage < 7 + (adjacents * 2))
        {
          //not enough pages to bother breaking it up
          for (counter = 1; counter <= lastpage; counter++)
          {
            paginationBuilder.Append(counter == page ? string.Format("<span class=\"current\">{0}</span>", counter) : string.Format("<a href=\"{0}page={1}\">{1}</a>", targetpage, counter));
          }
        }
        else if (lastpage >= 7 + (adjacents * 2))
        {
          //enough pages to hide some
          //close to beginning only hide later pages
          if (page < 1 + (adjacents * 3))
          {
            for (counter = 1; counter <= (4 + (adjacents * 2)) - 1; counter++)
            {
              paginationBuilder.Append(counter == page ? string.Format("<span class=\"current\">{0}</span>", counter) : string.Format("<a href=\"{0}page={1}\">{1}</a>", targetpage, counter));
            }
            paginationBuilder.Append("...");
            paginationBuilder.Append(string.Format("<a href=\"{0}page={1}\">{1}</a>", targetpage, lpm1));
            paginationBuilder.Append(string.Format("<a href=\"{0}page={1}\">{1}</a>", targetpage, lastpage));
          }
          //in middle hide some front and some back
          else if (lastpage - (adjacents * 2) > page & page > (adjacents * 2))
          {
            paginationBuilder.Append(string.Format("<a href=\"{0}page=1\">1</a>", targetpage));
            paginationBuilder.Append(string.Format("<a href=\"{0}page=2\">2</a>", targetpage));
            paginationBuilder.Append("...");
            for (counter = (page - adjacents); counter <= (page + adjacents); counter++)
            {
              paginationBuilder.Append(counter == page ? string.Format("<span class=\"current\">{0}</span>", counter) : string.Format("<a href=\"{0}page={1}\">{1}</a>", targetpage, counter));
            }
            paginationBuilder.Append("...");
            paginationBuilder.Append(string.Format("<a href=\"{0}page={1}\">{1}</a>", targetpage, lpm1));
            paginationBuilder.Append(string.Format("<a href=\"{0}page={1}\">{1}</a>", targetpage, lastpage));
          }
          else
          {
            //close to end only hide early pages
            paginationBuilder.Append(string.Format("<a href=\"{0}page=1\">1</a>", targetpage));
            paginationBuilder.Append(string.Format("<a href=\"{0}page=2\">2</a>", targetpage));
            paginationBuilder.Append("...");
            for (counter = (lastpage - (1 + (adjacents * 3))); counter <= lastpage; counter++)
            {
              paginationBuilder.Append(counter == page ? string.Format("<span class=\"current\">{0}</span>", counter) : string.Format("<a href=\"{0}page={1}\">{1}</a>", targetpage, counter));
            }
          }
        }
        //nextPage button
        paginationBuilder.Append(page < counter - 1 ? string.Format("<a href=\"{0}page={1}\">下一頁</a>", targetpage, nextPage) : "<span class=\"disabled\">下一頁</span>");
        paginationBuilder.Append("</div>\r\n");
      }
      return paginationBuilder.ToString();
    }
    #endregion
  }
}