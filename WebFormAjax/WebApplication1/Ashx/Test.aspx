<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="WebApplication1.Ashx.Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="../Scripts/jquery-3.3.1.js"></script>
</head>
<body>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <input type="button" value="123" onclick="add()" /><asp:Button ID="Button1" runat="server" Text="Button" />
</body>
</html>
<script>
    function add() {
        $.ajax({
            url: "MyHandler.ashx?Id=1&Name=张聪",
            type: "post",
            dataType: "json",
            contentType:"application/json",
            success: function (json) {
                alert(json);
            }
        })
    }
</script>
