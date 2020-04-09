using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DataLayer;
using InsertShowImage;
using KooyWebApp_MVC.Classes;

namespace BagShahr.Areas.Admin.Controllers
{
    [Authorize]
    public class ArticlesController : Controller
    {
        BagShahrContext db;
        ArticleRepo article;
        public ArticlesController()
        {
            db = new BagShahrContext();
            article = new ArticleRepo(db);
        }


        public ActionResult Index()
        {
            return View(article.GetAllArticle());
        }

        public ActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,ShortDiscript,Text,ImageName,CreatDate")] Article article,HttpPostedFileBase ImgUp)
        {
            if (ModelState.IsValid)
            {
                article.ImageName = "images.jpg";
                article.CreatDate = DateTime.Now;
                if (ImgUp != null && ImgUp.IsImage())
                {
                    article.ImageName = Guid.NewGuid().ToString() + Path.GetExtension(ImgUp.FileName);
                    ImgUp.SaveAs(Server.MapPath("/Image/Article/" + article.ImageName));
                    ImageResizer img = new ImageResizer();
                    img.Resize(Server.MapPath("/Image/Article/" + article.ImageName),
                        Server.MapPath("/Image/Article/Thumb/" + article.ImageName
                        ));
                }
                db.Articles.Add(article);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(article);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article arti = article.GetArticleById(id.Value);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(arti);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,ShortDiscript,Text,ImageName,CreatDate")] Article articlee,HttpPostedFileBase ImgUp)
        {
            if (ModelState.IsValid)
            {
                if (ImgUp != null)
                {
                    if (articlee.ImageName != "images.jpg")
                    {
                        System.IO.File.Delete(Server.MapPath("/Image/Article/" + articlee.ImageName));
                        System.IO.File.Delete(Server.MapPath("/Image/Article/Thumb/" + articlee.ImageName));
                    }
                    articlee.ImageName = Guid.NewGuid().ToString() + Path.GetExtension(ImgUp.FileName);
                    ImgUp.SaveAs(Server.MapPath("/Image/Article/" + articlee.ImageName));
                    ImageResizer img = new ImageResizer();
                    img.Resize(Server.MapPath("/image/Article/" + articlee.ImageName),
                        Server.MapPath("/image/Article/thumb/" + articlee.ImageName
                        ));
                }
                article.UpdateArticle(articlee);
                article.Save();
                return RedirectToAction("Index");
            }
            return View(article);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var arti = article.GetArticleById(id.Value);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(arti);
        }


        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            Article arti = article.GetArticleById(id);
            if (arti.ImageName != "images.jpg")
            {
                System.IO.File.Delete(Server.MapPath("/Image/Article/" + arti.ImageName));
                System.IO.File.Delete(Server.MapPath("/Image/Article/Thumb/" + arti.ImageName));
            }
            article.DeleteArticle(arti);
            article.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                article.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
