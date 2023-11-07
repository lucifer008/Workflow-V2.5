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
    /// ��    ��: MemberCardServiceImpl
    /// ���ܸ�Ҫ: ��Ա��������Service
    /// ��    ��: ������
    /// ����ʱ��: 2009-1-19
    /// ��������: 
    /// ����ʱ��: 
    /// </summary>
    public class MemberCardServiceImpl: IMemberCardService
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

		#region ע�� memberCardConcessionGatheringDao

		private IMemberCardConcessionGatheringDao memberCardConcessionGatheringDao;
		/// <summary>
		/// ע�� memberCardConcessionGatheringDao
		/// </summary>
		public IMemberCardConcessionGatheringDao MemberCardConcessionGatheringDao
		{
			set { memberCardConcessionGatheringDao = value; }
		}

		#endregion

		#region ע�� memberCardDiscountConcessionDao

		private IMemberCardDiscountConcessionDao memberCardDiscountConcessionDao;
		/// <summary>
		/// ע�� memberCardDiscountConcessionDao
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

		#region //�����Ա��
		/// <summary>
        /// ��    ��: InsertMemberCard
        /// ���ܸ�Ҫ: ��Ա����������
        /// ��    ��: ��ΰ
        /// ����ʱ��: 2007-9-30
        /// ��������: ������
        /// ����ʱ��: 2009��2��13��
        /// ��������: ���漰���ķ����������з�װ��һ�������� 
        /// </summary>
        /// <param name="memberCard">��Ա��Ϣ</param>
        /// <param name="customer">��Ա�����Ŀͻ���Ϣ</param>
        /// <param name="memberOperateLog">��Ա��������¼</param>
        [Transaction]
        public void InsertMemberCard(MemberCard memberCard,Customer customer,MemberOperateLog memberOperateLog)
        {
            memberCardDao.Insert(memberCard);
            customerDao.Update(customer);
            //�����Ա��������¼
            Hashtable condition = new Hashtable();
            condition.Add("MemberCardNo", memberCard.MemberCardNo);
            condition.Add("CustomerId", memberCard.CustomerId);
            IList<MemberCard> membercardList=memberCardDao.CheckMemberCardNo(condition);
            memberOperateLog.MemberCardId = membercardList[0].Id;
            memberOperateLogDao.Insert(memberOperateLog);
        }
        #endregion

        #region //�޸Ļ�Ա��Ϣ

        /// <summary>
        /// ��    ��: UpdateMemberCard
        /// ���ܸ�Ҫ: �޸Ļ�Ա����Ϣ
        /// ��    ��: ������
        /// ����ʱ��: 2009��2��13��
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="memberCard">��Ա��Ϣ</param>
        /// <param name="customer">��Ա�����ͻ���Ϣ</param>
        /// <param name="memberOperateLog">��Ա��������¼</param>
        [Transaction]
        public void UpdateMemberCard(MemberCard memberCard, Customer customer, MemberOperateLog memberOperateLog)
        {
            memberCardDao.Update(memberCard);
            customerDao.Update(customer);
            //memberOperateLogDao.Insert(memberOperateLog);//����Ի�Ա�������ļ�¼
        }
        #endregion

        #region //��Ա����������
        /// <summary>
        /// ��    ��: RepairNewMemberCard
        /// ���ܸ�Ҫ: ��Ա����������(��һ���¿������ҽ�ԭ������Ϣ�������¿���)
        /// ��    ��: ��ΰ
        /// ����ʱ��: 2007-9-30
        /// ��������: ������
        /// ����ʱ��: 2009��6��20��14:51:32
        /// ��������: ���漰���ķ����������з�װ��һ�������� 
        /// </summary>
        /// <param name="changeMemberCard"></param>
        /// <param name="PassWord"></param>
        /// <param name="Id"></param>
        /// <param name="memberOperateLog"></param>
        [Transaction]
        public void RepairNewMemberCard(ChangeMemberCard changeMemberCard, string PassWord, long Id, MemberOperateLog memberOperateLog)
        {
            //����
            MemberCard memberCard = memberCardDao.SelectByPk(Id);
            memberCard.MemberCardNo = changeMemberCard.NewMemberCardNo;
            memberCard.Password = PassWord;
            memberCard.MemberState = Constants.MEMBER_CARD_STATE_NATURAL_KEY; ;
            memberCardDao.Insert(memberCard);

            //��ԭ������Ϣд�絽�¿���(�Żݻ)
            Hashtable condition = new Hashtable();
            condition.Add("NewMemberCardId", memberCard.Id);
            condition.Add("MemberCardId", Id);
            memberCardConcessionDao.UpdateMemberCardId(condition);

            //���뵽��������
            changeMemberCard.MemberCardId = memberCard.Id;
            changeMemberCard.Memo = "";
            changeMemberCardDao.Insert(changeMemberCard);

            //�߼�ɾ��ԭ��
            memberCardDao.LogicDelete(Id);
            //���뻻��������¼ 
            memberOperateLogDao.Insert(memberOperateLog);
        }
        #endregion

		#region ��Ա����ӡ�»��ֵ
		/// <summary>
		/// ��Ա����ӡ�»��ֵ
		/// </summary>
		/// <param name="memberCardConcession" name="ChargeSum"></param>
		/// <remarks>
		/// ��    ��: ��ΰ
		/// ����ʱ��: 2007-10-22
		/// ��������: ����ط
		/// ����ʱ��: 2009.5.14
		/// ��������: ���������޸�
        /// ��������: ������
        /// ����ʱ��: 2010��1��13��10:16:23
        /// ��������: �ӳ�ֵ��¼
        #region //��Ա����ֵ
        [Transaction]
        public void InsertConcessionMemberCard(MemberCardConcession memberCardConcession, MemberCardConcessionGathering memberCardConcessionGathering, OtherGatheringAndRefundmentRecord ogr)
        {
			memberCardConcessionDao.Insert(memberCardConcession);
			memberCardConcessionGathering.MemberCardConcessionId = memberCardConcession.Id;
			memberCardConcessionGatheringDao.Insert(memberCardConcessionGathering);
            otherGatheringAndRefundmentRecordDao.Insert(ogr);
        }
        #endregion

        //#region //�����Ա��������¼
        ///// <summary>
        ///// �����Ա��������¼
        ///// </summary>
        ///// <param name="memberOperateLog"></param>
        ///// <remarks>
        ///// ��    ��: ������
        ///// ����ʱ��: 2008-12-18
        ///// ��������:
        ///// ����ʱ��:
        ///// </remarks>
        //[Transaction]
        //public void InsertMemberOprateLog(MemberOperateLog memberOperateLog) 
        //{
        //    memberOperateLogDao.Insert(memberOperateLog);
        //}
        //#endregion

        #region //���ݻ�Ա��Id���»�Ա����״̬Ϊ1
        /// <summary>
        /// ���ݻ�Ա��Id���»�Ա����״̬Ϊ1
        /// </summary>
        /// <param name="memberOperateLog"></param>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2008-12-18
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        [Transaction]
        public void UpdateMemberCard(MemberCard memberCard) 
        {
            memberCardDao.Update(memberCard);
        }
        #endregion

        #region //��Ա��ע������
        [Transaction]
        public void InsertLogoffMemberCard(LogoffMemberCard logoffMemberCard, MemberOperateLog memberOperateLog)
        {
            logoffMemberCardDao.Insert(logoffMemberCard);//����ע����¼
            memberOperateLogDao.Insert(memberOperateLog);//�����Ա��������¼
            //���»�Ա��״̬
            Hashtable condition = new Hashtable();
            condition.Add("Id", logoffMemberCard.MemberCardId);
            condition.Add("MemberState", Workflow.Support.Constants.MEMBER_CARD_STATE_LOGOUT_KEY);
            memberCardDao.UpdateMemberState(condition);
        }
        #endregion

        #region //��Ա����ʧ����
        [Transaction]
        public void InsertReprotLossMemberCard(ReportLossMemberCard reportLossMemberCard, MemberOperateLog memberOperateLog)
        {
            //�����ʧ��Ϣ
            reportLossMemberCardDao.Insert(reportLossMemberCard);
            
            //���»�Ա��״̬
            Hashtable condition = new Hashtable();
            condition.Add("Id", reportLossMemberCard.MemberCardId);
            condition.Add("MemberState", Workflow.Support.Constants.MEMBER_CARD_STATE_REPORTLOSS_KEY);
            memberCardDao.UpdateMemberState(condition);

            //�����Ա��������¼
            memberOperateLogDao.Insert(memberOperateLog);
        }
        #endregion

        #region //��Ա���ָ�����
        [Transaction]
        public void DeleteByMemberCardId(long Id, MemberOperateLog memberOperateLog)
        {
            //ɾ��ReportLossMemberCard
            reportLossMemberCardDao.DeleteByMemberCardId(Id);

            //���»�Ա��״̬
            Hashtable condition = new Hashtable();
            condition.Add("Id", Id);
            condition.Add("MemberState", Workflow.Support.Constants.MEMBER_CARD_STATE_NATURAL_KEY);
            memberCardDao.UpdateMemberState(condition);

            //�����Ա��������¼
            memberOperateLogDao.Insert(memberOperateLog);
        }
        #endregion

        #region //����Ի�Ա���Ĳ�����Ϣ
        [Transaction]
        public void InsertMemberOperateLong(MemberOperateLog memberOperateLog)
        {
            memberOperateLogDao.Insert(memberOperateLog);
        }
        #endregion

        #region //ͨ����ԱIdɾ����Ա
        /// <summary>
        /// ��    ��: DeleteMemberCardById
        /// ���ܸ�Ҫ: ͨ����ԱIdɾ����Ա
        /// ��    ��: ������
        /// ����ʱ��: 2009��2��13��16:29:48
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        ///<param name="Id">��ԱId</param>
        public void DeleteMemberCardById(long Id) 
        {
            memberCardDao.DeleteMemberCardById(Id);
        }
        #endregion

		#region ��Ա�����ۻ��ֵ

		/// <summary>
		/// ��Ա�����ۻ��ֵ
		/// </summary>
		/// <param name="memberCardDiscountConcession">��Ա���μӵĴ����Żݻ</param>
		/// <param name="memberCardConcessionGathering">��Ա���μ��Żݻ�ĸ����¼</param>
		/// <remarks>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009.5.14
        /// ��������: ������
        /// ����ʱ��: 2010��1��13��10:16:23
        /// ��������: �ӳ�ֵ��¼
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
