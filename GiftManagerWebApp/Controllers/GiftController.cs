using GiftManagerWebApp.BLL;
using GiftManagerWebApp.Filters;
using GiftManagerWebApp.Models;
using GiftManagerWebApp.OtherClass;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace GiftManagerWebApp.Controllers
{
    [LogInCheckFilter]
    public class GiftController : Controller
    {
        // GET: Gift

        
        [EventCheckFilter]
        public ActionResult Add()
        {
            ModelState.Clear();

            Gift gift = new Gift();

            return View(gift);
        }

        [HttpPost]
        [EventCheckFilter]
        public ActionResult Add(Gift gift)
        {
            ModelState.Clear();

            if ((EventSession.GetEventSession() != null) &&
                (UserSession.GetUserSession() != null))
            {
                ModelState.Clear();

                gift.EventId = EventSession.GetEventSession().Id;
                gift.AddedBy = UserSession.GetUserSession().Id;
                gift.Date = DateTime.Today;
                gift.Time = DateTime.Now;

                GiftManager giftManager = new GiftManager();

                int giftStatus = giftManager.AddGift(gift);

                if(giftStatus > 0)
                {

                    return RedirectToAction("status","gift",
                        new { giftno=gift.LocalSerialId,status=Massage.success});

                }
            }

            return RedirectToAction("status", "gift",
                        new { giftno = gift.LocalSerialId, status = Massage.failed });
        }


        public ActionResult AllGifts()
        {
            EventManager eventManager = new EventManager();

            List<SelectListItem> allEventsForDropdown = eventManager.GetAllEventModelForDropdown();



            return View(allEventsForDropdown);
        }

        [HttpPost]

        public ActionResult AllGifts(int eventId)
        {
            EventManager eventManager = new EventManager();

            List<SelectListItem> allEventsForDropdown = eventManager.GetAllEventModelForDropdown();

            GiftManager giftManager = new GiftManager();

            ViewBag.allGiftsList = giftManager.GetAllFiftByEventId(eventId);

            return View(allEventsForDropdown);

        }

        
        [EventCheckFilter]

        public ActionResult Current()
        {
            int eventId = EventSession.GetEventSession().Id;

            GiftManager giftManager = new GiftManager();

            ViewBag.totalAmount = giftManager
                .GetTotalAmountByEvventId(eventId);

            ViewBag.totalGifts = giftManager.GetTotalGiftByEvventId(eventId);

            return View();
        }


        public ActionResult Status(int? giftno, string status)
        {
            if(status == Massage.success)
            {
                ViewBag.msg = $"Gift received successfully!!";
                ViewBag.giftNo = giftno;
                ViewBag.Status = "panel panel-success";

            }
            else
            {
                ViewBag.msg = $"Failed to receive gift!!";
                ViewBag.Status = "panel panel-danger";

            }
            return View();
        }

    }
}