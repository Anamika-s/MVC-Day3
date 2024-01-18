using Microsoft.AspNetCore.Mvc;
using MVC_Day3.Models;

namespace MVC_Day3.Controllers
{
    public class EmployeeController : Controller
    {
        static List<User> list = new List<User>();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(User user)
        {  if (ModelState.IsValid)
            {
                list.Add(user);
                return RedirectToAction("Index");
            }
            else
                return View();
            

        }

        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> checkdate(DateTime doj)
        {
            if (doj <= DateTime.Now)
                return Json(data: true);
            else
                return Json(data: false);
        }
    }
}
