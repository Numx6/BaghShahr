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
using InsertShowImage;
using KooyWebApp_MVC.Classes;

namespace BagShahr.Areas.Admin.Controllers
{
	[Authorize]
	public class ProductsController : Controller
	{
		BagShahrContext db;
		ProductRepo productRepo;
		GalleryRepo galleryRepo;
		SpecifitaionRepo specifitaionRepo;
		EquipmentRepo equipmentRepo;
		public ProductsController()
		{
			db = new BagShahrContext();
			productRepo = new ProductRepo(db);
			galleryRepo = new GalleryRepo(db);
			specifitaionRepo = new SpecifitaionRepo(db);
			equipmentRepo = new EquipmentRepo(db);
		}

		public ActionResult Index()
		{
			return View(productRepo.GetAllProduct());
		}

		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		//[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "ProductID,Code,IsActive,Title,ShortDiscription,Discription,Address,Price,Slider,Special,ImageName,CreatDate")] Product product, HttpPostedFileBase ImgUp, string Specification, string Equipment)
		{
			if (ModelState.IsValid)
			{
				product.ImageName = "images.jpg";
				product.CreatDate = DateTime.Now;
				product.Visite = 0;
				if (ImgUp != null && ImgUp.IsImage())
				{
					product.ImageName = Guid.NewGuid().ToString() + Path.GetExtension(ImgUp.FileName);
					ImgUp.SaveAs(Server.MapPath("/Image/" + product.ImageName));
					ImageResizer img = new ImageResizer();
					img.Resize(Server.MapPath("/image/" + product.ImageName),
						Server.MapPath("/image/thumb/" + product.ImageName
						));
				}
				productRepo.AddProduct(product);
				if (!string.IsNullOrEmpty(Specification))
				{
					string[] tag = Specification.Split('-');
					foreach (string s in tag)
					{
						specifitaionRepo.AddSpecification(new SpecificationsProduct()
						{
							ProductID = product.ProductID,
							Title = s.Trim()
						});
					}
				}
				if (!string.IsNullOrEmpty(Equipment))
				{
					string[] tag = Equipment.Split('-');
					foreach (string e in tag)
					{
						equipmentRepo.AddEquipment(new EquipmentProduct()
						{
							ProductID = product.ProductID,
							EquipmentTitle = e.Trim(),
							CreatDate = DateTime.Now
						});
					}
				}
				productRepo.Save();
				return RedirectToAction("Index");
			}

			return View(product);
		}

		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Product product = productRepo.GetProductById(id.Value);
			if (product == null)
			{
				return HttpNotFound();
			}
			return View(product);
		}

		[HttpPost, ActionName("Delete")]
		//[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			Product product = productRepo.GetProductById(id);

			if (product.ImageName != "images.jpg")
			{
				System.IO.File.Delete(Server.MapPath("/Image/" + product.ImageName));
				System.IO.File.Delete(Server.MapPath("/Image/thumb/" + product.ImageName));
			}
			specifitaionRepo.DeleteGroupsSpec(product.ProductID);
			productRepo.DeleteProduct(product);
			productRepo.Save();
			return RedirectToAction("Index");
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				productRepo.Dispose();
			}
			base.Dispose(disposing);
		}

		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Product product = productRepo.GetProductById(id.Value);
			if (product == null)
			{
				return HttpNotFound();
			}
			ViewBag.Specification = string.Join("-", product.specifications.Select(s => s.Title));
			ViewBag.Equipment = string.Join("-", product.EquipmentProducts.Select(s => s.EquipmentTitle));
			return View(product);
		}


		[HttpPost]
		//[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "ProductID,Code,IsActive,Title,ShortDiscription,Discription,Address,Price,Slider,Special,ImageName,CreatDate")] Product product, HttpPostedFileBase ImgUp, string Specification,string Equipment)
		{
			if (ModelState.IsValid)
			{
				if (ImgUp != null)
				{
					if (product.ImageName != "images.jpg")
					{
						System.IO.File.Delete(Server.MapPath("/Image/" + product.ImageName));
						System.IO.File.Delete(Server.MapPath("/Image/Thumb/" + product.ImageName));

					}
					product.ImageName = Guid.NewGuid().ToString() + Path.GetExtension(ImgUp.FileName);
					ImgUp.SaveAs(Server.MapPath("/Image/" + product.ImageName));
					ImageResizer img = new ImageResizer();
					img.Resize(Server.MapPath("/image/" + product.ImageName),
						Server.MapPath("/image/thumb/" + product.ImageName
						));
				}
				productRepo.UpdateProduct(product);

				specifitaionRepo.DeleteGroupsSpec(product.ProductID);
				if (!string.IsNullOrEmpty(Specification))
				{
					string[] tag = Specification.Split('-');
					foreach (string s in tag)
					{
						specifitaionRepo.AddSpecification(new SpecificationsProduct()
						{
							ProductID = product.ProductID,
							Title = s.Trim()
						});
					}
				}
				equipmentRepo.DeleteEquipment(product.ProductID);
				if (!string.IsNullOrEmpty(Equipment))
				{
					string[] tag = Equipment.Split('-');
					foreach (string e in tag)
					{
						equipmentRepo.AddEquipment(new EquipmentProduct()
						{
							ProductID = product.ProductID,
							EquipmentTitle = e.Trim(),
							CreatDate = DateTime.Now
						});
					}
				}

				productRepo.Save();
				return RedirectToAction("Index");
			}
			return View(product);
		}

		public ActionResult AddGallery(int id)
		{
			var product = productRepo.GetProductById(id);
			ViewBag.Gallery = product.ProductGalleries.ToList();
			return View(new ProductGallery()
			{
				ProductID = id
			});
		}
		[HttpPost]
		//[ValidateAntiForgeryToken]
		public ActionResult AddGallery(ProductGallery gallery, HttpPostedFileBase GallerImg)
		{

			if (ModelState.IsValid)
			{
				if (GallerImg != null)
				{
					gallery.ImageName = Guid.NewGuid().ToString() + Path.GetExtension(GallerImg.FileName);
					GallerImg.SaveAs(Server.MapPath("/image/" + gallery.ImageName));
					ImageResizer img = new ImageResizer();
					img.Resize(Server.MapPath("/image/" + gallery.ImageName),
						Server.MapPath("/image/thumb/" + gallery.ImageName
						));
					gallery.CreatDate = DateTime.Now;
					galleryRepo.AddGallery(gallery);
					galleryRepo.Save();
					AddGallery(gallery.ProductID);
				}
			}
			return RedirectToAction("AddGallery", new { id = gallery.ProductID });
		}
		public ActionResult DeleteGallery(int id)
		{
			var itemGallery = galleryRepo.GetGalleryById(id);
			System.IO.File.Delete(Server.MapPath("/Image/" + itemGallery.ImageName));
			System.IO.File.Delete(Server.MapPath("/Image/Thumb/" + itemGallery.ImageName));

			galleryRepo.DeleteGallery(itemGallery);
			galleryRepo.Save();
			return RedirectToAction("AddGallery", new { id = itemGallery.ProductID });
		}

	}
}
