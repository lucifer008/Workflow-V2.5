using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table BUSINESS_TYPE_PRICE_SET 对应的Dao 接口
	/// </summary>
    public interface IBusinessTypePriceSetDao : IDaoBase<BusinessTypePriceSet>
    {
        IList<BusinessTypePriceSet> GetBusinessTypePriceSetListCustomQuery(BusinessTypePriceSet businessTypePriceSet);
        /// <summary>
        /// 不论有没有设置会员或者行业价格,都按条件指定条件查出来. 
        /// </summary>
        /// <param name="businessTypePriceSet"></param>
        /// <returns></returns>
        IList<BusinessTypePriceSet> GetAllBusinessTypePriceSetListCustomQuery(BusinessTypePriceSet businessTypePriceSet);
        /// <summary>
        /// 经过设置会员或者行业价格,都按条件指定条件查出来. 
        /// </summary>
        /// <param name="businessTypePriceSet"></param>
        /// <returns></returns>
        IList<BusinessTypePriceSet> GetOnlyBusinessTypePriceSetListCustomQuery(BusinessTypePriceSet businessTypePriceSet);
        /// <summary>
        /// 获取BusinessTypePriceSet对应的会员卡级别或者行业名称
        /// </summary>
        /// <param name="bizPriceSet"></param>
        string GetTargetName(BusinessTypePriceSet bizPriceSet);

        /// <summary>
        /// 不论有没有设置会员或者行业价格,都按条件指定条件查出来.取行数
        /// </summary>
        /// <param name="businessTypePriceSet"></param>
        /// <returns></returns>
        long GetAllBusinessTypePriceSetListCustomQueryCount(BusinessTypePriceSet businessTypePriceSet);
        /// <summary>
        /// 经过设置会员或者行业价格的行数
        /// </summary>
        /// <param name="businessTypePriceSet"></param>
        /// <returns></returns>
        long GetOnlyBusinessTypePriceSetListCustomQueryCount(BusinessTypePriceSet businessTypePriceSet);


        BusinessTypePriceSet GetPrice(BusinessTypePriceSet businessTypePriceSet);
    }
}
