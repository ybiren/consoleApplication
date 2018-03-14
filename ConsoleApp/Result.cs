using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{

	public class Result
	{
		public List<City> cities { get; set; }
	}

	public class City
	{
		public string name { get; set; }
		public int interval { get; set; }
	}
}
