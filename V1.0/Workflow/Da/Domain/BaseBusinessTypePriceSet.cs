using System;
using System.Collections.Generic;
using Workflow.Da.Domain.Base;
using Workflow.Support.Exception;

namespace Workflow.Da.Domain
{
	/// <summary>
	/// Table BASE_BUSINESS_TYPE_PRICE_SET对应的DotNet Object
	/// </summary>
	[Serializable]
	public class BaseBusinessTypePriceSet : BaseBusinessTypePriceSetBase
	{
		public BaseBusinessTypePriceSet()
		{
		}

        public long this[int index]
        {
            get
            {
                switch (index + 1)
                {
                    case 1:
                        return this.Factor1;
                    case 2:
                        return this.Factor2;
                    case 3:
                        return this.Factor3;
                    case 4:
                        return this.Factor4;
                    case 5:
                        return this.Factor5;
                    case 6:
                        return this.Factor6;
                    case 7:
                        return this.Factor7;
                    case 8:
                        return this.Factor8;
                    case 9:
                        return this.Factor9;
                    case 10:
                        return this.Factor10;
                    case 11:
                        return this.Factor11;
                    case 12:
                        return this.Factor12;
                    case 13:
                        return this.Factor13;
                    case 14:
                        return this.Factor14;
                    case 15:
                        return this.Factor15;
                    case 16:
                        return this.Factor16;
                    case 17:
                        return this.Factor17;
                    case 18:
                        return this.Factor18;
                    case 19:
                        return this.Factor19;
                    case 20:
                        return this.Factor20;
                    default:
                        throw new WorkflowException();
                }            
            }
            set 
            {
                switch (index + 1)
                {
                    case 1:
                        this.Factor1 = value;
                        break;
                    case 2:
                        this.Factor2 = value;
                        break;
                    case 3:
                        this.Factor3 = value;
                        break;
                    case 4:
                        this.Factor4 = value;
                        break;
                    case 5:
                        this.Factor5 = value;
                        break;
                    case 6:
                        this.Factor6 = value;
                        break;
                    case 7:
                        this.Factor7 = value;
                        break;
                    case 8:
                        this.Factor8 = value;
                        break;
                    case 9:
                        this.Factor9 = value;
                        break;
                    case 10:
                        this.Factor10 = value;
                        break;
                    case 11:
                        this.Factor11 = value;
                        break;
                    case 12:
                        this.Factor12 = value;
                        break;
                    case 13:
                        this.Factor13 = value;
                        break;
                    case 14:
                        this.Factor14 = value;
                        break;
                    case 15:
                        this.Factor15 = value;
                        break;
                    case 16:
                        this.Factor16 = value;
                        break;
                    case 17:
                        this.Factor17 = value;
                        break;
                    case 18:
                        this.Factor18 = value;
                        break;
                    case 19:
                        this.Factor19 = value;
                        break;
                    case 20:
                        this.Factor20 = value;
                        break;
                    default:
                        throw new WorkflowException();
                }
            }
        }

        //设置每一个因素值ID
        public void SetItem(int i,long value)
        {
            switch (i + 1)
            {
                case 1:
                    this.Factor1 = value;
                    break;
                case 2:
                    this.Factor2 = value;
                    break;
                case 3:
                    this.Factor3 = value;
                    break;
                case 4:
                    this.Factor4 = value;
                    break;
                case 5:
                    this.Factor5 = value;
                    break;
                case 6:
                    this.Factor6 = value;
                    break;
                case 7:
                    this.Factor7 = value;
                    break;
                case 8:
                    this.Factor8 = value;
                    break;
                case 9:
                    this.Factor9 = value;
                    break;
                case 10:
                    this.Factor10 = value;
                    break;
                case 11:
                    this.Factor11 = value;
                    break;
                case 12:
                    this.Factor12 = value;
                    break;
                case 13:
                    this.Factor13 = value;
                    break;
                case 14:
                    this.Factor14 = value;
                    break;
                case 15:
                    this.Factor15 = value;
                    break;
                case 16:
                    this.Factor16 = value;
                    break;
                case 17:
                    this.Factor17 = value;
                    break;
                case 18:
                    this.Factor18 = value;
                    break;
                case 19:
                    this.Factor19 = value;
                    break;
                case 20:
                    this.Factor20 = value;
                    break;
            }
            
        }

        //显示每一个因素值ID
        //public long Item(int i)
        //{   
        //    switch (i+1)
        //    {
        //        case 1:
        //            return this.Factor1;
        //        case 2:
        //            return this.Factor2;
        //        case 3:
        //            return this.Factor3;
        //        case 4:
        //            return this.Factor4;
        //        case 5:
        //            return this.Factor5;
        //        case 6:
        //            return this.Factor6;
        //        case 7:
        //            return this.Factor7;
        //        case 8:
        //            return this.Factor8;
        //        case 9:
        //            return this.Factor9;
        //        case 10:
        //            return this.Factor10;
        //        case 11:
        //            return this.Factor11;
        //        case 12:
        //            return this.Factor12;
        //        case 13:
        //            return this.Factor13;
        //        case 14:
        //            return this.Factor14;
        //        case 15:
        //            return this.Factor15;
        //        case 16:
        //            return this.Factor16;
        //        case 17:
        //            return this.Factor17;
        //        case 18:
        //            return this.Factor18;
        //        case 19:
        //            return this.Factor19;
        //        case 20:
        //            return this.Factor20;
        //        default:
        //            throw new WorkflowException();
        //    }
        //}

        //存储每一条价格信息的因素的实际值
        private string[] texts;
        public string[] Texts
        {
            get { return texts;  }
            set { texts = value; }
        }

        //客户选择批量数据时查询使用
        private string idList;
        public string IdList
        {
            get { return idList;  }
            set { idList = value; }
        }
        #region 取价格时用到的属性 付强
        //业务类型ID
        private long businessTypeId;
        public long BusinessTypeId
        {
            get { return businessTypeId; }
            set { businessTypeId = value; }
        }
        //客户ID
        private long customerId;
        public long CustomerId
        {
            get { return customerId; }
            set { customerId = value; }
        }
        //会员卡ID
        private long memberCardId;
        public long MemberCardId
        {
            get { return memberCardId; }
            set { memberCardId = value; }
        }
        //行业ID
        private long tradeId;
        public long TradeId
        {
            get { return tradeId; }
            set { tradeId = value; }
        }
        //会员卡级别ID
        private long memberCardLevelId;
        public long MemberCardLevelId
        {
            get { return memberCardLevelId; }
            set { memberCardLevelId = value; }
        }
        #endregion


        //每个页面显示的行数
        private short everyPageRows;
        public short EveryPageRows
        {
            get
            {
                return everyPageRows;
            }
            set
            {
                everyPageRows = value;
            }
        }

        //当前的页面数
        private long currentPageID;
        public long CurrentPageID
        {
            get
            {
                return currentPageID;
            }
            set
            {
                currentPageID = value;
            }
        }

        #region 换分页后使用新的方法

        private int beginRow;
        /// <summary>
        /// 开始行
        /// </summary>
        public int BeginRow
        {
            get { return beginRow; }
            set { beginRow = value; }

        }

        private int endRow;
        /// <summary>
        /// 结束行
        /// </summary>
        public int EndRow
        {
            get { return endRow; }
            set { endRow = value; }
        }

        #endregion

        private IList<MemberCardLevel> memberCardLevelList;
        public IList<MemberCardLevel> MemberCardLevelList
        {
            set { memberCardLevelList = value; }
            get { return memberCardLevelList; }
        }

        private Concession concession;
        public Concession Concession
        {
            set { concession = value; }
            get { return concession; }
        }
        private List<LabelValue> strPriceFactorList;
        public List<LabelValue> StrPriceFactorList 
        {
            set { strPriceFactorList = value; }
            get { return strPriceFactorList; }
        }
    }

    /// <summary>
    /// 存储一条确定的业务类型(包含业务类型下的因素)
    /// </summary>
    public class BusinessTypeFactorRelation 
    {
        private long businessTypeId;
        public long BusinessTypeId 
        {
            set { businessTypeId = value; }
            get { return businessTypeId; }
        }

        private long processContentId;
        public long ProcessContentId 
        {
            set { processContentId = value; }
            get { return processContentId; }
        }

        private long machineTypeId;
        public long MachineTypeId 
        {
            set { machineTypeId = value; }
            get { return machineTypeId; }
        }

        private long paperTypeId;
        public long PaperTypeId 
        {
            set { paperTypeId = value; }
            get { return paperTypeId; }
        }

        private long paperSecId;
        public long PaperSecId 
        {
            set { paperSecId = value; }
            get { return paperSecId; }
        }

        private long memberId;
        public long MemberId 
        {
            set { memberId = value; }
            get { return memberId; }
        }

        private long amountId;
        public long AmountId 
        {
            set { amountId = value; }
            get { return amountId; }
        }
        private List<string> strElementList=new List<string>();
        public List<string> StrElementList 
        {
            set { strElementList = value; }
            get { return strElementList; }
        }

        private List<long> intElementIdList = new List<long>();
        public List<long> IntElementIdList 
        {
            set { intElementIdList = value; }
            get { return intElementIdList; }
        }
    }
}
