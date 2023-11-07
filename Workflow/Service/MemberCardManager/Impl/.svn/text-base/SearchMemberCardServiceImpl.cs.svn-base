using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Workflow.Da;
using Workflow.Da.Domain;
namespace Workflow.Service.MemberCardManager.Impl
{
    /// <summary>
    /// 名    称: SearchMemberCardServiceImpl
    /// 功能概要: 会员卡查询的Service
    /// 作    者: 张晓林
    /// 创建时间: 2009-1-19
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    public class SearchMemberCardServiceImpl : ISearchMemberCardService
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

        private IBaseBusinessTypePriceSetDao baseBusinessTypePriceSetDao;
        public IBaseBusinessTypePriceSetDao BaseBusinessTypePriceSetDao 
        {
            set { baseBusinessTypePriceSetDao = value; }
        }
        #endregion



        #region //查询会员卡充值纪录
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
        public IList<MemberCardConcession> SearchChargeRecord(Hashtable condition) 
        {
            return memberCardConcessionDao.SearchChargeRecord(condition);
        }

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
        public long SearchChargeRecordRowCount(Hashtable condition) 
        {
            return memberCardConcessionDao.SearchChargeRecordRowCount(condition);
        }
        //#region 查询会员卡充值纪录(MemberCardConcession)
        //public IList<MemberCardConcession> SearchCRMemberCardConcession(System.Collections.Hashtable condition)
        //{
        //    return memberCardConcessionDao.SelectChargeRecord(condition);
        //}
        //#endregion

        //public IList<MemberCard> SearchCRMemberCard(Hashtable condition)
        //{
        //    return memberCardDao.SelectChargeRecord(condition);
        //}

        //#region 得到Concession(List)相关CampaignName
        //public string GetCampaignNames(IList<MemberCardConcession> memberCardConcessionList)
        //{
        //    string campaignNames = "";

        //    for (int i = 0; i < memberCardConcessionList.Count; i++)
        //    {
        //        campaignNames += concessionDao.SelectCampaignNameByConcessionId(memberCardConcessionList[i].Concession.Id);
        //        campaignNames += ",";
        //    }

        //    return campaignNames;
        //}
        //#endregion
        #endregion

        #region //查询会员换卡记录
        /// <summary>
        /// 查询会员卡会卡记录(分页)
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年4月2日10:24:42
        /// 修正履历:
        /// 修正时间: 
        ///</remarks>
        public IList<ChangeMemberCard> SearchChangeMemberCard(Hashtable condition) 
        {
            return changeMemberCardDao.SearchChangeMemberCard(condition);
        }

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
        public long SearchChangeMemberCardRowCount(Hashtable condition)
        {
            return changeMemberCardDao.SearchChangeMemberCardRowCount(condition);
        }

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
        public IList<ChangeMemberCard> SearchChangeMemberCardPrint(Hashtable condition) 
        {
            return changeMemberCardDao.SearchChangeMemberCardPrint(condition);
        }
        #endregion

        #region 查询会员卡操作纪录(MemberOperateLog)
        public IList<MemberOperateLog> SelectORMemberOperateLog(System.Collections.Hashtable condition)
        {
            return memberOperateLogDao.SelectOperateLog(condition);
        }
        #endregion

        #region 查询会员卡操作纪录(MemberCard)
        public IList<MemberCard> SelectORMemberCard(System.Collections.Hashtable condition)
        {
            return memberCardDao.SelectOperateLog(condition);
        }
        #endregion

        //#region 查询换卡记录(ChangeMemberCard)
        //public IList<ChangeMemberCard> SelectCMCChangeMemberCard(System.Collections.Hashtable condition)
        //{
        //    return changeMemberCardDao.SelectChangMemberCard(condition);
        //}
        //#endregion

        //#region 查询换卡记录(MemberCard)
        //public IList<MemberCard> SelectCMCMemberCard(System.Collections.Hashtable condition)
        //{
        //    return memberCardDao.SelectChangeMemberCard(condition);
        //}
        //#endregion

        #region  根据卡号Id和顾客Id判断卡是否存在
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
        public IList<MemberCard> CheckMemberCardNo(Hashtable hashCondition)
        {
            return memberCardDao.CheckMemberCardNo(hashCondition);
        }
        #endregion

        #region //查询会员卡信息
        /// <summary>
        /// 名    称: SearchMemberCard
        /// 功能概要: 查询会员卡信息(分页)
        /// 作    者: liuwei
        /// 创建时间: 2007-9-29
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IList<MemberCard> SearchMemberCard(System.Collections.Hashtable condition)
        {
            return memberCardDao.SearchMemberCard(condition);
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
            return memberCardDao.SearchMemberCardRowCount(condition);
        } 
        #endregion

        #region 通过Id查询会员卡信息
        public MemberCard SearchMemberCardById(long Id)
        {
            return memberCardDao.SelectByPk(Id);
        }

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
            return memberCardDao.SearchMemberById(Id);
        }
        #endregion

        #region 通过MemberCardNo查询会员卡信息(只查询正常状态的卡)
        public MemberCard SearchMemberCardByCardNo(string memberCardNo)
        {
            return memberCardDao.SearchSelectMemberCardByCardNo(memberCardNo);
        }
        #endregion

        #region 通过MemberCardNo查询会员卡信息(查询所有状态的卡)

        public MemberCard SearchAllMemberCardByCardNo(string memberCardNo)
        {
            return memberCardDao.SelectAllMemberCardByCardNo(memberCardNo);
        }
        #endregion

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
            return memberCardDao.SearchMemberCardConsumeAmount(memberCardId);
        }

        #region 通过IdentityCardNo查询MemberCardInfo
        public IList<MemberCard> SearchMemberCardByIdentityCard(Hashtable hashtable)
        {
            return memberCardDao.SearchMemberCardByIdentityCard(hashtable);
        }
        #endregion

        #region 通过MemberCardNo和PassWord查询会员卡信息
        public int SearchMemberCardByMemberCardNo(System.Collections.Hashtable condition)
        {
            return memberCardDao.SelectMemberCardByMemberCardNoAndPassWord(condition);
        }
        #endregion

        #region 获取所有的会员卡信息
        /// <summary>
        /// 获得当日会员卡
        /// </summary>
        /// <returns></returns>
        public IList<MemberCard> GetTodayNewMemberCardList()
        {
            return memberCardDao.SelectTodayNewMemberCard();
        }

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
        public IList<MemberCard> GetSomeNewMemberCardList(System.Collections.Hashtable condition)
        {
            return memberCardDao.SelectSomeNewMemberCard(condition);
        }


        /// <summary>
        /// 获得会员卡一览
        /// </summary>
        /// <returns></returns>
        public IList<MemberCard> GetMemberCardList()
        {
            return memberCardDao.SelectAll();
        }
        #endregion

        #region 判定该卡是否存在
        public int SearchWhetherMemberCardNo(string memberCardNo)
        {
            return memberCardDao.SearchWheterMemberCardNo(memberCardNo);
        }
        #endregion

        #region //通过MemberCardNo查询该卡参加的营销活动(Campaign)
        /// <summary>
        /// 通过MemberCardNo查询该卡参加的营销活动
        /// </summary>
        /// <param name="memberCardNo"></param>
        /// <returns></returns>
        public string SearchMemberCardCampaign(string memberCardNo)
        {
            string campaigns = "";

            MemberCard memberCard = memberCardDao.SelectAllMemberCardByCardNo(memberCardNo);

            if (memberCard != null)
            {
                if (memberCard.MemberCardConcessionList.Count != 0)
                {
                    for (int i = 0; i < memberCard.MemberCardConcessionList.Count; i++)
                    {
                        campaigns += concessionDao.SelectCampaignNameByConcessionId(memberCard.MemberCardConcessionList[i].Concession.Id);
                        campaigns += ",";
                    }
                }
            }

            return campaigns;
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
            return memberCardDao.GetMemberCardConsume(order);
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
            return memberCardDao.GetMemberCardConsumeRowCount(order);
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
            return memberCardDao.GetMemberCardConsumePrint(order);
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
            return memberCardDao.SearchMemberCardIdInOrdersRowCount(membercardId);
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
            return memberCardDao.SearchOperateLog(condition);
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
            return memberCardDao.SearchOperateLogRowCount(condition);
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
            return memberCardDao.SearchOperateLogPrint(condition);
        }
        #endregion

        #region //获取会员参加优惠的业务类型类型列表
        /// <summary>
        /// 获取会员参加优惠的业务类型类型列表
        /// </summary>
        /// <remarks>
        /// 作    者: 
        /// 创建时间: 
        /// 修正履历:张晓林
        /// 修正时间:2009年4月15日13:54:16
        /// 描    述:
        /// </remarks>
        public IList<MemberCardConcession> GetMemberCardConcessionBaseBusniessInfo(long memberCardId) 
        {
            return memberCardDao.GetMemberCardConcessionBaseBusniessInfo(memberCardId);
        }
        #endregion

        #region //获取会员卡优惠方案业务明细列表
        /// <summary>
        /// 获取会员卡优惠方案业务明细
        /// </summary>
        /// <remarks>
        /// 作    者: 
        /// 创建时间: 
        /// 修正履历:张晓林
        /// 修正时间:2009年4月15日13:54:16
        /// 描    述:
        /// </remarks>
        public BaseBusinessTypePriceSet GetMemberCardBaseBusniessSet(long baseBusniessTypeId) 
        {
            return baseBusinessTypePriceSetDao.SelectByPk(baseBusniessTypeId);
        }
        #endregion

        #region //获取会员卡消费的业务类型明细
        /// <summary>
        /// 获取会员卡参与的业务类型明细
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
        public IList<Order> GetMemberCardBaseBusItem(MemberCard memberCard) 
        {
            return baseBusinessTypePriceSetDao.GetMemberCardBaseBusItem(memberCard);
        }
        #endregion

        #region //获取匹配的会员参加优惠信息
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
        public MemberCardConcession GetMemberCardConcession(MemberCardConcession memberCardConcession)
        {
            return memberCardConcessionDao.GetMemberCardConcession(memberCardConcession);
        }
        #endregion
    }
}
