<%@ Page Title="" Language="C#" MasterPageFile="~/Job Recruiter.Master" AutoEventWireup="true" CodeBehind="JobRecruiterShowjobpost.aspx.cs" Inherits="JobPortalApplication.JobRecruiterModule.JobRecruiterShowjobpost" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                <asp:GridView ID="jobpostshow" runat="server" AutoGenerateColumns="false" OnRowCommand="jobpostshow_RowCommand" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                    <Columns>
                        <asp:TemplateField HeaderText="Job Post ID">
                            <ItemTemplate>
                                <%#Eval("JobPostId") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Recruiter Name">
                            <ItemTemplate>
                                <%#Eval("JRName") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Job Profile Name">
                            <ItemTemplate>
                                <%#Eval("jobprofileName") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Job Mode">
                            <ItemTemplate>
                                <%#Eval("jobprofileName").ToString()=="1"?"work from office":Eval("jobprofileName").ToString()=="1"?"work from Home":"Hybrid mode" %>
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="Gender">
                            <ItemTemplate>
                                <%#Eval("sgname") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Qualification">
                            <ItemTemplate>
                                <%#Eval("JobPostQualification") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Experience">
                            <ItemTemplate>
                                <%#Eval("JobPostMinExp") %> Year - <%#Eval("JobPostMaxExp") %>Year
                            </ItemTemplate>
                        </asp:TemplateField>



                        <asp:TemplateField HeaderText="Sallary">
                            <ItemTemplate>
                                Rs.  <%#Eval("JobPostMinSalary") %> -  Rs. <%#Eval("JobPostMaxSalary") %>
                            </ItemTemplate>
                        </asp:TemplateField>



                        <asp:TemplateField HeaderText="Number of Vacancy">
                            <ItemTemplate>
                                <%#Eval("JobPostVacancy") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Comments">
                            <ItemTemplate>
                                <%#Eval("JobPostComments") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btndelete" CommandName="A" Text="Delete" runat="server" CommandArgument='<%#Eval("JobPostId") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnedit" CommandName="B" Text="Edit" runat="server" CommandArgument='<%#Eval("JobPostId") %>'></asp:LinkButton>
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
