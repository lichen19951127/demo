﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Index.aspx.vb" Inherits="webform.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            用户名: <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </div>
       <div>
            密码: <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="Button1" runat="server" Text="登录" />
        </div>
    </form>
</body>
</html>
