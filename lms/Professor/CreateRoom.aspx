<%@ Page Title="" Language="C#" MasterPageFile="~/Professor/professorMasterPage.Master" AutoEventWireup="true" CodeBehind="CreateRoom.aspx.cs" Inherits="lms.Professor.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../CSS/ProfessorCSS/CreateRoom.css" />
        <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
<script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">


    <div class="room-page">
        <div class="room-filter">
            <div class="filters">
                <p>Select Room</p>
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="d-list" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                    <asp:ListItem Text="All Rooms" Value="1" />
                </asp:DropDownList>
            </div>

            <div class="btn-room">
                <a href="room_details.aspx" class="add-room"><i class="fas fa-plus"></i>Create Room </a>

            </div>
        </div>
        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        <div class="room-lists">

            <asp:Repeater ID="roomRepeater" runat="server">
                <HeaderTemplate>
                    <ul>
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="room-card">
                        <div class="room-image">
                            <img class="room-banner" src='<%# "ImageHandler.ashx?roomid=" + Eval("roomid") %>' alt="" />
                        </div>

                        <div class="room-sched">
                            <a href='<%# "RoomDetails.aspx?roomid=" + Eval("roomid") %>' class="room-subj"><%# Eval("subjectname") %></a>
                            <span class="room-section"><%# Eval("section") + " | " + Eval("schedule") %></span>

                            <div class="room-buttons">
                                <a href="#" class="room-btn">Enter Room</a>
                                <%--                                 <a href="editDetails.aspx" class="room-btn">Edit Details</a>                               --%>
                                <asp:LinkButton ID="roomLink" runat="server" CssClass="room-btn"
                                    PostBackUrl='<%# "editDetails.aspx?roomid=" + Eval("roomid") %>'
                                    Text="Edit Details" />

                                <a href="#" class="room-btn createRoomLink">Archive Room</a>
                            </div>
                        </div>
                    </div>

                </ItemTemplate>
                <FooterTemplate>
                    </ul>
                </FooterTemplate>
            </asp:Repeater>

        </div>

    </div>

 <div class="link" id="assignmentContainer">
    <div class="assignment">
        <div class="message">
            <p>Are you sure you want to Archive this room?</p>
        </div>
        <div class="message-button">
            <asp:Button ID="Button1" runat="server" Text="Yes" CssClass="msg yes" />
            <asp:Button ID="Button2" runat="server" Text="No" CssClass="msg no" />
        </div>
    </div>
  
    </div>
   
      <div id="bg-blur"></div>

    <script>
        // Use querySelectorAll to select all elements with the class 'createRoomLink'
        var createRoomLinks = document.querySelectorAll('.createRoomLink');

        // Loop through each element with the class 'createRoomLink'
        createRoomLinks.forEach(function (link) {
            // Add a click event listener to each element
            link.addEventListener('click', function (e) {
                e.preventDefault(); // Prevent the link from navigating

                var assignmentContainer = document.getElementById('assignmentContainer');
                var backgroundBlur = document.getElementById('bg-blur');

                if (assignmentContainer.style.display === 'none' || assignmentContainer.style.display === '') {
                    // Show the background blur and the assignment container
                    backgroundBlur.style.display = 'block';
                    assignmentContainer.style.display = 'block';
                } else {
                    // Hide the background blur and the assignment container
                    backgroundBlur.style.display = 'none';
                    assignmentContainer.style.display = 'none';
                }
            });
        });
    </script>
</asp:Content>
