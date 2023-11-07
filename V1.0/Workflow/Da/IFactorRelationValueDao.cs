using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
    /// <summary>
    /// 名     称:IFactorRelationValueDao
    /// 功能概要:因素依赖关系值接口
    /// 作    者:
    /// 创建时间:
    /// 修正履历:
    /// 修正时间:
    /// </summary>
    public interface IFactorRelationValueDao : IDaoBase<FactorRelationValue>
    {

        /// <summary>
        /// 名    称: SearchFactorRelationValue
        /// 功能概要: 获取因素依赖的关系值列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月18日11:10:17
        /// 修正履历：
        /// 修正时间:
        /// </summary>
        IList<FactorRelationValue> SearchFactorRelationValue(FactorRelationValue factorRelationValue);

        /// <summary>
        /// 名    称: SearchFactorRelationValueRowCount
        /// 功能概要: 获取因素依赖的关系值列表个数
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月18日11:10:17
        /// 修正履历：
        /// 修正时间:
        /// </summary>
        long SearchFactorRelationValueRowCount(FactorRelationValue factorRelationValue);

        /// <summary>
        /// 名    称: CheckFactorIsRelation
        /// 功能概要: 检查是否存在这样的依赖关系
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月25日15:26:24
        /// 修正履历：
        /// 修正时间:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        long CheckFactorIsRelation(FactorRelationValue factorRelationValue);

        ///// <summary>
        ///// 名    称: GetBusinessTypeRelationPriceFactorCount
        ///// 功能概要: 获取业务类型价格因素
        ///// 作    者: 张晓林
        ///// 创建时间: 2009年6月26日9:44:49
        ///// 修正履历：
        ///// 修正时间:
        ///// </summary>
        ///// <param name="condition"></param>
        ///// <returns></returns>
        //long GetBusinessTypeRelationPriceFactorCount(FactorRelationValue factorRelationValue);

        /// <summary>
        /// 名    称: GetFactorRelationId
        /// 功能概要: 获取价格因素依赖关系Id
        /// 作    者: 张晓林
        /// 创建时间: 2009年7月13日10:27:18
        /// 修正履历：
        /// 修正时间: 
        /// </summary>
        /// <param name="factorRelation"></param>
        /// <returns></returns>
        long GetFactorRelationId(FactorRelation factorRelation);

        /// <summary>
        /// 名    称: CheckFactorRelationValueIsExist
        /// 功能概要: 检查FactorRelationValue是否存在
        /// 作    者: 张晓林
        /// 创建时间: 2009年7月15日14:50:16
        /// 修正履历：
        /// 修正时间: 
        /// </summary>
        /// <param name="factorRelation"></param>
        /// <returns></returns>
        bool CheckFactorRelationValueIsExist(FactorRelationValue factorRelationValue);
    }
}
