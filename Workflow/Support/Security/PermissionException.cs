using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Support.Exception;

namespace Workflow.Support.Security
{
	/// <summary>
	/// ���������쳣����
	/// </summary>
	public class PermissionException : WorkflowException
	{
		public PermissionException() : base()
        {}

        public PermissionException(string message)
            : base(message)
        { }

		public PermissionException(string message, System.Exception exception)
            : base(message, exception)
        { }
	}
}
