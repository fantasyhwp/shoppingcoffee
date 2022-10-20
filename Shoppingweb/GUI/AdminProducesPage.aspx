<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminProducesPage.aspx.cs" Inherits="Shoppingweb.GUI.AdminProducesPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <asp:Label ID="lbldisplay" runat="server" Height="50px" Width="221px"></asp:Label>
             <br />
             <asp:GridView ID="datagrid" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager" AutoGenerateColumns="False" HeaderStyle-CssClass="header" EnableViewState="False" RowStyle-CssClass="rows" AllowPaging="True" OnRowDataBound="datagrid_RowDataBound" OnSelectedIndexChanged="datagrid_SelectedIndexChanged" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" Width="494px">
            <Columns>

            </Columns>
                 <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
<HeaderStyle CssClass="header" BackColor="#333333" Font-Bold="True" ForeColor="White"></HeaderStyle>

<PagerStyle CssClass="pager" BackColor="White" ForeColor="Black" HorizontalAlign="Right"></PagerStyle>

<RowStyle CssClass="rows"></RowStyle>
                 <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                 <SortedAscendingCellStyle BackColor="#F7F7F7" />
                 <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                 <SortedDescendingCellStyle BackColor="#E5E5E5" />
                 <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>
        </div>
    </form>
</body>
</html>
