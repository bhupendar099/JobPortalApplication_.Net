<%@ Page Title="" Language="C#" MasterPageFile="~/Job Recruiter.Master" AutoEventWireup="true" CodeBehind="JobRecruiterjobpost.aspx.cs" Inherits="JobPortalApplication.JobRecruiterModule.JobRecruiterjobpost" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>Job Profile </td>
            <td><asp:DropDownList ID="ddljobprofile" runat="server"></asp:DropDownList></td>
        </tr>

        <tr>
    <td>Job Mode  </td>
    <td><asp:DropDownList ID="ddljobmode" runat="server">
        <asp:ListItem Text="--select--" Value="0"></asp:ListItem>
         <asp:ListItem Text="work from office" Value="1"></asp:ListItem>
         <asp:ListItem Text="work from Home " Value="2"></asp:ListItem>
         <asp:ListItem Text=" Hybrid Mode " Value="3"></asp:ListItem>
        </asp:DropDownList></td>
</tr>

         <tr>
     <td>Job Gender </td>
     <td><asp:RadioButtonList ID="rblgender" runat="server" RepeatColumns="2"></asp:RadioButtonList></td>
 </tr>

                <tr>
    <td>Job Qualification </td>
    <td><asp:CheckBoxList ID="cblqualification" runat="server" RepeatColumns="6"></asp:CheckBoxList></td>
</tr>

        <tr>
            <td>Min Experience</td>
            <td><asp:TextBox ID="txtminexp" runat="server"></asp:TextBox> </td>
        </tr>

         <tr>
     <td>Max Experience</td>
     <td><asp:TextBox ID="txtmaxexp" runat="server"></asp:TextBox> </td>
 </tr>
                <tr>
    <td>Min Sallary</td>
    <td><asp:TextBox ID="txtminsalary" runat="server"></asp:TextBox> </td>
</tr>

                <tr>
    <td>Max Salary</td>
    <td><asp:TextBox ID="txtmaxsalary" runat="server"></asp:TextBox> </td>
</tr>

                <tr>
    <td>Number of Vacancies</td>
    <td><asp:TextBox ID="txtvacancy" runat="server"></asp:TextBox> </td>
</tr>

                        <tr>
    <td>Comments</td>
    <td><asp:TextBox ID="txtcomment" runat="server"></asp:TextBox> </td>
</tr>

                                <tr>
    <td></td>
    <td><asp:Button ID="btnpostjob"  Text="Post Your Job" OnClick="btnpostjob_Click" runat="server"></asp:Button> </td>
</tr>
        <tr>
            <td></td>
            <td><asp:Label ID="lblmsg" runat="server" ForeColor="Blue" Font-Bold="true"></asp:Label></td>
        </tr>

    </table>
</asp:Content>
