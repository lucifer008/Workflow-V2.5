using System;
using Workflow.Da.Domain.Base;
using System.Collections.Generic;

namespace Workflow.Da.Domain
{
	/// <summary>
	/// Table PRICE_FACTOR对应的DotNet Object
	/// </summary>
	[Serializable]
	public class PriceFactor : PriceFactorBase
	{
        /** 业务类型_ID [BUSINESS_TYPE_ID] */
        private long businessTypeId;
        /** 价格因素_ID [PRICE_FACTOR_ID] */
        private long priceFactorId;

        /// <summary>
        /// 业务类型_ID [BUSINESS_TYPE_ID]
        /// </summary>
        public long BusinessTypeId
        {
            get { return this.businessTypeId; }
            set { this.businessTypeId = value; }
        }
        /// <summary>
        /// 价格因素_ID [PRICE_FACTOR_ID]
        /// </summary>
        public long PriceFactorId
        {
            get { return this.priceFactorId; }
            set { this.priceFactorId = value; }
        }

        /// <summary>
        /// 动态获取价格因素时，根据Price_Factor表中的Target_Table列的值 传递列名,如果是Factor_Value(动态因素),
        /// 则传递"Price_Factor_Id",如果为固定因素,则传递"Id"
        /// 指定是Price_Factor_Id 还是Id
        /// </summary>
        private string targetPriceFactorId;
        public string TargetPriceFactorId
        {
            get { return targetPriceFactorId; }
            set { targetPriceFactorId = value; }
        }
        /// <summary>
        /// 因素值ID
        /// 由于价格取得的时候需要因素对象PriceFactor,和动态因素对象FactorValue.
        /// 主要用到字段:
        /// PriceFactor中的因素ID(ID),TARGET_TABLE,TARGET_VALUE_COLUMN,TARGET_TEXT_COLUMN
        /// FactorValue中的因素值(ID)
        /// ibatis中parameterClass不支持两个对象,为了简化,将PriceFactor中增加因素值ID属性
        /// 主要用到的字段:因素ID,因素值ID,TargetTable,Target
        /// </summary>
        private long priceValueId;
        public long PriceValueId
        {
            get { return this.priceValueId; }
            set { this.priceValueId = value;}
        }

        #region Add:Cry,Date:2009-1-9

        #endregion

    }
}
