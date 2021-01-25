using GiftManagerWebApp.BLL;
using GiftManagerWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GiftManagerWebApp.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult Index(int? id)
        {
            GiftManager giftManager = new GiftManager();
            EventManager eventManager = new EventManager();

            EventModel eventModel = eventManager.GetEventById(id.GetValueOrDefault());

            List<Gift> allGfits = null;

            if (id != null && eventModel != null)
            {
                allGfits = giftManager.GetAllFiftByEventId(Convert.ToInt32(id));
                ViewBag.totalMoney = giftManager.GetTotalAmountByEvventId(id.GetValueOrDefault());
                ViewBag.totalGifts = giftManager.GetTotalGiftByEvventId(id.GetValueOrDefault());
                ViewBag.eventName = eventManager.GetEventById(id.GetValueOrDefault()).EventName;
            }

            return View(allGfits);
        }

    }
}