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
    /// ��    ��: CheckFieldIsUseAjax
    /// ���ܸ�Ҫ: ����ֶε�ֵ�Ƿ�ʹ��(���Ѿ�ɾ��������)
    /// ��    ��: ������
    /// ����ʱ��: 2009��4��30��15:26:51
    /// ��������: 
    /// ����ʱ��: 
    /// </summary>
    class CheckFieldIsUseAjax : AjaxProcess
    {
        #region ����ע��Service
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
                if ("BusinessType"==tag)//ҵ������
                {
                    count = searchPriceBaseService.CheckBusinessTyIsUse(deleteId);
                }
                if ("MachineType" == tag)//��������
                {
                    count = searchPriceBaseService.CheckMachineTypeIsUse(deleteId);
                }
                if ("PriceFactor"==tag)//�۸�����
                {
                    count = searchPriceBaseService.CheckPriceFactorIsUse(deleteId);
                }
                if ("ProcessContent"==tag)//�ӹ�����
                {
                    count = 0;//searchPriceBaseService.CheckProcessContentIsUse(deleteId);//2009��6��5��15:06:56ע��
                }
                if ("FactorRelation"==tag)//�۸�����֮��Ĺ�ϵ����
                {
                    count = searchPriceBaseService.CheckFactorRelationIsUse(deleteId);
                }
                if ("CustomerLevel" == tag)//�ͻ�����
                {
                    count = searchOrderBaseDataService.CheckCustomerLevelIsUse(deleteId);
                }
                if ("CustomerType" == tag)//�ͻ�����
                {
                    count = searchOrderBaseDataService.CheckCustomerTypeIsUse(deleteId);
                }
                if ("MasterTrade"==tag)//�ͻ�����ҵ
                {
                    count = searchOrderBaseDataService.CheckMasterTradeIsUse(deleteId);
                }
                if("MemberCardLevel"==tag)//��Ա������
                {
                    count = searchOrderBaseDataService.CheckMemberCardLevelIsUse(deleteId);
                }
                if ("PrintDemand"==tag)//ӡ��Ҫ��
                {
                    count = searchOrderBaseDataService.CheckPrintDemandIsUse(deleteId);
                }
                if ("ReportLessMode"==tag)//��ʧ��ʽ
                {
                    count = searchOrderBaseDataService.CheckReportLessModeIsUse(deleteId);
                }
                if ("TrashReason"==tag)//����ԭ��
                {
                    count = searchOrderBaseDataService.CheckTrashReasonIsUse(deleteId);
                }
                if("Company"==tag)//��˾
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
