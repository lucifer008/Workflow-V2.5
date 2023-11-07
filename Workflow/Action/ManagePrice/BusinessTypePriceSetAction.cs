using System;
using System.Text;
using System.Collections.Generic;
using Workflow.Service;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Action.Model;
using Workflow.Service.MemberCardManager;
using Workflow.Service.SystemManege.PriceManage;
namespace Workflow.Action
{
    /// <summary>
    /// 名    称: Workflow.Action.BusinessTypePriceSetAction
    /// 功能概要: 会员卡价格/特殊会员价格/行业价格的显示/增加/修改/删除
    /// 作    者: 麻少华
    /// 创建时间: 2007-9-19
    /// 修正履历:
    /// 修正时间:
    /// </summary>
    public class BusinessTypePriceSetAction
    {
        #region 对象传递
        /// <summary>
        /// 价格管理
        /// </summary>
        private IPriceService priceService;
        public IPriceService PriceService
        {
            set { priceService = value; }
        }

        /// <summary>
        /// 会员管理
        /// </summary>
        private IMemberCardService memberCardService;
        public IMemberCardService MemberCardService
        {
            set { memberCardService = value; }
        }

        private ISearchMemberCardService searchMemberCardService;
        public ISearchMemberCardService SearchMemberCardService 
        {
            set { searchMemberCardService = value; }
        }

        /// <summary>
        /// 基本信息管理
        /// </summary>
        private IMasterDataService masterDataService;
        public IMasterDataService MasterDataService
        {
            set { masterDataService = value; }
        }
        #endregion

        #region 私有成员变量
        private BusinessTypePriceSetModel model = new BusinessTypePriceSetModel();
        public BusinessTypePriceSetModel Model
        {
            get { return model; }
        }
        #endregion

        /// <summary>
        /// 方法名称: Add
        /// 功能概要: 会员卡价格/特殊会员价格/行业价格的增加
        /// 作    者: 麻少华
        /// 创建时间: 2007-9-19
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="model"></param>
        public virtual void Add(BusinessTypePriceSetModel model)
        {
            priceService.InsertBusinessTypePriceSet(model.BusinessTypePriceSetList);
        }

        /// <summary>
        /// 方法名称: Update
        /// 功能概要: 会员卡价格/特殊会员价格/行业价格的更新
        /// 作    者: 麻少华
        /// 创建时间: 2007-9-19
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="model"></param>
        public virtual void Update(BusinessTypePriceSetModel model)
        {
            priceService.UpdateBusinessTypePriceSet(model.BusinessTypePriceSetList);
        }

        /// <summary>
        /// 方法名称: Delete
        /// 功能概要: 门市价格的删除
        /// 作    者: 麻少华
        /// 创建时间: 2007-9-19
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="model"></param>
        public virtual void Delete(BusinessTypePriceSetModel model)
        {
            priceService.DeleteBusinessTypePriceSet(model.BusinessTypePriceSet);
        }

        /// <summary>
        /// 方法名称: InitDataPriceSet
        /// 功能概要: 价格设置页面初始化
        /// 作    者: 麻少华
        /// 创建时间: 2007-9-26
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="intAction"></param>
        public virtual void InitDataPriceSetMember(BusinessTypePriceSetModel model, int intAction)
        {
            switch (intAction)
            {
                case Constants.ACTION_INIT:
                    //初始化业务类型Combox
                    model.BusinessTypeList = masterDataService.GetBusinessTypes();
                    //model.PriceFactor = masterDataService.GetPriceFactors();
                    //获取价格一览
                    model.BusinessTypePriceSet = priceService.GetBusinessTypePriceSetById(model.BusinessTypePriceSet);
                    model.Factorrelation = new FactorRelation();
                    model.Factorrelation.BusinessTypeId = model.BusinessTypePriceSet.BusinessType.Id;
                    //价格因素一览
                    model.PriceFactor = priceService.GetRelatedPrice(model.Factorrelation);

                    break;

                default:
                    break;
            }
            
        }

        /// <summary>
        /// 方法名称: InitDataPriceTypeMember
        /// 功能概要: 会员卡价格页面初始化显示
        /// 作    者: 麻少华
        /// 创建时间: 2007-9-19
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="intAction"></param>
        public virtual void InitDataPriceTypeMember(int intAction)
        {
            switch (intAction)
            {
                case Constants.ACTION_INIT:
                    //初始化业务类型Combox
                    model.BusinessTypeList = masterDataService.GetBusinessTypes();
                    //初始化卡级别Combox
                    model.MemberCardLevelList = masterDataService.GetMemberCardLevels();
                    //价格因素一览
                    model.PriceFactor = masterDataService.GetPriceFactors();
                    //价格一览(此处先保留,目前页面初始化时使用自定义查询的方法来实现)
                    //model.BusinessTypePriceSetList = priceService.GetBusinessTypePriceSetList();
                    break;
                case Constants.ACTION_SEARCH:
                    //初始化业务类型Combox
                    model.BusinessTypeList = masterDataService.GetBusinessTypes();
                    //初始化卡级别Combox
                    model.MemberCardLevelList = masterDataService.GetMemberCardLevels();
                    //价格因素一览
                    model.PriceFactor = masterDataService.GetPriceFactors();
                    break;
                case Constants.ACTION_INSERT:
                    //初始化业务类型Combox
                    model.BusinessTypeList = masterDataService.GetBusinessTypes();
                    //价格因素一览
                    model.PriceFactor = masterDataService.GetPriceFactors();
                    break;
                case Constants.ACTION_UPDATE:
                    //初始化业务类型Combox
                    model.BusinessTypeList = masterDataService.GetBusinessTypes();
                    //初始化卡级别Combox
                    model.MemberCardLevelList = masterDataService.GetMemberCardLevels();
                    //价格因素一览
                    model.PriceFactor = masterDataService.GetPriceFactors();
                    break;
                case Constants.ACTION_DELETE:
                    //初始化业务类型Combox
                    model.BusinessTypeList = masterDataService.GetBusinessTypes();
                    //初始化卡级别Combox
                    model.MemberCardLevelList = masterDataService.GetMemberCardLevels();
                    //价格因素一览
                    model.PriceFactor = masterDataService.GetPriceFactors();
                    break;
            }
        }

        /// <summary>
        /// 方法名称: InitDataPriceTypeTrade
        /// 功能概要: 行业价格页面初始化显示
        /// 作    者: 麻少华
        /// 创建时间: 2007-9-25
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="flag"></param>
        public virtual void InitDataPriceTypeTrade(int intAction)
        {
            switch (intAction)
            {
                case Constants.ACTION_INIT:
                    //初始化业务类型Combox
                    model.BusinessTypeList = masterDataService.GetBusinessTypes();
                    //初始化行业Combox
                    model.MasterTrade = masterDataService.GetMasterTrade();
                    //价格因素一览
                    model.PriceFactor = masterDataService.GetPriceFactors();
                    model.SecondaryTradeList = new List<SecondaryTrade>();
                    foreach(MasterTrade mt in model.MasterTrade)
                    {
                        foreach (SecondaryTrade st in mt.SecondaryTradeList)
                        {
                            model.SecondaryTradeList.Add(st);
                        }
                    }
                    //价格一览
                    //model.BusinessTypePriceSetList = priceService.GetBusinessTypePriceSetList();
                    break;
                //case Constants.ACTION_SEARCH:
                //    //初始化业务类型Combox
                //    model.BusinessTypeList = masterDataService.GetBusinessTypes();
                //    //初始化卡类型Combox
                //    model.MemberCardLevelList = masterDataService.GetMemberCardLevels();
                //    break;
                //case Constants.ACTION_INSERT:
                //    //初始化业务类型Combox
                //    model.BusinessTypeList = masterDataService.GetBusinessTypes();
                //    //价格因素一览
                //    model.PriceFactor = masterDataService.GetPriceFactors();
                //    break;
                //case Constants.ACTION_DELETE:
                //    break;
            }
        }

        /// <summary>
        /// 方法名称: InitDataPriceTypeSpecial
        /// 功能概要: 特殊会员价格页面初始化显示
        /// 作    者: 麻少华
        /// 创建时间: 2007-9-25
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="flag"></param>
        public virtual void InitDataPriceTypeSpecial(int intAction)
        {
            switch (intAction)
            {
                case Constants.ACTION_INIT:
                    //初始化业务类型Combox
                    model.BusinessTypeList = masterDataService.GetBusinessTypes();
                    //价格因素一览
                    model.PriceFactor = masterDataService.GetPriceFactors();
                    //价格一览
                    //model.BusinessTypePriceSetList = priceService.GetBusinessTypePriceSetList();
                    break;
            }
        }

        /// <summary>
        /// 方法名称: InitCustomQuery
        /// 功能概要: 初始化自定义查询
        /// 作    者: 麻少华
        /// 创建时间: 2007-9-19
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="model"></param>
        public virtual void InitCustomQuery(BusinessTypePriceSetModel model)
        {
            model.BusinessTypePriceSetList = priceService.GetBusinessTypePriceSetListCustomQuery(model.BusinessTypePriceSet);
            model.RecordCount = priceService.GetBusinessTypePriceSetListCustomQueryCount(model.BusinessTypePriceSet);
        }

        /// <summary>
        /// 不论有没有设置会员或者行业价格,都按条件指定条件查出来.取行
        /// </summary>
        /// <param name="businessTypePriceSet"></param>
        /// <returns></returns>
        public virtual void GetAllBusinessTypePriceSetList(BusinessTypePriceSetModel model)
        {
            model.BusinessTypePriceSetList = priceService.GetAllBusinessTypePriceSetListCustomQuery(model.BusinessTypePriceSet);
        }

        /// <summary>
        /// 设置过的会员或者行业价格,都按条件指定条件查出来.取行
        /// </summary>
        /// <param name="businessTypePriceSet"></param>
        /// <returns></returns>
        public virtual void GetOnlyBusinessTypePriceSetList(BusinessTypePriceSetModel model)
        {
            model.BusinessTypePriceSetList = priceService.GetOnlyBusinessTypePriceSetListCustomQuery(model.BusinessTypePriceSet);
        }

		/// <summary>
		/// 设置过的会员或者行业价格,都按条件指定条件(不分页)
		/// </summary>
		public void GetOnlyBusinessTypePriceSets()
		{
			model.BusinessTypePriceSetList = priceService.GetOnlyBusinessTypePriceSetList(model.BusinessTypePriceSet);
		}


        /// <summary>
        /// 不论有没有设置会员或者行业价格,都按条件指定条件查出来.取行数量
        /// </summary>
        /// <param name="businessTypePriceSet"></param>
        /// <returns></returns>
        public virtual long GetAllBusinessTypePriceSetListCount(BusinessTypePriceSetModel model)
        {
            return priceService.GetAllBusinessTypePriceSetListCustomQueryCount(model.BusinessTypePriceSet);
        }

        /// <summary>
        /// 设置过的会员或者行业价格,都按条件指定条件查出来.取行
        /// </summary>
        /// <param name="businessTypePriceSet"></param>
        /// <returns></returns>
        public virtual long GetOnlyBusinessTypePriceSetListCount(BusinessTypePriceSetModel model)
        {
            return priceService.GetOnlyBusinessTypePriceSetListCustomQueryCount(model.BusinessTypePriceSet);
        }

        /// <summary>
        /// 方法名称: InitDataSelectPrice
        /// 功能概要: 选择价格页面初始化
        /// 作    者: 麻少华
        /// 创建时间: 2007-9-28
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        public virtual void InitDataSelectPrice()
        {
            model.BusinessTypeList = masterDataService.GetBusinessTypes();
        }

        /// <summary>
        /// 方法名称: InitDataSelectPriceNext
        /// 功能概要: 选择价格下一步页面初始化
        /// 作    者: 麻少华
        /// 创建时间: 2007-9-30
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        public virtual void InitDataSelectPriceNext(BaseBusinessTypePriceSetModel basModel, int intPageType)
        {
            //价格因素一览
            basModel.PriceFactor = masterDataService.GetPriceFactors();
            //价格因素
            basModel.BaseBusinessTypePriceSetList = priceService.GetBaseBusinessTypePriceSetListCustomQuery(basModel.BaseBusinessTypePriceSet);
            switch (intPageType)
            {
                case 1:
                    model.MemberCardLevelList = masterDataService.GetMemberCardLevels();
                    break;
                case 2:
                    model.MasterTrade = masterDataService.GetMasterTrade();
                    break;
                case 3:
                    model.MemberCardList = searchMemberCardService.GetMemberCardList();
                    break;
                default:
                    break;
            }

        }

        /// <summary>
        /// 方法名称: GetActiveRelation
        /// 功能概要: 获得因素以及因素的值
        /// 作    者: 麻少华
        /// 创建时间: 2007-9-30
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        public virtual void GetActiveRelation()
        {
            model.PriceFactor = priceService.GetRelatedPrice(model.Factorrelation);
        }

        public void GetPriceFactor()
        {
            model.PriceFactor = masterDataService.GetPriceFactors();
        }

        /// <summary>
        /// 方法名称: DeleteMembercardPrice
        /// 功能概要: 删除会员价格
        /// 作    者: 张晓林
        /// 创建时间: 2010年1月29日17:35:39
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        public void DeleteMembercardPrice()
        {
            priceService.DeleteMembercardPrice(model.BusinessTypePriceSetList);
        }

         /// <summary>
        /// 方法名称: UpdateMembercardPrice
        /// 功能概要: 编辑会员价格
        /// 作    者: 张晓林
        /// 创建时间: 2010年1月30日15:39:54
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        public void UpdateMembercardPrice() 
        {
            priceService.UpdateMembercardPrice(model.BusinessTypePriceSet);
        }

		#region 批量修改会员卡价格

		/// <summary>
		/// 批量修改门市价格
		/// </summary>
		public void BatchUpdatePrice()
		{
			priceService.UpdateBusinessTypePrice(model.BusinessTypePriceSetList);
		}

		#endregion
	}
}
