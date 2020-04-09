using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using DataLayer;
using DataLayer.Migrations;
using InsertShowImage;
using KooyWebApp_MVC.Classes;

namespace BagShahr.Areas.Admin.Controllers
{
	[Authorize]
	public class HomeSlidersController : Controller
	{
		private BagShahrContext db;
		SliderRepo sliderRepo;
		public HomeSlidersController()
		{
			db = new BagShahrContext();
			sliderRepo = new SliderRepo(db);

		}

		public ActionResult Index()
		{
			return View(sliderRepo.GetAllSlider());
		}
		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		//[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "Id,ImgName,ImgAlt,Title,SubTitle,CreatDate")] HomeSlider homeSlider, HttpPostedFileBase ImgUp)
		{
			if (ModelState.IsValid)
			{
				homeSlider.CreatDate = DateTime.Now;
				homeSlider.ImgName = "images.jpg";
				if (ImgUp != null && ImgUp.IsImage())
				{
					homeSlider.ImgName = Guid.NewGuid().ToString() + Path.GetExtension(ImgUp.FileName);
					ImgUp.SaveAs(Server.MapPath("/Image/slider/" + homeSlider.ImgName));
					ImageResizer img = new ImageResizer();
					img.Resize(Server.MapPath("/Image/slider/" + homeSlider.ImgName),
						Server.MapPath("/Image/slider/Thumb/" + homeSlider.ImgName
						));
				}
				sliderRepo.AddSlider(homeSlider);
				sliderRepo.Save();
				return RedirectToAction("Index");
			}
			return View(homeSlider);
		}

		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			HomeSlider homeSlider = sliderRepo.GetSliderById(id.Value);
			if (homeSlider == null)
			{
				return HttpNotFound();
			}
			return View(homeSlider);
		}

		[HttpPost, ActionName("Delete")]
		//[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			var slid = sliderRepo.GetSliderById(id);
			if (slid.ImgName != "images.jpg")
			{
				System.IO.File.Delete(Server.MapPath("/Image/slider/" + slid.ImgName));
				System.IO.File.Delete(Server.MapPath("/Image/slider/Thumb/" + slid.ImgName));
			}
			sliderRepo.DeleteSlider(slid);
			sliderRepo.Save();
			return RedirectToAction("Index");
		}
	
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				sliderRepo.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
