using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// 名     称:IFactorValueDao
    /// 功能概要:因素值接口
    /// 作    者:
    /// 创建时间:
    /// 修正履历:
    /// 修正时间:
	/// </summary>
    public interface IFactorValueDao : IDaoBase<FactorValue>
    {
        IList<FactorValue> GetFactorValueListByPriceFactor(PriceFactor priceFactor);
        string GetFactorValueByFactorValueId(PriceFactor priceFactor, bool common);

        /// <summary>
        /// 名    称: SearchFactorValue
        /// 功能概要: 获取所有因素值列表
        /// 作    者：张晓林
        /// 创建时间: 2009年5月6日15:01:35
        /// 修正时间:
        /// </summary>
        IList<FactorValue> SearchFactorValue(FactorValue factorValue);

        /// <summary>
        /// 名    称: SearchFactorValueRowCount
        /// 功能概要: 获取所有因素值记录数
        /// 作    者：张晓林
        /// 创建时间: 2009年5月6日15:01:35
        /// 修正时间:
        /// </summary>
        long SearchFactorValueRowCount(FactorValue factorValue);

        /// <summary>
        /// 名    称: GetLastFactorValueByPriceFactorId
        /// 功能概要: 根据价格因素Id获取上一个Value,排序号
        /// 作    者：张晓林
        /// 创建时间: 2009年5月6日16:27:26
        /// 修正时间:
        /// </summary>
        FactorValue GetLastFactorValueByPriceFactorId(long priceFactorId);

        /// <summary>
        /// 名    称: GetLastFactorValueById
        /// 功能概要: 根据价格因素值Id Value,排序号
        /// 作    者：张晓林
        /// 创建时间: 2009年5月6日16:27:26
        /// 修正时间:
        /// </summary>
        FactorValue GetLastFactorValueById(long factorValueId); 
    }
}
