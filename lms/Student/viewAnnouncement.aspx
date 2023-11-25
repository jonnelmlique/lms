<%@ Page Title="" Language="C#" MasterPageFile="~/Student/classroomMasterPage.Master" AutoEventWireup="true" CodeBehind="viewAnnouncement.aspx.cs" Inherits="lms.Student.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../CSS/Student/viewAnnouncement.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Student" runat="server">

     <div class="submit">
     <div class="class-content">
       <div class="details">
         <div class="title">
             <h2>Date Posted</h2>
         </div>
         <div class="name">
             <h3>Mark Gervic Arca </h3>
           
         </div>
       
        </div>
         <div class="modules">
            
                 <p>please answer and submit within the day.  do not forget to turn in.</p>
      
         
         </div>
         <div class="comments">
             <div class="class-comments">
                 <span><i class="fas fa-users"></i> Class comments</span>
             </div>
             <div class="comment-list">

             </div>
              <div class="announcement-comment">
                   <div class="post-div i">                                                  
                      <i class="fas fa-user"></i>

                  </div>
                  <div class="post-div txt">
                      <asp:TextBox ID="TextBox1" runat="server" placeholder="Add comment" CssClass="txt-comment"></asp:TextBox>
                </div>
                  <div class="comment-button">
                     <i class="fas fa-arrow-right"></i>
                    <%--  it should be imagebutton(arrow image button)--%>
                  </div>

              </div>
         </div>
     </div>
  
     </div>


</asp:Content>
