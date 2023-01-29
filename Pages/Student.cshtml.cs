using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;
using static Student_Management_Application.Pages.NewStudentModel;

namespace Student_Management_Application.Pages
{
    public class StudentModel : PageModel
    {
        StudentEntities stud = new StudentEntities();
        
        public void OnGet()
        {
        }

        public void OnPost()
        {
           
            


            try
            {

                stud.id = Request.Form["id"];
                stud.pswd = Request.Form["pswd"];

                SqlConnection scon;
                 SqlCommand scmd;
                 SqlDataAdapter sda;
                 DataSet ds;

                 scon = new SqlConnection("server=MANOHARES-5279\\sqlexpress;uid=sa;pwd=shubham;database=release");
                 scmd = new SqlCommand("select * from student where id=@a and pswd=@b;", scon);
                 scmd.Parameters.AddWithValue("a", stud.id);
                 scmd.Parameters.AddWithValue("b", stud.id);
                 sda = new SqlDataAdapter(scmd);
                 ds = new DataSet();
                 sda.Fill(ds, "a");
                    int cnt = ds.Tables["a"].Rows.Count;

                     if (cnt > 0)
                     {
      
                         Response.Redirect("User.aspx");
                      }
                      else
                      {
                          Response.Redirect("Failure.aspx");
                     }

            }
            catch (Exception)
            {
                Response.Redirect("/Failure");
            }
        }


    }
}
