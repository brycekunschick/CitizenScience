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
    public partial class AddObservation : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (string.IsNullOrEmpty(HttpContext.Current.User.Identity.GetUserId()))
                {
                    Response.Redirect("Default.aspx");
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string userID = HttpContext.Current.User.Identity.GetUserId();
            string notes = txtNotes.Text;

            if (string.IsNullOrWhiteSpace(notes))
            {
                // Handle empty notes, notes is non-nullable in the DB
                return;
            }

            string connString = ConfigurationManager.ConnectionStrings["CitizenScienceDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("AddObservation", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", userID);
                cmd.Parameters.AddWithValue("@Notes", notes);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            Response.Redirect("Observations.aspx");
        }
    }
}