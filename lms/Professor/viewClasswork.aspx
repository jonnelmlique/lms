<%@ Page Title="" Language="C#" MasterPageFile="~/Professor/instructorClassRoom.Master" AutoEventWireup="true" CodeBehind="viewClasswork.aspx.cs" Inherits="lms.Professor.WebForm16" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../CSS/ProfessorCSS/viewClasswork.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Classroom" runat="server">

        <div class="submit">
        <div class="class-content">
          <div class="details">
            <div class="title">
                <asp:Label ID="lblpost" runat="server" Text="" CssClass="h2"></asp:Label>

            </div>
            <div class="name">
               <asp:Label ID="lblteacher" runat="server" Text="" CssClass="h3"></asp:Label>
                <asp:Label ID="lbldateposted" runat="server" Text="" CssClass="span"></asp:Label>

            </div>
            <div class="points-date">
             <asp:Label ID="lblpoints" runat="server" Text="" CssClass="span"></asp:Label>'
              <asp:Label ID="lbldue" runat="server" Text="" CssClass="span"></asp:Label>


            </div>
           </div>
            <div class="modules">
                <div class="instructions">

                 <asp:Label ID="lblinstructions" runat="server" Text="" CssClass="p"></asp:Label>

                </div>
                <div class="file">
                    <div class="files">
                   <asp:DropDownList ID="ddlFiles" runat="server" CssClass="custom-dropdown" AutoPostBack="true" OnSelectedIndexChanged="ddlFiles_SelectedIndexChanged">
                   </asp:DropDownList><br />
                     <asp:Button ID="btnDownload" runat="server" Text="Download File" OnClick="btnDownload_Click" />
                 </div>
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
           
            <div class="submitted">
            <div class="works">
                <h2>Turned In</h2>
               <span></span>
            </div>
            <div class="work-list">
              <%--  work list--%>
            </div>
           
        </div>
                <div class="not-submitted">
                      <div class="works">
                            <h2>Assigned</h2>
                           <span></span>
                    </div>
                  <div class="work-list">
                     <%--  work list--%>
                 </div>
           
            </div>
        </div>
    
</div>

</asp:Content>
