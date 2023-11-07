using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Spring.Transaction.Interceptor;
using Workflow.Da;
using Workflow.Support;
using Workflow.Service;
using Workflow.Da.Domain;

namespace Workflow.Service.Impl
{
    /// <summary>
    /// 名    称: MemberCardServiceImpl
    /// 功能概要: 会员卡操作的Service
    /// 作    者: 张晓林
    /// 创建时间: 2009-1-19
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    public class MemberCardServiceImpl: IMemberCardService
    {
        #region 注入Dao
        private IMemberCardDao memberCardDao;

        public IMemberCardDao MemberCardDao
        {
            set { memberCardDao = value; }
        }

        private IMemberCardConcessionDao memberCardConcessionDao;

        public IMemberCardConcessionDao MemberCardConcessionDao
        {
            set { memberCardConcessionDao = value; }
        }

        private IChangeMemberCardDao changeMemberCardDao;

        public IChangeMemberCardDao ChangeMemberCardDao
        {
            set { changeMemberCardDao = value; }
        }

        private IConcessionDao concessionDao;
        public IConcessionDao ConcessionDao
        {
            set { concessionDao = value; }
        }

        private IMemberOperateLogDao memberOperateLogDao;
        public IMemberOperateLogDao MemberOperateLogDao
        {
            set { memberOperateLogDao = value; }
        }

        private ILogoffMemberCardDao logoffMemberCardDao;

        public ILogoffMemberCardDao LogoffMemberCardDao
        {
            set { logoffMemberCardDao = value; }
        }

        private IReportLossMemberCardDao reportLossMemberCardDao;

        public IReportLossMemberCardDao ReportLossMemberCardDao
        {
            set { reportLossMemberCardDao = value; }
        }

        private ICustomerDao customerDao;
        public ICustomerDao CustomerDao 
        {
            set { customerDao = value; }
        }

        private IBaseBusinessTypePriceSetDao baseBusinessTypePriceSetDao;
        public IBaseBusinessTypePriceSetDao BaseBusinessTypePriceSetDao
        {
            set { baseBusinessTypePriceSetDao = value; }
		}

		#region 注入 memberCardConcessionGatheringDao

		private IMemberCardConcessionGatheringDao memberCardConcessionGatheringDao;
		/// <summary>
		/// 注入 memberCardConcessionGatheringDao
		/// </summary>
		public IMemberCardConcessionGatheringDao MemberCardConcessionGatheringDao
		{
			set { memberCardConcessionGatheringDao = value; }
		}

		#endregion

		#region 注入 memberCardDiscountConcessionDao

		private IMemberCardDiscountConcessionDao memberCardDiscountConcessionDao;
		/// <summary>
		/// 注入 memberCardDiscountConcessionDao
		/// </summary>
		public IMemberCardDiscountConcessionDao MemberCardDiscountConcessionDao
		{
			set { memberCardDiscountConcessionDao = value; }
		}

		#endregion

        private IOtherGatheringAndRefundmentRecordDao otherGatheringAndRefundmentRecordDao;
        public IOtherGatheringAndRefundmentRecordDao OtherGatheringAndRefundmentRecordDao 
        {
            set { otherGatheringAndRefundmentRecordDao = value; }
        }
		#endregion

		#region //插入会员卡
		/// <summary>
        /// 名    称: InsertMemberCard
        /// 功能概要: 会员卡发卡操作
        /// 作    者: 刘伟
        /// 创建时间: 2007-9-30
        /// 修正履历: 张晓林
        /// 修正时间: 2009年2月13日
        /// 修正描述: 将涉及到的发卡操作进行封装在一个事务中 
        /// </summary>
        /// <param name="memberCard">会员信息</param>
        /// <param name="customer">会员所属的客户信息</param>
        /// <param name="memberOperateLog">会员卡操作记录</param>
        [Transaction]
        public void InsertMemberCard(MemberCard memberCard,Customer customer,MemberOperateLog memberOperateLog)
        {
            memberCardDao.Insert(memberCard);
            customerDao.Update(customer);
            //插入会员卡操作记录
            Hashtable condition = new Hashtable();
            condition.Add("MemberCardNo", memberCard.MemberCardNo);
            condition.Add("CustomerId", memberCard.CustomerId);
            IList<MemberCard> membercardList=memberCardDao.CheckMemberCardNo(condition);
            memberOperateLog.MemberCardId = membercardList[0].Id;
            memberOperateLogDao.Insert(memberOperateLog);
        }
        #endregion

        #region //修改会员信息

        /// <summary>
        /// 名    称: UpdateMemberCard
        /// 功能概要: 修改会员卡信息
        /// 作    者: 张晓林
        /// 创建时间: 2009年2月13日
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="memberCard">会员信息</param>
        /// <param name="customer">会员所属客户信息</param>
        /// <param name="memberOperateLog">会员卡操作记录</param>
        [Transaction]
        public void UpdateMemberCard(MemberCard memberCard, Customer customer, MemberOperateLog memberOperateLog)
        {
            memberCardDao.Update(memberCard);
            customerDao.Update(customer);
            //memberOperateLogDao.Insert(memberOperateLog);//插入对会员卡操作的记录
        }
        #endregion

        #region //会员卡补卡操作
        /// <summary>
        /// 名    称: RepairNewMemberCard
        /// 功能概要: 会员卡补卡操作(发一张新卡，并且将原卡的信息拷贝到新卡中)
        /// 作    者: 刘伟
        /// 创建时间: 2007-9-30
        /// 修正履历: 张晓林
        /// 修正时间: 2009年6月20日14:51:32
        /// 修正描述: 将涉及到的发卡操作进行封装在一个事务中 
        /// </summary>
        /// <param name="changeMemberCard"></param>
        /// <param name="PassWord"></param>
        /// <param name="Id"></param>
        /// <param name="memberOperateLog"></param>
        [Transaction]
        public void RepairNewMemberCard(ChangeMemberCard changeMemberCard, string PassWord, long Id, MemberOperateLog memberOperateLog)
        {
            //换卡
            MemberCard memberCard = memberCardDao.SelectByPk(Id);
            memberCard.MemberCardNo = changeMemberCard.NewMemberCardNo;
            memberCard.Password = PassWord;
            memberCard.MemberState = Constants.MEMBER_CARD_STATE_NATURAL_KEY; ;
            memberCardDao.Insert(memberCard);

            //将原卡的信息写如到新卡中(优惠活动)
            Hashtable condition = new Hashtable();
            condition.Add("NewMemberCardId", memberCard.Id);
            condition.Add("MemberCardId", Id);
            memberCardConcessionDao.UpdateMemberCardId(condition);

            //插入到换卡表中
            changeMemberCard.MemberCardId = memberCard.Id;
            changeMemberCard.Memo = "";
            changeMemberCardDao.Insert(changeMemberCard);

            //逻辑删除原卡
            memberCardDao.LogicDelete(Id);
            //插入换卡操作记录 
            memberOperateLogDao.Insert(memberOperateLog);
        }
        #endregion

		#region 会员卡送印章活动冲值
		/// <summary>
		/// 会员卡送印章活动冲值
		/// </summary>
		/// <param name="memberCardConcession" name="ChargeSum"></param>
		/// <remarks>
		/// 作    者: 刘伟
		/// 创建时间: 2007-10-22
		/// 修正履历: 陈汝胤
		/// 修正时间: 2009.5.14
		/// 修正描述: 需求变更的修改
        /// 修正履历: 张晓林
        /// 修正时间: 2010年1月13日10:16:23
        /// 修正描述: 加充值记录
        #region //会员卡充值
        [Transaction]
        public void InsertConcessionMemberCard(MemberCardConcession memberCardConcession, MemberCardConcessionGathering memberCardConcessionGathering, OtherGatheringAndRefundmentRecord ogr)
        {
			memberCardConcessionDao.Insert(memberCardConcession);
			memberCardConcessionGathering.MemberCardConcessionId = memberCardConcession.Id;
			memberCardConcessionGatheringDao.Insert(memberCardConcessionGathering);
            otherGatheringAndRefundmentRecordDao.Insert(ogr);
        }
        #endregion

        //#region //插入会员卡操作记录
        ///// <summary>
        ///// 插入会员卡操作记录
        ///// </summary>
        ///// <param name="memberOperateLog"></param>
        ///// <remarks>
        ///// 作    者: 张晓林
        ///// 创建时间: 2008-12-18
        ///// 修正履历:
        ///// 修正时间:
        ///// </remarks>
        //[Transaction]
        //public void InsertMemberOprateLog(MemberOperateLog memberOperateLog) 
        //{
        //    memberOperateLogDao.Insert(memberOperateLog);
        //}
        //#endregion

        #region //根据会员卡Id更新会员卡的状态为1
        /// <summary>
        /// 根据会员卡Id更新会员卡的状态为1
        /// </summary>
        /// <param name="memberOperateLog"></param>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2008-12-18
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        [Transaction]
        public void UpdateMemberCard(MemberCard memberCard) 
        {
            memberCardDao.Update(memberCard);
        }
        #endregion

        #region //会员卡注销操作
        [Transaction]
        public void InsertLogoffMemberCard(LogoffMemberCard logoffMemberCard, MemberOperateLog memberOperateLog)
        {
            logoffMemberCardDao.Insert(logoffMemberCard);//插入注销记录
            memberOperateLogDao.Insert(memberOperateLog);//插入会员卡操作记录
            //更新会员卡状态
            Hashtable condition = new Hashtable();
            condition.Add("Id", logoffMemberCard.MemberCardId);
            condition.Add("MemberState", Workflow.Support.Constants.MEMBER_CARD_STATE_LOGOUT_KEY);
            memberCardDao.UpdateMemberState(condition);
        }
        #endregion

        #region //会员卡挂失操作
        [Transaction]
        public void InsertReprotLossMemberCard(ReportLossMemberCard reportLossMemberCard, MemberOperateLog memberOperateLog)
        {
            //插入挂失信息
            reportLossMemberCardDao.Insert(reportLossMemberCard);
            
            //更新会员卡状态
            Hashtable condition = new Hashtable();
            condition.Add("Id", reportLossMemberCard.MemberCardId);
            condition.Add("MemberState", Workflow.Support.Constants.MEMBER_CARD_STATE_REPORTLOSS_KEY);
            memberCardDao.UpdateMemberState(condition);

            //插入会员卡操作记录
            memberOperateLogDao.Insert(memberOperateLog);
        }
        #endregion

        #region //会员卡恢复操作
        [Transaction]
        public void DeleteByMemberCardId(long Id, MemberOperateLog memberOperateLog)
        {
            //删除ReportLossMemberCard
            reportLossMemberCardDao.DeleteByMemberCardId(Id);

            //更新会员卡状态
            Hashtable condition = new Hashtable();
            condition.Add("Id", Id);
            condition.Add("MemberState", Workflow.Support.Constants.MEMBER_CARD_STATE_NATURAL_KEY);
            memberCardDao.UpdateMemberState(condition);

            //插入会员卡操作记录
            memberOperateLogDao.Insert(memberOperateLog);
        }
        #endregion

        #region //插入对会员卡的操作信息
        [Transaction]
        public void InsertMemberOperateLong(MemberOperateLog memberOperateLog)
        {
            memberOperateLogDao.Insert(memberOperateLog);
        }
        #endregion

        #region //通过会员Id删除会员
        /// <summary>
        /// 名    称: DeleteMemberCardById
        /// 功能概要: 通过会员Id删除会员
        /// 作    者: 张晓林
        /// 创建时间: 2009年2月13日16:29:48
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        ///<param name="Id">会员Id</param>
        public void DeleteMemberCardById(long Id) 
        {
            memberCardDao.DeleteMemberCardById(Id);
        }
        #endregion

		#region 会员卡打折活动冲值

		/// <summary>
		/// 会员卡打折活动冲值
		/// </summary>
		/// <param name="memberCardDiscountConcession">会员卡参加的打折优惠活动</param>
		/// <param name="memberCardConcessionGathering">会员卡参加优惠活动的付款记录</param>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.5.14
        /// 修正履历: 张晓林
        /// 修正时间: 2010年1月13日10:16:23
        /// 修正描述: 加充值记录
		/// </remarks>
		[Spring.Transaction.Interceptor.Transaction]
		public void InsertDiscountConcessionMemberCard(MemberCardDiscountConcession memberCardDiscountConcession, MemberCardConcessionGathering memberCardConcessionGathering,OtherGatheringAndRefundmentRecord ogr)
		{
			memberCardDiscountConcessionDao.Insert(memberCardDiscountConcession);
			memberCardConcessionGathering.MemberCardDiscountConcessionId = memberCardDiscountConcession.Id;
			memberCardConcessionGathering.MemberCardConcessionId = 0;
			memberCardConcessionGatheringDao.Insert(memberCardConcessionGathering);
            otherGatheringAndRefundmentRecordDao.Insert(ogr);
		}

		#endregion

		#endregion
	}
}
