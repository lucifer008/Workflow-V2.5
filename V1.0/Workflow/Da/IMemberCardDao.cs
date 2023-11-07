using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using System.Collections;

namespace Workflow.Da
{
	/// <summary>
	/// Table MEMBER_CARD 对应的Dao 接口
	/// </summary>
    public interface IMemberCardDao : IDaoBase<MemberCard>
    {

		
        /// <summary>
        /// 名    称: SearchMemberCard
        /// 功能概要: 查询会员卡信息
        /// 作    者: liuwei
        /// 创建时间: 2007-9-29
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        ///
        IList<MemberCard> SearchMemberCard(Hashtable condition);

        /// <summary>
        /// 名    称: SearchMemberCardRowCount
        /// 功能概要: 查询会员卡信息记录数
        /// 作    者: 张晓林
        /// 创建时间: 2009-02-11
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        long SearchMemberCardRowCount(Hashtable condition);

        /// <summary>
        /// 名    称: SearchMemberCardByIdentityCard
        /// 功能概要: 通过IdentityCardNo查询MemberCardInfo
        /// 作    者: liuwei
        /// 创建时间: 2007-10-5
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        ///
        IList<MemberCard> SearchMemberCardByIdentityCard(Hashtable hashtable);

        /// <summary>
        /// 名    称: UpdateMemberState
        /// 功能概要: 更新MemberCard的状态
        /// 作    者: liuwei
        /// 创建时间: 2007-10-6
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        ///
        void UpdateMemberState(System.Collections.Hashtable condition);
        /// <summary>
        /// 名    称: SelectMemberCardByMemberCardNoAndPassWord
        /// 功能概要: 通过MemberCardNo和PassWord查询会员卡信息
        /// 作    者: liuwei
        /// 创建时间: 2007-10-6
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        ///
        int SelectMemberCardByMemberCardNoAndPassWord(System.Collections.Hashtable condition);
        /// <summary>
        /// 通过MemberCardId查询会员卡信息(只查询正常状态的)
        /// </summary>
        /// <param name="memberCardNo">会员卡号</param>
        /// <returns>MemberCard</returns>
        /// <remarks>
        /// 作    者: liuwei
        /// 创建时间: 2007-10-7
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        MemberCard SearchSelectMemberCardByCardNo(string memberCardNo);
        /// <summary>
        /// 通过MemberCardId查询会员卡信息(查询所有)
        /// </summary>
        /// <param name="memberCardNo">会员卡号</param>
        /// <returns>MemberCard</returns>
        /// <remarks>
        /// 作    者: liuwei
        /// 创建时间: 2007-10-23
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        MemberCard SelectAllMemberCardByCardNo(string memberCardNo);


         /// <summary>
        /// 根据卡号获取该卡消费的总金额
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年4月3日17:57:34
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        MemberCard SearchMemberCardConsumeAmount(long memberCardId); 

        /// <summary>
        /// 判定该卡是否存在
        /// </summary>
        /// <param name="memberCardNo">会员卡号</param>
        /// <returns>int</returns>
        /// <remarks>
        /// 作    者: liuwei
        /// 创建时间: 2007-10-10
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        int SearchWheterMemberCardNo(string memberCardNo);
        /// <summary>
        /// 通过CustomerId更改deleted
        /// </summary>
        /// <param name="Id">CustomerId</param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: liuwei
        /// 创建时间: 2007-10-12
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        void UpdateByCustomerId(long Id);

        /// 选择当日新办理的会员卡一览
        /// </summary>
        /// <returns>Member</returns>
        /// <remarks>
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-13
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        IList<MemberCard> SelectTodayNewMemberCard();

        /// <summary>
        /// 按时段获取办理的会员卡
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 朱静程
        /// 创建时间: 2008-11-04
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        IList<MemberCard> SelectSomeNewMemberCard(System.Collections.Hashtable condition);

        /// 通过会员卡ID更新会员卡已消费金额
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-22
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        void UpdateMemberCardConsumeAmount(MemberCard memberCard);
        /// 查询会员充值记录(MemberCard)
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 刘伟
        /// 创建时间: 2007-10-23
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        IList<MemberCard> SelectChargeRecord(System.Collections.Hashtable condition);
        /// 通过会员卡号查找相关客户信息
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-23
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        MemberCard SelectCustomerInfoByMemberCardNo(string memberCardNo);
        /// 查询会员卡操作记录(MemberCard)
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 刘伟
        /// 创建时间: 2007-10-24
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        IList<MemberCard> SelectOperateLog(System.Collections.Hashtable condition);
        /// 查询换卡记录
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 刘伟
        /// 创建时间: 2007-10-24
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        IList<MemberCard> SelectChangeMemberCard(System.Collections.Hashtable condition);

        /// <summary>
        /// 根据卡Id和雇员ID区判断卡号的
        /// </summary>
        /// <param name="hashCondition"></param>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2008-12-17
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        IList<MemberCard> CheckMemberCardNo(Hashtable hashCondition);

        #region //会员消费统计
        /// <summary>
        /// 会员卡的消费统计
        /// </summary>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-27
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        IList<Order> GetMemberCardConsume(Order order);

        /// <summary>
        /// 会员卡的消费统计记录数
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年4月3日10:53:10
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        long GetMemberCardConsumeRowCount(Order order);

        /// <summary>
        /// 会员卡的消费统计(打印)
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年4月3日10:53:10
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        IList<Order> GetMemberCardConsumePrint(Order order);
        #endregion 

        /// <summary>
        /// 名    称: SearchMemberById
        /// 功能概要: 通过Id查询会员信息
        /// 作    者: 张晓林
        /// 创建时间: 2009年2月12日11:35:57
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        MemberCard SearchMemberById(long Id);

        /// <summary>
        /// 获取该会员在Order中的记录数
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年2月13日
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        long SearchMemberCardIdInOrdersRowCount(string membercardId);

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

         #region //会员操作记录

        /// <summary>
        ///获取会员卡操作列表(分页) 
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作     者:张晓林
        /// 创建时间：2009年4月6日10:19:40
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        IList<MemberCard> SearchOperateLog(Hashtable condition);

        /// <summary>
        ///获取会员操作记录数
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作     者:张晓林
        /// 创建时间：2009年4月6日10:19:40
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        long SearchOperateLogRowCount(Hashtable condition);

        /// <summary>
        ///获取会员操作记录(打印)
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作     者:张晓林
        /// 创建时间：2009年4月6日10:19:40
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        IList<MemberCard> SearchOperateLogPrint(Hashtable condition);
        #endregion

        #region //获取会员参加优惠的业务类型类型列表
        /// <summary>
        /// 获取会员参加优惠的业务类型类型列表
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年4月15日13:54:16
        /// 修正履历:
        /// 修正时间:
        /// 描    述:
        /// </remarks>
        IList<MemberCardConcession> GetMemberCardConcessionBaseBusniessInfo(long memberCardId); 
        #endregion

        #region //会员卡冲减
        /// <summary>
        /// 会员卡冲减
        /// </summary>
        /// <param name="memberCardBaseBusinessTypeItem"></param>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年4月16日13:35:42
        /// 修正履历:
        /// 修正时间:
        /// 描    述:
        /// </remarks>
        void MemberCardDiff(MemberCard.MemberCardBaseBusinessTypeItem memberCardBaseBusinessTypeItem);
        #endregion

        /// <summary>
        /// 名   称:  UpdateMemberCardMarkingSetting
        /// 功能概要: 更新会员积分
        /// 作    者: 张晓林
        /// 创建时间: 2009年10月29日13:29:39
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        void UpdateMemberCardMarkingSetting(MemberCard memberCard);
    }
}
