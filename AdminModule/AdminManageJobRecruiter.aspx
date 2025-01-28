<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminManageJobRecruiter.aspx.cs" Inherits="JobPortalApplication.AdminModule.AdminManageJobRecruiter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <table>
     <tr>
        <td></td>
         <td><asp:GridView ID="gvjobseeker" runat="server" AutoGenerateColumns="false" OnRowCommand="gvjobseeker_RowCommand" >
              <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                             <Columns>
                    <asp:TemplateField HeaderText="JR ID">
                        <ItemTemplate>
                            <%#Eval("JRId") %>
                        </ItemTemplate>
                    </asp:TemplateField>
        <asp:TemplateField HeaderText="JR Name">
    <ItemTemplate>
        <%#Eval("JRName") %>
    </ItemTemplate>
</asp:TemplateField>

   <asp:TemplateField HeaderText="JR Email">
    <ItemTemplate>
        <%#Eval("JREmail") %>
    </ItemTemplate>
</asp:TemplateField>

       <asp:TemplateField HeaderText="JR Password">
    <ItemTemplate>
        <%#Eval("JRPassword") %>
    </ItemTemplate>
</asp:TemplateField>
  <asp:TemplateField HeaderText="JR URL">
    <ItemTemplate>
        <%#Eval("JRURL") %>
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
      <asp:TemplateField HeaderText="Address">
    <ItemTemplate>
        <%#Eval("JRAddress") %>
    </ItemTemplate>
</asp:TemplateField>
    
    <asp:TemplateField HeaderText="Image">
    <ItemTemplate>
       <asp:Image ID="imgrecruiter" runat="server" Width="50px" Height="40px" ImageUrl='<%#Eval("JRImage","~/JobSeekerPhotos/{0}") %>' />
    </ItemTemplate>
</asp:TemplateField>
     
     <asp:TemplateField HeaderText="Comments">
    <ItemTemplate>
        <%#Eval("JRComment") %>
    </ItemTemplate>
</asp:TemplateField>
     <asp:TemplateField >
    <ItemTemplate>
       <asp:Button ID="btnblock" runat="server" Text=' <%#Eval("JRStatus").ToString()=="0" ? "Block" :"Blocked"%>' CommandName="A" CommandArgument=' <%#Eval("JRId") %>' />
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
