using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
	public class GalleryRepo : IGallery
	{
		BagShahrContext db;
		public GalleryRepo(BagShahrContext db)
		{
			this.db = db;
		}
		public bool AddGallery(ProductGallery gallery)
		{
			try
			{
				db.productGalleries.Add(gallery);
				return true;

			}
			catch (Exception)
			{

				return false;
			}
		}

		public bool DeleteGallery(ProductGallery gallery)
		{
			try
			{
				db.Entry(gallery).State = EntityState.Deleted;
				return true;

			}
			catch (Exception)
			{

				return false;
			}
		}

		public bool DeleteGallery(int id)
		{
			try
			{
				var gallery = GetGalleryById(id);
				DeleteGallery(gallery);
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

		public IEnumerable<ProductGallery> GetAllGalleries()
		{
			return db.productGalleries;
		}

		public ProductGallery GetGalleryById(int id)
		{
			return db.productGalleries.Find(id);
		}

		public void Save()
		{
			db.SaveChanges();
		}

		public bool UpdateGallery(ProductGallery gallery)
		{
			try
			{
				db.Entry(gallery).State = EntityState.Modified;
				return true;

			}
			catch (Exception)
			{

				return false;
			}
		}
	}
}
