<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomForm.aspx.cs" Inherits="ValidationsPrj.CustomForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Custom Validation JS Enabled</title>
    <script type="text/javascript">
        function IsEven(source, args) {
            if (args.Value == "") {
                args.IsValid = false;
                alert("Empty Text, Enter Valid Data..");
            }
            else if ((args.Value > 0) && (args.Value % 2 == 0)) {
                    args.IsValid = true;
                    alert("Validation Suceeded");
                }
                else {
                    args.IsValid = false;
                    alert("Validation Failed...");
                }
            }
                function IsOdd(source, args) {
                    if (args.Value == "") {
                        args.IsValid = false;
                        alert("Empty Text, Enter Valid Data..");
                    }
                    else if ((args.Value > 0) && (args.Value % 2 != 0)) {
                            args.IsValid = true;
                            alert("Odd Number Validation Succeeded");
                        }
                        else {
                            args.IsValid = false;
                            alert("Validation Failed... Enter Positive Odd Number");
                        }
                    }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Please Enter a Positive Even Number : &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtnum" runat="server"></asp:TextBox>
            &nbsp;&nbsp;
            <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="txtnum" ErrorMessage="Not a Positive or Even Number" ForeColor="Red" OnServerValidate="CustomValidator1_ServerValidate" ClientValidationFunction="IsEven" ValidateEmptyText="True"></asp:CustomValidator>
            <br />
            <br />
            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
            <br /><br />
            <asp:label ID="lblmsg" runat="server"></asp:label>
        </div>
        <div>
            Please Enter a Positive Odd Number :
            <asp:TextBox ID="txtnum1" runat="server"></asp:TextBox>
            &nbsp;&nbsp;
            <asp:CustomValidator ID="CustomValidator2" runat="server" ControlToValidate="txtnum1" ErrorMessage="Not a Positive Odd Number" ForeColor="Red" ClientValidationFunction="IsOdd" OnServerValidate="CustomValidator2_ServerValidate" ValidateEmptyText="True"></asp:CustomValidator>
            <br /><br />
            <asp:Button ID="btnSave1" runat="server" Text="Save" OnClick="btnSave_Click" />
            <br /><br />
            <asp:Label ID="lblmsg1" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
