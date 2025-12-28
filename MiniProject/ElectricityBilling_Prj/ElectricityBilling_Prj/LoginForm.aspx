<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="LoginForm.aspx.cs" Inherits="ElectricityBilling_Prj.LoginForm" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">

    <h2>Admin Login</h2>

    <asp:Label Text="Username" runat="server" /><br />
    <asp:TextBox ID="txtUsername" runat="server" /><br /><br />

    <asp:Label Text="Password" runat="server" /><br />
    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" /><br /><br />

    <asp:Button ID="btnLogin"
        runat="server"
        Text="Login"
        OnClick="btnLogin_Click" /><br /><br />

    <asp:Label ID="lblMessage"
        runat="server"
        ForeColor="Red" />

</asp:Content>