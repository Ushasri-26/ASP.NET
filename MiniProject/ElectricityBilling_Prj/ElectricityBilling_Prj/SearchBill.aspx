<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SearchBill.aspx.cs" Inherits="ElectricityBilling_Prj.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Electricity Bill Report</h3><br /><br />
    Consumer Number:&nbsp;&nbsp;
    <asp:TextBox ID="txtConsumerNumber" runat="server"></asp:TextBox>
    <br /><br />
     Report Type:<br />
    <asp:RadioButtonList ID="rblReportType" runat="server">
        <asp:ListItem Text="Monthly Report" Value="M" />
        <asp:ListItem Text="Yearly Report" Value="Y" />
    </asp:RadioButtonList>
    <br />
       Month:  &nbsp;  &nbsp;  &nbsp;
    <asp:TextBox ID="txtMonth" runat="server"></asp:TextBox>
    <br />
<br />
Year:  &nbsp;  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
    <asp:TextBox ID="txtYear" runat="server"></asp:TextBox>
    <br />
    <br />
     <asp:Button ID="btnSearch"
        runat="server"
        Text="Generate Report"
        OnClick="btnSearch_Click" />

    <br /><br />
    <asp:GridView ID="gvBills"
        runat="server"
        AutoGenerateColumns="true">
    </asp:GridView>

    <br />
    <asp:Label ID="lblMsg"
        runat="server"
        ForeColor="Red"></asp:Label>
</asp:Content>
