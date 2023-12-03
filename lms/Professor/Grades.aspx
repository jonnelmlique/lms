<%@ Page Title="" Language="C#" MasterPageFile="~/Professor/instructorClassRoom.Master" AutoEventWireup="true" CodeBehind="Grades.aspx.cs" Inherits="lms.Professor.Grades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       <link rel="stylesheet" href="../CSS/ProfessorCSS/viewClasswork.css" />
<script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
<script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>

<style>
    .gridview {
        width: 100%;
        border-collapse: collapse;
        margin-top: 20px;
        font-family: 'Arial', sans-serif;
        color: #333;
    }

        .gridview th, .gridview td {
            padding: 15px;
            text-align: left;
            border: 1px solid #ddd;
        }

        .gridview th {
            background-color: #4CAF50;
            color: white;
            font-weight: bold;
        }

        .gridview tr {
            transition: background-color 0.3s;
        }

            .gridview tr:hover {
                background-color: #f5f5f5;
            }

        .gridview a {
            display: inline-block;
            padding: 10px 15px;
            text-align: center;
            text-decoration: none;
            background-color: #3498db;
            color: white;
            border-radius: 5px;
            transition: background-color 0.3s;
        }

            .gridview a:hover {
                background-color: #2980b9;
            }

    .hide-column {
        display: none;
    }

    .img-profile {
        margin: auto;
        color: #000;
        width: 60px;
        height: 50px;
        border-radius: 50%;
    }

    .announcement-grid {
        width: 100%;
        border-collapse: collapse;
        margin-top: 20px;
    }

    .announcement-box {
        border: 1px solid #ccc;
        margin-bottom: 20px;
        padding: 10px;
        border-radius: 5px;
        background-color: #fff;
        box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
    }

    .announcement-head {
        display: flex;
        align-items: center;
        margin-bottom: 10px;
    }

    .profile {
        margin-right: 10px;
    }

    .img-profile {
        width: 50px;
        height: 50px;
        border-radius: 50%;
    }

    .info {
        flex-grow: 1;
    }

    .name {
        margin-bottom: 5px;
    }

        .name h3 {
            margin: 0;
            color: #333;
        }

    .date span {
        color: #888;
    }

    .announcement-body {
        line-height: 1.6;
    }

    .emailname {
        display: none;
    }

    .class-content .comments .announcement-comment .comment-button .btn-comment {
        height: 60px;
        cursor: pointer;
        width: 60px;
        border-color: transparent;
        transition: 0.3s all ease;
        padding: 10px;
    }

        .class-content .comments .announcement-comment .comment-button .btn-comment:hover {
            opacity: 0.5;
            color: #fff;
        }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Classroom" runat="server">
                  <div class="class-submit">

    <div class="submitted">
    <div class="works">
        <h2>GRADED</h2>
        <span></span>
    </div>
<%--    <div class="work-list">--%>

        <asp:GridView ID="gvgraded" runat="server" AutoGenerateColumns="False" CssClass="gridview"  >
            <Columns>
                <asp:BoundField DataField="studentworkid" HeaderText="File ID" SortExpression="materialsId" ReadOnly="True" HeaderStyle-CssClass="hide-column" ItemStyle-CssClass="hide-column" />
                <asp:BoundField DataField="materialsId" HeaderText="File ID" SortExpression="materialsId" ReadOnly="True" HeaderStyle-CssClass="hide-column" ItemStyle-CssClass="hide-column" />
                <asp:BoundField DataField="studentname" HeaderText="Student Name" SortExpression="StudentName" ReadOnly="True"  />
                <asp:BoundField DataField="FileName" HeaderText="File Name" SortExpression="FileName" ReadOnly="True" />
                <asp:BoundField DataField="points" HeaderText="Score" SortExpression="FileName" ReadOnly="True"  />
            </Columns>
        </asp:GridView>



        <%--  grade list--%>
<%--    </div>--%>

</div></div>

</asp:Content>
