<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Backstage.Master" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="Tayana.Backend.AddUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <div class="content-header">
        <div class="container-fluid">
            <div class="row justify-content-center">
                <%--<div class="col-sm-6">
                    <h1 class="m-0 text-dark">新增會員</h1>
                </div>--%>
                <div class="col-sm-6">
                    <ol class="breadcrumb float-sm-right">
                        <li class="breadcrumb-item"><a href="#">Home</a></li>
                        <li class="breadcrumb-item active">新增會員</li>
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
                            <h3 class="card-title">新增會員</h3>
                        </div>
                        <!-- form start -->
                        <div class="card-body">
                            <%--上傳圖片--%>
                            <div class="form-group media">
                                <div class="media-body align-self-end mr-3">
                                    <label for="photo">圖片</label>
                                    <div class="input-group">
                                        <div class="custom-file">
                                            <asp:FileUpload ID="user_img" class="custom-file-input" runat="server" ClientIDMode="Static" />
                                            <label class="custom-file-label" for="FileUpload">Choose file</label>
                                        </div>
                                    </div>
                                    <asp:Label ID="UploadStatusLabel" runat="server" Text=""></asp:Label>
                                </div>
                                <img src="#" alt="" class="user_img img-fluid img-thumbnail" />
                            </div>
                            <%--帳號--%>
                            <div class="form-group">
                                <label for="name">User name</label>
                                <div class="input-group">
                                    <asp:TextBox ID="name" runat="server" class="form-control" placeholder="Enter your user name" ClientIDMode="Static" required=""></asp:TextBox>
                                    <div class="input-group-append">
                                        <input id="checkAccountBtn" type="button" class="btn btn-sm btn-outline-secondary" value="檢查帳號" />
                                    </div>
                                </div>
                                <asp:Label ID="accountMessage" runat="server" Text="" ForeColor="Red" ClientIDMode="Static" />
                            </div>
                            <%--email--%>
                            <div class="form-group">
                                <label for="email">Email address</label>
                                <asp:TextBox ID="email" runat="server" TextMode="Email" class="form-control" placeholder="Enter email" ClientIDMode="Static" required=""></asp:TextBox>
                                <asp:Label ID="emailMessage" runat="server" Text="" ForeColor="Red" ClientIDMode="Static" />
                            </div>
                            <%--密碼--%>
                            <div class="form-group">
                                <label for="password">Password</label>
                                <asp:TextBox ID="password" runat="server" TextMode="Password" class="form-control" placeholder="Enter password" ClientIDMode="Static" required=""></asp:TextBox>
                            </div>
                            <label>權限</label>
                            <div class="form-row">
                                <%--<asp:RadioButtonList ID="RadioButtonList1" runat="server">
                                    <asp:ListItem Value="1" Text="一般會員"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="管理員"></asp:ListItem>
                                </asp:RadioButtonList>--%>
                                <div class="form-group col-md-3">
                                    <div class="custom-control custom-radio">
                                        <input class="custom-control-input" type="radio" id="Radio1" name="customRadio" value="2" runat="server" clientidmode="Static" checked />
                                        <label for="Radio1" class="custom-control-label">一般會員</label>
                                    </div>
                                </div>
                                <div class="form-group col-md-3">
                                    <div class="custom-control custom-radio">
                                        <input class="custom-control-input" type="radio" id="Radio2" name="customRadio" value="1" runat="server" clientidmode="Static" />
                                        <label for="Radio2" class="custom-control-label">管理員</label>
                                    </div>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="form-group col-md-2">
                                    <%-- <asp:CheckBoxList ID="CheckBoxList" runat="server">
                                        <asp:ListItem Value="1" Text="遊艇管理"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="新聞管理"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="經銷商管理"></asp:ListItem>
                                    </asp:CheckBoxList>--%>
                                    <div class="custom-control custom-checkbox mb-2">
                                        <input class="custom-control-input" type="checkbox" id="AllCheckBox" value="">
                                        <label for="AllCheckBox" class="custom-control-label">全選</label>
                                    </div>
                                </div>
                                <div class="form-group col-md-3">
                                    <div class="custom-control custom-checkbox mb-2">
                                        <input class="custom-control-input uniChecked" type="checkbox" name="checkbox1" id="CheckBox1" value="01">
                                        <label for="CheckBox1" class="custom-control-label">遊艇管理</label>
                                    </div>
                                </div>
                                <div class="form-group col-md-3">
                                    <div class="custom-control custom-checkbox mb-2">
                                        <input class="custom-control-input uniChecked" type="checkbox" name="checkbox2" id="CheckBox2" value="02">
                                        <label for="CheckBox2" class="custom-control-label">新聞管理</label>
                                    </div>
                                </div>
                                <div class="form-group col-md-3">
                                    <div class="custom-control custom-checkbox">
                                        <input class="custom-control-input uniChecked" type="checkbox" name="checkbox3" id="CheckBox3" value="03">
                                        <label for="CheckBox3" class="custom-control-label">經銷商管理</label>
                                    </div>
                                    <input type="hidden" id="Permission" class="permission" name="hidden" value="" runat="server" clientidmode="Static" />
                                </div>
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
