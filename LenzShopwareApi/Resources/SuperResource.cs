using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;


namespace Lenz.ShopwareApi.Resources
{
	public abstract class SuperResource<TResponse>
	{
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType );

		protected string ressourceUrl;

		private IRestClient client { get; set; }

		public SuperResource ( IRestClient client )
		{
			this.client = client;
		}

		public TResponse get ( int id )
		{
			return get( id.ToString() );
		}

		public TResponse get ( string id )
		{
			ApiResponse<TResponse> response = convertResponsestringToObject<TResponse>( executeGet( id ) );
			if ( !response.success )
			{
				throw new Exception( response.message );
			}
			return response.data;
		}

		public List<TResponse> getAll ()
		{
			string data = executeGetAll();
			log.Debug(data);
			ApiResponse<List<TResponse>> response = convertResponsestringToObject<List<TResponse>>( data );
			if ( !response.success )
			{
				throw new Exception( response.message );
			}
			return response.data;
		}

		public string add ( TResponse data )
		{
			return executeAdd( data );
		}

		protected string executeAdd ( TResponse data )
		{
			string json = JsonConvert.SerializeObject( data, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore } );
			return execute( ressourceUrl, Method.POST, null, json );
		}

		public void update ( TResponse data )
		{
			string response = this.executeUpdate( data, "" );
		}

		protected string executeUpdate ( TResponse data, string id )
		{
			string json = JsonConvert.SerializeObject( data, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore } );

			// set id.
			List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
			parameters.Add( new KeyValuePair<string, string>( "id", id ) );
			return execute( ressourceUrl + "/{id}", Method.PUT, parameters, json );
		}

		public void delete ( string id )
		{
			string response = executeDelete( id );
		}

		protected string executeDelete ( string id )
		{
			// set id.
			List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
			parameters.Add( new KeyValuePair<string, string>( "id", id ) );
			string response = execute( ressourceUrl + "/{id}", Method.DELETE, parameters );
			return response;
		}

		protected ApiResponse<A> convertResponsestringToObject<A> ( string responsestring )
		{
			return JsonConvert.DeserializeObject<ApiResponse<A>>( responsestring, new JsonSerializerSettings {
				NullValueHandling = NullValueHandling.Ignore
			} );
		}

		protected string executeGet ( string id )
		{
			// set id.
			List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
			parameters.Add( new KeyValuePair<string, string>( "id", id ) );
			string response = execute( ressourceUrl + "/{id}", Method.GET, parameters );
			return response;
		}

		protected string executeGetAll ()
		{
			List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();

			return execute( ressourceUrl, Method.GET, parameters );
		}

		private string execute ( string ressource, RestSharp.Method method, List<KeyValuePair<string, string>> parameters )
		{
			return execute( ressource, method, parameters, "" );
		}

		private string execute ( string ressource, RestSharp.Method method, List<KeyValuePair<string, string>> parameters, string body )
		{
			var request = new RestRequest( ressource, method );
			request.RequestFormat = DataFormat.Json;

			if ( parameters != null )
			{
				foreach ( KeyValuePair<string, string> parameter in parameters )
				{
					request.AddUrlSegment( parameter.Key, parameter.Value ); // replaces matching token in request.Resource
				}
			}

			// send body if it is available
			request.AddParameter( "application/json; charset=utf-8", body, ParameterType.RequestBody );

			// execute the request
			IRestResponse response = client.Execute( request );

			if ( response.ErrorException != null )
			{
				Debug.WriteLine( "Api Error:" );
				Debug.WriteLine( response.ErrorException.Message );
			}
			else
			{
				string content = response.Content; // raw content as string
				Debug.WriteLine( content );
				return content;
			}
			return "failed";
		}
	}
}
