using GiftManagerWebApp.BLL;
using GiftManagerWebApp.Filters;
using GiftManagerWebApp.Models;
using GiftManagerWebApp.OtherClass;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GiftManagerWebApp.Controllers
{
    public class EventController : Controller
    {
        // GET: Event
        [LogInCheckFilter]
        public ActionResult Add()
        {
            EventModel eventModel = new EventModel();
            return View(eventModel);
        }

        [HttpPost]
        [LogInCheckFilter]

        public ActionResult Add(EventModel eventModel)
        {

            EventManager eventManager = new EventManager();
            eventManager.AddEvent(eventModel);

            ModelState.Clear();

            return View(new EventModel());

        }

        [LogInCheckFilter]
        public ActionResult SetEventModel()
        {
            EventModel eventModel = new EventModel();
            EventManager eventManager = new EventManager();

            ViewBag.allEvents = eventManager.GetAllEventModelForDropdown();


            return View(eventModel);
        }

        [HttpPost]
        [LogInCheckFilter]
        public ActionResult SetEventModel(int id)
        {
            ModelState.Clear();

            EventModel eventModel = new EventModel();
            EventManager eventManager = new EventManager();

            ViewBag.allEvents = eventManager.GetAllEventModelForDropdown();

            EventModel eventModeToSet = eventManager.GetEventById(id);

            if(eventModel != null)
            {
                EventSession.SetEventSession(eventModeToSet);

                //Debug.Print(EventSession.GetEventSession().EventName);

                return RedirectToAction("add", "gift");
            }

            return View(eventModel);
        }
    }
}