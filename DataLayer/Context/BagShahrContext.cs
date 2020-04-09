using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
	public class BagShahrContext:DbContext
	{
		public DbSet<Product> products { get; set; }
		public DbSet<EquipmentProduct> equipment { get; set; }
		public DbSet<ProductGallery> productGalleries { get; set; }
		public DbSet<SpecificationsProduct> specifications { get; set; }
		public DbSet<Article> Articles { get; set; }
		public DbSet<HomeSlider> HomeSliders { get; set; }
		public DbSet<User> Users { get; set; }
	}
}
