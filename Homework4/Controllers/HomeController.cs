using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework4.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult Page1()
        //{
        //    return View();
        //}

        public ActionResult Page2()
        {
            return View();
        }

        public ActionResult Page3()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Page1()
        {
            string text = Request.QueryString["temp1"];
            ViewBag.RequestMethod = "GET";
            ViewBag.Message = text;
            return View();
        }
    }
}