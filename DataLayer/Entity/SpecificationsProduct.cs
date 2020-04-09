using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
	public class SpecificationsProduct
	{
		[Key]
		public int SpecificationsID { get; set; }
		[Display(Name = "محصول")]
		public int ProductID { get; set; }
		[Display(Name = "عنوان")]
		[MaxLength(250)]
		public string Title { get; set; }

		public virtual Product product { get; set; }
		public SpecificationsProduct()
		{

		}
	}
}
