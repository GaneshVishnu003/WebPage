<%@ Page Language="C#" EnableEventValidation="false" MasterPageFile="MasterPage.Master" AutoEventWireup="true" CodeBehind="ViewLocations.aspx.cs" Inherits="WebPage.ViewLocations" %>

<asp:Content ID="contentView" runat="server" ContentPlaceHolderID="head">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="idLocationView1" runat="server" AutoGenerateColumns="False" 
        ShowFooter="true" DataKeyNames="id" Width="219px" OnSelectedIndexChanged="idLocationView1_SelectedIndexChanged">
        <Columns>
            <%-- <asp:BoundField DataField="location" HeaderText="Operable Locations" />--%>
            <asp:TemplateField HeaderText="Operable Locations">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("location") %>' runat="server" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtLocation" Text='<%# Eval("location") %>' runat="server" />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtLocationFooter" runat="server" />
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ImageUrl="~/images/edit.png" alt="edit" runat="server" 
                        CommandName="Edit" ToolTip="Edit" Width="20px" Height="20px" />
                    <asp:ImageButton ImageUrl="~/images/delete.png" alt="delete" runat="server"  CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:ImageButton ImageUrl="~/images/save.png" alt="edit" runat="server" CommandName="Update" ToolTip="Update" Width="20px" Height="20px" />
                    <asp:ImageButton ImageUrl="~/images/cancel.png" alt="delete" runat="server" CommandName="Cancel" ToolTip="Cancel" Width="20px" Height="20px" />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:ImageButton ImageUrl="~/images/addnew.png" alt="delete" runat="server" OnClick="CallAdd" CommandName="Addnew" ToolTip="Addnew" Width="20px" Height="20px" />
                </FooterTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <br />
    <asp:Label ID="lblSuccess" Text="Success" runat="server" ForeColor="Green" />
    <asp:Label ID="lblFailure" Text="Fail" runat="server" ForeColor="Red" />
</asp:Content>
