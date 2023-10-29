<%@ Page Title="" Language="C#" MasterPageFile="~/Professor/professorMasterPage.Master" AutoEventWireup="true" CodeBehind="notifications.aspx.cs" Inherits="lms.Professor.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../CSS/ProfessorCSS/notifications.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <div class="notifications">
        <div class="notif-data">
             <div class="notif-head">
                  <i class="fas fa-bell"></i>
                  <span> Notifications</span>
              </div>
              <div class="notif-list">
                  <div class="notif-p">
                             <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal" StaticMenuItemStyle-CssClass="tab"
                                      StaticSelectedStyle-CssClass="selected-tab" StaticMenuItemStyle-HorizontalPadding="50px" StaticMenuItemStyle-VerticalPadding="15px"
                                      StaticSelectedStyle-BackColor="#eb4d4d" CssClass="tabs" OnMenuItemClick="Menu1_MenuItemClick"  >
                                    <Items>
                                         <asp:MenuItem Text="Notifications List" Value="0" Selected="true"></asp:MenuItem>
                                          <asp:MenuItem Text="Notification Details" Value="1"></asp:MenuItem>
                                    </Items>
                            </asp:Menu>
                       </div>
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

</asp:Content>
