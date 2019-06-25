<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ajax.aspx.cs" Inherits="WebApplication1.Ajax" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
          <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>                                                                       
<asp:UpdatePanel ID="UpdatePanel3" runat="server">
<ContentTemplate>
<asp:TextBox ID="txtProduct" runat="server" Width="180px" Height="25px" ></asp:TextBox>    
    <ajaxToolkit:AutoCompleteExtender ID="actProduct" runat="server" 
    ServicePath="WebService1.asmx"                                                          
    TargetControlID="txtProduct"                                                               
    ServiceMethod="GetDataList"                                                              
    MinimumPrefixLength="1"                                                                     
    CompletionInterval="100"                                                                    
    CompletionListCssClass="autocomplete_completionListElement"                                
    CompletionListItemCssClass="autocomplete_listItem" 
    CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" >
    </ajaxToolkit:AutoCompleteExtender>
    </ContentTemplate>  
    </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>