#region imports
using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
#endregion

namespace Workflow.Da
{
	/// <summary>
	/// Table MARKING_SETTING (积分设置)对应的Dao 接口
	/// </summary>
	public interface IMarkingSettingDao : IDaoBase<MarkingSetting>
	{
        #region//会员积分设置
        /// <summary>
        /// 名   称:  SearchMarking
        /// 功能概要: 获取积分列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年10月28日11:32:18
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        IList<MarkingSetting> SearchMarkingSetting(MarkingSetting markingSetting);

        /// <summary>
        /// 名   称:  SearchMarkingSettingRowCount
        /// 功能概要: 获取积分列表记录数
        /// 作    者: 张晓林
        /// 创建时间: 2009年10月28日11:32:18
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        long SearchMarkingSettingRowCount(MarkingSetting markingSetting);

        /// <summary>
        /// 名    称：CheckMarkingSettingIsExist
        /// 功能概要：检加工内容积分是否存在
        /// 作    者: 张晓林
        /// 创建时间: 2009年10月28日16:57:01
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        bool CheckMarkingSettingIsExist(MarkingSetting markingSetting); 

        /// <summary>
        /// 名   称:  GetAllMarkingSettingList
        /// 功能概要: 获取所有积分列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年10月29日13:29:39
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        IList<MarkingSetting> GetAllMarkingSettingList();


        /// <summary>
        /// 名   称:  根据订单Id获取会员消费的订单明细
        /// 功能概要: 获取所有积分列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年10月29日13:29:39
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        IList<Order> GetOrderItemList(Order order);
        #endregion
	}
}