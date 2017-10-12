<%@ Page Title="" Language="C#" MasterPageFile="~/MiniVenueSite.Master" AutoEventWireup="true" CodeBehind="FindGig.aspx.cs" Inherits="Web.Pages.FindGig" meta:resourcekey="PageResource1" %>
<asp:Content ID="content" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div id="form">
        <form id="FindForm" method="post" runat="server">
        <div class="field">
            <span class="label">
                <asp:Localize ID="lclIdentifier" runat="server" Text="<%$ Resources:Common, gigId %>" />
            </span><span class="entry">
                <asp:TextBox ID="txtIdentifier" runat="server" Width="200px" Columns="16" 
                />
                <asp:RegularExpressionValidator ID="typeValidator" runat="server" ControlToValidate="txtIdentifier"
                    ValidationExpression="(\d)*" Text="<%$ Resources:Common, typeError %>" 
                Display="Dynamic"  />
                <asp:RequiredFieldValidator ID="rfvIdentifier" runat="server" ControlToValidate="txtIdentifier"
                    Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>" 
                CssClass="errorMessage"  />
                <asp:Label CssClass="errorMessage" ID="lblIdentifierError" runat="server" meta:resourcekey="lblIdentifierError" />
            </span>
        </div>
        <div class="button">
            <asp:Button ID="btnFind" runat="server" meta:resourcekey="btnFind" OnClick="BtnFindClick" />
        </div>
        </form>
    </div>
    <br />
    <br />
</asp:Content>
