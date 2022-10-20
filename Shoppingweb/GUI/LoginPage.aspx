<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/MasterPage.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="Shoppingweb.GUI.LoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            margin-left: 65px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                    <div class="divLoginFormView">
                        <asp:Image ID="imgLoginFormLogoSignIN" runat="server" ImageUrl="~/Images/login.jpg" Height="180px" Width="220px" /><br />
                        <asp:Label ID="lblLoginSignIN" runat="server" Text="Email" CssClass="cssclassLabel"></asp:Label><br />
                        <asp:TextBox ID="txtboxLoginSignIn" runat="server" CssClass="cssclassTextBox"></asp:TextBox><br />
                        <br />
                        <asp:Label ID="lblPasswordSignIN" runat="server" Text="Password" CssClass="cssclassLabel"></asp:Label><br />
                        <asp:TextBox ID="txtboxPasswordSignIN" runat="server" CssClass="cssclassTextBox"></asp:TextBox><br />
                        <asp:Image runat="server" ID="VDCode" CssClass="icoimg" ImageUrl="VDC.aspx" Height="39px" Width="102px"></asp:Image>
                        <br />
                        <asp:Label ID="LabelCheckCode" runat="server" Text="Verification Code :" CssClass="labelInfo"></asp:Label>
                        <asp:TextBox ID="TxtCheckCode" runat="server" CssClass="cssclassTextBox"></asp:TextBox><br />
                        <br />
                        <asp:Button ID="btnLoginSignIN" runat="server" Text="Login" CssClass="cssclassLogRegButton" OnClick="btnLoginSignIN_Click" Width="74px"/>
                        <asp:Button ID="btnRegister" runat="server" CssClass="auto-style1" PostBackUrl="~/GUI/Register.aspx" Text="Register" />
                        <br />
                        <br />
                    </div>
</asp:Content>
