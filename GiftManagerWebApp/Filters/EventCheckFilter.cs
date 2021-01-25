using GiftManagerWebApp.OtherClass;
using System.Web.Mvc;
using System.Web.Routing;

namespace GiftManagerWebApp.Filters
{
    public class EventCheckFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (EventSession.GetEventSession() == null)
            {
                RouteValueDictionary routeValue = new RouteValueDictionary()
                { { "action", "SetEventModel" },{"controller","event" } };

                filterContext.Result = new RedirectToRouteResult(routeValue);
            }
        }
    }
}