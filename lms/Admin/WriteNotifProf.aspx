﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminLayout.Master" AutoEventWireup="true" CodeBehind="WriteNotifProf.aspx.cs" Inherits="lms.Admin.WebForm13" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../CSS/AdminCSS/Notifications.css" />
<script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
 <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
                  <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>

    <div class="message">
        <div class="message-content">
            <div class="message-head">
                   <a href="ProfessorNotif.aspx"><i class="fas fa-arrow-left arrow-left"></i></a>
                <h2>Write Message</h2>

            </div>
        
            <asp:Label ID="lblRecipientEmail" runat="server" Visible="false"></asp:Label>
            <h3>Email:</h3> 
            <asp:TextBox ID="emailtxt" runat="server" CssClass="area1"></asp:TextBox>

            <h3>Subject:</h3>  <asp:Label ID="ErrorSub1" runat="server"  CssClass="error"></asp:Label>
            <asp:TextBox ID="txtsubject" runat="server" CssClass="area1" placeholder="Write email subject"></asp:TextBox>
            <h3>Message:</h3>  <asp:Label ID="ErroSub2" runat="server"  CssClass="error"></asp:Label>
          <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" Rows="5" CssClass="area2" placeholder="Write email content"></asp:TextBox>
            <br />
            
           <%-- <asp:Label ID="lblMessage" runat="server" CssClass="area3" Text="">Check</asp:Label>--%>
            <asp:Button ID="btnSendMessage" runat="server" Text="SEND MESSAGE"  OnClick="btnSendMessage_Click" CssClass="button" />
        </div>
    </div>
</asp:Content>


