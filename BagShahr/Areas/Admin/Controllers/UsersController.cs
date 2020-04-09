using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using System.Web.Security;

namespace BagShahr.Areas.Admin.Controllers
{
  
    [Authorize]
    public class UsersController : Controller
    {
        BagShahrContext db;
        UserRepo userRepo;
        public UsersController()
        {
            db = new BagShahrContext();
            userRepo = new UserRepo(db);
        }
        public ActionResult Index()
        {
            return View(userRepo.GetAllUser());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,Name,UserName,Password,CreatDate")] User user)
        {
            if (ModelState.IsValid)
            {
                user.CreatDate = DateTime.Now;
                user.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(user.Password, "MD5");
                userRepo.AddUser(user);
                userRepo.Save();
                return RedirectToAction("Index");
            }

            return View(user);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = userRepo.GetUserById(id.Value);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,Name,UserName,Password,CreatDate")] User user)
        {
            if (ModelState.IsValid)
            {
                userRepo.UpdateUser(user);
                userRepo.Save();
                return RedirectToAction("Index");
            }
            return View(user);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = userRepo.GetUserById(id.Value);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            userRepo.DeleteUser(id);
            userRepo.Save();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                userRepo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
