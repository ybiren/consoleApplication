using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Net;

namespace ConsoleApp
{
	class Program
	{
		static void Start()
		{
			Console.Write("hello from start");
		}

		static void Start2()
		{
			Console.Write("xx");
		}

		static async Task MainAsync()
		{

			var dat = new WebClient().DownloadString(new Uri(@"c:\yossiapps\jobs\AngularTut\WindowsFormsApplication1\dat.json"));

			/*
			StreamReader sr = new StreamReader(@"c:\yossiapps\jobs\AngularTut\WindowsFormsApplication1\dat.json");
			var dat = sr.ReadToEnd();
			sr.Close();
			*/
			Result res = new JavaScriptSerializer().Deserialize<Result>(dat);

			//List<Action> actionList = new List<Action>();
			foreach (var itm in res.cities)
			{
				var weatherReq = new WeatherReq() { City = itm.name, Interval = itm.interval };
				var t1 = new Task(() => weatherReq.Run());
				Console.Write("hello\r\n");
				
				await Task.Run(() => t1.Start());

				//actionList.Add(t1.Start);
			}

			//await Task.Run(() => Parallel.ForEach<Action>(actionList, (o => o())));
			//await Task.Run(() => Parallel.Invoke(actionList[0], actionList[1]));
			//await Task.Run(()=>Parallel.ForEach(actionList, task => task.Start()));
			Console.Write("end");
		}

		static void Main(string[] args)
		{

			MainAsync().Wait();
			Console.Read();
		}
	}
}
