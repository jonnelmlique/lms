<%@ Page Title="" Language="C#" MasterPageFile="~/Student/classroomMasterPage.Master" AutoEventWireup="true" CodeBehind="submitClasswork.aspx.cs" Inherits="lms.Student.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../CSS/Student/submitClasswork.css" />

        <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
       <style>
    .custom-dropdown {
        display: inline-block;
        position: relative;
        padding: 10px;
        background-color: #f7f7f7;
        border: 1px solid #ccc;
        border-radius: 5px;
        cursor: not-allowed;
        overflow: hidden;
    }
    .custom-dropdown select {
        appearance: none;
        -webkit-appearance: none;
        -moz-appearance: none;
        width: 100%;
        height: 100%;
        border: none;
        outline: none;
        background: transparent;
        cursor: not-allowed;
        font-size: 16px;
        color: #333;
    }
    .custom-dropdown::before {
        content: "\25BC"; 
        position: absolute;
        top: 50%;
        right: 10px;
        transform: translateY(-50%);
        font-size: 16px;
        color: #555;
    }
    .custom-dropdown:hover {
        background-color: #e0e0e0;
    }

    .custom-dropdown select:focus {
        border: 1px solid #4CAF50;
        box-shadow: 0 0 5px rgba(76, 175, 80, 0.5);
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Student" runat="server">

    <div class="submit">
        <div class="class-content">
          <div class="details">
            <div class="title">
                <asp:Label ID="lblpost" runat="server" Text=""></asp:Label>
<%--                <h2>ACTIVITY</h2>--%>
            </div>
            <div class="name">
<%--                <h3>Mark Gervic Arca </h3>--%>
               <asp:Label ID="lblteacher" runat="server" Text=""></asp:Label>

<%--                <span> Date Posted</span>--%> 
                <asp:Label ID="lbldateposted" runat="server" Text=""></asp:Label>

            </div>
            <div class="points-date">
              <%--  <span>100 points</span>
                <span>Due  </span>--%>
             <asp:Label ID="lblpoints" runat="server" Text=""></asp:Label>'
          <asp:Label ID="lbldue" runat="server" Text=""></asp:Label>


            </div>
           </div>
            <div class="modules">
                <div class="instructions">
<%--                    <p>please answer and submit within the day.  do not forget to turn in.</p>--%>
                 <asp:Label ID="lblinstructions" runat="server" Text=""></asp:Label>

                </div>
                <div class="file">
                         <asp:DropDownList ID="ddlFiles" runat="server" CssClass="custom-dropdown" AutoPostBack="true" OnSelectedIndexChanged="ddlFiles_SelectedIndexChanged">
    </asp:DropDownList><br />
    <asp:Button ID="btnDownload" runat="server" Text="Download File" OnClick="btnDownload_Click" />
    <div class="assign">
<%--                    <div class="files"></div>--%>
                 
                    <%--<div class="files"></div>
                    <div class="files"></div>
                    <div class="files"></div>--%>
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
