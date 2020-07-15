<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend/Yachts.master" AutoEventWireup="true" CodeBehind="yacht_overview.aspx.cs" Inherits="Tayana.Frontend.yachts01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="yachtsContent" runat="server">
    <div class="left">
        <div class="left1">
            <p><span>YACHTS</span></p>
            <ul>
                <asp:Repeater ID="YachtRepeater" runat="server">
                    <ItemTemplate>
                        <li>
                            <asp:HyperLink runat="server" NavigateUrl='<%# $"yacht_overview.aspx?id={Eval("id")}" %>'>
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
            <div class="box1">
                <asp:Literal ID="content" runat="server"></asp:Literal>
                <br />
            </div>
            <div class="box3">
                <h4><asp:Literal ID="model" runat="server"></asp:Literal> DIMENSIONS</h4>
                <asp:Literal ID="dimensions" runat="server"></asp:Literal>
            </div>

            <p class="topbuttom">
                <img src="images/top.gif" alt="top" />
            </p>
            <!--下載開始-->
            <div class="downloads">
                <p>
                    <img src="images/downloads.gif" alt="&quot;&quot;" />
                </p>
                <ul>
                    <li><a href="#">Downloads 001</a></li>
                    <li><a href="#">Downloads 001</a></li>
                    <li><a href="#">Downloads 001</a></li>
                    <li><a href="#">Downloads 001</a></li>
                    <li><a href="#">Downloads 001</a></li>
                </ul>
            </div>
            <!--下載結束-->
            <!--------------------------------內容結束---------------------------------------------------->
        </div>
    </div>
    <!--------------------------------右邊選單結束---------------------------------------------------->
</asp:Content>
