<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebApplication1.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" Text="新增" PostBackUrl="~/Add.aspx" />
        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" style="margin-right: 175px" Width="581px" OnRowCommand="GridView1_RowCommand" DataKeyNames="Id" >
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" />
                <asp:BoundField DataField="Name" HeaderText="用户名" />
                <asp:ButtonField CommandName="upd" HeaderText="编辑" Text="编辑" />
                <asp:ButtonField CommandName="del" HeaderText="删除" Text="删除" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label><asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button2_Click" />


        <select id="sel" name="sel" runat="server">
            <%=aa %>
        </select>
        <asp:Button ID="Button3" runat="server" Text="Button" OnClick="Button3_Click" />

    </form>
</body>
</html>
