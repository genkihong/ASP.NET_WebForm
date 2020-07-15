<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Backstage.Master" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="Tayana.admin" %>

<%@ Register Src="~/Backend/BackstagePagination.ascx" TagPrefix="uc1" TagName="BackstagePagination" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <section class="content-header">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-12 d-flex align-items-center">
                    <div class="row w-50 mr-auto align-items-end">
                        <div class="col-md-6">
                            <label for="SearchText">會員帳號</label>
                            <div class="input-group">
                                <asp:TextBox ID="SearchUser" runat="server" class="form-control" placeholder="請輸入會員帳號" TextMode="Search" ClientIDMode="Static" />
                                <div class="input-group-append">
                                    <asp:LinkButton ID="Search_btn" runat="server" class="btn btn-primary" ClientIDMode="Static" OnClick="Search_btn_Click">
                                <i class="fas fa-search"></i>
                                    </asp:LinkButton>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <asp:LinkButton ID="Reset_btn" runat="server" class="btn btn-outline-secondary" ClientIDMode="Static" OnClick="Reset_btn_Click">
                                <%--<i class="fas fa-sync-alt"></i>--%>
                                <span>重新搜尋</span> 
                            </asp:LinkButton>
                        </div>
                    </div>
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#">Home</a></li>
                        <li class="breadcrumb-item active">會員列表</li>
                        <li class="breadcrumb-item active">
                            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
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
                    <%--會員列表--%>
                    <div class="card">
                        <div class="card-body pb-0">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="text-right mb-3">
                                        <asp:Button ID="AddUser_btn" runat="server" Text="新增會員" class="btn btn-primary" OnClick="AddUser_btn_Click" ClientIDMode="Static" />
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
                                <asp:Repeater ID="UserRepeater" runat="server" OnItemCommand="UserRepeater_ItemCommand">
                                    <ItemTemplate>
                                        <div class="col-md-4">
                                            <div class="card bg-light">
                                                <div class="card-header border-bottom-0">
                                                    <h3><%# Eval("user_identity").ToString() == "1" ? "管理員" : "一般會員" %></h3>
                                                </div>
                                                <div class="card-body pt-0">
                                                    <div class="row">
                                                        <div class="col-8">
                                                            <ul class="mb-0 fa-ul ml-4">
                                                                <li class="mb-1">
                                                                    <span class="fa-li">
                                                                        <i class="fas fa-user"></i>
                                                                    </span>
                                                                    <span>帳號: <%# Eval("name") %></span></li>
                                                                <li class="mb-1">
                                                                    <span class="fa-li">
                                                                        <i class="fas fa-envelope"></i>
                                                                    </span>
                                                                    <span>email: <%# Eval("email") %></span>
                                                                </li>
                                                                <li class="d-flex mb-1">
                                                                    <div>
                                                                        <span class="fa-li">
                                                                            <i class="fas fa-tools"></i>
                                                                        </span>
                                                                        <span>權限: </span>
                                                                    </div>
                                                                    <ul class="list-unstyled d-flex">
                                                                        <li class="mr-1">
                                                                            <%# Eval("permission").ToString().Contains("01") ? "遊艇管理" : "" %>
                                                                        </li>
                                                                        <li class="mr-1">
                                                                            <%# Eval("permission").ToString().Contains("02") ? "新聞管理" : "" %>
                                                                        </li>
                                                                        <li>
                                                                            <%# Eval("permission").ToString().Contains("03") ? "經銷商管理" : "" %>
                                                                        </li>
                                                                    </ul>
                                                                </li>
                                                               <%-- <li>
                                                                    <span class="fa-li">
                                                                        <i class="fas fa-unlock-alt"></i>
                                                                    </span>
                                                                    <span>密碼: <%# Eval("password").ToString().Substring(0,11)+"..." %></span>
                                                                </li>--%>
                                                            </ul>
                                                        </div>
                                                        <div class="col-4 text-center">
                                                            <img src="../Upload/images/<%# Eval("photo") %>" alt="" class="img-circle img-fluid">
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
                        <asp:Button ID="AddUser_btn" runat="server" Text="新增會員" class="btn btn-primary" OnClick="AddUser_btn_Click" />
                    </div>
                    <asp:GridView ID="GridView1" CssClass="text-center w-100" runat="server" AutoGenerateColumns="False" DataKeyNames="id" CellPadding="3" Height="80px" ClientIDMode="Static" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="GridView1_RowUpdating" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                        <Columns>
                            <asp:TemplateField HeaderText="編號">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Container.DataItemIndex + 1 %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="user_identity" HeaderText="身份" SortExpression="user_identity" />
                            <asp:BoundField DataField="name" HeaderText="帳號" SortExpression="name" />
                            <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" />
                            <asp:BoundField DataField="password" HeaderText="密碼" SortExpression="password" />
                            <asp:BoundField DataField="permission" HeaderText="權限" SortExpression="permission" />
                            <asp:BoundField DataField="photo" HeaderText="圖片" SortExpression="photo" />
                            <asp:BoundField DataField="create_date" DataFormatString="{0:yyyy/MM/dd HH:mm}" HeaderText="建立日期" SortExpression="create_date" />
                            <asp:TemplateField HeaderText="編輯" ShowHeader="False">
                                <EditItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="更新"></asp:LinkButton>
                                    &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="取消"></asp:LinkButton>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:HyperLink runat="server" NavigateUrl='<%# $"UpdateUser.aspx?id={Eval("id")}" %>' Text="編輯" CssClass="btn btn-sm btn-outline-primary" ClientIDMode="Static">
                                    </asp:HyperLink>
                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Edit" Text="編輯" CssClass="btn btn-sm btn-outline-primary"></asp:LinkButton>
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
