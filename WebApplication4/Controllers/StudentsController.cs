using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class StudentsController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            
            
            SqlConnection con =
                new SqlConnection(
                    "Data Source=localhost,1433;Initial Catalog=master;User ID=SA;Password=<YourStrong@Passw0rd>; TrustServerCertificate=true;");
            SqlCommand com = new SqlCommand();
            com.CommandText = "SELECT * FROM Student";

            com.Connection = con;
            
            con.Open();
            var dr = com.ExecuteReader();
            var students = new List<Student>();
            
            while(dr.Read()) 
            {
                var s = new Student();
                s.FirstName = dr["FirstName"].ToString();
                s.LastName = dr["LastName"].ToString();
                s.IdStudent = int.Parse(dr["IdStudent"].ToString());
                students.Add(s);
            }
            
            // ViewBag.Names = names;
            // ViewBag.Title = "Students";
            return View(students);
        }
    }
}