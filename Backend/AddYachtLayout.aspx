<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Backstage.Master" AutoEventWireup="true" CodeBehind="AddYachtLayout.aspx.cs" Inherits="Tayana.Backend.AddYachtLayout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <div class="content-header">
        <div class="container-fluid">
            <div class="row justify-content-center">
                <div class="col-sm-10">
                    <ol class="breadcrumb float-sm-right">
                        <li class="breadcrumb-item"><a href="#">Home</a></li>
                        <li class="breadcrumb-item active">新增船型平面圖</li>
                    </ol>
                </div>
            </div>
        </div>
    </div>
    <section class="content">
        <div class="container-fluid">
            <div class="row justify-content-center">
                <div class="col-md-10">
                    <!-- general form elements -->
                    <div class="card card-lightblue">
                        <div class="card-header">
                            <h3 class="card-title">新增船型平面圖</h3>
                        </div>
                        <div class="card-body">
                            <%--內容--%>
                            <div class="form-group">
                                <label for="news_content">船型平面圖</label>
                                <asp:TextBox ID="yacht_layout" runat="server" class="ckeditor" TextMode="MultiLine" ClientIDMode="Static"></asp:TextBox>
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
