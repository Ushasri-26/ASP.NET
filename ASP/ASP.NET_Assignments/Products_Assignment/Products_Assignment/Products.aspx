<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="Products_Assignment.Products" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        Select a Product:
        <asp:DropDownList ID="ddl" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_SelectedIndexChanged">
            <asp:ListItem 
                Text="All" Value="All">
            </asp:ListItem>
            <asp:ListItem>Desktop</asp:ListItem>
            <asp:ListItem>Laptop</asp:ListItem>
            <asp:ListItem>Phone</asp:ListItem>
            <asp:ListItem>TV</asp:ListItem>
            <asp:ListItem>Watch</asp:ListItem>
            
        </asp:DropDownList>
        <br />
        <br />
        <asp:Image ID="img" runat="server" Height="200px" Width="200px" />
        <br />
        <br />
        <asp:Button ID="btn" runat="server" Text="Get Price" OnClick="btn_Click" />
        <br />
        <br />
        <br />
        <br />
        <asp:Label ID="lbl" runat="server" Text=""></asp:Label>
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Product Id"/>
                <asp:BoundField DataField="PName" HeaderText="Product Name" />
                <asp:BoundField DataField="Price" HeaderText="Price" />
            </Columns>
                <HeaderStyle BackColor="Blue" ForeColor="White" />
                <RowStyle BackColor="White" ForeColor="Red" />
                <PagerStyle BackColor="Red" ForeColor="White"  HorizontalAlign="Center"/>
        </asp:GridView>
        <br />
        <br />
    </form>
</body>
</html>
