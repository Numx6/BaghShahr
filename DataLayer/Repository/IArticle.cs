using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
	public interface IArticle:IDisposable
	{
		IEnumerable<Article> GetAllArticle();
		IEnumerable<Article> LastArticle(int take=3);
		Article GetArticleById(int id);
		bool AddArticle(Article  article);
		bool UpdateArticle(Article article);
		bool DeleteArticle(Article article);
		bool DeleteArticle(int id);
		void Save();
	}
}
