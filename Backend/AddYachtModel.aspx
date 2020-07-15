<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Backstage.Master" AutoEventWireup="true" CodeBehind="AddYachtModel.aspx.cs" Inherits="Tayana.Backend.AddYachtModel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <section class="content-header">
        <div class="container-fluid">
            <div class="row justify-content-center">
                <div class="col-md-6">
                    <ol class="breadcrumb float-sm-right">
                        <li class="breadcrumb-item"><a href="#">Home</a></li>
                        <li class="breadcrumb-item active">新增船型</li>
                    </ol>
                </div>
            </div>
        </div>
    </section>
    <section class="content">
        <div class="container-fluid">
            <div class="row justify-content-center">
                <div class="col-md-6">
                    <div class="card card-lightblue">
                        <div class="card-header">
                            <h3 class="card-title">新增船型</h3>
                        </div>
                        <div class="card-body">
                            <%--新增船型--%>
                            <div class="form-group">
                                <label for="yacht_model">船型</label>
                                <asp:TextBox ID="yacht_model" runat="server" class="form-control" placeholder="船型" ClientIDMode="Static" required=""></asp:TextBox>
                            </div>
                            <label>最新船型</label>
                            <div class="form-row col-6">
                                <div class="form-group col-3">
                                    <div class="custom-control custom-radio">
                                        <input class="custom-control-input" type="radio" id="Radio1" name="customRadio" value="1" runat="server" clientidmode="Static" />
                                        <label for="Radio1" class="custom-control-label">是</label>
                                    </div>
                                </div>
                                <div class="form-group col-3">
                                    <div class="custom-control custom-radio">
                                        <input class="custom-control-input" type="radio" id="Radio2" name="customRadio" value="0" runat="server" clientidmode="Static" />
                                        <label for="Radio2" class="custom-control-label">否</label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="card-footer text-right">
                            <asp:Button ID="Cancel_btn" runat="server" Text="取消" class="btn btn-outline-secondary" ClientIDMode="Static" OnClick="Cancel_btn_Click" UseSubmitBehavior="False" />
                            <asp:Button ID="Submit_btn" runat="server" Text="確認" class="btn btn-primary" OnClick="Submit_btn_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
