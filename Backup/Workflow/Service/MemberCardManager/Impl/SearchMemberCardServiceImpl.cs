using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Workflow.Da;
using Workflow.Da.Domain;
namespace Workflow.Service.MemberCardManager.Impl
{
    /// <summary>
    /// ��    ��: SearchMemberCardServiceImpl
    /// ���ܸ�Ҫ: ��Ա����ѯ��Service
    /// ��    ��: ������
    /// ����ʱ��: 2009-1-19
    /// ��������: 
    /// ����ʱ��: 
    /// </summary>
    public class SearchMemberCardServiceImpl : ISearchMemberCardService
    {
        #region ע��Dao
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



        #region //��ѯ��Ա����ֵ��¼
        /// <summary>
        /// ��ѯ��Ա����ֵ��¼
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// ��    ��: ������
        /// ����ʱ��: 2009��4��3��11:39:40
        /// ��������:
        /// ����ʱ��:
        /// 
        public IList<MemberCardConcession> SearchChargeRecord(Hashtable condition) 
        {
            return memberCardConcessionDao.SearchChargeRecord(condition);
        }

        /// <summary>
        /// ��ѯ��Ա����ֵ��¼��
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// ��    ��: ������
        /// ����ʱ��: 2009��4��3��11:39:40
        /// ��������:
        /// ����ʱ��:
        ///
        public long SearchChargeRecordRowCount(Hashtable condition) 
        {
            return memberCardConcessionDao.SearchChargeRecordRowCount(condition);
        }
        //#region ��ѯ��Ա����ֵ��¼(MemberCardConcession)
        //public IList<MemberCardConcession> SearchCRMemberCardConcession(System.Collections.Hashtable condition)
        //{
        //    return memberCardConcessionDao.SelectChargeRecord(condition);
        //}
        //#endregion

        //public IList<MemberCard> SearchCRMemberCard(Hashtable condition)
        //{
        //    return memberCardDao.SelectChargeRecord(condition);
        //}

        //#region �õ�Concession(List)���CampaignName
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

        #region //��ѯ��Ա������¼
        /// <summary>
        /// ��ѯ��Ա���Ῠ��¼(��ҳ)
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��4��2��10:24:42
        /// ��������:
        /// ����ʱ��: 
        ///</remarks>
        public IList<ChangeMemberCard> SearchChangeMemberCard(Hashtable condition) 
        {
            return changeMemberCardDao.SearchChangeMemberCard(condition);
        }

        /// <summary>
        /// ��ѯ��Ա���Ῠ��¼
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��4��2��10:24:42
        /// ��������:
        /// ����ʱ��: 
        ///</remarks>
        public long SearchChangeMemberCardRowCount(Hashtable condition)
        {
            return changeMemberCardDao.SearchChangeMemberCardRowCount(condition);
        }

        /// <summary>
        /// ��ѯ��Ա���Ῠ��¼(��ӡ)
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��4��2��10:24:42
        /// ��������:
        /// ����ʱ��: 
        ///</remarks>
        public IList<ChangeMemberCard> SearchChangeMemberCardPrint(Hashtable condition) 
        {
            return changeMemberCardDao.SearchChangeMemberCardPrint(condition);
        }
        #endregion

        #region ��ѯ��Ա��������¼(MemberOperateLog)
        public IList<MemberOperateLog> SelectORMemberOperateLog(System.Collections.Hashtable condition)
        {
            return memberOperateLogDao.SelectOperateLog(condition);
        }
        #endregion

        #region ��ѯ��Ա��������¼(MemberCard)
        public IList<MemberCard> SelectORMemberCard(System.Collections.Hashtable condition)
        {
            return memberCardDao.SelectOperateLog(condition);
        }
        #endregion

        //#region ��ѯ������¼(ChangeMemberCard)
        //public IList<ChangeMemberCard> SelectCMCChangeMemberCard(System.Collections.Hashtable condition)
        //{
        //    return changeMemberCardDao.SelectChangMemberCard(condition);
        //}
        //#endregion

        //#region ��ѯ������¼(MemberCard)
        //public IList<MemberCard> SelectCMCMemberCard(System.Collections.Hashtable condition)
        //{
        //    return memberCardDao.SelectChangeMemberCard(condition);
        //}
        //#endregion

        #region  ���ݿ���Id�͹˿�Id�жϿ��Ƿ����
        /// <summary>
        /// ���ݿ���Id�͹˿�Id�жϿ��Ƿ����
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2008-12-17
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        public IList<MemberCard> CheckMemberCardNo(Hashtable hashCondition)
        {
            return memberCardDao.CheckMemberCardNo(hashCondition);
        }
        #endregion

        #region //��ѯ��Ա����Ϣ
        /// <summary>
        /// ��    ��: SearchMemberCard
        /// ���ܸ�Ҫ: ��ѯ��Ա����Ϣ(��ҳ)
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-9-29
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IList<MemberCard> SearchMemberCard(System.Collections.Hashtable condition)
        {
            return memberCardDao.SearchMemberCard(condition);
        }

        /// <summary>
        /// ��    ��: SearchMemberCardRowCount
        /// ���ܸ�Ҫ: ��ѯ��Ա����Ϣ��¼��
        /// ��    ��: ������
        /// ����ʱ��: 2009-02-11
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public long SearchMemberCardRowCount(Hashtable condition) 
        {
            return memberCardDao.SearchMemberCardRowCount(condition);
        } 
        #endregion

        #region ͨ��Id��ѯ��Ա����Ϣ
        public MemberCard SearchMemberCardById(long Id)
        {
            return memberCardDao.SelectByPk(Id);
        }

        /// <summary>
        /// ��    ��: SearchMemberById
        /// ���ܸ�Ҫ: ͨ��Id��ѯ��Ա��Ϣ
        /// ��    ��: ������
        /// ����ʱ��: 2009��2��12��11:35:57
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public MemberCard SearchMemberById(long Id) 
        {
            return memberCardDao.SearchMemberById(Id);
        }
        #endregion

        #region ͨ��MemberCardNo��ѯ��Ա����Ϣ(ֻ��ѯ����״̬�Ŀ�)
        public MemberCard SearchMemberCardByCardNo(string memberCardNo)
        {
            return memberCardDao.SearchSelectMemberCardByCardNo(memberCardNo);
        }
        #endregion

        #region ͨ��MemberCardNo��ѯ��Ա����Ϣ(��ѯ����״̬�Ŀ�)

        public MemberCard SearchAllMemberCardByCardNo(string memberCardNo)
        {
            return memberCardDao.SelectAllMemberCardByCardNo(memberCardNo);
        }
        #endregion

        /// <summary>
        /// ���ݿ��Ż�ȡ�ÿ����ѵ��ܽ��
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��4��3��17:57:34
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        public MemberCard SearchMemberCardConsumeAmount(long memberCardId)
        {
            return memberCardDao.SearchMemberCardConsumeAmount(memberCardId);
        }

        #region ͨ��IdentityCardNo��ѯMemberCardInfo
        public IList<MemberCard> SearchMemberCardByIdentityCard(Hashtable hashtable)
        {
            return memberCardDao.SearchMemberCardByIdentityCard(hashtable);
        }
        #endregion

        #region ͨ��MemberCardNo��PassWord��ѯ��Ա����Ϣ
        public int SearchMemberCardByMemberCardNo(System.Collections.Hashtable condition)
        {
            return memberCardDao.SelectMemberCardByMemberCardNoAndPassWord(condition);
        }
        #endregion

        #region ��ȡ���еĻ�Ա����Ϣ
        /// <summary>
        /// ��õ��ջ�Ա��
        /// </summary>
        /// <returns></returns>
        public IList<MemberCard> GetTodayNewMemberCardList()
        {
            return memberCardDao.SelectTodayNewMemberCard();
        }

        /// <summary>
        /// ��ʱ�λ�ȡ����Ļ�Ա��
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: �쾲��
        /// ����ʱ��: 2008-11-04
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        public IList<MemberCard> GetSomeNewMemberCardList(System.Collections.Hashtable condition)
        {
            return memberCardDao.SelectSomeNewMemberCard(condition);
        }


        /// <summary>
        /// ��û�Ա��һ��
        /// </summary>
        /// <returns></returns>
        public IList<MemberCard> GetMemberCardList()
        {
            return memberCardDao.SelectAll();
        }
        #endregion

        #region �ж��ÿ��Ƿ����
        public int SearchWhetherMemberCardNo(string memberCardNo)
        {
            return memberCardDao.SearchWheterMemberCardNo(memberCardNo);
        }
        #endregion

        #region //ͨ��MemberCardNo��ѯ�ÿ��μӵ�Ӫ���(Campaign)
        /// <summary>
        /// ͨ��MemberCardNo��ѯ�ÿ��μӵ�Ӫ���
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

        #region //��Ա��������ͳ��
        /// <summary>
        /// ��Ա��������ͳ��
        /// </summary>
        /// <remarks>
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-10-27
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        public IList<Order> GetMemberCardConsume(Order order)
        {
            return memberCardDao.GetMemberCardConsume(order);
        }

        /// <summary>
        /// ��Ա��������ͳ�Ƽ�¼��
        /// </summary>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��4��3��10:53:10
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        public long GetMemberCardConsumeRowCount(Order order) 
        {
            return memberCardDao.GetMemberCardConsumeRowCount(order);
        }

        /// <summary>
        /// ��Ա��������ͳ��(��ӡ)
        /// </summary>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��4��3��10:53:10
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        public IList<Order> GetMemberCardConsumePrint(Order order) 
        {
            return memberCardDao.GetMemberCardConsumePrint(order);
        }
        #endregion

        #region //��ȡ�û�Ա��Order�еļ�¼��
        /// <summary>
        /// ��ȡ�û�Ա��Order�еļ�¼��
        /// </summary>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��2��13��
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        public long SearchMemberCardIdInOrdersRowCount(string membercardId) 
        {
            return memberCardDao.SearchMemberCardIdInOrdersRowCount(membercardId);
        }
        #endregion

        #region //��Ա������¼
        /// <summary>
        ///��ȡ��Ա�������б�(��ҳ) 
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// <remarks>
        /// ��     ��:������
        /// ����ʱ�䣺2009��4��6��10:19:40
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        public IList<MemberCard> SearchOperateLog(Hashtable condition) 
        {
            return memberCardDao.SearchOperateLog(condition);
        }

        /// <summary>
        ///��ȡ��Ա������¼��
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// <remarks>
        /// ��     ��:������
        /// ����ʱ�䣺2009��4��6��10:19:40
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        public long SearchOperateLogRowCount(Hashtable condition) 
        {
            return memberCardDao.SearchOperateLogRowCount(condition);
        }

        /// <summary>
        ///��ȡ��Ա������¼(��ӡ)
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// <remarks>
        /// ��     ��:������
        /// ����ʱ�䣺2009��4��6��10:19:40
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        public IList<MemberCard> SearchOperateLogPrint(Hashtable condition) 
        {
            return memberCardDao.SearchOperateLogPrint(condition);
        }
        #endregion

        #region //��ȡ��Ա�μ��Żݵ�ҵ�����������б�
        /// <summary>
        /// ��ȡ��Ա�μ��Żݵ�ҵ�����������б�
        /// </summary>
        /// <remarks>
        /// ��    ��: 
        /// ����ʱ��: 
        /// ��������:������
        /// ����ʱ��:2009��4��15��13:54:16
        /// ��    ��:
        /// </remarks>
        public IList<MemberCardConcession> GetMemberCardConcessionBaseBusniessInfo(long memberCardId) 
        {
            return memberCardDao.GetMemberCardConcessionBaseBusniessInfo(memberCardId);
        }
        #endregion

        #region //��ȡ��Ա���Żݷ���ҵ����ϸ�б�
        /// <summary>
        /// ��ȡ��Ա���Żݷ���ҵ����ϸ
        /// </summary>
        /// <remarks>
        /// ��    ��: 
        /// ����ʱ��: 
        /// ��������:������
        /// ����ʱ��:2009��4��15��13:54:16
        /// ��    ��:
        /// </remarks>
        public BaseBusinessTypePriceSet GetMemberCardBaseBusniessSet(long baseBusniessTypeId) 
        {
            return baseBusinessTypePriceSetDao.SelectByPk(baseBusniessTypeId);
        }
        #endregion

        #region //��ȡ��Ա�����ѵ�ҵ��������ϸ
        /// <summary>
        /// ��ȡ��Ա�������ҵ��������ϸ
        /// </summary>
        /// <param name="memberCardId"></param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��:������ 
        /// ����ʱ��: 2009��4��16��10:44:31
        /// ��������:
        /// ����ʱ��:
        /// ��    ��:
        /// </remarks>
        public IList<Order> GetMemberCardBaseBusItem(MemberCard memberCard) 
        {
            return baseBusinessTypePriceSetDao.GetMemberCardBaseBusItem(memberCard);
        }
        #endregion

        #region //��ȡƥ��Ļ�Ա�μ��Ż���Ϣ
        /// <summary>
        /// ��ȡƥ��Ļ�Ա�μ��Ż���Ϣ
        /// </summary>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��4��17��14:56:27
        /// ��������:
        /// ����ʱ��:
        /// ��    ��:
        /// </remarks>
        public MemberCardConcession GetMemberCardConcession(MemberCardConcession memberCardConcession)
        {
            return memberCardConcessionDao.GetMemberCardConcession(memberCardConcession);
        }
        #endregion
    }
}
