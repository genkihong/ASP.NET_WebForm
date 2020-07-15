<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend/Yachts.master" AutoEventWireup="true" CodeBehind="yacht_layout.aspx.cs" Inherits="Tayana.Frontend.yachts02" %>

<asp:Content ID="Content1" ContentPlaceHolderID="yachtsContent" runat="server">
    <div class="left">
        <div class="left1">
            <p><span>YACHTS</span></p>
            <ul>
                <asp:Repeater ID="YachtRepeater" runat="server">
                    <ItemTemplate>
                        <li>
                            <asp:HyperLink runat="server" NavigateUrl='<%# $"yacht_layout.aspx?id={Eval("id")}" %>'>
                                <%# Eval("model") %>
                                <%# Eval("newest").ToString() == "1" ? " (New Building)" : "" %>
                            </asp:HyperLink>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </div>
    <!--------------------------------右邊選單開始---------------------------------------------------->
    <div id="crumb">
        <a href="#">Home</a> >>
        <a href="#">Yachts</a> >>
        <a href="#">
            <span class="on1">
                <asp:Literal runat="server" ID="breadcrumb" /></span>
        </a>
    </div>
    <!--------------------------------內容開始---------------------------------------------------->
    <div class="right">
        <div class="right1">
            <div class="title">
                <span>
                    <asp:Literal runat="server" ID="title" />
                </span>
            </div>
            <!--次選單-->
            <div class="menu_y">
                <ul>
                    <li class="menu_y00">YACHTS</li>
                    <li>
                        <asp:HyperLink ID="overview" runat="server" class="menu_yli01" Text="Overview" ClientIDMode="Static" />
                        <%--<a class="menu_yli01" href="yacht_overview.aspx">Overview</a>--%>
                    </li>
                    <li>
                        <asp:HyperLink ID="layout" runat="server" class="menu_yli02" Text="Layout & deck plan" ClientIDMode="Static" />
                        <%--<a class="menu_yli02" href="yacht_layout.aspx">Layout & deck plan</a>--%>
                    </li>
                    <li>
                        <asp:HyperLink ID="specification" runat="server" class="menu_yli03" Text="Specification" ClientIDMode="Static" />
                        <%--<a class="menu_yli03" href="yacht_specification.aspx">Specification</a>--%>
                    </li>
                </ul>
            </div>
            <!--次選單-->
            <div class="box6">
                <p>Layout & deck plan</p>
                <asp:Literal ID="Literal1" runat="server" ClientIDMode="Static"></asp:Literal>
                <%-- <ul>
                    <li>
                        <img src="images/deckplan01.jpg" alt="&quot;&quot;" />
                    </li>
                </ul>--%>
            </div>
            <div class="clear"></div>
            <!--------------------------------內容結束---------------------------------------------------->
        </div>
    </div>
    <!--------------------------------右邊選單結束---------------------------------------------------->
</asp:Content>
