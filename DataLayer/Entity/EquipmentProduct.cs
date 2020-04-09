using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
	public class EquipmentProduct
	{
		[Key]
		public int EquipmentID { get; set; }
		[Display(Name = "محصول")]
		public int ProductID { get; set; }
		[Display(Name = "عنوان تجهیزات")]
		[MaxLength(250)]
		public string EquipmentTitle { get; set; }
		[Display(Name = "تاریخ ثبت")]
		public DateTime CreatDate { get; set; }

		public virtual Product Product { get; set; }
		public EquipmentProduct()
		{

		}
	}
}
