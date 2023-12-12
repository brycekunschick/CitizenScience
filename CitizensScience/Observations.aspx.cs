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

                if (string.IsNullOrEmpty(userID))
                {
                    litMessage.Text = "You must be logged in to view or add observations.";
                    LoginButton.Visible = true; // Show login button
                }
                else
                {
                    // Load initial observations
                    DataTable dt = GetDataFromDatabase(userID);
                    ObservationsGridView.DataSource = dt;
                    ObservationsGridView.DataBind();

                    // Make controls visible for logged-in users
                    ObservationsGridView.Visible = true;
                    AddObservationButton.Visible = true;
                    btnBackToHome.Visible = true;
                    txtSearch.Visible = true;
                    btnSearch.Visible = true;
                }
            }
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void AddObservationButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddObservation.aspx");
        }

        protected void btnBackToHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string userID = HttpContext.Current.User.Identity.GetUserId();
            string searchTerm = txtSearch.Text.Trim();
            DataTable dt = SearchObservations(userID, searchTerm);
            ObservationsGridView.DataSource = dt;
            ObservationsGridView.DataBind();
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
        private DataTable SearchObservations(string userID, string searchTerm)
        {
            DataTable dt = new DataTable();
            string connString = ConfigurationManager.ConnectionStrings["CitizenScienceDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("SearchObservationsByUser", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", userID);
                cmd.Parameters.AddWithValue("@SearchTerm", searchTerm);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            return dt;
        }


    }
}