using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CitizensScience
{
    public partial class Projects : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string raID = Request.QueryString["RA"];
                if (string.IsNullOrEmpty(raID))
                {
                    Response.Redirect("ResearchAreas.aspx");
                }
                else
                {
                    string researchAreaName = GetResearchAreaName(raID);
                    litHeader.Text = "Projects for " + researchAreaName;

                    ProjectsRepeater.DataSource = GetDataFromDatabase(raID);
                    ProjectsRepeater.DataBind();
                }
            }
        }

        protected void btnBackToResearchAreas_Click(object sender, EventArgs e)
        {
            Response.Redirect("ResearchAreas.aspx");
        }

        private string GetResearchAreaName(string raID)
        {
            string researchAreaName = "";
            string connString = ConfigurationManager.ConnectionStrings["CitizenScienceDB"].ToString();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("GetResearchAreaName", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ResearchAreaID", raID);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        researchAreaName = reader["ResearchName"].ToString();
                    }
                }
            }

            return researchAreaName;
        }

        private DataTable GetDataFromDatabase(string raID)
        {
            DataTable dt = new DataTable();
            string connString = ConfigurationManager.ConnectionStrings["CitizenScienceDB"].ToString();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                // If raID is provided, get projects by research area
                cmd.CommandText = "GetProjectsByRA";
                cmd.Parameters.AddWithValue("@ResearchAreaID", raID);

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }

            return dt;
        }
    }
}