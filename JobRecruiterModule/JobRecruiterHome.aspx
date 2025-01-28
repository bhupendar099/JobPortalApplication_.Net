<%@ Page Title="" Language="C#" MasterPageFile="~/Job Recruiter.Master" AutoEventWireup="true" CodeBehind="JobRecruiterHome.aspx.cs" Inherits="JobPortalApplication.JobRecruiterModule.JobRecruiterHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
    <tr>
        <td>
            <asp:GridView ID="Gvjobrecruiter"  runat="server"></asp:GridView>
        </td>
    </tr>
</table>
</asp:Content>
