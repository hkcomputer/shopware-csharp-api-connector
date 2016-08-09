using Lenz.ShopwareApi.Models.Articles;
using Lenz.ShopwareApi.Models.Response;
using System.Collections.Generic;

namespace Lenz.ShopwareApi.Resources
{
	public interface IArticleResource
	{
		List<ArticleMain> getAll ();

		ArticleMain get ( int id );

		ArticleMain get ( string id );

		ArticleMain getByOrdernumber ( string ordernumber );

		IdentifiableResponse add ( ArticleMain article );

		void update ( ArticleMain article );
	}
}