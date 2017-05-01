<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Homepage.aspx.cs" Inherits="Homepage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <center> <p> !<%=Session["UserName"] %> שלום
   <br />תוכל/י למצוא כאן כתבות בנושא תזונה, אורח חיים בריא וכושר
   <br />
    <br />
   </center>
   <center>
      <img src="Fitness.jpg" alt="Fitness" width="55%" height="45%" />
       </center>
 

   
</asp:Content>

