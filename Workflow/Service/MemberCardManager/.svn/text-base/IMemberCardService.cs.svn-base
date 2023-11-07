using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da;
using Workflow.Da.Domain;
using System.Collections;
namespace Workflow.Service
{
    /// <summary>
    /// 名    称: IMemberCardService
    /// 功能概要: 会员卡操作的Service接口
    /// 作    者: 张晓林
    /// 创建时间: 2009-1-19
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    public interface IMemberCardService
    {

        /// <summary>
        /// 名    称: InsertMemberCard
        /// 功能概要: 插入会员卡
        /// 作    者: 刘伟
        /// 创建时间: 2007-9-30
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="memberCard">会员信息</param>
        /// <param name="customer">会员所属的客户信息</param>
        /// <param name="memberOperateLog">会员卡操作记录</param>
        void InsertMemberCard(MemberCard memberCard, Customer customer, MemberOperateLog memberOperateLog);

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
        void UpdateMemberCard(MemberCard memberCard,Customer customer,MemberOperateLog memberOperateLog);
       
        /// <summary>
        /// 换卡
        /// </summary>
        /// <param name="orderId">Id,NewMemberCardNo,PassWord</param>
        /// <returns</returns>
        /// <remarks>
        /// 作    者: 刘伟
        /// 创建时间: 2007-10-7
        /// 修正履历:
        /// 修正时间:
        /// </remarks>	
        void RepairNewMemberCard(ChangeMemberCard changeMemberCard, string PassWord, long Id, MemberOperateLog memberOperateLog);
       
        ///// <summary>
        ///// 会员卡充值
        ///// </summary>
        ///// <param name="campaign">充值信息</param>
        ///// <returns</returns>
        ///// <remarks>
        ///// 作    者: 刘伟
        ///// 创建时间: 2007-10-8
        ///// 修正履历:
        ///// 修正时间:
        ///// </remarks>	
        //void InsertCampaignMemberCard(MemberCardConcession memberCardConcession);


        /// <summary>
        /// 会员充值
        /// </summary>
        /// <param name="memberCardConcession" name="ChargeSum"></param>
        /// <remarks>
        /// 作    者: 刘伟
        /// 创建时间: 2007-10-22
        /// 修正履历: 陈汝胤
        /// 修正时间: 2009.5.14
		/// 修正描述: 需求变更的修改
        /// </remarks>
		void InsertConcessionMemberCard(MemberCardConcession memberCardConcession, MemberCardConcessionGathering memberCardConcessionGathering,OtherGatheringAndRefundmentRecord ogr);
   


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
        //void InsertMemberOprateLog(MemberOperateLog memberOperateLog);

        /// <summary>
        /// 根据会员卡Id更新会员卡的状态为正常(Member_State=1)
        /// </summary>
        /// <param name="memberOperateLog"></param>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2008-12-18
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        void UpdateMemberCard(MemberCard memberCard);

        /// <summary>
        /// 插入注销信息
        /// </summary>
        /// <param name="orderId">LogoffMemberCard</param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 刘伟
        /// 创建时间: 2007-10-6
        /// 修正履历:
        /// 修正时间:
        /// </remarks>

        void InsertLogoffMemberCard(LogoffMemberCard logoffMemberCard,MemberOperateLog memberOperateLog);

        /// <summary>
        /// 名    称: InsertReprotLossMemberCard
        /// 功能概要: 插入挂失信息
        /// 作    者: 刘伟
        /// 创建时间: 2007-10-5
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        void InsertReprotLossMemberCard(ReportLossMemberCard reportLossMemberCard, MemberOperateLog memberOperateLog);

        /// <summary>
        /// 名    称: DeleteByMemberCardId
        /// 功能概要: 会员卡恢复
        /// 作    者: 刘伟
        /// 创建时间: 2007-10-6
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        void DeleteByMemberCardId(long Id,MemberOperateLog memberOperateLog);

        /// <summary>
        /// 名    称: InsertMemberOperateLong
        /// 功能概要: 插入对会员卡的操作信息
        /// 作    者: 张晓林
        /// 创建时间: 2008-12-25
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="memberOperateLog"></param>
        void InsertMemberOperateLong(MemberOperateLog memberOperateLog);

        /// <summary>
        /// 名    称: DeleteMemberCardById
        /// 功能概要: 通过会员Id删除会员
        /// 作    者: 张晓林
        /// 创建时间: 2009年2月13日16:29:48
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        ///<param name="Id">会员Id</param>
        void DeleteMemberCardById(long Id);

		#region 会员卡打折活动冲值

		/// <summary>
		/// 会员卡打折活动冲值
		/// </summary>
		/// <param name="memberCardDiscountConcession">会员卡参加的打折优惠活动</param>
		/// <param name="memberCardConcessionGathering">会员卡参加优惠活动的付款记录</param>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.5.14
		/// </remarks>
		void InsertDiscountConcessionMemberCard(MemberCardDiscountConcession memberCardDiscountConcession, MemberCardConcessionGathering memberCardConcessionGathering,OtherGatheringAndRefundmentRecord ogr);

		#endregion
		
	}
}
