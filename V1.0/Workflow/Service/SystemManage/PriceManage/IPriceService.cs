using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Workflow.Da.Domain;
using Workflow.Da.Domain.Base;
/// <summary>
/// 名    称: IPriceService
/// 功能概要: 价格管理 接口
/// 作    者: 
/// 创建时间: 
/// 修 正 人: 陈汝胤
/// 修正时间: 2009-1-21
/// 修正描述: 代码整理
/// </summary>

namespace Workflow.Service.SystemManege.PriceManage
{
    /// <summary>
    /// 价格管理相关接口声明
    /// </summary>
   public interface IPriceService
   {
        #region 业务类型设置
        #region 获得因素的基本信息
        /// <summary>
        /// 功能概要: 获得因素的基本信息
        /// </summary>
        /// <returns></returns>
       IList<PriceFactor> GetPriceFactor();
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
        /// <param name="businessType">业务类型</param>
        /// <returns></returns>
        IList<BusinessTypePriceFactor> getBusinessTypePriceFactor();
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
        void InsertBusinessType(BusinessType businessType, IList<BusinessTypePriceFactor> businessTypePriceFactor);
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
        /// <param name="businessType">业务类型</param>
        /// <param name="businessTypePriceFactor">业务类型包含的价格因素</param>
        void UpdateBusinessType(BusinessType businessType, IList<BusinessTypePriceFactor> businessTypePriceFactor);
        #endregion

        #region 删除当前的业务类型
        /// <summary>
        /// 方法名称: DeleteBusinessType
        /// 功能概要: 删除当前的业务类型
        /// 作    者: 麻少华
        /// 创建时间: 2007-9-11
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="businessType">业务类型</param>
        
        void DeleteBusinessType(BusinessType businessType);
        #endregion

        #region 获得某一业务类型下价格因素的设置信息
        /// <summary>
        /// 方法名称: GetPriceFactorSetList
        /// 功能概要: 获得某一业务类型下价格因素的设置信息
        /// 作    者: 麻少华
        /// 创建时间: 2007-9-9
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="businessType">业务类型</param>
       IList<PriceFactor> GetPriceFactorSetList(BusinessType businessType);
        #endregion

        #region 获得业务类型一览
        /// <summary>
        /// 方法名称: GetBusinessTypeList
        /// 功能概要: 获得业务类型一览
        /// 作    者: 麻少华
        /// 创建时间: 2007-9-18
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <returns></returns>
        IList<BusinessType> GetBusinessTypeList();
        #endregion

        #region 业务类型自定义查询
        /// <summary>
        /// 方法名称: GetBusinessTypeListCustomQuery
        /// 功能概要: 
        /// 作    者: 麻少华
        /// 创建时间: 2007-9-18
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <returns></returns>
        IList<BusinessType> GetBusinessTypeListCustomQuery(BusinessType businessType);

        /// <summary>
        /// 显示设置时需要显示的信息
        /// </summary>
        /// <param name="businessType"></param>
        /// <returns></returns>
        IList<BusinessType> GetBusinessTypeListCustomQuery_Set(BusinessType businessType);

        #endregion
        #endregion

        #region 门市价格设置

        /// <summary>
        /// 方法名称: GetBaseBusinessTypePriceSetList
        /// 功能概要: 获得门市价格设置一览
        /// 作    者: 麻少华
        /// 创建时间: 2007-9-19
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <returns></returns>
        IList<BaseBusinessTypePriceSet> GetBaseBusinessTypePriceSetList();

        /// <summary>
        /// 方法名称: GetBaseBusinessTypePriceSetList
        /// 功能概要: 获得门市价格设置一览
        /// 作    者: 张晓林
        /// 创建时间: 2009年3月5日13:40:53
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <returns></returns>
        IList<BaseBusinessTypePriceSet> GetBaseBusinessTypePriceSetList(BaseBusinessTypePriceSet baseBusinessTypePriceSet);

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
        long SearchBaseBuinessTypeSetInfoRowCount(BaseBusinessTypePriceSet baseBusinessTypePriceSet);

        /// <summary>
        /// 方法名称: GetBaseBusinessTypePriceSetById
        /// 功能概要: 根据ID取得单条门市价格设置的信息
        /// 作    者: 麻少华
        /// 创建时间: 2007-9-26
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="baseBusinessTypePriceSet"></param>
        /// <returns></returns>
        BaseBusinessTypePriceSet GetBaseBusinessTypePriceSetById(BaseBusinessTypePriceSet baseBusinessTypePriceSet);
        /// <summary>
        /// 方法名称: GetBaseBusinessTypePriceSetListCustomQuery
        /// 功能概要: 获得门市价格设置一览(自定义查询)
        /// 作    者: 麻少华
        /// 创建时间: 2007-9-19
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="baseBusinessTypePriceSet"></param>
        /// <returns></returns>
        IList<BaseBusinessTypePriceSet> GetBaseBusinessTypePriceSetListCustomQuery(BaseBusinessTypePriceSet baseBusinessTypePriceSet);
        /// <summary>
        /// 方法名称: GetBaseBusinessTypePriceSetListCustomQuery
        /// 功能概要: 带分页功能的获得门市价格设置一览(自定义查询)
        /// 作    者: 朱静程
        /// 创建时间: 2008-11-08
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="baseBusinessTypePriceSet"></param>
        /// <returns></returns>
        IList<BaseBusinessTypePriceSet> GetBaseBusinessTypePriceSetListCustomQuery_Page(BaseBusinessTypePriceSet baseBusinessTypePriceSet);
        /// <summary>
        /// 方法名称: GetBaseBusinessTypePriceSetListCustomQuery
        /// 功能概要: 门市价格设置一览的总行数
        /// 作    者: 朱静程
        /// 创建时间: 2008-11-08
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="baseBusinessTypePriceSet"></param>
        /// <returns></returns>
        int GetBaseBusinessTypePriceSetListCustomQueryCount(BaseBusinessTypePriceSet baseBusinessTypePriceSet);


        /// <summary>
        /// 方法名称: InsertBaseBusinessTypePriceSet
        /// 功能概要: 追加门市价格设置
        /// 作    者: 麻少华
        /// 创建时间: 2007-9-19
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="baseBusinessTypePriceSetList"></param>
        void InsertBaseBusinessTypePriceSet(IList<BaseBusinessTypePriceSet> baseBusinessTypePriceSetList);

        /// <summary>
        /// 方法名称: AddBaseBusinessTypePrice
        /// 功能概要: 门市价格批量增加
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月23日15:15:13
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
       void AddBaseBusinessTypePrice(BaseBusinessTypePriceSet baseBusinessTypePriceSet);

        /// <summary>
        /// 方法名称: UpdateBaseBusinessTypePriceSet
        /// 功能概要: 更新门市价格设置
        /// 作    者: 麻少华
        /// 创建时间: 2007-9-19
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="baseBusinessTypePriceSetList"></param>
        void UpdateBaseBusinessTypePriceSet(IList<BaseBusinessTypePriceSet> baseBusinessTypePriceSetList);
        /// <summary>
        /// 方法名称: DeleteBaseBusinessTypePriceSet
        /// 功能概要: 删除门市价格设置
        /// 作    者: 麻少华
        /// 创建时间: 2007-9-19
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="baseBusinessTypePriceSet"></param>
        void DeleteBaseBusinessTypePriceSet(BaseBusinessTypePriceSet baseBusinessTypePriceSet);

        /// <summary>
        /// 方法名称: GetRelatedPrice
        /// 功能概要: 得到业务类型关联的价格因素以及价格因素的数值
        /// 作    者: 麻少华
        /// 创建时间: 2007-9-24
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="factorRelation"></param>
        /// <param name="businessType"></param>
        /// <returns></returns>
        IList<PriceFactor> GetRelatedPrice(FactorRelation factorRelation);
        #endregion

        #region 业务价格设置
        /// <summary>
        /// 方法名称: GetBusinessTypePriceSetList
        /// 功能概要: 获得业务价格设置一览
        /// 作    者: 麻少华
        /// 创建时间: 2007-9-19
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <returns></returns>
        IList<BusinessTypePriceSet> GetBusinessTypePriceSetList();

        /// <summary>
        /// 方法名称: GetBusinessTypePriceSetById
        /// 功能概要: 根据ID取得单条业务价格设置的信息
        /// 作    者: 麻少华
        /// 创建时间: 2007-9-26
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="businessTypePriceSet"></param>
        /// <returns></returns>
        BusinessTypePriceSet GetBusinessTypePriceSetById(BusinessTypePriceSet businessTypePriceSet);

        /// <summary>
        /// 方法名称: GetBusinessTypePriceSetListCustomQuery
        /// 功能概要: 获得业务价格设置一览(自定义查询)
        /// 作    者: 麻少华
        /// 创建时间: 2007-9-19
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="businessTypePriceSet);"></param>
        /// <returns></returns>
        IList<BusinessTypePriceSet> GetBusinessTypePriceSetListCustomQuery(BusinessTypePriceSet businessTypePriceSet);

        /// <summary>
        /// 不论是否经过价格设置,都显示
        /// </summary>
        /// <param name="businessTypePriceSet"></param>
        /// <returns></returns>
        IList<BusinessTypePriceSet> GetAllBusinessTypePriceSetListCustomQuery(BusinessTypePriceSet businessTypePriceSet);

        /// <summary>
        /// 经过会员或行业价格设置的
        /// </summary>
        /// <param name="businessTypePriceSet"></param>
        /// <returns></returns>
        IList<BusinessTypePriceSet> GetOnlyBusinessTypePriceSetListCustomQuery(BusinessTypePriceSet businessTypePriceSet);

       /// <summary>
        /// 获取BusinessTypePriceSet对应的会员卡级别或者行业名称
       /// </summary>
       /// <param name="bizPriceSet"></param>
       string GetTargetName(BusinessTypePriceSet bizPriceSet);

        /// <summary>
        /// 不论是否经过价格设置,都统计
        /// </summary>
        /// <param name="businessTypePriceSet"></param>
        /// <returns></returns>
        long GetAllBusinessTypePriceSetListCustomQueryCount(BusinessTypePriceSet businessTypePriceSet);


        /// <summary>
        /// 经过会员或行业价格设置的
        /// </summary>
        /// <param name="businessTypePriceSet"></param>
        /// <returns></returns>
        long GetOnlyBusinessTypePriceSetListCustomQueryCount(BusinessTypePriceSet businessTypePriceSet);



        /// <summary>
        /// 方法名称: InsertBusinessTypePriceSet
        /// 功能概要: 追加业务价格设置
        /// 作    者: 麻少华
        /// 创建时间: 2007-9-19
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="businessTypePriceSetList);"></param>
        void InsertBusinessTypePriceSet(IList<BusinessTypePriceSet> businessTypePriceSetList);
        /// <summary>
        /// 方法名称: UpdateBusinessTypePriceSet
        /// 功能概要: 更新业务价格设置
        /// 作    者: 麻少华
        /// 创建时间: 2007-9-19
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="businessTypePriceSetList);"></param>
        void UpdateBusinessTypePriceSet(IList<BusinessTypePriceSet> businessTypePriceSetList);
        /// <summary>
        /// 方法名称: DeleteBusinessTypePriceSet
        /// 功能概要: 删除业务价格设置
        /// 作    者: 麻少华
        /// 创建时间: 2007-9-19
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="businessTypePriceSet);"></param>
        void DeleteBusinessTypePriceSet(BusinessTypePriceSet businessTypePriceSet);
        #endregion

        #region 获取价格　付强
        /// <summary>
        /// 获取价格
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强　
        /// 创建时间: 2007-10-6
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        BaseBusinessTypePriceSet GetPrice(BaseBusinessTypePriceSet baseBusinessTypePriceSet);
        BusinessTypePriceSet GetPrice(BusinessTypePriceSet businessTypePriceSet);
        #endregion

        #region 获取数量段
        IList<AmountSegment> GetAmountSegmentList();
        #endregion

		#region 获取市场价格带分页
	
		/// <summary>
		/// 方法名称: GetBaseBusinessTypePriceList
		/// 功能概要: 获取市场价格带分页
		/// 作    者: 陈汝胤
		/// 创建时间: 2009-1-9
		/// 修正履历: 
		/// 修正时间: 
		/// </summary>
		IList<BaseBusinessTypePriceSet> GetBaseBusinessTypePriceList(BaseBusinessTypePriceSet baseBusinessTypePriceSet);

		#endregion

   }
}
