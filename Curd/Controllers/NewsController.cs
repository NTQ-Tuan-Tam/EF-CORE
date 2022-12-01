using Microsoft.AspNetCore.Mvc;

namespace Curd.Controllers
{
    public class NewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult stringOut(int id, Student student)
        {
            return Content($"hel {id} - {student.lastName} {student.firstName}");
        } 
        public IActionResult JsonOut(int id,Student student) 
        {
            var obj = new { Id = id, Student = student };
            return Json(obj);
        }
        public class Student { 
        public string lastName{ get; set; }
        public string firstName{ get; set; }
        
        
        }


    }
}
