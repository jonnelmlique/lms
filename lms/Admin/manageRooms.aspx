<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminLayout.Master" AutoEventWireup="true" CodeBehind="manageRooms.aspx.cs" Inherits="lms.Admin.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../CSS/AdminCSS/manageRoom.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
            
    <div class="classroom">
        <div class="search-room">
            <asp:TextBox ID="TextBox1" runat="server" CssClass="search-txt" placeholder="Search Room"></asp:TextBox>
         <%--  <asp:ImageButton ID="btnsearch" runat="server" CssClass="room-btn" ImageUrl="~/Resources/search.png" />--%>
            <asp:Button ID="Button1" runat="server" Text="Search" CssClass="button-room"/>
        </div>
        
        <div class="room-tbl">
<%--             <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>--%>
        <asp:GridView ID="roomGridView" runat="server" AutoGenerateColumns="false" EmptyDataText="No Rooms Found">
              <Columns>
<%--                <asp:BoundField DataField="room_id" HeaderText="Room ID" />--%>
        <asp:BoundField DataField="professorname" HeaderText="Professor Name" />
        <asp:BoundField DataField="professoremail" HeaderText="Professor Email" />

                  <asp:TemplateField HeaderText="" ItemStyle-Width="140px">
                 <ItemTemplate>
                   <asp:LinkButton ID="roomLink" runat="server" 
PostBackUrl='<%# "roomDetails.aspx?professor_email=" + Eval("professoremail") %>'
    Text="View Rooms" />


                  </ItemTemplate>
             </asp:TemplateField>
          </Columns>
   </asp:GridView>
        </div>
    </div>

</asp:Content>
