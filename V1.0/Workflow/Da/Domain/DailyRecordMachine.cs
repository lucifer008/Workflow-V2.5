using System;
using Workflow.Da.Domain.Base;

namespace Workflow.Da.Domain
{
	/// <summary>
	/// Table DAILY_RECORD_MACHINE¶ÔÓ¦µÄDotNet Object
	/// </summary>
	[Serializable]
	public class DailyRecordMachine : DailyRecordMachineBase
	{
		public DailyRecordMachine()
		{
		}

        private int currentPageIndex;
        public int CurrentPageIndex 
        {
            set { currentPageIndex = value;}
            get { return currentPageIndex; }
        }

        private int rowCount;
        public int RowCount 
        {
            set { rowCount = value; }
            get { return rowCount; }
        }

        private string beginDoWatchDateTimeString;
        public string BeginDoWatchDateTimeString 
        {
            set { beginDoWatchDateTimeString = value; }
            get { return beginDoWatchDateTimeString; }
        }

        private string endDoWatchDateTimeString;
        public string EndDoWatchDateTimeString 
        {
            set { endDoWatchDateTimeString = value; }
            get { return endDoWatchDateTimeString; }
        }

        private string machineName;
        public string MachineName 
        {
            set { machineName = value; }
            get { return machineName; }
        }

        private string paperSharpe;
        public string PaperSharpe 
        {
            set { paperSharpe = value; }
            get { return paperSharpe; }
        }
	}
}
