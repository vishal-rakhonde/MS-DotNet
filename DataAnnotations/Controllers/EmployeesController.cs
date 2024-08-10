using DataAnnotations.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataAnnotations.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: EmployeesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: EmployeesController/Details/5
        public ActionResult Details(int id=1)
        {
            return View();
        }

        // GET: EmployeesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee obj )
        //model binding
        //obj = get value from html control
        //obj.EmpNo = html control EmpNo
        //obj.Name = html control Name
        //obj.Basic = html control Basic  ---> set Basic
        //obj.DeptNo = html control DeptNo



        {
            try
            {
                //if(ModelState.IsValid) {
                //if (ModelState.IsValid) //true when no exceptions during model binding
                foreach (var item in ModelState.Values)
                {
                    foreach (var item2 in item.Errors)
                    {
                        //item2.ErrorMessage
                    }
                }
                return View();
               // return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
