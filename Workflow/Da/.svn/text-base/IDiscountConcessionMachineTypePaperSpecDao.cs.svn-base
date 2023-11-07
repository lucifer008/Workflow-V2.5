#region imports
using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
#endregion

namespace Workflow.Da
{
	/// <summary>
	/// Table DISCOUNT_CONCESSION_MACHINE_TYPE_PAPER_SPEC (打折的优惠活动所适用的机器类型和纸型)对应的Dao 接口
	/// </summary>
	public interface IDiscountConcessionMachineTypePaperSpecDao : IDaoBase<DiscountConcessionMachineTypePaperSpec>
	{
		#region 获取打折活动适用于机器和执型的信息通过打折活动id

		/// <summary>
		///  获取打折活动适用于机器和执型的信息通过打折活动id
		/// </summary>
		/// <param name="discountId">打折活动id</param>
		/// <returns>适用于机器和执型列表</returns>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.5.12
		/// </remarks>
		IList<DiscountConcessionMachineTypePaperSpec> SelectAllDiscountConcessionMachineTypePaperSpecByDiscountId(long discountId);

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
		void DeleteDiscountConcessionMachineTypePaperSpecByDiscountId(long discountId);
		
		#endregion

		
	}
}