﻿using Lenz.ShopwareApi.Models.Articles;
using System.Collections.Generic;

namespace Lenz.ShopwareApi.Resources
{
	public interface IArticleResource
	{
		List<ArticleMain> getAll ();

		ArticleMain get ( int id );

		ArticleMain get ( string id );

		ArticleMain getByOrdernumber ( string ordernumber );

		void add ( ArticleMain article );

		void update ( ArticleMain article );
	}
}