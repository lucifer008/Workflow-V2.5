#region imports
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
#endregion

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table BUY_SEND (买M送N) 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class BuySendBase : Workflow.Da.Domain.Base.MetaData
	{

		#region Id
		/* ID [ID] */
		private long id;
		/// <summary>
		/// ID [ID]
		/// </summary>
		public virtual long Id
		{
			get { return id ;	}
			set { id=value;		}	
		}
		#endregion

		#region CampaignId
		/* 营销活动_ID [CAMPAIGN_ID] */
		private long campaignId;
		/// <summary>
		/// 营销活动_ID [CAMPAIGN_ID]
		/// </summary>
		public virtual long CampaignId
		{
			get { return campaignId ;	}
			set { campaignId=value;		}	
		}
		#endregion

		#region BaseBusinessTypePriceSetId
		/* 基本门市价格 [BASE_BUSINESS_TYPE_PRICE_SET_ID] */
		private long baseBusinessTypePriceSetId;
		/// <summary>
		/// 基本门市价格 [BASE_BUSINESS_TYPE_PRICE_SET_ID]
		/// </summary>
		public virtual long BaseBusinessTypePriceSetId
		{
			get { return baseBusinessTypePriceSetId ;	}
			set { baseBusinessTypePriceSetId=value;		}	
		}
		#endregion

		#region Name
		/* 名称 [NAME] */
		private string name;
		/// <summary>
		/// 名称 [NAME]
		/// </summary>
		public virtual string Name
		{
			get { return name ;	}
			set { name=value;		}	
		}
		#endregion

		#region BuyCount
		/* 买的数量 [BUY_COUNT] */
		private long buyCount;
		/// <summary>
		/// 买的数量 [BUY_COUNT]
		/// </summary>
		public virtual long BuyCount
		{
			get { return buyCount ;	}
			set { buyCount=value;		}	
		}
		#endregion

		#region SendCount
		/* 送的数量 [SEND_COUNT] */
		private long sendCount;
		/// <summary>
		/// 送的数量 [SEND_COUNT]
		/// </summary>
		public virtual long SendCount
		{
			get { return sendCount ;	}
			set { sendCount=value;		}	
		}
		#endregion

		#region Description
		/* 描述 [DESCRIPTION] */
		private string description;
		/// <summary>
		/// 描述 [DESCRIPTION]
		/// </summary>
		public virtual string Description
		{
			get { return description ;	}
			set { description=value;		}	
		}
		#endregion

		#region PaperCount
		/* 印章数 [PAPER_COUNT] */
		private decimal paperCount;
		/// <summary>
		/// 印章数 [PAPER_COUNT]
		/// </summary>
		public virtual decimal PaperCount
		{
			get { return paperCount ;	}
			set { paperCount=value;		}	
		}
		#endregion

		#region UsePaperCount
		/* 已使用印章数 [USE_PAPER_COUNT] */
		private decimal usePaperCount;
		/// <summary>
		/// 已使用印章数 [USE_PAPER_COUNT]
		/// </summary>
		public virtual decimal UsePaperCount
		{
			get { return usePaperCount ;	}
			set { usePaperCount=value;		}	
		}
		#endregion

		#region Memo
		/* 备注 [MEMO] */
		private string memo;
		/// <summary>
		/// 备注 [MEMO]
		/// </summary>
		public virtual string Memo
		{
			get { return memo ;	}
			set { memo=value;		}	
		}
		#endregion
	}
}