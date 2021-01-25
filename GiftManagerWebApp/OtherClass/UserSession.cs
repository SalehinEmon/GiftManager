using GiftManagerWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GiftManagerWebApp.OtherClass
{
    public static class UserSession
    {

        public static void SetUserSession(User user)
        {
            if(GetUserSession() == null)
            {
                HttpContext.Current.Session["user"] = user;
            }

        }


        public static User GetUserSession()
        {
            User user = HttpContext.Current.Session["user"] as User;

            return user;

        }


        public static void ClearUserSession()
        {
            if(GetUserSession() != null)
            {
                HttpContext.Current.Session["user"] = null;

            }
        }
    }
}