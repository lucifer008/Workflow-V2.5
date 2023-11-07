using System;
using System.Text;
using System.Collections.Generic;
using Workflow.Da.Domain;

namespace Workflow.Service.CompaignManage
{
    /// <summary>
    /// 名    称: ICampaignService
    /// 功能概要: 活动管理Service的接口
    /// 作    者: 
    /// 创建时间: 
    /// 修 正 人: 付强
    /// 修正时间: 2009-1-21
    /// 描    述: 代码整理
    /// </summary>
    public interface ICampaignService
    {
        #region 活动管理
        /// <summary>
        /// 名    称: InsertCampaign
        /// 功能概要: 插入营销活动
        /// 作    者: liuwei
        /// 创建时间: 2007-10-15
        /// 修 正 人: 付强
        /// 修正时间: 2009-1-21
        /// 描    述: 代码整理
        /// </summary>
        /// <param name="campaign">具体活动</param>
        void InsertCampaign(Campaign campaign);
 
        /// <summary>
        /// 名    称: DeleteCampaignById
        /// 功能概要: 删除Campaign
        /// 作    者: liuwei
        /// 创建时间: 2007-10-18
        /// 修 正 人: 付强
        /// 修正时间: 2009-1-21
        /// 描    述: 代码整理
        /// </summary>
        /// <param name="campaign">要删除的活动的id</param>
        void DeleteCampaignById(long Id);
        /// <summary>
        /// 名    称: UpdateCampaign
        /// 功能概要: 通过CampaignId更新Campaign
        /// 作    者: liuwei
        /// 创建时间: 2007-10-19
        /// 修 正 人: 付强
        /// 修正时间: 2009-1-21
        /// 描    述: 代码整理
        /// </summary>
        /// <param name="campaign">要更新的活动</param>
        void UpdateCampaign(Campaign campaign);
        #endregion

        #region 活动下的优惠管理
        /// <summary>
        /// 名    称: InsertConcession
        /// 功能概要: 插入优惠活动
        /// 作    者: liuwei
        /// 创建时间: 2007-10-17
        /// 修 正 人: 付强
        /// 修正时间: 2009-1-21
        /// 描    述: 代码整理
        /// </summary>
        /// <param name="concession">优惠活动</param>
        void InsertConcession(Concession concession);
        /// <summary>
        /// 名    称: InsertConcessionMemberCardLevel
        /// 功能概要: 插入优惠活动适应的卡级别
        /// 作    者: liuwei
        /// 创建时间: 2007-10-17
        /// 修 正 人: 付强
        /// 修正时间: 2009-1-21
        /// 描    述: 代码整理
        /// </summary>
        /// <param name="concessionMemberCardLevel">优惠活动适应的卡级别</param>
        void InsertConcessionMemberCardLevel(ConcessionMemberCardLevel concessionMemberCardLevel);
        /// <summary>
        /// 名    称: InsertConcessionDifferencePrice
        /// 功能概要: 插入优惠活动适应的差价
        /// 作    者: liuwei
        /// 创建时间: 2007-10-17
        /// 修 正 人: 付强
        /// 修正时间: 2009-1-21
        /// 描    述: 代码整理
        /// </summary>
        /// <param name="concessionDifferencePrice">优惠活动适应的差价</param>
        void InsertConcessionDifferencePrice(ConcessionDifferencePrice concessionDifferencePrice);
        /// <summary>
        /// 名    称: DeleteConessionById
        /// 功能概要: 删除Concession
        /// 作    者: liuwei
        /// 创建时间: 2007-10-18
        /// 修 正 人: 付强
        /// 修正时间: 2009-1-21
        /// 描    述: 代码整理
        /// </summary>
        /// <param name="Id">ConcessionId</param>
        void DeleteConessionById(long Id);


        /// <summary>
        /// 名    称: DeleteConcessionById
        /// 功能概要: 删除Concession
        /// 作    者: 张晓林
        /// 创建时间: 2009年3月17日14:06:16
        /// 修 正 人: 
        /// 修正时间: 
        /// 描    述: 
        /// </summary>
        /// <param name="campaign">要删除的方案id</param>
        void DeleteConcessionById(long Id);

        /// <summary>
        /// 名    称: UpdateConcession
        /// 功能概要: 更新Concession
        /// 作    者: liuwei
        /// 创建时间: 2007-10-18
        /// 修 正 人: 付强
        /// 修正时间: 2009-1-21
        /// 描    述: 代码整理
        /// </summary>
        /// <param name="concession">Concession</param>
        /// <param name="concessionMemberCardLevelIds">会员开级别ID</param>
        /// <param name="concessionDifferencePriceIds">优惠差价Id</param>
        /// <param name="concessionDifferenceValues">差价</param>
        void UpdateConcession(Concession concession);
        /// <summary>
        /// 名    称: DeletedConcessionMemberCardByConcessionId
        /// 功能概要: 通过ConcessionId删除ConcessionMemberCardLevel表中的相关信息
        /// 作    者: liuwei
        /// 创建时间: 2007-10-19
        /// 修 正 人: 付强
        /// 修正时间: 2009-1-21
        /// 描    述: 代码整理
        /// </summary>
        /// <param name="Id">ConcessionId</param>
        void DeletedConcessionMemberCardByConcessionId(long Id);
        /// <summary>
        /// 名    称: DeletedConcessionDifferencePriceByConcessionId
        /// 功能概要: 通过ConcessionId删除ConcessionDifferencePrice表中的相关信息
        /// 作    者: liuwei
        /// 创建时间: 2007-10-19
        /// 修 正 人: 付强
        /// 修正时间: 2009-1-21
        /// 描    述: 代码整理
        /// </summary>
        /// <param name="Id">ConcessionId</param>
        void DeletedConcessionDifferencePriceByConcessionId(long Id);

        /// <summary>
        /// 名    称: SearchConcessionList
        /// 功能概要: 按照条件查询Concession信息
        /// 作    者: 张晓林
        /// 创建时间: 2009年3月19日18:05:47
        /// 修 正 人:
        /// 修正时间:
        /// 描    述:
        /// </summary>
        /// <param name="concession"></param>
        /// <returns></returns>
        IList<Concession> SearchConcessionList(Concession concession);
        #endregion

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
		IList<DiscountConcession> GetAllDiscountConcession(int beginRow,int endRow);

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
		int GetAllDiscountConcessionCount();

		#endregion

		#region 删除指定id的打折活动

		/// <summary>
		/// 删除指定id的打折活动
		/// </summary>
		/// <param name="discountConcessionId">打折活动id</param>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.5.11
		/// </remarks>
		void DeleteDiscountConcessionById(long discountConcessionId);

		#endregion

		#region 获取所有的营销活动

		/// <summary>
		/// 获取所有的营销活动
		/// </summary>
		/// <returns>营销活动列表</returns>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.5.11
		/// </remarks>
		IList<Campaign> GetAllCampaign();

		#endregion

		#region 获取所有的机器类型

		/// <summary>
		/// 获取所有的机器类型
		/// </summary>
		/// <returns>机器类型列表</returns>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.5.11
		/// </remarks>
		IList<MachineType> GetAllMachine();

		#endregion

		#region 获取所有的机器类型

		/// <summary>
		/// 获取所有的机器类型
		/// </summary>
		/// <returns>机器类型列表</returns>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.5.11
		/// </remarks>
		IList<PaperSpecification> GetAllPaperSpecification();

		#endregion

		#region 保存折扣适用于的机器和纸型

		/// <summary>
		/// 保存折扣适用于的机器和纸型
		/// </summary>
		/// <param name="discountConcession">折扣</param>
		/// <param name="applyDiscountList">折扣适用的机器和纸型</param>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.5.12
		/// </remarks>
		void SaveDiscountApplyMachineAndPaper(DiscountConcession discountConcession, IList<DiscountConcessionMachineTypePaperSpec> applyDiscountList);

		#endregion

		#region 通过折扣id获取折扣活动

		/// <summary>
		/// 通过折扣id获取折扣活动
		/// </summary>
		/// <param name="id">折扣id</param>
		/// <returns>折扣活动</returns>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.5.12
		/// </remarks>
		DiscountConcession GetDiscountConcessionById(long id);

		#endregion

		#region 更新折扣适用于的机器和纸型

		/// <summary>
		/// 更新折扣适用于的机器和纸型
		/// </summary>
		/// <param name="discountConcession">折扣</param>
		/// <param name="applyDiscountList">折扣适用的机器和纸型</param>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.5.12
		/// </remarks>
		void updateDiscountApplyMachineAndPaper(DiscountConcession discountConcession, IList<DiscountConcessionMachineTypePaperSpec> applyDiscountList);
		
		#endregion

		#region 获取指定折扣活动的所有适用于的机器和纸型

		/// <summary>
		/// 获取指定折扣活动的所有适用于的机器和纸型
		/// </summary>
		/// <param name="discountId">折扣id</param>
		/// <returns></returns>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.5.12
		/// </remarks>
		IList<DiscountConcessionMachineTypePaperSpec> GetAllDiscountConcessionMachineTypePaperSpecByDiscountId(long discountId);
		
		#endregion
	}
}

