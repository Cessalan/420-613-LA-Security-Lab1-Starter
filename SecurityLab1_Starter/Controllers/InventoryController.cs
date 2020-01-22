using SecurityLab1_Starter.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecurityLab1_Starter.Controllers
{
    public class InventoryController : Controller
    {
        // GET: Inventory
        public ActionResult Index()
        {
            return View();
        }
        protected override void OnException(ExceptionContext filterContext)
        {


            filterContext.ExceptionHandled = true;

            string filepath = @"C:\Users\Haroon\source\repos\420-613-LA-Security-Lab1-Starter\SecurityLab1_Starter\log.txt";
            using (StreamWriter w = System.IO.File.AppendText(filepath))
            {

                Logger.Log(filterContext.Exception.ToString(), w);
            }
            filterContext.Result = RedirectToAction("Index", "Error");

        }

    }
}