<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Backstage.Master" AutoEventWireup="true" CodeBehind="UpdateYachtList.aspx.cs" Inherits="Tayana.Backend.UpdateYachtList" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <div class="content-header">
        <div class="container-fluid">
            <div class="row justify-content-center">
                <div class="col-md-6 col-lg-10  d-flex align-items-center">
                    <%--船型--%>
                    <h2 class="mr-auto mb-0">
                        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                    </h2>
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#">Home</a></li>
                        <li class="breadcrumb-item active">編輯船型總覽</li>
                    </ol>
                </div>
            </div>
        </div>
    </div>
    <section class="content">
        <div class="container-fluid">
            <div class="row justify-content-center">
                <div class="col-md-6 col-lg-10">
                    <div class="card card-lightblue card-tabs">
                        <div class="card-header p-0 pt-1">
                            <ul class="nav nav-tabs" id="custom-tabs-one-tab" role="tablist">
                                <li class="nav-item">
                                    <a class="nav-link active" id="yacht_overview_tab" data-toggle="pill" href="#yacht_overview">船型總覽</a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" id="yacht_layout_tab" data-toggle="pill" href="#yacht_layout">船型平面圖</a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" id="yacht_specification_tab" data-toggle="pill" href="#yacht_specification">船型規格</a>
                                </li>
                            </ul>
                        </div>
                        <div class="card-body">
                            <div class="tab-content" id="custom-tabs-one-tabContent">
                                <%--船型總覽--%>
                                <div class="tab-pane fade show active" id="yacht_overview">
                                    <div class="form-group">
                                        <label for="YachtOverview">Overview</label>
                                        <asp:TextBox ID="YachtOverview" runat="server" class="ckeditor" TextMode="MultiLine" ClientIDMode="Static"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label for="YachtDimensions">Dimensions</label>
                                        <asp:TextBox ID="YachtDimensions" runat="server" class="ckeditor" TextMode="MultiLine" ClientIDMode="Static"></asp:TextBox>
                                    </div>
                                </div>
                                <%--船型平面圖--%>
                                <div class="tab-pane fade" id="yacht_layout">
                                    <div class="form-group">
                                        <label for="YachtLayout">Layout</label>
                                        <asp:TextBox ID="YachtLayout" runat="server" class="ckeditor" TextMode="MultiLine" ClientIDMode="Static"></asp:TextBox>
                                    </div>
                                    <%--<div class="form-group media">
                                        <div class="media-body align-self-end mr-3">
                                            <label for="YachtLayout">YachtLayout</label>
                                            <div class="input-group">
                                                <div class="custom-file">
                                                    <asp:FileUpload ID="YachtLayout" class="custom-file-input" runat="server" ClientIDMode="Static" required="" />
                                                    <label class="custom-file-label" for="YachtLayout">Choose file</label>
                                                </div>
                                            </div>
                                            <asp:Label ID="UploadStatusLabel" runat="server" ClientIDMode="Static" ForeColor="Red"></asp:Label>
                                        </div>
                                        <asp:Image ID="LayoutImg" runat="server" class="img-fluid img-thumbnail" ClientIDMode="Static" />
                                    </div>--%>
                                </div>
                                <%--船型規格--%>
                                <div class="tab-pane fade" id="yacht_specification">
                                    <div class="form-group">
                                        <label for="YachtSpecification">Specification</label>
                                        <asp:TextBox ID="YachtSpecification" runat="server" class="ckeditor" TextMode="MultiLine" ClientIDMode="Static"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="card-footer text-right">
                            <asp:Button ID="Cancel_btn" runat="server" Text="取消" class="btn btn-outline-secondary" ClientIDMode="Static" UseSubmitBehavior="False" OnClick="Cancel_btn_Click" />
                            <asp:Button ID="Submit_btn" runat="server" Text="確認" class="btn btn-primary" OnClick="Submit_btn_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
