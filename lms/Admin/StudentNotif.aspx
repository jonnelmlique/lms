<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminLayout.Master" AutoEventWireup="true" CodeBehind="StudentNotif.aspx.cs" Inherits="lms.Admin.WebForm5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../CSS/AdminCSS/Prof_StudNotif.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="notif">
        <div class="search-nav">
            <input type="text" class="search" placeholder="Search" /><i class="fas fa-search"></i>
            <button>Send To All</button>
        </div>

              <table>
    <thead>
        <tr>
            <th>Student ID</th>
            <th>Name</th>
            <th>Email</th>
            <th style="width: 140px;"></th>
        </tr>
    </thead>
    <tbody>
        <asp:Repeater ID="studentRepeater" runat="server">
            <ItemTemplate>
                <tr>
                    <td><%# Eval("student_id") %></td>
                    <td><%# Eval("Fullname") %></td>
                    <td><%# Eval("Email") %></td>
                    <td>
                        <asp:HyperLink ID="studentLink" runat="server"
                            NavigateUrl='<%# "WriteNotif.aspx?studentid=" + Eval("student_id") %>'
                            Text="Send Message" />
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </tbody>
</table>
    </div>
</asp:Content>
