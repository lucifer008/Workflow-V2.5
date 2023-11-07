using System;
using System.Text;
using System.Collections.Generic;
using Workflow.Service;
using Workflow.Da.Domain;
using Workflow.Action.Model;
using Workflow.Service.SystemManege.PriceManage;
//using Workflow.Service.SystemManege.PriceManage;
/// <summary>
/// 名    称: Workflow.Action.BusinessTypePriceSetAction
/// 功能概要: 会员卡价格/特殊会员价格/行业价格的显示/增加/修改/删除
/// 作    者: 麻少华
/// 创建时间: 2007-9-19
/// 修 正 人: 陈汝胤
/// 修正时间: 2009-1-21
/// 修正描述: 代码整理
/// </summary>

namespace Workflow.Action
{
   
   public class PriceAction : BaseAction
    {
        #region 注入
       
       //价格管理
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

        //价格Model
        private PriceModel model = new PriceModel();
        public PriceModel Model
        {
            get { return model; }
        }
        #endregion

        #region 获得所有的因素列表
        /// <summary>
        /// 方法名称: GetPriceFactor
        /// 功能概要: 获得所有的因素列表
        /// 作    者: 麻少华
        /// 创建时间: 2007-9-9
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <returns></returns>
        public IList<PriceFactor> GetPriceFactor()
        {   
           return priceService.GetPriceFactor();
        }
        #endregion

        #region 获得初始化数据
        /// <summary>
        /// 方法名称: InitData
        /// 功能概要: 获得初始化数据
        /// 作    者: 麻少华
        /// 创建时间: 2007-9-11
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <returns>PriceModel</returns>
       public virtual void InitData()
        { 
           model.PriceFactor = priceService.GetPriceFactor();
        }
        /// <summary>
        /// 方法名称: InitDataForUpdate
        /// 功能概要: 获得初始化数据
        /// 作    者: 麻少华
        /// 创建时间: 2007-9-11
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <returns>PriceModel</returns>
       public virtual void InitDataForUpdate()
       {
           model.PriceFactor = priceService.GetPriceFactorSetList(model.BusinessType);
       }

       /// <summary>
       /// 方法名称: InitDataForBusinessTypeList
       /// 功能概要: 获得初始化数据
       /// 作    者: 麻少华
       /// 创建时间: 2007-9-11
       /// 修正履历: 
       /// 修正时间: 
       /// </summary>
       /// <returns>PriceModel</returns>
       public virtual void InitDataForBusinessTypeList()
       {
           model.BusinessTypeMaster = masterDataService.GetBusinessTypes();
           //model.BusinessTypePriceFactor = priceService.GetBusinessTypePriceFactor();
           model.BusinessTypeList = priceService.GetBusinessTypeList();
       }

        #endregion

        #region 追加新的业务类型
       /// <summary>
        /// 方法名称: InsertBusinessType
        /// 功能概要: 追加新的业务类型
        /// 作    者: 麻少华
        /// 创建时间: 2007-9-11
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="businessType">业务类型</param>
        /// <param name="businessTypePriceFactor">业务类型包含的价格因素</param>
       public virtual void InsertBusinessType(PriceModel model)
        {
            priceService.InsertBusinessType(model.BusinessType, model.BusinessTypePriceFactor);
        }
        #endregion

        #region 编辑当前的业务类型

        /// <summary>
        /// 方法名称: UpdateBusinessType
        /// 功能概要: 编辑当前的业务类型
        /// 作    者: 麻少华
        /// 创建时间: 2007-9-11
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="PriceModel">价格Model</param>

       public virtual void UpdateBusinessType(PriceModel model)
        {
            priceService.UpdateBusinessType(model.BusinessType, model.BusinessTypePriceFactor);
        }
        #endregion

        #region 删除当前的业务类型
        /// <summary>
        /// 方法名称: DeleteBusinessType
        /// 功能概要: 删除当前的业务类型
        /// 作    者: 麻少华
        /// 创建时间: 2007-9-11
        /// 修正履历:
        /// 修正时间: 2008-11-06  删除业务类型时增加判断.
        /// </summary>
        /// <param name="PriceModel">价格Model</param>
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

        #region 获得业务类型包含的因素
        /// <summary>
        /// 方法名称: GetBusinessTypePriceFactor
        /// 功能概要: 获得业务类型包含的因素
        /// 作    者: 麻少华
        /// 创建时间: 2007-9-9
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
       public virtual IList<BusinessTypePriceFactor> GetBusinessTypePriceFactor(BusinessType businessType)
       {
           return null;
       }
        #endregion

        #region 自定义查询
        /// <summary>
        /// 方法名称: InitCustomQuery
        /// 功能概要: 自定义查询
        /// 作    者: 麻少华
        /// 创建时间: 2007-9-18
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
       public virtual void InitCustomQuery(PriceModel model)
       {
           model.BusinessTypeList= priceService.GetBusinessTypeListCustomQuery(model.BusinessType);
           model.BusinessTypeMaster = masterDataService.GetBusinessTypes();
       }


       /// <summary>
       /// 显示设置时需要显示的信息
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
