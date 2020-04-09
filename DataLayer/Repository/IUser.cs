using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
	public interface IUser:IDisposable
	{
		IEnumerable<User> GetAllUser();
		User GetUserById(int id);
		bool AddUser(User user);
		bool UpdateUser(User user);
		bool DeleteUser(User user);
		bool DeleteUser(int id);
		bool HasUser(User user);
		void Save();

	}
}
