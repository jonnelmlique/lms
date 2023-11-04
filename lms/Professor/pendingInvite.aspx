<%@ Page Title="" Language="C#" MasterPageFile="~/Professor/professorMasterPage.Master" AutoEventWireup="true" CodeBehind="pendingInvite.aspx.cs" Inherits="lms.Professor.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link rel="stylesheet" href="../CSS/ProfessorCSS/pedingInvite.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

   <div class="reports">
       <div class="search-room">
              <div class="search-bar">         
                 <asp:TextBox ID="txtsearch" runat="server" CssClass="search" placeholder="Search Rooms" AutoPostBack="True" OnTextChanged="txtsearch_TextChanged" ></asp:TextBox>        
                  <i class="fas fa-search"></i>
                </div>
          <div class="search-buttons">

          </div>





       </div>

       <div class="invitation-tbl">
             <asp:GridView ID="pendinggrv" runat="server" AutoGenerateColumns="false" EmptyDataText="No Professor Found">
        <Columns>
            <asp:BoundField DataField="invitationid" HeaderText="Invitation ID" />
            <asp:BoundField DataField="studentid" HeaderText="Student ID" />
            <asp:BoundField DataField="teacherid" HeaderText="Teacher ID" />
            <asp:BoundField DataField="teacheremail" HeaderText="Teacher Email" />
            <asp:BoundField DataField="studentemail" HeaderText="Student Email" />
            <asp:BoundField DataField="status" HeaderText="Status" />

          
        </Columns>
    </asp:GridView>


       </div>
   </div>
</asp:Content>
