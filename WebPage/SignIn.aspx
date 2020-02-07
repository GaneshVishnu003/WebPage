<%@ Page Language="C#" MasterPageFile="MasterPage.Master" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="WebPage.SignIn" %>
<asp:Content ID="contentHead" runat="server" ContentPlaceHolderID="head">
    </asp:Content>
        <asp:Content ID="contentPlaceHolderLogin" runtat="server" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div>
            <table>
            <tr>
                <td>User Name</td>
                <td><asp:TextBox runat="server" type="email" id="txtUser"/></td>
            </tr>
            <tr>
                <td>Password</td>
                <td><asp:TextBox runat="server" type="password" id="txtPassword"/></td>
            </tr>
        </table>
        <asp:Button runat="server" text="signIn" OnClick="Unnamed1_Click"></asp:Button>
        <asp:Button runat="server" text="signUp" OnClick="Unnamed2_Click"></asp:Button>
        </div>
    </asp:Content>