﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Professor/professorMasterPage.Master" AutoEventWireup="true" CodeBehind="ArchiveConfirmation.aspx.cs" Inherits="lms.Professor.ArchiveConfirmation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link rel="stylesheet" href="../CSS/ProfessorCSS/CreateRoom.css" />
        <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
<script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
     <div class="link" >
    <div class="assignment">
        <div class="message">
            <p>Are you sure you want to Archive this room?</p>
        </div>
        <div class="message-button">
            <asp:Button ID="btnarchiveyes" runat="server" Text="Yes" CssClass="msg yes" OnClick="btnarchiveyes_Click" />
            <asp:Button ID="btnarchiveno" runat="server" Text="No" CssClass="msg no" OnClick="btnarchiveno_Click" />
        </div>
    </div>
  
    </div>
   
      <div id="bg-blur"></div>


      <script>
          function showSuccessMessage() {
              Swal.fire({
                  icon: 'success',
                  text: 'Room Archived Successfully!',
                  confirmButtonText: 'Confirm',
                  confirmButtonColor: '#3085d6',
              }).then((result) => {
                  if (result.isConfirmed) {
                      window.location.href = 'CreateRoom.aspx';
                  }
              });
          }
      </script>
</asp:Content>
