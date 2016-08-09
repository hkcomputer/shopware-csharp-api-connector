﻿using Lenz.ShopwareApi.Models.Orders;
using RestSharp;
using System;

namespace Lenz.ShopwareApi.Resources
{
	public class OrderResource : SuperResource<Order>, IOrderResource
	{
		public OrderResource ( IRestClient client )
			: base( client )
		{
			ressourceUrl = "orders";
		}

		public void add ()
		{
			throw new NotImplementedException( "It is not allowed to add orders via Shopware REST API." );
		}

		public void delete ()
		{
			throw new NotImplementedException( "It is not allowed to delete orders via Shopware REST API." );
		}
	}
}
