<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend/Yachts.master" AutoEventWireup="true" CodeBehind="yacht_specification.aspx.cs" Inherits="Tayana.Frontend.yachts03" %>

<asp:Content ID="Content1" ContentPlaceHolderID="yachtsContent" runat="server">
    <div class="left">
        <div class="left1">
            <p><span>YACHTS</span></p>
            <ul>
                <asp:Repeater ID="YachtRepeater" runat="server">
                    <ItemTemplate>
                        <li>
                            <asp:HyperLink runat="server" NavigateUrl='<%# $"yacht_specification.aspx?id={Eval("id")}" %>'>
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
            <span class="on1"><asp:Literal runat="server" ID="breadcrumb" /></span>
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
            <div class="box5">
                <h4>DETAIL SPECIFICATION</h4>
                <asp:Literal ID="content" runat="server"></asp:Literal>
                <%--<p>HULL STRUCTURE & DECKS</p>
                <ul>
                    <li>Yanmar 4LHA-HTP 160HP (or equal)</li>
                    <li>White formica counters in hgalley. Teak veneer ctt</li>
                    <li>White formica counters in hgalley. Teak veneer c</li>
                    <li>White formica counters in hgalley. Teak veneer c</li>
                    <li>WTeak veneer ctte table 0005</li>
                    <li>WTeak veneer ctte table 0005</li>
                </ul>
                <p>HULL STRUCTURE & DECKS</p>
                <ul>
                    <li>Yanmar 4LHA-HTP 160HP (or equal)</li>
                    <li>White formica counters in hgalley. Teak veneer ctt</li>
                    <li>White formica counters in hgalley. Teak veneer c</li>
                    <li>White formica counters in hgalley. Teak veneer c</li>
                    <li>WTeak veneer ctte table 0005</li>
                    <li>WTeak veneer ctte table 0005</li>
                </ul>--%>
            </div>
            <p class="topbuttom">
                <img src="images/top.gif" alt="top" />
            </p>
            <!--------------------------------內容結束---------------------------------------------------->
        </div>
    </div>
    <!--------------------------------右邊選單結束---------------------------------------------------->
</asp:Content>
