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
  public partial class UpdateDealers : System.Web.UI.Page
  {
    string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        BindDealer();
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
        countrySelect.DataSource = dr;
        countrySelect.DataValueField = "country_id";
        countrySelect.DataTextField = "country";
        countrySelect.DataBind();
        dr.Close();
      }
    }

    private void BindDealer()
    {
      using (SqlConnection conn = new SqlConnection(config))
      {
        string strSQL = "SELECT Country.country, Region.region, Dealers.*" +
                        "FROM Country INNER JOIN Dealers ON Country.country_id = Dealers.country_id INNER JOIN Region ON Country.country_id = Region.country_id AND Dealers.region_id = Region.region_id " +
                        "WHERE (Dealers.id = @id)";
        using (SqlCommand cmd = new SqlCommand(strSQL, conn))
        {
          conn.Open();
          cmd.Parameters.AddWithValue("@id", Request.QueryString["id"]);
          SqlDataReader dr = cmd.ExecuteReader();
          if (dr.HasRows)
          {
            while (dr.Read())
            {
              Response.Cookies["dealer_img"].Value = dr["dealer_img"].ToString();
              DealerImage.ImageUrl = $"../Upload/images/{dr["dealer_img"]}";
              dealer_title.Text = dr["dealer_title"].ToString();
              dealer_name.Text = dr["dealer_name"].ToString();
              dealer_tel.Text = dr["dealer_tel"].ToString();
              dealer_fax.Text = dr["dealer_fax"].ToString();
              dealer_email.Text = dr["dealer_email"].ToString();
              dealer_website.Text = dr["dealer_website"].ToString();
              dealer_address.Text = dr["dealer_address"].ToString();
            }
          }
          dr.Close();
        }
      }
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
        fileName = Request.Cookies["dealer_img"].Value;
        UploadStatusLabel.Text = "You did not specify a file to upload.";
      }
      return fileName;
    }
    
    protected void Submit_btn_Click(object sender, EventArgs e)
    {
      string fileName = UploadPhoto();

      using (SqlConnection conn = new SqlConnection(config))
      {
        string strSQL = "UPDATE [Dealers] SET country_id = @country_id, region_id = @region_id, dealer_img = @img, dealer_title = @title, " +
                        "dealer_name = @name, dealer_tel = @tel, dealer_fax = @fax, dealer_email = @email, dealer_website = @website, dealer_address = @address " +
                        "WHERE (id = @id)";
        SqlCommand cmd = new SqlCommand(strSQL, conn);
        conn.Open();
        cmd.Parameters.AddWithValue("@id", Request.QueryString["id"]);
        cmd.Parameters.AddWithValue("@country_id", countrySelect.SelectedValue);
        cmd.Parameters.AddWithValue("@region_id", Request.Form["region"]);
        //cmd.Parameters.AddWithValue("@region_id", regionValue.Value);
        cmd.Parameters.AddWithValue("@img", fileName);
        cmd.Parameters.AddWithValue("@title", dealer_title.Text);
        cmd.Parameters.AddWithValue("@name", dealer_name.Text);
        cmd.Parameters.AddWithValue("@tel", dealer_tel.Text);
        cmd.Parameters.AddWithValue("@fax", dealer_fax.Text);
        cmd.Parameters.AddWithValue("@email", dealer_email.Text);
        cmd.Parameters.AddWithValue("@website", dealer_website.Text);
        cmd.Parameters.AddWithValue("@address", dealer_address.Text);
        cmd.ExecuteNonQuery();
        int page = Convert.ToInt32(Request.QueryString["page"] ?? "1");
        Response.Redirect($"DealersList.aspx?page={page}");
      }
    }

    protected void Cancel_btn_Click(object sender, EventArgs e)
    {
      int page = Convert.ToInt32(Request.QueryString["page"] ?? "1");
      Response.Redirect($"DealersList.aspx?page={page}");
    }
  }
}