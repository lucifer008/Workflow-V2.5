using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table COMPANY 对应的Dao 接口
	/// </summary>
    public interface ICompanyDao : IDaoBase<Company>
    {
        #region//公司信息维护
        /// <summary>
        /// 名    称：SearchCompany
        /// 功能概要：获取公司信息列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月9日13:24:38
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        IList<Company> SearchCompany(Company company);

        /// <summary>
        /// 名    称：SearchCompany
        /// 功能概要：获取公司信息列表记录数
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月9日13:24:38
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        long SearchCompanyRowCount(Company company);


        /// <summary>
        /// 名    称：CheckCompanyIsUsed
        /// 功能概要：检查公司是否正在使用
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月9日13:24:38
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        long CheckCompanyIsUsed(long companyId);
        #endregion
    }
}
