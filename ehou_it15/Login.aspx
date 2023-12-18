<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ehou_it15.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form action="/" method="post">
        <h3>Log in
        </h3>
        <table>
            <tr>
                <td>Username:</td>
                <td>
                    <input id="txtUsername" type="text" runat="server"></td>
                <td>
                    <asp:RequiredFieldValidator ControlToValidate="txtUsername"
                        Display="Static" ErrorMessage="*" runat="server"
                        ID="vUsername" /></td>
            </tr>
            <tr>
                <td>Password:</td>
                <td>
                    <input id="txtPassword" type="password" runat="server"></td>
                <td>
                    <asp:RequiredFieldValidator ControlToValidate="txtPassword"
                        Display="Static" ErrorMessage="*" runat="server"
                        ID="vPassword" />
                </td>
            </tr>
            <tr>
                <td>Persistent Cookie:</td>
                <td>
                    <asp:CheckBox ID="chkPersistCookie" runat="server" AutoPostBack="false" /></td>
                <td></td>
            </tr>
        </table>
        <input type="submit" value="DoLogin" runat="server" id="btnLogin"><p></p>
        <asp:Label ID="lblMsg" ForeColor="red" Font-Name="Verdana" Font-Size="10" runat="server" />
    </form>
</asp:Content>
