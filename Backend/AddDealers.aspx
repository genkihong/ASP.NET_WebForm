<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Backstage.Master" AutoEventWireup="true" CodeBehind="AddDealers.aspx.cs" Inherits="Tayana.Backend.AddDealers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <div class="content-header">
        <div class="container-fluid">
            <div class="row justify-content-center">
                <div class="col-sm-6">
                    <ol class="breadcrumb float-sm-right">
                        <li class="breadcrumb-item"><a href="#">Home</a></li>
                        <li class="breadcrumb-item active">新增經銷商</li>
                    </ol>
                </div>
            </div>
        </div>
    </div>
    <section class="content">
        <div class="container-fluid">
            <div class="row justify-content-center">
                <div class="col-md-6">
                    <!-- general form elements -->
                    <div class="card card-lightblue">
                        <div class="card-header">
                            <h3 class="card-title">新增經銷商</h3>
                        </div>
                        <div class="card-body">
                            <%--上傳圖片--%>
                            <div class="form-group">
                                <%--<div class="media-body align-self-end mr-3">--%>
                                    <label for="dealers_img">圖片</label>
                                    <div class="input-group mb-2">
                                        <div class="custom-file">
                                            <asp:FileUpload ID="dealers_img" class="custom-file-input" runat="server" ClientIDMode="Static" />
                                            <label class="custom-file-label" for="dealers_img">Choose file</label>
                                        </div>
                                    </div>
                                    <asp:Label ID="UploadStatusLabel" runat="server" ClientIDMode="Static" ForeColor="Red"></asp:Label>
                                <%--</div>--%>
                                <img src="#" alt="" class="dealers_img img-fluid img-thumbnail" />
                            </div>
                            <div class="form-row">
                                <%--國家名稱--%>
                                <div class="form-group col-md-6">
                                    <label for="countrySelect">國家名稱</label>
                                    <asp:DropDownList ID="countrySelect" runat="server" class="form-control" ClientIDMode="Static"></asp:DropDownList>
                                    <%--<asp:DropDownList ID="DropDownList1" runat="server" class="form-control" ClientIDMode="Static" required=""                                       
                                        AppendDataBoundItems="True" AutoPostBack="True"
                                        OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged1">
                                        <asp:ListItem Text="請選擇" />                                     
                                    </asp:DropDownList>--%>
                                </div>
                                <%--地區--%>
                                <div class="form-group col-md-6">
                                    <label for="modifyRegionSelect">地區名稱</label>
                                    <select id="modifyRegionSelect" name="region" class="form-control" required=""></select>
                                    <%--<asp:DropDownList ID="DropDownList2" runat="server" class="form-control"
                                         AppendDataBoundItems="True" ClientIDMode="Static" required="">
                                        <asp:ListItem Text="請選擇" />  
                                    </asp:DropDownList>--%>
                                </div>
                            </div>
                            <%--地址--%>
                            <div class="form-group">
                                <label for="dealer_address">地址</label>
                                <asp:TextBox ID="dealer_address" runat="server" class="form-control" placeholder="地址" ClientIDMode="Static" required=""></asp:TextBox>
                            </div>
                            <div class="form-row">
                                <%--姓名--%>
                                <div class="form-group col-md-6">
                                    <label for="dealer_name">姓名</label>
                                    <asp:TextBox ID="dealer_name" runat="server" class="form-control" placeholder="姓名" ClientIDMode="Static" required=""></asp:TextBox>
                                </div>
                                <%--職稱--%>
                                <div class="form-group col-md-6">
                                    <label for="dealer_title">職稱</label>
                                    <asp:TextBox ID="dealer_title" runat="server" class="form-control" placeholder="職稱" ClientIDMode="Static" required=""></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-row">
                                <%--電話--%>
                                <div class="form-group col-md-6">
                                    <label for="dealer_tel">電話</label>
                                    <asp:TextBox ID="dealer_tel" runat="server" class="form-control" placeholder="電話" ClientIDMode="Static" required=""></asp:TextBox>
                                </div>
                                <%--傳真--%>
                                <div class="form-group col-md-6">
                                    <label for="dealer_fax">傳真</label>
                                    <asp:TextBox ID="dealer_fax" runat="server" class="form-control" placeholder="傳真" ClientIDMode="Static" required=""></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-row">
                                <%--Email--%>
                                <div class="form-group col-md-6">
                                    <label for="dealer_email">Email</label>
                                    <asp:TextBox ID="dealer_email" runat="server" class="form-control" placeholder="Email" ClientIDMode="Static" TextMode="Email" required=""></asp:TextBox>
                                </div>
                                <%--網址--%>
                                <div class="form-group col-md-6">
                                    <label for="dealer_website">網址</label>
                                    <asp:TextBox ID="dealer_website" runat="server" class="form-control" placeholder="網址" ClientIDMode="Static" required=""></asp:TextBox>
                                </div>
                            </div>

                            <%--地區代理商--%>
                            <%--<div class="form-group">
                                <label for="dealer">地區代理商</label>
                                <asp:TextBox ID="dealer" runat="server" class="ckeditor" TextMode="MultiLine" ClientIDMode="Static"></asp:TextBox>
                            </div>--%>
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
