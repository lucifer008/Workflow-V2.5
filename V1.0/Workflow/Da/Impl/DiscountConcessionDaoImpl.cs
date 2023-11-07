#region imports
using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;
using System.Collections;
using Workflow.Support;
#endregion

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table DISCOUNT_CONCESSION (打折的优惠活动) 对应的Dao 实现
	/// </summary>
    public class DiscountConcessionDaoImpl : Workflow.Da.Base.DaoBaseImpl<DiscountConcession>, IDiscountConcessionDao
    {

		#region 获取打折活动列表(分页)

		/// <summary>
		/// 获取打折活动列表(分页)
		/// </summary>
		/// <param name="beginRow">当前行</param>
		/// <param name="endRow">每页行数</param>
		/// <returns>打折活动列表</returns>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.5.9
		/// </remarks>
		public IList<DiscountConcession> GetAllDiscountConcession(int beginRow, int endRow)
		{
			Hashtable map = new Hashtable();
			map.Add("beginrow", beginRow);
			map.Add("endrow", endRow);
			map.Add("companyid", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
			map.Add("branchShopid", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
			return sqlMap.QueryForList<DiscountConcession>("DiscountConcession.GetAllDiscountConcession",map);
		}

		#endregion

		#region 获取所有打折活动的记录数

		/// <summary>
		/// 获取所有打折活动的记录数
		/// </summary>
		/// <returns>记录数</returns>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.5.11
		/// </remarks>
		public int GetAllDiscountConcessionCount()
		{
			Hashtable map = new Hashtable();
			map.Add("companyid", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
			map.Add("branchShopid", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
			return sqlMap.QueryForObject<int>("DiscountConcession.GetAllDiscountConcessionCount", map);
		}

		#endregion
	}
}