<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend/News.master" AutoEventWireup="true" CodeBehind="news_list.aspx.cs" Inherits="Tayana.Frontend.news_list" %>

<%@ Register Src="~/Frontend/Pagination.ascx" TagPrefix="uc1" TagName="Pagination" %>


<asp:Content ID="Content1" ContentPlaceHolderID="newsContent" runat="server">
    <div class="box2_list">
        <ul>
            <asp:Repeater ID="Repeater1" runat="server" ClientIDMode="Static">
                <ItemTemplate>
                    <li>
                        <div class="list01">
                            <ul>
                                <li>
                                    <div>
                                        <p>
                                            <img src="../Upload/images/<%# Eval("news_img") %>" alt="" />
                                        </p>
                                    </div>
                                </li>
                                <li>
                                    <span><%# Eval("news_date") %></span>
                                    <br />
                                    <asp:HyperLink ID="NewsTitle" runat="server" Text='<%# Eval("news_title") %>' NavigateUrl='<%# $"news_detail.aspx?id={Eval("id")}" %>' />
                                </li>
                                <br />
                                  <li>
                                    <asp:Literal ID="Literal1" runat="server" Text='<%# Eval("news_summary") %>' ClientIDMode="Static" />
                                </li>
                            </ul>
                        </div>
                    </li>
                </ItemTemplate>
            </asp:Repeater>            
        </ul>
        <!-- 分頁 -->
        <div class="pagenumber">
            <uc1:Pagination runat="server" ID="Pagination" />
            <%--<div class="pagination">
                共<span style="color: red">63</span>筆資料
                <span class="disabled">上一頁</span>
                <span class="current">1</span>
                <a href="new_list.aspx?page=2">2</a>
                <a href="new_list.aspx?page=3">3</a>
                <a href="new_list.aspx?page=4">4</a>
                <a href="new_list.aspx?page=5">5</a>
                <a href="new_list.aspx?page=6">6</a>
                <a href="new_list.aspx?page=7">7</a>
                <a href="new_list.aspx?page=2">下一頁</a>
            </div>--%>
        </div>
        <%--<div class="pagenumber">| <span>1</span> | <a href="#">2</a> | <a href="#">3</a> | <a href="#">4</a> | <a href="#">5</a> |  <a href="#">Next</a>  <a href="#">LastPage</a></div>
        <div class="pagenumber1">Items：<span>89</span>  |  Pages：<span>1/9</span></div>--%>
    </div>
</asp:Content>




