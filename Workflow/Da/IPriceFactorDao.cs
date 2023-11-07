using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
    /// 名    称:IPriceFactorDao
    /// 功能概要:价格因素接口
    /// 作    者:
    /// 创建时间:
    /// 修正履历:
    /// 修正时间:
	/// </summary>
    public interface IPriceFactorDao : IDaoBase<PriceFactor>
    {
        /// <summary>
        /// 提取可使用因素
        /// 付强
        /// </summary>
        /// <returns></returns>
        IList<PriceFactor> SelectByUsed();
        /// <summary>
        /// 提取因素在某个业务类型下的设置情况
        /// MSH
        /// </summary>
        /// <returns></returns>
        IList<PriceFactor> SelectPriceFactorSetList(PriceFactor priceFactor);

        /// <summary>
        /// 方法名称: SelectUsedPriceFactor
        /// 功能概要: 获取当前正在使用的价格因素
        /// 作    者: 陈汝胤
        /// 创建时间: 2009-1-9
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        IList<PriceFactor> SelectUsedPriceFactor(long businessTypeId);

        /// <summary>
        /// 名    称: SearchPriceFactor
        /// 功能概要: 获取所有价格因素列表
        /// 作    者：张晓林
        /// 创建时间: 2009年5月6日17:38:56
        /// 修正时间:
        /// </summary>
        IList<PriceFactor> SearchPriceFactor(PriceFactor priceFactor);

        /// <summary>
        /// 名    称: SearchPriceFactorRowCount
        /// 功能概要: 获取所有价格因素记录数
        /// 作    者：张晓林
        /// 创建时间: 2009年5月6日17:38:56
        /// 修正时间:
        /// </summary>
        long SearchPriceFactorRowCount(PriceFactor priceFactor);

        /// <summary>
        /// 名    称：CheckPriceFactorIsUse
        /// 功能概要: 检查价格因素是否正在使用
        /// 作    者：张晓林
        /// 创建时间: 2009年5月12日15:29:25
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        long CheckPriceFactorIsUse(long priceFactorId);

        /// <summary>
        /// 名    称: GetPriceFactorDetail
        /// 功能概要: 获取价格因素详情
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月12日16:00:46
        /// 修正履历：
        /// 修正时间:
        /// </summary>
        PriceFactor GetPriceFactorDetail(long priceFactorId);

        /// <summary>
        /// 名    称: GetPriceFactorValueList
        /// 功能概要: 根据依赖关系Id获取该因素下的所有值
        /// 作    者: 张晓林
        /// 创建时间: 2009年7月15日9:37:25
        /// 修正履历：
        /// 修正时间:
        /// </summary>
        IList<PriceFactor> GetPriceFactorValueList(PriceFactor priceFactor);

        /// <summary>
        /// 名    称: SelectAllPriceFactorList
        /// 功能概要: 获取所有价格因素列表
        /// 作    者: 张晓林
        /// 创建时间: 2010年4月19日11:06:50
        /// 修正履历：
        /// 修正时间:
        /// </summary>
        /// <returns></returns>
        IList<PriceFactor> SelectAllPriceFactorList();
    }
}
