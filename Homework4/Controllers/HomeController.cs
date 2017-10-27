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
            string answerText = "Please enter a valid request.";
            string text = Request.QueryString["temp1"];
            string to = Request.QueryString["to"];
            ViewBag.RequestMethod = "GET";

            double answer;
            if(to == "f" || to == "F")
            {
                answer = (double.Parse(text) * 1.8) + 32;
                answerText = "" + answer;
            }
            else if (to == "c" || to == "C")
            {
                answer = (double.Parse(text) - 32) / 1.8;
                answerText = "" + answer;
            }
            else
            {
            }
            ViewBag.Message = answerText;
            return View();
        }
    }
}