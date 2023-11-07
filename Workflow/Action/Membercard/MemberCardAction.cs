using System;
using System.Collections;
using System.Collections.Generic;
using Workflow.Util;
using Workflow.Service;
using Workflow.Da.Domain;
using Workflow.Action.Model;
using Workflow.Support.Encrypt;
using Workflow.Service.CustomerManager;
using Workflow.Service.MemberCardManager;
/// <summary>
/// 名    称: MemberCardAction
/// 功能概要: 会员卡操作的Action
/// 作    者: 张晓林
/// 创建时间: 2009-01-23
/// 修正履历: 
/// 修正时间: 
/// </summary>
namespace Workflow.Action
{
    public  class MemberCardAction
    {
        #region //Model
        private MemberCardModel model = new MemberCardModel();
        /// <summary>
        /// Gets or sets the Member Card model
        /// </summary>
        /// <value>The Member Card model.</value>
        public MemberCardModel Model
        {
            get { return model; }
        }

        #endregion

        #region //注入Service
        private IMemberCardService memberCardService;
        /// <summary>
        /// Gets or sets the member card  service
        /// </summary>
        /// <value>The member card service</value>
        public IMemberCardService MemberCardService
        {
            set { memberCardService = value; }
        }

        private ISearchMemberCardService searchMemberCardService;
        public ISearchMemberCardService SearchMemberCardService
        {
            set { searchMemberCardService = value; }
        }

        private ICustomerService customerService;
        /// <summary>
        /// Gets or sets the customer service
        /// </summary>
        /// <value>The customer service</value>
        public ICustomerService CustomerService
        {
            set { customerService = value; }
        }
        #endregion

        #region //根据卡号和顾客Id 及卡状态判断卡号是否存在
        /// <summary>
        /// 根据卡号和顾客Id 及卡状态判断卡号是否存在
        /// </summary>
        /// <returns></returns>
        public void CheckMemberCardByNoAndCustomerId()
        {
            Hashtable hashCondition = new Hashtable();
            hashCondition.Add("MemberCardNo", model.MemberCard.MemberCardNo);
            hashCondition.Add("CustomerId", model.MemberCard.CustomerId);
            model.MemberCardList = searchMemberCardService.CheckMemberCardNo(hashCondition);
        }
        #endregion

        #region //换卡操作
        /// <summary>
        /// 换卡操作
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: liuwei
        /// 创建时间: 2007-10-7
        /// 修正履历: 张晓林
        /// 修正时间: 2009年6月20日14:40:19
        ///           将挂失卡所涉及到的操作封装到一个事务中
        /// </remarks>

        public virtual void RepairNewMemberCard()
        {
            memberCardService.RepairNewMemberCard(model.ChangeMemberCard, model.PassWord, model.Id, model.MemberOperateLog);
            //memberCardService.InsertMemberOprateLog(model.MemberOperateLog);//添加注销操作记录
        }
        #endregion

        #region //插入新会员卡
        /// <summary>
        /// 名    称: InsertMemberCard
        /// 功能概要: 插入会员卡s
        /// 作    者: 刘伟
        /// 创建时间: 2007-9-30
        /// 修正履历: 张晓林
        /// 修正时间: 2009年2月13日9:40:44
        /// 修正描述: 在Service层：将涉及到的发卡操作进行封装在一个事务中
        /// </summary>
        public virtual void InsertMemberCard()
        {
            //根据CustomerId和MemberCardNo获取MemberCardId
            //CheckMemberCardByNoAndCustomerId();
            //model.MemberOperateLog.MemberCardId = model.MemberCardList[0].Id;
            memberCardService.InsertMemberCard(model.MemberCard,model.Customer,model.MemberOperateLog);
           //memberCardService.InsertMemberOprateLog(model.MemberOperateLog);//插入插卡记录
        }
        #endregion

        #region //修改会员卡信息
        /// <summary>
        /// 方法名称: UpdateMemberCard
        /// 功能概要: 修改会员卡信息
        /// 作    者: 张晓林
        /// 创建时间: 2009年2月13日
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        public virtual void UpdateMemberCard() 
        {
            memberCardService.UpdateMemberCard(model.MemberCard,model.Customer,model.MemberOperateLog);
        }
        #endregion

        #region 会员卡送印章活动冲值
        /// <summary>
		/// 会员卡送印章活动冲值
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: liuwei
        /// 创建时间: 2007-10-8
        /// 修正履历: 陈汝胤
        /// 修正时间: 2009.5.14
        /// </remarks>
        public void InsertMemberCardConcession()
        {
            memberCardService.InsertConcessionMemberCard(model.MemberCardConcession,model.MemberCardConcessionGathering,model.OtherGatheringAndRefundmentRecord);
        }
        #endregion

        #region //插入挂失会员卡
        /// <summary>
        /// 插入挂失会员卡
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: liuwei
        /// 创建时间: 2007-10-6
        /// 修正履历: 张晓林
        /// 修正时间: 2009年6月20日14:09:22
        ///           将挂失卡所涉及到的操作封装到一个事务中
        /// </remarks>
        public virtual void InsertReportLessMemberCard()
        {
            memberCardService.InsertReprotLossMemberCard(model.ReportLossMemberCard, model.MemberOperateLog);

            //model.MemberOperateLog = new MemberOperateLog();

            //model.MemberOperateLog.MemberCardId = model.ReportLossMemberCard.MemberCardId;
            //model.MemberOperateLog.OperateType = Workflow.Support.Constants.MEMBER_CARD_OPERATE_REPORTLOSS_KEY;
            //model.MemberOperateLog.Memo = "挂失";
            //memberCardService.InsertMemberOperateLong(model.MemberOperateLog);
        }
        #endregion

        #region //插入注销会员卡
        /// <summary>
        /// 插入注销会员卡
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: liuwei
        /// 创建时间: 2007-10-6
        /// 修正履历: 张晓林
        /// 修正时间: 2009年6月20日13:53:06
        ///           将注销卡所涉及到的操作封装到一个事务中
        /// </remarks>
        public virtual void InsertLogoffMemberCard()
        {
            memberCardService.InsertLogoffMemberCard(model.LogoffMemberCard,model.MemberOperateLog);
            //model.MemberOperateLog = new MemberOperateLog();
            //model.MemberOperateLog.MemberCardId = model.LogoffMemberCard.MemberCardId;
            //model.MemberOperateLog.OperateType = Workflow.Support.Constants.MEMBER_CARD_OPERATE_LOGOUT_KEY;//注销
            //model.MemberOperateLog.Memo = "注销";
            //memberCardService.InsertMemberOperateLong(model.MemberOperateLog);
        }
        #endregion

        #region //通过MemberCardId删除挂失信息
        /// <summary>
        /// 会员卡恢复
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: liuwei
        /// 创建时间: 2007-10-6
        /// 修正履历: 张晓林
        /// 修正时间: 2009年6月20日14:37:26
        ///         将会员卡恢复所涉及到得操作封装到事务中
        /// </remarks>
        public virtual void DeleteByMemberCardId()
        {
            //通过MemberCardId删除挂失信息
            memberCardService.DeleteByMemberCardId(model.MemberCardId,model.MemberOperateLog);

            //model.MemberOperateLog.MemberCardId = model.MemberCardId;
            //model.MemberOperateLog.OperateType = Workflow.Support.Constants.MEMBER_CARD_OPERATE_RECOVERY_KEY;//恢复
            //model.MemberOperateLog.Memo = "恢复";
            //memberCardService.InsertMemberOperateLong(model.MemberOperateLog);
        }
        #endregion

		#region 会员卡打折活动冲值

		/// <summary>
		/// 会员卡打折活动冲值
		/// </summary>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.5.14
		/// </remarks>
		public void InsertMemberCardDiscountConcession()
		{
            memberCardService.InsertDiscountConcessionMemberCard(model.MemberCardDiscountConcession, model.MemberCardConcessionGathering, model.OtherGatheringAndRefundmentRecord);
		} 

		#endregion

		
	}
}
