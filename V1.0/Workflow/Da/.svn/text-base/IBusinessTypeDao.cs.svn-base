using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table BUSINESS_TYPE 对应的Dao 接口
	/// </summary>
    public interface IBusinessTypeDao : IDaoBase<BusinessType>
    {
        //IList<PriceFactor> GetPriceFactorListByBusinessTypeId(long id);
        IList<BusinessType> SelectCustomerQueryBusinessTypeList(BusinessType businessType);
        /// <summary>
        /// 在设置界面上,不论价格因素是否使用,都显示
        /// </summary>
        /// <param name="businessType"></param>
        /// <returns></returns>
        IList<BusinessType> SelectCustomerQueryBusinessTypeList_Set(BusinessType businessType);
        /// <summary>
        /// 指定编号的业务类型是否能删除.如果不能返回BusinessType类型数据,否则无数据
        /// </summary>
        /// <param name="businessId">要检验的业务类型ID</param>
        /// <returns></returns>
        /// <remarks>
        /// 日期:2008-11-06
        /// 朱静程
        ///</remarks>
        IList<BusinessType> DeleteCheck(long businessId);

        /// <summary>
        /// 名    称：GetBusinessTypeList
        /// 功能概要：获取业务类型列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年4月28日17:26:13
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="businessType"></param>
        /// <returns></returns>
        IList<BusinessType> GetBusinessTypeList(BusinessType businessType);


        /// <summary>
        /// 名    称：GetBusinessTypeListRowCount
        /// 功能概要：获取业务类型记录数
        /// 作    者: 张晓林
        /// 创建时间: 2009年4月29日11:26:27
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="businessType"></param>
        /// <returns></returns>
        long GetBusinessTypeListRowCount(BusinessType businessType);

        /// <summary>
        /// 名    称：GetAllBusinessTypeList
        /// 功能概要: 获取业务类型列表
        /// 作    者：张晓林
        /// 创建时间: 2009年4月30日9:45:47
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        IList<BusinessType> GetAllBusinessTypeList(); 

         /// <summary>
        /// 名    称：CheckBusinessTyIsUse
        /// 功能概要: 检查业务类型是否正在使用
        /// 作    者：张晓林
        /// 创建时间: 2009年4月30日15:35:42
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        long CheckBusinessTyIsUse(long businessTypeId);
    }
}
