<%@ Page Title="" Language="C#" MasterPageFile="~/MiniVenueSite.Master" 
AutoEventWireup="true" CodeBehind="CreateGig.aspx.cs" Inherits="Web.Pages.CreateGig"  %>
<asp:Content ID="content" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

  <div id="form">
        <form id="CreateGigForm" method="post" runat="server">
        <div class="field">
            <span class="label">
                <asp:Localize ID="lclNameGig" runat="server" Text="<%$ Resources:Common, gigName %>" />
            </span><span class="entry">
                <asp:TextBox ID="txtGigName" runat="server" Width="300px" Columns="16"></asp:TextBox>
               
                <asp:RequiredFieldValidator ID="rfvGigName" runat="server" ControlToValidate="txtGigName"
                    Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>" 
                CssClass="errorMessage" meta:resourcekey="rfvGigNameResource1"></asp:RequiredFieldValidator>
            </span>
        </div>
        <div class="field">
            <span class="label">
                <asp:Localize ID="lclStartDate" runat="server" Text="<%$ Resources:Common, gigDate %>" /></span>
            <span class="entry">
                <asp:TextBox type="date" ID="txtCal" runat="server" Width="200px" 
                Columns="16" ></asp:TextBox>
               
                <asp:RequiredFieldValidator ID="rfvBalance" runat="server" ControlToValidate="txtCal"
                    Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>" 
                CssClass="errorMessage" ></asp:RequiredFieldValidator>                               
            </span>

        </div>
        <div class="field">
            <span class="label">
                <asp:Localize ID="lclGigType" runat="server" meta:resourcekey="lclGigType" />
            </span><span class="entry">
                <asp:DropDownList ID="ddlGigType" runat="server">
                  
                </asp:DropDownList>
            </span>
            </div>
            
        <div class="button">
            <asp:Button ID="btnCreate" runat="server" meta:resourcekey="btnCreate" OnClick="BtnCreateClick" />
        </div>
        </form>
    </div>
    <br />
    <br />
</asp:Content>
