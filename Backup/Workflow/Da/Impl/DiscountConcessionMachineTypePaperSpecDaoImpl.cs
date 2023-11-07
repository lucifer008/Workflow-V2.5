#region imports
using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;
#endregion

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table DISCOUNT_CONCESSION_MACHINE_TYPE_PAPER_SPEC (打折的优惠活动所适用的机器类型和纸型) 对应的Dao 实现
	/// </summary>
    public class DiscountConcessionMachineTypePaperSpecDaoImpl : Workflow.Da.Base.DaoBaseImpl<DiscountConcessionMachineTypePaperSpec>, IDiscountConcessionMachineTypePaperSpecDao
    {

		#region 获取打折活动适用于机器和执型的信息通过打折活动id

		/// <summary>
		///  获取打折活动适用于机器和执型的信息通过打折活动id
		/// </summary>
		/// <returns>适用于机器和执型列表</returns>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.5.12
		/// </remarks>
		public IList<DiscountConcessionMachineTypePaperSpec> SelectAllDiscountConcessionMachineTypePaperSpecByDiscountId(long disCountId)
		{
			return sqlMap.QueryForList<DiscountConcessionMachineTypePaperSpec>("DiscountConcessionMachineTypePaperSpec.SelectAllDiscountConcessionMachineTypePaperSpecByDiscountId", disCountId);
		}

		#endregion

		#region 删除打折活动适用于机器和执型的信息通过打折活动id

		/// <summary>
		/// 删除打折活动适用于机器和执型的信息通过打折活动id
		/// </summary>
		/// <param name="discountId">打折活动Id</param>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.5.12
		/// </remarks>
		public void DeleteDiscountConcessionMachineTypePaperSpecByDiscountId(long discountId)
		{
			sqlMap.Delete("DiscountConcessionMachineTypePaperSpec.DeleteDiscountConcessionMachineTypePaperSpecByDiscountId", discountId);
		}

		#endregion
	}
}