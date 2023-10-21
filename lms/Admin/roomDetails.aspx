<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminLayout.Master" AutoEventWireup="true" CodeBehind="roomDetails.aspx.cs" Inherits="lms.Admin.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../CSS/AdminCSS/roomDetails.css" />
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
                    <span> List of Created Rooms By:</span>
                    <asp:Label ID="Label2" runat="server" Text="PROFESSOR EMAIL"></asp:Label>
                </div>
                <div class="subjects">
                    <div class="sub-lbl">
                    <asp:Label ID="Label1" runat="server" Text="SUBJECTS" CssClass="room-subs"></asp:Label>
                        </div>
                    <div class="sub-btn">
                    <asp:Button ID="Button1" runat="server" Text="Button" CssClass="subj-btn" />
                        </div>
                </div>
            </div>
            
        </div>


    </div>

</asp:Content>
