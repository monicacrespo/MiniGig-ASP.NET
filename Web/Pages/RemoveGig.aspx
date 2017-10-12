<%@ Page Title="" Language="C#" MasterPageFile="~/MiniVenueSite.Master"
 AutoEventWireup="true" CodeBehind="RemoveGig.aspx.cs" Inherits="Web.Pages.RemoveGig" %>
<asp:Content ID="content" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div id="form">
        <form id="FindForm" method="post" runat="server">
        <div class="field">
            <span class="label">
                <asp:Localize ID="lclIdentifier" runat="server"  Text="<%$ Resources:Common, gigId %>" />
            </span><span class="entry">
                <asp:TextBox ID="txtIdentifier" runat="server" Width="200px" Columns="16"/>
                <asp:RegularExpressionValidator ID="typeValidator" runat="server" ControlToValidate="txtIdentifier"
                    ValidationExpression="(\d)*" Text="<%$ Resources:Common, typeError %>" 
                Display="Dynamic" meta:resourcekey="typeValidatorResource1" />
                <asp:RequiredFieldValidator ID="rfvIdentifier" runat="server" ControlToValidate="txtIdentifier"
                    Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>" 
                CssClass="errorMessage" meta:resourcekey="rfvIdentifierResource1" />
                <asp:Label CssClass="errorMessage" ID="lblIdentifierError" runat="server" meta:resourcekey="lblIdentifierError" />
            </span>
        </div>
        <div class="button">
            <asp:Button ID="btnRemove" runat="server" meta:resourcekey="btnRemove" OnClick="BtnRemoveClick" />
        </div>
        </form>
    </div>
    <br />
    <br />
</asp:Content>
