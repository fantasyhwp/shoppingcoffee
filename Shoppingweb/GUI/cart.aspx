<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cart.aspx.cs" Inherits="Shoppingweb.GUI.cart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" CssClass="table table-hover table-responsive" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1" OnRowUpdated="GridView1_RowUpdated" OnRowDeleted="GridView1_RowDeleted" CellPadding="4" ForeColor="#333333" GridLines="None" Height="227px" Width="589px" EmptyDataText="No Particular Product Available in Shopping Cart">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" Visible="false" SortExpression="ID" />
                    <asp:BoundField DataField="ProductID" HeaderText="ProductID" ReadOnly="true" SortExpression="ProductID" />
                    <asp:ImageField DataImageUrlField="Images" HeaderText="ProductImg">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:ImageField>
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                    <asp:BoundField DataField="ProductPrice" HeaderText="ProductPrice" ReadOnly="true" SortExpression="ProductPrice" />
                    <asp:BoundField DataField="TotalPrice" HeaderText="TotalPrice" ReadOnly="true" SortExpression="TotalPrice" />
                    <asp:BoundField DataField="Produceid" HeaderText="Produceid" SortExpression="Produceid" Visible="false" />
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ShoppingConnectionString %>" DeleteCommand="DELETE FROM [t_shoppingCar] WHERE [ID] = @ID"
                InsertCommand="INSERT INTO [t_shoppingCar] ([Productid], [Quantity], [ProductPrice], [TotalPrice], [Produceid]) VALUES (@Productid, @Quantity, @ProductPrice, @TotalPrice, @Produceid)"
                SelectCommand="SELECT * FROM [t_shoppingCar] WHERE ([Produceid] = @Produceid)"
                UpdateCommand="UPDATE [t_shoppingCar] SET [Quantity] = @Quantity, [TotalPrice] = @Quantity*ProductPrice WHERE [ID] = @ID">
                <DeleteParameters>
                    <asp:Parameter Name="ID" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="Productid" Type="Int32" />
                    <asp:Parameter Name="Quantity" Type="Int32" />
                    <asp:Parameter Name="ProductPrice" Type="Decimal" />
                    <asp:Parameter Name="TotalPrice" Type="Decimal" />
                    <asp:Parameter Name="Produceid" Type="String" />
                </InsertParameters>
                <SelectParameters>
                    <asp:SessionParameter Name="Produceid" SessionField="Produceid" Type="String" />
                </SelectParameters>
                <UpdateParameters>
                   <asp:Parameter Name="Productid" Type="Int32" />
                    <asp:Parameter Name="Quantity" Type="Int32" />
                    <asp:Parameter Name="ProductPrice" Type="Decimal" />
                    <asp:Parameter Name="TotalPrice" Type="Decimal" />
                    <asp:Parameter Name="Produceid" Type="String" />
                    <asp:Parameter Name="ID" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>

            <br />
            <br />
                        <div class="row">
                <div class="pull-right col-md-3">
                    Total Amount:&nbsp; <asp:Label ID="lblTotalAmount" runat="server" Text="Label"></asp:Label>
                    <br />
                    <br />
                    <asp:Button ID="btnCheckout" CssClass="btn btn-success" runat="server" Text="Checkout" OnClick="btnCheckout_Click" />
                    <br />
                    <br />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
