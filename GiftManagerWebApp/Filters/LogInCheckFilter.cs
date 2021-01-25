using GiftManagerWebApp.OtherClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GiftManagerWebApp.Filters
{
    public class LogInCheckFilter:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(UserSession.GetUserSession() == null)
            {
                RouteValueDictionary routeToGo = new RouteValueDictionary() 
                { { "action","login"},{"controller","user"} };

                filterContext.Result = new RedirectToRouteResult(routeToGo);
            }
        }
    }
}