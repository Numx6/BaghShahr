using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
	public class HomeSlider
	{
		[Key]
		public int Id { get; set; }
		[Display(Name = "تصویر")]
		[MaxLength(100)]
		public string ImgName { get; set; }
		[Display(Name = "alt گوگل")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(50)]
		public string ImgAlt { get; set; }
		[Display(Name = "عنوان")]
		[MaxLength(100)]
		public string Title { get; set; }
		[Display(Name = "عنوان فرعی")]
		[MaxLength(100)]
		public string SubTitle { get; set; }
		[Display(Name = "تاریخ ثبت")]
		[DisplayFormat(DataFormatString = "{0: yyyy/MM/dd}")]
		public DateTime CreatDate { get; set; }
	}
}
