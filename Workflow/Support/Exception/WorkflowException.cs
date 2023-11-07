using System;
using System.Collections.Generic;
using System.Text;

namespace Workflow.Support.Exception
{
    public class WorkflowException : System.Exception
    {
        public WorkflowException() : base()
        {}

        public WorkflowException(string message)
            : base(message)
        { }

        public WorkflowException(string message, System.Exception exception)
            : base(message, exception)
        { }
    }
}
