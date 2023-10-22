﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Professor/professorMasterPage.Master" AutoEventWireup="true" CodeBehind="room_details.aspx.cs" Inherits="lms.Professor.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../CSS/ProfessorCSS/room_details.css" />
       <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
<script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
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
        <%-- <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>--%>
        <div class="room-details">
            <div class="room-info">
                <div class="room-head">
                    <asp:ImageButton ID="ImageButton1" ImageUrl="~/Resources/left-arrow.png" CssClass="arrow-left" runat="server" OnClick="ImageButton1_Click" CausesValidation="false" />
                    <h2>Create Room</h2>
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
                                        <asp:RequiredFieldValidator ID="InstructorNameValidator" runat="server" ErrorMessage="* Required" ControlToValidate="instructorname" ForeColor="Red"></asp:RequiredFieldValidator>

                                    </div>
                                    <br />
                                    <div class="tab-setup">
                                        <label for="rname" class="label l2"><b>Subject Name:</b></label>
                                        <asp:TextBox ID="roomname" runat="server" CssClass="tab-text" placeholder="Enter Subject Name (REQUIRED)"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RoomNameValidator" runat="server" ErrorMessage="* Required" ControlToValidate="roomname" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="tab-setup">
                                        <label for="sname" class="label l3"><b>Subject Code:</b></label>
                                        <asp:TextBox ID="subjectname" runat="server" CssClass="tab-text" placeholder="Enter Subject Code"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="SubjectNameValidator" runat="server" ErrorMessage="* Required" ControlToValidate="subjectname" ForeColor="Red"></asp:RequiredFieldValidator>

                                    </div>
                                </div>
                              <%--  <asp:Label ID="ValidationMessage" runat="server" CssClass="error-message" Visible="false"></asp:Label>--%>

                                <div class="tab-btn">
                                    <asp:Button ID="Button2" runat="server" Text="Cancel" CssClass="tab-nxt" OnClick="Button2_Click" CausesValidation="false" />
                                    <asp:Button ID="Button1" runat="server" Text="Next" CssClass="tab-nxt" OnClick="Button1_Click" />
                                </div>
                            </asp:View>
                            <asp:View ID="View2" runat="server">
                                <div class="details-view">
                                    <div class="details-image">
                                        <asp:Image ID="ImagePreview" runat="server" CssClass="img-preview" EnableViewState="false" Visible="true" />
                                        <asp:FileUpload ID="roomimage" runat="server" CssClass="img-btn" onchange="showImagePreview()" Font-Size="Larger" />
                                        <asp:RequiredFieldValidator ID="ImageValidator" runat="server" ErrorMessage="* Required" ControlToValidate="roomimage" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="details-info">
                                        <div class="info">
                                            <label for="sched" class="info-details section">Section : </label>
                                            <asp:TextBox ID="txtsection" runat="server" CssClass="info-txt" placeholder="BSIT - 3L"> </asp:TextBox>
                                            <br />
                                            <asp:RequiredFieldValidator ID="SectionValidator" runat="server" ErrorMessage="* Required" ControlToValidate="txtsection" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="info">
                                            <label for="sched" class="info-details sched">Schedule : </label>
                                            <asp:TextBox ID="schedule" runat="server" CssClass="info-txt" placeholder="MONDAY| 8:00am - 10:00am , 11:00am - 2:00pm"> </asp:TextBox>
                                             <br />
                                            <asp:RequiredFieldValidator ID="ScheduleValidator" runat="server" ErrorMessage="* Required" ControlToValidate="schedule" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="info">
                                            <div class="info1">
                                                <div class="info2 lbl">
                                                    <label for="desc" class="info-details detail">Description : </label>
                                                </div>
                                                <div class="info2 txt">
                                                    <asp:TextBox ID="txtdescription" runat="server" TextMode="MultiLine" Rows="5" CssClass="info-txt desc"> </asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="info-button">
                                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="info-btn" OnClick="btnCancel_Click" CausesValidation="false" />
                                            <asp:Button ID="btnCreate" runat="server" Text="Create Room" CssClass="info-btn" OnClick="btnCreate_Click" />
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
