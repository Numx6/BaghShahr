using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
	public interface ISpecification:IDisposable
	{
		IEnumerable<SpecificationsProduct> GetAllSpecifications();
		SpecificationsProduct GetSpecificationsById(int id);
		bool AddSpecification(SpecificationsProduct specifications);
		bool UpdateSpecification(SpecificationsProduct specifications);
		bool DeleteSpecification(SpecificationsProduct specifications);
		bool DeleteSpecification(int id);
		bool DeleteGroupsSpec(int ProductId);
		void Save();
	}
}
