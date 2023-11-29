<%@ Page Title="" Language="C#" MasterPageFile="~/Student/classroomMasterPage.Master" AutoEventWireup="true" CodeBehind="viewAnnouncement.aspx.cs" Inherits="lms.Student.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../CSS/Student/viewAnnouncement.css" />
    <style>
.img-profile {
    margin: auto;
    color: #000;
    width: 60px;
    height: 50px;
    border-radius: 50%;
}

<style type="text/css">
    .announcement-grid {
        width: 100%;
        border-collapse: collapse;
        margin-top: 20px;
    }

    .announcement-box {
        border: 1px solid #ccc;
        margin-bottom: 20px;
        padding: 10px;
        border-radius: 5px;
        background-color: #fff;
        box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
    }

    .announcement-head {
        display: flex;
        align-items: center;
        margin-bottom: 10px;
    }

    .profile {
        margin-right: 10px;
    }

    .img-profile {
        width: 50px;
        height: 50px;
        border-radius: 50%;
    }

    .info {
        flex-grow: 1;
    }

    .name {
        margin-bottom: 5px;
    }

    .name h3 {
        margin: 0;
        color: #333;
    }

    .date span {
        color: #888;
    }

    .announcement-body {
        line-height: 1.6;
    }
    .emailname{
        display: none;
    }
</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Student" runat="server">

     <div class="submit">
     <div class="class-content">
       <div class="details">
         <div class="title">
<%--             <h2>Date Posted</h2>--%>
          <asp:Label ID="lbldate" runat="server" Text=""></asp:Label>

         </div>
         <div class="name">
             <asp:Label ID="lblteachername" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblteacheremail" runat="server" CssClass="emailname" Text=""></asp:Label>

         </div>
       
        </div>
         <div class="modules">
            
<%--                 <p>please answer and submit within the day.  do not forget to turn in.</p>--%>
                   <asp:Label ID="lblpostcontent" runat="server" Text=""></asp:Label>

         
         </div>
         <div class="comments">
             <div class="class-comments">
                 <span><i class="fas fa-users"></i> Class comments</span>
                 <asp:Label ID="classCommentCountLabel" runat="server" Text='<%# Eval("CommentCount") %>'></asp:Label>

             </div>
             <div class="comment-list">
            <asp:GridView ID="commentGridView" runat="server" AutoGenerateColumns="false" EmptyDataText="No Comment" CssClass="announcement-grid">
       <Columns>
           <asp:TemplateField>
               <ItemTemplate>
                   <div class="announcement-box">
                       <div class="announcement-head">
                           <div class="profile">
                       <asp:Image ID="Image1" runat="server" CssClass="img-profile" ImageUrl='<%# GetProfileImageUrl(Eval("profileimage")) %>' />
                           </div>
                           <div class="info">
                               <div class="name">
                                   <h3><%# Eval("name") %></h3>
                               </div>
                               <div class="date">
                                   <span><%# Eval("datepost") %></span>
                               </div>
                           </div>
                       </div>
                       <div class="announcement-body">
                           <p><%# Eval("commentpost") %></p>
                       </div>
                   </div>
               </ItemTemplate>
           </asp:TemplateField>
       </Columns>
   </asp:GridView>



             </div>
              <div class="announcement-comment">
                   <div class="post-div i">                                                  
                        <asp:Image ID="Image1" runat="server"  CssClass="img-profile"  />                 

                  </div>
                  <div class="post-div txt">
                      <asp:TextBox ID="txtcomment" runat="server" placeholder="Add comment" CssClass="txt-comment"></asp:TextBox>
                </div>
                  <div class="comment-button">
<%--                     <i class="fas fa-arrow-right"></i>--%>
                      <asp:Button ID="btncomment" runat="server" Text=">" OnClick="btncomment_Click" />
                    <%--  it should be imagebutton(arrow image button)--%>
                  </div>

              </div>
         </div>
     </div>
  
     </div>


</asp:Content>
