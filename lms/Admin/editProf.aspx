<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminLayout.Master" AutoEventWireup="true" CodeBehind="editProf.aspx.cs" Inherits="lms.Admin.WebForm11" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../CSS/AdminCSS/editProf.css" />
     <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
 <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
           <div class="add-account">
    <div class="acc-card">
        <div class="acc-head">
            <a href="StudentAcc.aspx"><i class="fas fa-arrow-left arrow-left"></i></a>
            <h2>Professor Details</h2>
        </div>
        <div class="acc-body">
            <div class="acc-info1">
                <div class="lbl-txt">
                    <div class="lbl">
                        <asp:Label ID="Label1" runat="server" Text="First Name:" CssClass="acc-lbl fname"></asp:Label>
                    </div>
                    <div class="txt">
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="acc-txt" placeholder="Enter First Name"></asp:TextBox>
                    </div>
                </div>
                <div class="lbl-txt">
                    <div class="lbl">
                        <asp:Label ID="Label2" runat="server" Text="Last Name" CssClass="acc-lbl lname"></asp:Label>
                    </div>
                    <div class="txt">
                        <asp:TextBox ID="TextBox2" runat="server" CssClass="acc-txt" placeholder="Enter Last Name"></asp:TextBox>
                    </div>
                </div>
                <div class="lbl-txt">
                    <div class="lbl">
                        <asp:Label ID="Label3" runat="server" Text="BirthDay:" CssClass="acc-lbl bday"></asp:Label>
                    </div>
                    <div class="txt">
                        <asp:TextBox ID="TextBox3" runat="server" CssClass="acc-txt" placeholder="Enter birthDay" AutoPostBack="True" OnTextChanged="TextBox3_TextChanged"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="TextBox3_CalendarExtender" runat="server" BehaviorID="TextBox3_CalendarExtender" TargetControlID="TextBox3"></ajaxToolkit:CalendarExtender>
                    </div>
                </div>
                <div class="lbl-txt">
                    <div class="lbl">
                        <asp:Label ID="Label4" runat="server" Text="Age :" CssClass="acc-lbl age"></asp:Label>
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                    </div>
                    <div class="txt">
                        <asp:TextBox ID="TextBox4" runat="server" CssClass="acc-txt" placeholder="Age"></asp:TextBox>
                    </div>
                </div>
                <div class="lbl-txt">
                    <div class="lbl">
                        <asp:Label ID="Label5" runat="server" Text="Gender:" CssClass="acc-lbl gender"></asp:Label>
                    </div>
                    <div class="txt rdb">
                        <asp:RadioButton ID="RadioButton1" runat="server" Text="Male" CssClass="radio-btn" GroupName="GenderGroup" />
                        <asp:RadioButton ID="RadioButton2" runat="server" Text="Female" CssClass="radio-btn" GroupName="GenderGroup" />
                    </div>
                </div>
                <div class="lbl-txt">
                    <div class="lbl">
                        <asp:Label ID="Label6" runat="server" Text="Contact No." CssClass="acc-lbl age"></asp:Label>
                    </div>
                    <div class="txt">
                        <asp:TextBox ID="TextBox5" runat="server" CssClass="acc-txt" placeholder="Enter Contact Number"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="acc-info2">
                <div class="acc-img">
                    <asp:Image ID="ImagePreview" runat="server" CssClass="img-preview" EnableViewState="false" Visible="true" />
                    <asp:FileUpload ID="FileUpload1" runat="server" text="" onchange="showImagePreview()" CssClass="upload" />
                </div>

                <div class="lbl-txt ">
                    <div class="lbl hide">
                      <asp:Label ID="Label9" runat="server" Text="Username" CssClass="acc-lbl age"></asp:Label>

                    </div>
                    <div class="txt hide">
                        <asp:TextBox ID="txtusername" runat="server" CssClass="acc-txt" placeholder="Username"></asp:TextBox>
                    </div>
                </div>
                <div class="lbl-txt">
                    <div class="lbl">
                        <asp:Label ID="Label7" runat="server" Text="Email Account" CssClass="acc-lbl age"></asp:Label>
                    </div>
                    <div class="txt">
                        <asp:TextBox ID="TextBox6" runat="server" CssClass="acc-txt" placeholder="Enter Email Account"></asp:TextBox>


                    </div>
                </div>


                <div class="lbl-txt">
                    <div class="lbl">
                        <asp:Label ID="Label8" runat="server" Text="Password" CssClass="acc-lbl age"></asp:Label>
                    </div>
                    <div class="txt">
                        <asp:TextBox ID="TextBox7" runat="server" CssClass="acc-txt" placeholder="Temporary Password"></asp:TextBox>
                    </div>

                </div>
                <div class="lbl-txt button-add">
                    <asp:Button ID="btnedit" runat="server" Text="Edit Details" OnClientClick="return validateGender();" CssClass="btn-add" OnClick="btnedit_Click" />
                     <asp:Button ID="btnactivate" runat="server" Text="Activate Account" CssClass="btn-add" OnClick="btnactivate_Click"/>
                        <asp:Button ID="btndeactivate" runat="server" Text="Deactivate Account" CssClass="btn-add" OnClick="btndeactivate_Click" />

                    <%-- <asp:Button ID="Button3" runat="server" Text="Activate Account" OnClientClick="return validateGender();" OnClick="btnadd_Click"  CssClass="btn-add"/>
                 <asp:Button ID="Button2" runat="server" Text="Deactivate Account" OnClientClick="return validateGender();" OnClick="btnadd_Click"  CssClass="btn-add"/>
                 <asp:Button ID="Button1" runat="server" Text="Clear"  CssClass="btn-add" />--%>
                </div>
            </div>
        </div>

    </div>


</div>
<script type="text/javascript">
    function showImagePreview() {
        var imgPreview = document.getElementById('<%= ImagePreview.ClientID %>');
  var fileUpload = document.getElementById('<%= FileUpload1.ClientID %>');

        if (fileUpload.files && fileUpload.files[0]) {
            var reader = new FileReader();
            reader.onload = function (e) {
                imgPreview.src = e.target.result;
                imgPreview.style.display = 'block';
            };
            reader.readAsDataURL(fileUpload.files[0]);
        } else {
            imgPreview.style.display = 'none';
        }
    }
</script>
</asp:Content>
