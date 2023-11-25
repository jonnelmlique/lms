<%@ Page Title="" Language="C#" MasterPageFile="~/Student/classroomMasterPage.Master" AutoEventWireup="true" CodeBehind="submitClasswork.aspx.cs" Inherits="lms.Student.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../CSS/Student/submitClasswork.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Student" runat="server">

    <div class="submit">
        <div class="class-content">
          <div class="details">
            <div class="title">
                <h2>ACTIVITY</h2>
            </div>
            <div class="name">
                <h3>Mark Gervic Arca </h3>
                <span> Date Posted</span>
            </div>
            <div class="points-date">
                <span>100 points</span>
                <span>Due  </span>
            </div>
           </div>
            <div class="modules">
                <div class="instructions">
                    <p>please answer and submit within the day.  do not forget to turn in.</p>
                </div>
                <div class="file">
                    <div class="files"></div>
                    <div class="files"></div>
                    <div class="files"></div>
                    <div class="files"></div>
                </div>
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
        <div class="class-submit">
            <div class="my-works">
            <div class="works">
                <h2>Your Work</h2>
                <span>Turned in</span>
            </div>
            <div class="work-list">
              <%--  work list--%>
            </div>
             <div class="submit-btn">
                 <asp:Button ID="Button1" runat="server" Text="Add or Create" CssClass="work-btn" />
                  <asp:Button ID="Button2" runat="server" Text="Mark as done" CssClass="work-btn" />
             </div>
        </div>
        </div>
    </div>

</asp:Content>
