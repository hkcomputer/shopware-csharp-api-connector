using Lenz.ShopwareApi.Models.Orders;
using RestSharp;

namespace Lenz.ShopwareApi.Resources
{
	public class CustomerResource : SuperResource<Order>
	{
		public CustomerResource ( IRestClient client )
			: base( client )
		{
			ressourceUrl = "customers";
		}
	}
}
