using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Signup : System.Web.UI.Page
{
    public string message = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.HttpMethod == "POST") // לאחר שהמשתמש לחץ על סבמיט
        {
            string username = Request.Form["UserName"];
            string password = Request.Form["Pass"];
            string confirmpass = Request.Form["ConfirmPass"];
            string email = Request.Form["Email"];
            string phone = Request.Form["Phone"];

           // SqlConnection connection = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=\"C:\\Users\\user1\\Downloads\\Pro\\Pro\\App_Data\\Database3.mdf\";Integrated Security=True;User Instance=True");
            string path = HttpContext.Current.Server.MapPath("App_Data/");//מיקום מסד בפורוייקט
            path += "Database2.mdf";
            //string path = HttpContext.Current.Server.MapPath("App_Data/" + fileName);//מאתר את מיקום מסד הנתונים מהשורש ועד התקייה בה ממוקם המסד
            string connString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=" +
                                 path +
                                 ";Integrated Security=True;User Instance=True";
            SqlConnection connection = new SqlConnection(Settings.ConnectionString);

            connection.Open();
            
            string sqlstring = String.Format("INSERT INTO Users VALUES('{0}','{1}', '{2}', '{3}')", username, password, email,phone);
            SqlCommand command = new SqlCommand(sqlstring, connection);
           
            try
            {
                command.ExecuteNonQuery(); //מכניס את הנתונים לטבלה
                Session["user"] = Request.Form["username"]; //שומר באובייקט סשן את שם המשתמש
                message += "Succeeded";
                Response.Redirect("SignIn.aspx"); // שולח את המשתמש לדף ההתחברות
            }
            catch (SqlException) //אם שם המשתמש תפוס יהיה אקספשן כי הגדרתי את שם המשתמש בטבלה כיוניק
            {
                message += "The user name is already exists, please choose another one";
            }
            connection.Close();

        }
    }
}