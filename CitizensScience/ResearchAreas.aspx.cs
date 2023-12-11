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
    public partial class ResearchAreas : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string instID = Request.QueryString["InstID"];
                DataTable dt = GetDataFromDatabase(instID);
                ResearchAreasRepeater.DataSource = dt;
                ResearchAreasRepeater.DataBind();

                if (string.IsNullOrEmpty(instID))
                {
                    litHeader.Text = "All Research Areas";
                    btnBack.Text = "Back to Home";
                    btnBack.CommandArgument = "Default.aspx";
                }
                else
                {
                    string institutionName = GetInstitutionName(instID);
                    litHeader.Text = "Research Areas for " + institutionName;
                    btnBack.Text = "Back to Institutions";
                    btnBack.CommandArgument = "Institutions.aspx";
                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Response.Redirect(btn.CommandArgument);
        }

        private string GetInstitutionName(string instID)
        {
            string institutionName = "";
            string connString = ConfigurationManager.ConnectionStrings["CitizenScienceDB"].ToString();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("GetInstitutionName", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@InstitutionID", instID);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        institutionName = reader["InstitutionName"].ToString();
                    }
                }
            }

            return institutionName;
        }

        private DataTable GetDataFromDatabase(string instID)
        {
            DataTable dt = new DataTable();
            string connString = ConfigurationManager.ConnectionStrings["CitizenScienceDB"].ToString();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                // If instID is not provided, use a different stored procedure that gets all research areas
                if (string.IsNullOrEmpty(instID))
                {
                    cmd.CommandText = "GetAllResearchAreas"; // Stored procedure that gets all research areas
                }
                else
                {
                    cmd.CommandText = "GetRAbyInstitution"; // Stored procedure that gets research areas by institution
                    cmd.Parameters.AddWithValue("@InstitutionID", instID);
                }

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }

            return dt;
        }
    }
}