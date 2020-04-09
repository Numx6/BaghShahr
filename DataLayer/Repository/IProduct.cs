using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
	public interface IProduct:IDisposable
	{
		IEnumerable<Product> GetAllProduct();
		IEnumerable<Product> GetSpecialProduct();
		IEnumerable<Product> Favorit(int take=4);
		IEnumerable<Product> NewProduct(int take=8);
		IEnumerable<Product> SearchProduct(string q);
		Product GetProductById(int ProductId);
		bool AddProduct(Product product);
		bool UpdateProduct(Product product);
		bool DeleteProduct(Product product);
		bool DeleteProduct(int ProductId);

		void Save();
	}
}
