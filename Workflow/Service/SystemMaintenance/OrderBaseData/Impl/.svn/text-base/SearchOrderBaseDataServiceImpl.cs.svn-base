using System;
using System.Collections.Generic;
using Workflow.Da;
using Workflow.Da.Domain;
namespace Workflow.Service.SystemMaintenance.OrderBaseData.Impl
{
    /// <summary>
    /// 名    称: SearchOrderBaseDataServiceImpl
    /// 功能概要: 获取订单基础数据接口实现
    /// 作    者: 张晓林
    /// 创建时间: 2009年4月29日17:22:33
    /// 修 正 人: 
    /// 修正时间: 
    /// 修正描述: 
    /// </summary>
    public class SearchOrderBaseDataServiceImpl:ISearchOrderBaseDataService
    {
        #region//注入Dao
        private ICustomerLevelDao customerLevelDao;
        public ICustomerLevelDao CustomerLevelDao 
        {
            set { customerLevelDao = value; }
        }

        private ICustomerTypeDao customerTypeDao;
        public ICustomerTypeDao CustomerTypeDao 
        {
            set { customerTypeDao = value; }
        }

        private IMasterTradeDao masterTradeDao;
        public IMasterTradeDao MasterTradeDao
        {
            set { masterTradeDao = value; }
        }
        private ISecondaryTradeDao secondaryTradeDao;
        public ISecondaryTradeDao SecondaryTradeDao
        {
            set { secondaryTradeDao = value; }
        }

        private IMemberCardLevelDao memberCardLevelDao;
        public IMemberCardLevelDao MemberCardLevelDao
        {
            set { memberCardLevelDao = value; }
        }

        private IPrintDemandDao printDemandDao;
        public IPrintDemandDao PrintDemandDao 
        {
            set { printDemandDao = value; }
        }

        private IPrintDemandDetailDao printDemandDetailDao;
        public IPrintDemandDetailDao PrintDemandDetailDao
        {
            set { printDemandDetailDao = value; }
        }

        private IReportLessModeDao reportLessModeDao;
        public IReportLessModeDao ReportLessModeDao 
        {
            set { reportLessModeDao = value; }
        }

        private ITrashReasonDao trashReasonDao;
        public ITrashReasonDao TrashReasonDao
        {
            set { trashReasonDao = value; }
        }

        private IProcessContentDao processContentDao;
        public IProcessContentDao ProcessContentDao 
        {
            set { processContentDao = value; }
        }

        private IProcessContentAchievementRateDao processContentAchievementRateDao;
        public IProcessContentAchievementRateDao ProcessContentAchievementRateDao 
        {
            set { processContentAchievementRateDao = value; }
        }
        #endregion

        #region//客户级别
        /// <summary>
        /// 名   称:  SearchCustomerLevel
        /// 功能概要: 获取客户级别列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月19日10:04:46
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public IList<CustomerLevel> SearchCustomerLevel(CustomerLevel customerLevel) 
        {
            return customerLevelDao.SearchCustomerLevel(customerLevel);
        }

        /// <summary>
        /// 名   称:  SearchCustomerLevelRowCount
        /// 功能概要: 获取客户级别列表个数
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月19日10:04:46
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public long SearchCustomerLevelRowCount(CustomerLevel customerLevel) 
        {
            return customerLevelDao.SearchCustomerLevelRowCount(customerLevel);
        }

        /// <summary>
        /// 名   称:  CheckCustomerLevelIsUse
        /// 功能概要: 检查客户级别是否正在使用
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月19日11:35:34
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public long CheckCustomerLevelIsUse(long customerLevelId) 
        {
            return customerLevelDao.CheckCustomerLevelIsUse(customerLevelId);
        }
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
        public IList<CustomerType> SearchCustomerType(CustomerType customerType) 
        {
            return customerTypeDao.SearchCustomerType(customerType);
        }

        /// <summary>
        /// 名   称:  SearchCustomerTypeRowCount
        /// 功能概要: 获取客户类型列表个数
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月19日10:04:46
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public long SearchCustomerTypeRowCount(CustomerType customerType) 
        {
            return customerTypeDao.SearchCustomerTypeRowCount(customerType);
        }

        /// <summary>
        /// 名   称:  CheckCustomerTypeIsUse
        /// 功能概要: 检查客户类型是否正在使用
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月19日11:35:34
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public long CheckCustomerTypeIsUse(long customerTypeId) 
        {
            return customerTypeDao.CheckCustomerTypeIsUse(customerTypeId);
        }
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
        public IList<MasterTrade> SearchMasterTrade(MasterTrade masterTrade) 
        {
            return masterTradeDao.SearchMasterTrade(masterTrade);
        }

        /// <summary>
        /// 名   称:  SearchMasterTradeRowCount
        /// 功能概要: 获取客主行业列表个数
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月20日10:20:39
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public long SearchMasterTradeRowCount(MasterTrade masterTrade) 
        {
            return masterTradeDao.SearchMasterTradeRowCount(masterTrade);
        }

        /// <summary>
        /// 名   称:  SearchMasterTrade
        /// 功能概要: 获取客户子行业列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月20日10:20:39
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public IList<SecondaryTrade> SearchSecondaryTrade(SecondaryTrade secondaryTrade) 
        {
            return secondaryTradeDao.SearchSecondaryTrade(secondaryTrade);
        }

        /// <summary>
        /// 名   称:  SearchMasterTradeRowCount
        /// 功能概要: 获取客户子行业列表个数
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月20日10:20:39
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public long SearchSecondaryTradeRowCount(SecondaryTrade secondaryTrade) 
        {
            return secondaryTradeDao.SearchSecondaryTradeRowCount(secondaryTrade);
        }

        /// <summary>
        /// 名   称:  CheckMasterTradeIsUse
        /// 功能概要: 检查客户客户主行业是否正在使用
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月20日11:48:22
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public long CheckMasterTradeIsUse(long masterTradeId) 
        {
            return masterTradeDao.CheckMasterTradeIsUse(masterTradeId);
        }

        /// <summary>
        /// 名   称:  GetAllMasterTrade
        /// 功能概要: 获取所有主行业列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月22日9:51:12
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public IList<MasterTrade> GetAllMasterTrade() 
        {
            return masterTradeDao.SelectAll();
        }
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
        public IList<MemberCardLevel> SearchMemberCardLevel(MemberCardLevel memberCardLevel) 
        {
            return memberCardLevelDao.SearchMemberCardLevel(memberCardLevel);
        }

        /// <summary>
        /// 名   称:  SearchMemberCardLevelRowCount
        /// 功能概要: 获取会员卡级别列表个数
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月23日10:52:43
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public long SearchMemberCardLevelRowCount(MemberCardLevel memberCardLevel) 
        {
            return memberCardLevelDao.SearchMemberCardLevelRowCount(memberCardLevel);
        }

        /// <summary>
        /// 名   称:  CheckMemberCardLevelIsUse
        /// 功能概要: 检查会员卡级别是否正在使用
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月23日10:58:02
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public long CheckMemberCardLevelIsUse(long memberCardLevelId) 
        {
            return memberCardLevelDao.CheckMemberCardLevelIsUse(memberCardLevelId);
        }
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
        public IList<PrintDemand> SearchPrintDemand(PrintDemand printDemand) 
        {
            return printDemandDao.SearchPrintDemand(printDemand); ;
        }

        /// <summary>
        /// 名   称:  SearchPrintDemandRowCount
        /// 功能概要: 获取印制要求列表数目
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月26日11:49:00
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public long SearchPrintDemandRowCount(PrintDemand printDemand) 
        {
            return printDemandDao.SearchPrintDemandRowCount(printDemand);
        }

        /// <summary>
        /// 名   称:  SearchPrintDemandDetail
        /// 功能概要: 获取印制要求明细列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月26日11:49:00
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public IList<PrintDemandDetail> SearchPrintDemandDetail(PrintDemandDetail printDemandDetail) 
        {
            return printDemandDetailDao.SearchPrintDemandDetail(printDemandDetail);
        }

        /// <summary>
        /// 名   称:  SearchPrintDemandDetailRowCount
        /// 功能概要: 获取印制要求明细列表数目
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月26日11:49:00
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public long SearchPrintDemandDetailRowCount(PrintDemandDetail printDemandDetail) 
        {
            return printDemandDetailDao.SearchPrintDemandDetailRowCount(printDemandDetail);
        }

        /// <summary>
        /// 名   称:  GetAllPrintDemand
        /// 功能概要: 获取所有印制要求列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月26日17:47:10
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public IList<PrintDemand> GetAllPrintDemand() 
        {
           return printDemandDao.GetAllPrintDemand();
        }

        /// <summary>
        /// 名   称:  CheckPrintDemandIsUse
        /// 功能概要: 检查印制要求是否正在使用
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月26日17:49:14
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public long CheckPrintDemandIsUse(long printDemandId) 
        {
            return printDemandDao.CheckPrintDemandIsUse(printDemandId);
        }
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
        public IList<ReportLessMode> SearchReportLessMode(ReportLessMode reportLessMode) 
        {
            return reportLessModeDao.SearchReportLessMode(reportLessMode);
        }

        /// <summary>
        /// 名   称:  SearchReportLessModeRowCount
        /// 功能概要: 获取挂失方式列表个数
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月27日10:29:05
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public long SearchReportLessModeRowCount(ReportLessMode reportLessMode) 
        {
            return reportLessModeDao.SearchReportLessModeRowCount(reportLessMode);
        }


        /// <summary>
        /// 名   称:  CheckReportLessModeIsUse
        /// 功能概要: 检查挂失方式是否正在使用
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月27日10:36:51
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public long CheckReportLessModeIsUse(long reportLessModeId) 
        {
            return reportLessModeDao.CheckReportLessModeIsUse(reportLessModeId);
        }
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
        public IList<TrashReason> SearchTrashReason(TrashReason trashReason) 
        {
            return trashReasonDao.SearchTrashReason(trashReason);
        }

        /// <summary>
        /// 名   称:  SearchTrashReasonRowCount
        /// 功能概要: 获取废张原因列表记录数
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月2日10:29:05
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public long SearchTrashReasonRowCount(TrashReason trashReason) 
        {
            return trashReasonDao.SearchTrashReasonRowCount(trashReason);
        }

        /// <summary>
        /// 名   称:  CheckTrashReasonIsUse
        /// 功能概要: 检查废张原因是否正在使用
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月2日10:29:05
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public long CheckTrashReasonIsUse(long trashReasonId) 
        {
            return trashReasonDao.CheckTrashReasonIsUse(trashReasonId);
        }

        #endregion

        #region//加工内容业绩比例
        /// <summary>
        /// 名    称: GetAllProcessContent
        /// 功能概要: 获取所有加工内容
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月2日
        /// 修正时间:
        /// </summary>
        public IList<ProcessContent> GetAllProcessContent()
        {
            return processContentDao.GetAllProcessContent();
        }

        /// <summary>
        /// 名    称: SearchProcessContentAchievementValue
        /// 功能概要: 获取加工内容业绩比例列表 
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月2日
        /// 修正时间:
        /// </summary>
        public IList<ProcessContentAchievementRate> SearchProcessContentAchievementValue(ProcessContentAchievementRate processContentAchievementRate) 
        {
            return processContentAchievementRateDao.SearchProcessContentAchievementValue(processContentAchievementRate);
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
            return processContentAchievementRateDao.SearchProcessContentAchievementValueRowCount(processContentAchievementRate);
        }
        #endregion
    }
}
