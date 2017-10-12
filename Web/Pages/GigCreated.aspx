<%@ Page Title="" Language="C#" MasterPageFile="~/MiniVenueSite.Master" AutoEventWireup="true"
 CodeBehind="GigCreated.aspx.cs" Inherits="Web.Pages.GigCreated"  %>
<asp:Content ID="content" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <p>
        <asp:Label ID="lblGigCreatedTitle" runat="server" meta:resourcekey="lblGigCreated" />
    </p>
    <p>
        <asp:Label ID="lblGigCreatedSubTitle" runat="server" meta:resourcekey="lblGigCreatedId" />
        <strong>
            <asp:Label ID="lblGigCreatedId" runat="server" />
        </strong>
    </p>
</asp:Content>
