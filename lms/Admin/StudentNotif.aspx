﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminLayout.Master" AutoEventWireup="true" CodeBehind="StudentNotif.aspx.cs" Inherits="lms.Admin.WebForm5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
<script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
    <link rel="stylesheet" href="../CSS/AdminCSS/Prof_StudNotif.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="notif">
        <div class="search-nav">
             <asp:TextBox ID="txtsearch" runat="server" CssClass="search" placeholder="Search Student" AutoPostBack="True" OnTextChanged="txtsearch_TextChanged"></asp:TextBox>
<%--  <asp:ImageButton ID="btnsearch" runat="server" CssClass="search-btn" ImageUrl="~/Resources/search.png" OnClick="btnsearch_Click" />--%>
<%--  <asp:Button ID="btnrefresh" runat="server" Text="Refresh" CssClass="crud" OnClick="btnrefresh_Click" />--%>
            <asp:Button ID="btnSendToAll" runat="server" Text="Send To All" CssClass="crud" OnClick="btnSendToAll_Click" />
        </div>
          <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
           <asp:GridView ID="studentGridView" runat="server" AutoGenerateColumns="false" EmptyDataText="No Student Found">
     <Columns>
         <asp:BoundField DataField="studentid" HeaderText="Student ID" />
         <asp:BoundField DataField="Fullname" HeaderText="Name" />
         <asp:BoundField DataField="email" HeaderText="Email" />
         <asp:TemplateField HeaderText="" ItemStyle-Width="140px">
             <ItemTemplate>
                 <asp:HyperLink ID="studentLink" runat="server"
                     NavigateUrl='<%# "WriteNotif.aspx?studentid=" + Eval("studentid") %>'
                     Text="Send Message" />
             </ItemTemplate>
         </asp:TemplateField>
     </Columns>
 </asp:GridView>
    </div>
</asp:Content>
