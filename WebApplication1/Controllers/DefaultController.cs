using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index(int? id, int b=10, int a = 5, int c=0)
        {
            //if (id == null)
            //    return NotFound();
            ViewBag.id = id;
            ViewBag.a = a;
            ViewBag.b = b;
            ViewBag.c = c;


            return View();
        }
    }
}
