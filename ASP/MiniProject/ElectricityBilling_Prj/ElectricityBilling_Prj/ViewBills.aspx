<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ViewBills.aspx.cs" Inherits="ElectricityBilling_Prj.ViewBills" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

    <h3>Retrieve Last N Bills</h3>

    Enter Number of Bills:<br />
    <asp:TextBox ID="txtCount" runat="server"></asp:TextBox>
    <br /><br />

    <asp:Button ID="btnShow"
        runat="server"
        Text="Show Bills"
        OnClick="btnShow_Click" />
    <br /><br />

    <asp:GridView ID="GridView1"
        runat="server"
        AutoGenerateColumns="true"
        BorderWidth="1">
    </asp:GridView>

</asp:Content>
