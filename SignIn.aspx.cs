using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SignIn : System.Web.UI.Page
{
    public string message = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.HttpMethod == "POST")
        {
            string username = Request.Form["UserName"];
            string password = Request.Form["Password"];
            SqlConnection con = new SqlConnection(Settings.ConnectionString);
            con.Open();
            SqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT * FROM Users WHERE UserName = '" + username + "';";
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                if (reader.GetString(1) == password)
                {
                    message = "Succeeded!";
                    Session["UserName"] = reader.GetString(0);
                    Response.Redirect("HomePage.aspx");
                }
                else
                {
                    message = "username or password are incorrect, please try again. ";
                }
            }
            else
            {
                message = "username or password are incorrect, please try again.";
            }
            reader.Close();
            con.Close();
        }
    }
}