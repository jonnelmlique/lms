<%@ Page Title="" Language="C#" MasterPageFile="~/Student/studentMasterPage.Master" AutoEventWireup="true" CodeBehind="classSubjects.aspx.cs" Inherits="lms.Student.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" href="../CSS/Student/classSubjects.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <div class="subjects">
        <div class="search-subject">
            <div class="search-subj">
                <asp:TextBox ID="TextBox1" runat="server" Placeholder="Search Subject" CssClass="subj-txt"></asp:TextBox>
                 <i class="fas fa-search"></i>
            </div>
            <div class="search-subj2">

            </div>
        </div>
        <div class="subject-list">

        </div>
    </div>


</asp:Content>
