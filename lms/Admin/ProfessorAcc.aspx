<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminLayout.Master" AutoEventWireup="true" CodeBehind="ProfessorAcc.aspx.cs" Inherits="lms.Admin.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <div class="Management">
        <div class="search-nav">
            <input type="text" class="search" placeholder="Search" /><i class="fas fa-search"></i>
            <select>
                <option value="Activated">Activated Accounts</option>
                <option value="Deactivated">Deactivated Accounts</option>
            </select>
            <button class="crud"> Add Account </button>
            <button class="crud"> Edit Account </button>
            <button class="crud"> Block Account </button>

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
                        <td width="140px"><a href="#"> View Details</a></td>
                    </tr>
                
            </tbody>
        </table>


    </div>

</asp:Content>
