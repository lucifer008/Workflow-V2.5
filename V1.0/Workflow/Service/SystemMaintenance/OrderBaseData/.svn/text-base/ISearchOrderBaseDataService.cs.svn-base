using System;
using System.Collections.Generic;
using Workflow.Da.Domain;

namespace Workflow.Service.SystemMaintenance.OrderBaseData
{
    /// <summary>
    /// 名    称: ISearchOrderBaseDataService
    /// 功能概要: 获取工单基础数据接口
    /// 作    者: 张晓林
    /// 创建时间: 2009年4月29日17:22:33
    /// 修 正 人: 
    /// 修正时间: 
    /// 修正描述: 
    /// </summary>
    public interface ISearchOrderBaseDataService
    {
        #region//客户级别
        /// <summary>
        /// 名   称:  SearchCustomerLevel
        /// 功能概要: 获取客户级别列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月19日10:04:46
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        IList<CustomerLevel> SearchCustomerLevel(CustomerLevel customerLevel); 

        /// <summary>
        /// 名   称:  SearchCustomerLevelRowCount
        /// 功能概要: 获取客户级别列表个数
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月19日10:04:46
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        long SearchCustomerLevelRowCount(CustomerLevel customerLevel);

        /// <summary>
        /// 名   称:  CheckCustomerLevelIsUse
        /// 功能概要: 检查客户级别是否正在使用
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月19日11:35:34
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        long CheckCustomerLevelIsUse(long customerLevelId);
        #endregion

        #region//客户类型

        /// <summary>
        /// 名   称:  SearchCustomerType
        /// 功能概要: 获取客户类型列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月19日10:04:46
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        IList<CustomerType> SearchCustomerType(CustomerType customerType);

        /// <summary>
        /// 名   称:  SearchCustomerTypeRowCount
        /// 功能概要: 获取客户类型列表个数
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月19日10:04:46
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        long SearchCustomerTypeRowCount(CustomerType customerType);

        /// <summary>
        /// 名   称:  CheckCustomerTypeIsUse
        /// 功能概要: 检查客户类型是否正在使用
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月19日11:35:34
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        long CheckCustomerTypeIsUse(long customerTypeId);
        #endregion

        #region//客户行业及子行业
        /// <summary>
        /// 名   称:  SearchMasterTrade
        /// 功能概要: 获取客主行业列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月20日10:20:39
        /// 修正履历:
        /// 修正时间:
        /// </summary>
       IList<MasterTrade> SearchMasterTrade(MasterTrade masterTrade);

       /// <summary>
       /// 名   称:  SearchMasterTradeRowCount
       /// 功能概要: 获取客主行业列表个数
       /// 作    者: 张晓林
       /// 创建时间: 2009年5月20日10:20:39
       /// 修正履历:
       /// 修正时间:
       /// </summary>
       long SearchMasterTradeRowCount(MasterTrade masterTrade);

       /// <summary>
       /// 名   称:  SearchMasterTrade
       /// 功能概要: 获取客户子行业列表
       /// 作    者: 张晓林
       /// 创建时间: 2009年5月20日10:20:39
       /// 修正履历:
       /// 修正时间:
       /// </summary>
       IList<SecondaryTrade> SearchSecondaryTrade(SecondaryTrade secondaryTrade);

       /// <summary>
       /// 名   称:  SearchMasterTradeRowCount
       /// 功能概要: 获取客户子行业列表个数
       /// 作    者: 张晓林
       /// 创建时间: 2009年5月20日10:20:39
       /// 修正履历:
       /// 修正时间:
       /// </summary>
       long SearchSecondaryTradeRowCount(SecondaryTrade secondaryTrade);

       /// <summary>
       /// 名   称:  CheckMasterTradeIsUse
       /// 功能概要: 检查客户客户主行业是否正在使用
       /// 作    者: 张晓林
       /// 创建时间: 2009年5月20日11:48:22
       /// 修正履历:
       /// 修正时间:
       /// </summary>
       long CheckMasterTradeIsUse(long masterTradeId);

         /// <summary>
        /// 名   称:  GetAllMasterTrade
        /// 功能概要: 获取所有主行业列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月22日9:51:12
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        IList<MasterTrade> GetAllMasterTrade(); 
        #endregion

        #region//会员卡级别
        /// <summary>
        /// 名   称:  SearchMemberCardLevel
        /// 功能概要: 获取会员卡级别列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月23日10:52:43
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        IList<MemberCardLevel> SearchMemberCardLevel(MemberCardLevel memberCardLevel);

        /// <summary>
        /// 名   称:  SearchMemberCardLevelRowCount
        /// 功能概要: 获取会员卡级别列表个数
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月23日10:52:43
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        long SearchMemberCardLevelRowCount(MemberCardLevel memberCardLevel);

        /// <summary>
        /// 名   称:  CheckMemberCardLevelIsUse
        /// 功能概要: 检查会员卡级别是否正在使用
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月23日10:58:02
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        long CheckMemberCardLevelIsUse(long memberCardLevelId);
        #endregion

        #region//印制要求及明细
        /// <summary>
        /// 名   称:  SearchPrintDemand
        /// 功能概要: 获取印制要求列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月26日11:49:00
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        IList<PrintDemand> SearchPrintDemand(PrintDemand printDemand);

        /// <summary>
        /// 名   称:  SearchPrintDemandRowCount
        /// 功能概要: 获取印制要求列表数目
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月26日11:49:00
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        long SearchPrintDemandRowCount(PrintDemand printDemand);

         /// <summary>
        /// 名   称:  SearchPrintDemandDetail
        /// 功能概要: 获取印制要求明细列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月26日11:49:00
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        IList<PrintDemandDetail> SearchPrintDemandDetail(PrintDemandDetail printDemandDetail);

        /// <summary>
        /// 名   称:  SearchPrintDemandDetailRowCount
        /// 功能概要: 获取印制要求明细列表数目
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月26日11:49:00
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        long SearchPrintDemandDetailRowCount(PrintDemandDetail printDemandDetail);

         /// <summary>
        /// 名   称:  GetAllPrintDemand
        /// 功能概要: 获取所有印制要求列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月26日17:47:10
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        IList<PrintDemand> GetAllPrintDemand();

        /// <summary>
        /// 名   称:  CheckPrintDemandIsUse
        /// 功能概要: 检查印制要求是否正在使用
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月26日17:49:14
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        long CheckPrintDemandIsUse(long printDemandId);
         #endregion


        #region//挂失方式
        /// <summary>
        /// 名   称:  SearchReportLessMode
        /// 功能概要: 获取挂失方式列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月27日10:29:05
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        IList<ReportLessMode> SearchReportLessMode(ReportLessMode reportLessMode);

        /// <summary>
        /// 名   称:  SearchReportLessModeRowCount
        /// 功能概要: 获取挂失方式列表个数
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月27日10:29:05
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        long SearchReportLessModeRowCount(ReportLessMode reportLessMode);

         /// <summary>
        /// 名   称:  CheckReportLessModeIsUse
        /// 功能概要: 检查挂失方式是否正在使用
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月27日10:36:51
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        long CheckReportLessModeIsUse(long reportLessModeId); 
        #endregion

        #region//废张原因
        /// <summary>
        /// 名   称:  SearchTrashReason
        /// 功能概要: 获取废张原因列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月2日10:29:05
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        IList<TrashReason> SearchTrashReason(TrashReason trashReason);

        /// <summary>
        /// 名   称:  SearchTrashReasonRowCount
        /// 功能概要: 获取废张原因列表记录数
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月2日10:29:05
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        long SearchTrashReasonRowCount(TrashReason trashReason);

        /// <summary>
        /// 名   称:  CheckTrashReasonIsUse
        /// 功能概要: 检查废张原因是否正在使用
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月2日10:29:05
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        long CheckTrashReasonIsUse(long trashReasonId); 
        #endregion

        #region//加工内容业绩比例
        /// <summary>
        /// 名    称: GetAllProcessContent
        /// 功能概要: 获取所有加工内容
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月2日
        /// 修正时间:
        /// </summary>
        IList<ProcessContent> GetAllProcessContent(); 

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
        #endregion
    }
}
