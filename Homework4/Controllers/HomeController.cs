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

        // Gets the answer for calculation.
        [HttpGet]
        public ActionResult Page1()
        {
            string answerText = "Please enter a valid request.";
            string text = Request.QueryString["temp1"];
            string to = Request.QueryString["to"];
            ViewBag.RequestMethod = "GET";

            double answer;

            // To f.
            if(to == "f" || to == "F")
            {
                answer = (double.Parse(text) * 1.8) + 32;
                answerText = "" + answer;
            }
            // To c.
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

        // Get for page2.
        [HttpGet]
        public ActionResult Page2()
        {
            ViewBag.RequestMethod = "GET";
            return View();
        }

        // Post for page2.
        [HttpPost]
        public ActionResult Page2(FormCollection form)
        {
            ViewBag.RequestMethod = "POST";   
            string value = Request.Form["amount"];
            string from = Request.Form["from"];
            string to = Request.Form["to"];

            double valueT = double.Parse(value);
 
            //First converts to US dollars, no matter what.
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


            //Then converts to the desired currency.
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

        //The calculation for loan stuff.
        [HttpPost]
        public ActionResult Page3(double amount, double iRate, double tLength)
        {
            double n = tLength * 12;
            double i = iRate / 12;
            double d = (((Math.Pow((1 + i), n)) - 1) / (i * Math.Pow((1 + i), n)));
            double p = amount / d;

            ViewBag.Month = p + "";
            ViewBag.Total = p * n + "";

            return View();
        }
    }
}