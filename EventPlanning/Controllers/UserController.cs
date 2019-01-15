using EventPlanning.Models.DB.Tables;
using EventPlanning.Models.ElementControl;
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
            if(Models.ElementControl.UserControl.userAuthenticication(this, user))
            {
                return RedirectToActionPermanent("UserHome");
            }
            return RedirectToActionPermanent("SignIn");
        }

        
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(User user)
        {
            return View(Models.ElementControl.UserControl.userRegistration(this, user));
        }

        public ActionResult UserHome()
        {
            ViewBag.UserId = Session["UserId"].ToString();
            ViewBag.UserEvents = EventControl.GetUserEvents(Session["UserId"].ToString());
            return View();
        }

        public ActionResult ConfirmEmail(string token, string email)
        {
            Models.ElementControl.UserControl.confirmEmail(token, email);
            return View("SignIn");
        }
    }
}