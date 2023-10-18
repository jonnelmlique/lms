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
               <a hre="#" class="add-room"><i class="fas fa-plus"></i>Create Room </a>
              
          </div>
      </div>
    </div>

   
  
</asp:Content>
