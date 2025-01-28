using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JobPortalApplication
{
    public partial class LogIn : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=LAPTOP-84MRHNGB; initial catalog=dbjobportal_1; integrated security=true");
       

        protected void Page_Load(object sender, EventArgs e)
        {
            // Optional: Any logic needed when the page loads.
        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            if (ddlusertype.SelectedValue == "1")
            {
                using (con)
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("select * from tblAdmin where AdminEmail = '" + txtemail.Text + "' and AdminPassword = '" + txtpassword.Text + "'", con))
                    {

                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);

                        if (dt.Rows.Count == 0)
                        {
                            lblmsg.Text = "Login Failed!";
                        }
                        else
                        {
                            Session["AID"] = dt.Rows[0]["AdminID"];
                            lblmsg.Text = "Login Successfully!";
                            Response.Redirect("~/AdminModule/AdminHome.aspx");
                        }
                    }
                }

            }
            else if (ddlusertype.SelectedValue == "2") // Job Seeker
            {
               

                using (con)
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("select * from tbljobseeker where jobseekerEmail = '"+ txtemail.Text + "' and jobseekerPassword = '"+ txtpassword.Text + "' and jobseekerStatus=0", con))
                    {
                        
                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);

                        if (dt.Rows.Count == 0)
                        {
                            lblmsg.Text = "Login Failed!";
                        }
                        else
                        {
                            Session["JSID"] = dt.Rows[0]["jobseekerId"];
                            lblmsg.Text = "Login Successfully!";
                            Response.Redirect("~/JobSeekerModule/JobSeekerHome.aspx");
                        }
                    }
                }
            }
            else if (ddlusertype.SelectedValue == "3") // Job Recruiter
            {
              

                using (con)
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("select * from tbljobrecruiter where JREmail ='"+ txtemail.Text + "' and JRPassword = '"+ txtpassword.Text + "' and JRStatus=0", con))
                    {
                        
                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);

                        if (dt.Rows.Count == 0)
                        {
                            lblmsg.Text = "Login Failed!";
                        }
                        else
                        {
                            Session["JRID"] = dt.Rows[0]["JRId"];
                            lblmsg.Text = "Login Successfully!";
                            Response.Redirect("~/JobRecruiterModule/JobRecruiterHome.aspx");
                        }
                    }
                }
            }
        }
    }
}