using GiftManagerWebApp.Models;
using GiftManagerWebApp.OtherClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GiftManagerWebApp.Filters
{
    public class AdminCheckFilter:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            User currentUser = UserSession.GetUserSession();

            if(currentUser != null)
            {
                if(currentUser.Role != "admin")
                {
                    RouteValueDictionary routeToGo =
                        new RouteValueDictionary()
                        { { "action","add"},{"controller","gift" } };

                    filterContext.Result = new RedirectToRouteResult(routeToGo);
                }
            }

        }
    }
}