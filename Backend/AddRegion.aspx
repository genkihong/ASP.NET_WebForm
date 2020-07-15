<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Backstage.Master" AutoEventWireup="true" CodeBehind="AddRegion.aspx.cs" Inherits="Tayana.Backend.AddRegion" %>

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
                            <h3 class="card-title">新增地區</h3>
                        </div>
                        <div class="card-body">
                            <div class="form-row">
                                <%--國家名稱--%>
                                <div class="form-group col">
                                    <label for="DropDownList1">國家名稱</label>
                                    <asp:DropDownList ID="DropDownList1" runat="server" class="form-control" ClientIDMode="Static" required=""
                                        AppendDataBoundItems="True" AutoPostBack="True">
                                        <asp:ListItem Text="請選擇" />
                                    </asp:DropDownList>
                                </div> 
                                <%--地區名稱--%>
                                <div class="form-group col">
                                    <label for="region">地區名稱</label>
                                    <asp:TextBox ID="region" runat="server" class="form-control" placeholder="地區名稱" ClientIDMode="Static" required=""></asp:TextBox>
                                </div>
                                <%--地區代號--%>
                               <%-- <div class="form-group col">
                                    <label for="region_id">地區代號</label>
                                    <asp:TextBox ID="region_id" runat="server" class="form-control" placeholder="地區代號" ClientIDMode="Static" required="" TextMode="Number"></asp:TextBox>
                                </div>--%>
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
