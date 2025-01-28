using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace JobPortalApplication.AdminModule
{
    public partial class AdminManageJobSeeker : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=LAPTOP-84MRHNGB; initial catalog=dbjobportal_1; integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                BindJObSeeker();
            }
        }
        public void BindJObSeeker()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select *from tbljobseeker join tblstate on jobseekerState=stateId join tblcity on jobseekerCity=cityid join seekerGender on jobseekerGender=sgid join tbljobprofile on jobseekerJobprofile =jobprofileId join tblqualification on jobseekerQualification=qualificationId ", con);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            gvjobseeker.DataSource = dt;
            gvjobseeker.DataBind();
        }

        protected void gvjobseeker_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "A")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("proc_jobseeker", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "jobSeekerblock");
                cmd.Parameters.AddWithValue("@jobseekerId", e.CommandArgument);
                cmd.ExecuteNonQuery();
                con.Close();
                BindJObSeeker();
            }
        }
    }
}