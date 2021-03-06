﻿using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using System.Diagnostics;
using Lenz.ShopwareApi.Resources;
using RestSharp.Authenticators;

namespace Lenz.ShopwareApi
{
	public class ShopwareApi
	{
		private string url;
		private string username;
		private string password;
		private RestClient client;

		private ArticleResource articleResource;
		private OrderResource orderResource;
		private CategoryResource categoryResource;
		private MediaResource mediaResource;

		public ShopwareApi ( string url, string username, string password )
		{
			Debug.WriteLine( "Shopware API for URL \"" + url + "\" started" );
			Debug.WriteLine( "Username: " + username );
			Debug.WriteLine( "API Key: " + password );

			this.url = url;
			this.username = username;
			this.password = password;

			client = new RestClient( url );
			client.Authenticator = new DigestAuthenticator( username, password );
		}

		public ArticleResource getArticleResource ()
		{
			if ( articleResource == null )
			{
				articleResource = new ArticleResource( client );
			}
			return articleResource;
		}

		public OrderResource getOrderResource ()
		{
			if ( orderResource == null )
			{
				orderResource = new OrderResource( client );
			}
			return orderResource;
		}

		public CategoryResource getCategoryResource ()
		{
			if ( categoryResource == null )
			{
				categoryResource = new CategoryResource( client );
			}
			return categoryResource;
		}

		public MediaResource getMediaResource ()
		{
			if ( mediaResource == null )
			{
				mediaResource = new MediaResource( client );
			}
			return mediaResource;
		}
	}
	public class DigestAuthenticator :
		IAuthenticator
	{
		private readonly string _user;
		private readonly string _pass;

		public DigestAuthenticator ( string user, string pass )
		{
			_user = user;
			_pass = pass;
		}

		public void Authenticate ( IRestClient client, IRestRequest request )
		{
			request.Credentials = new NetworkCredential( _user, _pass );
		}
	}
}
