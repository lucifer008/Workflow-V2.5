using System;
using Workflow.Da.Domain.Base;

namespace Workflow.Da.Domain
{
	/// <summary>
	/// Table CASH_HAND_OVER¶ÔÓ¦µÄDotNet Object
	/// </summary>
	[Serializable]
	public class CashHandOver : CashHandOverBase
	{
		public CashHandOver()
		{
		}

        private long ticketCount;
        public long TicketCount 
        {
            set { ticketCount = value; }
            get { return ticketCount; }
        }

        private decimal prepayMoneySum;
        public decimal PrepayMoneySum 
        {
            set { prepayMoneySum = value; }
            get { return prepayMoneySum; }
        }

        private decimal membercardDiffAmount;
        public decimal MembercardDiffAmount 
        {
            set { membercardDiffAmount = value; }
            get { return membercardDiffAmount; }
        }
	}
}
