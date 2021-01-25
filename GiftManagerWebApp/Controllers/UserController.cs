using GiftManagerWebApp.BLL;
using GiftManagerWebApp.Filters;
using GiftManagerWebApp.Models;
using GiftManagerWebApp.OtherClass;
using System.Diagnostics;
using System.Web.Mvc;

namespace GiftManagerWebApp.Controllers
{
    public class UserController : Controller
    {
      
        // GET: User
        public ActionResult LogIn()
        {
            return View();
        }


        [HttpPost]

        public ActionResult LogIn(string email,string password)
        {
            UserManager userManager = new UserManager();

            User userTologIn = userManager.LogInCheck(email, password);

            if (ModelState.IsValid && userTologIn != null)
            {
                ModelState.Clear();

                UserSession.SetUserSession(userTologIn);

                // Debug.WriteLine("User name : "+UserSession.GetUserSession().Name);

                //ViewBag.User = userTologIn;

                return RedirectToAction("add", "gift");
            }

            ViewBag.msg = new Massage() 
            { Body = "wrong password or email or both",Type=Massage.failed };

            return View();
        }

        [LogInCheckFilter]
        [AdminCheckFilter]

        public ActionResult AddUser()
        {
            User user = new User();

            return View(user);
        }

        [HttpPost]
        [LogInCheckFilter]
        [AdminCheckFilter]
        public ActionResult AddUser(User user)
        {
            
            if (ModelState.IsValid)
            {
                ModelState.Clear();

                UserManager userManager = new UserManager();
                userManager.AddNewUser(user);
            }

            return View(new User());
        }

        public ActionResult LogOut()
        {
            UserManager userManager = new UserManager();

            UserSession.ClearUserSession();
            EventSession.ClearEventSession();

            return RedirectToAction("LogIn");
        }
        [LogInCheckFilter]
        public ActionResult Profile_info()
        {
            return View(UserSession.GetUserSession());
        }


        public ActionResult ChangePass()
        {
            return View();
        }

        [HttpPost]
        [LogInCheckFilter]
        public ActionResult ChangePass(string newPassword,string oldPassword)
        {
            UserManager userManager = new UserManager();

            bool changeStatus = userManager.ChangePassword
                (UserSession.GetUserSession().Email, newPassword, oldPassword);

            if(changeStatus)
            {
                ViewBag.msg = "Password Changed";
            }
            else
            {
                ViewBag.msg = "Failed to change password";
            }

            return View();
        }
    }
}