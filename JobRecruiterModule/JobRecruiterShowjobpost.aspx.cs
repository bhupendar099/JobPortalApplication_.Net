using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace JobPortalApplication.JobRecruiterModule
{
    public partial class JobRecruiterShowjobpost : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=LAPTOP-84MRHNGB; initial catalog=dbjobportal_1; integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            BindShowPost();
        }
        public void BindShowPost()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("jobPost_proc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "jobshow");
            cmd.Parameters.AddWithValue("@JobRecruiterId", Session["JRID"]); 
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            jobpostshow.DataSource = dt;
            jobpostshow.DataBind();
           
        }

        protected void jobpostshow_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "A")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from tblJobPost where JobPostId='" + e.CommandArgument + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                BindShowPost();
            }
            else if (e.CommandName == "B")
            {
                Response.Redirect("JobRecruiterjobpost.aspx?pp=" + e.CommandArgument);
            }
        }
    }
}