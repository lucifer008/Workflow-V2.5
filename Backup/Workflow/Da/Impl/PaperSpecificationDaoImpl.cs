using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;
using System.Collections;

namespace Workflow.Da.Impl
{
    /// <summary>
    /// 名     称:PaperSpecificationDaoImpl
    /// 功能概要:IPaperSpecification接口实现
    /// 作    者:
    /// 创建时间:
    /// 修正履历:
    /// 修正时间:
    /// </summary>
    public class PaperSpecificationDaoImpl : Workflow.Da.Base.DaoBaseImpl<PaperSpecification>, IPaperSpecificationDao
    {
        #region //获取纸型数据
        /// <summary>
        /// 名    称: SearchPaperSecification
        /// 功能概要: 获取纸型列表
        /// 作    者：张晓林
        /// 创建时间: 2009年5月5日15:15:30
        /// 修正时间:
        /// </summary>
        public IList<PaperSpecification> SearchPaperSecification(PaperSpecification paperSpecification)
        {
            paperSpecification.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            paperSpecification.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<PaperSpecification>("PaperSpecification.SearchPaperSecification", paperSpecification);
        }

        /// <summary>
        /// 名    称: SearchPaperSecificationRowCount
        /// 功能概要: 获取纸型记录数 
        /// 作    者：张晓林
        /// 创建时间: 2009年5月5日15:15:30
        /// 修正时间:
        /// </summary>
        public long SearchPaperSecificationRowCount(PaperSpecification paperSpecification) 
        {
            return sqlMap.QueryForObject<long>("PaperSpecification.SearchPaperSecificationRowCount", paperSpecification);
        }
        #endregion

		#region 通过纸型名称获取纸型Id
		/// <summary>
		/// 名    称: SelectPaperSpecificationIdByName
		/// 功能概要: 通过纸型名称获取纸型
		/// 作    者：白晓宇
		/// 创建时间: 2010年5月7日
		/// 修正时间:
		/// </summary>
		/// <param name="name">纸型名称</param>
		public long SelectPaperSpecificationIdByName(string name)
		{
			User user = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser;

			Hashtable ht = new Hashtable();
			ht.Add("Name", name);
			ht.Add("BranchShopId", user.BranchShopId);
			ht.Add("CompanyId", user.CompanyId);

			return sqlMap.QueryForObject<long>("PaperSpecification.SelectPaperSpecificationIdByName", ht);
		}
		#endregion
	}
}
