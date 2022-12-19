using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using tp4.Data;
using tp4.Models;

namespace tp4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Debug.WriteLine("****** First place ********");
            UniversityContext UniverCont = UniversityContext.GetCont();
            List<Student> students = UniverCont.Student.ToList();
            int i = 0;
            foreach (Student student in students)
            {
                Debug.WriteLine("Student num " + i + ": ***********");
                Debug.WriteLine(" id " + student.id+ " First Name : " + student.first_name+ " Last Name : " + student.last_name);
                Debug.WriteLine("Phone Number : " + student.phone_number+ " University : " + student.university + " Course : " + student.course+" TimeStamp : " + student.timestamp);
            }
            return View();
        }

        public IActionResult Privacy()
        {
            Debug.WriteLine("****** Second place ********");
            UniversityContext UniverCont = UniversityContext.GetCont();
            List<Student> students = UniverCont.Student.ToList();
            int i = 0;
            foreach (Student student in students)
            {
                Debug.WriteLine("Student num " + i + ": ***********");
                Debug.WriteLine(" id " + student.id + " First Name : " + student.first_name + " Last Name : " + student.last_name);
                Debug.WriteLine("Phone Number : " + student.phone_number + " University : " + student.university + " Course : " + student.course + " TimeStamp : " + student.timestamp);
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Courses() {
            UniversityContext UniverCont = UniversityContext.GetCont();
            RepoStudent repoStudent = new RepoStudent(UniverCont);
            List<string> courses = (List<string>)repoStudent.GetCourses();
            ViewBag.courses = courses;
            return View(); }
        [HttpGet]
        [Route("/Home/Course/{CName}")]
        public IActionResult EtCourses(string CName)
        {
            UniversityContext UniverCont = UniversityContext.GetCont();
            RepoStudent StudentRepo = new RepoStudent(UniverCont);

            IEnumerable<Student> StudentsPerCourse = (IEnumerable<Student>)StudentRepo.GetStudentsPerCourse(CName);
            ViewBag.Cname = CName;
            ViewBag.StudentsPerCourse = StudentsPerCourse;
            return View();
        }
    }
}