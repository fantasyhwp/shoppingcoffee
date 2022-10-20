<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Shoppingweb.GUI.HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
    <link href="../CSS/HomePageStyleSheet.css" rel="stylesheet" type="text/css" />
    
    <style type="text/css">
        .auto-style1 {
            margin-top: 0px;
        }
    </style>
    
    </head>
<body>
    <form id="form1" runat="server">
        <div>
        <header>
            <ul>
                <li><a href="LoginPage.aspx">Login</a></li>
                <h1 id="title">Coffe Shopping</h1>
            </ul>
        </header>
             <br />
            <br />
            <br />
            <br />
            <br />
            <br />
             <asp:Button ID="ButtonSearch" runat="server" OnClick="ButtonSearch_Click" autopostback="false" Text="Search" CssClass="btn" style="margin-left:100px; margin-top: 0px;" Height="70px" Width="140px"/>
             <asp:TextBox ID="txtsearch" runat="server" CssClass="auto-style1" Height="47px" Width="287px"></asp:TextBox>
        </div><br/>
          <asp:GridView ID="gvProduces" runat="server" AutoGenerateColumns="False" AllowPaging="True"
    OnPageIndexChanging="OnPaging" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
    <Columns>
        <asp:BoundField DataField="Title" HeaderText="Title" ItemStyle-Width="150" >
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="Price" HeaderText="Price" ItemStyle-Width="150" >
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="Num" HeaderText="Num" ItemStyle-Width="150" >
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="Image" HeaderText="Image" ItemStyle-Width="150" >
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="Information" HeaderText="Information" ItemStyle-Width="150" >
        
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        
    </Columns>
              <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
              <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
              <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
              <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
              <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
              <SortedAscendingCellStyle BackColor="#FFF1D4" />
              <SortedAscendingHeaderStyle BackColor="#B95C30" />
              <SortedDescendingCellStyle BackColor="#F1E5CE" />
              <SortedDescendingHeaderStyle BackColor="#93451F" />
</asp:GridView>
        <footer id="footer">
            <nav id="navbar">
                <div class="container">
                    <ul>
                        <li style="font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif"><asp:HyperLink NavigateUrl="" runat="server" CssClass="Hyper">Service</asp:HyperLink></li>
                        <li style="font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif"><asp:HyperLink NavigateUrl="" runat="server" CssClass="Hyper">Privacy Policy</asp:HyperLink></li>
                        <li style="font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif"><asp:HyperLink NavigateUrl="" runat="server" CssClass="Hyper">About Us</asp:HyperLink></li>
                        <li style="font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif"><asp:HyperLink NavigateUrl="" runat="server" CssClass="Hyper">Contact Us</asp:HyperLink></li>
                    </ul>
                </div>
    </nav>
        <p>Copyright &copy; 2022 - ShoppingCoffee</p>
    </footer>
        <asp:Label ID="lblmessage" runat="server"></asp:Label>
    </form>
    
</body>
</html>
