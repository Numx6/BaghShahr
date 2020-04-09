using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
	public class ProductGallery
	{
		[Key]
		public int GalleryID { get; set; }
		[Display(Name = "محصول")]
		public int ProductID { get; set; }
		[Display(Name = "نام تصویر")]
		[MaxLength(1500)]
		public string ImageName { get; set; }
		[Display(Name = "عنوان تصویر")]
		[MaxLength(350)]
		public string ImageTitle { get; set; }
		[Display(Name = "تاریخ ثبت")]
		public DateTime CreatDate { get; set; }

		public virtual Product Product { get; set; }
		public ProductGallery()
		{

		}

	}
}
