<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="lms.LOGIN.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta charset="UTF-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title>Login</title>
    <link rel="stylesheet" href="../CSS/login.css" />
    <link rel="stylesheet" href="//use.fontawesome.com/releases/v5.0.7/css/all.css"/>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap/5.3.0/js/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.5.1/jquery.min.js" charset="utf-8"></script>
</head>
<body>

     <div class="login">
        <div class="login-img">
            <img src="../Resources/Novaliches High School Cover Picture.jpg" />

            <h2>Novaliches High School</h2>
        </div>
        <div class="login-page">

            <form method="post" runat="server">
                <div class="login-logo">
                    <img src="../Resources/Novaliches Senior High School.png" />
                    <h2>Learning Management System</h2>
                </div>
                <div class="container">
                    
                    <label for="uname"><b>Email</b></label>
                    <asp:TextBox ID="txtemail" required placeholder="Enter Email" runat="server"></asp:TextBox>
               
                    <label for="psw"><b>Password</b></label>
                    <asp:TextBox ID="txtpassword" placeholder="Enter Password" runat="server" TextMode="Password"></asp:TextBox>
                    
                      <input type="checkbox" onclick="myFunction()"> Show Password
                
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                    <asp:Button ID="btnlogin" CssClass="btn" runat="server" Text="Login" OnClick="btnlogin_Click"  />
                         <%--<input type="text" placeholder="Enter Username" name="uname" required/>--%>
<%--                    <input type="password" placeholder="Enter Password" name="psw" required/>--%>
<%--                    <button type="submit">Login</button>--%>

                </div>

            </form>
        </div>

    </div>


    <script>
        function myFunction() {
            var x = document.getElementById("txtpassword");
            if (x.type === "password") {
                x.type = "text";
            } else {
                x.type = "password";
            }
        }
    </script>


   
</body>
</html>
