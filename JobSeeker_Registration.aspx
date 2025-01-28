<%@ Page Title="" Language="C#" MasterPageFile="~/Defult.Master" AutoEventWireup="true" CodeBehind="JobSeeker_Registration.aspx.cs" Inherits="JobPortalApplication.JobSeeker_Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table>
        <tr>
            <td>Name :</td>
            <td><asp:TextBox ID="txtname" runat="server"></asp:TextBox></td>
        </tr>
         <tr>
     <td>Gender :</td>
     <td><asp:RadioButtonList ID="rblgender" runat="server"  RepeatColumns="3" >
        
         </asp:RadioButtonList></td>
 </tr>

        <tr>
    <td>Email Id :</td>
    <td><asp:TextBox ID="txtemil" runat="server"></asp:TextBox></td>
</tr>

        <tr>
    <td>Password:</td>
    <td><asp:TextBox ID="txtpassword" runat="server"></asp:TextBox></td>
</tr>
                <tr>
    <td>Date_of_Birth:</td>
    <td><asp:TextBox ID="txtbod" runat="server"></asp:TextBox></td>
</tr>
                <tr>
    <td>Question:</td>
    <td><asp:DropDownList ID="ddlquestion" runat="server"></asp:DropDownList></td>
</tr>
                        <tr>
    <td>Answer:</td>
    <td><asp:TextBox ID="txtanswer" runat="server"></asp:TextBox></td>
</tr>

        <tr>
    <td>Job Profile:</td>
    <td><asp:DropDownList ID="ddljobprofile" runat="server"></asp:DropDownList></td>
</tr>

                <tr>
    <td>Job Experience:</td>
    <td><asp:DropDownList ID="ddljobexperience" runat="server">
        <asp:ListItem  Text="--select--" Value="0"></asp:ListItem>
        <asp:ListItem  Text="0" Value="1"></asp:ListItem>
        <asp:ListItem  Text="1" Value="2"></asp:ListItem>
        <asp:ListItem  Text="2" Value="3"></asp:ListItem>
        <asp:ListItem  Text="3" Value="4"></asp:ListItem>
        </asp:DropDownList></td>
</tr>

                <tr>
    <td>Qualification:</td>
    <td><asp:DropDownList ID="ddlqualification" runat="server"></asp:DropDownList></td>
</tr>

                        <tr>
    <td>State:</td>
    <td><asp:DropDownList ID="ddlstate" runat="server" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged" AutoPostBack="true" ></asp:DropDownList></td>
</tr>

                        <tr>
    <td>City:</td>
    <td><asp:DropDownList ID="ddlcity" runat="server"></asp:DropDownList></td>
</tr>
                        <tr>
    <td>Photo Upload:</td>
    <td><asp:FileUpload ID="fuphoto" runat="server" /></td>
</tr>

                                <tr>
    <td>Resume Upload:</td>
    <td><asp:FileUpload ID="furesume" runat="server" /></td>
</tr>

                <tr>
    <td>Comment :</td>
    <td><asp:TextBox ID="txtcomment" runat="server"></asp:TextBox></td>
</tr>
                <tr>
    <td></td>
    <td>
        <asp:Button ID="btnsubmit" Text="Submit" runat="server" OnClick="btnsubmit_Click" />
    </td>
</tr>

    </table>
</asp:Content>
