using GiftManagerWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GiftManagerWebApp.OtherClass
{
    public static class EventSession
    {

        public static void SetEventSession(EventModel eventModel)
        {
            HttpContext.Current.Session["event"] = eventModel;
        }

        public static EventModel GetEventSession()
        {
            if(HttpContext.Current.Session["event"] != null)
            {
                return HttpContext.Current.Session["event"] as EventModel;
            }

            return null;

        }

        public static void ClearEventSession()
        {
            if(GetEventSession() != null)
            {
                HttpContext.Current.Session["event"] = null;
            }
        }

        


         
    }
}