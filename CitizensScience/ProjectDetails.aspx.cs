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
    public partial class ProjectDetails : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string projectID = Request.QueryString["ProjectID"];
                if (string.IsNullOrEmpty(projectID))
                {
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    DataTable dt = GetDataFromDatabase(projectID);
                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        lblProjectID.Text = row["ProjectID"].ToString();
                        lblProjectName.Text = row["ProjectName"].ToString();
                        lblStartDate.Text = Convert.ToDateTime(row["StartDate"]).ToString("yyyy-MM-dd");
                        lblEndDate.Text = Convert.ToDateTime(row["EndDate"]).ToString("yyyy-MM-dd");
                        lblCoordinatorID.Text = row["Coordinator"].ToString();
                        lblDescription.Text = row["Description"].ToString();
                        lblResearchID.Text = row["ResearchID"].ToString();
                    }
                }
            }
        }

        private DataTable GetDataFromDatabase(string projectID)
        {
            DataTable dt = new DataTable();
            string connString = ConfigurationManager.ConnectionStrings["CitizenScienceDB"].ToString();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                string spName = "GetProjectDetails";
                using (SqlCommand cmd = new SqlCommand(spName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProjectID", projectID);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }

            return dt;
        }
    }
}