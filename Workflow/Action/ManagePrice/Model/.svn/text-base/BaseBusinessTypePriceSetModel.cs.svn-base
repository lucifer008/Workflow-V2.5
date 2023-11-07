using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Action.Model;

namespace Workflow.Action.Model
{
    public class BaseBusinessTypePriceSetModel
    {
        //门市价格设置
        private BaseBusinessTypePriceSet baseBusinessTypePriceSet;
        public BaseBusinessTypePriceSet BaseBusinessTypePriceSet
        {   
            get { return baseBusinessTypePriceSet; }
            set { baseBusinessTypePriceSet = value; }
        }

        //门市价格设置一览
        private IList<BaseBusinessTypePriceSet> baseBusinessTypePriceSetList;
        public IList<BaseBusinessTypePriceSet> BaseBusinessTypePriceSetList
        {
            get { return baseBusinessTypePriceSetList; }
            set { baseBusinessTypePriceSetList = value;}

        }

        private IList<PriceFactor> priceFactor;
        /// <summary>
        /// 因素一览
        /// </summary>
        public IList<PriceFactor> PriceFactor
        {
            get { return priceFactor; }
            set { priceFactor = value; }
        }

        //因素之间的关系
        private FactorRelation factorrelation;
        public FactorRelation Factorrelation
        {
            get { return factorrelation; }
            set { factorrelation = value; }
        }


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

        private IList<string> strBaseBusinessTypePriceList=new List<string>();
        public IList<string> StrBaseBusinessTypePriceList 
        {
            set { strBaseBusinessTypePriceList = value; }
            get { return strBaseBusinessTypePriceList; }
        }
        #region Modify:Cry,Date:2009-1-9

        #region 当前业务类型影响价格的因素的数量

        private long selectBusinessType;
        /// <summary>
        /// 当前选择的业务
        /// </summary>
        public long SelectBusinessType
        {
            get { return selectBusinessType; }
            set { selectBusinessType = value; }
        }

        private int priceFactorCount;
        /// <summary>
        /// 当前业务类型影响价格的因素的数量
        /// </summary>
        public int PriceFactorCount
        {
            get { return priceFactorCount; }
            set { priceFactorCount=value; }
        }
        #endregion

        private IList<BusinessType> businessTypeList;
        /// <summary>
        /// 业务类型一览
        /// </summary>
        public IList<BusinessType> BusinessTypeList
        {
            get { return businessTypeList; }
            set { businessTypeList = value; }
        }

        private IList<PriceFactor> priceFactorList;
        /// <summary>
        /// 当前使用价格因素
        /// </summary>
        public IList<PriceFactor> PriceFactorList
        {
            get { return priceFactorList; }
            set { priceFactorList = value; }
        }
        #endregion
    }
}
