using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using static Student_Management_Application.Pages.NewStudentModel;

namespace Student_Management_Application.Pages
{
    public class DeleteStudentModel : PageModel
    {
        public StudentEntities stud = new StudentEntities();
        public void OnPost()
        {
            string id = Request.Form["id"];
           

            try
            {
                string connectionString = "Data Source=MANOHARES-5279\\SQLEXPRESS;Initial Catalog=release;Integrated Security=True";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string sql = "DELETE FROM student WHERE id = @id";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                        Response.Redirect("/SuccessDeletion");
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

