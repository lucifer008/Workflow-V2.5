using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;
using Workflow.Support;
namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table PROCESS_CONTENT 对应的Dao 实现
	/// </summary>
    public class ProcessContentDaoImpl : Workflow.Da.Base.DaoBaseImpl<ProcessContent>, IProcessContentDao
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
        public string GetProcessContentById(long Id)
        {
            return sqlMap.QueryForObject("ProcessContent.SelectColorTypeById", Id).ToString();
        }

        #region IProcessContentDao 成员

        /// 通过订单明细id获取订单的明细的加工内容
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 陈汝胤
        /// 创建时间: 2009-1-6
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public string GetProcessContentByOrderItemId(long orderItemId)
        {
            ProcessContent processContent = new ProcessContent();
            processContent.Id = orderItemId;
            processContent.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            processContent.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForObject<string>("ProcessContent.GetProcessContentByOrderItemId", processContent);
        }

        #endregion

        /// <summary>
        /// 名    称：GetProcessContentList
        /// 功能概要: 获取加工内容列表
        /// 作    者：张晓林
        /// 创建时间: 2009年4月30日9:45:47
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public IList<ProcessContent> GetProcessContentList(ProcessContent processContent) 
        {
            processContent.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            processContent.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<ProcessContent>("ProcessContent.GetProcessContentList", processContent);
        }

        /// <summary>
        /// 名    称：GetProcessContentListRowCount
        /// 功能概要: 获取加工内容列表记录数
        /// 作    者：张晓林
        /// 创建时间: 2009年4月30日9:45:47
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public long GetProcessContentListRowCount(ProcessContent processContent) 
        {
            return sqlMap.QueryForObject<long>("ProcessContent.GetProcessContentListRowCount", processContent);
        }

        /// <summary>
        /// 名    称：DeleteLogicProcessContent
        /// 功能概要: 逻辑删除加工内容
        /// 作    者：张晓林
        /// 创建时间: 2009年4月30日13:25:57
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void DeleteLogicProcessContent(long processContentId) 
        {
            sqlMap.Update("ProcessContent.DeleteLogicProcessContent", processContentId);
        }

        /// <summary>
        /// 名    称：UpdateProcessContent
        /// 功能概要: 更新加工内容
        /// 作    者：张晓林
        /// 创建时间: 2009年4月30日14:49:07
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void UpdateProcessContent(ProcessContent processContent) 
        {
            processContent.UpdateDateTime = System.DateTime.Now;
            processContent.UpdateUser = ThreadLocalUtils.CurrentUserContext.CurrentUser.Id;
            sqlMap.Update("ProcessContent.UpdateProcessContent",processContent);
        }

        /// <summary>
        /// 名    称：CheckProcessContentIsUse
        /// 功能概要: 检查加工内容是否正在使用
        /// 作    者：张晓林
        /// 创建时间: 2009年5月15日17:29:45
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public long CheckProcessContentIsUse(long processContentId) 
        {
            ProcessContent processContent = new ProcessContent();
            processContent.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            processContent.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            processContent.Id = processContentId;
            return sqlMap.QueryForObject<long>("ProcessContent.CheckProcessContentIsUse", processContent);
        }

        /// <summary>
        /// 名    称: GetAllProcessContent
        /// 功能概要: 获取所有加工内容
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月2日
        /// 修正时间:
        /// </summary>
        public IList<ProcessContent> GetAllProcessContent() 
        {
            ProcessContent processContent = new ProcessContent();
            processContent.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            processContent.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<ProcessContent>("ProcessContent.GetAllProcessContent", processContent);
        }

        /// <summary>
        /// 获取当前订单明细的加工类型的前期业绩比列
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2010年5月11日16:23:51
        /// </remarks>
        public decimal GetProcessContentAchievementRate(long orderItemId) 
        {
            ProcessContent processContent = new ProcessContent();
            processContent.Id = orderItemId;
            processContent.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            processContent.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForObject<decimal>("ProcessContent.GetProcessContentAchievementRate", processContent);
        }

    }
}
