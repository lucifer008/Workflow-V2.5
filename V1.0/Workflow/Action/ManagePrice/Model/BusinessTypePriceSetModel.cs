using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Service;
using Workflow.Da.Domain;

namespace Workflow.Action.Model
{
    public class BusinessTypePriceSetModel
    {

        //业务类型
        //会员卡价格设置一览页面中作为查询条件使用
        private IList<BusinessType> businessTypeList;
        public IList<BusinessType> BusinessTypeList
        {
            get { return businessTypeList;  }
            set { businessTypeList = value; }
        }

        //卡级别
        //会员卡价格设置一览页面中作为查询条件使用
        private IList<MemberCardLevel> memberCardLevelList;
        public IList<MemberCardLevel> MemberCardLevelList
        {
            get { return memberCardLevelList;  }
            set { memberCardLevelList = value; }
        }

        //行业一览
        //行业价格设置页面,作为查询条件的时候作为输入参数
        private IList<MasterTrade> masterTrade;
        public IList<MasterTrade> MasterTrade
        {
            get { return masterTrade; }
            set { masterTrade = value; }
        }

        //业务价格
        //查询时候,作为查询条件的输入参数
        private BusinessTypePriceSet businessTypePriceSet;
        public BusinessTypePriceSet BusinessTypePriceSet
        {
            get { return businessTypePriceSet;  }
            set { businessTypePriceSet = value; }
        }

        //因素之间的关系
        //价格追加,编辑的时候显示不同业务下的因素以及因素的值
        private FactorRelation factorrelation;
        public FactorRelation Factorrelation
        {
            get { return factorrelation; }
            set { factorrelation = value; }
        }

        //因素一览
        //显示价格一览的时候,动态显示列名文字
        private IList<PriceFactor> priceFactor;
        public IList<PriceFactor> PriceFactor
        {
            get { return priceFactor; }
            set { priceFactor = value; }
        }
        
        //门市价格一览
        private IList<BaseBusinessTypePriceSet> baseBusinessTypePriceSetList;
        public IList<BaseBusinessTypePriceSet> BaseBusinessTypePriceSetList
        {
            get { return baseBusinessTypePriceSetList;  }
            set { baseBusinessTypePriceSetList = value; }
        }

        //业务价格一览
        private IList<BusinessTypePriceSet> businessTypePriceSetList;
        public IList<BusinessTypePriceSet> BusinessTypePriceSetList
        {
            get { return businessTypePriceSetList;  }
            set { businessTypePriceSetList = value; }
        }

        //会员卡一览
        private IList<MemberCard> memberCardList;
        public IList<MemberCard> MemberCardList
        {
            get { return memberCardList;    }
            set { memberCardList=value;     }
        }
        
    }
}
