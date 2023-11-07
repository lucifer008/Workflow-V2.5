using System;
using System.Collections.Generic;
using System.Text;
using IBatisNet.DataMapper.TypeHandlers;

namespace Workflow.Da.Support
{
	public class ForeignKeyTypeHandlerCallback : ITypeHandlerCallback
	{
		#region ITypeHandlerCallback ≥…‘±

		object ITypeHandlerCallback.GetResult(IResultGetter getter)
		{
			return getter.Value;
		}

		object ITypeHandlerCallback.NullValue
		{
			get { return 0; }
		}

		void ITypeHandlerCallback.SetParameter(IParameterSetter setter, object parameter)
		{
			long value = (long)parameter;
			if (value == 0)
			{
				setter.Value = DBNull.Value;
			}
			else
			{
				setter.Value = value;
			}
		}

		object ITypeHandlerCallback.ValueOf(string s)
		{
			return Int64.Parse(s);
		}

		#endregion
	}
}
