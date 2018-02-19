<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Project.aspx.cs" Inherits="Agile_2018.Project1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="margin-top: 30px">
        <ul class="collection">
            <asp:Repeater ID="ProjectName" runat="server">
                <ItemTemplate>
                    <li class="collection-item avatar">
                        <i class="material-icons circle">folder</i>
                        <span class="title truncate"><%# Eval("Title") %></span>
                        <p class="truncate">
                            <br />
                            <div class="right-align">
                                <input type="file" name="file" id="file" class="fileuploader" />
                                <label for="file" class=" waves-effect waves-light btn btn-small blue darken-1 button-icon ">
                                    <i class="material-icons">add</i>
                                    Upload
                                </label>
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
            <asp:Repeater ID="Files" runat="server">
                <ItemTemplate>
                    <li class="collection-item avatar">
                        <span class="title truncate"><%# Eval("FileName") %></span>
                        <div class="right-align">
                            <asp:LinkButton runat="server" class="waves-effect waves-light btn btn-small red darken-1 button-icon">
                            <i class="material-icons">delete_forever</i>
                            </asp:LinkButton>
                        </div>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
</asp:Content>
