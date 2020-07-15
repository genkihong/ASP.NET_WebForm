using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tayana.Backend
{
  public partial class UpdateYachtPhoto : System.Web.UI.Page
  {
    string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        BindYachtModel();
        BindYachtPhoto();
      }
    }

    private void BindYachtModel()
    {
      using (SqlConnection conn = new SqlConnection(config))
      {
        SqlCommand cmd = new SqlCommand("SELECT * FROM [YachtModel]", conn);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        YachtModel.DataSource = dr;
        YachtModel.DataValueField = "id";
        YachtModel.DataTextField = "model";
        YachtModel.DataBind();
        dr.Close();
      }
    }

    private void BindYachtPhoto()
    {
      using (SqlConnection conn = new SqlConnection(config))
      {
        string strSQL = "SELECT * FROM YachtPhoto WHERE (id = @id)";
        using (SqlCommand cmd = new SqlCommand(strSQL, conn))
        {
          conn.Open();
          cmd.Parameters.AddWithValue("@id", Request.QueryString["id"]);
          SqlDataReader dr = cmd.ExecuteReader();
          if (dr.HasRows)
          {
            while (dr.Read())
            {
              Response.Cookies["yacht_img"].Value = dr["photo"].ToString();
              YachtImage.ImageUrl = $"../Upload/images/{dr["photo"]}";
            }
          }
          dr.Close();
        }
      }
    }

    /// <summary>
    /// 舉世無敵縮圖程式(指定高度，等比例縮小)
    /// </summary>
    /// <param name="name">原檔檔名</param>
    /// <param name="source">來源路徑</param>
    /// <param name="target">目的路徑</param>
    /// <param name="suffix">縮圖辯識符號</param>
    /// <param name="MaxHight">指定要縮的高度</param>
    /// <remarks></remarks>
    public void GenerateThumbnailImage(string name, System.IO.Stream source, string target, string suffix, int MaxHight)
    {
      System.Drawing.Image baseImage = System.Drawing.Image.FromStream(source);
      Single ratio = 0.0F;//存放縮圖比例
      Single h = baseImage.Height; //圖像原尺寸高度
      Single w = baseImage.Width;  //圖像原尺寸寬度
      int ht; //圖像縮圖後高度
      int wt; //圖像縮圖後寬度
      ratio = MaxHight / h; //計算寬度縮圖比例
      if (MaxHight < h)
      {
        ht = MaxHight;
        wt = Convert.ToInt32(ratio * w);

      }
      else
      {
        ht = Convert.ToInt32(baseImage.Height);
        wt = Convert.ToInt32(baseImage.Width);

      }
      string Newname = target + "\\" + suffix + name;

      System.Drawing.Bitmap img = new System.Drawing.Bitmap(wt, ht);
      System.Drawing.Graphics graphic = Graphics.FromImage(img);
      graphic.CompositingQuality = CompositingQuality.HighQuality;
      graphic.SmoothingMode = SmoothingMode.HighQuality;
      graphic.InterpolationMode = InterpolationMode.NearestNeighbor;
      graphic.DrawImage(baseImage, 0, 0, wt, ht);
      img.Save(Newname);

      img.Dispose();
      graphic.Dispose();
      baseImage.Dispose();
    }

    protected void Submit_btn_Click(object sender, EventArgs e)
    {
      string FileName = "";

      if (yacht_img.HasFile)
      {
        if (yacht_img.PostedFile.ContentType.IndexOf("image") == -1)
        {
          UploadStatusLabel.Text = "檔案型態錯誤!";
        }
        //取得副檔名
        string Extension = yacht_img.FileName.Split('.')[yacht_img.FileName.Split('.').Length - 1];
        //新檔案名稱
        //FileName = yacht_img.FileName;
        //FileName = String.Format("{0:yyyyMMddhhmm}.{1}", DateTime.Now, Extension);
        FileName = $"{DateTime.Now.ToString("yyyyMMddhhmmss")}.{Extension}";
        string savePath = Server.MapPath("~/Upload/images/");
        string saveResult = savePath + FileName;
        yacht_img.SaveAs(saveResult);
        GenerateThumbnailImage(FileName, yacht_img.PostedFile.InputStream, savePath, "S", 63);
      }
      else
      {
        FileName = Request.Cookies["yacht_img"].Value;
        UploadStatusLabel.Text = "You did not specify a file to upload.";
      }

      using (SqlConnection conn = new SqlConnection(config))
      {
        string strSQL = "UPDATE [YachtPhoto] SET yacht_id = @yacht_id, photo = @photo WHERE id = @id";
        using (SqlCommand cmd = new SqlCommand(strSQL, conn))
        {
          conn.Open();
          cmd.Parameters.AddWithValue("@id", Request.QueryString["id"]);
          cmd.Parameters.AddWithValue("@yacht_id", YachtModel.SelectedValue);
          cmd.Parameters.AddWithValue("@photo", FileName);
          cmd.ExecuteNonQuery();
          int page = Convert.ToInt32(Request.QueryString["page"] ?? "1");
          Response.Redirect($"YachtPhoto.aspx?page={page}");
        }
      }
    }

    protected void Cancel_btn_Click(object sender, EventArgs e)
    {
      int page = Convert.ToInt32(Request.QueryString["page"] ?? "1");
      Response.Redirect($"YachtPhoto.aspx?page={page}");
    }
  }
}