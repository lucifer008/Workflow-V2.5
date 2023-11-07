using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table PROCESS_CONTENT 对应的Dao 接口
	/// </summary>
    public interface IProcessContentDao : IDaoBase<ProcessContent>
    {
        /// 通过ID查找加工内容的颜色
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-24
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        string GetProcessContentById(long Id);

        /// 通过订单明细id获取订单的明细的加工内容
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 陈汝胤
        /// 创建时间: 2009-1-6
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        string GetProcessContentByOrderItemId(long orderItemId);

        /// <summary>
        /// 名    称：GetProcessContentList
        /// 功能概要: 获取加工内容列表
        /// 作    者：张晓林
        /// 创建时间: 2009年4月30日9:45:47
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        IList<ProcessContent> GetProcessContentList(ProcessContent processContent);

        /// <summary>
        /// 名    称：GetProcessContentListRowCount
        /// 功能概要: 获取加工内容列表记录数
        /// 作    者：张晓林
        /// 创建时间: 2009年4月30日9:45:47
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        long GetProcessContentListRowCount(ProcessContent processContent);


        /// <summary>
        /// 名    称：CheckProcessContentIsUse
        /// 功能概要: 检查加工内容是否正在使用
        /// 作    者：张晓林
        /// 创建时间: 2009年5月15日17:29:45
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        long CheckProcessContentIsUse(long processContentId);

         /// <summary>
        /// 名    称：DeleteLogicProcessContent
        /// 功能概要: 逻辑删除加工内容
        /// 作    者：张晓林
        /// 创建时间: 2009年4月30日13:25:57
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        void DeleteLogicProcessContent(long processContentId);

        /// <summary>
        /// 名    称：UpdateProcessContent
        /// 功能概要: 更新加工内容
        /// 作    者：张晓林
        /// 创建时间: 2009年4月30日14:49:07
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        void UpdateProcessContent(ProcessContent processContent);

        /// <summary>
        /// 名    称: GetAllProcessContent
        /// 功能概要: 获取所有加工内容
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月2日
        /// 修正时间:
        /// </summary>
        IList<ProcessContent> GetAllProcessContent();

        /// <summary>
        /// 获取当前订单明细的加工类型的前期业绩比列
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2010年5月11日16:23:51
        /// </remarks>
        decimal GetProcessContentAchievementRate(long orderItemId);

    }
}
