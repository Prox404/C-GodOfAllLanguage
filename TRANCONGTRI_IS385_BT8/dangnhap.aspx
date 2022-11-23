<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dangnhap.aspx.cs" Inherits="TRANCONGTRI_IS385_BT8.dangnhap" %>

    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">

    <head runat="server">
        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet"
            integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
        <link href="/styles.css" rel="stylesheet" />
        <title></title>
    </head>

    <body class="login-wrapper">
        <form class="w-100 h-100" id="form1" runat="server">
            <div class="w-100 h-100 position-relative">
                <div class="modal-auth-wrapper wrapper-centered">
                    <div class="modal-auth-content">
                        <div class="p-0">
                            <div class="row">
                                <div class="col-6 modal-auth-left">
                                    <h2 class="text-primary">Đăng nhập</h2>
                                    <h5 class="text-cyan mt-4">Xin chào !
                                    </h5>
                                    <h5 class="text-brand">Hãy nhập Tên đăng nhập và Mật khẩu !
                                    </h5>
                                    <asp:Login CssClass="w-100" ID="Login1" runat="server"
                                        OnAuthenticate="Login1_Authenticate">
                                        <LayoutTemplate>
                                            <div class="mb-3">
                                                <asp:Label CssClass="form-label" ID="UserNameLabel" runat="server"
                                                    AssociatedControlID="UserName">User Name:</asp:Label>
                                                <asp:TextBox CssClass="form-control" ID="UserName" runat="server">
                                                </asp:TextBox>
                                                <div class="form-text">
                                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server"
                                                        ControlToValidate="UserName"
                                                        ErrorMessage="User Name is required."
                                                        ToolTip="User Name is required." ValidationGroup="ctl00$Login1">
                                                        Điền tên đăng nhập</asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="mb-3">
                                                <asp:Label CssClass="form-label" ID="PasswordLabel" runat="server"
                                                    AssociatedControlID="Password">Password:</asp:Label>
                                                <asp:TextBox CssClass="form-control" ID="Password" runat="server"
                                                    TextMode="Password"></asp:TextBox>
                                                <div class="form-text">
                                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server"
                                                        ControlToValidate="Password"
                                                        ErrorMessage="Password is required."
                                                        ToolTip="Password is required." ValidationGroup="ctl00$Login1">
                                                        Điền mật khẩu</asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="mb-3">
                                                <asp:CheckBox ID="RememberMe" runat="server"
                                                    Text="Ghi nhớ đăng nhập." />
                                            </div>
                                            <div class="mb-3">
                                                <div class="form-text">
                                                    <asp:Literal ID="FailureText" runat="server"
                                                        EnableViewState="False"></asp:Literal>
                                                </div>
                                            </div>
                                            <asp:Button CssClass="btn btn-primary w-100 mt-2" ID="LoginButton"
                                                runat="server" CommandName="Login" Text="Đăng nhập"
                                                ValidationGroup="ctl00$Login1" />
                                        </LayoutTemplate>
                                    </asp:Login>
                                </div>
                                <div class="col-6">
                                    <img class="h-100" src="./assets/images/proxBanner.png" alt="prox-banner" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </form>
    </body>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js"
        integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM"
        crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.2/dist/umd/popper.min.js"
        integrity="sha384-IQsoLXl5PILFhosVNubq5LC7Qb9DXgDA9i+tQ8Zj3iwWAwPtgFTxbJ8NT4GN1R8p"
        crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.min.js"
        integrity="sha384-cVKIPhGWiC2Al4u+LWgxfKTRIcfu0JTxR+EQDz/bgldoEyl4H0zUF0QKbrJ0EcQF"
        crossorigin="anonymous"></script>
    <script src="https://kit.fontawesome.com/53662a567a.js" crossorigin="anonymous"></script>

    </html>