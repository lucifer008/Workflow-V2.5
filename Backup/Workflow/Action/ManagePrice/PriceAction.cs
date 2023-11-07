using System;
using System.Text;
using System.Collections.Generic;
using Workflow.Service;
using Workflow.Da.Domain;
using Workflow.Action.Model;
using Workflow.Service.SystemManege.PriceManage;
//using Workflow.Service.SystemManege.PriceManage;
/// <summary>
/// ��    ��: Workflow.Action.BusinessTypePriceSetAction
/// ���ܸ�Ҫ: ��Ա���۸�/�����Ա�۸�/��ҵ�۸����ʾ/����/�޸�/ɾ��
/// ��    ��: ���ٻ�
/// ����ʱ��: 2007-9-19
/// �� �� ��: ����ط
/// ����ʱ��: 2009-1-21
/// ��������: ��������
/// </summary>

namespace Workflow.Action
{
   
   public class PriceAction : BaseAction
    {
        #region ע��
       
       //�۸����
        private IPriceService priceService;
        public IPriceService PriceService
        {
           set { priceService = value; }
        }
       private IMasterDataService masterDataService;
       public IMasterDataService MasterDataService
       {
           set { masterDataService = value; }
       }

        //�۸�Model
        private PriceModel model = new PriceModel();
        public PriceModel Model
        {
            get { return model; }
        }
        #endregion

        #region ������е������б�
        /// <summary>
        /// ��������: GetPriceFactor
        /// ���ܸ�Ҫ: ������е������б�
        /// ��    ��: ���ٻ�
        /// ����ʱ��: 2007-9-9
        /// ��������: 
        /// ����ʱ��: 
        /// </summary>
        /// <returns></returns>
        public IList<PriceFactor> GetPriceFactor()
        {   
           return priceService.GetPriceFactor();
        }
        #endregion

        #region ��ó�ʼ������
        /// <summary>
        /// ��������: InitData
        /// ���ܸ�Ҫ: ��ó�ʼ������
        /// ��    ��: ���ٻ�
        /// ����ʱ��: 2007-9-11
        /// ��������: 
        /// ����ʱ��: 
        /// </summary>
        /// <returns>PriceModel</returns>
       public virtual void InitData()
        { 
           model.PriceFactor = priceService.GetPriceFactor();
        }
        /// <summary>
        /// ��������: InitDataForUpdate
        /// ���ܸ�Ҫ: ��ó�ʼ������
        /// ��    ��: ���ٻ�
        /// ����ʱ��: 2007-9-11
        /// ��������: 
        /// ����ʱ��: 
        /// </summary>
        /// <returns>PriceModel</returns>
       public virtual void InitDataForUpdate()
       {
           model.PriceFactor = priceService.GetPriceFactorSetList(model.BusinessType);
       }

       /// <summary>
       /// ��������: InitDataForBusinessTypeList
       /// ���ܸ�Ҫ: ��ó�ʼ������
       /// ��    ��: ���ٻ�
       /// ����ʱ��: 2007-9-11
       /// ��������: 
       /// ����ʱ��: 
       /// </summary>
       /// <returns>PriceModel</returns>
       public virtual void InitDataForBusinessTypeList()
       {
           model.BusinessTypeMaster = masterDataService.GetBusinessTypes();
           //model.BusinessTypePriceFactor = priceService.GetBusinessTypePriceFactor();
           model.BusinessTypeList = priceService.GetBusinessTypeList();
       }

        #endregion

        #region ׷���µ�ҵ������
       /// <summary>
        /// ��������: InsertBusinessType
        /// ���ܸ�Ҫ: ׷���µ�ҵ������
        /// ��    ��: ���ٻ�
        /// ����ʱ��: 2007-9-11
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="businessType">ҵ������</param>
        /// <param name="businessTypePriceFactor">ҵ�����Ͱ����ļ۸�����</param>
       public virtual void InsertBusinessType(PriceModel model)
        {
            priceService.InsertBusinessType(model.BusinessType, model.BusinessTypePriceFactor);
        }
        #endregion

        #region �༭��ǰ��ҵ������

        /// <summary>
        /// ��������: UpdateBusinessType
        /// ���ܸ�Ҫ: �༭��ǰ��ҵ������
        /// ��    ��: ���ٻ�
        /// ����ʱ��: 2007-9-11
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="PriceModel">�۸�Model</param>

       public virtual void UpdateBusinessType(PriceModel model)
        {
            priceService.UpdateBusinessType(model.BusinessType, model.BusinessTypePriceFactor);
        }
        #endregion

        #region ɾ����ǰ��ҵ������
        /// <summary>
        /// ��������: DeleteBusinessType
        /// ���ܸ�Ҫ: ɾ����ǰ��ҵ������
        /// ��    ��: ���ٻ�
        /// ����ʱ��: 2007-9-11
        /// ��������:
        /// ����ʱ��: 2008-11-06  ɾ��ҵ������ʱ�����ж�.
        /// </summary>
        /// <param name="PriceModel">�۸�Model</param>
       public virtual string DeleteBusinessType(PriceModel model)
        {
            string returnStr = "";
            try
            {
                priceService.DeleteBusinessType(model.BusinessType);

            }
            catch (Exception ex)
            {

                returnStr = ex.Message;
            }
            return returnStr;
        }
        #endregion

        #region ���ҵ�����Ͱ���������
        /// <summary>
        /// ��������: GetBusinessTypePriceFactor
        /// ���ܸ�Ҫ: ���ҵ�����Ͱ���������
        /// ��    ��: ���ٻ�
        /// ����ʱ��: 2007-9-9
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
       public virtual IList<BusinessTypePriceFactor> GetBusinessTypePriceFactor(BusinessType businessType)
       {
           return null;
       }
        #endregion

        #region �Զ����ѯ
        /// <summary>
        /// ��������: InitCustomQuery
        /// ���ܸ�Ҫ: �Զ����ѯ
        /// ��    ��: ���ٻ�
        /// ����ʱ��: 2007-9-18
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
       public virtual void InitCustomQuery(PriceModel model)
       {
           model.BusinessTypeList= priceService.GetBusinessTypeListCustomQuery(model.BusinessType);
           model.BusinessTypeMaster = masterDataService.GetBusinessTypes();
       }


       /// <summary>
       /// ��ʾ����ʱ��Ҫ��ʾ����Ϣ
       /// </summary>
       /// <param name="model"></param>
       public virtual void ShowSetData(PriceModel model)
       { 
           model.BusinessTypeList= priceService.GetBusinessTypeListCustomQuery_Set(model.BusinessType);
           model.BusinessTypeMaster = masterDataService.GetBusinessTypes();       
       }


       public virtual void InitDataForBusinessTypeList_Set()
       {

           model.BusinessType = new Workflow.Da.Domain.BusinessType();
           model.BusinessType.Id = -1;

           model.BusinessTypeMaster = masterDataService.GetBusinessTypes();
           model.BusinessTypeList = priceService.GetBusinessTypeListCustomQuery_Set(model.BusinessType);
       }


        #endregion
    }
}
