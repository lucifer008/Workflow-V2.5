using System;
using Workflow.Da.Domain.Base;

namespace Workflow.Da.Domain
{
	/// <summary>
	/// Table FACTOR_RELATION¶ÔÓ¦µÄDotNet Object
	/// </summary>
	[Serializable]
	public class FactorRelation : FactorRelationBase
	{
		public FactorRelation()
		{
		}

        private string targetValueColumn;
        public string TargetValueColumn
        {
            set { targetValueColumn = value; }
            get { return targetValueColumn; }
        }

        private string targetTextColumn;
        public string TargetTextColumn
        {
            set { targetTextColumn = value; }
            get { return targetTextColumn; }
        }

        private string targetTable;
        public string TargetTable
        {
            set { targetTable = value; }
            get { return targetTable; }
        }

        private long sourceValue;
        public long SourceValue
        {
            set { sourceValue = value; }
            get { return sourceValue; }
        }

        private string businessTypeName;
        public string BusinessTypeName 
        {
            set { businessTypeName = value; }
            get { return businessTypeName; }
        }

        private string priceFactorDisplayText;
        public string PriceFactorDisplayText 
        {
            set { priceFactorDisplayText = value; }
            get { return priceFactorDisplayText; }
        }

        private string priceFactorDisplayText2;
        public string PriceFactorDisplayText2
        {
            set { priceFactorDisplayText2 = value; }
            get { return priceFactorDisplayText2; }
        }

        private long priceFactorId2;
        public  long PriceFactorId2
        {
            get { return priceFactorId2; }
            set { priceFactorId2 = value; }
        }

        private string[] arrSourceValue;
        public string[] ArrSourceValue 
        {
            get { return arrSourceValue; }
            set { arrSourceValue = value; }
        }
	}
}
