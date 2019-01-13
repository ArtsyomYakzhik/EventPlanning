using EventPlanning.Models.DB.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventPlanning.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(User user)
        {

            return View();
        }

        
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Registration(User user)
        {
            return SignUp();
        }

        public ActionResult UserHome()
        {
            ViewBag.UserId = Session["UserId"];
            return View();
        }
    }
}