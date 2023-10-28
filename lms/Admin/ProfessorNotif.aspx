<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminLayout.Master" AutoEventWireup="true" CodeBehind="ProfessorNotif.aspx.cs" Inherits="lms.Admin.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../CSS/AdminCSS/Prof_StudNotif.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <div class="notif">
        <div class="search-nav">
            <asp:TextBox ID="txtsearch" runat="server" CssClass="search" placeholder="Search Professor" AutoPostBack="True" OnTextChanged="txtsearch_TextChanged"></asp:TextBox>

            <asp:Button ID="btnSendToAll" runat="server" Text="Send To All" CssClass="crud" OnClick="btnSendToAll_Click" />
        </div>
                        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>

        <asp:GridView ID="TeacherGridView" runat="server" AutoGenerateColumns="false" EmptyDataText="No Professor Found">
            <Columns>
                <asp:BoundField DataField="teacherid" HeaderText="Teacher ID" />
                <asp:BoundField DataField="Fullname" HeaderText="Name" />
                <asp:BoundField DataField="email" HeaderText="Email" />
                <asp:TemplateField HeaderText="" ItemStyle-Width="140px">
                    <ItemTemplate>
                        <asp:HyperLink ID="studentLink" runat="server"
                            NavigateUrl='<%# "WriteNotifProf.aspx?teacherid=" + Eval("teacherid") %>'
                            Text="Send Message" CssClass="view" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        </div>
</asp:Content>
