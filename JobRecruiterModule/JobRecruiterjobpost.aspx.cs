using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Services.Protocols;

namespace JobPortalApplication.JobRecruiterModule
{
    public partial class JobRecruiterjobpost : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=LAPTOP-84MRHNGB; initial catalog=dbjobportal_1; integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindJobProfile();
                BindQualification();
                BindGender();
            }

            if (Request.QueryString["pp"] != null && Request.QueryString["pp"].ToString() != "")
            {
                if (!IsPostBack)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("jobPost_proc", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@action", "EDIT");
                    cmd.Parameters.AddWithValue("@JobPostId", Request.QueryString["pp"]);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    con.Close();
                    ddljobprofile.SelectedValue = dt.Rows[0]["JobPostJobProfileId"].ToString();
                    ddljobmode.SelectedValue = dt.Rows[0]["JobPostMode"].ToString();
                    rblgender.SelectedValue = dt.Rows[0]["JobPostGender"].ToString();
                    string[] arr = dt.Rows[0]["JobPostQualification"].ToString().Split(',');
                    for (int i = 0; i < cblqualification.Items.Count; i++)
                    {
                        for(int j=0; j<arr.Length; j++)
                        {
                            if (cblqualification.Items[i].Text == arr[j])
                            {
                                cblqualification.Items[i].Selected = true;
                            }
                        }
                    }

                        txtminexp.Text = dt.Rows[0]["JobPostMinExp"].ToString();
                    txtmaxexp.Text = dt.Rows[0]["JobPostMaxExp"].ToString();
                    txtminsalary.Text = dt.Rows[0]["JobPostMinSalary"].ToString();
                    txtmaxsalary.Text = dt.Rows[0]["JobPostMaxSalary"].ToString();
                    txtvacancy.Text = dt.Rows[0]["JobPostVacancy"].ToString();
                    txtcomment.Text = dt.Rows[0]["JobPostComments"].ToString();
                    btnpostjob.Text = "Update";
                }
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
        public void BindQualification()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select *from tblqualification", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            cblqualification.DataValueField = "qualificationId";
            cblqualification.DataTextField = "qualificationName";
            cblqualification.DataSource = dt;
            cblqualification.DataBind();

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

        protected void btnpostjob_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtminsalary.Text) < Convert.ToInt32(txtmaxsalary.Text))
            {
                if (Convert.ToInt32(txtminexp.Text) < Convert.ToInt32(txtmaxexp.Text))
                {
                    string kk = "";
                    for (int i = 0; i < cblqualification.Items.Count; i++)
                    {
                        if (cblqualification.Items[i].Selected == true)
                        {
                            kk += cblqualification.Items[i].Text + ",";
                        }
                    }
                    kk = kk.TrimEnd(',');

                    if (btnpostjob.Text == "Post Your Job")
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("jobPost_proc", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@action", "insert");
                        cmd.Parameters.AddWithValue("@JobRecruiterId", Session["JRID"]);
                        cmd.Parameters.AddWithValue("@JobPostJobProfileId", ddljobprofile.SelectedValue);
                        cmd.Parameters.AddWithValue("@JobPostMode", ddljobmode.SelectedValue);
                        cmd.Parameters.AddWithValue("@JobPostGender", rblgender.SelectedValue);
                        cmd.Parameters.AddWithValue("@JobPostQualification", kk);
                        cmd.Parameters.AddWithValue("@JobPostMinExp", txtminexp.Text);
                        cmd.Parameters.AddWithValue("@JobPostMaxExp", txtmaxexp.Text);
                        cmd.Parameters.AddWithValue("@JobPostMinSalary", txtminsalary.Text);
                        cmd.Parameters.AddWithValue("@JobPostMaxSalary", txtmaxsalary.Text);
                        cmd.Parameters.AddWithValue("@JobPostVacancy", txtvacancy.Text);
                        cmd.Parameters.AddWithValue("@JobPostComments", txtcomment.Text);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        Response.Redirect("JobRecruiterShowjobpost.aspx");
                    }
                    else if (btnpostjob.Text == "Update")
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("jobPost_proc", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@action", "update");
                        cmd.Parameters.AddWithValue("@JobPostId", Request.QueryString["pp"]);
                        cmd.Parameters.AddWithValue("@JobRecruiterId", Session["JRID"]);
                        cmd.Parameters.AddWithValue("@JobPostJobProfileId", ddljobprofile.SelectedValue);
                        cmd.Parameters.AddWithValue("@JobPostMode", ddljobmode.SelectedValue);
                        cmd.Parameters.AddWithValue("@JobPostGender", rblgender.SelectedValue);
                        cmd.Parameters.AddWithValue("@JobPostQualification", kk);
                        cmd.Parameters.AddWithValue("@JobPostMinExp", txtminexp.Text);
                        cmd.Parameters.AddWithValue("@JobPostMaxExp", txtmaxexp.Text);
                        cmd.Parameters.AddWithValue("@JobPostMinSalary", txtminsalary.Text);
                        cmd.Parameters.AddWithValue("@JobPostMaxSalary", txtmaxsalary.Text);
                        cmd.Parameters.AddWithValue("@JobPostVacancy", txtvacancy.Text);
                        cmd.Parameters.AddWithValue("@JobPostComments", txtcomment.Text);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        Response.Redirect("JobRecruiterShowjobpost.aspx");
                    }
                }
                else
                {
                    lblmsg.Text = "Minimum Experience Should Be Minimum than the Maximum Experience";
                }

            }
            else
            {
                lblmsg.Text = "Minimum Sallary Should Be Minimum than the Maximum Sallary";
            }

           
        }
    }
}