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
using Lenz.ShopwareApi.Models.Media;
using Lenz.ShopwareApi.Models.Response;
using System.IO;

namespace Lenz.ShopwareApi.Resources
{
	public class MediaResource : SuperResource<Media>, IMediaResource
	{
		public MediaResource ( IRestClient client ) :
			base( client )
		{
			ressourceUrl = "media";
		}

		public new IdentifiableResponse add ( Media media )
		{
			if (
				media.album > 0 &&
				media.file.Length > 0 &&
				media.description.Length > 0
			)
			{
				string result = base.add( media );
				return JsonConvert.DeserializeObject<IdentifiableResponse>( result );
			}
			throw new Exception( "Minimum required fields for media add: media.album, media.file, media.description" );
		}

		public new void update ( Media media )
		{
			if ( media.id.HasValue )
			{
				executeUpdate( media, media.id.ToString() );
				return;
			}
			throw new Exception( "Minimum required fields for media update: media.id" );
		}
	}
}
