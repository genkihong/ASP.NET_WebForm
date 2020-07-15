<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Backstage.Master" AutoEventWireup="true" CodeBehind="YachtPhoto.aspx.cs" Inherits="Tayana.Backend.YachtPhoto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <section class="content-header">
        <div class="container-fluid">
            <div class="row justify-content-center">
                <div class="col-md-12">
                    <ol class="breadcrumb float-sm-right">
                        <li class="breadcrumb-item"><a href="#">Home</a></li>
                        <li class="breadcrumb-item breadcrumb-title active">船型相簿</li>
                    </ol>
                </div>
            </div>
        </div>
    </section>
    <section class="content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <%--<div class="card-header">
                             <div class="card-title">
                                YachtPhoto
                            </div>
                        </div>--%>
                        <div class="card-body pb-0">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="text-right mb-3">
                                        <asp:Button ID="AddYachtPhoto_btn" runat="server" Text="新增船型相簿" class="btn btn-primary" OnClick="AddYachtPhoto_btn_Click" ClientIDMode="Static" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <asp:Repeater ID="YachtPhotoRepeater" runat="server" OnItemCommand="YachtPhotoRepeater_ItemCommand">
                                    <ItemTemplate>
                                        <div class="col-sm-2 mb-3">
                                            <button class="btn btn-block btn-outline-secondary mb-3" type="button" data-toggle="collapse" data-target="#collapse<%# Eval("yacht_id") %>">
                                                <h3><%# Eval("model") %></h3>
                                            </button>
                                            <div id="collapse<%# Eval("yacht_id") %>" class="collapse">
                                                <a href="../Upload/images/<%# Eval("photo")%>" data-toggle="lightbox" data-title="<%# Eval("model") %>" data-gallery="gallery">
                                                    <img src="../Upload/images/<%# Eval("photo")%>" class="img-fluid mb-2" alt="yacht photo" />
                                                </a>
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
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
