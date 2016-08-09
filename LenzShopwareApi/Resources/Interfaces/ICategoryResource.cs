using Lenz.ShopwareApi.Models.Categories;
using Lenz.ShopwareApi.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lenz.ShopwareApi.Resources.Interfaces
{
	interface ICategoryResource
	{
		List<Category> getAll ();

		Category get ( int id );

		Category get ( string id );

		IdentifiableResponse add ( Category categorie );

		IdentifiableResponse update ( Category article );
	}
}
