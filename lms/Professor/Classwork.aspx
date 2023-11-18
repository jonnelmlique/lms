﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Professor/instructorClassRoom.Master" AutoEventWireup="true" CodeBehind="Classwork.aspx.cs" Inherits="lms.Professor.WebForm13" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../CSS/ProfessorCSS/classwork.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Classroom" runat="server">

    <div class="classwork">
        <div class="class-head">
            <div class="drop-list1">
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="d-list">
                    <asp:ListItem Text="All Topics" Value="1" />
                    <asp:ListItem Text="Assignments" Value="2" />
                    <asp:ListItem Text="Quiz" Value="3" />
                    <asp:ListItem Text="Materials" Value="4" />
                </asp:DropDownList>
            </div>
            <div class="drop-list2">
                <a href="#" class="d-link" id="createRoomLink">Create Task</a>
            </div>
        </div>


        <div class="class-body">

            <asp:GridView ID="materialsGridView" runat="server" AutoGenerateColumns="false" EmptyDataText="No Learning Materials Found" CssClass="custom-materials-grid">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <div class="materials-box">
                                <div class="title">
                                    <h2><%# Eval("materialsname") %></h2>

                                    <a href='<%# "editClasswork.aspx?roomid=" + Request.QueryString["roomid"] + "&materialsid=" + Eval("materialsid") %>'><i class="fas fa-edit"></i></a>
                                </div>
                                <div class="date-points">
                                    <div class="points">
                                        <span><%# Eval("points") %></span>
                                    </div>
                                    <div class="date">
                                        <span>
                                            <p>Due Date, <%# Eval("duedate") %></p>
                                        </span>
                                    </div>
                                </div>
                                <div class="instruction">
                                    <p><%# Eval("instructions") %></p>
                                </div>



                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>

</asp:Content>
