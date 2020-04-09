using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
	public class SpecifitaionRepo : ISpecification
	{
		BagShahrContext db;
		public SpecifitaionRepo(BagShahrContext db)
		{
			this.db = db;
		}
		public bool AddSpecification(SpecificationsProduct specifications)
		{
			try
			{
				db.specifications.Add(specifications);
				return true;

			}
			catch (Exception)
			{

				return false;
			}
		}

		public bool DeleteGroupsSpec(int ProductId)
		{
			try
			{
				List<SpecificationsProduct> list = db.specifications.Where(t => t.ProductID == ProductId).ToList();
				foreach (var item in list)
				{
					DeleteSpecification(item);
				}
				return true;

			}
			catch (Exception)
			{

				return false;
			}
		}

		public bool DeleteSpecification(SpecificationsProduct specifications)
		{
			try
			{
				db.Entry(specifications).State = EntityState.Deleted;
				return true;

			}
			catch (Exception)
			{

				return false;
			}
		}

		public bool DeleteSpecification(int id)
		{
			try
			{
				var specification = GetSpecificationsById(id);
				DeleteSpecification(specification);
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

		public IEnumerable<SpecificationsProduct> GetAllSpecifications()
		{
			return db.specifications;
		}


		public SpecificationsProduct GetSpecificationsById(int id)
		{
			return db.specifications.Find(id);
		}

		public void Save()
		{
			db.SaveChanges();
		}

		public bool UpdateSpecification(SpecificationsProduct specifications)
		{
			try
			{
				db.Entry(specifications).State = EntityState.Modified;
				return true;

			}
			catch (Exception)
			{

				return false;
			}
		}
	}
}
