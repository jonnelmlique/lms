<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminLayout.Master" AutoEventWireup="true" CodeBehind="ProfessorNotif.aspx.cs" Inherits="lms.Admin.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" href="../CSS/AdminCSS/Prof_StudNotif.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

      <div class="notif">
        <div class="search-nav">
            <input type="text" class="search" placeholder="Search" /><i class="fas fa-search"></i>
            <button> Send To All </button>
        </div>

        <table>
            <thead>
                <tr>
                    <th>Professor ID</th>
                    <th>Name</th>
                    <th>Email</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
              
                    <tr>
                        <td>@Model[i].ID</td>
                        <td>@Model[i].FirstName @Model[i].LastName</td>
                        <td>@Model[i].Email</td>
                        <td width="140px"><a href="WriteNotif.aspx"> Send Message</a></td>
                    </tr>
                
            </tbody>
         
        </table>
    </div>
</asp:Content>
