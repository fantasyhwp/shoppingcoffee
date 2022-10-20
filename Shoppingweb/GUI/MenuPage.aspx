<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/MasterPage.Master" AutoEventWireup="true" CodeBehind="MenuPage.aspx.cs" Inherits="Shoppingweb.GUI.MenuPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            top: 25px;
            left: 25px;
            position: relative;
            width: 115px;
            height: 237px;
        }
        .auto-style2 {
            margin-top: 16px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="text-align: center" class="auto-style1">
        <tr>      
            <th colspan="2" style="font-size: x-large">Sort by<br />
            </th>
        </tr>
        <tr>
            <th>
                <asp:Label ID="Label5" runat="server" Text="Price" Font-Size="Large"></asp:Label>
            </th>
            <td>
                <asp:DropDownList ID="sortPrice" runat="server" AutoPostBack="True" OnSelectedIndexChanged="sortPrice_SelectedIndexChanged">
                    <asp:ListItem Selected="True">Random</asp:ListItem>
                    <asp:ListItem>Low to High</asp:ListItem>
                    <asp:ListItem>High to Low</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <br />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <th colspan="2" style="font-size: large">Find Product(s)
            </th>
        </tr>
        <tr>
            <td colspan="2">
                <asp:TextBox ID="searchProducts" runat="server" Style="width: 150px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <br />
                <asp:Button ID="btnSearch" runat="server" Text="Search" Font-Size="large" OnClick="btnSearch_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:HyperLink ID="gotoAll" runat="server" ForeColor="Black" ImageUrl="~/Images/icon.jpg" NavigateUrl="~/MenuPage.aspx">Show All Products</asp:HyperLink>
            </td>
        </tr>

    </table>
    <asp:DataList ID="productsDisplay" runat="server" DataKeyField="Title" DataSourceID="SqlDataSource1" OnItemCommand="productsDisplay_ItemCommand" OnItemDataBound="productsDisplay_ItemDataBound" RepeatColumns="4" RepeatDirection="Horizontal" OnSelectedIndexChanged="sortPrice_SelectedIndexChanged1">
        <ItemTemplate>
            <table runat="server" border="1" class="auto-style1" style="border-collapse: collapse;">
                <tr>
                    <td style="text-align: center">
                        <asp:Image ID="Image1" runat="server" Height="256" ImageUrl='<%# Eval("Image") %>' onerror="this.onerror=null;this.src=''" Style="z-index: 1; position: relative" />
                    </td>
                </tr>
                <tr style="border: none">
                    <td style="text-align: center">
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="x-Large" Style="z-index: 1; position: relative" Text='<%# Eval("Title") %>'></asp:Label>
                    </td>
                </tr>
                <tr style="border: none">
                    <td>
                        <asp:Label ID="Label4" runat="server" Font-Size="x-Large" Text="$: "></asp:Label>
                        <asp:Label ID="Label2" runat="server" Font-Size="x-Large" Style="z-index: 1; position: relative" Text='<%# Eval("price") %>'></asp:Label>
                    </td>
                </tr>
                <tr style="border: none">
                    <td style="z-index: 1; text-align: center">Select Quantity
                        <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="ddlQuantity_SelectedIndexChanged">
                             <asp:ListItem Selected="True">1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2" style="text-align: center">
                        <asp:ImageButton ID="ImageButton1" runat="server" CommandArgument='<%# Eval("Title") %>' CommandName="addtocart" Height="50px" ImageUrl="~/Images/addtocart.png" Style="z-index: 1; position: relative" />
                    </td>
                </tr>                
            </table>
            <br />
            <br />
        </ItemTemplate>
    </asp:DataList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ShoppingConnectionString %>" SelectCommand="SELECT * FROM Produces ORDER BY Title"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ShoppingConnectionString %>" SelectCommand="SELECT * FROM [Produces] WHERE ([keywords] LIKE '%' + @keywords + '%')">
        <SelectParameters>
            <asp:ControlParameter ControlID="searchProducts" PropertyName="Text" Name="keywords" Type="String"></asp:ControlParameter>
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ShoppingConnectionString %>" SelectCommand="SELECT * FROM Produces ORDER BY [price]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:ShoppingConnectionString %>" SelectCommand="SELECT * FROM Produces ORDER BY [price] DESC"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:ShoppingConnectionString %>" SelectCommand="SELECT * FROM Produces ORDER BY Title"></asp:SqlDataSource>
</asp:Content>
