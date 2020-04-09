using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
	public class ProductRepo : IProduct
	{
		BagShahrContext db;
		public ProductRepo(BagShahrContext db)
		{
			this.db = db;
		}

		public bool AddProduct(Product product)
		{
			try
			{
				db.products.Add(product);
				return true;

			}
			catch (Exception)
			{

				return false;
			}
		}

		public bool DeleteProduct(Product product)
		{
			try
			{
				db.Entry(product).State = EntityState.Deleted;
				return true;
			}
			catch (Exception)
			{

				return false;
			}
		}

		public bool DeleteProduct(int ProductId)
		{
			try
			{
				var product = GetProductById(ProductId);
				DeleteProduct(product);
				return true;
			}
			catch (Exception)
			{

				return false;
			}


		}

		public void Dispose()
		{
			db.Dispose();
		}

		public IEnumerable<Product> Favorit(int take = 4)
		{
			return db.products.OrderByDescending(o => o.Visite).Take(take);
		}

		public IEnumerable<Product> GetAllProduct()
		{
			return db.products;
		}

		public Product GetProductById(int ProductId)
		{
			return db.products.Find(ProductId);
		}

		public IEnumerable<Product> GetSpecialProduct()
		{
			return db.products.Where(s => s.Special == true).ToList();
		}

		public IEnumerable<Product> NewProduct(int take = 8)
		{
			return db.products.OrderByDescending(c => c.CreatDate).Take(take).ToList();
		}

		public void Save()
		{
			db.SaveChanges();
		}

		public IEnumerable<Product> SearchProduct(string q)
		{
			return db.products.Where(p => p.Title.Contains(q) || p.ShortDiscription.Contains(q) || p.Code.Contains(q)).ToList();
		}

		public bool UpdateProduct(Product product)
		{
			try
			{
				db.Entry(product).State = EntityState.Modified;
				return true;
			}
			catch (Exception)
			{

				return false;
			}
		}
	}
}
