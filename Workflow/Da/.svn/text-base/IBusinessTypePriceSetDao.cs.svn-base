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
        /// 方法名称: GetBusinessTypePriceSetListCustomQueryCount
        /// 功能概要: 获得业务价格总数
        /// 作    者: 付强
        /// 创建时间: 2010-3-1
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="businessTypePriceSet);"></param>
        /// <returns></returns>
        long GetBusinessTypePriceSetListCustomQueryCount(BusinessTypePriceSet businessTypePriceSet);

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
		/// 经过设置会员或者行业价格,都按条件指定条件查出来. (不分页)
		/// </summary>
		/// <param name="businessTypePriceSet"></param>
		/// <returns></returns>
		IList<BusinessTypePriceSet> GetOnlyBusinessTypePriceSetList(BusinessTypePriceSet businessTypePriceSet);

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

        #region//删除会员价格
        /// <summary>
        /// 方法名称: DeleteMembercardPrice
        /// 功能概要: 删除会员价格
        /// 作    者: 张晓林
        /// 创建时间: 2010年1月30日10:10:40
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        void DeleteMembercardPrice(BusinessTypePriceSet businessTypePriceSet);
        #endregion

        #region//编辑会员价格
        /// <summary>
        /// 方法名称: UpdateMembercardPrice
        /// 功能概要: 编辑会员价格
        /// 作    者: 张晓林
        /// 创建时间: 2010年1月30日15:39:54
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        void UpdateMembercardPrice(BusinessTypePriceSet businessTypePriceSet);
        #endregion

		#region 修改会员卡价格

		/// <summary>
		/// 修改会员卡价格
		/// </summary>
		/// <param name="val"></param>
		void UpdateBusinessTypePrice(BusinessTypePriceSet val);

		#endregion

		
	}
}
