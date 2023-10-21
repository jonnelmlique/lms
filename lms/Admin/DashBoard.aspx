<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminLayout.Master" AutoEventWireup="true" CodeBehind="DashBoard.aspx.cs" Inherits="lms.Admin.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

     <div class="dashboard">
   <div class="dash-list">
    <i class="fas fa-users"></i>
    <h2>Total Students : <span><%= GetTotalStudentCount() %></span></h2>
</div>
<div class="dash-list">
    <i class="fas fa-users"></i>
    <h2>Total Professors: <span><%= GetTotalProfessorCount() %></span></h2>
</div>

    <div class="dash-list">

    </div>
    <div class="dash-list">

    </div>
             <div class="dash-list">

    </div>
             <div class="dash-list">

    </div>
             <div class="dash-list">

    </div>
             <div class="dash-list">

    </div>
             <div class="dash-list">

    </div>
             <div class="dash-list">

    </div>
             <div class="dash-list">

    </div>
             <div class="dash-list">

    </div>
             <div class="dash-list">

    </div>
             <div class="dash-list">

    </div>
             <div class="dash-list">

    </div>

</div>
</asp:Content>
