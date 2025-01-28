using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace JobPortalApplication
{
    public partial class JobSeeker_Registration : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=LAPTOP-84MRHNGB; initial catalog=dbjobportal_1; integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindJobProfile();
                BindQualification();
                BindState();
                BindQuestion();
                BindGender();
            }

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

        public void BindQuestion()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select *from tblquestion", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
           ddlquestion.DataValueField = "questionId";
            ddlquestion.DataTextField = "questionName";
            ddlquestion.DataSource = dt;
            ddlquestion.DataBind();
            ddlquestion.Items.Insert(0, new ListItem("--select--", "0"));
        }
        public void BindQualification()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select *from tblqualification", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            ddlqualification.DataValueField = "qualificationId";
            ddlqualification.DataTextField = "qualificationName";
            ddlqualification.DataSource = dt;
            ddlqualification.DataBind();
            ddlqualification.Items.Insert(0, new ListItem("--select--", "0"));
        }

        public void BindState()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select *from tblstate", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            ddlstate.DataValueField = "stateId";
            ddlstate.DataTextField = "stateName";
            ddlstate.DataSource = dt;
            ddlstate.DataBind();
            ddlstate.Items.Insert(0, new ListItem("--select--", "0"));
        }

        public void BindCity()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select *from tblcity where stateId='"+ddlstate.SelectedValue+"'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            ddlcity.DataValueField = "cityId";
            ddlcity.DataTextField = "cityName";
            ddlcity.DataSource = dt;
            ddlcity.DataBind();
            ddlcity.Items.Insert(0, new ListItem("--select--", "0"));
        }
        public void BindGender()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select *from seekerGender ", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            rblgender.DataValueField = "sgid";
            rblgender.DataTextField = "sgname";
            rblgender.DataSource = dt;
            rblgender.DataBind();
            
        }

        protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindCity();
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            string ResumeName = DateTime.Now.Ticks.ToString()+Path.GetFileName(furesume.PostedFile.FileName);
            string PhotoName = DateTime.Now.Ticks.ToString()+Path.GetFileName(fuphoto.PostedFile.FileName);

         furesume.SaveAs(Server.MapPath("JobSeekerResume" + "\\" + ResumeName));
      fuphoto.SaveAs(Server.MapPath("JobSeekerPhotos" + "\\" + PhotoName));
            con.Open();
            SqlCommand cmd = new SqlCommand("proc_jobseeker", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "INSERT");
            cmd.Parameters.AddWithValue("@jobseekerName", txtname.Text);
            cmd.Parameters.AddWithValue("@jobseekerEmail", txtemil.Text);
            cmd.Parameters.AddWithValue("@jobseekerPassword",txtpassword.Text);
            cmd.Parameters.AddWithValue("@jobseekerGender", rblgender.SelectedValue);
            cmd.Parameters.AddWithValue("@jobseekerJobprofile",ddljobprofile.SelectedValue);
            cmd.Parameters.AddWithValue("@jobseekerQualification", ddlqualification.SelectedValue);
            cmd.Parameters.AddWithValue("@jobseekerState", ddlstate.SelectedValue);
            cmd.Parameters.AddWithValue("@jobseekerCity", ddlcity.SelectedValue);
            cmd.Parameters.AddWithValue("@jobseekerQuestion", ddlquestion.SelectedValue);
            cmd.Parameters.AddWithValue("@jobseekerAnswer", txtanswer.Text);
            cmd.Parameters.AddWithValue("@jobseekerExp", ddljobexperience.SelectedValue);
            cmd.Parameters.AddWithValue("@jobseekerDOB", txtbod.Text);
            cmd.Parameters.AddWithValue("@jobseekerResume", ResumeName);
            cmd.Parameters.AddWithValue("@jobseekerImage", PhotoName);
            cmd.Parameters.AddWithValue("@jobseekerComments", txtcomment.Text);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}