using System;
using System.Collections.Generic;

using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace JobPortalApplication.AdminModule
{
    public partial class AdminManageJobPost : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=LAPTOP-84MRHNGB; initial catalog=dbjobportal_1; integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindShowPost();
            }
        }
        public void BindShowPost()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("jobPost_proc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "jobshowAll");
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
                SqlCommand cmd = new SqlCommand("jobPost_proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "jobPostblock");
                cmd.Parameters.AddWithValue("@JobPostId", e.CommandArgument);
                cmd.ExecuteNonQuery();
                con.Close();
                BindShowPost();
            }
        }
    }
}