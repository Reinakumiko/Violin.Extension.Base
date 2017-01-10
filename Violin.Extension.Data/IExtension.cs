using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Violin.Extension.Data
{
	/// <summary>
	/// 扩展程序的接入口，一般可只用泛型接入口。
	/// </summary>
	public interface IExtension
	{
		/// <summary>
		/// 扩展程序的主入口
		/// </summary>
		void Start();

		/// <summary>
		/// 设置扩展程序的基本应用配置(继承自 Violin.Extension.Data.IExtension 接口)
		/// </summary>
		/// <param name="builder">扩展程序的配置类</param>
		void Configuration(IExtensionBuilder builder);
	}

	/// <summary>
	/// 扩展程序的接入口
	/// </summary>
	/// <typeparam name="T">针对程序接入口使用的配置类型</typeparam>
	public interface IExtension<T> : IExtension where T : IExtensionBuilder
	{
		/// <summary>
		/// 设置扩展程序的应用配置
		/// </summary>
		/// <param name="builder">需要使用的配置类型</param>
		void Configuration(T builder);
	}
}
