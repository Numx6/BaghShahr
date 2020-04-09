using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
	public interface IGallery:IDisposable
	{
		IEnumerable<ProductGallery> GetAllGalleries();
		ProductGallery GetGalleryById(int id);
		bool AddGallery(ProductGallery gallery);
		bool UpdateGallery(ProductGallery gallery);
		bool DeleteGallery(ProductGallery gallery);
		bool DeleteGallery(int id);
		void Save();
	}
}
