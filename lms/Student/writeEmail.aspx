﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Student/classroomMasterPage.Master" AutoEventWireup="true" CodeBehind="writeEmail.aspx.cs" Inherits="lms.Student.WebForm9" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link rel="stylesheet" href="../CSS/AdminCSS/Notifications.css" />
<script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
 <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Student" runat="server">
       <div class="message">
       <div class="message-content">
           <div class="message-head">
                  <a href="ProfessorNotif.aspx"><i class="fas fa-arrow-left arrow-left"></i></a>
               <h2>Write Message</h2>

           </div>
       
           <asp:Label ID="lblRecipientEmail" runat="server" Visible="false"></asp:Label>
         <div class="message-details">
               <div class="head">  
                  <h3>Email:</h3> 
                   </div>
           <div class="area">
                   <asp:TextBox ID="emailtxt" runat="server" CssClass="area1" placeholder="Write the email of  receiver"></asp:TextBox>
            </div>
           </div>
            <div class="message-details">
                 <div class="head">  
                    <h3>Subject:</h3>  <asp:Label ID="ErrorSub1" runat="server"  CssClass="error"></asp:Label>
                </div>
           <div class="area">
           <asp:TextBox ID="txtsubject" runat="server" CssClass="area1" placeholder="Write email subject"></asp:TextBox>
          </div>
       </div>
                     <div class="main-message">    
             <div class="head">  
                 <h3>Message:</h3>  <asp:Label ID="ErroSub2" runat="server"  CssClass="error"></asp:Label>
             </div>
             <div class="area">
                 <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" Rows="5" CssClass="area2" placeholder="Write email content"></asp:TextBox>
              </div>
                <br />
           </div>
           <div class="message-btn">         

           <asp:Button ID="btnSendMessage" runat="server" Text="SEND MESSAGE"  OnClick="btnSendMessage_Click" CssClass="button" />      
           </div>  

       </div>
   </div>

</asp:Content>
