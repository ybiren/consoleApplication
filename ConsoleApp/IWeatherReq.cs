using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
	public interface IWeatherReq
	{
		void Run();
		int Interval { get; set; }
		string City { get; set; }
	}
}
