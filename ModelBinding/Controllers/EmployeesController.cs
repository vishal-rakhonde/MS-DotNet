using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelBinding.Models;

namespace ModelBinding.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: EmployeesController
        public ActionResult Index()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee { EmpNo = 1, Name = "Kajal", Basic = 12345, DeptNo = 10 });
            employees.Add(new Employee { EmpNo = 2, Name = "Paras", Basic = 10000, DeptNo = 10 });
            employees.Add(new Employee { EmpNo = 3, Name = "Naresh", Basic = 99999, DeptNo = 20 });

            //List<Employee> employees = Employee.GetAllEmployees();
            return View(employees);
        }

        // GET: EmployeesController/Details/5
        public ActionResult Details(int id=1)
        {
            Employee obj = new Employee();
            obj.EmpNo = id;
            obj.Name = "Vikram";
            obj.Basic = 12345;
            obj.DeptNo = 10;

            //Employee obj = Employee.GetSingleEmployee(id);
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
        //public ActionResult Create(IFormCollection collection)
        //public ActionResult Create(int EmpNo, string Name, decimal Basic, int DeptNo)  //Binding
        //public ActionResult Create(Employee obj,IFormCollection collection,int EmpNo, string Name, decimal Basic, int DeptNo)  //Model Binding
        public ActionResult Create(Employee obj)  //Model Binding
        {
            try
            {
                //Employee.Insert(obj);

                //string name = collection["Name"];
                //string empno = collection["EmpNo"];
                //string basic = collection["Basic"];
                //string deptno = collection["DeptNo"];
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/Edit/5
        public ActionResult Edit(int id)
        {
            Employee obj = new Employee();
            obj.EmpNo = id;
            obj.Name = "Vikram";
            obj.Basic = 12345;
            obj.DeptNo = 10;
            return View(obj);
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee obj)
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
            Employee obj = new Employee();
            obj.EmpNo = id;
            obj.Name = "Vikram";
            obj.Basic = 12345;
            obj.DeptNo = 10;
            return View(obj);
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
