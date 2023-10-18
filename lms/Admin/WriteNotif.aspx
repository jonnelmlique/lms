<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminLayout.Master" AutoEventWireup="true" CodeBehind="WriteNotif.aspx.cs" Inherits="lms.Admin.WebForm6" %>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="message">
        <div class="message-content">
            <h2>Write Message</h2>

            <asp:Label ID="lblRecipientEmail" runat="server" Visible="false"></asp:Label>
            <h3>Email:</h3>
            <asp:TextBox ID="emailtxt" runat="server"></asp:TextBox>
            <h3>Subject:</h3>
            <asp:TextBox ID="txtsubject" runat="server"></asp:TextBox>
            <h3>Message:</h3>
          <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" Rows="5"></asp:TextBox>
            
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            <asp:Button ID="btnSendMessage" runat="server" Text="SEND MESSAGE" OnClick="btnSendMessage_Click" />
        </div>
    </div>
</asp:Content>




<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       <link rel="stylesheet" href="../CSS/AdminCSS/Notifications.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
     <div class="message">
        <div class="message-content">
            <h2> Write Message </h2>
            <h3> Title:</h3>
            <textarea class="area1"> </textarea>
            <h3>  Message:</h3>
            <textarea class="area2"> </textarea>

            <button> SEND MESSAGE</button>
        </div>
    </div>
</asp:Content>--%>
