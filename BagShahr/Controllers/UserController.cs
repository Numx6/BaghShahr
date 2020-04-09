using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using System.Web.Security;

namespace BagShahr.Controllers
{
    public class UserController : Controller
    {
        BagShahrContext db;
        UserRepo userRepo;
        public UserController()
        {
            db = new BagShahrContext();
            userRepo = new UserRepo(db);
        }
        [Route("LogIn")]
        public ActionResult LogIn()
        {
            return View();
        }
        [Route("LogIn")]
        [HttpPost]
        public ActionResult LogIn(User user, string ReturnUrl= "/Admin/Products/Index")
        {
            if (ModelState.IsValid)
            {
                user.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(user.Password,"MD5");
                if (userRepo.HasUser(user))
                {
                    FormsAuthentication.SetAuthCookie(user.Name,true);
                    return Redirect(ReturnUrl);
                }
                else
                {
                    ModelState.AddModelError("UserName","نام کاربری یا کلمه عبور اشتباه می باشد");
                }
                
            }
            return View(user);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }

    }
}