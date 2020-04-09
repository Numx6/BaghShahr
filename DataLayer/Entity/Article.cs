using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DataLayer
{
	public class Article
	{
		[Key]
		public int Id { get; set; }
		[Display(Name = "عنوان")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(250)]
		public string Title { get; set; }
		[Display(Name = "توضیح کوتا")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[AllowHtml]
		[DataType(DataType.MultilineText)]
		public string ShortDiscript { get; set; }
		[Display(Name = "متن")]
		[AllowHtml]
		[DataType(DataType.MultilineText)]
		public string Text { get; set; }
		[Display(Name = "تصویر")]
		public string ImageName { get; set; }
		[Display(Name = "تاریخ ثبت")]
		[DisplayFormat(DataFormatString ="{0: yyyy/MM/dd}")]
		public DateTime CreatDate { get; set; }

	}
}
