using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Violin.Extension.Data;

namespace Violin.Extension.Loader
{
	public class ExtensionLoader
	{
		/// <summary>
		/// 载入目录下的所有扩展程序
		/// </summary>
		/// <param name="folder">目录路径</param>
		public static void LoadDirectory<T>(T builder, string folder) where T : class, IExtensionBuilder
		{
			var allPlugins = Directory.EnumerateFiles(folder, "*.dll", SearchOption.TopDirectoryOnly);

			foreach (var item in allPlugins)
			{
				Load<T>(builder, item);
			}
		}

		/// <summary>
		/// 载入扩展程序
		/// </summary>
		/// <typeparam name="T">需要传入的配置类型</typeparam>
		/// <param name="builder">配置数据类</param>
		/// <param name="libraryName">需要载入的程序集的名称(文件名)</param>
		public static void Load<T>(T builder, string libraryName) where T : class, IExtensionBuilder
		{
			var assembly = Assembly.LoadFrom(libraryName);

			var className = string.Format("{0}.Extension", assembly.GetName().Name);
			var type = assembly.GetType(className);
			var instance = Activator.CreateInstance(type) as IExtension<T>;

			instance.Configuration(builder);
			instance.Start();
		}
	}
}
