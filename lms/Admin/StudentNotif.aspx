<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminLayout.Master" AutoEventWireup="true" CodeBehind="StudentNotif.aspx.cs" Inherits="lms.Admin.WebForm5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../CSS/AdminCSS/Prof_StudNotif.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="notif">
        <div class="search-nav">
             <asp:TextBox ID="txtsearch" runat="server" CssClass="search" placeholder="Search Student"></asp:TextBox>
  <asp:ImageButton ID="btnsearch" runat="server" CssClass="search-btn" ImageUrl="~/Resources/search.png" OnClick="btnsearch_Click" />
  <asp:Button ID="btnrefresh" runat="server" Text="Refresh" CssClass="crud" OnClick="btnrefresh_Click" />
            <button>Send To All</button>
        </div>

           <asp:GridView ID="studentGridView" runat="server" AutoGenerateColumns="false" EmptyDataText="No Student Found">
     <Columns>
         <asp:BoundField DataField="student_id" HeaderText="Student ID" />
         <asp:BoundField DataField="Fullname" HeaderText="Name" />
         <asp:BoundField DataField="email" HeaderText="Email" />
         <asp:TemplateField HeaderText="" ItemStyle-Width="140px">
             <ItemTemplate>
                 <asp:HyperLink ID="studentLink" runat="server"
                     NavigateUrl='<%# "WriteNotif.aspx?studentid=" + Eval("student_id") %>'
                     Text="Send Message" />
             </ItemTemplate>
         </asp:TemplateField>
     </Columns>
 </asp:GridView>
    </div>
</asp:Content>
