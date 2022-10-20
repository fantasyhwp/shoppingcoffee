<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/MasterPage.Master" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="Shoppingweb.GUI.Payment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="payment.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <section id="cart">
                <h4>Cart <span class="price" style="color: black"><i class="fa fa-shopping-cart"></i><b>4</b></span></h4>
                <p><a href="#">Product 1</a> <span class="price">$15</span></p>
                <p><a href="#">Product 2</a> <span class="price">$5</span></p>
                <p><a href="#">Product 3</a> <span class="price">$8</span></p>
                <p><a href="#">Product 4</a> <span class="price">$2</span></p>
                <hr>
                <p>Total <span class="price" style="color: black"><b>$30</b></span></p>
    </section> 
    <section id="payment">
        <h3>Payment</h3>
        <label for="fname">Accepted Cards</label>
        <div class="icon-container">
            <i class="fa fa-cc-visa" style="color: navy;"></i>
            <i class="fa fa-cc-amex" style="color: blue;"></i>
            <i class="fa fa-cc-mastercard" style="color: red;"></i>
        </div>
        <label for="cname">Name on Card</label>
        <asp:TextBox ID="ccName" CssClass="tb1" placeholder="" runat="server"></asp:TextBox>
        <br />
        <label for="ccnum">Credit card number</label>
        <asp:TextBox CssClass="tb1" ID="ccNum" placeholder="" runat="server"></asp:TextBox>
        <br />
        <label for="expmonth">Exp Month</label>
        <asp:TextBox CssClass="tb1" ID="expMonth" placeholder="" runat="server"></asp:TextBox>
        <br />
        <label for="expyear">Exp Year</label>
        <asp:TextBox CssClass="tb1" ID="expYear" placeholder="" runat="server"></asp:TextBox>
        <br />
            <label for="cvv">CVV</label>
            <asp:TextBox CssClass="tb1" ID="CVV" runat="server" placeholder=""></asp:TextBox>
        <br />
        <asp:Button ID="payButton" runat="server" Text="Pay" CssClass="btns" Width="170px" />

    </section>
</asp:Content>
