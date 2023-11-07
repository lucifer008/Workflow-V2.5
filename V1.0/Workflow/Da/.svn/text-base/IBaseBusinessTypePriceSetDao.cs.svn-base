using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using System.Collections;

namespace Workflow.Da
{
	/// <summary>
	/// Table BASE_BUSINESS_TYPE_PRICE_SET 对应的Dao 接口
	/// </summary>
    public interface IBaseBusinessTypePriceSetDao : IDaoBase<BaseBusinessTypePriceSet>
    {
        IList<BaseBusinessTypePriceSet> GetBaseBusinessTypePriceSetListCustomQuery(BaseBusinessTypePriceSet baseBusinessTypePriceSet);
        /// <summary>
        /// 增加分页功能的GetBaseBusinessTypePriceSetListCustomQuery
        /// </summary>
        /// <param name="baseBusinessTypePriceSet"></param>
        /// <returns></returns>
        /// <remarks>
        /// 2008-11-08
        /// </remarks>
        IList<BaseBusinessTypePriceSet> GetBaseBusinessTypePriceSetListCustomQuery_Page(BaseBusinessTypePriceSet baseBusinessTypePriceSet);

        int GetBaseBusinessTypePriceSetListCustomQueryCount(BaseBusinessTypePriceSet baseBusinessTypePriceSet);

        BaseBusinessTypePriceSet GetTheLowerestPrice(BaseBusinessTypePriceSet baseBusinessTypePriceSet);

        /// <summary>
        /// 方法名称: GetBaseBusinessTypePriceSetDao
        /// 功能概要: 修改门市价格设置的分页
        /// 作    者: 陈汝胤
        /// 创建时间: 2008-1-9
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        IList<BaseBusinessTypePriceSet> GetBaseBusinessTypePriceSetDao(BaseBusinessTypePriceSet baseBusinessTypePriceSet);

           /// <summary>
        /// 方法名称: SearchBaseBuinessTypeSetInfo
        /// 功能概要: 获得门市价格设置一览(分页)
        /// 作    者: 张晓林
        /// 创建时间: 2009年3月5日13:40:53
        /// 修正履历: 
        /// 修正时间:
        /// </summary>
        /// <param name="baseBusinessTypePriceSet"></param>
        /// <returns></returns>
        IList<BaseBusinessTypePriceSet> SearchBaseBuinessTypeSetInfo(BaseBusinessTypePriceSet baseBusinessTypePriceSet);

        /// <summary>
        /// 方法名称: SearchBaseBuinessTypeSetInfoRowCount
        /// 功能概要: 获得门市价格设置记录数
        /// 作    者: 张晓林
        /// 创建时间: 2009年3月5日13:40:53
        /// 修正履历: 
        /// 修正时间:
        /// </summary>
        /// <param name="baseBusinessTypePriceSet"></param>
        /// <returns></returns>
        long SearchBaseBuinessTypeSetInfoRowCount(BaseBusinessTypePriceSet baseBusinessTypePriceSet);

        /// <summary>
        /// 获取会员卡消费的业务类型明细
        /// </summary>
        /// <param name="memberCardId"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者:张晓林 
        /// 创建时间: 2009年4月16日10:44:31
        /// 修正履历:
        /// 修正时间:
        /// 描    述:
        /// </remarks>
        IList<Order> GetMemberCardBaseBusItem(MemberCard memberCard);
    }
}
