<%@ Page Title="" Language="C#" MasterPageFile="~/Job Recruiter.Master" AutoEventWireup="true" CodeBehind="JobRecruiterChangePassword.aspx.cs" Inherits="JobPortalApplication.JobRecruiterModule.JobRecruiterChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table>
                <tr>
            <td>Current Password</td>
            <td><asp:TextBox ID="txtcurrent" runat="server" ></asp:TextBox></td>
        </tr>
        <tr>
    <td>New Password</td>
    <td><asp:TextBox ID="txtnew" runat="server" ></asp:TextBox></td>
</tr>

                <tr>
    <td>Confirm New Password</td>
    <td><asp:TextBox ID="txtconfirmnew" runat="server" ></asp:TextBox></td>
</tr>
        <tr>
    <td></td>
    <td><asp:Button Id="btncp" runat="server"  Text="Change Password" OnClick="btncp_Click"  /></td>
</tr>
        <tr>
    <td> </td>
    <td><asp:Label ID="lblmsg" runat="server" Font-Bold="true" ForeColor="Red" ></asp:Label></td>
</tr>
    </table>
</asp:Content>
