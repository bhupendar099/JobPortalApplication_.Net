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
    public partial class JobRecruiterHome : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=LAPTOP-84MRHNGB; initial catalog=dbjobportal_1; integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                jobrecruiters();
            }
        }
        public void jobrecruiters()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tbljobrecruiter where JRId='" + Session["JRID"] + "' ", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Gvjobrecruiter.DataSource = dt;
            Gvjobrecruiter.DataBind();
        }
    }
}