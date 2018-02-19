<%@ Page Title="Projects" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AllProjects.aspx.cs" Inherits="Agile_2018._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="margin-top: 30px">
        <ul class="collection">
            <asp:Repeater ID="Projects" runat="server">
                <ItemTemplate>
                    <li class="collection-item avatar">
                        <i class="material-icons circle">folder</i>
                        <span class="title truncate"><%# Eval("Title") %></span>
                        <p class="truncate">
                            <%# Eval("TimeAgo") %>
                            <br>
                            <div class="right-align">
                                <asp:LinkButton runat="server" class="waves-effect waves-light btn btn-small blue darken-1 button-icon" OnClick="ViewProject_Click" CommandArgument='<%# Eval("ProjectID") +" "+ Eval("Title") %>'>
                            <i class="material-icons">visibility</i>
                                    View
                                </asp:LinkButton>
                                <asp:LinkButton runat="server" class="waves-effect waves-light btn btn-small amber darken-1 button-icon">
                            <i class="material-icons">create</i>
                                    Sign
                                </asp:LinkButton>
                                <asp:LinkButton runat="server" class="waves-effect waves-light btn btn-small red darken-1 button-icon">
                            <i class="material-icons">delete_forever</i>
                                    Delete
                                </asp:LinkButton>
                            </div>
                        </p>
                        <div class="secondary-content"><span class="new badge" data-badge-caption="Files">4</span></div>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
</asp:Content>
