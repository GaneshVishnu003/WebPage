<%@ Page Language="C#" MasterPageFile="MasterPage.Master" AutoEventWireup="true" CodeBehind="ViewLocations.aspx.cs" Inherits="WebPage.ViewLocations" %>

<asp:Content ID="contentView" runat="server" ContentPlaceHolderID="head">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="idLocationView1" runat="server" AutoGenerateColumns="False" Width="182px">
        <Columns>
            <asp:BoundField DataField="location" HeaderText="Operable Locations" />
        </Columns>
    </asp:GridView>
</asp:Content>
