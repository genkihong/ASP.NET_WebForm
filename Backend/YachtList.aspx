<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Backstage.Master" AutoEventWireup="true" CodeBehind="YachtList.aspx.cs" Inherits="Tayana.Backend.YachtList" %>

<%@ Register Src="~/Backend/BackstagePagination.ascx" TagPrefix="uc1" TagName="BackstagePagination" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <section class="content-header">
        <div class="container-fluid">
            <div class="row justify-content-center">
                <div class="col-md-12">
                    <ol class="breadcrumb float-sm-right">
                        <li class="breadcrumb-item"><a href="#">Home</a></li>
                        <li class="breadcrumb-item breadcrumb-title active">船型管理</li>
                    </ol>
                </div>
            </div>
        </div>
    </section>
    <section class="content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-12">
                    <%--船型管理--%>
                    <div class="card">
                        <div class="card-body pb-0">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="text-right mb-3">
                                        <asp:Button ID="AddYacht_btn" runat="server" Text="新增船型資料" class="btn btn-primary" OnClick="AddYacht_btn_Click" ClientIDMode="Static" />
                                    </div>
                                </div>
                            </div>
                            <div class="row flex-column align-items-center">
                                <asp:Repeater ID="YachtRepeater" runat="server" OnItemCommand="YachtRepeater_ItemCommand">
                                    <ItemTemplate>
                                        <div class="col-md-12">
                                            <div class="bg-light card">
                                                <div class="card-header border-bottom-0 d-flex">
                                                    <h2 class="mb-0"><%# Eval("model") %></h2>
                                                </div>
                                                <div class="card-body pt-0">
                                                    <div class="ribbon-wrapper <%# Eval("newest").ToString() == "0" ? "d-none" : "" %>">
                                                        <div class="ribbon bg-warning">
                                                            Newest
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-6 mb-3">
                                                            <button class="btn btn-block btn-secondary mb-3" type="button" data-toggle="collapse" data-target="#collapse<%# Eval("id") %>">
                                                                船型總覽
                                                            </button>
                                                            <div id="collapse<%# Eval("id") %>" class="collapse">
                                                                <h3>Overview</h3>
                                                                <%# Eval("overview") %>
                                                                <hr />
                                                                <h3>Dimensions</h3>
                                                                <%# Eval("dimensions") %>
                                                            </div>
                                                        </div>
                                                        <div class="col-6 mb-3">
                                                            <button class="btn btn-block btn-secondary mb-3" type="button" data-toggle="collapse" data-target="#collapse<%# Eval("id") %>">
                                                                船型平面圖
                                                            </button>
                                                            <div id="collapse<%# Eval("id") %>" class="collapse">
                                                                <h3>Layout</h3>
                                                                <%# Eval("layout") %>
                                                            </div>
                                                        </div>
                                                        <div class="col-6">
                                                            <button class="btn btn-block btn-secondary mb-3" type="button" data-toggle="collapse" data-target="#collapse<%# Eval("id") %>">
                                                                船型規格
                                                            </button>
                                                            <div id="collapse<%# Eval("id") %>" class="collapse">
                                                                <h3>Specification</h3>
                                                                <%# Eval("specification") %>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="card-footer text-right">
                                                    <%--<div class="mr-auto">
                                                <asp:LinkButton ID="NewestBtn" runat="server" CssClass="btn btn-sm btn-outline-secondary"
                                                    CommandArgument='<%# Eval( "id") %>' CommandName="Newest" ClientIDMode="Static"
                                                    OnClientClick="javascript:if(!window.confirm('確定要變更?')) window.event.returnValue = false;">
                                                    <span class="ml-1">最新船型</span>
                                                </asp:LinkButton>
                                            </div>--%>
                                                    <asp:LinkButton ID="EditBtn" runat="server" CssClass="btn btn-sm btn-outline-primary"
                                                        CommandArgument='<%# Eval( "id") %>' CommandName="Edit" ClientIDMode="Static">
                                                        <i class="fas fa-pencil-alt"></i>
                                                        <span class="ml-1">編輯</span>
                                                    </asp:LinkButton>
                                                    <asp:LinkButton ID="DelBtn" runat="server" CssClass="btn btn-sm btn-outline-danger"
                                                        CommandArgument='<%# Eval( "id") %>' CommandName="Delete" ClientIDMode="Static"
                                                        OnClientClick="javascript:if(!window.confirm('確定要刪除?')) window.event.returnValue = false;">
                                                        <i class="far fa-trash-alt"></i>
                                                        <span class="ml-1">刪除</span>
                                                    </asp:LinkButton>
                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                        <div class="card-footer">
                            <nav aria-label="Contacts Page Navigation">
                                <uc1:BackstagePagination runat="server" ID="BackstagePagination" />
                            </nav>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
