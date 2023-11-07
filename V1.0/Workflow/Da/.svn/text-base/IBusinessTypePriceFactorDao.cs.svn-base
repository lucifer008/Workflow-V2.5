using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// 名     称: IBusinessTypePriceFactorDao
    /// 功能概要: 业务类型包含的价格因素接口
    /// 作    者:
    /// 创建时间:
    /// 修正履历:
    /// 修正时间:
	/// </summary>
    public interface IBusinessTypePriceFactorDao : IDaoBase<BusinessTypePriceFactor>
    {
        void DeleteByBusinessTypeId(long id);

        #region//业务类型包含的价格因素

        /// <summary>
        /// 名    称: SearchBusinessTypePriceFactor
        /// 功能概要: 获取业务类型包含的价格因素列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月13日10:01:27
        /// 修正履历：
        /// 修正时间:
        /// </summary>
        IList<BusinessTypePriceFactor> SearchBusinessTypePriceFactor();

        /// <summary>
        /// 名    称: SearchBusinessTypePriceFactor
        /// 功能概要: 获取业务类型包含的价格因素列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月13日10:01:27
        /// 修正履历：
        /// 修正时间:
        /// </summary>
        IList<BusinessTypePriceFactor> SearchBusinessTypePriceFactor(long businessTypeId);

        /// <summary>
        /// 名    称: DeleteBusinessTypePriceFactorByBusinessTypeId
        /// 功能概要: 根据业务类型Id删除与价格因素之间的依赖 
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月13日10:01:27
        /// 修正履历：
        /// 修正时间:
        /// </summary>
        void DeleteBusinessTypePriceFactorByBusinessTypeId(long businessTypeId);

        /// <summary>
        /// 名    称: CheckBusinessTypePriceFactorIsExist
        /// 功能概要: 根据业务类型Id和价格因素Id是否存在之间的依赖 
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月13日14:54:39
        /// 修正履历：
        /// 修正时间:
        /// </summary>
        bool CheckBusinessTypePriceFactorIsExist(BusinessTypePriceFactor businessTypePriceFactor);
        #endregion
    }
}
