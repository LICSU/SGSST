<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Empresa.aspx.cs" Inherits="source_Empresa" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:UpdatePanel ID="upEmpresa" runat="server">
            <ContentTemplate>
                <asp:GridView ID="GridView1" CssClass="footable" 
                              runat="server" Width="90%" HorizontalAlign="Center"
                              OnRowCommand="GridView1_RowCommand" AutoGenerateColumns="false" AllowPaging="true"
                              DataKeyNames="ClaseID"  PageSize="20"
                              onpageindexchanging="GridView1_PageIndexChanging">
                    <Columns>

                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
