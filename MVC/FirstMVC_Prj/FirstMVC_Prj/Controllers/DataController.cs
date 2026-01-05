using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstMVC_Prj.Controllers
{
    public class DataController : Controller
    {
        // GET: Data
        public ActionResult Index()
        {
            //1. passing an object to the view that will be used as a model
            //ViewBag.data = "Flowers List";
            //List<string> flowers = new List<string>()
            //{
            //    "Roses", "Jasmine", "Chrysanthemum", "Marigolds", "Lillies", "Tulips"
            //};
            //return View(flowers);

            // trying to access tempdata of the earlier few requests
            List<string> stlist = TempData["stores"] as List<string>;
            //return View(stlist); able to see tempdata from previous many requests

            //redirecting to see tempdata values in different controller
            return RedirectToAction("Test_TempData_across_controllers","Demo");
        }

        //2. Checking if the viewbag can pass on the data/info to further requests
        public ActionResult TestDataTransfer()
        {
            ViewBag.data1 = "Data One";
            ViewData["data2"] = "Data Two";
            //return View(); // data passed to the current view
            return RedirectToAction ("Index");
        }

        //3. passing data through viewbag and viewdata
        public ActionResult OfficeRules()
        {
            List<string> rules = new List<string>
            { 
                "Be on Time", "Carry your ID card", "Complete work as per Deadline", "Avoid T-Shirts"
            };
            //3.1 transfer data through viewbag
            ViewBag.ofcrules = rules;
            //return View();
            
            //3.2 transfer using viewdata
            ViewData["or"] = rules;
            //return View();
            return RedirectToAction("TestDataTransfer");
        }
        //4. Passing data through tempdata object
        public ActionResult FirstTempRequest()
        {
            List<string> stationeries = new List<string>()
            {
                "Pens", "Crayons", "WaterColors", "Sketches", "Markers", "Colorpens", "Pencils", "Erasers"
            };
            TempData["stores"] = stationeries;

            //4.1 using tempdata in the current view
            //return View();

            //4.2 redirecting to see if tempdata is available
            return RedirectToAction("SecondTempRequest");
        }
        public ActionResult SecondTempRequest()
        {
            //List<string> stnlist;
            //stnlist = TempData["stores"] as List<string>;
            //return View(stnlist);
            return RedirectToAction("Index"); //making aa third request to the index view
        }
        public ActionResult Colors()
        {
            List<string> colors = new List<string>()
            {
                "Red","Green","Blue","Pink","Black"
            };
            ViewBag.ColorList = colors;
            return View();
        }
        public ActionResult Mobiles()
        {
            List<string> mobiles = new List<string>()
            {
                "Samsung", "iPhone", "Vivo", "Pixel", "OnePlus"
            };
            ViewData["MobileList"] = mobiles;
            return View();  
        }
    }
}