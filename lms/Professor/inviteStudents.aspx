﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Professor/professorMasterPage.Master" AutoEventWireup="true" CodeBehind="inviteStudents.aspx.cs" Inherits="lms.Professor.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../CSS/ProfessorCSS/inviteStudents.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    
    <div class="reports">
         <div class="search-room">
            <asp:TextBox ID="TextBox1" runat="server" CssClass="search-txt" placeholder="Search Room"></asp:TextBox>
 
              <asp:Button ID="Button1" runat="server" Text="Search" CssClass="button-room"/>
                
         </div>

        <div class="report-tbl">
            <div class="invite-room">
                <div class="invite-p">
                    <p>List of Created Rooms</p>
                </div>
                <div class="invite-room-list">
                     <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal" StaticMenuItemStyle-CssClass="tab"
                          StaticSelectedStyle-CssClass="selected-tab" StaticMenuItemStyle-HorizontalPadding="50px" StaticMenuItemStyle-VerticalPadding="15px"
                           StaticSelectedStyle-BackColo="White" CssClass="tabs" OnMenuItemClick="Menu1_MenuItemClick" >
                     <Items>
                          <asp:MenuItem Text="Created Room List" Value="0" Selected="true"></asp:MenuItem>
                           <asp:MenuItem Text="List of Student" Value="1"></asp:MenuItem>
                    </Items>
                    </asp:Menu>
                    <div class="class-list">
                          <asp:MultiView ID="MultiView1" ActiveViewIndex="0" runat="server">
                                <asp:View ID="View1" runat="server">
                                    ROOM LIST
                                    </asp:View>
                               <asp:View ID="View2" runat="server">
                                        STUDENT LIST
                                     </asp:View>
                         </asp:MultiView>

                    </div>
              
                </div>
            </div>
        </div>
        
    </div>
</asp:Content>