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
  public partial class AddYachtList : System.Web.UI.Page
  {
    string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        BindYachtModel();
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

    protected void Submit_btn_Click(object sender, EventArgs e)
    {
      //string radioValue = Radio1.Checked ? Radio1.Value : Radio2.Value;
      using (SqlConnection conn = new SqlConnection(config))
      {
        string strSQL = "INSERT INTO [YachtDetail] (yacht_id, overview, dimensions, layout, specification) " +
                        "VALUES (@id, @overview, @dimensions, @layout, @specification)";
        SqlCommand cmd = new SqlCommand(strSQL, conn);
        conn.Open();
        cmd.Parameters.AddWithValue("@id", YachtModel.SelectedValue);
        //cmd.Parameters.AddWithValue("@newest", radioValue);
        cmd.Parameters.AddWithValue("@overview", YachtOverview.Text);
        cmd.Parameters.AddWithValue("@dimensions", YachtDimensions.Text);
        cmd.Parameters.AddWithValue("@layout", YachtLayout.Text);
        cmd.Parameters.AddWithValue("@specification", YachtSpecification.Text);
        cmd.ExecuteNonQuery();
        Response.Redirect("YachtList.aspx");
      }
    }

    protected void Cancel_btn_Click(object sender, EventArgs e)
    {
      int page = Convert.ToInt32(Request.QueryString["page"] ?? "1");
      Response.Redirect($"YachtList.aspx?page={page}");
    }

    //private string UploadPhoto()
    //{
    //  string fileName = "";
    //  if (layout_img.HasFile)
    //  {
    //    if (layout_img.PostedFile.ContentType.IndexOf("image") == -1)
    //    {
    //      UploadStatusLabel.Text = "檔案型態錯誤!";
    //    }
    //    //取得副檔名
    //    string Extension = layout_img.FileName.Split('.')[layout_img.FileName.Split('.').Length - 1];
    //    //新檔案名稱
    //    //fileName = String.Format("{0:yyyyMMddhhmm}.{1}", DateTime.Now, Extension);
    //    fileName = $"{DateTime.Now.ToString("yyyyMMddhhmmss")}.{Extension}";
    //    string savePath = Server.MapPath("~/Upload/images/");
    //    string saveResult = savePath + fileName;
    //    layout_img.SaveAs(saveResult);
    //  }
    //  else
    //  {
    //    UploadStatusLabel.Text = "You did not specify a file to upload.";
    //  }
    //  return fileName;
    //}

    //protected void UploadBtn_Click(object sender, EventArgs e)
    //{
    //  string fileName = UploadPhoto();
    //  using (SqlConnection conn = new SqlConnection(config))
    //  {
    //    string strSQL = "INSERT INTO [YachtLayout] (yacht_id, layout) VALUES (@id, @layout)";
    //    SqlCommand cmd = new SqlCommand(strSQL, conn);
    //    conn.Open();
    //    cmd.Parameters.AddWithValue("@id", yachtSelect.SelectedValue);
    //    cmd.Parameters.AddWithValue("@layout", fileName);
    //    cmd.ExecuteNonQuery();
    //  }
    //}
  }
}