using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
	public class ArticleRepo : IArticle
	{
		BagShahrContext db;
		public ArticleRepo(BagShahrContext db)
		{
			this.db = db;
		}
		public bool AddArticle(Article article)
		{
			try
			{
				db.Articles.Add(article);
				return true;
			}
			catch (Exception)
			{

				return false;
			}
		}

		public bool DeleteArticle(Article article)
		{
			try
			{
				db.Entry(article).State = EntityState.Deleted;
				return true;
			}
			catch (Exception)
			{

				return false;
			}
		}

		public bool DeleteArticle(int id)
		{
			try
			{
				var article = GetArticleById(id);
				DeleteArticle(article);
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

		public IEnumerable<Article> GetAllArticle()
		{
			return db.Articles.ToList();
		}

		public Article GetArticleById(int id)
		{
			return db.Articles.Find(id);
		}

		public IEnumerable<Article> LastArticle(int take = 3)
		{
			return db.Articles.OrderByDescending(d => d.CreatDate).Take(take).ToList();
		}

		public void Save()
		{
			db.SaveChanges();
		}

		public bool UpdateArticle(Article article)
		{
			try
			{
				db.Entry(article).State = EntityState.Modified;
				return true;
			}
			catch (Exception)
			{

				return false;
			}
		}
	}
}
