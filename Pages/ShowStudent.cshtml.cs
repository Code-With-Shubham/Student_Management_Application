using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using static Student_Management_Application.Pages.NewStudentModel;

namespace Student_Management_Application.Pages
{
    public class ShowStudentModel : PageModel
    {
        public List<StudentEntities> se = new List<StudentEntities>();
        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=MANOHARES-5279\\SQLEXPRESS;Initial Catalog=release;Integrated Security=True";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string sql = "SELECT *  FROM student";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                StudentEntities studinfo = new StudentEntities();
                                studinfo.id = "" + reader.GetString(0);
                                studinfo.pswd = reader.GetString(1);
                                studinfo.name = reader.GetString(2);
                                studinfo.con = reader.GetString(3);
                                


                                se.Add(studinfo);

                            }
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }
        }
    }
}
