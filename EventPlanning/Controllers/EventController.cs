using EventPlanning.Models.DB.Tables;
using EventPlanning.Models.ElementControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventPlanning.Controllers
{
    public class EventController : Controller
    {
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Event eventItem, string[] fieldName, string[] fieldText)
        {
            eventItem.CreatorId = Session["UserId"].ToString();
            EventControl.CreateNewEvent(eventItem, fieldName, fieldText);
            return RedirectToActionPermanent("UserHome", "User");
        }

        [HttpGet]
        public ActionResult SignToEvent()
        {
            ViewBag.EventList = EventControl.GetEventsWithFreeSpace();
            return View();
        }

        [HttpPost]
        public ActionResult SignToEvent(string eventId)
        {

            return RedirectToActionPermanent("UserHome", User);
        }
    }
}