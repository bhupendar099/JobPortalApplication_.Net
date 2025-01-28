<%@ Page Title="" Language="C#" MasterPageFile="~/Defult.Master" AutoEventWireup="true" CodeBehind="JobRecruiter_Registration.aspx.cs" Inherits="JobPortalApplication.JobRecruiter_Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table>
        <tr>
            <td> Name :</td>
            <td><asp:TextBox ID="txtname" runat="server"></asp:TextBox></td>
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
    <td>URL:</td>
    <td><asp:TextBox ID="txturl" runat="server"></asp:TextBox></td>
</tr>
                <tr>
    <td>Address:</td>
    <td><asp:TextBox ID="txtaddress" runat="server"></asp:TextBox></td>
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
