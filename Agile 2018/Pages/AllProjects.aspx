<%@ Page Title="Projects" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AllProjects.aspx.cs" Inherits="Agile_2018._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="margin-top: 30px">
        <asp:Repeater ID="Projects" runat="server">
            <ItemTemplate>
                <div class="list-group" style="line-height: 50px; vertical-align: middle">
                    <div class="list-group-item clearfix text-black rounded project">
                        <div class="pull-left">
                            <span class="label label-sm label-info glyphicon glyphicon-file" style="margin-right: 5px">10</span>
                            <%# Eval("Title") %>
                        </div>
                        <div class="pull-right">
                            <asp:LinkButton runat="server" OnClick="ViewProject_Click"  CommandArgument='<%# Eval("Title") %>' class="btn btn-sm btn-primary">View</asp:LinkButton>
                            <asp:LinkButton runat="server" class="btn btn-sm btn-success">Sign</asp:LinkButton>
                            <asp:LinkButton runat="server" class="btn btn-sm btn-danger">
                                <span class="glyphicon glyphicon-trash"></span>
                            </asp:LinkButton>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
