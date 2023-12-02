<%@ Page Title="" Language="C#" MasterPageFile="~/Professor/instructorClassRoom.Master" AutoEventWireup="true" CodeBehind="editAnnouncement.aspx.cs" Inherits="lms.Professor.WebForm15" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../CSS/ProfessorCSS/editAnnouncement.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Classroom" runat="server">

    <div class="edit">
        <div class="edit-main">
             <div class="edit-head">
                   <h2>Edit Announcement</h2>
             </div>
              <div class="edit-body">
                  <asp:TextBox ID="TextBox1" runat="server" CssClass="txt-edit" TextMode="MultiLine" Rows="10"></asp:TextBox>
             </div>
            <div class="edit-btn">
                 <asp:Button ID="btncreatepost" runat="server" CssClass="post-btn" Text="Edit Post" />
                <a href="#" class="post-btn">Cancel Edit</a>
            </div>
         </div>
   </div>
</asp:Content>
