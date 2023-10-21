<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminLayout.Master" AutoEventWireup="true" CodeBehind="subDetails.aspx.cs" Inherits="lms.Admin.WebForm9" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../CSS/AdminCSS/subDetails.css" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
         <div class="view-details">
       <div class="details-card">
         <div class="room-head">
                <asp:ImageButton ID="ImageButton1" ImageUrl="~/Resources/left-arrow.png" CssClass="arrow-left"  runat="server"   CausesValidation="false" />
                <h2> Rooms Created</h2>
           </div>
           <div class="room-prof">
             
             <div class="p-room">
                     <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal" StaticMenuItemStyle-CssClass="tab" 
                          StaticSelectedStyle-CssClass="selected-tab" StaticMenuItemStyle-HorizontalPadding="50px" StaticMenuItemStyle-VerticalPadding="15px" 
                         StaticSelectedStyle-ForeColor="black" StaticSelectedStyle-BackColor="white"  CssClass="tabs" OnMenuItemClick="Menu1_MenuItemClick">
                      <Items>
                          <asp:MenuItem Text="Description" Value="0" Selected="true"></asp:MenuItem>
                         <asp:MenuItem Text="Peoples" Value="1"></asp:MenuItem>
                      </Items>
                    </asp:Menu>
                 </div>
                <div class="tabContents">
                    <asp:MultiView ID="MultiView1" ActiveViewIndex="0" runat="server">
                             <asp:View ID="View1" runat="server"> 
                                 <p> NO DETAILS </p>
                              
                                 </asp:View>
                           <asp:View ID="View2" runat="server" >
                                    <div class="members">
                                        <div class="instructor">
                                            <div class="owner">
                                                 <h2>Room Owner :</h2>
                                                <asp:Label ID="Label1" runat="server" Text="Label" CssClass="lbl-owner"></asp:Label>
                                            </div>
                                           <div class="co-owner">
                                               <h2>Co-Room Owner :</h2>

                                           </div>
                                        </div>
                                        <div class="students">
                                            <div class="student-txt">
                                            <span>Students Enrolled:</span>
                                            <asp:TextBox ID="TextBox1" runat="server" CssClass="search-student" placeholder="Search Student"></asp:TextBox>
                                                <asp:Button ID="Button1" runat="server" Text="Button" CssClass="student-btn" />
                                                </div>
                                            <div class="student-data">
                                             <%--   gridview--%>
                                            </div>
                                        </div>
                                    </div>                          
                               </asp:View>
                    </asp:MultiView>
               </div>

              
           
       </div>

</div>
   </div>
</asp:Content>
