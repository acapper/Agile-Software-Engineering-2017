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
    <form runat="server">
        <asp:ScriptManager runat="server">
            <Scripts>
                <%--To learn more about bundling scripts in ScriptManager see https://go.microsoft.com/fwlink/?LinkID=301884 --%>
                <%--Framework Scripts--%>
                <asp:ScriptReference Name="MsAjaxBundle" />
                <asp:ScriptReference Name="jquery" />
                <asp:ScriptReference Name="bootstrap" />
                <asp:ScriptReference Name="respond" />
                <asp:ScriptReference Name="WebForms.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebForms.js" />
                <asp:ScriptReference Name="WebUIValidation.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebUIValidation.js" />
                <asp:ScriptReference Name="MenuStandards.js" Assembly="System.Web" Path="~/Scripts/WebForms/MenuStandards.js" />
                <asp:ScriptReference Name="GridView.js" Assembly="System.Web" Path="~/Scripts/WebForms/GridView.js" />
                <asp:ScriptReference Name="DetailsView.js" Assembly="System.Web" Path="~/Scripts/WebForms/DetailsView.js" />
                <asp:ScriptReference Name="TreeView.js" Assembly="System.Web" Path="~/Scripts/WebForms/TreeView.js" />
                <asp:ScriptReference Name="WebParts.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebParts.js" />
                <asp:ScriptReference Name="Focus.js" Assembly="System.Web" Path="~/Scripts/WebForms/Focus.js" />
                <asp:ScriptReference Name="WebFormsBundle" />
                <%--Site Scripts--%>
            </Scripts>
        </asp:ScriptManager>
    </form>
    <div class="container v-center">
        <div class="row">
            <div class="Absolute-Center is-Responsive">
                <div class="col-sm-12 col-sm-10 text-align-center p-15">
                    <form role="form" action="AllProjects.aspx">
                        <div class="form-group text-align-center">
                            <h3>Login</h3>
                        </div>
                        <div class="form-group input-group">
                            <span class="input-group-addon text-black"><i class="glyphicon glyphicon-user"></i></span>
                            <input class="form-control input-lg" type="text" name='username' placeholder="Username" required/>
                        </div>
                        <div class="form-group input-group">
                            <span class="input-group-addon text-black"><i class="glyphicon glyphicon-lock"></i></span>
                            <input class="form-control input-lg" type="password" name='password' placeholder="Password" required/>
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
                            <button type="submit" class="btn btn-default">Login</button>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
