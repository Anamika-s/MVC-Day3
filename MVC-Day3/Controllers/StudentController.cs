using Microsoft.AspNetCore.Mvc;
using MVC_Day3.Models;

namespace MVC_Day3.Controllers
{
    public class StudentController : Controller
    {
        static List<Student> list = null;
        public StudentController()
        {
            if (list == null)
            {
                list = new List<Student>()
            {
new Student() { Id =1, Name="Deepak", Batch="B001", Marks=90 },

new Student() { Id =2, Name="Pawan", Batch="B001", Marks=81 },

new Student() { Id =3, Name="Deepti", Batch="B002", Marks=78 }
            };
            }
        }
        public IActionResult Index()
        {

            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            list.Add(student);
            //return View();
            return RedirectToAction("Index");

        }

        public IActionResult Display(int? id)
        {
            if (!id.HasValue)
            {
                ViewBag.msg = "Please provide a ID"; return View();
            }
            else
            {
                var student = list.Where(x => x.Id == id).FirstOrDefault();
                if (student == null)
                {
                    ViewBag.msg = "There is no record woth this ID";
                    return View();
                }
                else
                    return View(student);
            }


        }
        public IActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                ViewBag.msg = "Please provide a ID"; return View();
            }
            else
            {
                var student = list.Where(x => x.Id == id).FirstOrDefault();
                if (student == null)
                {
                    ViewBag.msg = "There is no record woth this ID";
                    return View();
                }
                else
                    return View(student);
            }


        }
        [HttpPost]
        public IActionResult Delete(Student student, int id)
        {
            var temp = list.Where(x => x.Id == id).FirstOrDefault();
            if (temp != null)
                list.Remove(temp);
            return RedirectToAction("Index");

        }
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                ViewBag.msg = "Please provide a ID"; return View();
            }
            else
            {
                var student = list.Where(x => x.Id == id).FirstOrDefault();
                if (student == null)
                {
                    ViewBag.msg = "There is no record woth this ID";
                    return View();
                }
                else
                    return View(student);
            }

        }

        [HttpPost]
        public IActionResult Edit(Student student, int id)
        {
            var temp = list.Where(x => x.Id == id).FirstOrDefault();
            if (temp != null)
            {
                foreach (Student stu in list)
                {
                    if (stu.Id == temp.Id)
                    {
                        stu.Batch = student.Batch;
                        stu.Marks = student.Marks;
                        break;
                    }
                     

                }
            }
            return RedirectToAction("Index");

        }


    }
}

   

