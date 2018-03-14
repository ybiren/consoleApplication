using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Threading;
using System.IO;


namespace ConsoleApp
{
	 /* 
	Result res = new c.Deserialize<Result>(dat);

	List<Action> actionList = new List<Action>();
			foreach (var itm in res.cities)
			{
				WebReq wb = new WebReq() { city = itm.name, interval = itm.interval };
				*/


	public class WeatherReq: IWeatherReq
	{
		private JavaScriptSerializer mJsSerializer;
		private WebClient mWebClient;

		private void WriteToCsv(string str)
		{
			string fileName = String.Format("{0}.csv", City);
			string path = Path.Combine("CsvFiles", fileName);
			var sw = new StreamWriter(path);
			sw.Write(str);
			sw.Close();
		}


		public WeatherReq()
		{
			mJsSerializer = new JavaScriptSerializer();
			mWebClient = new WebClient();
		}

		public string City { get; set; }
		 public int Interval { get; set; }

		public void Run()
		{
			//Console.Write("hello from {0}", City);
			string address = String.Format("http://xxx.xxx.xxx?city={0}", City);
			while (true)
			{
				try
				{
					//var resStr = mWebClient.DownloadString(address);
					//Result res =
					Console.Write("{0},{1}\n" ,City,Interval);
				
					//WriteToCsv("hello");
				}
				catch (Exception exp)
				{
					Console.Write("exception from {0}:{1}",City,exp.Message);

				}
				Task.Delay(Interval).Wait();
			}  
		}

	}
  
 



}



