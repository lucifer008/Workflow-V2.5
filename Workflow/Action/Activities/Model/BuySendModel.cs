using System;
using System.Collections.Generic;
using System.Text;

using Workflow.Da.Domain;

namespace Workflow.Action.Activities.Model
{
	/// <summary>
	/// ��    ��: BuySendModel
	/// ���ܸ�Ҫ: ��M��N�Model
	/// ��    ��: 
	/// ����ʱ��: 2010-04-15
	/// �� �� ��: ������
	/// ����ʱ��: 
	/// ��    ��: 
	/// </summary>
	public class BuySendModel
	{
		#region Ӫ����б�
		private IList<Campaign> campaignList;
		/// <summary>
		/// Ӫ����б�
		/// </summary>
		public IList<Campaign> CampaignList
		{
			get { return campaignList; }
			set { campaignList = value; }
		}
		#endregion

		#region Ӫ���Id
		private long campaignId;
		/// <summary>
		/// Ӫ���Id
		/// </summary>
		public long CampaignId
		{
			get { return campaignId; }
			set { campaignId = value; }
		}
		#endregion

		#region ��������
		private string actionInfo;
		/// <summary>
		/// ��������
		/// </summary>
		public string ActionInfo
		{
			get { return actionInfo; }
			set { actionInfo = value; }
		}
		#endregion

		#region ���ע
		private string buySendMemo;
		/// <summary>
		/// ���ע
		/// </summary>
		public string BuySendMemo
		{
			get { return buySendMemo; }
			set { buySendMemo = value; }
		}
		#endregion 

		#region �˵��
		private string  buySendDescription;
		/// <summary>
		/// �˵��
		/// </summary>
		public string  BuySendDescription
		{
			get { return buySendDescription; }
			set { buySendDescription = value; }
		}
		#endregion

		#region ���ӡ��
		private long buyCount;
		/// <summary>
		/// ���ӡ��
		/// </summary>
		public long BuyCount
		{
			get { return buyCount; }
			set { buyCount = value; }
		}
		#endregion

		#region �͵�ӡ��
		private long sendCouint;
		/// <summary>
		/// �͵�ӡ��
		/// </summary>
		public long SendCount
		{
			get { return sendCouint; }
			set { sendCouint = value; }
		}
		#endregion

		#region ��������
		private decimal paperCount;
		/// <summary>
		/// ��������
		/// </summary>
		public decimal PaperCount
		{
			get { return paperCount; }
			set { paperCount = value; }
		}
		#endregion

		#region ��������
		private string buySendName;
		/// <summary>
		/// ��������
		/// </summary>
		public string BuySendName
		{
			get { return buySendName; }
			set { buySendName = value; }
		}
		#endregion

		#region ҵ�������б�
		private IList<BusinessType> businessTypeList;
		/// <summary>
		/// ҵ�������б�
		/// </summary>
		public IList<BusinessType> BusinessTypeList
		{
			get { return businessTypeList; }
			set { businessTypeList = value; }
		}
		#endregion

		#region ҵ������Id
		private long businessTypeId;
		/// <summary>
		/// ҵ������Id
		/// </summary>
		public long BusinessTypeId
		{
			get { return businessTypeId; }
			set { businessTypeId = value; }
		}
		#endregion

		#region ��M��N�domain
		private BuySend buySend;
		/// <summary>
		/// ��M��N�domain
		/// </summary>
		public BuySend BuySend
		{
			get { return buySend; }
			set { buySend = value; }
		}
		#endregion

		#region �Id
		private long buySendId;
		/// <summary>
		/// �Id
		/// </summary>
		public long BuySendId
		{
			get { return buySendId; }
			set { buySendId = value; }
		}
		#endregion

		#region ��M��N����list
		private IList<BuySend> buySendList;
		/// <summary>
		/// ��M��N����list
		/// </summary>
		public IList<BuySend> BuySendList
		{
			get { return buySendList; }
			set { buySendList = value; }
		}
		#endregion

		#region ��ȡ�ĵļ�¼��
		private int recordCount;
		/// <summary>
		/// ��ȡ�ĵļ�¼��
		/// </summary>
		public int RecordCount
		{
			get { return recordCount; }
			set { recordCount = value; }
		}
		#endregion

		#region ���м۸�
		private BaseBusinessTypePriceSet baseBusinessTypePriceSet;
		/// <summary>
		/// BaseBusinessTypePriceSet
		/// </summary>
		public BaseBusinessTypePriceSet BaseBusinessTypePriceSet
		{
			get { return baseBusinessTypePriceSet; }
			set { baseBusinessTypePriceSet = value; }
		}
	
		#endregion

		#region �۸�����
		private IList<PriceFactor> priceFactor;
		/// <summary>
		/// �۸�����
		/// </summary>
		public IList<PriceFactor> PriceFactor
		{
			get { return priceFactor; }
			set { priceFactor = value; }
		}
		#endregion

	}
}
