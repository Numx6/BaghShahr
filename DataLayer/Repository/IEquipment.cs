using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
	public interface IEquipment:IDisposable
	{
		IEnumerable<EquipmentProduct> GetAllEquipment();
		EquipmentProduct GetEquipmentById(int id);
		bool AddEquipment(EquipmentProduct equipment);
		bool UpdateEquipment(EquipmentProduct equipment);
		bool DeleteEquipment(EquipmentProduct equipment);
		bool DeleteEquipment(int id);
		void Save();
	}
}
