<%@ Page Title="" Language="C#" MasterPageFile="~/Professor/professorMasterPage.Master" AutoEventWireup="true" CodeBehind="archiveClass.aspx.cs" Inherits="lms.Professor.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../CSS/ProfessorCSS/archivedClass.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <div class="archived">
        <div class="archived-head">
            <asp:TextBox ID="TextBox1" runat="server" CssClass="archived-search" placeholder="Search Archived Room"></asp:TextBox>
        </div>
        <div class="archived-body">
            
        </div>

    </div>

</asp:Content>
