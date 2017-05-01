<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageBeforeSigning.master"
    AutoEventWireup="true" CodeFile="Signup.aspx.cs" Inherits="Signup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Sign Up</title>
    <script type="text/javascript">
        function Validation() {
            var form = document.forms["SignUp"];
            var username = form["UserName"].value;
            var pass = form["Pass"].value;
            var cpass = form["ConfirmPass"].value;
            var email = form["Email"].value;
            var phone = form["phone"].value;
            if (username.length < 8) {
                alert("Your username is too short");
                return false;
            }
            else if (pass != cpass) {
                alert("Your confirmed password doesn't match to the original one");
                return false;
            }
            else if (pass.length < 6) {
                alert("Your password is too short");
                return false;
            }
            else if (email == "") {
                alert("Please enter your email");
                return false;
            }
            else if (phone == "") {
                alert("Please enter your phone number");
                return false;
            }

            return true;


        }

    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <p>
        <%= message %></p>
    <center>
        <h1>
            Sign Up</h1>
    </center>
    <form id="SignUp" runat="server" onsubmit="return Validation();" method="post">
    <div>
        <input id="UserName" name="UserName" placeholder="User Name" type="text" class="form-control" />
    </div>
    <div>
        <br />
        <input id="Pass" name="Pass" placeholder="Password" type="password" class="form-control" />
    </div>
    <div>
        <br />
        <input id="ConfirmPass" name="ConfirmPass" placeholder="Confirm Password" type="password"
            class="form-control" />
    </div>
    <div>
        <br />
        <input id="Email" name="Email" placeholder="E-mail" type="email" class="form-control" />
    </div>
    <div>
        <br />
        <input id="phone" name="phone" placeholder="Phone number" type="text" class="form-control" />
    </div>
    <div>
        <br />
        <input id="Submit" name="Submit" value="Submit" type="submit" />
    </div>
    </form>
    <br />
    <br />
</asp:Content>
