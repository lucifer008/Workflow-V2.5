#region imports
using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
#endregion

namespace Workflow.Da
{
	/// <summary>
	/// Table PROCESS_CONTENT_ACHIEVEMENT_RATE (加工内容业绩比例)对应的Dao 接口
	/// </summary>
	public interface IProcessContentAchievementRateDao : IDaoBase<ProcessContentAchievementRate>
	{
        /// <summary>
        /// 名    称: SearchProcessContentAchievementValue
        /// 功能概要: 获取加工内容业绩比例列表 
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月2日
        /// 修正时间:
        /// </summary>
        IList<ProcessContentAchievementRate> SearchProcessContentAchievementValue(ProcessContentAchievementRate processContentAchievementRate);

        /// <summary>
        /// 名    称: SearchProcessContentAchievementValueRowCount
        /// 功能概要: 获取加工内容业绩比例列表记录数 
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月2日
        /// 修正时间:
        /// </summary>
        long SearchProcessContentAchievementValueRowCount(ProcessContentAchievementRate processContentAchievementRate);

        /// <summary>
        /// 名    称:GetProcessContentAchievementRate
        /// 功能概要:获取加工内容的业绩
        /// 作    者:张晓林
        /// 创建时间:2009年6月5日11:52:04
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        ProcessContentAchievementRate GetProcessContentAchievementRate(long processContentId);
        
        /// <summary>
        /// 名    称:UpdateProcessContentAchievementRate
        /// 功能概要:修改加工内容的业绩比例
        /// 作    者:张晓林
        /// 创建时间:2009年6月5日11:52:04
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        void UpdateProcessContentAchievementRate(ProcessContentAchievementRate processContentAchievementRate);
	}
}