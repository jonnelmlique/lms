<%@ Page Title="" Language="C#" MasterPageFile="~/Professor/professorMasterPage.Master" AutoEventWireup="true" CodeBehind="pendingInvite.aspx.cs" Inherits="lms.Professor.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link rel="stylesheet" href="../CSS/ProfessorCSS/pedingInvite.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

   <div class="reports">
       <div class="search-room">
          <asp:TextBox ID="TextBox1" runat="server" CssClass="search-txt" placeholder="Search Room"></asp:TextBox>
 
            <asp:Button ID="Button1" runat="server" Text="Search" CssClass="button-room"/>
              
       </div>

       <div class="invitation-tbl">

       </div>
   </div>
</asp:Content>
