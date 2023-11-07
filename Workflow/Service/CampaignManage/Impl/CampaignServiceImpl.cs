using System;
using System.Text;
using System.Collections.Generic;

using Workflow.Da;
using Workflow.Da.Domain;
using Spring.Transaction.Interceptor;
using System.Collections;
using Workflow.Support;
using Workflow.Service.OrderManage;
using Workflow.Service.SystemManege.PriceManage;

namespace Workflow.Service.CompaignManage
{
    /// <summary>
    /// ��    ��: CampaignServiceImpl
    /// ���ܸ�Ҫ: ������Service
    /// ��    ��: 
    /// ����ʱ��: 
    /// �� �� ��: ��ǿ
    /// ����ʱ��: 2009-1-21
    /// ��    ��: ��������
    /// </summary>
    public class CampaignServiceImpl: ICampaignService
    {
        #region ���Ա
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

		private IMemberCardBuySendDao memberCardBuySendDao;
		/// <summary>
		/// IMemberCardBuySendDaoss
		/// </summary>
		public IMemberCardBuySendDao MemberCardBuySendDao
		{
			set { memberCardBuySendDao = value; }
		}
		#region ע�� machineTypeDao

		private IMachineTypeDao machineTypeDao;
		/// <summary>
		/// ע�� machineTypeDao
		/// </summary>
		public IMachineTypeDao MachineTypeDao
		{
			set { machineTypeDao = value; }
		}

		#endregion

		#region ע�� paperSpecificationDao

		private IPaperSpecificationDao paperSpecificationDao;
		/// <summary>
		/// ע�� paperSpecificationDao
		/// </summary>
		public IPaperSpecificationDao PaperSpecificationDao
		{
			set { paperSpecificationDao = value; }
		}

		#endregion

		#region ע�� discountConcessionMachineTypePaperSpecDao

		private IDiscountConcessionMachineTypePaperSpecDao discountConcessionMachineTypePaperSpecDao;
		/// <summary>
		/// ע�� discountConcessionMachineTypePaperSpecDao
		/// </summary>
		public IDiscountConcessionMachineTypePaperSpecDao DiscountConcessionMachineTypePaperSpecDao
		{
			set { discountConcessionMachineTypePaperSpecDao = value; }
		}

		#endregion

		#region ע�� memberCardConcessionDao

		private IMemberCardConcessionDao memberCardConcessionDao;
		/// <summary>
		/// ע�� memberCardConcessionDao
		/// </summary>
		public IMemberCardConcessionDao MemberCardConcessionDao
		{
			set { memberCardConcessionDao = value; }
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

		#region ע�� buySendDao
		private IBuySendDao buySendDao;
		/// <summary>
		/// buySendDao
		/// </summary>
		public IBuySendDao BuySendDao
		{
			set { buySendDao = value; }
		}
		#endregion

		#region OrderService
		private IOrderService orderService;
		/// <summary>
		/// OrderService
		/// </summary>
		public IOrderService OrderService
		{
			set { orderService = value; }
		}
		#endregion

		#region PriceService
		private IPriceService priceService;
		/// <summary>
		/// PriceService
		/// </summary>
		public IPriceService PriceService
		{
			set { priceService = value; }
		}
		#endregion
		

		#endregion

		#region �����
		/// <summary>
        /// ��    ��: InsertCampaign
        /// ���ܸ�Ҫ: ����Ӫ���
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-10-15
        /// �� �� ��: ��ǿ
        /// ����ʱ��: 2009-1-21
        /// ��    ��: ��������
        /// </summary>
        /// <param name="campaign">����</param>
        [Transaction]
        public void InsertCampaign(Campaign campaign)
        {
            campaignDao.Insert(campaign);
        }

        /// <summary>
        /// ��    ��: DeleteCampaignById
        /// ���ܸ�Ҫ: ɾ��Campaign
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-10-18
        /// �� �� ��: ��ǿ
        /// ����ʱ��: 2009-1-21
        /// ��    ��: ��������
        /// �� �� ��:������
        /// ����ʱ��:2009��3��17��14:04:22
        /// ��    ��:������ɾ����Ϊ�߼�ɾ��
        /// </summary>
        /// <param name="campaign">Ҫɾ���Ļ��id</param>
        [Transaction]
        public void DeleteCampaignById(long Id)
        {
            //ɾ��ConcessionDifferencePrice
            //concessionDifferencePriceDao.DeleteConcessionDifferencePriceByCampaignId(Id);
            //ɾ��ConcessionMemberCardLevel
            //concessionMemberCardLevelDao.DeleteConcessionMemberCardLevelByCampaignId(Id);
            //ɾ��Concession
            //concessionDao.DeleteConcessionById(Id);
            //ɾ��Campaign
            campaignDao.DeleteCampaignById(Id);
        }

        /// <summary>
        /// ��    ��: DeleteConcessionById
        /// ���ܸ�Ҫ: ɾ��Concession
        /// ��    ��: ������
        /// ����ʱ��: 2009��3��17��14:06:16
        /// �� �� ��: 
        /// ����ʱ��: 
        /// ��    ��: 
        /// </summary>
        /// <param name="campaign">Ҫɾ���ķ���id</param>
        public void DeleteConcessionById(long Id) 
        {
            concessionDao.DeleteConcessionById(Id);
        }
        
        /// <summary>
        /// ��    ��: UpdateCampaign
        /// ���ܸ�Ҫ: ͨ��CampaignId����Campaign
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-10-19
        /// �� �� ��: ��ǿ
        /// ����ʱ��: 2009-1-21
        /// ��    ��: ��������
        /// </summary>
        /// <param name="campaign">Ҫ���µĻ</param>
        public void UpdateCampaign(Campaign campaign)
        {
            campaignDao.Update(campaign);
        }
        #endregion

        #region ��µľ����Ż�
        /// <summary>
        /// ��    ��: InsertConcession
        /// ���ܸ�Ҫ: �����Żݻ
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-10-17
        /// �� �� ��: ��ǿ
        /// ����ʱ��: 2009-1-21
        /// ��    ��: ��������
        /// </summary>
        /// <param name="concession">�Żݻ</param>
        [Transaction]
        public void InsertConcession(Concession concession)
        {
            //concession.UnitPrice =//Convert.ToInt64(concession.ChargeAmount / concession.PaperCount);
            concessionDao.Insert(concession);

            //�Żݻ����Ӧ�Ŀ���Ϣ
            ConcessionMemberCardLevel concessionMemberCardLevel = new ConcessionMemberCardLevel();
            concessionMemberCardLevel.ConcessionId = concession.Id;
            for (int i = 0; i < concession.ConcessionMemberCardLevelId.Length; i++)
            {
                concessionMemberCardLevel.MemberCardLevelId = Convert.ToInt64(concession.ConcessionMemberCardLevelId[i]);
                InsertConcessionMemberCardLevel(concessionMemberCardLevel);
            }

            //�Żݻ�������Ĳ��
            ConcessionDifferencePrice concessionDifferencePrice = new ConcessionDifferencePrice();
            concessionDifferencePrice.ConcessionId = concession.Id;
            concessionDifferencePrice.BaseBusinessTypePriceSet = new BaseBusinessTypePriceSet();
            concessionDifferencePrice.BaseBusinessTypePriceSet.Id = concession.BaseBusinessTypePriceSet.Id;
            concessionDifferencePrice.PriceDifference = concession.RoomPrice - concession.UnitPrice;//���

            //�Żݻ�����Ĳ��
            if (0 != concessionDifferencePrice.PriceDifference)
            {
                InsertConcessionDifferencePrice(concessionDifferencePrice);
            }
            
        }
        /// <summary>
        /// ��    ��: InsertConcessionMemberCardLevel
        /// ���ܸ�Ҫ: �����Żݻ��Ӧ�Ŀ�����
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-10-17
        /// �� �� ��: ��ǿ
        /// ����ʱ��: 2009-1-21
        /// ��    ��: ��������
        /// </summary>
        /// <param name="concessionMemberCardLevel">�Żݻ��Ӧ�Ŀ�����</param>
        [Transaction]
        public void InsertConcessionMemberCardLevel(ConcessionMemberCardLevel concessionMemberCardLevel)
        {
            concessionMemberCardLevelDao.Insert(concessionMemberCardLevel);
        }
        /// <summary>
        /// ��    ��: InsertConcessionDifferencePrice
        /// ���ܸ�Ҫ: �����Żݻ��Ӧ�Ĳ��
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-10-17
        /// �� �� ��: ��ǿ
        /// ����ʱ��: 2009-1-21
        /// ��    ��: ��������
        /// </summary>
        /// <param name="concessionDifferencePrice">�Żݻ��Ӧ�Ĳ��</param>
        [Transaction]
        public void InsertConcessionDifferencePrice(ConcessionDifferencePrice concessionDifferencePrice)
        {
            concessionDifferencePriceDao.Insert(concessionDifferencePrice);
        }
        /// <summary>
        /// ��    ��: DeleteConessionById
        /// ���ܸ�Ҫ: ɾ��Concession
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-10-18
        /// �� �� ��: ��ǿ
        /// ����ʱ��: 2009-1-21
        /// ��    ��: ��������
        /// </summary>
        /// <param name="Id">ConcessionId</param>
        [Transaction]
        public void DeleteConessionById(long Id)
        {
            //ɾ��ConcessionDifferencePrice
            concessionDifferencePriceDao.DeletedConcessionDifferencePriceByConcessionId(Id);
            //ɾ��ConcessionMemberCardLevel
            concessionMemberCardLevelDao.DeleteConcessionMemberCardByConcessionId(Id);
            //ɾ��Concession
            concessionDao.DeleteConcessionById(Id);
        }
        /// <summary>
        /// ��    ��: UpdateConcession
        /// ���ܸ�Ҫ: ����Concession
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-10-18
        /// �� �� ��: ��ǿ
        /// ����ʱ��: 2009-1-21
        /// ��    ��: ��������
        /// </summary>
        /// <param name="concession">Concession</param>
        /// <param name="concessionMemberCardLevelIds">��Ա������ID</param>
        /// <param name="concessionDifferencePriceIds">�Żݲ��Id</param>
        /// <param name="concessionDifferenceValues">���</param>
        [Transaction]
        public void UpdateConcession(Concession concession)
        {
            //����Concession
            concessionDao.Update(concession);

            //�����Żݻ����Ӧ�Ŀ���Ϣ
            DeletedConcessionMemberCardByConcessionId(concession.Id);
            ConcessionMemberCardLevel concessionMemberCardLevel = new ConcessionMemberCardLevel();
            concessionMemberCardLevel.ConcessionId = concession.Id;
            for (int i = 0; i < concession.ConcessionMemberCardLevelId.Length; i++)
            {
                concessionMemberCardLevel.MemberCardLevelId = Convert.ToInt64(concession.ConcessionMemberCardLevelId[i]);
                InsertConcessionMemberCardLevel(concessionMemberCardLevel);
            }

            //�����Żݻ�������Ĳ��
            DeletedConcessionDifferencePriceByConcessionId(concession.Id);
            ConcessionDifferencePrice concessionDifferencePrice = new ConcessionDifferencePrice();
            concessionDifferencePrice.ConcessionId = concession.Id;
            concessionDifferencePrice.BaseBusinessTypePriceSet = new BaseBusinessTypePriceSet();
            concessionDifferencePrice.BaseBusinessTypePriceSet.Id = concession.BaseBusinessTypePriceSet.Id;
            concessionDifferencePrice.PriceDifference = concession.RoomPrice - concession.UnitPrice;//���

            //�Żݻ�����Ĳ��
            if (0 != concessionDifferencePrice.PriceDifference)
            {
                InsertConcessionDifferencePrice(concessionDifferencePrice);
            }
        }
        /// <summary>
        /// ��    ��: DeletedConcessionMemberCardByConcessionId
        /// ���ܸ�Ҫ: ͨ��ConcessionIdɾ��ConcessionMemberCardLevel���е������Ϣ
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-10-19
        /// �� �� ��: ��ǿ
        /// ����ʱ��: 2009-1-21
        /// ��    ��: ��������
        /// </summary>
        /// <param name="Id">ConcessionId</param>
        [Transaction]
        public void DeletedConcessionMemberCardByConcessionId(long Id)
        {
            concessionMemberCardLevelDao.DeleteConcessionMemberCardByConcessionId(Id);
        }

        /// <summary>
        /// ��    ��: DeletedConcessionDifferencePriceByConcessionId
        /// ���ܸ�Ҫ: ͨ��ConcessionIdɾ��ConcessionDifferencePrice���е������Ϣ
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-10-19
        /// �� �� ��: ��ǿ
        /// ����ʱ��: 2009-1-21
        /// ��    ��: ��������
        /// </summary>
        /// <param name="Id">ConcessionId</param>
        [Transaction]
        public void DeletedConcessionDifferencePriceByConcessionId(long Id)
        {
            concessionDifferencePriceDao.DeletedConcessionDifferencePriceByConcessionId(Id);
        }

        /// <summary>
        /// ��    ��: SearchConcessionList
        /// ���ܸ�Ҫ: ����������ѯConcession��Ϣ
        /// ��    ��: ������
        /// ����ʱ��: 2009��3��19��18:05:47
        /// �� �� ��:
        /// ����ʱ��:
        /// ��    ��:
        /// </summary>
        /// <param name="concession"></param>
        /// <returns></returns>
        public IList<Concession> SearchConcessionList(Concession concession) 
        {
            return concessionDao.SearchConcessionList(concession);
        }
        #endregion

		#region ��ȡ���ۻ�б�(��ҳ)

		/// <summary>
		/// ��ȡ���ۻ�б�(��ҳ)
		/// </summary>
		/// <param name="beginRow">��ǰ��</param>
		/// <param name="endRow">ÿҳ����</param>
		/// <returns>���ۻ�б�</returns>
		/// <remarks>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009.5.9
		/// </remarks>
		public IList<DiscountConcession> GetAllDiscountConcession(int beginRow, int endRow)
		{
			return discountConcessionDao.GetAllDiscountConcession(beginRow, endRow);
		}

		#endregion

		#region ��ȡ���д��ۻ�ļ�¼��

		/// <summary>
		/// ��ȡ���д��ۻ�ļ�¼��
		/// </summary>
		/// <returns>��¼��</returns>
		/// <remarks>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009.5.11
		/// </remarks>
		public int GetAllDiscountConcessionCount()
		{
			return discountConcessionDao.GetAllDiscountConcessionCount();
		}

		#endregion

		#region ɾ��ָ��id�Ĵ��ۻ

		/// <summary>
		/// ɾ��ָ��id�Ĵ��ۻ
		/// </summary>
		/// <param name="discountConcessionId">���ۻid</param>
		/// <remarks>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009.5.11
		/// </remarks>
		public void DeleteDiscountConcessionById(long discountConcessionId)
		{
			discountConcessionDao.LogicDelete(discountConcessionId);
		}

		#endregion

		#region ��ȡ���е�Ӫ���

		/// <summary>
		/// ��ȡ���е�Ӫ���
		/// </summary>
		/// <returns>Ӫ����б�</returns>
		/// <remarks>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009.5.11
		/// </remarks>
		public IList<Campaign> GetAllCampaign()
		{
			return campaignDao.SelectAll();
		}

		#endregion

		#region ��ȡ���еĻ�������

		/// <summary>
		/// ��ȡ���еĻ�������
		/// </summary>
		/// <returns>���������б�</returns>
		/// <remarks>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009.5.11
		/// </remarks>
		public IList<MachineType> GetAllMachine()
		{
			return machineTypeDao.SelectAll();
		}

		#endregion

		#region ��ȡ���еĻ�������

		/// <summary>
		/// ��ȡ���еĻ�������
		/// </summary>
		/// <returns>���������б�</returns>
		/// <remarks>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009.5.11
		/// </remarks>
		public IList<PaperSpecification> GetAllPaperSpecification()
		{
			return paperSpecificationDao.SelectAll();
		}

		#endregion

		#region �����ۿ������ڵĻ�����ֽ��

		/// <summary>
		/// �����ۿ������ڵĻ�����ֽ��
		/// </summary>
		/// <param name="discountConcession">�ۿ�</param>
		/// <param name="applyDiscountList">�ۿ����õĻ�����ֽ��</param>
		/// <remarks>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009.5.12
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

		#region ͨ���ۿ�id��ȡ�ۿۻ

		/// <summary>
		/// ͨ���ۿ�id��ȡ�ۿۻ
		/// </summary>
		/// <param name="id">�ۿ�id</param>
		/// <returns>�ۿۻ</returns>
		/// <remarks>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009.5.12
		/// </remarks>
		public DiscountConcession GetDiscountConcessionById(long id)
		{
			return discountConcessionDao.SelectByPk(id);
		}

		#endregion

		#region �����ۿ������ڵĻ�����ֽ��

		/// <summary>
		/// �����ۿ������ڵĻ�����ֽ��
		/// </summary>
		/// <param name="discountConcession">�ۿ�</param>
		/// <param name="applyDiscountList">�ۿ����õĻ�����ֽ��</param>
		/// <remarks>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009.5.12
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

		#region ��ȡָ���ۿۻ�����������ڵĻ�����ֽ��

		/// <summary>
		/// ��ȡָ���ۿۻ�����������ڵĻ�����ֽ��
		/// </summary>
		/// <param name="discountId">�ۿ�id</param>
		/// <returns></returns>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009.5.12
		/// </remarks>
		public IList<DiscountConcessionMachineTypePaperSpec> GetAllDiscountConcessionMachineTypePaperSpecByDiscountId(long discountId)
		{
			return discountConcessionMachineTypePaperSpecDao.SelectAllDiscountConcessionMachineTypePaperSpecByDiscountId(discountId);
		}

		#endregion

		#region ��ȡ���ۻ�б�

		/// <summary>
		/// ��ȡ���ۻ�б�
		/// </summary>
		/// <returns>���ۻ�б�</returns>
		/// <remarks>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009.5.13
		/// </remarks>
		public IList<DiscountConcession> GetAllDiscountConcession()
		{
			return discountConcessionDao.SelectAll();
		}

		#endregion

		#region ��ȡӡ�»�б�ͨ��Ӫ���id

		/// <summary>
		/// ��ȡӡ�»�б�ͨ��Ӫ���id
		/// </summary>
		/// <param name="campaignId">Ӫ���id</param>
		/// <returns>ӡ�»�б�</returns>
		/// <remarks>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009.5.13
		/// </remarks>
		public IList<Concession> GetAllConcessionByCampaignId(long campaignId)
		{
			return concessionDao.SelectAllConcessByCampaignId(campaignId);
		}

		#endregion

		#region ��ȡ���ۻ�б�ͨ��Ӫ���id

		/// <summary>
		/// ��ȡ���ۻ�б�ͨ��Ӫ���id
		/// </summary>
		/// <param name="campaignId">Ӫ���id</param>
		/// <returns>���ۻ�б�</returns>
		/// <remarks>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009.5.13
		/// </remarks>
		public IList<DiscountConcession> GetAllDiscountConcessionByCampaignId(long campaignId)
		{
			return discountConcessionDao.SelectAllDiscountConcessionByCampaignId(campaignId);
		}

		#endregion


		#region ��ȡ��Ч�Ļ�Ա���μӵ��Żݻͨ����Ա��id

		/// <summary>
		/// ��ȡ��Ч�Ļ�Ա���μӵ��Żݻͨ����Ա��id
		/// </summary>
		/// <param name="memberCardId">��Ա��id</param>
		/// <returns>��Ա���μӵ��Żݻ�б�</returns>
		/// <remarks>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009.5.19
		/// </remarks>
		public IList<MemberCardConcession> GetValidMemberCardConcession(long memberCardId)
		{
			return memberCardConcessionDao.SelectValidMemberCardConcession(memberCardId);
		}

		#endregion

		#region ��ȡ��Ч�Ļ�Ա���μӵĴ��ۻ-ͨ����Ա��id

		/// <summary>
		/// ��ȡ��Ч�Ļ�Ա���μӵĴ��ۻ-ͨ����Ա��id
		/// </summary>
		/// <param name="memberCardId">��Ա��id</param>
		/// <returns>��Ա���μӵĴ��ۻ</returns>
		/// <remarks>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009.5.20
		/// </remarks>
		public IList<MemberCardDiscountConcession> GetValidMemberDiscountCardConcession(long memberCardId)
		{
			IList<MemberCardDiscountConcession> tempList=memberCardDiscountConcessionDao.SelectValidMemberDiscountCardConcession(memberCardId);
			Hashtable map = new Hashtable();
			int i = 0;
			while(i<tempList.Count)
			{
				if (map.ContainsKey(tempList[i].Id))
				{
					string contrastValue = tempList[i].MachinePriceFactor.ToString() + "," + tempList[i].PaperPriceFactor.ToString();
					IList<string> contrastValues = (IList<string>)map[tempList[i].Id];
					contrastValues.Add(contrastValue);
					tempList.Remove(tempList[i]);
				}
				else
				{
					string contrastValue = tempList[i].MachinePriceFactor.ToString() + "," + tempList[i].PaperPriceFactor.ToString();
					tempList[i].ContrastValues.Add(contrastValue);
					map.Add(tempList[i].Id, tempList[i].ContrastValues);
					i++;
				}
			}
			return tempList;
		}

		#endregion

		#region �����M��N�
		/// ��    ��: AddBuySendCampaign
		/// ���ܸ�Ҫ: �����M��N�
		/// ��    ��: ������
		/// ����ʱ��: 2010-04-16
		/// �� �� ��: 
		/// ����ʱ��: 
		/// ��    ��: 
		/// <param name="domain"></param>
		public void AddBuySendCampaign(BuySend domain)
		{
			User user = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser;
			domain.InsertDateTime = DateTime.Now;
			domain.InsertUser = user.Id;
			domain.CompanyId = user.CompanyId;
			domain.BranchShopId = user.BranchShopId;

			buySendDao.Insert(domain);
		}
		#endregion

		#region �޸���M��N�
		/// <summary>
		/// ��    ��: EditBuySendCampaing
		/// ���ܸ�Ҫ: �޸���M��N�
		/// ��    ��: ������
		/// </summary>
		/// <param name="domain"></param>
		public void EditBuySendCampaing(BuySend domain)
		{
			buySendDao.Update(domain);
		}
		#endregion

		#region ��ȡ��M��N���Ϣ
		/// <summary>
		/// ��    ��: GetBuySendInfo
		/// ���ܸ�Ҫ: ��ȡ��M��N���Ϣ
		/// ��    ��: ������
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public BuySend GetBuySendInfo(long id)
		{
			return buySendDao.SelectByPk(id);
		}
		#endregion

		#region ��ȡ��M��N������¼��
		/// <summary>
		/// ��    ��: GetAllBuySendListInfoRowCount
		/// ���ܸ�Ҫ: ��ȡ��M��N������¼��
		/// ��    ��: ������
		/// ����ʱ��: 2010��4��19��
		/// �� �� ��: 
		/// ����ʱ��: 
		/// ��    ��: 
		/// </summary>
		public int GetAllBuySendListInfoRowCount(Hashtable condition)
		{
			return buySendDao.SelectAllBuySendListInfoRowCount(condition);
		}
		#endregion

		#region ��ȡ��M��N����
		/// <summary>
		/// ��    ��: GetAllBuySendListInfo
		/// ���ܸ�Ҫ: ��ȡ��M��N����
		/// ��    ��: ������
		/// ����ʱ��: 2010��4��19��
		/// �� �� ��: 
		/// ����ʱ��: 
		/// ��    ��: 
		/// </summary>
		public IList<BuySend> GetAllBuySendListInfo(Hashtable condition)
		{
			return buySendDao.SelectAllBuySendListInfo(condition);
		}
		#endregion

		#region ɾ����M��N����
		/// <summary>
		/// ��    ��: RemoveBuySend
		/// ���ܸ�Ҫ: ɾ����M��N����
		/// ��    ��: ������
		/// ����ʱ��: 2010��4��20��
		/// �� �� ��: 
		/// ����ʱ��: 
		/// ��    ��: 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public void RemoveBuySend(long id)
		{
			BuySend domain = this.GetBuySendInfo(id);
			User user = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser;
			domain.Deleted = '1';
			domain.UpdateDateTime = DateTime.Now;
			domain.UpdateUser = user.Id;

			this.EditBuySendCampaing(domain);
		}
		#endregion

		#region ��ȡ��ǰ���ڽ��е���M��N����
		/// <summary>
		/// ��    ��: GetCurrentBuySend
		/// ���ܸ�Ҫ: ��ȡ��ǰ���ڽ��е���M��N����
		/// ��    ��: ������
		/// ����ʱ��: 2010��4��20��
		/// �� �� ��: 
		/// ����ʱ��: 
		/// ��    ��: 
		/// </summary>
		public BuySend GetCurrentBuySend()
		{
			return buySendDao.SelectCurrentBuySend(DateTime.Now);
		}
		#endregion

		#region �����Żݵ�ӡ�º��Żݽ��
		/// <summary>
		/// ��    ��: ProcessMoneyAndCount
		/// ���ܸ�Ҫ: �����Żݵ�ӡ�º��Żݽ��
		/// ��    ��: ������
		/// ����ʱ��: 2010��4��20��
		/// �� �� ��: 
		/// ����ʱ��: 
		/// ��    ��: 
		/// </summary>
		/// <param name="orderItem">������</param>
		public void ProcessMoneyAndCount(IList<OrderItem> orderItemList, IList<MemberCardBuySend> memberCardBuySendList)
		{
			BuySend buySend;
			decimal canUsedPaperCount = 0;
			BaseBusinessTypePriceSet priceSet = null ;

			OrderItem newOrderItem = null;
			foreach (MemberCardBuySend item in memberCardBuySendList)
			{
				item.OrderItemList = new List<OrderItem>();
				buySend = this.GetBuySendInfo(item.BuySendId);

				priceSet = new BaseBusinessTypePriceSet();
				priceSet.Id = buySend.BaseBusinessTypePriceSetId;

				priceSet = priceService.GetBaseBusinessTypePriceSetById(priceSet);

				foreach (OrderItem orderItem in orderItemList)
				{
					newOrderItem = new OrderItem();
					newOrderItem = orderItem;

					decimal diffPrice = 0.0M;
					

					if (orderItem.UnitPrice > priceSet.StandardPrice)
					{
						diffPrice = orderItem.UnitPrice - priceSet.StandardPrice;
					}

					//����ɳ��ӡ����
					decimal paperConsumeCount = (decimal)Math.Truncate(((double)orderItem.Amount * buySend.SendCount) / (buySend.SendCount + buySend.BuyCount));
					if (item.RestPaperCount < paperConsumeCount)
					{
						paperConsumeCount = item.RestPaperCount;
					}
					newOrderItem.PaperConsumeCount = paperConsumeCount;
					newOrderItem.DiffPrice = diffPrice;
					item.OrderItemList.Add(newOrderItem);
				}

				item.BuySendName = buySend.Name;
				item.BuyCount = buySend.BuyCount;
				item.SendCount = buySend.SendCount;
			}
		}
		#endregion

		#region ��ȡָ����Ա�� ��M��N�
		/// <summary>
		/// ��    ��: GetMemberCardBuySendList
		/// ���ܸ�Ҫ: ��ȡָ����Ա�� ��M��N�
		/// ��    ��: 
		/// ����ʱ��: 
		/// �� �� ��: ������
		/// ����ʱ��: 2010-4-24
		/// ��    ��: 
		/// </summary>
		/// <param name="memberCardId">��Ա��Id</param>
		public IList<MemberCardBuySend> GetMemberCardBuySendList(long memberCardId)
		{
			return memberCardBuySendDao.SelectListByMemberCardId(memberCardId);
		}
		#endregion
	}
}
