<%@ Page Language="C#"
    MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true"
    CodeBehind="Billing.aspx.cs"
    Inherits="ElectricityBilling_Prj.Billing" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

    <h3>Electricity Bill Entry</h3>

    Consumer Number:<br />
    <asp:TextBox ID="txtConsumerNumber" runat="server"></asp:TextBox>
    <br /><br />

    Consumer Name:<br />
    <asp:TextBox ID="txtConsumerName" runat="server"></asp:TextBox>
    <br /><br />

    Units Consumed:<br />
    <asp:TextBox ID="txtUnits" runat="server"></asp:TextBox>
    <br /><br />
     Bill Date:<br />
    <asp:TextBox ID="txtBillDate" runat="server" TextMode="Date"></asp:TextBox>
    <br /><br />
    <asp:Button ID="btnCalculate"
        runat="server"
        Text="Calculate Bill"
        OnClick="btnCalculate_Click" />
    <br /><br />
     Last Month Bill Amount:<br />
    <asp:Label ID="lblLastMonthBill"
        runat="server"
        ForeColor="DarkGreen"></asp:Label>
    <br /><br />
    <asp:Label ID="lblResult"
        runat="server"
        ForeColor="Blue"></asp:Label>

</asp:Content>
