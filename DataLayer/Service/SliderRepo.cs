using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
	public class SliderRepo : ISlider
	{
		BagShahrContext db;
		public SliderRepo(BagShahrContext db)
		{
			this.db = db;
		}
		public bool AddSlider(HomeSlider slider)
		{
			try
			{
				db.HomeSliders.Add(slider);
				return true;
			}
			catch (Exception)
			{

				return false;
			}
		}

		public bool DeleteSlider(HomeSlider slider)
		{
			try
			{
				db.Entry(slider).State = EntityState.Deleted;
				return true;
			}
			catch (Exception)
			{

				return false;
			}
		}

		public bool DeleteSlider(int id)
		{
			try
			{
				var slider = GetSliderById(id);
				DeleteSlider(slider);
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

		public IEnumerable<HomeSlider> GetAllSlider()
		{
			return db.HomeSliders.ToList();
		}

		public HomeSlider GetSliderById(int id)
		{
			return db.HomeSliders.Find(id);
		}

		public void Save()
		{
			db.SaveChanges();
		}

		public bool UpdateSlider(HomeSlider slider)
		{
			try
			{
				db.Entry(slider).State = EntityState.Modified;
				return true;
			}
			catch (Exception)
			{

				return false;
			}
		}
	}
}
