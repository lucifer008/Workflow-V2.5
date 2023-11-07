using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Workflow.Da.Domain;

namespace Workflow.Service.MemberCardManager
{
    /// <summary>
    /// 名    称: ISearchMemberCardService
    /// 功能概要: 会员卡查询的Service接口
    /// 作    者: 张晓林
    /// 创建时间: 2009-1-19
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    public interface ISearchMemberCardService
    {
        /// <summary>
        /// 名    称: SearchMemberCard
        /// 功能概要: 根据条件查询客户信息
        /// 作    者: 刘伟
        /// 创建时间: 2007-9-29
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        IList<MemberCard> SearchMemberCard(System.Collections.Hashtable condition);

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
        /// 名    称: SearchMemberCardById
        /// 功能概要: 通过Id查询会员卡信息
        /// 作    者: 刘伟
        /// 创建时间: 2007-9-29
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        MemberCard SearchMemberCardById(long Id);

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
        /// 名    称: SearchMemberCardByIdentityCard
        /// 功能概要: 通过IdentityCardNo查询MemberCardInfo
        /// 作    者: 刘伟
        /// 创建时间: 2007-10-5
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        IList<MemberCard> SearchMemberCardByIdentityCard(Hashtable hashtable);

        /// <summary>
        /// 名    称: SearchMemberCardByMemberCardNo
        /// 功能概要: 通过MemberCardNo和PassWord查询MemberCardInfo
        /// 作    者: 刘伟
        /// 创建时间: 2007-10-6
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        int SearchMemberCardByMemberCardNo(System.Collections.Hashtable condition);

        /// <summary>
        /// 通过MemberCardId查询会员卡信息(只查询正常状态的卡)
        /// </summary>
        /// <param name="memberCardNo"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 刘伟
        /// 创建时间: 2007-10-7
        /// 修正履历:
        /// 修正时间:
        /// </remarks>	
        MemberCard SearchMemberCardByCardNo(string memberCardNo);

        /// <summary>
        /// 通过MemberCardId查询会员卡信息(查询所有状态的卡)
        /// </summary>
        /// <param name="memberCardNo">会员卡号</param>
        /// <returns</returns>
        /// <remarks>
        /// 作    者: 刘伟
        /// 创建时间: 2007-10-23
        /// 修正履历:
        /// 修正时间:
        /// </remarks>	
        MemberCard SearchAllMemberCardByCardNo(string memberCardNo);


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
        /// 获得会员卡信息一览
        /// </summary>
        /// <returns</returns>
        /// <remarks>
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-13
        /// 修正履历:
        /// 修正时间:
        /// </remarks>	
        IList<MemberCard> GetMemberCardList();

        /// <summary>
        /// 判定该卡是否存在
        /// </summary>
        /// <param name="memberCardNo">会员卡号</param>
        /// <returns>int</returns>
        /// <remarks>
        /// 作    者: 刘伟
        /// 创建时间: 2007-10-10
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        int SearchWhetherMemberCardNo(string memberCardNo);

        /// <summary>
        /// 根据卡号Id和顾客Id判断卡是否存在
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2008-12-17
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        IList<MemberCard> CheckMemberCardNo(Hashtable hashCondition);

        /// <summary>
        /// 通过MemberCardNo查询该卡参加的营销活动
        /// </summary>
        /// <param name="memberCardNo"></param>
        /// <returns>StringBuilder</returns>
        /// <remarks>
        /// 作    者: 刘伟
        /// 创建时间: 2007-10-23
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        string SearchMemberCardCampaign(string memberCardNo);

        #region //查询 会员卡充值记录
        ///// <summary>
        ///// 查询会员卡充值纪录(MemberCardConcession)
        ///// </summary>
        ///// <param name="condition"></param>
        ///// <returns>string</returns>
        ///// <remarks>
        ///// 作    者: 刘伟
        ///// 创建时间: 2007-10-23
        ///// 修正履历:
        ///// 修正时间:
        ///// </remarks>
        //IList<MemberCardConcession> SearchCRMemberCardConcession(Hashtable condition);

        /// <summary>
        /// 查询会员卡充值记录
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// 作    者: 张晓林
        /// 创建时间: 2009年4月3日11:39:40
        /// 修正履历:
        /// 修正时间:
        /// 
        IList<MemberCardConcession> SearchChargeRecord(Hashtable condition);

        /// <summary>
        /// 查询会员卡充值记录数
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// 作    者: 张晓林
        /// 创建时间: 2009年4月3日11:39:40
        /// 修正履历:
        /// 修正时间:
        /// 
        long SearchChargeRecordRowCount(Hashtable condition);

        ///// <summary>
        ///// 查询会员卡充值纪录(MemberCard)
        ///// </summary>
        ///// <param name="condition"></param>
        ///// <returns>string</returns>
        ///// <remarks>
        ///// 作    者: 刘伟
        ///// 创建时间: 2007-10-23
        ///// 修正履历:
        ///// 修正时间:
        ///// </remarks>
        //IList<MemberCard> SearchCRMemberCard(System.Collections.Hashtable condition);

        ///// <summary>
        ///// 得到Concession(List)相关CampaignName
        ///// </summary>
        ///// <param name="memberCardConcessionList"></param>
        ///// <returns>string</returns>
        ///// <remarks>
        ///// 作    者: 刘伟
        ///// 创建时间: 2007-10-23
        ///// 修正履历:
        ///// 修正时间:
        ///// </remarks>
        //string GetCampaignNames(IList<MemberCardConcession> memberCardConcessionList);
        #endregion


        #region //会员管理记录
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
        /// <summary>
        /// 查询会员卡操作纪录(MemberOperateLog)
        /// </summary>
        /// <param name="condition"></param>
        /// <returns>MemberOperateLogList</returns>
        /// <remarks>
        /// 作    者: 刘伟
        /// 创建时间: 2007-10-24
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        IList<MemberOperateLog> SelectORMemberOperateLog(System.Collections.Hashtable condition);

        /// <summary>
        /// 查询会员卡操作纪录(MemberCard)
        /// </summary>
        /// <param name="condition"></param>
        /// <returns>MemberCardList</returns>
        /// <remarks>
        /// 作    者: 刘伟
        /// 创建时间: 2007-10-24
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        IList<MemberCard> SelectORMemberCard(System.Collections.Hashtable condition);

        ///// <summary>
        ///// 查询会员卡换卡记录(ChangeMemberCard)
        ///// </summary>
        ///// <param name="condition"></param>
        ///// <returns></returns>
        ///// <remarks>
        ///// 作    者: 刘伟
        ///// 创建时间: 2007-10-24
        ///// 修正履历:
        ///// 修正时间:
        ///// </remarks>
        //IList<ChangeMemberCard> SelectCMCChangeMemberCard(System.Collections.Hashtable condition);

        ///// <summary>
        ///// 查询会员卡换卡记录(MemberCard)
        ///// </summary>
        ///// <param name="condition"></param>
        ///// <returns></returns>
        ///// <remarks>
        ///// 作    者: 刘伟
        ///// 创建时间: 2007-10-24
        ///// 修正履历:
        ///// 修正时间:
        ///// </remarks>
        //IList<MemberCard> SelectCMCMemberCard(System.Collections.Hashtable condition);

        #region //查询会员换卡记录
        /// <summary>
        /// 查询会员卡会卡记录
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年4月2日10:24:42
        /// 修正履历:
        /// 修正时间: 
        ///</remarks>
        IList<ChangeMemberCard> SearchChangeMemberCard(Hashtable condition);


        /// <summary>
        /// 查询会员卡会卡记录数
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年4月2日10:24:42
        /// 修正履历:
        /// 修正时间: 
        ///</remarks>
       long SearchChangeMemberCardRowCount(Hashtable condition);

       /// <summary>
       /// 查询会员卡会卡记录(打印)
       /// </summary>
       /// <param name="condition"></param>
       /// <returns></returns>
       /// <remarks>
       /// 作    者: 张晓林
       /// 创建时间: 2009年4月2日10:24:42
       /// 修正履历:
       /// 修正时间: 
       ///</remarks>
        IList<ChangeMemberCard> SearchChangeMemberCardPrint(Hashtable condition);
        #endregion

       /// <summary>
        /// 本日新追加会员卡信息
        /// </summary>
        /// <returns</returns>
        /// <remarks>
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-13
        /// 修正履历:
        /// 修正时间:
        /// </remarks>	
        IList<MemberCard> GetTodayNewMemberCardList();

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
        IList<MemberCard> GetSomeNewMemberCardList(System.Collections.Hashtable condition);


        /// <summary>
        /// 会员卡的消费统计(分页)
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


        /// <summary>
        /// 获取匹配的会员参加优惠信息
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年4月17日14:56:27
        /// 修正履历:
        /// 修正时间:
        /// 描    述:
        /// </remarks>
        MemberCardConcession GetMemberCardConcession(MemberCardConcession memberCardConcession); 

         /// <summary>
        /// 获取会员卡优惠方案业务明细列表
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年4月15日13:54:16
        /// 修正履历:
        /// 修正时间:
        /// 描    述:
        /// </remarks>
        BaseBusinessTypePriceSet GetMemberCardBaseBusniessSet(long baseBusniessTypeId);

        /// <summary>
        /// 获取会员卡消费的业务类型明细
        /// </summary>
        /// <param name="memberCardId"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者:张晓林 
        /// 创建时间: 2009年4月16日10:44:31
        /// 修正履历:
        /// 修正时间:
        /// 描    述:
        /// </remarks>
        IList<Order> GetMemberCardBaseBusItem(MemberCard memberCard);
    }
}
