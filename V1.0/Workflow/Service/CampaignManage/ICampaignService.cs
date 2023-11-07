using System;
using System.Text;
using System.Collections.Generic;
using Workflow.Da.Domain;

namespace Workflow.Service.CompaignManage
{
    /// <summary>
    /// ��    ��: ICampaignService
    /// ���ܸ�Ҫ: �����Service�Ľӿ�
    /// ��    ��: 
    /// ����ʱ��: 
    /// �� �� ��: ��ǿ
    /// ����ʱ��: 2009-1-21
    /// ��    ��: ��������
    /// </summary>
    public interface ICampaignService
    {
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
        void InsertCampaign(Campaign campaign);
 
        /// <summary>
        /// ��    ��: DeleteCampaignById
        /// ���ܸ�Ҫ: ɾ��Campaign
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-10-18
        /// �� �� ��: ��ǿ
        /// ����ʱ��: 2009-1-21
        /// ��    ��: ��������
        /// </summary>
        /// <param name="campaign">Ҫɾ���Ļ��id</param>
        void DeleteCampaignById(long Id);
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
        void UpdateCampaign(Campaign campaign);
        #endregion

        #region ��µ��Żݹ���
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
        void InsertConcession(Concession concession);
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
        void InsertConcessionMemberCardLevel(ConcessionMemberCardLevel concessionMemberCardLevel);
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
        void InsertConcessionDifferencePrice(ConcessionDifferencePrice concessionDifferencePrice);
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
        void DeleteConessionById(long Id);


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
        void DeleteConcessionById(long Id);

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
        void UpdateConcession(Concession concession);
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
        void DeletedConcessionMemberCardByConcessionId(long Id);
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
        void DeletedConcessionDifferencePriceByConcessionId(long Id);

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
        IList<Concession> SearchConcessionList(Concession concession);
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
		IList<DiscountConcession> GetAllDiscountConcession(int beginRow,int endRow);

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
		int GetAllDiscountConcessionCount();

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
		void DeleteDiscountConcessionById(long discountConcessionId);

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
		IList<Campaign> GetAllCampaign();

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
		IList<MachineType> GetAllMachine();

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
		IList<PaperSpecification> GetAllPaperSpecification();

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
		void SaveDiscountApplyMachineAndPaper(DiscountConcession discountConcession, IList<DiscountConcessionMachineTypePaperSpec> applyDiscountList);

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
		DiscountConcession GetDiscountConcessionById(long id);

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
		void updateDiscountApplyMachineAndPaper(DiscountConcession discountConcession, IList<DiscountConcessionMachineTypePaperSpec> applyDiscountList);
		
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
		IList<DiscountConcessionMachineTypePaperSpec> GetAllDiscountConcessionMachineTypePaperSpecByDiscountId(long discountId);
		
		#endregion
	}
}

