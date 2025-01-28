<%@ Page Title="" Language="C#" MasterPageFile="~/Job Seeker.Master" AutoEventWireup="true" CodeBehind="JobSeekerHome.aspx.cs" Inherits="JobPortalApplication.JobSeekerModule.JobSeekerHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table>
        <tr>
            <td>Name :</td>
            <td><asp:Label ID="lblname" runat="server"></asp:Label></td>
        </tr>
        

        <tr>
    <td>Email Id :</td>
    <td><asp:Label ID="lblemil" runat="server"></asp:Label></td>
</tr>

        <tr>
    <td>Password:</td>
    <td><asp:Label ID="lblpassword" runat="server"></asp:Label></td>
</tr>
                    <tr>
    <td>Gender :</td>
    <td><asp:Label ID="lblgender" runat="server" ></asp:Label>  </td>
       
       
</tr>
                <tr>
    <td>Date_of_Birth:</td>
    <td><asp:Label ID="lblbod" runat="server"></asp:Label></td>
</tr>
                <tr>
    <td>Question:</td>
    <td><asp:Label ID="lblquestion" runat="server"></asp:Label></td>
</tr>
                        <tr>
    <td>Answer:</td>
    <td><asp:Label ID="lblanswer" runat="server"></asp:Label></td>
</tr>

        <tr>
    <td>Job Profile:</td>
    <td><asp:Label ID="lbljobprofile" runat="server"></asp:Label></td>
</tr>

                <tr>
    <td>Job Experience:</td>
    <td><asp:Label ID="lbljobexperience" runat="server">
        
        </asp:Label></td>
</tr>

                <tr>
    <td>Qualification:</td>
    <td><asp:Label ID="lblqualification" runat="server"></asp:Label></td>
</tr>

                        <tr>
    <td>State:</td>
    <td><asp:Label ID="lblstate" runat="server"  ></asp:Label></td>
</tr>

                        <tr>
    <td>City:</td>
    <td><asp:Label ID="lblcity" runat="server"></asp:Label></td>
</tr>
                        <tr>
    <td>Photo Upload:</td>
    <td><asp:Label ID="lblphoto" runat="server" /></td>
</tr>

                                <tr>
    <td>Resume Upload:</td>
    <td><asp:Label ID="lblresume" runat="server" /></td>
</tr>

                <tr>
    <td>Comment :</td>
    <td><asp:Label ID="lblcomment" runat="server"></asp:Label></td>
</tr>
                <tr>
    <td></td>
    <td>
        <asp:Button ID="btnsubmit" Text="Submit" runat="server"  />
    </td>
</tr>

    </table>
</asp:Content>
