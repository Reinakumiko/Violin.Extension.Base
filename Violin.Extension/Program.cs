using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Violin.Extension.Loader;
using Violin.Extension.SampleBuilder;

namespace Violin.Extension
{
	class Program
	{
		static void Main(string[] args)
		{
			var builder = new SampleExtensionBuilder();
			ExtensionLoader.LoadDirectory<SampleExtensionBuilder>(builder, "./plugins");

			Console.ReadLine();
		}
	}
}
