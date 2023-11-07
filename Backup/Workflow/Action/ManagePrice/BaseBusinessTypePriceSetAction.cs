using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Workflow.Service;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Action.Model;
using Workflow.Service.SystemManege.PriceManage;
//using Workflow.Service.SystemManege.PriceManage;
/// <summary>
/// 名    称: Workflow.Action.BaseBusinessTypePriceSetAction
/// 功能概要: 门市价格的显示/增加/修改/删除
/// 作    者: 麻少华
/// 创建时间: 2007-9-19
/// 修 正 人: 陈汝胤
/// 修正时间: 2009-1-21
/// 修正描述: 代码整理
/// </summary>

namespace Workflow.Action
{
    public class BaseBusinessTypePriceSetAction
    {
        #region 注入
        /// <summary>
        /// 价格管理
        /// </summary>
        private IPriceService priceService;
        public IPriceService PriceService
        {
            set { priceService = value; }
        }
        /// <summary>
        /// 基本信息管理
        /// </summary>
        private IMasterDataService masterDataService;
        public IMasterDataService MasterDataService
        {
            set { masterDataService = value; }
        }

        /// <summary>
        /// 选择活动因素
        /// </summary>
        private ISelectActiveFactorService selectActiveFactorService;
        public ISelectActiveFactorService SelectActiveFactorService
        {
            set { selectActiveFactorService = value; }
        } 
        #endregion

        #region 私有成员变量
        private BaseBusinessTypePriceSetModel model=new BaseBusinessTypePriceSetModel();
        public BaseBusinessTypePriceSetModel Model
        {
            get { return model; }
        }
        #endregion

		#region 门市价格的增加
		
		/// <summary>
        /// 方法名称: Add
        /// 功能概要: 门市价格的增加
        /// 作    者: 麻少华
        /// 创建时间: 2007-9-19
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="model"></param>
        public void Add(BaseBusinessTypePriceSetModel model)
        {
            priceService.InsertBaseBusinessTypePriceSet(model.BaseBusinessTypePriceSetList);
		}

        /// <summary>
        /// 方法名称: AddBaseBusinessTypePrice
        /// 功能概要: 门市价格批量增加
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月23日15:15:13
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        public void AddBaseBusinessTypePrice() 
        {
            priceService.AddBaseBusinessTypePrice(model.BaseBusinessTypePriceSet);
        }
		#endregion

		#region 门市价格的更新
		
		/// <summary>
        /// 方法名称: Update
        /// 功能概要: 门市价格的更新
        /// 作    者: 麻少华
        /// 创建时间: 2007-9-19
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="model"></param>
        public void Update(BaseBusinessTypePriceSetModel model)
        {
            priceService.UpdateBaseBusinessTypePriceSet(model.BaseBusinessTypePriceSetList);
		}

		#endregion

		#region 门市价格的删除
		
		/// <summary>
        /// 方法名称: Delete
        /// 功能概要: 门市价格的删除
        /// 作    者: 麻少华
        /// 创建时间: 2007-9-19
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="model"></param>
        public void Delete(BaseBusinessTypePriceSetModel model)
        {
            priceService.DeleteBaseBusinessTypePriceSet(model.BaseBusinessTypePriceSet);
		}

        /// <summary>
        /// 方法名称: BatchDeletePrice
        /// 功能概要: 门市价格批量删除
        /// 作    者: 张晓林
        /// 创建时间: 2010年1月15日11:04:04
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="model"></param>
        public void BatchDeletePrice()
        {
            priceService.BatchDeletePrice(model.StrBaseBusinessTypePriceList);
        }
		#endregion

		#region 门市价格一览页面初始化显示
		
		/// <summary>
        /// 方法名称: InitData
        /// 功能概要: 门市价格一览页面初始化显示
        /// 作    者: 麻少华
        /// 创建时间: 2007-9-19
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        public void InitData()
        {
            model.BusinessTypeList = masterDataService.GetBusinessTypes();
            BusinessType item = new BusinessType();
            item.Id = long.Parse(Constants.SELECT_VALUE_NOT_SELECTED_KEY);
            item.Name = Constants.SELECT_VALUE_NOT_SELECTED_TEXT;
            bool isExist = false;
            foreach (BusinessType bt in model.BusinessTypeList)
            {
                if (bt.Name == Constants.SELECT_VALUE_NOT_SELECTED_TEXT)
                {
                    isExist = true;
                    break;
                }
            }
            if (!isExist)
            {
                model.BusinessTypeList.Add(item);
            }

            model.PriceFactor = masterDataService.GetPriceFactors();
            model.BaseBusinessTypePriceSetList = priceService.GetBaseBusinessTypePriceSetList();
		}

		#endregion

        #region //获取门市价格数据
        /// <summary>
        /// 方法名称: SearchSalesroomPriceInfo
        /// 功能概要: 获取门市价格数据(分页)
        /// 作    者: 张晓林
        /// 创建时间: 2009年3月5日13:34:36
        /// 修正履历: 
        /// 修正时间:
        /// </summary>
        public void SearchSalesroomPriceInfo(int currentPageIndex) 
        {
            model.BusinessTypeList = masterDataService.GetBusinessTypes();
            model.PriceFactor = masterDataService.GetPriceFactors();
            model.BaseBusinessTypePriceSet.EveryPageRows = Constants.ROW_COUNT_FOR_PAGER;
            model.BaseBusinessTypePriceSet.CurrentPageID = currentPageIndex - 1;
            model.BaseBusinessTypePriceSetList = priceService.GetBaseBusinessTypePriceSetList(model.BaseBusinessTypePriceSet);
        }
        /// <summary>
        /// 方法名称: SearchBaseBuinessTypeSetInfoRowCount
        /// 功能概要: 获得门市价格设置记录数
        /// 作    者: 张晓林
        /// 创建时间: 2009年3月5日13:40:53
        /// 修正履历: 
        /// 修正时间:
        /// </summary>
        /// <param name="baseBusinessTypePriceSet"></param>
        /// <returns></returns>
        public long SearchBaseBuinessTypeSetInfoRowCount(BaseBusinessTypePriceSet baseBusinessTypePriceSet) 
        {
            return priceService.SearchBaseBuinessTypeSetInfoRowCount(baseBusinessTypePriceSet);
        }
        #endregion

        #region 门市价格设置初始化显示

        /// <summary>
        /// 方法名称: InitDataPriceSet
        /// 功能概要: 门市价格设置初始化显示
        /// 作    者: 麻少华
        /// 创建时间: 2007-9-19
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        public void InitDataPriceSet(BaseBusinessTypePriceSetModel model)
        {           
            //初始化业务类型Combox
            model.BusinessTypeList = masterDataService.GetBusinessTypes();
            //获取价格一览
            model.BaseBusinessTypePriceSet = priceService.GetBaseBusinessTypePriceSetById(model.BaseBusinessTypePriceSet);
            model.Factorrelation = new FactorRelation();
            model.Factorrelation.BusinessTypeId = model.BaseBusinessTypePriceSet.BusinessType.Id;
            //价格因素一览
            model.PriceFactor = priceService.GetRelatedPrice(model.Factorrelation);
		}

		#endregion

		#region 当在追加业务类型页面选择业务类型的时候,重新提取数据
		
		/// <summary>
        /// 方法名称: ReInitData
        /// 功能概要: 当在追加业务类型页面选择业务类型的时候,重新提取数据
        /// 作    者: 麻少华
        /// 创建时间: 2007-9-24
        /// 修正履历: 
        ///             2008-11-10 修改发票,会员
        /// 修正时间: 
        /// </summary>
        public void ReInitData(BaseBusinessTypePriceSetModel model)
        {
            model.BusinessTypeList = masterDataService.GetBusinessTypes();
            //model.Factorrelation.PriceFactorId = model.Factorrelation.BusinessTypeId;

            //model.PriceFactor = selectActiveFactorService.GetRelatedPrice(model.Factorrelation);
            //foreach (BusinessType bt in model.BusinessTypeList)
            //{
            //    bt.PriceFactorList.Clear();
            //    //if (bt.Id == model.Factorrelation.BusinessTypeId)
            //    //{
            //    //    model.PriceFactor = bt.PriceFactorList;
            //    //    //break;
            //    //}
            //}
            model.PriceFactor = priceService.GetRelatedPrice(model.Factorrelation);
		}

		#endregion

		#region 追加价格时候初始化
		
		/// <summary>
        /// 方法名称: InitAddPriceData
        /// 功能概要: 追加价格时候初始化
        /// 作    者: 麻少华
        /// 创建时间: 2007-9-21
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        public void InitAddPriceData()
        {
            model.BusinessTypeList = masterDataService.GetBusinessTypes();
		}

		#endregion

		#region 初始化自定义查询
		
		/// <summary>
        /// 方法名称: InitCustomQuery
        /// 功能概要: 初始化自定义查询
        /// 作    者: 麻少华
        /// 创建时间: 2007-9-19
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="model"></param>
        public void InitCustomQuery(BaseBusinessTypePriceSetModel model)
        {
            //model.BusinessTypeList = masterDataService.GetBusinessTypes();
            //model.PriceFactor = masterDataService.GetPriceFactors();//业务类型标题
			//model.BaseBusinessTypePriceSetList = priceService.GetBaseBusinessTypePriceList(model.BaseBusinessTypePriceSet);
		}

		#endregion
		
		#region 带分页功能的获取数据查询

		/// <summary>
        /// 带分页功能的获取数据查询
        /// </summary>
        /// <param name="model"></param>
        /// <remarks>
        /// 创建时间:2008-11-08
        /// 朱静程
        /// 修正履历:
        /// </remarks>
        public void InitCustomQuery_Page()
        {
            //model.BusinessTypeList = masterDataService.GetBusinessTypes();
            //model.PriceFactor = masterDataService.GetPriceFactors();

            //model.BaseBusinessTypePriceSetList = priceService.GetBaseBusinessTypePriceSetListCustomQuery(model.BaseBusinessTypePriceSet);
            model.BaseBusinessTypePriceSetList = priceService.GetBaseBusinessTypePriceList(model.BaseBusinessTypePriceSet);
		}

		#endregion

		#region 获取只能条件的门市价格

		public void InitCustomerQuery()
		{
			//model.BusinessTypeList = masterDataService.GetBusinessTypes();
			model.BaseBusinessTypePriceSetList = priceService.GetBaseBusinessTypePrices(model.BaseBusinessTypePriceSet);
		}

		#endregion

		#region 批量修改门市价格

		/// <summary>
		/// 批量修改门市价格
		/// </summary>
		public void BatchUpdatePrice()
		{
			priceService.UpdateBaseBusinessTypePrice(model.BaseBusinessTypePriceSetList);
		}

		#endregion

		#region MyRegion

		public int GetBaseBusinessTypePriceSetListCustomQueryCount(BaseBusinessTypePriceSetModel model)
        {
            return priceService.GetBaseBusinessTypePriceSetListCustomQueryCount(model.BaseBusinessTypePriceSet);
		}

		#endregion

		#region 通过baseBusinessTypePriceSetId获取baseBusinessTypePriceSet信息
		
		/// <summary>
        /// 方法名称: GetBaseBusinessTypePriceSetById
        /// 功能概要: 通过baseBusinessTypePriceSetId获取baseBusinessTypePriceSet信息
        /// 作    者: 刘伟
        /// 创建时间: 2007-10-18
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="model"></param>
        public void GetBaseBusinessTypePriceSetById(BaseBusinessTypePriceSet baseBusinessTypePriceSet)
        {
            model.BaseBusinessTypePriceSet = priceService.GetBaseBusinessTypePriceSetById(baseBusinessTypePriceSet);
		}

		#endregion

		#region 获取价格因素
		
		/// <summary>
        /// 方法名称: GetPriceFactor
        /// 功能概要: 获取价格因素
        /// 作    者: 刘伟
        /// 创建时间: 2007-10-18
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        public void GetPriceFactor()
        {
			model.BusinessTypeList = masterDataService.GetBusinessTypes();
            model.PriceFactor = masterDataService.GetPriceFactors();
        }

		#endregion

    }
}
