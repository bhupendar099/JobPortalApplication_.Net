using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace JobPortalApplication.JobRecruiterModule
{
    public partial class JobRecruiterChangePassword : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=LAPTOP-84MRHNGB; initial catalog=dbjobportal_1; integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btncp_Click(object sender, EventArgs e)
        {
            if (txtnew.Text == txtconfirmnew.Text)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update tbljobrecruiter set JRPassword='"+ txtnew.Text + "' where JRId='" + Session["JRID"] + "' and JRPassword='"+txtcurrent.Text+"'", con);
              
               
                cmd.ExecuteNonQuery();
                con.Close();
                lblmsg.Text = "Password change Successfully !!";

            }
            else
            {
                lblmsg.Text = "Password do not match !!";
            }
        }
    }
}