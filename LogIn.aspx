<%@ Page Title="" Language="C#" MasterPageFile="~/Defult.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="JobPortalApplication.LogIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
         <tr>
     <td>LogIn Type</td>
     <td><asp:DropDownList ID="ddlusertype" runat="server" >
         <asp:ListItem  Text="--select--" Value="0"></asp:ListItem>
         <asp:ListItem  Text="Admin" Value="1" ></asp:ListItem>
         <asp:ListItem  Text="JobSeeker" Value="2" ></asp:ListItem>
         <asp:ListItem  Text="JobRecruiter" Value="3" ></asp:ListItem>
         </asp:DropDownList></td>
 </tr>
        <tr>
            <td> Email</td>
            <td><asp:TextBox ID="txtemail" runat="server" ></asp:TextBox></td>
        </tr>
        <tr>
    <td>Password</td>
    <td><asp:TextBox ID="txtpassword" runat="server" ></asp:TextBox></td>
</tr>
        <tr>
    <td></td>
    <td><asp:Button Id="btnlogin" runat="server"  Text="Login" OnClick="btnlogin_Click"  /></td>
</tr>
        <tr>
    <td> </td>
    <td><asp:Label ID="lblmsg" runat="server" Font-Bold="true" ForeColor="Red" ></asp:Label></td>
</tr>
    </table>
</asp:Content>
