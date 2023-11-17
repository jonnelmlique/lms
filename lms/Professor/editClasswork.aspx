<%@ Page Title="" Language="C#" MasterPageFile="~/Professor/instructorClassRoom.Master" AutoEventWireup="true" CodeBehind="editClasswork.aspx.cs" Inherits="lms.Professor.WebForm11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../CSS/ProfessorCSS/editClasswork.css" />
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="Classroom" runat="server">
 <div class="classwork">
   <div class="class-head">
       <div class="drop-list1">
             <asp:DropDownList ID="DropDownList1" runat="server" CssClass="d-list">
                  <asp:ListItem Text="All Topics" Value="1" />
                
             </asp:DropDownList>
        </div>
      <div class="drop-list2">
              <a href="#" class="d-link" id="createRoomLink">Create Task</a>
        </div>
   </div>

     <div class="edit">
         <div class="assignment">
    <div class="assign-title">
        <div class="title">
            <asp:Label ID="lbltitle" runat="server" Text="Title:" CssClass="lbl-title"></asp:Label>
            <asp:TextBox ID="txtmaterialsname" runat="server" CssClass="txt-title" placeholder="Enter Title"></asp:TextBox>
        </div>
        <div class="instructions">
            <asp:Label ID="Label4" runat="server" Text="Instructions:" CssClass="lbl-instruc"></asp:Label>
            <asp:TextBox ID="txtinstructions" runat="server" TextMode="MultiLine" Rows="5" CssClass="txt-instruc" placeholder="Write instructions about the post"></asp:TextBox>
        </div>
    </div>
    <div class="assign-description">
        <div class="assign">
            <asp:Label ID="lblposttype" runat="server" Text="Create Post: " CssClass="lbl-assign"></asp:Label>
            <asp:RadioButton ID="rbassignment" runat="server" Text="Assignment" CssClass="rdb-post" GroupName="MaterialsGroup" />
            <asp:RadioButton ID="rbquiz" runat="server" Text="Quiz" CssClass="rdb-post" GroupName="MaterialsGroup" />
            <asp:RadioButton ID="rbmaterials" runat="server" Text="Materials" CssClass="rdb-post" GroupName="MaterialsGroup" />

        </div>
        <div class="assign">
            <asp:Label ID="lblpoints" runat="server" Text="Points:" CssClass="lbl-assign"></asp:Label>
            <asp:DropDownList ID="drdpoints" runat="server" CssClass="txt-assign list">
                <asp:ListItem Text="0" Value="1" />
                <asp:ListItem Text="100" Value="2" />
                <asp:ListItem Text="50" Value="3" />
                <asp:ListItem Text="40" Value="4" />
                <asp:ListItem Text="30" Value="5" />
            </asp:DropDownList>
        </div>
        <div class="assign">
            <asp:Label ID="Label7" runat="server" Text="Due Date:" CssClass="lbl-assign"></asp:Label>
            <asp:TextBox ID="txtduedate" runat="server" CssClass="txt-assign txt"></asp:TextBox>

        </div>
        <div class="assign">
            <asp:Label ID="Label8" runat="server" Text="Topic:" CssClass="lbl-assign"></asp:Label>
            <asp:TextBox ID="txttopic" runat="server" CssClass="txt-assign txt"></asp:TextBox>
            
        </div>
         <div class="assign">
               <asp:FileUpload ID="file" runat="server" />
        </div>
        <div class="assign-btn">
            <asp:Button ID="btncreate" runat="server" Text="Create Assignment" CssClass="buttons"  />
            <asp:Button ID="Button4" runat="server" Text="Cancel" CssClass="buttons" OnClick="Button4_Click" />
        </div>
    </div>
</div>
     </div>

  </div>


</asp:Content>
