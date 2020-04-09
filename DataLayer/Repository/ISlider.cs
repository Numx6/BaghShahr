using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
	public interface ISlider:IDisposable
	{
		IEnumerable<HomeSlider> GetAllSlider();
		HomeSlider GetSliderById(int id);
		bool AddSlider(HomeSlider slider);
		bool UpdateSlider(HomeSlider slider);
		bool DeleteSlider(HomeSlider slider);
		bool DeleteSlider(int id);
		void Save();
	}
}
