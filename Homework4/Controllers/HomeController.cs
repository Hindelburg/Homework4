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

        [HttpGet]
        public ActionResult Page2()
        {
            ViewBag.RequestMethod = "GET";
            return View();
        }

        [HttpPost]
        public ActionResult Page2(FormCollection form)
        {
            ViewBag.RequestMethod = "POST";   
            string value = Request.Form["amount"];
            string from = Request.Form["from"];
            string to = Request.Form["to"];

            double valueT = double.Parse(value);
 
            if(from == "Dollar")
            {
                valueT = valueT; //Unneeded but done for my wellbeing.
            }
            else if (from == "Pound")
            {
                valueT = valueT * 1.31;
            }
            else if (from == "Yuan")
            {
                valueT = valueT / 6.65;
            }
            else
            {
                value = "Please enter valid input.";
                ViewBag.Message = value;
                return View();
            }

            if (to == "Dollar")
            {
                valueT = valueT; //Unneeded but done for my wellbeing.
            }
            else if (to == "Pound")
            {
                valueT = valueT / 1.31;
            }
            else if (to == "Yuan")
            {
                valueT = valueT * 6.65;
            }
            else
            {
                value = "Please enter valid input.";
                ViewBag.Message = value;
                return View();
            }

            value = "" + valueT;
            ViewBag.Message = value;
            return View();
        }

        public ActionResult Page3()
        {
            return View();
        }
    }
}