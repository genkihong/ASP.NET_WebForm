<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend/Tayana.Master" AutoEventWireup="true" CodeBehind="contact.aspx.cs" Inherits="Tayana.Frontend.contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <!--遮罩-->
    <div class="bannermasks">
        <img src="images/contact.jpg" alt="&quot;&quot;" width="967" height="371" />
    </div>
    <!--遮罩結束-->
    <div class="banner">
        <ul>
            <li>
                <img src="images/newbanner.jpg" alt="Tayana Yachts" />
            </li>
        </ul>
    </div>
    <!--------------------------------換圖結束---------------------------------------------------->
    <div class="conbg">
        <!--------------------------------左邊選單開始---------------------------------------------------->
        <div class="left">
            <div class="left1">
                <p><span>CONTACT</span></p>
                <ul>
                    <li><a href="#">contacts</a></li>
                </ul>
            </div>
        </div>
        <!--------------------------------左邊選單結束---------------------------------------------------->

        <!--------------------------------右邊選單開始---------------------------------------------------->
        <div id="crumb"><a href="#">Home</a> >> <a href="#"><span class="on1">Contact</span></a></div>
        <div class="right">
            <div class="right1">
                <div class="title">
                    <span>Contact</span>
                </div>
                <!--------------------------------內容開始---------------------------------------------------->
                <!--表單-->
                <div class="from01">
                    <p>
                        Please Enter your contact information<span class="span01">*Required</span>
                    </p>
                    <br />
                    <table>
                        <tr>
                            <td class="from01td01">Name :</td>
                            <td><span>*</span>
                                <asp:TextBox ID="name" runat="server" ClientIDMode="Inherit" required=""
                                    oninvalid="setCustomValidity('請輸入姓名');" oninput="setCustomValidity('');" />
                                <%--<input type="text" name="textfield" id="textfield" />--%>
                            </td>
                        </tr>
                        <tr>
                            <td class="from01td01">Email :</td>
                            <td><span>*</span>
                                <asp:TextBox ID="email" runat="server" TextMode="Email" required=""
                                    oninvalid="setCustomValidity('請輸入email');" oninput="setCustomValidity('');" />
                                <%--<input type="text" name="textfield" id="textfield" />--%>
                            </td>
                        </tr>
                        <tr>
                            <td class="from01td01">Phone :</td>
                            <td><span>*</span>
                                <asp:TextBox ID="phone" runat="server" TextMode="Phone" required=""
                                    oninvalid="setCustomValidity('請輸入電話');" oninput="setCustomValidity('');" />
                                <%--<input type="text" name="textfield" id="textfield" />--%>
                            </td>
                        </tr>
                        <tr>
                            <td class="from01td01">Country :</td>
                            <td><span>*</span>
                                <asp:DropDownList ID="CountryDropDownList" runat="server" />
                                <%--<select name="select" id="select">
                                    <option>Annapolis</option>
                                </select>--%>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2"><span>*</span>Brochure of interest  *Which Brochure would you like to view?</td>
                        </tr>
                        <tr>
                            <td class="from01td01">&nbsp;</td>
                            <td>
                                <asp:DropDownList ID="YachtModelDropDownList" runat="server" />
                                <%--<select name="select" id="select">
                                    <option>Dynasty 72 </option>
                                </select>--%>
                            </td>
                        </tr>
                        <tr>
                            <td class="from01td01">Comments:</td>
                            <td>
                                <asp:TextBox ID="comments" runat="server" name="textarea" cols="45" Rows="5" TextMode="MultiLine" />
                                <%--<textarea name="textarea" id="textarea" cols="45" rows="5"></textarea>--%>
                            </td>
                        </tr>
                        <tr>
                            <td class="from01td01">&nbsp;</td>
                            <td class="f_right">
                                <a href="#">
                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="images/buttom03.gif" Height="25" Width="59" OnClick="ImageButton1_Click" />
                                    <%--<img src="images/buttom03.gif" alt="submit" width="59" height="25" />--%>
                                </a>
                            </td>
                        </tr>
                    </table>
                </div>
                <!--表單-->
                <div class="box1">
                    <span class="span02">Contact with us</span><br />
                    Thanks for your enjoying our web site as an introduction to the Tayana world and our range of yachts.
As all the designs in our range are semi-custom built, we are glad to offer a personal service to all our potential customers. 
If you have any questions about our yachts or would like to take your interest a stage further, please feel free to contact us.
                </div>
                <div class="list03">
                    <p>
                        <span>TAYANA HEAD OFFICE</span><br />
                        NO.60 Haichien Rd. Chungmen Village Linyuan Kaohsiung Hsien 832 Taiwan R.O.C<br />
                        tel. +886(7)641 2422<br />
                        fax. +886(7)642 3193<br />
                        info@tayanaworld.com<br />
                    </p>
                </div>
                <div class="list03">
                    <p>
                        <span>SALES DEPT.</span><br />
                        +886(7)641 2422  ATTEN. Mr.Basil Lin<br />
                        <br />
                    </p>
                </div>
                <div class="box4">
                    <h4>Location</h4>
                    <p>
                        <%--<iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3683.3210622737756!2d120.29860794920243!3d22.604482869936636!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x346e037776556f41%3A0xc45467858397992e!2zODA26auY6ZuE5biC5YmN6Y6u5Y2A5b6p6IiI5Zub6LevMTLomZ8!5e0!3m2!1szh-TW!2stw!4v1586179292786!5m2!1szh-TW!2stw" width="600" height="450" frameborder="0" style="border:0;" allowfullscreen="" aria-hidden="false" tabindex="0"></iframe>--%>
                        <iframe width="695" height="518" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3683.3210622737756!2d120.29860794920243!3d22.604482869936636!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x346e037776556f41%3A0xc45467858397992e!2zODA26auY6ZuE5biC5YmN6Y6u5Y2A5b6p6IiI5Zub6LevMTLomZ8!5e0!3m2!1szh-TW!2stw!4v1586179292786!5m2!1szh-TW!2stw"></iframe>
                    </p>
                </div>
                <!--------------------------------內容結束------------------------------------------------------>
            </div>
        </div>
        <!--------------------------------右邊選單結束---------------------------------------------------->
    </div>
</asp:Content>
