using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
	public class User
	{
		[Key]
		public int UserId { get; set; }
		[Display(Name = "نام")]
		[MaxLength(400)]
		public string Name { get; set; }
		[Display(Name = "نام کاربری")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(250)]
		public string UserName { get; set; }
		[Display(Name = "کلمه عبور")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(250)]
		public string Password { get; set; }
		[Display(Name = "تاریخ ثبت")]
		[DisplayFormat(DataFormatString = "{0: yyyy/MM/dd}")]
		public DateTime CreatDate { get; set; }
	}
}
