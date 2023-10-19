<%@ Page Title="" Language="C#" MasterPageFile="~/Professor/professorMasterPage.Master" AutoEventWireup="true" CodeBehind="CreateRoom.aspx.cs" Inherits="lms.Professor.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../CSS/ProfessorCSS/CreateRoom.css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

  
    <div class="room-page">
        <div class="room-filter">
            <div class="filters">               
                    <p> Select Room</p>
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="d-list">
                       <asp:ListItem Text="All Rooms" Value="1" />
                        <asp:ListItem Text="Subject 1" Value="2" />
                          <asp:ListItem Text="Subject 2" Value="3" />
                </asp:DropDownList>
                      
             </div>
          
           <div class="btn-room">
               <a href="room_details.aspx" class="add-room"><i class="fas fa-plus"></i>Create Room </a>
              
          </div>       
      </div>


              <asp:Repeater ID="roomRepeater" runat="server">
    <HeaderTemplate>
        <ul>
    </HeaderTemplate>
    <ItemTemplate>
        <div class="card">
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
        </div>
    </ItemTemplate>
    <FooterTemplate>
        </ul>
    </FooterTemplate>
</asp:Repeater>



<%--        <div class="room-lists">
            <div class="room-card">
            </div>
            <div class="room-card">
</div>
            <div class="room-card">
</div>
            <div class="room-card">
</div>
            <div class="room-card">
</div>
            <div class="room-card">

</div>
            <div class="room-card">

</div>

        </div>--%>

        
    </div>

   
  
</asp:Content>
