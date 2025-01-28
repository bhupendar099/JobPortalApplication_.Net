<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminManageJobSeeker.aspx.cs" Inherits="JobPortalApplication.AdminModule.AdminManageJobSeeker" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
           <td></td>
            <td><asp:GridView ID="gvjobseeker" runat="server" AutoGenerateColumns="false" OnRowCommand="gvjobseeker_RowCommand" >
                 <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                <Columns>
                    <asp:TemplateField HeaderText="JobSeeker ID">
                        <ItemTemplate>
                            <%#Eval("jobseekerId") %>
                        </ItemTemplate>
                    </asp:TemplateField>
        <asp:TemplateField HeaderText="JobSeeker Name">
    <ItemTemplate>
        <%#Eval("jobseekerName") %>
    </ItemTemplate>
</asp:TemplateField>

   <asp:TemplateField HeaderText="JobSeeker Email">
    <ItemTemplate>
        <%#Eval("jobseekerEmail") %>
    </ItemTemplate>
</asp:TemplateField>

       <asp:TemplateField HeaderText="JobSeeker Password">
    <ItemTemplate>
        <%#Eval("jobseekerPassword") %>
    </ItemTemplate>
</asp:TemplateField>
  <asp:TemplateField HeaderText="JobSeeker Gender">
    <ItemTemplate>
        <%#Eval("sgname") %>
    </ItemTemplate>
</asp:TemplateField>

   <asp:TemplateField HeaderText="JobSeeker Jobprofile">
    <ItemTemplate>
        <%#Eval("jobprofileName") %>
    </ItemTemplate>
</asp:TemplateField>
        <asp:TemplateField HeaderText="Qualification">
    <ItemTemplate>
        <%#Eval("qualificationName") %>
    </ItemTemplate>
</asp:TemplateField>
        <asp:TemplateField HeaderText="State">
    <ItemTemplate>
        <%#Eval("stateName") %>
    </ItemTemplate>
</asp:TemplateField>
        <asp:TemplateField HeaderText="City">
    <ItemTemplate>
        <%#Eval("cityName") %>
    </ItemTemplate>
</asp:TemplateField>
      <asp:TemplateField HeaderText="Date_of_Birth">
    <ItemTemplate>
        <%#Eval("jobseekerDOB") %>
    </ItemTemplate>
</asp:TemplateField>
     <asp:TemplateField HeaderText="Exp">
    <ItemTemplate>
        <%#Eval("jobseekerExp") %>
    </ItemTemplate>
</asp:TemplateField>
    <asp:TemplateField HeaderText="Image">
    <ItemTemplate>
        <%#Eval("jobseekerImage") %>
    </ItemTemplate>
</asp:TemplateField>
       <asp:TemplateField HeaderText="Resume">
    <ItemTemplate>
        <%#Eval("jobseekerResume") %>
    </ItemTemplate>
</asp:TemplateField>
     <asp:TemplateField HeaderText="Comments">
    <ItemTemplate>
        <%#Eval("jobseekerComments") %>
    </ItemTemplate>
</asp:TemplateField>


     <asp:TemplateField >
    <ItemTemplate>
       <asp:Button ID="btnblock" runat="server" Text=' <%#Eval("jobseekerStatus").ToString()=="0" ? "Block" :"Blocked"%>' CommandName="A" CommandArgument=' <%#Eval("jobseekerId") %>' />
    </ItemTemplate>
</asp:TemplateField>

                </Columns>
                 <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White"></FooterStyle>

 <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White"></HeaderStyle>

 <PagerStyle HorizontalAlign="Center" BackColor="#FFCC66" ForeColor="#333333"></PagerStyle>

 <RowStyle BackColor="#FFFBD6" ForeColor="#333333"></RowStyle>

 <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy"></SelectedRowStyle>

 <SortedAscendingCellStyle BackColor="#FDF5AC"></SortedAscendingCellStyle>

 <SortedAscendingHeaderStyle BackColor="#4D0000"></SortedAscendingHeaderStyle>

 <SortedDescendingCellStyle BackColor="#FCF6C0"></SortedDescendingCellStyle>

 <SortedDescendingHeaderStyle BackColor="#820000"></SortedDescendingHeaderStyle>
                </asp:GridView></td>
        </tr>
    </table>
</asp:Content>
