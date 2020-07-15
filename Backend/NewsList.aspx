<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Backstage.Master" AutoEventWireup="true" CodeBehind="NewsList.aspx.cs" Inherits="Tayana.Backend.NewsList" %>

<%@ Register Src="~/Backend/BackstagePagination.ascx" TagPrefix="uc1" TagName="BackstagePagination" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <section class="content-header">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-12">
                    <div class="row align-items-end">
                        <div class="col-md-3">
                            <label for="SearchText">新聞標題</label>
                            <div class="input-group">
                                <asp:TextBox ID="SearchNews" runat="server" class="form-control" placeholder="請輸入新聞標題" TextMode="Search" ClientIDMode="Static" />
                                <%--<div class="input-group-append">
                                    <asp:LinkButton ID="LinkButton2" runat="server" class="btn btn-primary" ClientIDMode="Static" OnClick="Search_btn_Click">
                                        <i class="fas fa-search"></i>
                                    </asp:LinkButton>
                                </div>--%>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <label>選擇日期</label>
                            <div class="d-flex">
                                <span class="mr-1">From</span>
                                <asp:TextBox ID="SearchdDate1" runat="server" class="form-control" TextMode="Date" ClientIDMode="Static" />
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="d-flex">
                                <span class="mr-1">To</span>
                                <asp:TextBox ID="SearchdDate2" runat="server" class="form-control" TextMode="Date" ClientIDMode="Static" />
                            </div>
                        </div>
                        <div class="col-md-3">
                            <asp:LinkButton ID="Search_btn" runat="server" class="btn btn-primary mr-2" ClientIDMode="Static" OnClick="Search_btn_Click">
                                <i class="fas fa-search"></i>
                                <span>Search</span>
                            </asp:LinkButton>
                            <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-outline-secondary" ClientIDMode="Static" OnClick="Reset_btn_Click">
                            <%--<i class="fas fa-sync-alt"></i>--%>
                                <span>重新搜尋</span> 
                            </asp:LinkButton>
                        </div>
                    </div>
                    <%--<ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#">Home</a></li>
                        <li class="breadcrumb-item active">新聞列表</li>
                        <li class="breadcrumb-item">
                            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                        </li>
                        <li class="breadcrumb-item">
                            <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                        </li>
                    </ol>--%>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12 d-flex justify-content-end">
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#">Home</a></li>
                        <li class="breadcrumb-item active">新聞列表</li>
                        <li class="breadcrumb-item">
                            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                        </li>
                        <li class="breadcrumb-item">
                            <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                        </li>
                    </ol>
                </div>
            </div>
        </div>
    </section>
    <section class="content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-12">
                    <%--新聞列表--%>
                    <div class="card">
                        <div class="card-body pb-0">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="text-right mb-3">
                                        <asp:Button ID="AddNews_btn" runat="server" Text="新增新聞" class="btn btn-primary" OnClick="AddNews_btn_Click" ClientIDMode="Static" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <%--查無資料--%>
                                <div id="Result" class="col d-flex justify-content-center align-items-center" runat="server" visible="False" style="height: 60vh">
                                    <h2 class="text-bold">
                                        <asp:Literal ID="SearchResult" runat="server"></asp:Literal>
                                    </h2>
                                </div>
                                <asp:Repeater ID="NewsRepeater" runat="server" OnItemCommand="NewsRepeater_ItemCommand">
                                    <ItemTemplate>
                                        <div class="col-md-4">
                                            <div class="card bg-light">
                                                <div class="card-header border-bottom-0 d-flex">
                                                    <h4 class="mb-0"><%# Eval("news_title") %></h4>
                                                </div>
                                                <div class="card-body pt-0">
                                                    <div class="ribbon-wrapper ribbon-lg <%# Eval("news_top").ToString() == "0" ? "d-none" : "" %>">
                                                        <div class="ribbon bg-danger">
                                                            Top News
                                                        </div>
                                                    </div>
                                                    <div class="row no-gutters">
                                                        <div class="col-5">
                                                            <img src="../Upload/images/<%# Eval("news_img") %>" alt="" class="img-fluid img-thumbnail">
                                                        </div>
                                                        <div class="col-7">
                                                            <ul class="ml-4 mb-0 fa-ul">
                                                                <%--<li class="mb-1">
                                                                    <span class="fa-li">
                                                                        <i class="fab fa-apple"></i>
                                                                    </span>
                                                                    <span>標題: <%# Eval("news_title") %></span>
                                                                </li>--%>
                                                                <li class="mb-1">
                                                                    <span class="fa-li">
                                                                        <i class="fas fa-calendar-alt"></i>
                                                                    </span>
                                                                    <span>日期: <%# Eval("news_date") %></span>
                                                                </li>
                                                                <li class="mb-1">
                                                                    <span class="fa-li">
                                                                        <i class="fas fa-file-alt"></i>
                                                                    </span>
                                                                    <span>摘要: <%# Eval("news_summary") %></span>
                                                                </li>
                                                                <li class="mb-1">
                                                                    <span class="fa-li">
                                                                        <i class="fas fa-book"></i>
                                                                    </span>
                                                                    <a href="#" data-toggle="modal" data-target="#modal-lg-<%# Eval( "id") %>">內容</a>
                                                                </li>
                                                            </ul>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="card-footer d-flex">
                                                    <div class="mr-auto">
                                                        <asp:LinkButton ID="TopBtn" runat="server" CssClass="btn btn-sm btn-outline-secondary"
                                                            CommandArgument='<%# Eval( "id") %>' CommandName="Top" ClientIDMode="Static"
                                                            OnClientClick="javascript:if(!window.confirm('確定要變更?')) window.event.returnValue = false;">
                                                    <span class="ml-1">切換置頂</span>
                                                        </asp:LinkButton>
                                                    </div>
                                                    <div class="text-right">
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
                                        </div>

                                        <%--Modal--%>
                                        <div class="modal fade" id="modal-lg-<%# Eval( "id") %>">
                                            <div class="modal-dialog modal-lg">
                                                <div class="modal-content">
                                                    <div class="modal-header">
                                                        <h4 class="modal-title"><%# Eval("news_title") %></h4>
                                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                            <span aria-hidden="true">&times;</span>
                                                        </button>
                                                    </div>
                                                    <div class="modal-body">
                                                        <%# Eval("news_content") %>
                                                    </div>
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

    <%--<section class="content">
        <div class="container-fluid">
            <div class="row justify-content-center">
                <div class="col-md-10 col-lg-12">
                     <div class="text-right mb-3">                       
                        <asp:Button ID="AddNews_btn" runat="server" Text="新增新聞" class="btn btn-primary" OnClick="AddNews_btn_Click" />
                    </div>
                    <asp:GridView ID="GridView1" CssClass="text-center w-100" runat="server" AutoGenerateColumns="False" DataKeyNames="id" Height="80px" ClientIDMode="Static" CellPadding="3" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                        <Columns>
                            <asp:TemplateField HeaderText="編號">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Container.DataItemIndex + 1 %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="news_img" HeaderText="圖片" SortExpression="news_img" />
                            <asp:BoundField DataField="news_date" HeaderText="日期" SortExpression="news_date" />
                            <asp:BoundField DataField="news_title" HeaderText="標題" SortExpression="news_title" />
                            <asp:BoundField DataField="news_summary" HeaderText="摘要" SortExpression="news_summary" />
                            <asp:BoundField DataField="news_content" HeaderText="內容" SortExpression="news_content" /><asp:TemplateField HeaderText="編輯" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:HyperLink runat="server" NavigateUrl='<%# $"UpdateNews.aspx?id={Eval("id")}" %>' Text="編輯" CssClass="btn btn-sm btn-outline-primary" ClientIDMode="Static">
                                    </asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="刪除" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="DelLinkButton" runat="server" CausesValidation="False" CommandName="Delete" Text="刪除" CssClass="btn btn-sm btn-outline-danger"
                                        OnClientClick="javascript:if(!window.confirm('確定要刪除?')) window.event.returnValue = false;"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle ForeColor="#000066" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                    </asp:GridView>                    
                </div>
            </div>
        </div>
    </section>--%>
</asp:Content>
