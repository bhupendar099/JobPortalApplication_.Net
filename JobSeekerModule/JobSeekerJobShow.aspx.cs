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
    public partial class JobSeekerJobShow : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=LAPTOP-84MRHNGB; initial catalog=dbjobportal_1; integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindShowPost();
                BindJobProfile();
            }
        }
        public void BindShowPost()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("jobPost_proc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "jobshowAllactive");
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            jobpostshow.DataSource = dt;
            jobpostshow.DataBind();

        }
        public void BindJobProfile()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select *from tbljobprofile", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            ddljobprofile.DataValueField = "jobprofileId";
            ddljobprofile.DataTextField = "jobprofileName";
            ddljobprofile.DataSource = dt;
            ddljobprofile.DataBind();
            ddljobprofile.Items.Insert(0, new ListItem("--select--", "0"));
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("jobPost_proc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "searchjobpost");
            cmd.Parameters.AddWithValue("@JobPostJobProfileId", ddljobprofile.SelectedValue);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            jobpostshow.DataSource = dt;
            jobpostshow.DataBind();

        }
    }
}