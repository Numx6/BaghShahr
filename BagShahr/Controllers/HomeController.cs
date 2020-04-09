using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace BagShahr.Controllers
{
	public class HomeController : Controller
	{
		BagShahrContext db;
		ProductRepo productRepo;
		ArticleRepo articleRepo;
		SliderRepo sliderRepo;
		public HomeController()
		{
			db = new BagShahrContext();
			productRepo = new ProductRepo(db);
			articleRepo = new ArticleRepo(db);
			sliderRepo = new SliderRepo(db);
		}
		public ActionResult Index()
		{
			return View();
		}
		public ActionResult About()
		{
			return View();
		}
		public ActionResult Contact()
		{
			return View();
		}
		public ActionResult Slider()
		{
			return PartialView();
		}
		public ActionResult Nav()
		{
			return PartialView();
		}
		public ActionResult ImgHead()
		{
			return PartialView();
		}
		public ActionResult Special()
		{
			return PartialView(productRepo.GetSpecialProduct());
		}
		public ActionResult Article()
		{
			var article = articleRepo.LastArticle();
			return PartialView(article);
		}
		public ActionResult FavoritProduct()
		{
			return PartialView(productRepo.Favorit());
		}
		[Route("new")]
		public ActionResult NewProduct()
		{
			return PartialView(productRepo.NewProduct());
		}
		[Route("SingleProduct/{id}")]
		public ActionResult SinglProduct(int id)
		{
			Product product = productRepo.GetProductById(id);
			product.Visite += 1;
			productRepo.Save();
			return View(product);
		}
		public ActionResult Arshive(int id=1)
		{
			List<Product> list = new List<Product>();

			list.AddRange(productRepo.GetAllProduct());

			int take = 9;
			int skip = (id - 1) * take;
			ViewBag.PageCount = list.Count() / take;
			return View(list.OrderByDescending(p => p.CreatDate).Skip(skip).Take(take).ToList());
		}
		public ActionResult Search(string q)
		{
			ViewBag.count = productRepo.SearchProduct(q).ToList().Count();
			return View(productRepo.SearchProduct(q).ToList());
		}

	}
}