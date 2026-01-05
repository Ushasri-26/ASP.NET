using Antlr.Runtime.Misc;
using FirstMVC_Prj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstMVC_Prj.Controllers
{
    public class DemoController : Controller
    {
        // GET: Demo
        public ActionResult Index()
        {
            return View();
        }

        //1.Normal Method
        public string NormalMethod()
        {
            return "Hi All..Welcome to MVC";
        }
        //2. view result
        public ViewResult ViewMethod()
        {
            return View();
        }
        //3. Content result
        public ContentResult ContentMethod()
        {
            // return Content("Hello All!! this is the content", "text/plain");
            return Content("<h1 style=color:green;>Hii Usha sri..!!!</h1>");
        }
        //4. emptyresult
        public EmptyResult EmptyMethod()
        {
            int amt = 45000;
            float si = (amt * 3 * 2) / 100;
            return new EmptyResult();
        }
        //5.Redirect Method
        public ActionResult redirectMethod()
        {
            // return RedirectToAction("ContentMethod"); //redirecting to other action needed
            //of the same controller

            return RedirectToAction("index","home"); // redirecting to other action needed                                                      //of the different controller
        }
        //6.json result
        public JsonResult JsonMethod()
        {
            Employee emp = new Employee() { Id=101,Name="Usha sri",Age=22};
            return Json(emp,JsonRequestBehavior.AllowGet);
        }
        //to check if the tempdata values are available here from the previous controllers multiple requests
        public ActionResult Test_TempData_across_controllers()
        {
            TempData.Keep();
            return View(TempData["stores"]);
        }


        //this action method is to test the tempdata values being made
        //available even after traversing many requests, and without redirection
        public ActionResult CheckTempdata()
        {
            TempData.Keep();
            return View(TempData["stores"]);
        }
    }
}