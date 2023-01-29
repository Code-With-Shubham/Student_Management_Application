using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static Student_Management_Application.Pages.NewStudentModel;
using System.Data.SqlClient;

namespace Student_Management_Application.Pages
{
    public class UpdateStudentModel : PageModel
    {
        public void OnGet()
        {

        }

       
        public StudentEntities stud = new StudentEntities();
        public void OnPost()
        {
            string con1 = Request.Form["con"];
            string id = Request.Form["id"];


            try
            {
                string connectionString = "Data Source=MANOHARES-5279\\SQLEXPRESS;Initial Catalog=release;Integrated Security=True";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string sql = "UPDATE student SET con = @con WHERE id = @id";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@con", con1);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                        Response.Redirect("/SuccessUpdation");
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
