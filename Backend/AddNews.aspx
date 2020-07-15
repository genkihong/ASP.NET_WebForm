<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Backstage.Master" AutoEventWireup="true" CodeBehind="AddNews.aspx.cs" Inherits="Tayana.Backend.AddNews" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <div class="content-header">
        <div class="container-fluid">
            <div class="row justify-content-center">
                <div class="col-sm-8">
                    <ol class="breadcrumb float-sm-right">
                        <li class="breadcrumb-item"><a href="#">Home</a></li>
                        <li class="breadcrumb-item active">新增新聞</li>
                    </ol>
                </div>
            </div>
        </div>
    </div>
    <section class="content">
        <div class="container-fluid">
            <div class="row justify-content-center">
                <div class="col-md-8">
                    <div class="card card-lightblue">
                        <div class="card-header">
                            <h3 class="card-title">新增新聞</h3>
                        </div>
                        <div class="card-body">
                            <%--置頂--%>
                            <label for="news_top">是否置頂</label>
                            <div class="form-row">
                                <div class="form-group col-md-2">
                                    <div class="custom-control custom-radio">
                                        <input class="custom-control-input" type="radio" id="Radio1" name="customRadio" value="1" runat="server" clientidmode="Static" />
                                        <label for="Radio1" class="custom-control-label">是</label>
                                    </div>
                                </div>
                                <div class="form-group col-md-2">
                                    <div class="custom-control custom-radio">
                                        <input class="custom-control-input" type="radio" id="Radio2" name="customRadio" value="0" runat="server" clientidmode="Static" />
                                        <label for="Radio2" class="custom-control-label">否</label>
                                    </div>
                                </div>
                            </div>
                            <%--上傳縮圖--%>
                            <div class="form-group media">
                                <div class="media-body align-self-end mr-3">
                                    <label for="news_img">圖片</label>
                                    <div class="input-group">
                                        <div class="custom-file">
                                            <asp:FileUpload ID="news_img" class="custom-file-input" runat="server" ClientIDMode="Static" required="" />
                                            <label class="custom-file-label" for="news_img">Choose file</label>
                                        </div>
                                    </div>
                                    <asp:Label ID="UploadStatusLabel" runat="server" ClientIDMode="Static" ForeColor="Red"></asp:Label>
                                </div>
                                <img src="#" alt="" class="news_img img-fluid img-thumbnail" />
                            </div>
                            <%--日期--%>
                           <%--<div class="form-group">
                                <label for="news_date">日期</label>
                                <asp:TextBox ID="news_date" runat="server" class="form-control" placeholder="日期" ClientIDMode="Static" TextMode="Date" required=""></asp:TextBox>
                            </div>--%>
                            <%--標題--%>
                            <div class="form-group">
                                <label for="news_title">標題</label>
                                <asp:TextBox ID="news_title" runat="server" class="form-control" placeholder="標題" ClientIDMode="Static" required=""></asp:TextBox>
                            </div>
                            <%--摘要--%>
                            <div class="form-group">
                                <label for="news_summary">摘要</label>
                                <asp:TextBox ID="news_summary" runat="server" class="form-control" placeholder="摘要" ClientIDMode="Static" TextMode="MultiLine" required=""></asp:TextBox>
                            </div>
                            <%--內容--%>
                            <div class="form-group">
                                <label for="news_content">內容</label>
                                <asp:TextBox ID="news_content" runat="server" class="ckeditor" TextMode="MultiLine" ClientIDMode="Static"></asp:TextBox>
                            </div>
                        </div>
                        <div class="card-footer text-right">
                            <asp:Button ID="Cancel_btn" runat="server" Text="取消" class="btn btn-outline-secondary" ClientIDMode="Static" OnClick="Cancel_btn_Click" UseSubmitBehavior="False" />
                            <asp:Button ID="Submit_btn" runat="server" Text="確認" class="btn btn-primary" OnClick="Submit_btn_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
