using Microsoft.AspNet.Identity;
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
    public partial class Observations : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string userID = HttpContext.Current.User.Identity.GetUserId();

                // Redirect to Default.aspx if userID is null (user not logged in)
                if (string.IsNullOrEmpty(userID))
                {
                    litMessage.Text = "You must be logged in to view or add observations.";
                    ObservationsGridView.Visible = false;
                    AddObservationButton.Visible = false;
                    LoginButton.Visible = true; // Show login button
                    return;
                }

                DataTable dt = GetDataFromDatabase(userID);
                ObservationsGridView.DataSource = dt;
                ObservationsGridView.DataBind();
            }
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        private DataTable GetDataFromDatabase(string userID)
        {
            DataTable dt = new DataTable();
            string connString = ConfigurationManager.ConnectionStrings["CitizenScienceDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("GetObservationsByUser", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", userID);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            return dt;
        }

        protected void AddObservationButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddObservation.aspx");
        }
    }
}