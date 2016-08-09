using Lenz.ShopwareApi.Resources;
using Lenz.ShopwareApi.Models.Categories;
using Lenz.ShopwareApi.Resources.Interfaces;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Lenz.ShopwareApi.Models.Response;

namespace Lenz.ShopwareApi.Resources
{
	public class CategoryResource : SuperResource<Category>, ICategoryResource
	{
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		public CategoryResource ( IRestClient client ) :
			base( client )
		{
			ressourceUrl = "categories";
		}

		public new IdentifiableResponse add ( Category category )
		{
			if ( category.name.Length != 0 )
			{
				string result = base.add( category );
				return JsonConvert.DeserializeObject<IdentifiableResponse>( result );
			}
			throw new Exception( "Minimum required fields for category add: category.name" );
		}

		public new IdentifiableResponse update ( Category category )
		{
			if (
				category.id.HasValue &&
				category.name.Length > 0
			)
			{
				string response = executeUpdate( category, category.id.ToString() );
				return JsonConvert.DeserializeObject<IdentifiableResponse>( response );
			}
			throw new Exception( "Minimum required fields for category update: category.id, category.name" );
		}
		
	}
}
