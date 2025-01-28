using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace JobPortalApplication.JobSeekerModule
{
    public partial class JobSeekerChangePassword : System.Web.UI.Page
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
                SqlCommand cmd = new SqlCommand("update tbljobseeker set jobseekerPassword = '" + txtnew.Text + "' where jobseekerId = '" + Session["JSID"] + "' and jobseekerPassword = '" + txtcurrent.Text+"'",con);
               
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