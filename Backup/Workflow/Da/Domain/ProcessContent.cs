using System;
using Workflow.Da.Domain.Base;

namespace Workflow.Da.Domain
{
	/// <summary>
	/// Table PROCESS_CONTENT��Ӧ��DotNet Object
	/// </summary>
	[Serializable]
	public class ProcessContent : ProcessContentBase
	{
		public ProcessContent()
		{
		}

        private string businessTypeName;
        public string BusinessTypeName 
        {
            set { businessTypeName = value; }
            get { return businessTypeName; }
        }
	}
}
