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
                 <asp:Label ID="Label2" runat="server" ></asp:Label>
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
                                <asp:GridView ID="roomdetailsGridView" runat="server" AutoGenerateColumns="false" EmptyDataText="No Subject Found">
                                      <Columns>
                                            <asp:BoundField DataField="subject" HeaderText="Subject Name" HeaderStyle-CssClass="subj"/>
                                           <asp:TemplateField HeaderText="" ItemStyle-Width="160px">
                                                 <ItemTemplate>
                                                    <asp:LinkButton ID="roomLink" runat="server" CssClass="btn-list"
                                                       Text="View Message" />

                                                  </ItemTemplate>
                                            </asp:TemplateField>
                                    </Columns>
                              </asp:GridView>

                                 </asp:View>
                               <asp:View ID="View2" runat="server">
                                   <div class="message">
                                       <div class="message-from">
                                           <div class="from">
                                               <h3> FROM :</h3>
                                           </div>
                                           <div class="from-label">
                                               <asp:TextBox ID="TextBox1" runat="server" CssClass="lbl-from" Enabled="False"></asp:TextBox>
                                           </div>
                                       </div>
                                       <div class="message-from">
                                              <div class="from">
                                                     <h3> SUBJECT :</h3>
                                                 </div>
                                         <div class="from-label">
                                             <asp:TextBox ID="TextBox2" runat="server" CssClass="lbl-from" Enabled="False"></asp:TextBox>
                                          </div>
                                       </div>
                                       <div class="message-content">
                                           <div class="from">
                                               <h3>MESSAGE : </h3>
                                           </div>
                                              <div class="from-label">
                                                <asp:TextBox ID="TextBox3" runat="server" CssClass="lbl-from" Enabled="False"></asp:TextBox>
                                             </div>
                                       </div>
                                      <div class="message-button">
                                          <asp:Button ID="Button1" runat="server" Text="Go Back" CssClass="btn-msg" OnClick="Button1_Click"  />
                                      </div>
                                   </div>
                                  
                           </asp:View>
                          </asp:MultiView>

                       </div>
                 
                 
             </div>
         </div>
    </div>

</asp:Content>
