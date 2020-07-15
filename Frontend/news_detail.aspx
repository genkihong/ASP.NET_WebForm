<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend/News.master" AutoEventWireup="true" CodeBehind="news_detail.aspx.cs" Inherits="Tayana.Frontend.news_detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="newsContent" runat="server">
    <div class="box3">
        <h4>
            <asp:Label ID="NewsTitle" runat="server" Text="" ClientIDMode="Static"></asp:Label>
        </h4>
        <%--<p>
            <img src="images/pit009.jpg" alt="&quot;&quot;" style="width: 700px; height: 525px;" />
        </p>--%>
        <asp:Literal ID="NewsContent" runat="server" ClientIDMode="Static"></asp:Literal>
    </div>

    <!--下載開始-->
    <%--<div class="downloads">
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
    </div>--%>
    <!--下載結束-->

    <div class="buttom001">
        <a href="javascript:window.history.back();">
            <img src="images/back.gif" alt="&quot;&quot;" width="55" height="28" />
        </a>
    </div>
</asp:Content>
