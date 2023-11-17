<%@ Page Title="" Language="C#" MasterPageFile="~/Professor/instructorClassRoom.Master" AutoEventWireup="true" CodeBehind="StreamClassroom.aspx.cs" Inherits="lms.Professor.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../CSS/ProfessorCSS/stream.css" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Classroom" runat="server">

   <div class="stream">
    <div class="create-post">
        <div class="post-head">
            <h2>Create Post</h2>
        </div>
        <div class="post-details">
            <div id="postDetailsLink" class="post-details-link">
                <div class="post-div i">
                    <i class="fas fa-user"></i>
                </div>
                <div class="post-div txt">
                    <a href="#" class="post-txt">Announce something in the class</a>
                </div>
            </div>

            <div id="postDetailsInput" class="post-details-input">
                <div class="detail-link">
                    <div class="post-div txt">
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="detail-txt" placeholder="Announce something in the class" TextMode="MultiLine" Rows="7"></asp:TextBox>
                    </div>
                    <div class="post-buttons">
                        <asp:Button ID="btncreatepost" runat="server" CssClass="post-btn" Text="Create Post" OnClick="btncreatepost_Click" />
                        <asp:Button ID="Button1" runat="server" CssClass="post-btn cancel" Text="Cancel" />
                    </div>
                </div>
            </div>



        </div>
                              
        <asp:GridView ID="postGridView" runat="server" AutoGenerateColumns="false" EmptyDataText="" CssClass="announcement-grid">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <div class="announcement-box">
                            <div class="announcement-head">
                                <div class="profile">
                                    <i class="fas fa-user"></i>
                                </div>
                                <div class="info">
                                    <div class="name">
                                        <h3><%# Eval("teacheremail") %></h3>
                                        <a href="#"><i class="fas fa-edit"></i></a>
                                    </div>
                                    <div class="date">
                                        <span><%# Eval("datepost") %></span>
                                    </div>
                                </div>
                            </div>
                            <div class="announcement-body">
                                <p><%# Eval("postcontent") %></p>
                            </div>

                          
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

               
    </div>
</div>
</asp:Content>

<%--<asp:Content ID="Content3" ContentPlaceHolderID="Classwork" runat="server">
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
                                 <a href="editClasswork.aspx"><i class="fas fa-edit"></i></a>
                            </div>            
                            <div class="date-points">
                                <div class="points">
                                  <span><%# Eval("points") %></span>
                                </div>
                                <div class="date">
                                   <span><p>Due Date, <%# Eval("duedate") %></p></span>
                                </div>
                            </div>
                            <div class="instruction">
                                <p><%# Eval("instructions") %></p>
                            </div>
                           
                         
                            <asp:HyperLink ID="lnkFile" runat="server" NavigateUrl='<%# "DownloadHandler.ashx?materialsid=" + Eval("materialsid") %>' Text="Download" CssClass="file-link" />
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</div>

 </asp:Content>--%>