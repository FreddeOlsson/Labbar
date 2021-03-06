﻿using GissaTaletMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GissaTaletMVC.Controllers
{
    public class MainController : Controller
    {

        // GET: SectretNumber
        public ActionResult Index()
        {
            var number = GetNumber();
            return View(number);
        }

        //GET:
        public ActionResult NewPage()
        {
            GetNumber().Initialize();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(int? number)
        {
            if (Session.IsNewSession)
            {
                return View("Session");
            }
            var secretNumber = GetNumber();

            if (!number.HasValue)
            {
                ModelState.AddModelError("number", "Fel, ange ett tal!");
            }

            else if (number < 1 || number > 100)
            {
                ModelState.AddModelError("number", "Gissningen misslyckades, försök igen.");
                ModelState.AddModelError("number", "Talet måste vara mellan 1 och 100");
            }

            else
            {
                secretNumber.MakeGuess(number.Value);
            }
            return View(secretNumber);
        }

        private SecretNumber GetNumber()
        {
            var number = (SecretNumber)Session["Number"];
            if (number == null)
            {
                number = new SecretNumber();
                Session["Number"] = number;
            }
            return number;
        }
    }
}