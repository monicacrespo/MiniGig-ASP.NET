<%@ Page Title="" Language="C#" MasterPageFile="~/MiniVenueSite.Master" 
AutoEventWireup="true" CodeBehind="FindGigsByDate.aspx.cs" 
Inherits="Web.Pages.FindGigs"  %>
<asp:Content ID="content" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
 <form id="CreateGigForm" method="post" runat="server">
     <div class="field">
            <span class="label">
                <asp:Localize ID="lclStartDate" runat="server" meta:resourcekey="lclStartDate"  /></span>
            <span class="entry">
                <asp:TextBox ID="txtCalStartDate" name= "txtCalStartDate" type="date" runat="server" Width="200px" Columns="16" ></asp:TextBox>
               
                <asp:RequiredFieldValidator ID="rfvStartDate" runat="server" 
                    ControlToValidate="txtCalStartDate"
                    Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>" 
                    CssClass="errorMessage" ></asp:RequiredFieldValidator>
                
                
            </span>

        </div>
    
     <div class="field">
        <span class="label">
            <asp:Localize ID="lclEndDate" runat="server" meta:resourcekey="lclEndDate"  /></span>
        <span class="entry">
            <asp:TextBox ID="txtCalEndDate" name= "txtCalEndDate" type="date" runat="server" Width="200px" Columns="16"></asp:TextBox>
               
            <asp:RequiredFieldValidator ID="rfvEndDate" runat="server" 
                ControlToValidate="txtCalEndDate"
                Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>" 
                CssClass="errorMessage"></asp:RequiredFieldValidator>
                
           
        </span>

    </div>
      <div class="button">
            <asp:Button ID="btnFind" runat="server" meta:resourcekey="btnFind" OnClick="BtnFindClick" />
        </div>
</form>
</asp:Content>
