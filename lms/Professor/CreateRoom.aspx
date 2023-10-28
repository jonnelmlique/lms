<%@ Page Title="" Language="C#" MasterPageFile="~/Professor/professorMasterPage.Master" AutoEventWireup="true" CodeBehind="CreateRoom.aspx.cs" Inherits="lms.Professor.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../CSS/ProfessorCSS/CreateRoom.css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">


    <div class="room-page">
        <div class="room-filter">
            <div class="filters">
                <p>Select Room</p>
                <%--   <asp:DropDownList ID="DropDownList1" runat="server" CssClass="d-list">
                       <asp:ListItem Text="All Rooms" Value="1" />
                        <asp:ListItem Text="Subject 1" Value="2" />
                          <asp:ListItem Text="Subject 2" Value="3" />
                </asp:DropDownList>--%>
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="d-list">
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
                                <a href="#" class="room-btn">Edit Details</a>
                                <a href="#" class="room-btn">Enter Room</a>
                            </div>
                        </div>
                    </div>
                    <%--<div class="room-card">
            <div class="roomimage">
                <img class="room-thumb" src='<%# "ImageHandler.ashx?room_id=" + Eval("room_id") %>' alt="" />
                <a href='<%# "RoomDetails.aspx?room_id=" + Eval("room_id") %>'>
                    <span class="card-btn">VIEW</span>
                </a>
            </div>
            <div class="room-info">
                <h3 class="room-name"><%# Eval("roomname") %></h3>
                <p class="room-description"><%# Eval("rooomdescription") %></p>
                <span class="roomschedule"><%# Eval("schedule") %></span>
            </div>
        </div>--%>
                </ItemTemplate>
                <FooterTemplate>
                    </ul>
                </FooterTemplate>
            </asp:Repeater>

        </div>

    </div>



</asp:Content>
