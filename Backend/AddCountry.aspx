<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Backstage.Master" AutoEventWireup="true" CodeBehind="AddCountry.aspx.cs" Inherits="Tayana.Backend.AddCountry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <div class="content-header">
        <div class="container-fluid">
            <div class="row justify-content-center">
                <div class="col-sm-6">
                    <ol class="breadcrumb float-sm-right">
                        <li class="breadcrumb-item"><a href="#">Home</a></li>
                        <li class="breadcrumb-item active">新增國家</li>
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
                            <h3 class="card-title">新增國家</h3>
                        </div>
                        <!-- form start -->
                        <div class="card-body">
                            <%--國家代號--%>
                            <%--<div class="form-group col-md-6">
                                    <label for="country_id">國家代號</label>
                                    <asp:TextBox ID="country_id" runat="server" class="form-control" placeholder="國家代號" ClientIDMode="Static" required="" TextMode="Number"></asp:TextBox>
                                </div>--%>
                            <%--國家名稱--%>
                            <div class="form-group">
                                <label for="country">國家名稱</label>
                                <asp:TextBox ID="country" runat="server" class="form-control" placeholder="國家" ClientIDMode="Static" required=""></asp:TextBox>
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
