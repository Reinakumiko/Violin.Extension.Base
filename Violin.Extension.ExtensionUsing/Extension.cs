using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Violin.Extension.Data;
using Violin.Extension.ExtensionSample;
using Violin.Extension.SampleBuilder;

namespace Violin.Extension.ExtensionUsing
{
	public class Extension : IExtension<SampleExtensionBuilder>
	{
		public void Configuration(SampleExtensionBuilder builder)
		{
			Console.WriteLine("Called using extension configuration...");
		}

		public void Start()
		{
			Console.WriteLine("Called using extension start...");

			new Testing()
			{
				Message = "This is for using test message"
			}.ShowMessage();
		}

		public void Configuration(IExtensionBuilder builder)
		{
		}
	}
}
