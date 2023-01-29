using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Data;
namespace Student_Management_Application.Pages
{
    public class NewStudentModel : PageModel
    {
        public class StudentEntities
        {

            public string id="";
            public string pswd="";
            public string name="";
            public string con= "";
        }

        public StudentEntities stud = new StudentEntities();
        public void OnPost() 
        {
            stud.id = Request.Form["id"];   
            stud.pswd = Request.Form["pswd"];
            stud.name = Request.Form["name"];
            stud.con = Request.Form["con"];


            try
            {
                string connectionString = "Data Source=MANOHARES-5279\\SQLEXPRESS;Initial Catalog=release;Integrated Security=True";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string sql = "insert into student" + "(id,pswd,name,con)" +
                        "values(@id,@pswd,@name,@con);";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@id", stud.id);
                        cmd.Parameters.AddWithValue("@pswd", stud.pswd);
                        cmd.Parameters.AddWithValue("@name", stud.name);
                        cmd.Parameters.AddWithValue("@con", stud.con);
                        cmd.ExecuteNonQuery();
                        Response.Redirect("/Success");
                    }
                }

            }
            catch (Exception)
            {
                Response.Redirect("/Failure");
            }
        }    
    }
}
