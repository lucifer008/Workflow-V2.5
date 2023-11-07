using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table FACTOR_RELATION 对应的Dao 接口
	/// </summary>
    public interface IFactorRelationDao : IDaoBase<FactorRelation>
    {
        /// <summary>
        /// 名    称: GetRelatedPriceFactorBySourcePriceFactor
        /// 功能概要: 根据业务类型ID和源因素ID获取相关的价格因素。
        /// 作    者: 祝新宾
        /// 创建时间: 2007-9-16
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="factorRelation">必须包含指定的业务类型ID和源因素ID</param>
        /// <returns>FactorRelationID及PriceFactorId2对应的信息</returns>
        IList<FactorRelation> GetRelatedPriceFactorBySourcePriceFactor(FactorRelation factorRelation);

        /// <summary>
        /// 名    称: GetFactorValueListByFactorRelation
        /// 功能概要: 根据因素及因素之间的约束关系获取目标因素的值。
        /// 作    者: 祝新宾
        /// 创建时间: 2007-9-16
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="factorRelation">GetRelatedPriceFactorBySourcePriceFactor返回的每一个对象</param>
        /// <returns>对应的因素值的列表</returns>
        IList<FactorValue> GetFactorValueListByFactorRelation(FactorRelation factorRelation);

        ///// <summary>
        ///// 名    称: GetFactorRelationValueByBusinessTypeId
        ///// 功能概要: 根据
        ///// 作    者: 
        ///// 创建时间: 
        ///// 修正履历:
        ///// 修正时间:
        ///// </summary>
        ///// <param name="factorRelation"></param>
        ///// <returns></returns>
        //IList<FactorRelation> GetFactorRelationValueByBusinessTypeId(FactorRelation factorRelation);

        #region//价格因素之间的依赖

        /// <summary>
        /// 名    称: SearchFactorRelation
        /// 功能概要: 获取因素之间的依赖列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月14日10:47:30
        /// 修正履历：
        /// 修正时间:
        /// </summary>
        IList<FactorRelation> SearchFactorRelation(FactorRelation factorRelation);


        /// <summary>
        /// 名    称: SearchFactorRelationRowCount
        /// 功能概要: 获取因素之间的依赖列表记录数
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月14日10:47:30
        /// 修正履历：
        /// 修正时间:
        /// </summary>
        long SearchFactorRelationRowCount(FactorRelation factorRelation);

        /// <summary>
        /// 名    称: CheckFactorRelationIsExist
        /// 功能概要: 检查是否存在FactorRelation
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月14日10:47:30
        /// 修正履历：
        /// 修正时间:
        /// </summary>
        bool CheckFactorRelationIsExist(FactorRelation factorRelation);

        /// <summary>
        /// 名    称: DeleteFactorRelationValue
        /// 功能概要: 删除FactorRelationValue
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月14日15:48:02
        /// 修正履历：
        /// 修正时间:
        /// </summary>
        void DeleteFactorRelationValue(long factorRelationId);

        /// <summary>
        /// 名    称: CheckFactorRelationIsUse
        /// 功能概要: 检查价格因素依赖关系是否正在使用
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月18日9:53:25
        /// 修正履历：
        /// 修正时间:
        /// </summary>
        long CheckFactorRelationIsUse(long factorRelationId);
        #endregion
    }
}
