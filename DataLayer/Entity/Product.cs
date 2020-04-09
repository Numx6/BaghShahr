using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DataLayer
{
	public class Product
	{
		#region property
		[Key]
		public int ProductID { get; set; }


		[Display(Name = "کد ملک")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public string Code { get; set; }

		[Display(Name = "فعال")]
		public bool IsActive { get; set; }


		[Display(Name = "عنوان")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(250)]
		public string Title { get; set; }


		[Display(Name = "توضیح کوتاه")]
		[MaxLength(350)]
		[DataType(DataType.MultilineText)]
		[AllowHtml]
		public string ShortDiscription { get; set; }

		[Display(Name = "متن ")]
		[DataType(DataType.MultilineText)]
		[AllowHtml]
		public string Discription { get; set; }

		[Display(Name = "ادرس ")]
		public string Address { get; set; }

		[Display(Name = "قیمت به تومان")]
		public long Price { get; set; }

		[Display(Name = "نمایش در اسلایدر")]
		public bool Slider { get; set; }

		[Display(Name = "ویژه")]
		public bool Special { get; set; }
		[Display(Name = "مشاهده")]
		public int Visite { get; set; }

		[Display(Name = " تصویر")]
		[MaxLength(100)]
		public string ImageName { get; set; }

		[Display(Name = "تاریخ ثبت")]
		[DisplayFormat(DataFormatString ="{0:yyyy/MM/dd}")]
		public DateTime CreatDate { get; set; }
		#endregion

		#region rellation
		public virtual List<ProductGallery> ProductGalleries { get; set; }
		public virtual List<EquipmentProduct> EquipmentProducts { get; set; }
		public virtual List<SpecificationsProduct> specifications { get; set; }
		#endregion

		public Product()
		{

		}
	}
}
