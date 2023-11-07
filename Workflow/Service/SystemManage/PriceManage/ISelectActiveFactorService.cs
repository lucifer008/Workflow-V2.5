using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
/// <summary>
/// 名    称: ISelectActiveFactorService
/// 功能概要: 价格因素 接口
/// 作    者: 付强
/// 创建时间: 2007-9-9
/// 修 正 人: 陈汝胤
/// 修正时间: 2009-1-21
/// 修正描述: 代码整理
/// </summary>

namespace Workflow.Service.SystemManege.PriceManage
{
    public interface ISelectActiveFactorService
    {
		#region 业务类型

		/// <summary>
		/// 业务类型
		/// </summary>
		/// <returns>业务类型列表</returns>
		/// <remarks>
		/// 作    者: 付强
		/// 创建时间: 2007-9-9
		/// </remarks>
		IList<BusinessType> GetbusinessType();

		#endregion

		#region 机器

		/// <summary>
		/// 业务类型
		/// </summary>
		/// <returns>机器列表</returns>
		/// <remarks>
		/// 作    者: 付强
		/// 创建时间: 2007-9-9
		/// </remarks>
		IList<Machine> GetMachine();

		#endregion

		#region 机器类型

		/// <summary>
		/// 机器类型
		/// </summary>
		/// <returns>机器类型列表</returns>
		/// <remarks>
		/// 作    者: 付强
		/// 创建时间: 2007-9-9
		/// </remarks>
		IList<MachineType> GetMachineType();
		#endregion

		#region 印制要求

		/// <summary>
		/// 印制要求
		/// </summary>
		/// <returns>印制要求列表</returns>
		/// <remarks>
		/// 作    者: 付强
		/// 创建时间: 2007-9-9
		/// </remarks>
		IList<PrintDemand> GetPrintDemand();
		#endregion

		#region 印制要求明细

		/// <summary>
		/// 印制要求明细
		/// </summary>
		/// <returns>印制要求明细列表</returns>
		/// <remarks>
		/// 作    者: 付强
		/// 创建时间: 2007-9-9
		/// </remarks>
		IList<PrintDemandDetail> GetPrintDemandDetail();
		#endregion

		#region 制作要求

		/// <summary>
		/// 制作要求
		/// </summary>
		/// <returns>制作要求列表</returns>
		/// <remarks>
		/// 作    者: 付强
		/// 创建时间: 2007-9-9
		/// </remarks>
		IList<PrintRequireDetail> GetPrintRequireDetail();
		#endregion

		#region 获取所有价格因素

		/// <summary>
		/// 获取所有价格因素
		/// </summary>
		/// <returns>价格因素列表</returns>
		/// <remarks>
		/// 作    者: 付强
		/// 创建时间: 2007-9-9
		/// </remarks>
		IList<PriceFactor> GetPriceFactor();
		#endregion

		#region 获取所有纸型

		/// <summary>
		/// 获取所有纸型
		/// </summary>
		/// <returns>纸型列表</returns>
		/// <remarks>
		/// 作    者: 付强
		/// 创建时间: 2007-9-9
		/// </remarks>
		IList<PaperType> GetPaperType();
		#endregion

		#region 获取所有纸质

		/// <summary>
		/// 获取所有纸质
		/// </summary>
		/// <returns>纸质列表</returns>
		/// <remarks>
		/// 作    者: 付强
		/// 创建时间: 2007-9-9
		/// </remarks>
		IList<PaperSpecification> GetPaperSpecification();
		#endregion

		#region 获取所有单位

		/// <summary>
		/// 获取所有单位
		/// </summary>
		/// <returns>单位列表</returns>
		/// <remarks>
		/// 作    者: 付强
		/// 创建时间: 2007-9-9
		/// </remarks>
		IList<Unit> GetUnits();
		#endregion

		#region 获取因素关系

		/// <summary>
		/// 获取因素关系
		/// </summary>
		/// <returns>因素关系列表</returns>
		/// <remarks>
		/// 作    者: 付强
		/// 创建时间: 2007-9-9
		/// </remarks>
		IList<FactorRelation> GetFactorRelation();
		#endregion

		#region 获取因素关系的值

		/// <summary>
		/// 获取因素关系的值
		/// </summary>
		/// <returns>因素关系的值列表</returns>
		/// <remarks>
		/// 作    者: 付强
		/// 创建时间: 2007-9-9
		/// </remarks>
		IList<FactorRelationValue> GetFactorRelationValue();
		#endregion

		#region 获取活动因素的值

		/// <summary>
		/// 获取活动因素的值
		/// </summary>
		/// <returns>活动因素的值列表</returns>
		/// <remarks>
		/// 作    者: 付强
		/// 创建时间: 2007-9-9
		/// </remarks>
		IList<FactorValue> GetFactorValue();
		#endregion

		#region 检查指定的字符串是否为空

		/// <summary>
		/// 名    称: GetFactorValueListByFactorRelation
		/// 功能概要: 检查指定的字符串是否为空。
		/// 作    者: 付强
		/// 创建时间: 2007-9-16
		/// 修正履历:
		/// 修正时间:
		/// </summary>
		/// <param name="factorRelation">GetRelatedPriceFactorBySourcePriceFactor返回的每一个对象</param>
		/// <returns>对应的因素值的列表</returns>
		IList<FactorRelation> GetRelatedPriceFactorBySourcePriceFactor(FactorRelation factorRelation);
		#endregion

		#region 检查指定的字符串是否为空

		/// <summary>
		/// 名    称: GetFactorValueListByFactorRelation
		/// 功能概要: 检查指定的字符串是否为空。
		/// 作    者: 付强
		/// 创建时间: 2007-9-16
		/// 修正履历:
		/// 修正时间:
		/// </summary>
		/// <param name="factorRelation">GetRelatedPriceFactorBySourcePriceFactor返回的每一个对象</param>
		/// <returns>对应的因素值的列表</returns>
		IList<FactorValue> GetFactorValueListByFactorRelation(FactorRelation factorRelation);
		#endregion

		#region MyRegion

		IList<PriceFactor> GetRelatedPrice(FactorRelation factorRelation);

		#endregion
    }
}
