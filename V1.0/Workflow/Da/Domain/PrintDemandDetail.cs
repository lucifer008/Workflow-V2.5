using System;
using Workflow.Da.Domain.Base;

namespace Workflow.Da.Domain
{
	/// <summary>
	/// Table PRINT_DEMAND_DETAIL¶ÔÓ¦µÄDotNet Object
	/// </summary>
	[Serializable]
	public class PrintDemandDetail : PrintDemandDetailBase
	{
		public PrintDemandDetail()
		{
		}
        private string printDemandName;
        public string PrintDemandName 
        {
            set { printDemandName = value; }
            get { return printDemandName; }
        }
	}
}
