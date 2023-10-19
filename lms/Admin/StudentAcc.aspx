<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminLayout.Master" AutoEventWireup="true" CodeBehind="StudentAcc.aspx.cs" Inherits="lms.Admin.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <div class="Management">
        <div class="search-nav">
         <asp:TextBox ID="TextBox1" runat="server" CssClass="search" placeholder="Search Professor"></asp:TextBox> 
            <asp:ImageButton ID="ImageButton1" runat="server" CssClass="search-btn" ImageUrl="~/Resources/search.png"/>
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="d-list">
          <asp:ListItem Text="Activated Accounts" Value="1" />
              <asp:ListItem Text="Deactivated Accounts" Value="2" />
       
        </asp:DropDownList>
          
            <button class="crud"> Add Account </button>
            <button class="crud"> Edit Account </button>
            <button class="crud"> Block Account </button>
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
        <asp:Literal ID="trstduehnt" runat="server"></asp:Literal>

    </tbody>
</table>

    </div>
</asp:Content>
