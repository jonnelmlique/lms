<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminLayout.Master" AutoEventWireup="true" CodeBehind="ProfessorAcc.aspx.cs" Inherits="lms.Admin.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
<script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <div class="Management">
        <div class="search-nav">
            <asp:TextBox ID="txtsearch" runat="server" CssClass="search" placeholder="Search Professor" AutoPostBack="True" OnTextChanged="txtsearch_TextChanged"></asp:TextBox>        
<%--            <asp:Button ID="btnrefresh" runat="server" Text="Search" CssClass="crud" OnClick="btnrefresh_Click" />--%>
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="d-list">
                <asp:ListItem Text="Activated Accounts" Value="1" />
                <asp:ListItem Text="Deactivated Accounts" Value="2" />

            </asp:DropDownList>
            <a href="AddTeacher.aspx" class="crud">Add Account </a>
       

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
                            NavigateUrl='<%# "professor.aspx?teacherid=" + Eval("teacherid") %>'
                            Text="View Details" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>



    </div>

</asp:Content>
