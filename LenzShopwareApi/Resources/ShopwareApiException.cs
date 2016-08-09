using System;
using System.Runtime.Serialization;

namespace Lenz.ShopwareApi.Resources
{
	[Serializable]
	internal class ShopwareApiException : Exception
	{
		public ShopwareApiException ( string message, Exception innerException ) : base( message, innerException )
		{
		}
	}
}