using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelBinding.Models;

namespace ModelBinding.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: EmployeesController
        //Employees/Index
        public ActionResult Index()
        {
            List<Employee> employees = Employee.GetAllEmployees();
            return View(employees);
        }
        // GET: EmployeesController/Details/5
        //Employees/Details/2
        public ActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();
            Employee obj = Employee.GetSingleEmployee(id.Value);
            if (obj == null)
                //return NotFound();
                ViewBag.message = "No record found";
            return View(obj);


        }

        // GET: EmployeesController/Create
        //[HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee obj) //ModelBinding
        {
            try
            {
                Employee.Insert(obj);

                ViewBag.message = "Successfully inserted";
                return View();

                //return RedirectToAction("Index");
                //return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.message = ex.Message;
                return View();
            }
        }
        //public ActionResult Create(string Name, int EmpNo, decimal Basic, int DeptNo) //Binding
        //{
        //    try
        //    {


        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //public ActionResult Create(IFormCollection collection) //using IFormCollection
        //{
        //    try
        //    {
        //        string Name = collection["Name"];
        //        string EmpNo = collection["EmpNo"];
        //        string Basic = collection["Basic"];
        //        string DeptNo = collection["DeptNo"];


        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: EmployeesController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();
            Employee obj = Employee.GetSingleEmployee(id.Value);
            return View(obj);
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee obj)
        {
            try
            {
                Employee.Update(obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();
            Employee obj = Employee.GetSingleEmployee(id.Value);
            return View(obj);
        }

        // POST: EmployeesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Employee.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
