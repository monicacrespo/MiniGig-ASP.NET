<%@ Page Title="" Language="C#" MasterPageFile="~/MiniVenueSite.Master" 
AutoEventWireup="true" CodeBehind="ShowGigByGigID.aspx.cs" 
Inherits="Web.Pages.ShowGigByGigID" meta:resourcekey="PageResource1" %>
<asp:Content ID="content" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <asp:Table CssClass="gigDetails" ID="TableGigInfo" runat="server" 
        meta:resourcekey="TableGigInfoResource1">
        <asp:TableRow ID="TableRow1" runat="server" >
            <asp:TableHeaderCell ID="cellCaptionGigID" runat="server" 
                Text="<%$ Resources:Common, gigId %>"></asp:TableHeaderCell>
            <asp:TableCell ID="cellGigID" runat="server" 
               ></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="TableRow2" runat="server" >
            <asp:TableHeaderCell ID="cellCaptionName" runat="server" 
                Text="<%$ Resources:Common, gigName %>" ></asp:TableHeaderCell>
            <asp:TableCell ID="cellName" runat="server" ></asp:TableCell>
        </asp:TableRow>
         <asp:TableRow ID="TableRow3" runat="server">
            <asp:TableHeaderCell ID="cellCaptionDate" runat="server" 
                 Text="<%$ Resources:Common, gigDate %>"></asp:TableHeaderCell>
            <asp:TableCell ID="cellDate" runat="server" ></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="TableRow4" runat="server">
            <asp:TableHeaderCell ID="cellCaptionType" runat="server" 
                Text="<%$ Resources:Common, gigType %>"></asp:TableHeaderCell>
            <asp:TableCell ID="cellType" runat="server"></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
