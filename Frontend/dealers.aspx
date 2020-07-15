<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend/Dealers.master" AutoEventWireup="true" CodeBehind="dealers.aspx.cs" Inherits="Tayana.Frontend.dealers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="dealersContent" runat="server">
    <!--------------------------------右邊選單開始---------------------------------------------------->
    <div id="crumb">
        <a href="index.aspx">Home</a> >>
        <a href="#">Dealers</a> >>
        <a href="#">
            <asp:Label ID="Label1" runat="server" class="on1" ClientIDMode="Static"></asp:Label>
        </a>
    </div>
    <div class="right">
        <div class="right1">
            <div class="title">
                <asp:Label ID="Label2" runat="server" ClientIDMode="Static"></asp:Label>
            </div>
            <!--------------------------------內容開始---------------------------------------------------->
            <div class="box2_list">
                <asp:Repeater ID="Repeater1" runat="server">
                    <HeaderTemplate>
                        <ul>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li>
                            <div class="list02">
                                <ul>
                                    <li class="list02li">
                                        <div>
                                            <p>
                                                <img src="../Upload/images/<%# Eval("dealer_img") %>" width="100%" />
                                            </p>
                                        </div>
                                    </li>
                                    <li>
                                        <%--地區--%>
                                        <span>
                                            <%# Eval("region") %>
                                        </span>
                                        <br />
                                        <%--經銷商職稱--%>
                                        <%# Eval("dealer_title") %>
                                        <br />
                                        <%--姓名--%>
                                    Contact：<%# Eval("dealer_name") %>
                                        <br />
                                        <%--住址--%>
                                    Address：<%# Eval("dealer_address") %>
                                        <br />
                                        <%--電話--%>
                                    TEL：<%# Eval("dealer_tel") %>
                                        <br />
                                        <%--email--%>
                                    E-mail：<%# Eval("dealer_email") %>
                                        <br />
                                        <%--網址--%>
                                        <asp:HyperLink ID="DealerWebSite" runat="server" Text='<%# Eval("dealer_website") %>' NavigateUrl='<%# Eval("dealer_website") %>' Target="_blank" ClientIDMode="Static" />
                                    </li>
                                </ul>
                            </div>
                        </li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul>
                    </FooterTemplate>
                </asp:Repeater>
                <%-- <div class="pagenumber">| <span>1</span> | <a href="#">2</a> | <a href="#">3</a> | <a href="#">4</a> | <a href="#">5</a> |  <a href="#">Next</a>  <a href="#">LastPage</a></div>
        <div class="pagenumber1">Items：<span>89</span>  |  Pages：<span>1/9</span></div>--%>
            </div>
            <!--------------------------------內容結束------------------------------------------------------>
        </div>
    </div>
    <!--------------------------------右邊選單結束---------------------------------------------------->
</asp:Content>
