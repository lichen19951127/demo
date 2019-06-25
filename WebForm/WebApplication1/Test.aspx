<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="WebApplication1.Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
           <asp:Repeater runat="server" ID="rpList" OnItemDataBound="rpList_ItemDataBound">
            <ItemTemplate>
                <div class="catItem">
                    <h2>
                        <%#Eval("DataValue")%> </h2>
                    <div class="catType">
                        <asp:Repeater runat="server" ID="rpListSub">
                            <ItemTemplate>
                                <a href="catgory2.aspx?id=<%#Eval("Id")%>"><%#Eval("Name")%></a>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                <a href="#" class="cat-more"></a>
            </div>
       </ItemTemplate>
</asp:Repeater>
        </div>
    </form>
</body>
</html>
