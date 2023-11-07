using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Workflow.Support;
using Workflow.Support.Log;
using Workflow.Support.Ajax;
using Workflow.Service.SystemMaintenance.System;
using Workflow.Service.SystemMaintenance.PriceBaseData;
using Workflow.Service.SystemMaintenance.OrderBaseData;
namespace Workflow.Action.Ajax.SystemMaintenance
{
    /// <summary>
    /// 名    称: CheckFieldIsUseAjax
    /// 功能概要: 检查字段的值是否使用(除已经删除的数据)
    /// 作    者: 张晓林
    /// 创建时间: 2009年4月30日15:26:51
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    class CheckFieldIsUseAjax : AjaxProcess
    {
        #region 依赖注入Service
        private ISearchPriceBaseService searchPriceBaseService;
        public ISearchPriceBaseService SearchPriceBaseService
        {
            set { searchPriceBaseService = value; }
        }

        private ISearchOrderBaseDataService searchOrderBaseDataService;
        public ISearchOrderBaseDataService SearchOrderBaseDataService 
        {
            set { searchOrderBaseDataService = value; }
        }
        private ISearchSystemService searchSystemService;
        public ISearchSystemService SearchSystemService 
        {
            set { searchSystemService = value; }
        }
        #endregion

        public string DoProcess(NameValueCollection parameters)
        {
            try
            {
                long count = 0;
                string tag = parameters["Tag"];
                long deleteId=Convert.ToInt32(parameters["BusinessTypeId"]);
                if ("BusinessType"==tag)//业务类型
                {
                    count = searchPriceBaseService.CheckBusinessTyIsUse(deleteId);
                }
                if ("MachineType" == tag)//机器类型
                {
                    count = searchPriceBaseService.CheckMachineTypeIsUse(deleteId);
                }
                if ("PriceFactor"==tag)//价格因素
                {
                    count = searchPriceBaseService.CheckPriceFactorIsUse(deleteId);
                }
                if ("ProcessContent"==tag)//加工内容
                {
                    count = 0;//searchPriceBaseService.CheckProcessContentIsUse(deleteId);//2009年6月5日15:06:56注释
                }
                if ("FactorRelation"==tag)//价格因素之间的关系依赖
                {
                    count = searchPriceBaseService.CheckFactorRelationIsUse(deleteId);
                }
                if ("CustomerLevel" == tag)//客户级别
                {
                    count = searchOrderBaseDataService.CheckCustomerLevelIsUse(deleteId);
                }
                if ("CustomerType" == tag)//客户类型
                {
                    count = searchOrderBaseDataService.CheckCustomerTypeIsUse(deleteId);
                }
                if ("MasterTrade"==tag)//客户主行业
                {
                    count = searchOrderBaseDataService.CheckMasterTradeIsUse(deleteId);
                }
                if("MemberCardLevel"==tag)//会员卡级别
                {
                    count = searchOrderBaseDataService.CheckMemberCardLevelIsUse(deleteId);
                }
                if ("PrintDemand"==tag)//印制要求
                {
                    count = searchOrderBaseDataService.CheckPrintDemandIsUse(deleteId);
                }
                if ("ReportLessMode"==tag)//挂失方式
                {
                    count = searchOrderBaseDataService.CheckReportLessModeIsUse(deleteId);
                }
                if ("TrashReason"==tag)//废张原因
                {
                    count = searchOrderBaseDataService.CheckTrashReasonIsUse(deleteId);
                }
                if("Company"==tag)//公司
                {
                    count = searchSystemService.CheckCompanyIsUsed(deleteId);
                }
                return Convert.ToString(count);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex, Constants.LOGGER_NAME);
                throw ex;
            }
        }

    }
}
