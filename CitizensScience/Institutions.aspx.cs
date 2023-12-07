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
    public partial class Institutions : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindInstitutions();
            }
        }

        private void BindInstitutions()
        {
            DataTable dt = GetInstitutionsData();
            InstitutionsRepeater.DataSource = dt;
            InstitutionsRepeater.DataBind();
        }

        private DataTable GetInstitutionsData()
        {
            DataTable dt = new DataTable();
            string connString = ConfigurationManager.ConnectionStrings["CitizenScienceDB"].ToString();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("EXEC GetAllInstitutions", conn)) // Calling the stored procedure
                {
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