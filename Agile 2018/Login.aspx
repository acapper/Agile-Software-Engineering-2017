<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Agile_2018.WebForm1" %>

<!DOCTYPE html>

<html lang="en">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title><%: Page.Title %> - My ASP.NET Application</title>

    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>

    <webopt:BundleReference runat="server" Path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />

</head>
<body class="site-colour">
    <div class="container v-center">
        <div class="row">
            <div class="Absolute-Center is-Responsive">
                <div class="col-sm-12 col-sm-10 text-align-center p-15">
                    <form role="form" runat="server">
                        <div class="form-group text-align-center">
                            <h3>Login</h3>
                        </div>
                        <div class="form-group input-group">
                            <span class="input-group-addon text-black"><i class="glyphicon glyphicon-user"></i></span>
                            <input runat="server" id="username" class="form-control input-lg" type="text" name='username' placeholder="Username" required/>
                        </div>
                        <div class="form-group input-group">
                            <span class="input-group-addon text-black"><i class="glyphicon glyphicon-lock"></i></span>
                            <input runat="server" id="password" class="form-control input-lg" type="password" name='password' placeholder="Password" required/>
                        </div>
                        <div class="form-group input-group h-center">
                            <div class="checkbox">
                                <label>
                                    <input type="checkbox" class="custom-checkbox">
                                    Remember Me
                                </label>
                            </div>
                        </div>
                        <div class="form-group pt-10 text-align-end">
                            <asp:LinkButton runat="server" OnClick="LoginControl_Authenticate" type="submit" class="btn btn-default">Login</asp:LinkButton>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
