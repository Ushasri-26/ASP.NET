using FirstMVC_Prj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstMVC_Prj.Controllers
{
    public class HRController : Controller
    {
        // GET: HR
        //3.calling another view and passing the model object
        public ActionResult Index()
        {
            List<Department> dList = new List<Department>()
            {
                new Department{Id=1, DeptName="CSE"},
                new Department{Id=2, DeptName="ECE" },
                new Department{Id=3, DeptName="IT"},
                new Department{Id=4, DeptName="EEE"},
            };
            return View("DepartmentList", dList);
        }
        //the recieving view
        public ActionResult DepartmentList(List<Department> d)
        {
            return View(d);
        }
        //1.Binding a model object to a view
        public ActionResult DisplayEmployee()
        {
            Employee employee = new Employee() { Id=1,Name="Monika",Age=21};
            return View(employee); //passing a model object of type Employee
        }
        //2. Binding a collection model object to a view
        public ActionResult EmployeeList()
        {
            List<Employee> emplist = new List<Employee>()
            {
                new Employee { Id=10, Name="Sravani",Age=26},
                new Employee { Id=11, Name="Monika",Age=20},
                new Employee { Id=12, Name="Bhavya",Age =19}
            };
            return View(emplist);
        }
        //4. To change the name of the view different from action method name 
        //4.1 We can give action name selector and map it to different view name

        //4.2 We can change the view name to suit the action name
        [ActionName("Test")]
        public ActionResult DifferentViewName()
        {
            ViewBag.sample = "Testing Views with different names";
            // return View("DifferentViewName"); //4.1
            return View();
        }
    }
}