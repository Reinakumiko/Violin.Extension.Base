using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Violin.Extension.Data;
using Violin.Extension.Loader;
using Violin.Extension.SampleBuilder;

namespace Violin.Extension.ExtensionSample
{
	public class Extension : IExtension<SampleExtensionBuilder>
	{
		/// <summary>
		/// 设置扩展程序的应用配置
		/// </summary>
		/// <param name="builder"></param>
		public void Configuration(SampleExtensionBuilder builder)
		{
			Console.WriteLine("Extension Configuration...");
		}

		/// <summary>
		/// 设置扩展程序的基本应用配置(继承自 Violin.Extension.Data.IExtension 接口)
		/// </summary>
		/// <param name="builder"></param>
		public void Configuration(IExtensionBuilder builder)
		{
		}

		public void Start()
		{
			Console.WriteLine("Extension Start...");

			var listObject = new { JsonKey1 = "JsonValue1", Key2 = "Value2" };

			//扩展程序引用程序集测试
			var jsonString = JsonConvert.SerializeObject(listObject);
			var jObject = JsonConvert.DeserializeObject(jsonString);
			Console.WriteLine("Write JObject: {0}", jObject);

			//扩展程序异常抛出测试
			Console.WriteLine("Throw Exception.");
			throw new Exception();
		}
	}
}