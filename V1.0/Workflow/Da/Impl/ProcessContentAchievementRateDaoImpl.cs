#region imports
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;
#endregion

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table PROCESS_CONTENT_ACHIEVEMENT_RATE (加工内容业绩比例) 对应的Dao 实现
	/// </summary>
    public class ProcessContentAchievementRateDaoImpl : Workflow.Da.Base.DaoBaseImpl<ProcessContentAchievementRate>, IProcessContentAchievementRateDao
    {
        /// <summary>
        /// 名    称: SearchProcessContentAchievementValue
        /// 功能概要: 获取加工内容业绩比例列表 
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月2日
        /// 修正时间:
        /// </summary>
        public IList<ProcessContentAchievementRate> SearchProcessContentAchievementValue(ProcessContentAchievementRate processContentAchievementRate) 
        {
            processContentAchievementRate.Memo = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId.ToString();
            processContentAchievementRate.ProcessContentName = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId.ToString();
            return sqlMap.QueryForList<ProcessContentAchievementRate>("ProcessContentAchievementRate.SearchProcessContentAchievementValue", processContentAchievementRate);
        }

        /// <summary>
        /// 名    称: SearchProcessContentAchievementValueRowCount
        /// 功能概要: 获取加工内容业绩比例列表记录数 
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月2日
        /// 修正时间:
        /// </summary>
        public long SearchProcessContentAchievementValueRowCount(ProcessContentAchievementRate processContentAchievementRate) 
        {
            return sqlMap.QueryForObject<long>("ProcessContentAchievementRate.SearchProcessContentAchievementValueRowCount", processContentAchievementRate);
        }

        /// <summary>
        /// 名    称:GetProcessContentAchievementRate
        /// 功能概要:获取加工内容的业绩比例
        /// 作    者:张晓林
        /// 创建时间:2009年6月5日11:52:04
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public ProcessContentAchievementRate GetProcessContentAchievementRate(long processContentId) 
        {
            ProcessContent processContent = new ProcessContent();
            processContent.CompanyId= Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            processContent.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            processContent.Id = processContentId;
            return sqlMap.QueryForObject<ProcessContentAchievementRate>("ProcessContent.ProcessContentAchievementRate", processContent);
        }

        /// <summary>
        /// 名    称:UpdateProcessContentAchievementRate
        /// 功能概要:修改加工内容的业绩比例
        /// 作    者:张晓林
        /// 创建时间:2009年6月5日11:52:04
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void UpdateProcessContentAchievementRate(ProcessContentAchievementRate processContentAchievementRate) 
        {
            Hashtable condition = new Hashtable();
            condition.Add("Memo", processContentAchievementRate.Memo);
            condition.Add("AchievementValue", processContentAchievementRate.AchievementValue);
            condition.Add("ProcessContentId", processContentAchievementRate.ProcessContentId);
            condition.Add("CompanyId",Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            condition.Add("BranchShopId",Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            sqlMap.Update("ProcessContentAchievementRate.UpdateProcessContentAchievementRate", condition);
        }
    }
}