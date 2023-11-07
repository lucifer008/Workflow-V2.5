using System;
using System.Text;
using System.Collections.Generic;
using Workflow.Da;
using Workflow.Da.Domain;
using Spring.Transaction.Interceptor;

namespace Workflow.Service.CompaignManage
{
    /// <summary>
    /// 名    称: CampaignServiceImpl
    /// 功能概要: 活动管理的Service
    /// 作    者: 
    /// 创建时间: 
    /// 修 正 人: 付强
    /// 修正时间: 2009-1-21
    /// 描    述: 代码整理
    /// </summary>
    public class CampaignServiceImpl: ICampaignService
    {
        #region 类成员
        private ICampaignDao campaignDao;
        public ICampaignDao CampaignDao
        {
            set { campaignDao = value; }
        }

        private IConcessionDao concessionDao;
        public IConcessionDao ConcessionDao
        {
            set { concessionDao = value; }
        }

        private IConcessionDifferencePriceDao concessionDifferencePriceDao;
        public IConcessionDifferencePriceDao ConcessionDifferencePriceDao
        {
            set { concessionDifferencePriceDao = value; }
        }

        private IConcessionMemberCardLevelDao concessionMemberCardLevelDao;
        public IConcessionMemberCardLevelDao ConcessionMemberCardLevelDao
        {
            set { concessionMemberCardLevelDao = value; }
        }

		private IDiscountConcessionDao discountConcessionDao;
		public IDiscountConcessionDao DiscountConcessionDao
		{
			set { discountConcessionDao = value; }
		}
		#region 注入 machineTypeDao

		private IMachineTypeDao machineTypeDao;
		/// <summary>
		/// 注入 machineTypeDao
		/// </summary>
		public IMachineTypeDao MachineTypeDao
		{
			set { machineTypeDao = value; }
		}

		#endregion

		#region 注入 paperSpecificationDao

		private IPaperSpecificationDao paperSpecificationDao;
		/// <summary>
		/// 注入 paperSpecificationDao
		/// </summary>
		public IPaperSpecificationDao PaperSpecificationDao
		{
			set { paperSpecificationDao = value; }
		}

		#endregion

		#region 注入 discountConcessionMachineTypePaperSpecDao

		private IDiscountConcessionMachineTypePaperSpecDao discountConcessionMachineTypePaperSpecDao;
		/// <summary>
		/// 注入 discountConcessionMachineTypePaperSpecDao
		/// </summary>
		public IDiscountConcessionMachineTypePaperSpecDao DiscountConcessionMachineTypePaperSpecDao
		{
			set { discountConcessionMachineTypePaperSpecDao = value; }
		}

		#endregion

		#endregion

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
        [Transaction]
        public void InsertCampaign(Campaign campaign)
        {
            campaignDao.Insert(campaign);
        }

        /// <summary>
        /// 名    称: DeleteCampaignById
        /// 功能概要: 删除Campaign
        /// 作    者: liuwei
        /// 创建时间: 2007-10-18
        /// 修 正 人: 付强
        /// 修正时间: 2009-1-21
        /// 描    述: 代码整理
        /// 修 正 人:张晓林
        /// 修正时间:2009年3月17日14:04:22
        /// 描    述:将物理删除改为逻辑删除
        /// </summary>
        /// <param name="campaign">要删除的活动的id</param>
        [Transaction]
        public void DeleteCampaignById(long Id)
        {
            //删除ConcessionDifferencePrice
            //concessionDifferencePriceDao.DeleteConcessionDifferencePriceByCampaignId(Id);
            //删除ConcessionMemberCardLevel
            //concessionMemberCardLevelDao.DeleteConcessionMemberCardLevelByCampaignId(Id);
            //删除Concession
            //concessionDao.DeleteConcessionById(Id);
            //删除Campaign
            campaignDao.DeleteCampaignById(Id);
        }

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
        public void DeleteConcessionById(long Id) 
        {
            concessionDao.DeleteConcessionById(Id);
        }
        
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
        public void UpdateCampaign(Campaign campaign)
        {
            campaignDao.Update(campaign);
        }
        #endregion

        #region 活动下的具体优惠
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
        [Transaction]
        public void InsertConcession(Concession concession)
        {
            //concession.UnitPrice =//Convert.ToInt64(concession.ChargeAmount / concession.PaperCount);
            concessionDao.Insert(concession);

            //优惠活动所适应的卡信息
            ConcessionMemberCardLevel concessionMemberCardLevel = new ConcessionMemberCardLevel();
            concessionMemberCardLevel.ConcessionId = concession.Id;
            for (int i = 0; i < concession.ConcessionMemberCardLevelId.Length; i++)
            {
                concessionMemberCardLevel.MemberCardLevelId = Convert.ToInt64(concession.ConcessionMemberCardLevelId[i]);
                InsertConcessionMemberCardLevel(concessionMemberCardLevel);
            }

            //优惠活动所带来的差价
            ConcessionDifferencePrice concessionDifferencePrice = new ConcessionDifferencePrice();
            concessionDifferencePrice.ConcessionId = concession.Id;
            concessionDifferencePrice.BaseBusinessTypePriceSet = new BaseBusinessTypePriceSet();
            concessionDifferencePrice.BaseBusinessTypePriceSet.Id = concession.BaseBusinessTypePriceSet.Id;
            concessionDifferencePrice.PriceDifference = concession.RoomPrice - concession.UnitPrice;//差价

            //优惠活动带来的差价
            if (0 != concessionDifferencePrice.PriceDifference)
            {
                InsertConcessionDifferencePrice(concessionDifferencePrice);
            }
            
        }
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
        [Transaction]
        public void InsertConcessionMemberCardLevel(ConcessionMemberCardLevel concessionMemberCardLevel)
        {
            concessionMemberCardLevelDao.Insert(concessionMemberCardLevel);
        }
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
        [Transaction]
        public void InsertConcessionDifferencePrice(ConcessionDifferencePrice concessionDifferencePrice)
        {
            concessionDifferencePriceDao.Insert(concessionDifferencePrice);
        }
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
        [Transaction]
        public void DeleteConessionById(long Id)
        {
            //删除ConcessionDifferencePrice
            concessionDifferencePriceDao.DeletedConcessionDifferencePriceByConcessionId(Id);
            //删除ConcessionMemberCardLevel
            concessionMemberCardLevelDao.DeleteConcessionMemberCardByConcessionId(Id);
            //删除Concession
            concessionDao.DeleteConcessionById(Id);
        }
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
        [Transaction]
        public void UpdateConcession(Concession concession)
        {
            //更新Concession
            concessionDao.Update(concession);

            //更新优惠活动所适应的卡信息
            DeletedConcessionMemberCardByConcessionId(concession.Id);
            ConcessionMemberCardLevel concessionMemberCardLevel = new ConcessionMemberCardLevel();
            concessionMemberCardLevel.ConcessionId = concession.Id;
            for (int i = 0; i < concession.ConcessionMemberCardLevelId.Length; i++)
            {
                concessionMemberCardLevel.MemberCardLevelId = Convert.ToInt64(concession.ConcessionMemberCardLevelId[i]);
                InsertConcessionMemberCardLevel(concessionMemberCardLevel);
            }

            //更新优惠活动所带来的差价
            DeletedConcessionDifferencePriceByConcessionId(concession.Id);
            ConcessionDifferencePrice concessionDifferencePrice = new ConcessionDifferencePrice();
            concessionDifferencePrice.ConcessionId = concession.Id;
            concessionDifferencePrice.BaseBusinessTypePriceSet = new BaseBusinessTypePriceSet();
            concessionDifferencePrice.BaseBusinessTypePriceSet.Id = concession.BaseBusinessTypePriceSet.Id;
            concessionDifferencePrice.PriceDifference = concession.RoomPrice - concession.UnitPrice;//差价

            //优惠活动带来的差价
            if (0 != concessionDifferencePrice.PriceDifference)
            {
                InsertConcessionDifferencePrice(concessionDifferencePrice);
            }
        }
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
        [Transaction]
        public void DeletedConcessionMemberCardByConcessionId(long Id)
        {
            concessionMemberCardLevelDao.DeleteConcessionMemberCardByConcessionId(Id);
        }

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
        [Transaction]
        public void DeletedConcessionDifferencePriceByConcessionId(long Id)
        {
            concessionDifferencePriceDao.DeletedConcessionDifferencePriceByConcessionId(Id);
        }

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
        public IList<Concession> SearchConcessionList(Concession concession) 
        {
            return concessionDao.SearchConcessionList(concession);
        }
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
		public IList<DiscountConcession> GetAllDiscountConcession(int beginRow, int endRow)
		{
			return discountConcessionDao.GetAllDiscountConcession(beginRow, endRow);
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
			return discountConcessionDao.GetAllDiscountConcessionCount();
		}

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
		public void DeleteDiscountConcessionById(long discountConcessionId)
		{
			discountConcessionDao.LogicDelete(discountConcessionId);
		}

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
		public IList<Campaign> GetAllCampaign()
		{
			return campaignDao.SelectAll();
		}

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
		public IList<MachineType> GetAllMachine()
		{
			return machineTypeDao.SelectAll();
		}

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
		public IList<PaperSpecification> GetAllPaperSpecification()
		{
			return paperSpecificationDao.SelectAll();
		}

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
		[Spring.Transaction.Interceptor.Transaction]
		public void SaveDiscountApplyMachineAndPaper(DiscountConcession discountConcession, IList<DiscountConcessionMachineTypePaperSpec> applyDiscountList)
		{
			discountConcessionDao.Insert(discountConcession);
			foreach (DiscountConcessionMachineTypePaperSpec applyDiscount in applyDiscountList)
			{
				applyDiscount.DiscountConcessionId = discountConcession.Id;
				discountConcessionMachineTypePaperSpecDao.Insert(applyDiscount);
			}
		}

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
		public DiscountConcession GetDiscountConcessionById(long id)
		{
			return discountConcessionDao.SelectByPk(id);
		}

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
		[Spring.Transaction.Interceptor.Transaction]
		public void updateDiscountApplyMachineAndPaper(DiscountConcession discountConcession, IList<DiscountConcessionMachineTypePaperSpec> applyDiscountList)
		{
			discountConcessionDao.Update(discountConcession);
			discountConcessionMachineTypePaperSpecDao.DeleteDiscountConcessionMachineTypePaperSpecByDiscountId(discountConcession.Id);
			foreach (DiscountConcessionMachineTypePaperSpec applyDiscount in applyDiscountList)
			{
				discountConcessionMachineTypePaperSpecDao.Insert(applyDiscount);
			}
		}

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
		public IList<DiscountConcessionMachineTypePaperSpec> GetAllDiscountConcessionMachineTypePaperSpecByDiscountId(long discountId)
		{
			return discountConcessionMachineTypePaperSpecDao.SelectAllDiscountConcessionMachineTypePaperSpecByDiscountId(discountId);
		}

		#endregion
	}
}
