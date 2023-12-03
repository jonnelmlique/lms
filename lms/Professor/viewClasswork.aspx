<%@ Page Title="" Language="C#" MasterPageFile="~/Professor/instructorClassRoom.Master" AutoEventWireup="true" CodeBehind="viewClasswork.aspx.cs" Inherits="lms.Professor.WebForm16" %>

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

    <div class="submit">
        <div class="class-content">
            <div class="details">
                <div class="title">
                    <asp:Label ID="lblpost" runat="server" Text="" CssClass="h2"></asp:Label>

                </div>
                <div class="name">
                    <asp:Label ID="lblteacher" runat="server" Text="" CssClass="h3"></asp:Label>
                    <asp:Label ID="lblteacheremail" runat="server" CssClass="emailname" Text=""></asp:Label>
                    <asp:Label ID="lbldateposted" runat="server" Text="" CssClass="span"></asp:Label>

                </div>
                <div class="points-date">
                    <asp:Label ID="lblpoints" runat="server" Text="" CssClass="span"></asp:Label>'
              <asp:Label ID="lbldue" runat="server" Text="" CssClass="span"></asp:Label>


                </div>
            </div>
            <div class="modules">
                <div class="instructions">

                    <asp:Label ID="lblinstructions" runat="server" Text="" CssClass="p"></asp:Label>

                </div>
                <div class="file">
                    <div class="files">
                        <%-- <asp:DropDownList ID="ddlFiles" runat="server" CssClass="custom-dropdown" AutoPostBack="true" OnSelectedIndexChanged="ddlFiles_SelectedIndexChanged">
                   </asp:DropDownList><br />
                     <asp:Button ID="btnDownload" runat="server" Text="Download File" OnClick="btnDownload_Click" />--%>



                        <asp:GridView ID="gvFiles" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvFiles_SelectedIndexChanged" CssClass="gridview">
                            <Columns>
                                <asp:BoundField DataField="materialsId" HeaderText="File ID" SortExpression="materialsId" ReadOnly="True" HeaderStyle-CssClass="hide-column" ItemStyle-CssClass="hide-column" />
                                <asp:BoundField DataField="FileName" HeaderText="File Name" SortExpression="FileName" ReadOnly="True" HeaderStyle-CssClass="hide-column" />
                                <asp:CommandField ShowSelectButton="True" SelectText="Download" HeaderStyle-CssClass="hide-column" />
                            </Columns>
                        </asp:GridView>



                    </div>
                </div>
            </div>
            <div class="comments">
                <div class="class-comments">
                    <span><i class="fas fa-users"></i>Class comments</span>
                    <asp:Label ID="classCommentCountLabel" runat="server" Text='<%# Eval("CommentCount") %>' CssClass="lbl-comment"></asp:Label>

                </div>
                <div class="comment-list">


                    <asp:GridView ID="commentGridView" runat="server" AutoGenerateColumns="false" EmptyDataText="No Comment" CssClass="announcement-grid">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <div class="announcement-box">
                                        <div class="announcement-head">
                                            <div class="profile">
                                                <asp:Image ID="Image1" runat="server" CssClass="img-profile" ImageUrl='<%# GetProfileImageUrl(Eval("profileimage")) %>' />
                                            </div>
                                            <div class="info">
                                                <div class="name">
                                                    <h3><%# Eval("name") %></h3>
                                                </div>
                                                <div class="date">
                                                    <span><%# Eval("datepost") %></span>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="announcement-body">
                                            <p><%# Eval("commentpost") %></p>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>


                </div>
                <div class="announcement-comment">
                    <div class="post-div i">
                        <asp:Image ID="Image1" runat="server" CssClass="img-profile" />

                    </div>
                    <div class="post-div txt">
                        <asp:TextBox ID="txtcomment" runat="server" placeholder="Add comment" CssClass="txt-comment"></asp:TextBox>
                    </div>
                    <div class="comment-button">
                        <%--                        <i class="fas fa-arrow-right"></i>--%>
                        <%--  it should be imagebutton(arrow image button)--%>
                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Resources/submit2.png" CssClass="btn-comment" OnClick="ImageButton1_Click" />

                    </div>

                </div>
            </div>

        </div>
        <div class="class-submit">

            <div class="submitted">
                <div class="works">
                    <h2>Turned In</h2>
                    <span></span>
                </div>
                <div class="work-list">

                    <asp:GridView ID="gvwork" runat="server" AutoGenerateColumns="False" CssClass="gridview" OnSelectedIndexChanged="gvwork_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="materialsId" HeaderText="File ID" SortExpression="materialsId" ReadOnly="True" HeaderStyle-CssClass="hide-column" ItemStyle-CssClass="hide-column" />
                           <asp:BoundField DataField="studentname" HeaderText="File ID" SortExpression="StudentName" ReadOnly="True" HeaderStyle-CssClass="hide-column"  />
                            <asp:BoundField DataField="FileName" HeaderText="File Name" SortExpression="FileName" ReadOnly="True" HeaderStyle-CssClass="hide-column" />
                            <asp:CommandField ShowSelectButton="True" SelectText="Download" HeaderStyle-CssClass="hide-column" />
                        </Columns>
                    </asp:GridView>



                    <%--  work list--%>
                </div>

            </div>
            <div class="not-submitted">
                <div class="works">
                    <h2>Assigned</h2>
                    <span></span>
                </div>
                <div class="work-list">
                    <%--  work list--%>
                </div>

            </div>
        </div>

    </div>

</asp:Content>
