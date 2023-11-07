using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;
using Workflow.Support.Encrypt;
using System.Collections;
using Workflow.Support;
namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table MEMBER_CARD 对应的Dao 实现
	/// </summary>
    public class MemberCardDaoImpl : Workflow.Da.Base.DaoBaseImpl<MemberCard>, IMemberCardDao
    {
        
        #region //查询会员卡信息
        /// <summary>
        /// 名    称: SearchMemberCard
        /// 功能概要: 查询会员卡信息(分页)
        /// 作    者: liuwei
        /// 创建时间: 2007-9-29
        /// 修正履历:张晓林
        /// 修正时间:2009-02-11
        /// 修正描述:增加公司和分店查询条件，增加分页功能
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IList<MemberCard> SearchMemberCard(System.Collections.Hashtable condition)
        {
            condition.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            condition.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            return sqlMap.QueryForList<MemberCard>("MemberCard.SearchMemberCard", condition);
        }

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
        public long SearchMemberCardRowCount(Hashtable condition) 
        {
            condition.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            condition.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            return sqlMap.QueryForObject<long>("MemberCard.SearchMemberCardRowCount", condition);
        }

        #endregion

        #region 根据卡号和客户Id 判定会员卡密码是否正确(张晓林2008-12-18 修正)

        public int SelectMemberCardByMemberCardNoAndPassWord(System.Collections.Hashtable condition)
        {
            condition.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            condition.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            object obj = sqlMap.QueryForObject("MemberCard.SelectMemberCardByMemberCardNoAndPassWord", condition);
            int iNumber = (int)obj;
            return iNumber;
        }

        #endregion

        #region 判定该卡是否存在(张晓林2008-12-19 修正)
        public int SearchWheterMemberCardNo(string memberCardNo)
        {
            Hashtable hashCodition = new Hashtable();
            hashCodition.Add("MemberCardNo", memberCardNo.Trim().ToLower());
            hashCodition.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            hashCodition.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            object obj = sqlMap.QueryForObject("MemberCard.SelectMemberCardNo", hashCodition);
            int iNumber = (int)obj;

            return iNumber;
        }
        #endregion

        #region 通过IdentityCardNo查询MemberCardInfo
        public IList<MemberCard> SearchMemberCardByIdentityCard(Hashtable hashtable)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            hashtable.Add("BranchShopId", user.BranchShopId);
            hashtable.Add("CompanyId", user.CompanyId);
			//注销
			if (Convert.ToInt32(hashtable["Tag"]) == 3)//正常卡/挂失卡/恢复卡
			{
				return sqlMap.QueryForList<MemberCard>("MemberCard.SelectMemberCardByIdentityCardReportLossMemberCard", hashtable);
			}
			else if (Convert.ToInt32(hashtable["Tag"])== 2)//挂失卡 
			{
				return sqlMap.QueryForList<MemberCard>("MemberCard.SelectMemberCardByIdentityCard",hashtable);
			}
			return null;
        }
        #endregion

        #region 通过MemberCardNo查询MemberCard(只查询正常状态的)
        public MemberCard SearchSelectMemberCardByCardNo(string memberCardNo)
        {
            Hashtable condtion = new Hashtable();
            condtion.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            condtion.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            condtion.Add("MemberCardNo", memberCardNo);
            condtion.Add("MemberState", Constants.MEMBER_CARD_STATE_NATURAL_KEY);
            return sqlMap.QueryForObject<MemberCard>("MemberCard.SelectMemberCardByCardNo", condtion);
        }
        #endregion

        #region //根据卡号查询卡明细 
        /// <summary>
        /// 根据卡号查询卡明细 
        /// </summary>
        /// <param name="memberCardNo"></param>
        /// <returns></returns>
        public MemberCard SelectAllMemberCardByCardNo(string memberCardNo)
        {
            Hashtable condition = new Hashtable();
            condition.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            condition.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            condition.Add("MemberCardNo", memberCardNo);
            return sqlMap.QueryForObject<MemberCard>("MemberCard.SelectAllMemberCardByCardNo", condition);
        }

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
        public MemberCard SearchMemberCardConsumeAmount(long memberCardId) 
        {
            Hashtable condition = new Hashtable();
            condition.Add("CompanyId",ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            condition.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            condition.Add("Status", Constants.ORDER_STATUS_SUCCESSED_VALUE);
            condition.Add("MemberCardId", memberCardId);
            return sqlMap.QueryForObject<MemberCard>("MemberCard.SearchMemberCardConsumeAmount", condition);
        }
        #endregion

        #region 更新MemberCard的状态
        public void UpdateMemberState(System.Collections.Hashtable condition)
        {
            sqlMap.Update("MemberCard.UpdateMemberState", condition);
        }
        #endregion

        #region 通过CustomerId更改deleted= '1'
        public void UpdateByCustomerId(long Id)
        {
            sqlMap.Update("MemberCard.DeleteMemberCard", Id);
        }
        #endregion

        #region 查询会员卡充值记录(MemberCard)
        public IList<MemberCard> SelectChargeRecord(System.Collections.Hashtable condition)
        {
            return sqlMap.QueryForList<MemberCard>("MemberCard.SelectChargeRecord", condition);
        }
        #endregion

        #region 查询会员卡操作记录(MemberCard)
        public IList<MemberCard> SelectOperateLog(System.Collections.Hashtable condition)
        {
            return sqlMap.QueryForList<MemberCard>("MemberCard.SelectOperateLog", condition);
        }
        #endregion

        #region 查询换卡记录
        public IList<MemberCard> SelectChangeMemberCard(System.Collections.Hashtable condition)
        {
            return sqlMap.QueryForList<MemberCard>("MemberCard.SelectChangeMemberCard",condition);
        }
        #endregion

        #region //获得当天新办理的会员卡
        /// <summary>
        /// 获得当天新办理的会员卡
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-13
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public IList<MemberCard> SelectTodayNewMemberCard()
        {
            return sqlMap.QueryForList<MemberCard>("MemberCard.SelectTodayNewMemberCard", null);
        }
        #endregion

        #region //按时段获取办理的会员卡
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
        public IList<MemberCard> SelectSomeNewMemberCard(System.Collections.Hashtable condition)
        {
            condition.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            condition.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            return sqlMap.QueryForList<MemberCard>("MemberCard.SelectSomeNewMemberCard", condition);
        }
        #endregion

        #region //通过会员卡ID更新会员卡已消费金额
        /// 通过会员卡ID更新会员卡已消费金额
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-22
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public void UpdateMemberCardConsumeAmount(MemberCard memberCard)
        {
            sqlMap.Update("MemberCard.UpdateMemberCardConsumAmountById", memberCard);
        }
        #endregion

        #region //通过会员卡号查找相关客户信息
        /// 通过会员卡号查找相关客户信息
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-23
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public MemberCard SelectCustomerInfoByMemberCardNo(string memberCardNo)
        {
            Hashtable ht = new Hashtable();
            ht.Add("MemberCardNo", memberCardNo);
            ht.Add("Status", Constants.MEMBER_CARD_STATE_NATURAL_KEY);
            ht.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            ht.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            return sqlMap.QueryForObject<MemberCard>("MemberCard.SelectCustomerInfoByMemberCard", ht);
        }
        #endregion

        #region //根据卡Id和雇员ID区判断卡号的
        /// 根据卡Id和雇员ID区判断卡号的
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2008-12-17
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public IList<MemberCard> CheckMemberCardNo(Hashtable hashCondition) 
        {
            hashCondition.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            hashCondition.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            //hashCondition.Add("MemberCardState", Workflow.Support.Constants.MEMBER_CARD_OPERATE_LOGOUT_KEY);
            return sqlMap.QueryForList<MemberCard>("MemberCard.SelectMemberCardByCustomerIdAndMemberCardId", hashCondition);
        }
        #endregion

        #region //会员卡的消费统计
        /// <summary>
        /// 会员卡的消费统计
        /// </summary>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-27
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public IList<Order> GetMemberCardConsume(Order order)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            order.BranchShopId = user.BranchShopId;
            order.CompanyId = user.CompanyId;
            return sqlMap.QueryForList<Order>("MemberCardConcession.SelectMemberCardConsume", order);
        }

        /// <summary>
        /// 会员卡的消费统计记录数
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年4月3日10:53:10
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public long GetMemberCardConsumeRowCount(Order order) 
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            order.BranchShopId = user.BranchShopId;
            order.CompanyId = user.CompanyId;
            return sqlMap.QueryForObject<long>("MemberCardConcession.GetMemberCardConsumeRowCount", order);
        }

        /// <summary>
        /// 会员卡的消费统计(打印)
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年4月3日10:53:10
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public IList<Order> GetMemberCardConsumePrint(Order order) 
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            order.BranchShopId = user.BranchShopId;
            order.CompanyId = user.CompanyId;
            return sqlMap.QueryForList<Order>("MemberCardConcession.GetMemberCardConsumePrint", order);
        }
        #endregion

        #region //获取该会员在Order中的记录数
        /// <summary>
        /// 获取该会员在Order中的记录数
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年2月13日
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public long SearchMemberCardIdInOrdersRowCount(string membercardId) 
        {
            Hashtable condition = new Hashtable();
            condition.Add("BranchShopId",ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            condition.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            condition.Add("MemberCardId", membercardId);
            return sqlMap.QueryForObject<long>("MemberCard.SearchMemberCardIdInOrdersRowCount", condition);
        }
        #endregion

        #region //通过Id查询会员信息
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
        public MemberCard SearchMemberById(long Id) 
        {
            Hashtable condition = new Hashtable();
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            condition.Add("BranchShopId",user.BranchShopId);
            condition.Add("CompanyId", user.CompanyId);
            if (Id != 0)
            {
                condition.Add("Id", Id);
            }
            return sqlMap.QueryForObject<MemberCard>("MemberCard.SearchMemberById", condition);
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
            Hashtable condition = new Hashtable();
            condition.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            condition.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            condition.Add("MemberCardId", Id);
           sqlMap.Update("MemberCard.UpdateMemberCardById", condition);
        }
        #endregion

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
        public IList<MemberCard> SearchOperateLog(Hashtable condition)
        {
            condition.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            condition.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            return sqlMap.QueryForList<MemberCard>("MemberOperateLog.SearchOperateLog", condition);
        }

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
        public long SearchOperateLogRowCount(Hashtable condition)
        {
            return sqlMap.QueryForObject<long>("MemberOperateLog.SearchOperateLogRowCount", condition);
        }

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
        public IList<MemberCard> SearchOperateLogPrint(Hashtable condition)
        {
            return sqlMap.QueryForList<MemberCard>("MemberOperateLog.SearchOperateLogPrint", condition);
        }
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
        public IList<MemberCardConcession> GetMemberCardConcessionBaseBusniessInfo(long memberCardId) 
        {
            Hashtable condition = new Hashtable();
            condition.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            condition.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            condition.Add("MemberCardId", memberCardId);
            return sqlMap.QueryForList<MemberCardConcession>("MemberCardConcession.GetMemberCardConcessionBaseBusniessInfo", condition);
        }
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
        public void MemberCardDiff(MemberCard.MemberCardBaseBusinessTypeItem memberCardBaseBusinessTypeItem) 
        {
            MemberCardConcession memberCardConcession = new MemberCardConcession();
            memberCardConcession.ConcessionId = memberCardBaseBusinessTypeItem.CompanyId;//ConcessionId
            memberCardConcession.MemberCardId = memberCardBaseBusinessTypeItem.MemberCardId;
            memberCardConcession.Amount = (long)memberCardBaseBusinessTypeItem.BaseBusAmount;//冲减的印章数
            memberCardConcession.PaperCount = memberCardBaseBusinessTypeItem.BaseBusUnitPrice;//memberCardBaseBusinessTypeItem.BaseBusAmount*memberCardBaseBusinessTypeItem.BaseBusUnitPrice;//冲减的收款金额
            sqlMap.Update("MemberCardConcession.MemberCardDiff", memberCardConcession);
        }
        #endregion

        #region//累计会员积分
        /// <summary>
        /// 名   称:  UpdateMemberCardMarkingSetting
        /// 功能概要: 更新会员积分
        /// 作    者: 张晓林
        /// 创建时间: 2009年10月29日13:29:39
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void UpdateMemberCardMarkingSetting(MemberCard memberCard) 
        {
            memberCard.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            memberCard.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            sqlMap.Update("MemberCard.UpdateMemberCardMarkingSetting", memberCard);
        }
        #endregion
    }
}
