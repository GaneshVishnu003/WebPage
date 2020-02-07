<%@ Page Language="C#" MasterPageFile="MasterPage.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="WebPage.SignUp" %>
<asp:Content ID="contentHead" runat="server" ContentPlaceHolderID="head">
    </asp:Content>
        <asp:Content ID="contentPlaceHolderLogin" runtat="server" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div>

            <table>
                <tr>
                    <td>First Name</td>
                    <td>
                        <asp:TextBox runat="server" ID="txtFirst" placeholder="Enter the fist name" /></td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorFirstName" runat="server"
                            ErrorMessage="First Name is Required" ControlToValidate="txtFirst"> </asp:RequiredFieldValidator>
                    </td>

                </tr>
                <tr>
                    <td>Last Name</td>
                    <td>
                        <asp:TextBox runat="server" type="text" ID="txtLast" required="required" placeholder="Enter the last name" /></td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorLastName" runat="server"
                            ErrorMessage="Last Name is Required" ControlToValidate="txtLast"> </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Mobile Number</td>
                    <td>
                        <asp:TextBox runat="server" type="number" ID="mobileNum" required="required" placeholder="Enter the mobile number" /></td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorMobile" runat="server"
                            ErrorMessage="Mobile Number is Required" ControlToValidate="mobileNum"> </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Mail Id</td>
                    <td>
                        <asp:TextBox runat="server" type="email" ID="mail" required="required" placeholder="Enter the mail id" /></td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorMail" runat="server"
                            ErrorMessage="Mail is Required" ControlToValidate="mail"> </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Location</td>
                    <td>
                        <asp:TextBox runat="server" type="text" ID="txtlocation" required="required" placeholder="Enter your location" /></td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorLocation" runat="server"
                            ErrorMessage="Location is Required" ControlToValidate="txtlocation"> </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Password</td>
                    <td>
                        <asp:TextBox runat="server" type="password" ID="txtPassword" required="required" placeholder="Enter the password" /></td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server"
                            ErrorMessage="Password is Required" ControlToValidate="txtPassword"> </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Confirm Password</td>
                    <td>
                        <asp:TextBox runat="server" type="password" ID="txtConPassword" required="required" /></td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorConfirm" runat="server"
                            ErrorMessage="Confirm the password" ControlToValidate="txtConPassword"> </asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:CompareValidator runat="server" ID="cmpNumbers" ControlToValidate="txtPassword" ControlToCompare="txtConPassword" ErrorMessage="The passwords doesn't match" /></td>
                </tr>
            </table>
            <asp:Button runat="server" ID="signup" Text="SignUp" OnClick="signup_Click"></asp:Button>
        </div>
  </asp:Content>
