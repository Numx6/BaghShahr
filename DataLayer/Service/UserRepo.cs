using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
	public class UserRepo : IUser
	{
		BagShahrContext db;
		public UserRepo(BagShahrContext db)
		{
			this.db = db;
		}
		public bool AddUser(User user)
		{
			try
			{
				db.Users.Add(user);
				return true;
			}
			catch (Exception)
			{

				return false;
			}
		}

		public bool DeleteUser(User user)
		{
			try
			{
				db.Entry(user).State = EntityState.Deleted;
				return true;
			}
			catch (Exception)
			{

				return false;
			}
		}

		public bool DeleteUser(int id)
		{
			try
			{
				var user = GetUserById(id);
				DeleteUser(user);
				return true;
			}
			catch (Exception)
			{

				return false;
			}
		}

		public void Dispose()
		{
			db.Dispose();
		}

		public IEnumerable<User> GetAllUser()
		{
			return db.Users.ToList();
		}

		public User GetUserById(int id)
		{
			return db.Users.Find(id);
		}

		public bool HasUser(User user)
		{
			try
			{
				var u = db.Users.SingleOrDefault(p => p.UserName == user.UserName && p.Password == user.Password);
				if (u !=null)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			catch (Exception)
			{

				return false;
			}
		}

		public void Save()
		{
			db.SaveChanges();
		}

		public bool UpdateUser(User user)
		{
			try
			{
				db.Entry(user).State = EntityState.Modified;
				return true;
			}
			catch (Exception)
			{

				return false;
			}
		}
	}
}
