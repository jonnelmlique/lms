<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminLayout.Master" AutoEventWireup="true" CodeBehind="ProfessorAcc.aspx.cs" Inherits="lms.Admin.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <div class="Management">
        <div class="search-nav">
            <asp:TextBox ID="txtsearch" runat="server" CssClass="search" placeholder="Search Professor"></asp:TextBox>
            <asp:ImageButton ID="btnsearch" runat="server" CssClass="search-btn" ImageUrl="~/Resources/search.png" OnClick="btnsearch_Click" />
            <asp:Button ID="btnrefresh" runat="server" Text="Refresh" CssClass="crud" OnClick="btnrefresh_Click" />
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="d-list">
                <asp:ListItem Text="Activated Accounts" Value="1" />
                <asp:ListItem Text="Deactivated Accounts" Value="2" />

            </asp:DropDownList>
            <button class="crud">Add Account </button>
            <button class="crud">Edit Account </button>
            <button class="crud">Block Account </button>

        </div>

        <asp:GridView ID="professorGridView" runat="server" AutoGenerateColumns="false" EmptyDataText="No Professor Found">
            <Columns>
                <asp:BoundField DataField="professor_id" HeaderText="Professor ID" />
                <asp:BoundField DataField="Fullname" HeaderText="Name" />
                <asp:BoundField DataField="email" HeaderText="Email" />
                <asp:TemplateField HeaderText="" ItemStyle-Width="140px">
                    <ItemTemplate>
                        <asp:HyperLink ID="studentLink" runat="server"
                            NavigateUrl='<%# "professor.aspx?professorid=" + Eval("professor_id") %>'
                            Text="View Details" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>



    </div>

</asp:Content>
