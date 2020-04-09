using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
	public class EquipmentRepo : IEquipment
	{
		BagShahrContext db;
		public EquipmentRepo(BagShahrContext db)
		{
			this.db = db;
		}
		public bool AddEquipment(EquipmentProduct equipment)
		{
			try
			{
				db.equipment.Add(equipment);
				return true;

			}
			catch (Exception)
			{

				return false;
			}
		}

		public bool DeleteEquipment(EquipmentProduct equipment)
		{
			try
			{
				db.Entry(equipment).State = EntityState.Deleted;
				return true;

			}
			catch (Exception)
			{

				return false;
			}
		}

		public bool DeleteEquipment(int id)
		{
			try
			{
				var equipment = GetEquipmentById(id);
				DeleteEquipment(equipment);
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

		public IEnumerable<EquipmentProduct> GetAllEquipment()
		{
			return db.equipment;
		}

		public EquipmentProduct GetEquipmentById(int id)
		{
			return db.equipment.Find(id); 
		}

		public void Save()
		{
			db.SaveChanges();
		}

		public bool UpdateEquipment(EquipmentProduct equipment)
		{
			try
			{
				db.Entry(equipment).State = EntityState.Modified;
				return true;

			}
			catch (Exception)
			{

				return false;
			}
		}
	}
}
