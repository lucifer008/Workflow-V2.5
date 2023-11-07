using System;
using System.Collections.Generic;
using Workflow.Da;
using Workflow.Da.Domain;
using Workflow.Da.Support;
namespace Workflow.Service.SystemMaintenance.OrderBaseData.Impl
{
    /// <summary>
    /// 名    称: OrderBaseDataServiceImpl
    /// 功能概要: 管理工单基础数据接口实现
    /// 作    者: 张晓林
    /// 创建时间: 2009年4月29日17:22:33
    /// 修 正 人: 
    /// 修正时间: 
    /// 修正描述: 
    /// </summary>
    public class OrderBaseDataServiceImpl:IOrderBaseDataService
    {
        #region//注入Dao
        private IdGeneratorSupport idGeneratorSupport;
        public IdGeneratorSupport IdGeneratorSupport
        {
            set { idGeneratorSupport = value; }
        }

        private ICustomerLevelDao customerLevelDao;
        public ICustomerLevelDao CustomerLevelDao
        {
            set{customerLevelDao=value;}
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

        private IProcessContentAchievementRateDao processContentAchievementRateDao;
        public IProcessContentAchievementRateDao ProcessContentAchievementRateDao
        {
            set { processContentAchievementRateDao = value; }
        }
        #endregion

        #region//客户级别
        /// <summary>
        /// 名   称:  AddCustomerLevel
        /// 功能概要: 添加客户级别
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月19日9:47:16
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void AddCustomerLevel(CustomerLevel customerLevel)
        {
            Type type = typeof(CustomerLevel);
            long id = idGeneratorSupport.NextId(type);
            customerLevel.No = "0" + id.ToString();
            customerLevel.SortNo = Convert.ToInt32(id);
            customerLevelDao.Insert(customerLevel);
        }

        /// <summary>
        /// 名   称:  UpdateCustomerLevel
        /// 功能概要: 更新客户级别
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月19日9:47:16
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void UpdateCustomerLevel(CustomerLevel customerLevel)
        {
            customerLevel.No = "0" + customerLevel.Id.ToString();
            customerLevel.SortNo = Convert.ToInt32(customerLevel.Id);
            customerLevelDao.Update(customerLevel);
        }

        /// <summary>
        /// 名   称:  LogicDeleteCustomerLevel
        /// 功能概要: 逻辑删除客户级别
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月19日9:47:16
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void LogicDeleteCustomerLevel(long customerLevelId) 
        {
            customerLevelDao.LogicDelete(customerLevelId);
        }
        
        #endregion

        #region//客户类型
        /// <summary>
        /// 名   称:  AddCustomerType
        /// 功能概要: 添加客户类型
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月19日9:47:16
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void AddCustomerType(CustomerType customerType) 
        {
            Type type = typeof(CustomerType);
            long id = idGeneratorSupport.NextId(type);
            customerType.No = "0" + id.ToString();
            customerType.SortNo = Convert.ToInt32(id);
            customerTypeDao.Insert(customerType);
        }

        /// <summary>
        /// 名   称:  UpdateCustomerType
        /// 功能概要: 更新客户类型
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月19日9:47:16
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void UpdateCustomerType(CustomerType customerType) 
        {
            customerType.No = "0" + customerType.Id.ToString();
            customerType.SortNo = Convert.ToInt32(customerType.Id);
            customerTypeDao.Update(customerType);
        }

        /// <summary>
        /// 名   称:  LogicDeleteCustomerType
        /// 功能概要: 逻辑删除客户类型
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月19日9:47:16
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void LogicDeleteCustomerType(long customerTypeId) 
        {
            customerTypeDao.LogicDelete(customerTypeId);
        }

        #endregion

        #region//客户行业及子行业
        /// <summary>
        /// 名   称:  AddMasterTrade
        /// 功能概要: 添加客户主行业
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月20日9:56:25
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void AddMasterTrade(MasterTrade masterTrade) 
        {
            Type type = typeof(MasterTrade);
            long id = idGeneratorSupport.NextId(type);
            masterTrade.No = "0" + id.ToString();
            masterTradeDao.Insert(masterTrade);
        }

        /// <summary>
        /// 名   称:  UpdateMasterTrade
        /// 功能概要: 更新客户主行业
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月20日9:56:25
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void UpdateMasterTrade(MasterTrade masterTrade) 
        {
            masterTrade.No ="0"+ masterTrade.Id.ToString();
            masterTradeDao.Update(masterTrade);
        }

        /// <summary>
        /// 名   称:  LogicDeleteMasterTrade
        /// 功能概要: 逻辑删除客户主行业
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月20日9:56:25
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void LogicDeleteMasterTrade(long masterTradeId) 
        {
            masterTradeDao.LogicDelete(masterTradeId);
        }


        /// <summary>
        /// 名   称:  AddSeondaryTrade
        /// 功能概要: 添加客户子行业
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月20日9:56:25
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void AddSecondaryTrade(SecondaryTrade secondaryTrade) 
        {
            Type type = typeof(SecondaryTrade);
            long id = idGeneratorSupport.NextId(type);
            secondaryTrade.No = "0" + id.ToString();
            secondaryTradeDao.Insert(secondaryTrade);
        }

        /// <summary>
        /// 名   称:  UpdateSecondaryTrade
        /// 功能概要: 更新客户子行业
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月20日9:56:25
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void UpdateSecondaryTrade(SecondaryTrade secondaryTrade) 
        {
            secondaryTrade.No ="0"+ secondaryTrade.Id.ToString();
            secondaryTradeDao.Update(secondaryTrade);
        }


        /// <summary>
        /// 名   称:  LogicDeleteSecondaryTrade
        /// 功能概要: 逻辑删除客户子行业
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月20日9:56:25
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void LogicDeleteSecondaryTrade(long secondaryTradeId) 
        {
            secondaryTradeDao.LogicDelete(secondaryTradeId);
        }
        #endregion

        #region//会员卡级别
        /// <summary>
        /// 名   称:  AddMemberCardLevel
        /// 功能概要: 添加会员卡级别
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月23日10:42:04
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void AddMemberCardLevel(MemberCardLevel memberCardLevel) 
        {
            Type type = typeof(MemberCardLevel);
            long id = idGeneratorSupport.NextId(type);
            memberCardLevel.No = "0" + id.ToString();
            memberCardLevelDao.Insert(memberCardLevel);
        }

        /// <summary>
        /// 名   称:  UpdateMemberCardLevel
        /// 功能概要: 更新会员卡级别
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月23日10:42:04
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void UpdateMemberCardLevel(MemberCardLevel memberCardLevel) 
        {
            memberCardLevel.No = "0" + memberCardLevel.Id;
            memberCardLevelDao.Update(memberCardLevel);
        }

        /// <summary>
        /// 名   称:  UpdateMemberCardLevel
        /// 功能概要: 更新会员卡级别
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月23日10:42:04
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void LogicDeleteMemberCardLevel(long memberCardLevelId) 
        {
            memberCardLevelDao.LogicDelete(memberCardLevelId);
        }
        #endregion

        #region//印制要求及明细
        /// <summary>
        /// 名   称:  AddPrintDemand
        /// 功能概要: 添加印制要求
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月26日13:46:43
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void AddPrintDemand(PrintDemand printDemand) 
        {
            Type type = typeof(PrintDemand);
            long id = idGeneratorSupport.NextId(type);
            printDemand.SortNo = Convert.ToInt32(id);
            printDemandDao.Insert(printDemand);
        }

        /// <summary>
        /// 名   称:  UpdatePrintDemand
        /// 功能概要: 更新印制要求
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月26日13:46:43
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void UpdatePrintDemand(PrintDemand printDemand) 
        {
            printDemand.SortNo = Convert.ToInt32(printDemand.Id);
            printDemandDao.Update(printDemand);
        }

        /// <summary>
        /// 名   称:  LogicDeletePrintDemand
        /// 功能概要: 逻辑删除印制要求
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月26日13:46:43
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void LogicDeletePrintDemand(long printDemandId) 
        {
            printDemandDao.LogicDelete(printDemandId);
        }

        /// <summary>
        /// 名   称:  AddPrintDemandDetail
        /// 功能概要: 添加印制要求明细
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月26日11:49:00
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void AddPrintDemandDetail(PrintDemandDetail printDemandDetail) 
        {
            Type type = typeof(PrintDemandDetail);
            long id = idGeneratorSupport.NextId(type);
            printDemandDetail.SortNo = Convert.ToInt32(id);
            printDemandDetailDao.Insert(printDemandDetail);
        }

        /// <summary>
        /// 名   称:  UpdatePrintDemandDetail
        /// 功能概要: 更新印制要求明细
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月26日11:49:00
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void UpdatePrintDemandDetail(PrintDemandDetail printDemandDetail) 
        {
            printDemandDetail.SortNo = Convert.ToInt32(printDemandDetail.Id);
            printDemandDetailDao.Update(printDemandDetail);
        }

        /// <summary>
        /// 名   称:  LogicDeletePrintDemandDetail
        /// 功能概要: 逻辑删除印制要求明细
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月26日11:49:00
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void LogicDeletePrintDemandDetail(long printDemandDetailId) 
        {
            printDemandDetailDao.LogicDelete(printDemandDetailId);
        }
        #endregion

        #region//挂失方式
        /// <summary>
        /// 名   称:  AddReportLessMode
        /// 功能概要: 添加挂失方式
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月27日11:22:45
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void AddReportLessMode(ReportLessMode reportLessMode) 
        {
            Type type = typeof(ReportLessMode);
            long id = idGeneratorSupport.NextId(type);
            reportLessMode.No = "0"+Convert.ToString(id);
            reportLessModeDao.Insert(reportLessMode);
        }

        /// <summary>
        /// 名   称:  UpdateReportLessMode
        /// 功能概要: 修改挂失方式
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月27日11:22:45
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void UpdateReportLessMode(ReportLessMode reportLessMode) 
        {
            reportLessMode.No = "0"+reportLessMode.Id.ToString();
            reportLessModeDao.Update(reportLessMode);
        }

        /// <summary>
        /// 名   称:  LogicDeleteReportLessMode
        /// 功能概要: 逻辑删除挂失方式
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月27日11:22:45
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void LogicDeleteReportLessMode(long reportLessModeId) 
        {
            reportLessModeDao.LogicDelete(reportLessModeId);
        }
        #endregion

        #region//废张原因
        /// <summary>
        /// 名   称:  AddTrashReason
        /// 功能概要: 添加废张原因
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月2日10:22:45
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void AddTrashReason(TrashReason trashReason)
        {
            trashReasonDao.Insert(trashReason);
        }

        /// <summary>
        /// 名   称:  UpdateTrashReason
        /// 功能概要: 修改废张原因
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月2日10:22:45
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void UpdateTrashReason(TrashReason trashReason) 
        {
            trashReasonDao.Update(trashReason);
        }
        /// <summary>
        /// 名   称:  LogicDeleteTrashReason
        /// 功能概要: 逻辑删除废张原因
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月2日10:22:45
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void LogicDeleteTrashReason(long trashReasonId) 
        {
            trashReasonDao.LogicDelete(trashReasonId);
        }
        #endregion

        #region//加工内容业绩比例
        /// <summary>
        /// 名   称:  AddProcessContentAchievementRate
        /// 功能概要: 添加加工内容业绩比例
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月2日
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void AddProcessContentAchievementRate(ProcessContentAchievementRate processContentAchievementRate) 
        {
            processContentAchievementRateDao.Insert(processContentAchievementRate);
        }

        /// <summary>
        /// 名   称:  UpdateProcessContentAchievementRate
        /// 功能概要: 修改加工内容业绩比例
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月2日
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void UpdateProcessContentAchievementRate(ProcessContentAchievementRate processContentAchievementRate) 
        {
            processContentAchievementRateDao.Update(processContentAchievementRate);
        }

        /// <summary>
        /// 名   称:  LogicDeleteProcessContentAchievementRate
        /// 功能概要: 逻辑删除加工内容业绩比例
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月2日
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void LogicDeleteProcessContentAchievementRate(long processContentAchievementId) 
        {
            processContentAchievementRateDao.Delete(processContentAchievementId);
        }
        #endregion
    }
}
