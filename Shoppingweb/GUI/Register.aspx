<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/MasterPage.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Shoppingweb.GUI.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 19px;
        width: 280px;
    }
        .auto-style2 {
            height: 19px;
            width: 128px;
        }
        .auto-style3 {
            width: 128px;
        }
    .auto-style4 {
        width: 128px;
        height: 40px;
    }
    .auto-style5 {
        height: 40px;
        width: 280px;
    }
    .auto-style6 {
        width: 128px;
        height: 31px;
    }
    .auto-style7 {
        height: 31px;
        width: 280px;
    }
    .auto-style8 {
        width: 128px;
        height: 36px;
    }
    .auto-style9 {
        height: 36px;
        width: 280px;
    }
    .auto-style10 {
        width: 64%;
    }
    .auto-style11 {
        width: 280px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <table class="auto-style10">
        <tr>
            <td class="auto-style2">UserName:</td>
            <td class="auto-style1">
                <asp:TextBox ID="txtusername" runat="server" Width="231px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">PassWord:</td>
            <td class="auto-style11">
                <asp:TextBox ID="txtpsw" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style6">R-Password</td>
            <td class="auto-style7">
                <asp:TextBox ID="txtrepsw" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Name:</td>
            <td class="auto-style11">
                <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Address:</td>
            <td class="auto-style11">
                <asp:TextBox ID="txtaddress" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">sex</td>
            <td class="auto-style11">
                <asp:DropDownList ID="dropListsex" runat="server">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem Value="1">Man</asp:ListItem>
                    <asp:ListItem Value="2">Woman</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">PhoneNumber:</td>
            <td class="auto-style11">
                <asp:TextBox ID="txtphonenum" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">Email:</td>
            <td class="auto-style5">
                <asp:TextBox ID="txtemail" runat="server" OnTextChanged="txtemail_TextChanged"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style4"><span style="color: rgba(0, 0, 0, 0.87); font-family: Roboto, RobotoDraft, Helvetica, Arial, sans-serif; font-size: medium; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: nowrap; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">verification:</span></td>
            <td class="auto-style5">
                <asp:TextBox ID="txtverfication" runat="server" OnTextChanged="txtverfication_TextChanged"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style9">
                <asp:Button ID="btnsendemail" runat="server" Text="SendEmailCode" Width="137px" OnClick="btnsendemail_Click1" style="height: 26px" />
            </td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style11">
                <asp:Button ID="btnreg" runat="server" Height="39px" Text="Register" Width="169px" OnClick="btnreg_Click" />
            </td>
        </tr>
    </table>
</asp:Content>

