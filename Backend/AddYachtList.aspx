<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Backstage.Master" AutoEventWireup="true" CodeBehind="AddYachtList.aspx.cs" Inherits="Tayana.Backend.AddYachtList" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <div class="content-header">
        <div class="container-fluid">
            <div class="row justify-content-center">
                <div class="col-md-10">
                    <ol class="breadcrumb float-sm-right">
                        <li class="breadcrumb-item"><a href="#">Home</a></li>
                        <li class="breadcrumb-item active">新增船型總覽</li>
                    </ol>
                </div>
            </div>
        </div>
    </div>
    <section class="content">
        <div class="container-fluid">
            <div class="row justify-content-center">
                <div class="col-md-10">
                    <div class="card card-lightblue card-tabs">
                        <div class="card-header p-0 pt-1">
                            <ul class="nav nav-tabs" id="custom-tabs-one-tab" role="tablist">
                                <li class="nav-item">
                                    <a class="nav-link active" id="yacht_model_tab" data-toggle="pill" href="#yacht_model">船型</a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" id="yacht_overview_tab" data-toggle="pill" href="#yacht_overview">船型總覽</a>
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
                                <%--船型--%>
                                <div class="tab-pane fade show active" id="yacht_model">
                                    <div class="form-group">
                                        <label for="YachtModel">Model</label>
                                        <asp:DropDownList ID="YachtModel" runat="server" class="form-control" ClientIDMode="Static"></asp:DropDownList>
                                    </div>
                                    <%--最新船型--%>
                                    <%--<label for="news_top">最新船型</label>
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
                                    </div>--%>
                                </div>
                                <%--船型總覽--%>
                                <div class="tab-pane fade" id="yacht_overview">
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
                                    <%--<div class="container">
                                        <div class="row no-gutters">
                                            <div class="col-md-8 align-self-end">
                                                <div class="p-3">
                                                    <label for="layout_img">Layout</label>
                                                    <div class="input-group">
                                                        <div class="custom-file">
                                                            <asp:FileUpload ID="layout_img" class="custom-file-input" runat="server" ClientIDMode="Static" required="" />
                                                            <label class="custom-file-label" for="layout_img">Choose file</label>
                                                        </div>
                                                    </div>
                                                    <asp:Label ID="UploadStatusLabel" runat="server" ClientIDMode="Static" ForeColor="Red"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="p-3">
                                                    <asp:Image ID="LayoutImg" runat="server" class="card-img img-thumbnail" ClientIDMode="Static" />
                                                </div>
                                            </div>
                                        </div>
                                        <asp:Button ID="UploadBtn" runat="server" Text="上傳檔案" OnClick="UploadBtn_Click" />--%>
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
        </div>
    </section>
</asp:Content>
