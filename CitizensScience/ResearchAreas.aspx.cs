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
                // Get the InstID from the query string
                string instID = Request.QueryString["InstID"];

                // Pass the InstID to GetDataFromDatabase, which will handle null or empty
                ResearchAreasRepeater.DataSource = GetDataFromDatabase(instID);
                ResearchAreasRepeater.DataBind();
            }
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