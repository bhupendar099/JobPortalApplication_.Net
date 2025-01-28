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
    public partial class JobRecruiter_Registration : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=LAPTOP-84MRHNGB; initial catalog=dbjobportal_1; integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindState();
            }
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
            SqlCommand cmd = new SqlCommand("select *from tblcity where stateId='" + ddlstate.SelectedValue + "'", con);
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

        protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindCity();
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            string PhotoName = DateTime.Now.Ticks.ToString()+Path.GetFileName(fuphoto.PostedFile.FileName);

            fuphoto.SaveAs(Server.MapPath("JobSeekerPhotos" + "\\" + PhotoName));
            con.Open();
            SqlCommand cmd = new SqlCommand("proc_JobRecruiter", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "INSERT");
            cmd.Parameters.AddWithValue("@JRName", txtname.Text);
            cmd.Parameters.AddWithValue("@JREmail", txtemil.Text);
            cmd.Parameters.AddWithValue("@JRPassword", txtpassword.Text);
            cmd.Parameters.AddWithValue("@JRState", ddlstate.SelectedValue);
            cmd.Parameters.AddWithValue("@JRCity", ddlcity.SelectedValue);
            cmd.Parameters.AddWithValue("@JRURL", txturl.Text);
            cmd.Parameters.AddWithValue("@JRImage", PhotoName);
            cmd.Parameters.AddWithValue("@JRAddress", txtaddress.Text);
            cmd.Parameters.AddWithValue("@JRComment", txtcomment.Text);
            cmd.ExecuteNonQuery();
            con.Close();

        }
    }
}