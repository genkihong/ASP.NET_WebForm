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
  public partial class AddDealers : System.Web.UI.Page
  {
    string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        BindCountry();
      }
    }
    /// <summary>
    /// 繫結國家
    /// </summary>
    private void BindCountry()
    {
      using (SqlConnection conn = new SqlConnection(config))
      {
        SqlCommand cmd = new SqlCommand("SELECT * FROM [Country]", conn);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();

        #region 寫法一
        while (dr.Read())
        {
          countrySelect.Items.Add(new ListItem(
              dr["country"].ToString(),
              dr["country_id"].ToString()
              ));
        }
        #endregion

        #region 寫法二
        //while (dr.Read())
        //{
        //  countrySelect.DataValueField = dr["country_id"].ToString();
        //  countrySelect.DataTextField = dr["country"].ToString();
        //  countrySelect.Items.Add(dr["country"].ToString());
        //}
        #endregion

        #region 寫法三
        //countrySelect.DataSource = dr;
        //countrySelect.DataValueField = "country_id";
        //countrySelect.DataTextField = "country";
        //countrySelect.DataBind();
        #endregion

        dr.Close();
        conn.Close();
      }
    }

    /// <summary>
    /// 用國家ID繫結地區
    /// </summary>
    private void BindRegion()
    {
      //using (SqlConnection conn = new SqlConnection(config))
      //{
      //  int id = Convert.ToInt32(countrySelect.SelectedValue);
      //  SqlCommand cmd = new SqlCommand($"SELECT * FROM [Region] WHERE country_id = {id}", conn);
      //  conn.Open();
      //  SqlDataReader dr = cmd.ExecuteReader();
      //  DropDownList2.DataSource = dr;
      //  DropDownList2.DataValueField = "region_id";
      //  DropDownList2.DataTextField = "region";
      //  DropDownList2.DataBind();
      //  dr.Close();
      //}
    }

    /// <summary>
    /// 選擇了國家後帶出地區，將兩個 DropDownList 的預設第一個選項都設定為「請選擇」
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
    {
      //if (countrySelect.SelectedValue != "-1")
      //{
      //  DropDownList2.Items.Clear();
      //  DropDownList2.Items.Insert(0, new ListItem("請選擇", "-1"));
      //  BindRegion();
      //}
      //else
      //{
      //  DropDownList2.Items.Clear();
      //  DropDownList2.Items.Insert(0, new ListItem("請選擇", "-1"));
      //}
    }

    private string UploadPhoto()
    {
      string fileName = "";
      if (dealers_img.HasFile)
      {
        if (dealers_img.PostedFile.ContentType.IndexOf("image") == -1)
        {
          UploadStatusLabel.Text = "檔案型態錯誤!";
        }
        //取得副檔名
        string Extension = dealers_img.FileName.Split('.')[dealers_img.FileName.Split('.').Length - 1];
        //新檔案名稱
        //fileName = String.Format("{0:yyyyMMddhhmm}.{1}", DateTime.Now, Extension);
        fileName = $"{DateTime.Now.ToString("yyyyMMddhhmmss")}.{Extension}";
        string savePath = Server.MapPath("~/Upload/images/");
        string saveResult = savePath + fileName;
        dealers_img.SaveAs(saveResult);
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

      using (SqlConnection conn = new SqlConnection(config))
      {
        string strSQL = "INSERT INTO [Dealers] " +
                        "(country_id, region_id, dealer_img, dealer_title, dealer_name, dealer_tel, dealer_fax, dealer_email, dealer_website, dealer_address) " +
                        "VALUES (@country_id, @region_id, @img, @title, @name, @tel, @fax, @email, @website, @address)";
        SqlCommand cmd = new SqlCommand(strSQL, conn);
        conn.Open();
        cmd.Parameters.AddWithValue("@country_id", countrySelect.SelectedValue);
        cmd.Parameters.AddWithValue("@region_id", Request.Form["region"]);
        cmd.Parameters.AddWithValue("@img", fileName);
        cmd.Parameters.AddWithValue("@title", dealer_title.Text);
        cmd.Parameters.AddWithValue("@name", dealer_name.Text);
        cmd.Parameters.AddWithValue("@tel", dealer_tel.Text);
        cmd.Parameters.AddWithValue("@fax", dealer_fax.Text);
        cmd.Parameters.AddWithValue("@email", dealer_email.Text);
        cmd.Parameters.AddWithValue("@website", dealer_website.Text);
        cmd.Parameters.AddWithValue("@address", dealer_address.Text);
        cmd.ExecuteNonQuery();
        Response.Redirect($"DealersList.aspx");
      }
    }

    protected void Cancel_btn_Click(object sender, EventArgs e)
    {
      int page = Convert.ToInt32(Request.QueryString["page"]);
      Response.Redirect($"DealersList.aspx?page={page}");
    }
  }
}