<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageBeforeSigning.master" AutoEventWireup="true" CodeFile="SignIn.aspx.cs" Inherits="SignIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <p> <%=message %></p>
  If you dont have an account, <a href="Signup.aspx"> click here </a> to sign up
 <center>
 <h1> Sign In</h1>
 </center>
   
    <form id="Sign_In" runat="server" method=post> 
        <div>
				<input type="text" name="UserName" id="UserName" placeholder="UserName" class="form-control"/> <br/>
                 <br />
			</div>

			<div>
				<input type="password" name="Password" id="Password" placeholder="Password" class="form-control"/> <br/>
                 <br />
			</div>

			<input type="submit" id="Submit" value="Sign In"/>
			<input type="reset"/>
		

    </form>
</asp:Content>

