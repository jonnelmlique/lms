<%@ Page Title="" Language="C#" MasterPageFile="~/Professor/professorMasterPage.Master" AutoEventWireup="true" CodeBehind="room_details.aspx.cs" Inherits="lms.Professor.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../CSS/ProfessorCSS/room_details.css" />
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

  <div class="room-page">
     <div class="room-filter">
         <div class="filters">               
               
                   
          </div>
       
        <div class="btn-room">
            <a hre="#" class="add-room"><i class="fas fa-plus"></i>Create Room </a>
           
       </div>       
   </div>

       <div class="room-details">
             <div class="room-info">
                 <div class="room-head">
                     <asp:ImageButton ID="ImageButton1" ImageUrl="~/Resources/left-arrow.png" CssClass="arrow-left"  runat="server" OnClick="ImageButton1_Click" />
                     <h2> Create Room</h2>
                 </div>
                 <div class="room-setup">
                      <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal" StaticMenuItemStyle-CssClass="tab" 
                          StaticSelectedStyle-CssClass="selected-tab" StaticMenuItemStyle-HorizontalPadding="50px" StaticMenuItemStyle-VerticalPadding="15px"
                          StaticSelectedStyle-BackColo="White" CssClass="tabs" OnMenuItemClick="Menu1_MenuItemClick">
                          <Items>
                              <asp:MenuItem Text="Setting Up" Value="0" Selected="true"></asp:MenuItem>
                               <asp:MenuItem Text="Details" Value="1"></asp:MenuItem>
                          </Items>
                      </asp:Menu>
                     <div class="tabContents">
                         <asp:MultiView ID="MultiView1" ActiveViewIndex="0" runat="server">
                             <asp:View ID="View1" runat="server"> 
                              <div class="tab-details">
                                 <div class="tab-setup">
                                     <label for="instructor" class="label l1"><b>Instructor Name:</b></label>
                                     <asp:TextBox ID="instructorname" runat="server" CssClass="tab-text"></asp:TextBox>
                                 </div>
                                   <div class="tab-setup">
                                       <label for="rname" class="label l2"><b>Room Name:</b></label>
                                       <asp:TextBox ID="roomname" runat="server" CssClass="tab-text" placeholder="Enter Room Name (REQUIRED)"></asp:TextBox>
                                 </div>
                                   <div class="tab-setup">
                                        <label for="sname" class="label l3"><b>Subject Name:</b></label>
                                          <asp:TextBox ID="subjectname" runat="server" CssClass="tab-text" placeholder="Enter Subject Name"></asp:TextBox>
                                     </div>                                  
                               </div>
                                  <div class="tab-btn">
                                       <asp:Button ID="Button2" runat="server" Text="Cancel" CssClass="tab-nxt"/>
                                      <asp:Button ID="Button1" runat="server" Text="Next" CssClass="tab-nxt" OnClick="Button1_Click"/>
                                    </div>
                             </asp:View>
                              <asp:View ID="View2" runat="server" >
                                    <div class="details-view">
                                          <div class="details-image">
                                              <asp:Image ID="ImagePreview" runat="server" CssClass="img-preview" EnableViewState="false" Visible="true" />
                                           <asp:FileUpload ID="roomimage" runat="server" CssClass="img-btn" onchange="showImagePreview()"  Font-Size="Larger" />

                                          </div>  
                                        <div class="details-info">
                                              <div class="info">
                                                  <label for="sched" class="info-details section"> Section : </label>
                                                  <asp:TextBox ID="txtsection" runat="server" CssClass="info-txt" placeholder="BSIT - 3L"> </asp:TextBox>
                                                </div>
                                                  <div class="info">
                                                    <label for="sched" class="info-details sched"> Schedule : </label>
                                                    <asp:TextBox ID="schedule" runat="server" CssClass="info-txt" placeholder="MONDAY| 8:00am - 10:00am , 11:00am - 2:00pm"> </asp:TextBox>
                                              </div> 
                                            <div class="info">
                                                <div class="info1">
                                                    <div class="info2 lbl">
                                                         <label for="desc" class="info-details detail"> Description : </label>
                                                        </div>
                                                    <div class="info2 txt">
                                                      <asp:TextBox ID="txtdescription" runat="server" TextMode="MultiLine" Rows="5" CssClass="info-txt desc"> </asp:TextBox>
                                                  </div>
                                               </div>
                                           </div>
                                            <div class="info-button">
                                                  <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="info-btn" OnClick="btnCancel_Click"/>
                                                  <asp:Button ID="btnCreate" runat="server" Text="Create Room" CssClass="info-btn" OnClick="btnCreate_Click"/>
                                            </div>
                                        </div>
                                    </div>
                              </asp:View>
                         </asp:MultiView>

                        

                     </div>
                 </div>
                
             </div>
         </div>
 </div>
   
    <script type="text/javascript">
        function showImagePreview() {
            var imgPreview = document.getElementById('<%= ImagePreview.ClientID %>');
        var fileUpload = document.getElementById('<%= roomimage.ClientID %>');

            if (fileUpload.files && fileUpload.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    imgPreview.src = e.target.result;
                    imgPreview.style.display = 'block'; // Set the display style to "block"
                };
                reader.readAsDataURL(fileUpload.files[0]);
            } else {
                imgPreview.style.display = 'none';
            }
        }
    </script>

</asp:Content>
