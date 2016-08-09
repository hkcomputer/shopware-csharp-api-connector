using Lenz.ShopwareApi.Models.Categories;
using Lenz.ShopwareApi.Models.Media;
using Lenz.ShopwareApi.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lenz.ShopwareApi.Resources.Interfaces
{
	interface IMediaResource
	{
		List<Media> getAll ();

		Media get ( int id );

		Media get ( string id );

		IdentifiableResponse add ( Media categorie );

		void update ( Media article );
	}
}
