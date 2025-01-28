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
    public partial class AdminManageJobRecruiter : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=LAPTOP-84MRHNGB; initial catalog=dbjobportal_1; integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindJobRecruiter();
            }
        }
        public void BindJobRecruiter()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select *from tbljobrecruiter join tblstate on JRState=stateId join tblcity on JRCity=cityid", con);

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
                SqlCommand cmd = new SqlCommand("proc_JobRecruiter", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "jobrecruiterblock");
                cmd.Parameters.AddWithValue("@JRId", e.CommandArgument);
                cmd.ExecuteNonQuery();
                con.Close();
                BindJobRecruiter();
            }
        }
    }
}