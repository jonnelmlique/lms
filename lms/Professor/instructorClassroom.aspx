<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="instructorClassroom.aspx.cs" Inherits="lms.Professor.instructorClassroom" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <meta charset="UTF-8"/>
        <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
        <title>Learning Management System</title>
        <link rel="stylesheet" href="../CSS/ProfessorCSS/instructorClassroom.css" />
        <link rel="stylesheet" href="//use.fontawesome.com/releases/v5.0.7/css/all.css"/>
      <link href='https://unpkg.com/boxicons@2.1.4/css/boxicons.min.css' rel='stylesheet'/>
</head>
<body>
     <header>
        <div class="header-content">
            <div class="icon-img-h2">
                  <i class="fa fa-bars" aria-hidden="true"></i>
                  <img src="../Resources/Novaliches Senior High School.png" alt="LOGO" />
                   <h2> Novaliches High School</h2>
                </div>
            <i class="fas fa-angle-right dropdown"></i>
            <div class="sched-subj">
                    <asp:Label ID="Label1" runat="server" Text="SIA - System Integration and Organization" CssClass="sub"></asp:Label>             
                      <asp:Label ID="Label2" runat="server" Text="MONDAY | 7:00 am - 9:00 am , 10:00 am - 1:00 pm" CssClass="sched-room"></asp:Label>
                </div>
         </div>
     <div class="header-login">
           <div class="dropdown">
               <button class="dropdown-toggle"><i class='bx bx-user-circle icon'></i><i class='bx bxs-down-arrow arrow'></i></button>
                <div class="dropdown-menu">
              <a href="/Account/Logout.aspx"> <i class="fas fa-sign-out-alt"></i> Logout</a>
   
            </div>
         </div>
     </div>
   </header>
               <div class="container">
                     <div class="side-bar">
            <div class="menu">
               
                <div class="item">
                    <a href="DashBoard.aspx" class="sub-btn"><i class='bx bxs-dashboard'></i>Home</a>
                </div>
                <div class="item">
                    <a href="CreateRoom.aspx" class="sub-btn"><i class="fas fa-book"></i>Reviews</a>               
                </div>
                 <div class="item">
                      <a href="CreateRoom.aspx" class="sub-btn"><i class="fas fa-book"></i>Exit</a>               
                    </div>
         </div>
        </div>
        <main class="content">
         <form id="form1" runat="server">                    
                 <div class="invite-room-list">
                        <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal" StaticMenuItemStyle-CssClass="tab"
                            StaticSelectedStyle-CssClass="selected-tab" StaticMenuItemStyle-HorizontalPadding="50px" StaticMenuItemStyle-VerticalPadding="15px"
                            StaticSelectedStyle-BackColo="White" CssClass="tabs" OnMenuItemClick="Menu1_MenuItemClick1" >
                       <Items>
                           <asp:MenuItem Text="Stream" Value="0" Selected="true"></asp:MenuItem>
                           <asp:MenuItem Text="Classwork" Value="1"></asp:MenuItem>
                            <asp:MenuItem Text="People" Value="2"></asp:MenuItem>
                                <asp:MenuItem Text="Grades" Value="3"></asp:MenuItem>
                   </Items>
                </asp:Menu>
                 <div class="tabContents">
                       <asp:MultiView ID="MultiView1" ActiveViewIndex="0" runat="server">
                           <asp:View ID="View1" runat="server">
                                STREAM
                            </asp:View>
                          <asp:View ID="View2" runat="server">
                               CLASSWORK
                               </asp:View>
                             <asp:View ID="View3" runat="server">
                                PEOPLE
                             </asp:View>
                             <asp:View ID="View4" runat="server">
                              GRADES
                            </asp:View>
                      </asp:MultiView>

                </div>
    
                  </div>
          
             </form>
        </main>
    </div>


   

    <script>

        $(".sub-btn").click(function () {
            $(this).siblings(".sub-menu").slideToggle();
            $(this).find(".dropdown").toggleClass("rotate");
        });
    </script>
    <script>
        const dropdownToggle = document.querySelector(".dropdown-toggle");
        const dropdownMenu = document.querySelector(".dropdown-menu");

        dropdownToggle.addEventListener("click", (e) => {
            e.preventDefault();
            dropdownMenu.style.display = dropdownMenu.style.display === "block" ? "none" : "block";
        });

        window.addEventListener("click", (e) => {
            if (!dropdownToggle.contains(e.target)) {
                dropdownMenu.style.display = "none";
            }
        });
    </script>
</body>
</html>
