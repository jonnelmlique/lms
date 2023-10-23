<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminLayout.Master" AutoEventWireup="true" CodeBehind="addAccount.aspx.cs" Inherits="lms.Admin.WebForm11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../CSS/AdminCSS/addAccount.css" />
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
        
    <div class="add-account">
        <div class="acc-card">
             <div class="acc-head">
                 <asp:ImageButton ID="ImageButton1" ImageUrl="~/Resources/left-arrow.png" CssClass="arrow-left" runat="server" CausesValidation="false" />
                  <h2>Add Accounts</h2>
              </div>
            <div class="acc-body">
                <div class="acc-info1">
                    <div class="lbl-txt">
                           <div class="lbl">
                              <asp:Label ID="Label1" runat="server" Text="First Name:"  CssClass="acc-lbl fname"></asp:Label>
                            </div>
                        <div class="txt">
                          <asp:TextBox ID="TextBox1" runat="server" CssClass="acc-txt" placeholder="Enter First Name"></asp:TextBox>
                            </div>
                     </div>
                    <div class="lbl-txt">
                        <div class="lbl">
                         <asp:Label ID="Label2" runat="server" Text="Last Name"  CssClass="acc-lbl lname"></asp:Label>
                            </div>
                          <div class="txt">
                        <asp:TextBox ID="TextBox2" runat="server" CssClass="acc-txt" placeholder="Enter Last Name"></asp:TextBox>
                                   </div>
                     </div>
                    <div class="lbl-txt">
                           <div class="lbl">
                          <asp:Label ID="Label3" runat="server" Text="BirthDay:"  CssClass="acc-lbl bday"></asp:Label>
                                   </div>
                         <div class="txt">
                          <asp:TextBox ID="TextBox3" runat="server" CssClass="acc-txt" placeholder="Enter birthDay"></asp:TextBox>
                                </div>
                     </div>
                    <div class="lbl-txt">
                        <div class="lbl">
                             <asp:Label ID="Label4" runat="server" Text="Age :"  CssClass="acc-lbl age"></asp:Label>
                                </div>
                         <div class="txt">
                          <asp:TextBox ID="TextBox4" runat="server" CssClass="acc-txt"  placeholder="Age"></asp:TextBox>
                              </div>
                     </div>
                    <div class="lbl-txt">
                          <div class="lbl">
                            <asp:Label ID="Label5" runat="server" Text="Gender:" CssClass="acc-lbl gender"></asp:Label>
                              </div>
                         <div class="txt rdb">
                             <asp:RadioButton ID="RadioButton1" runat="server"  Text="Male" CssClass="radio-btn"/>
                              <asp:RadioButton ID="RadioButton2" runat="server"  Text="Female" CssClass="radio-btn"/>
                              </div>
                        </div>
                        <div class="lbl-txt">
                          <div class="lbl">
                              <asp:Label ID="Label6" runat="server" Text="Contact No."  CssClass="acc-lbl age"></asp:Label>
                              </div>
                             <div class="txt">
                                 <asp:TextBox ID="TextBox5" runat="server" CssClass="acc-txt"  placeholder="Enter Contact Number"></asp:TextBox>
                         </div>
                     </div>
                </div>
                <div class="acc-info2">
                      <div class="acc-img">
                           <asp:Image ID="ImagePreview" runat="server" CssClass="img-preview" EnableViewState="false" Visible="true" />
                      </div>  
                   <div class="lbl-txt">
                           <div class="lbl">
                              <asp:Label ID="Label7" runat="server" Text="Email Account"  CssClass="acc-lbl age"></asp:Label>
                         </div>
                      <div class="txt">
                          <asp:TextBox ID="TextBox6" runat="server" CssClass="acc-txt"  placeholder="Enter Email Account"></asp:TextBox>
                    </div>
                    </div>
                      <div class="lbl-txt">
                         <div class="lbl">
                              <asp:Label ID="Label8" runat="server" Text="Password"  CssClass="acc-lbl age"></asp:Label>
                           </div>
                      <div class="txt">
                        <asp:TextBox ID="TextBox7" runat="server" CssClass="acc-txt"  placeholder="Temporary Password"></asp:TextBox>
                     </div>
                  </div>           
               </div>
        </div>
         
     </div>
        

   </div>


</asp:Content>
