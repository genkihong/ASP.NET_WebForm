<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Tayana.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Login</title>
    <!-- Font Awesome -->
    <link rel="stylesheet" href="./Backend/plugins/fontawesome-free/css/all.min.css" />
    <!-- Ionicons -->
    <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css" />
    <!-- icheck bootstrap -->
    <link rel="stylesheet" href="./Backend/plugins/icheck-bootstrap/icheck-bootstrap.min.css" />
    <!-- Theme style -->
    <link rel="stylesheet" href="./Backend/dist/css/adminlte.min.css" />
    <!-- Google Font: Source Sans Pro -->
    <link href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700" rel="stylesheet" />
</head>
<body class="hold-transition login-page">
    <form id="form1" runat="server">
        <div class="login-box">
            <div class="login-logo">
                <a href="#"><b>Tayana</b></a>
            </div>
            <!-- /.login-logo -->
            <div class="card">
                <div class="card-body login-card-body">
                    <p class="login-box-msg">Sign in to start your session</p>  
                    <%--帳號--%>
                    <div class="form-group">
                        <div class="input-group">                            
                            <asp:TextBox ID="username" runat="server" type="text" class="form-control" placeholder="User Name" required=""
                                oninvalid="setCustomValidity('required')" oninput="setCustomValidity('');"></asp:TextBox>
                            <div class="input-group-append">
                                <div class="input-group-text">
                                    <span class="fas fa-user-alt"></span>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%--密碼--%>
                    <div class="form-group">
                        <div class="input-group">                            
                            <asp:TextBox ID="password" runat="server" type="password" class="form-control" placeholder="Password" required=""
                                oninvalid="setCustomValidity('required')" oninput="setCustomValidity('');"></asp:TextBox>
                            <div class="input-group-append">
                                <div class="input-group-text">
                                    <span class="fas fa-lock"></span>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="text-right">
                        <asp:Button ID="SignIn_btn" runat="server" Text="Sign In" class="btn btn-primary btn-block" OnClick="SignIn_btn_Click" />
                    </div>
                    <asp:Label ID="LoginLabel" runat="server" Text="" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>                    
                </div>
            </div>
        </div>
        <!-- jQuery -->
        <script src="./Backend/plugins/jquery/jquery.min.js"></script>
        <!-- Bootstrap 4 -->
        <script src="./Backend/plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
        <!-- AdminLTE App -->
        <script src="./Backend/dist/js/adminlte.min.js"></script>
    </form>
</body>
</html>
