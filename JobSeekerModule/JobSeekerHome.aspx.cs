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
    public partial class JobSeekerHome : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=LAPTOP-84MRHNGB; initial catalog=dbjobportal_1; integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                jobseekers();
            }
        }
        public void jobseekers()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tbljobseeker join tblstate on jobseekerState=stateId join tblquestion on jobseekerQuestion=questionId join tbljobprofile on jobseekerJobprofile=jobprofileId join tblcity on jobseekerCity=cityId join tblqualification on jobseekerQualification=qualificationId join seekerGender on jobseekerGender=sgid where jobseekerId='" + Session["JSID"]+"' ", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            lblname.Text = dt.Rows[0]["jobseekerName"].ToString();
            lblemil.Text = dt.Rows[0]["jobseekerEmail"].ToString();
            lblpassword.Text = dt.Rows[0]["jobseekerPassword"].ToString();
            lbljobprofile.Text = dt.Rows[0]["JobprofileName"].ToString();
            lblgender.Text = dt.Rows[0]["sgname"].ToString();
            lbljobexperience.Text = dt.Rows[0]["jobseekerExp"].ToString();
            lblqualification.Text = dt.Rows[0]["qualificationName"].ToString();
            lblquestion.Text = dt.Rows[0]["questionName"].ToString();
            lblanswer.Text = dt.Rows[0]["jobseekerAnswer"].ToString();
            lblbod.Text = dt.Rows[0]["jobseekerDOB"].ToString();
            lblcity.Text = dt.Rows[0]["cityName"].ToString();
            lblstate.Text = dt.Rows[0]["stateName"].ToString();
            lblphoto.Text = dt.Rows[0]["jobseekerImage"].ToString();
            lblresume.Text = dt.Rows[0]["jobseekerResume"].ToString();
            lblcomment.Text = dt.Rows[0]["jobseekerComments"].ToString();

            con.Close();

        

        }
    }
}