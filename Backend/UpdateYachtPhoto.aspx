<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Backstage.Master" AutoEventWireup="true" CodeBehind="UpdateYachtPhoto.aspx.cs" Inherits="Tayana.Backend.UpdateYachtPhoto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <div class="content-header">
        <div class="container-fluid">
            <div class="row justify-content-center">
                <div class="col-sm-8">
                    <ol class="breadcrumb float-sm-right">
                        <li class="breadcrumb-item"><a href="#">Home</a></li>
                        <li class="breadcrumb-item active">編輯船型相簿</li>
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
                            <h3 class="card-title">編輯船型相簿</h3>
                        </div>
                        <div class="card-body">
                            <%--船型--%>
                            <div class="form-group">
                                <label for="YachtModel">Model</label>
                                <asp:DropDownList ID="YachtModel" runat="server" class="form-control" ClientIDMode="Static"></asp:DropDownList>
                            </div>
                            <%--上傳圖片--%>
                            <div class="form-group">
                                <label for="yacht_img">圖片</label>
                                <div class="input-group mb-3">
                                    <div class="custom-file">
                                        <asp:FileUpload ID="yacht_img" class="custom-file-input" runat="server" ClientIDMode="Static" />
                                        <label class="custom-file-label" for="yacht_img">Choose file</label>
                                    </div>
                                </div>
                                <asp:Label ID="UploadStatusLabel" runat="server" ClientIDMode="Static" ForeColor="Red"></asp:Label>
                                <asp:Image ID="YachtImage" runat="server" class="yacht_img img-fluid img-thumbnail" ClientIDMode="Static" />
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
