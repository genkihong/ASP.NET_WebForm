<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Backstage.Master" AutoEventWireup="true" CodeBehind="DealersList.aspx.cs" Inherits="Tayana.Backend.DealersList" %>

<%@ Register Src="~/Backend/BackstagePagination.ascx" TagPrefix="uc1" TagName="BackstagePagination" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <section class="content-header">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-12">
                    <div class="row align-items-end">
                        <%--國家名稱--%>
                        <div class="col-md-3">
                            <label for="countrySelect">國家名稱</label>
                            <asp:DropDownList ID="countrySelect" runat="server" class="form-control" ClientIDMode="Static"></asp:DropDownList>
                            <input type="hidden" id="countryValue" value="" />
                        </div>
                        <%--地區--%>
                        <div class="col-md-3">
                            <label for="regionSelect">地區名稱</label>
                            <select id="regionSelect" name="region" class="form-control"></select>
                            <input type="hidden" id="regionValue" value="" runat="server" clientidmode="Static" />
                        </div>
                        <div class="col-md-3">
                            <asp:LinkButton ID="Search_btn" runat="server" class="btn btn-primary mr-2" ClientIDMode="Static" OnClick="Search_btn_Click">
                                <i class="fas fa-search"></i>
                                <span>Search</span>
                            </asp:LinkButton>
                            <asp:LinkButton ID="Reset_btn" runat="server" class="btn btn-outline-secondary" ClientIDMode="Static" OnClick="Reset_btn_Click">
                                <%--<i class="fas fa-sync-alt"></i>--%>
                                <span>重新搜尋</span> 
                            </asp:LinkButton>
                        </div>
                    </div>
                    
                </div>
            </div>
            <div class="row">
                <div class="col-md-12 d-flex justify-content-end">
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#">Home</a></li>
                        <li class="breadcrumb-item active">經銷商列表</li>
                        <%--<li class="breadcrumb-item">
                            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                        </li>
                        <li class="breadcrumb-item">
                            <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                        </li>--%>
                    </ol>
                </div>
            </div>
        </div>
    </section>
    <section class="content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-12">
                    <%--廠商列表--%>
                    <div class="card">
                        <div class="card-body pb-0">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="text-right mb-3">
                                        <asp:Button ID="AddDealer_btn" runat="server" Text="新增經銷商" class="btn btn-primary" OnClick="AddDealer_btn_Click" ClientIDMode="Static" />
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
                                <asp:Repeater ID="DealersRepeater" runat="server" OnItemCommand="DealersRepeater_ItemCommand">
                                    <ItemTemplate>
                                        <div class="col-md-4">
                                            <div class="card bg-light">
                                                <div class="card-header border-bottom-0">
                                                    <h5><%# Eval("country") %></h5>
                                                    <h6><%# Eval("region") %></h6>
                                                </div>
                                                <div class="card-body pt-0">
                                                    <div class="row">
                                                        <div class="col-7">
                                                            <h2 class="lead">
                                                                <b><%# Eval("dealer_name") %></b>
                                                            </h2>
                                                            <p>
                                                                <b>職稱: </b><%# Eval("dealer_title") %>
                                                            </p>
                                                            <ul class="ml-4 mb-0 fa-ul">
                                                                <li class="mb-1">
                                                                    <span class="fa-li">
                                                                        <i class="fas fa-building"></i>
                                                                    </span>
                                                                    <span>地址: <%# Eval("dealer_address") %></span>
                                                                </li>
                                                                <li class="mb-1">
                                                                    <span class="fa-li">
                                                                        <i class="fas fa-phone-square-alt"></i>
                                                                    </span>
                                                                    <span>電話: <%# Eval("dealer_tel") %></span>
                                                                </li>
                                                                <li class="mb-1">
                                                                    <span class="fa-li">
                                                                        <i class="fas fa-fax"></i>
                                                                    </span>
                                                                    <span>傳真: <%# Eval("dealer_fax") %></span>
                                                                </li>
                                                                <li class="mb-1">
                                                                    <span class="fa-li">
                                                                        <i class="fas fa-envelope"></i>
                                                                    </span>
                                                                    <span>email: <%# Eval("dealer_email") %></span>
                                                                </li>
                                                                <li>
                                                                    <span class="fa-li">
                                                                        <i class="fab fa-chrome"></i>
                                                                    </span>
                                                                    <span>網址: <%# Eval("dealer_website") %></span>
                                                                </li>
                                                            </ul>
                                                        </div>
                                                        <div class="col-5 text-center">
                                                            <img src="../Upload/images/<%# Eval("dealer_img") %>" alt="" class="img-circle img-fluid">
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="card-footer">
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
                        <asp:Button ID="AddDealer_btn" runat="server" Text="新增經銷商" class="btn btn-primary" OnClick="AddDealer_btn_Click" />
                    </div>
                    <asp:GridView ID="GridView1" CssClass="text-center w-100" runat="server" AutoGenerateColumns="False" DataKeyNames="id" Height="80px" ClientIDMode="Static" CellPadding="3" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                        <Columns>
                            <asp:TemplateField HeaderText="編號">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Container.DataItemIndex + 1 %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="country_id" HeaderText="國家" SortExpression="country_id" />
                            <asp:BoundField DataField="region_id" HeaderText="地區" SortExpression="region_id" />
                            <asp:BoundField DataField="dealer_img" HeaderText="圖片" SortExpression="dealer_img" />
                            <asp:BoundField DataField="dealer_title" HeaderText="職稱" SortExpression="dealer_title" />
                            <asp:BoundField DataField="dealer_name" HeaderText="姓名" SortExpression="dealer_name" />
                            <asp:BoundField DataField="dealer_address" HeaderText="地址" SortExpression="dealer_address" />
                            <asp:BoundField DataField="dealer_tel" HeaderText="電話" SortExpression="dealer_tel" />
                            <asp:BoundField DataField="dealer_fax" HeaderText="傳真" SortExpression="dealer_fax" />
                            <asp:BoundField DataField="dealer_email" HeaderText="email" SortExpression="dealer_email" />
                            <asp:BoundField DataField="dealer_website" HeaderText="網址" SortExpression="dealer_website" />
                            <asp:TemplateField HeaderText="編輯" ShowHeader="False">
                                <EditItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="更新"></asp:LinkButton>
                                    &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="取消"></asp:LinkButton>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:HyperLink runat="server" NavigateUrl='<%# $"UpdateDealers.aspx?id={Eval("id")}" %>' Text="編輯" CssClass="btn btn-sm btn-outline-primary" ClientIDMode="Static">
                                    </asp:HyperLink>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="編輯" CssClass="btn btn-sm btn-outline-primary"></asp:LinkButton>
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
