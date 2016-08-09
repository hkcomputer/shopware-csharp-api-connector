using Lenz.ShopwareApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lenz.ShopwareApi.Models.Response
{
	public class IdentifiableResponse
	{
		public Identifiable data;
		public bool success;
		public string message;
	}
}
