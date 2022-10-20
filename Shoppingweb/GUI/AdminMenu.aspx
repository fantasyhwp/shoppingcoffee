 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminMenu.aspx.cs" Inherits="Shoppingweb.GUI.Admin.AdminMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background:#808080; margin:0;padding:0;">
    <form id="form1" runat="server">
        <div>
            <table align="center">
                <tr align="center"><td><a href="user.aspx" target="shopping"></a></>UserManager</td></tr>
                <tr align="center"><td><a href="AdminProducesPage.aspx" target="shopping"></a>ProduceManager</td></tr>
                <tr align="center"><td><a href="" target="shopping"></a>OrderManager</td></tr>
                <tr align="center"><td><a href="" target="shopping"></a>product release</td></tr>
            </table>
        </div>
    </form>
</body>
</html>
