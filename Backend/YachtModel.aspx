<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Backstage.Master" AutoEventWireup="true" CodeBehind="YachtModel.aspx.cs" Inherits="Tayana.Backend.YachtModel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <section class="content-header">
        <div class="container-fluid">
            <div class="row justify-content-center">
                <div class="col-md-12">
                    <ol class="breadcrumb float-sm-right">
                        <li class="breadcrumb-item"><a href="#">Home</a></li>
                        <li class="breadcrumb-item active">船型列表</li>
                    </ol>
                </div>
            </div>
        </div>
    </section>
    <section class="content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-12">
                    <%--船型列表--%>
                    <div class="card">
                        <div class="card-body pb-0">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="text-right mb-3">
                                        <asp:Button ID="AddYachtModel_btn" runat="server" Text="新增船型" class="btn btn-primary" OnClick="AddYachtModel_btn_Click" ClientIDMode="Static" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <asp:Repeater ID="YachtModeRepeater" runat="server" OnItemCommand="YachtModelRepeater_ItemCommand">
                                    <ItemTemplate>
                                        <div class="col-md-3">
                                            <div class="card bg-light">
                                                <div class="card-header border-bottom-0 d-flex">
                                                    <h4 class="mb-0"><%# Eval("model") %></h4>
                                                </div>
                                                <div class="card-body pt-0">
                                                    <div class="ribbon-wrapper <%# Eval("newest").ToString() == "0" ? "d-none" : "" %>">
                                                        <div class="ribbon bg-danger">
                                                            Newest
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="card-footer d-flex">
                                                    <div class="mr-auto">
                                                        <asp:LinkButton ID="NewestBtn" runat="server" CssClass="btn btn-sm btn-outline-secondary"
                                                            CommandArgument='<%# Eval( "id") %>' CommandName="Newest" ClientIDMode="Static"
                                                            OnClientClick="javascript:if(!window.confirm('確定要變更?')) window.event.returnValue = false;">
                                                    <span class="ml-1">最新船型</span>
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
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <%--<section class="content">
        <div class="container-fluid">
            <div class="row justify-content-center">
                <div class="col-md-6">
                    <asp:GridView ID="GridView1" CssClass="text-center w-100" runat="server" AutoGenerateColumns="False" DataKeyNames="id" Height="80px" ClientIDMode="Static" CellPadding="3" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="GridView1_RowUpdating" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                        <Columns>
                            <asp:TemplateField HeaderText="編號" ItemStyle-Width="60">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Container.DataItemIndex + 1 %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="最新船型" ItemStyle-Width="80">
                                <ItemTemplate>
                                    <asp:Label ID="newest" runat="server" Text='<%# Eval("newest").ToString() == "1" ? "是" : "否" %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="model" HeaderText="船型" SortExpression="model" />
                            <asp:BoundField DataField="newest" HeaderText="最新船型代號" SortExpression="newest" />
                            <asp:TemplateField HeaderText="編輯" ShowHeader="False" ItemStyle-Width="120">
                                <EditItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="更新" CssClass="btn btn-sm btn-outline-primary"></asp:LinkButton>
                                    &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="取消" CssClass="btn btn-sm btn-outline-secondary"></asp:LinkButton>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="編輯" CssClass="btn btn-sm btn-outline-primary"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="刪除" ShowHeader="False" ItemStyle-Width="80">
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
