using System;
using Workflow.Da.Domain.Base;
using System.Collections.Generic;

namespace Workflow.Da.Domain
{
	/// <summary>
	/// Table PRICE_FACTOR��Ӧ��DotNet Object
	/// </summary>
	[Serializable]
	public class PriceFactor : PriceFactorBase
	{
        /** ҵ������_ID [BUSINESS_TYPE_ID] */
        private long businessTypeId;
        /** �۸�����_ID [PRICE_FACTOR_ID] */
        private long priceFactorId;

        /// <summary>
        /// ҵ������_ID [BUSINESS_TYPE_ID]
        /// </summary>
        public long BusinessTypeId
        {
            get { return this.businessTypeId; }
            set { this.businessTypeId = value; }
        }
        /// <summary>
        /// �۸�����_ID [PRICE_FACTOR_ID]
        /// </summary>
        public long PriceFactorId
        {
            get { return this.priceFactorId; }
            set { this.priceFactorId = value; }
        }

        /// <summary>
        /// ��̬��ȡ�۸�����ʱ������Price_Factor���е�Target_Table�е�ֵ ��������,�����Factor_Value(��̬����),
        /// �򴫵�"Price_Factor_Id",���Ϊ�̶�����,�򴫵�"Id"
        /// ָ����Price_Factor_Id ����Id
        /// </summary>
        private string targetPriceFactorId;
        public string TargetPriceFactorId
        {
            get { return targetPriceFactorId; }
            set { targetPriceFactorId = value; }
        }
        /// <summary>
        /// ����ֵID
        /// ���ڼ۸�ȡ�õ�ʱ����Ҫ���ض���PriceFactor,�Ͷ�̬���ض���FactorValue.
        /// ��Ҫ�õ��ֶ�:
        /// PriceFactor�е�����ID(ID),TARGET_TABLE,TARGET_VALUE_COLUMN,TARGET_TEXT_COLUMN
        /// FactorValue�е�����ֵ(ID)
        /// ibatis��parameterClass��֧����������,Ϊ�˼�,��PriceFactor����������ֵID����
        /// ��Ҫ�õ����ֶ�:����ID,����ֵID,TargetTable,Target
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
