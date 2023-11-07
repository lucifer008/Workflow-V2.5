using System;
using System.Collections.Generic;
using Workflow.Service.SystemMaintenance.OrderBaseData;
using Workflow.Action.SystemMaintenance.OrderBaseData.Model;
namespace Workflow.Action.SystemMaintenance.OrderBaseData
{
    /// <summary>
    /// 名   称:  SearchOrderBaseDataAction
    /// 功能概要: 获取工单基础数据Action
    /// 作    者: 张晓林
    /// 创建时间: 2009年4月29日17:02:07
    /// 修正履历:
    /// 修正时间:
    /// </summary>
    public class SearchOrderBaseDataAction
    {
        #region//ClassMember
        private ISearchOrderBaseDataService searchOrderBaseDataService;
        public ISearchOrderBaseDataService SearchOrderBaseDataService 
        {
            set { searchOrderBaseDataService = value; }
        }

        private OrderBaseDataModel model=new OrderBaseDataModel();
        public OrderBaseDataModel Model 
        {
            set { model = value; }
            get { return model; }
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
        public void SearchCustomerLevel() 
        {
            model.CustomerLevelList = searchOrderBaseDataService.SearchCustomerLevel(model.CustomerLevel);
            model.RowCount = searchOrderBaseDataService.SearchCustomerLevelRowCount(model.CustomerLevel);
        }
        #endregion

        #region//客户类型
        /// <summary>
        /// 名   称:  SearchCustomerType
        /// 功能概要: 获取客户级别列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月19日10:04:46
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void SearchCustomerType()
        {
            model.CustomerTypeList = searchOrderBaseDataService.SearchCustomerType(model.CustomerType);
            model.RowCount = searchOrderBaseDataService.SearchCustomerTypeRowCount(model.CustomerType);
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
        public void SearchMasterTrade() 
        {
            model.MasterTradeList = searchOrderBaseDataService.SearchMasterTrade(model.MasterTrade);
            model.RowCount = searchOrderBaseDataService.SearchMasterTradeRowCount(model.MasterTrade);
        }

        /// <summary>
        /// 名   称:  SearchSecondaryTrade
        /// 功能概要: 获取客子行业列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月20日10:20:39
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void SearchSecondaryTrade()
        {
            model.SecondaryTradeList = searchOrderBaseDataService.SearchSecondaryTrade(model.SecondaryTrade);
            model.RowCount= searchOrderBaseDataService.SearchSecondaryTradeRowCount(model.SecondaryTrade);
        }

        /// <summary>
        /// 名   称:  GetAllMasterTrade
        /// 功能概要: 获取所有主行业列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月22日9:51:12
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void GetAllMasterTrade() 
        {
            model.MasterTradeList = searchOrderBaseDataService.GetAllMasterTrade();
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
        public void SearchMemberCardLevel() 
        {
            model.MemberCardLevelList = searchOrderBaseDataService.SearchMemberCardLevel(model.MemberCardLevel);
            model.RowCount = searchOrderBaseDataService.SearchMemberCardLevelRowCount(model.MemberCardLevel);
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
        public void SearchPrintDemand() 
        {
            model.PrintDemandList = searchOrderBaseDataService.SearchPrintDemand(model.PrintDemand);
            model.RowCount = searchOrderBaseDataService.SearchPrintDemandRowCount(model.PrintDemand);
        }

        /// <summary>
        /// 名   称:  SearchPrintDemandDetail
        /// 功能概要: 获取印制要求明细列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月26日11:49:00
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void SearchPrintDemandDetail()
        {
            model.PrintDemandDetailList = searchOrderBaseDataService.SearchPrintDemandDetail(model.PrintDemandDetail);
            model.RowCount = searchOrderBaseDataService.SearchPrintDemandDetailRowCount(model.PrintDemandDetail);
        }

        /// <summary>
        /// 名   称:  GetAllPrintDemand
        /// 功能概要: 获取所有印制要求列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月26日17:47:10
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void GetAllPrintDemand() 
        {
            model.PrintDemandList = searchOrderBaseDataService.GetAllPrintDemand();
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
        public void SearchReportLessMode() 
        {
            model.ReportLessModeList=searchOrderBaseDataService.SearchReportLessMode(model.ReportLessMode);
            model.RowCount = searchOrderBaseDataService.SearchReportLessModeRowCount(model.ReportLessMode);
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
        public void SearchTrashReason() 
        {
            model.TrashReasonList = searchOrderBaseDataService.SearchTrashReason(model.TrashReason);
            model.RowCount = searchOrderBaseDataService.SearchTrashReasonRowCount(model.TrashReason);
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
        public void GetAllProcessContent() 
        {
            model.ProcessContentList = searchOrderBaseDataService.GetAllProcessContent();
        }

        /// <summary>
        /// 名    称: SearchProcessContentAchievementValue
        /// 功能概要: 获取加工内容业绩比例列表 
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月2日
        /// 修正时间:
        /// </summary>
        public void SearchProcessContentAchievementValue() 
        {
            model.ProcessContentAchievementRateList = searchOrderBaseDataService.SearchProcessContentAchievementValue(model.ProcessContentAchievementRate);
            model.RowCount = searchOrderBaseDataService.SearchProcessContentAchievementValueRowCount(model.ProcessContentAchievementRate);
        }
        #endregion
    }
}
