<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dangky.aspx.cs" Inherits="TRANCONGTRI_IS385_BT8.dangky" %>

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
                                    <h2 class="text-primary">Đăng ký tài khoản</h2>
                                    <h5 class="text-cyan mt-4">Xin chào !
                                    </h5>
                                    <h5 class="text-brand">Hãy nhập Tên đăng nhập và Mật khẩu !
                                    </h5>
                                    <asp:Label CssClass="form-label" ID="UserNameLabel1" runat="server"
                                        AssociatedControlID="TextBox1">UserName:</asp:Label>
                                    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server"></asp:TextBox>
                                    <div class="form-text">
                                        <asp:RequiredFieldValidator ControlToValidate="TextBox1" Display="Dynamic"
                                            ErrorMessage="UserName is required" ID="UserNameRequired" runat="server"
                                            ValidationGroup="register">
                                            Nhập tên đăng nhập
                                        </asp:RequiredFieldValidator>
                                    </div>
                                    <asp:Label CssClass="form-label" ID="PasswordLabel1" runat="server"
                                        AssociatedControlID="TextBox2">Password:</asp:Label>
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" TextMode="Password"
                                        runat="server">
                                    </asp:TextBox>
                                    <div class="form-text">
                                        <asp:RequiredFieldValidator ID="PasswordRequired" Display="Dynamic"
                                            ControlToValidate="TextBox2" runat="server" ErrorMessage="Password Require"
                                            ValidationGroup="register">
                                            Nhập mật khẩu
                                        </asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-text">
                                        <asp:Label CssClass="text-danger" ID="Label1" runat="server" Text="">
                                        </asp:Label>

                                    </div>
                                    <asp:Button CssClass="btn btn-primary mt-3" OnClick="Button4_Click" ID="Button4"
                                        runat="server" Text="Tạo tài khoản" ValidationGroup="register" />
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