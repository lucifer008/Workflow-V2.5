using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Action.Model
{
   public class PriceModel
    {
        /// <summary>
        ///价格因素
        /// </summary>
        private IList<PriceFactor> priceFactor;
        public IList<PriceFactor> PriceFactor
        {
            get { return priceFactor;   }
            set { priceFactor = value;  }
        }
       
        /// <summary>
        ///业务类型包含的因素
        /// </summary>
       private IList<BusinessTypePriceFactor> businessTypePriceFactor;
       public IList<BusinessTypePriceFactor> BusinessTypePriceFactor
       {
            get {return businessTypePriceFactor;    }
            set { businessTypePriceFactor = value;  }
       }

       //public void AddBusinessTypePriceFactor()
       //{
       //    businessTypePriceFactor.Add(new BusinessTypePriceFactor());
       //}

        /// <summary>
        ///业务类型<主要用作输入>
        /// </summary>
       private BusinessType businessType;
       public BusinessType BusinessType
       {
           get { return businessType;   }
           set { businessType = value;  }
       }

       /// <summary>
       ///业务类型一览
       /// </summary>
       
       private IList<BusinessType> businessTypeList;
       public IList<BusinessType> BusinessTypeList
       {
           get { return businessTypeList;   }
           set { businessTypeList = value;  }
       }

       /// <summary>
       ///业务类型一览(主要用作输出)
       /// </summary>
       private IList<BusinessType> businessTypeMaster;
       public IList<BusinessType> BusinessTypeMaster
       {
           get { return businessTypeMaster;     }
           set { businessTypeMaster = value;    }
       }
    }
}
