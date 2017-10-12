<%@ Page Title="" Language="C#" MasterPageFile="~/MiniVenueSite.Master"
 AutoEventWireup="true" CodeBehind="ShowGigsByDate.aspx.cs" Inherits="Web.Pages.ShowGigsByDate" meta:resourcekey="PageResource1" %>
<asp:Content ID="content" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
 
    <p>
        <asp:Label ID="lblInvalidGig" meta:resourcekey="lblInvalidGig" 
        runat="server" Visible="False"></asp:Label>
    </p>
    

    <form runat="server">
    <asp:GridView ID="gvGigsByDate" runat="server" CssClass="gigsByDate" 
        AutoGenerateColumns="False" 
        onpageindexchanging="GvGigsByDatePageIndexChanging" 
        ShowHeaderWhenEmpty="True" >
        <Columns>
           <asp:BoundField DataField="gigId" HeaderText="<%$ Resources:Common, gigId %>" />
           <asp:BoundField DataField="gigName" HeaderText="<%$ Resources:Common, gigName %>" />
           <asp:BoundField DataField="gigDate" DataFormatString="{0:d}" HtmlEncode=false  HeaderText="<%$ Resources:Common, gigDate %>" />
           <asp:BoundField DataField="MusicType" HeaderText="<%$ Resources:Common, gigType %>" />
        </Columns>
    </asp:GridView>

    <!-- "Previous" and "Next" links. -->
    </form>
   
     <p>
        <asp:Label ID="lblCreatedXMLTitle" runat="server" Visible="False" meta:resourcekey="lblCreatedXML" />  
        <strong>
            <asp:Label ID="lblCreatedXMLFile" Visible="False" runat="server" />
        </strong>
    </p>
</asp:Content>
