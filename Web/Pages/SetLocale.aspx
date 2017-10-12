<%@ Page Title="" Language="C#" MasterPageFile="~/MiniVenueSite.Master" 
AutoEventWireup="true" CodeBehind="SetLocale.aspx.cs" Inherits="Web.Pages.SetLocale" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div id="form">
        <form id="SetLocaleForm" method="post" runat="server">
        <div class="field">
            <span class="label">
                <asp:Localize ID="lclLanguage" runat="server" meta:resourcekey="lclLanguage" />
            </span><span class="entry">
                <asp:DropDownList ID="comboLanguage" runat="server" AutoPostBack="True" Width="200px"
                     
                meta:resourcekey="comboLanguageResource1">
                </asp:DropDownList>

               
            </span>
        </div>
       
        <div class="button">
            <asp:Button ID="btnSetLocale" runat="server" OnClick="BtnSetLocaleClick" meta:resourcekey="btnSetLocale" />
        </div>
        </form>
      </div>
</asp:Content>
