using System;
using System.Collections.Generic;
using System.Text;
using Spring.Objects.Factory;
using Castle.DynamicProxy;
using System.Reflection;
using Spring.Context;

namespace Workflow.Support.Spring
{
	/// <summary>
	/// 对action对象的包装，可以在其方法调用前后，添加自己的处理程序。
	/// </summary>
	public class ActionObjectFactory : IFactoryObject, IApplicationContextAware
	{
		private object action;
		private Type actionClass;
		private IApplicationContext applicationContext;

		public object Action
		{
			set 
			{
				action = value;
			}
		}

		public Type ActionClass
		{
			set
			{
				actionClass = value;
			}
		}
		
		#region IFactoryObject 成员

		public object GetObject()
		{
			ProxyGenerator proxyGenerator = new ProxyGenerator();
			GeneratorContext context = new GeneratorContext();
			IInterceptor handler = new SecurityInterceptor(actionClass);

			object proxy = proxyGenerator.CreateClassProxy(actionClass, handler, Type.EmptyTypes);

			PropertyInfo[] pis = actionClass.GetProperties();
			foreach (PropertyInfo pi in pis)
			{
				try
				{
					if (pi.CanWrite)
					{
						string name = pi.Name;
						object o = applicationContext.GetObject(name);
						pi.GetSetMethod().Invoke(proxy, new object[] { o });
					}
				}
				catch { }
			}
			//context.AddMixinInstance(action);
			//return proxyGenerator.CreateCustomClassProxy(ObjectType, handler, context);

			return proxy;
		}

		public bool IsSingleton
		{
			get { return false; }
		}

		public Type ObjectType
		{
			get { return actionClass; }
		}

		#endregion

		public IApplicationContext ApplicationContext
		{
			get
			{
				return applicationContext;
			}
			set
			{
				applicationContext = value;
			}
		}
	}
}
