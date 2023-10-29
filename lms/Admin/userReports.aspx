<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminLayout.Master" AutoEventWireup="true" CodeBehind="userReports.aspx.cs" Inherits="lms.Admin.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../CSS/AdminCSS/userReports.css" />
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">

    <div class="reports">
         <div class="search-room">
           
                <div class="search-bar">          
            <asp:TextBox ID="TextBox1" runat="server" CssClass="search" placeholder="Search Room"></asp:TextBox>
                    <i class="fas fa-search"></i>
               </div>
            <div class="search-buttons">
                 <asp:DropDownList ID="DropDownList1" runat="server" CssClass="d-list">
                      <asp:ListItem Text="Filter Reports" Value="1" />
                      <asp:ListItem Text="Professor Reports" Value="2" />
                        <asp:ListItem Text="Student Reports" Value="23" />
                 </asp:DropDownList>
                              <asp:Button ID="Button1" runat="server" Text="Search" CssClass="crud"/>
                  </div>
          
         </div>

        <div class="report-tbl">

        </div>
        
    </div>
</asp:Content>
