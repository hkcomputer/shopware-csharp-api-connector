using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lenz.ShopwareApi.Models.Media
{
	public class Media
	{
		public int? id;
		public int album;
		public string name;
		public string file;
		public string description;
		public string path;
		public string type;
		public string extension;
		public int? userId;
		public DateTime? created;
		public int? fileSize;
	}
}
