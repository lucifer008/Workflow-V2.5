using System;
using System.Collections.Generic;
using Workflow.Service.SystemMaintenance.OrderBaseData;
using Workflow.Action.SystemMaintenance.OrderBaseData.Model;

namespace Workflow.Action.SystemMaintenance.OrderBaseData
{
    /// <summary>
    /// 名   称:  OrderBaseDataAction
    /// 功能概要: 订单基础数据维护Action
    /// 作    者: 张晓林
    /// 创建时间: 2009年4月29日17:02:07
    /// 修正履历:
    /// 修正时间:
    /// </summary>
    public class OrderBaseDataAction
    {
        #region//ClassMember
        private IOrderBaseDataService orderBaseDataService;
        public IOrderBaseDataService OrderBaseDataService 
        {
            set { orderBaseDataService = value; }
        }

        private OrderBaseDataModel model = new OrderBaseDataModel();
        public OrderBaseDataModel Model
        {
            set { model = value; }
            get { return model; }
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
        public void AddCustomerLevel() 
        {
            orderBaseDataService.AddCustomerLevel(model.CustomerLevel);
        }

        /// <summary>
        /// 名   称:  UpdateCustomerLevel
        /// 功能概要: 更新客户级别
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月19日9:47:16
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void UpdateCustomerLevel()
        {
            orderBaseDataService.UpdateCustomerLevel(model.CustomerLevel);
        }

        /// <summary>
        /// 名   称:  LogicDeleteCustomerLevel
        /// 功能概要: 逻辑删除客户级别
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月19日9:47:16
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void LogicDeleteCustomerLevel()
        {
            orderBaseDataService.LogicDeleteCustomerLevel(model.CustomerLevel.Id);
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
        public void AddCustomerType()
        {
            orderBaseDataService.AddCustomerType(model.CustomerType);
        }

        /// <summary>
        /// 名   称:  UpdateCustomerType
        /// 功能概要: 更新客户类型
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月19日9:47:16
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void UpdateCustomerTypel()
        {
            orderBaseDataService.UpdateCustomerType(model.CustomerType);
        }

        /// <summary>
        /// 名   称:  LogicDeleteCustomerType
        /// 功能概要: 逻辑删除客户类型
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月19日9:47:16
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void LogicDeleteCustomerType()
        {
            orderBaseDataService.LogicDeleteCustomerType(model.CustomerType.Id);
        }
        #endregion

        #region//客户行业及主行业
        /// <summary>
        /// 名   称:  AddMasterTrade
        /// 功能概要: 添加客户主行业
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月20日9:56:25
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void AddMasterTrade()
        {
            orderBaseDataService.AddMasterTrade(model.MasterTrade);
        }

        /// <summary>
        /// 名   称:  UpdateMasterTrade
        /// 功能概要: 更新客户主行业
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月20日9:56:25
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void UpdateMasterTrade()
        {
            orderBaseDataService.UpdateMasterTrade(model.MasterTrade);
        }

        /// <summary>
        /// 名   称:  LogicDeleteMasterTrade
        /// 功能概要: 逻辑删除客户主行业
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月20日9:56:25
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void LogicDeleteMasterTrade()
        {
            orderBaseDataService.LogicDeleteMasterTrade(model.MasterTrade.Id);
        }

        /// <summary>
        /// 名   称:  AddSeondaryTrade
        /// 功能概要: 添加客户子行业
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月20日9:56:25
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void AddSecondaryTrade()
        {
            orderBaseDataService.AddSecondaryTrade(model.SecondaryTrade);
        }

        /// <summary>
        /// 名   称:  UpdateSecondaryTrade
        /// 功能概要: 更新客户子行业
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月20日9:56:25
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void UpdateSecondaryTrade()
        {
            orderBaseDataService.UpdateSecondaryTrade(model.SecondaryTrade);
        }

        /// <summary>
        /// 名   称:  LogicDeleteSecondaryTrade
        /// 功能概要: 逻辑删除客户子行业
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月20日9:56:25
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void LogicDeleteSecondaryTrade()
        {
            orderBaseDataService.LogicDeleteSecondaryTrade(model.SecondaryTrade.Id);
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
        public void AddMemberCardLevel() 
        {
            orderBaseDataService.AddMemberCardLevel(model.MemberCardLevel);
        }

        /// <summary>
        /// 名   称:  UpdateMemberCardLevel
        /// 功能概要: 更新会员卡级别
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月23日10:42:04
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void UpdateMemberCardLevel()
        {
            orderBaseDataService.UpdateMemberCardLevel(model.MemberCardLevel);
        }

        /// <summary>
        /// 名   称:  UpdateMemberCardLevel
        /// 功能概要: 更新会员卡级别
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月23日10:42:04
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void LogicDeleteMemberCardLevel()
        {
            orderBaseDataService.LogicDeleteMemberCardLevel(model.MemberCardLevel.Id);
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
        public void AddPrintDemand()
        {
            orderBaseDataService.AddPrintDemand(model.PrintDemand);
        }

        /// <summary>
        /// 名   称:  UpdatePrintDemand
        /// 功能概要: 更新印制要求
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月26日13:46:43
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void UpdatePrintDemand()
        {
            orderBaseDataService.UpdatePrintDemand(model.PrintDemand);
        }

        /// <summary>
        /// 名   称:  LogicDeletePrintDemand
        /// 功能概要: 逻辑删除印制要求
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月26日13:46:43
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void LogicDeletePrintDemand()
        {
            orderBaseDataService.LogicDeletePrintDemand(model.PrintDemand.Id);
        }

         /// <summary>
        /// 名   称:  AddPrintDemandDetail
        /// 功能概要: 添加印制要求明细
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月26日11:49:00
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void AddPrintDemandDetail() 
        {
            orderBaseDataService.AddPrintDemandDetail(model.PrintDemandDetail);
        }

        /// <summary>
        /// 名   称:  UpdatePrintDemandDetail
        /// 功能概要: 更新印制要求明细
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月26日11:49:00
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void UpdatePrintDemandDetail()
        {
            orderBaseDataService.UpdatePrintDemandDetail(model.PrintDemandDetail);
        }

        /// <summary>
        /// 名   称:  LogicDeletePrintDemandDetail
        /// 功能概要: 逻辑删除印制要求明细
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月26日11:49:00
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void LogicDeletePrintDemandDetail()
        {
            orderBaseDataService.LogicDeletePrintDemandDetail(model.PrintDemandDetail.Id);
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
        public void AddReportLessMode()
        {
            orderBaseDataService.AddReportLessMode(model.ReportLessMode);
        }

        /// <summary>
        /// 名   称:  UpdateReportLessMode
        /// 功能概要: 修改挂失方式
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月27日11:22:45
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void UpdateReportLessMode()
        {
            orderBaseDataService.UpdateReportLessMode(model.ReportLessMode);
        }

        /// <summary>
        /// 名   称:  LogicDeleteReportLessMode
        /// 功能概要: 逻辑删除挂失方式
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月27日11:22:45
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void LogicDeleteReportLessMode()
        {
            orderBaseDataService.LogicDeleteReportLessMode(model.ReportLessMode.Id);
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
        public void AddTrashReason()
        {
            orderBaseDataService.AddTrashReason(model.TrashReason);
        }

        /// <summary>
        /// 名   称:  UpdateTrashReason
        /// 功能概要: 修改废张原因
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月2日10:22:45
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void UpdateTrashReason()
        {
            orderBaseDataService.UpdateTrashReason(model.TrashReason);
        }

        /// <summary>
        /// 名   称:  LogicDeleteTrashReason
        /// 功能概要: 逻辑删除废张原因
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月2日10:22:45
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void LogicDeleteTrashReason()
        {
            orderBaseDataService.LogicDeleteTrashReason(model.TrashReason.Id);
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
        public void AddProcessContentAchievementRate() 
        {
            orderBaseDataService.AddProcessContentAchievementRate(model.ProcessContentAchievementRate);
        }

        /// <summary>
        /// 名   称:  UpdateProcessContentAchievementRate
        /// 功能概要: 修改加工内容业绩比例
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月2日
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void UpdateProcessContentAchievementRate()
        {
            orderBaseDataService.UpdateProcessContentAchievementRate(model.ProcessContentAchievementRate);
        }

        /// <summary>
        /// 名   称:  LogicDeleteProcessContentAchievementRate
        /// 功能概要: 逻辑删除加工内容业绩比例
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月2日
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void LogicDeleteProcessContentAchievementRate()
        {
            orderBaseDataService.LogicDeleteProcessContentAchievementRate(model.ProcessContentAchievementRate.Id);
        }
        #endregion
    }
}
