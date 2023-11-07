using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table CAMPAIGN 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class CampaignBase : Workflow.Da.Domain.Base.MetaData 
	{
		/** ID [ID] */
		private long id;
		/** 姓名 [NAME] */
		private string name;
		/** 开始时间 [BEGIN_DATE_TIME] */
		private DateTime beginDateTime;
		/** 结束时间 [END_DATE_TIME] */
		private DateTime endDateTime;
		/** 备注 [MEMO] */
		private string memo;

		public CampaignBase()
		{
			
		}

		/// <summary>
		/// ID [ID]
		/// </summary>
		public virtual long Id
		{
			get { return this.id; }
			set { this.id = value; }
		}
		/// <summary>
		/// 姓名 [NAME]
		/// </summary>
		public virtual string Name
		{
			get { return this.name; }
			set { this.name = value; }
		}
		/// <summary>
		/// 开始时间 [BEGIN_DATE_TIME]
		/// </summary>
		public virtual DateTime BeginDateTime
		{
			get { return this.beginDateTime; }
			set { this.beginDateTime = value; }
		}
		/// <summary>
		/// 结束时间 [END_DATE_TIME]
		/// </summary>
		public virtual DateTime EndDateTime
		{
			get { return this.endDateTime; }
			set { this.endDateTime = value; }
		}
		/// <summary>
		/// 备注 [MEMO]
		/// </summary>
		public virtual string Memo
		{
			get { return this.memo; }
			set { this.memo = value; }
		}

		private IList<Workflow.Da.Domain.Concession> concessionList;
		/// <summary>
		/// Source Table[CAMPAIGN] Column[ID] --> Target Table[CONCESSION] Column[CAMPAIGN_ID]
		/// </summary>
		public virtual IList<Workflow.Da.Domain.Concession> ConcessionList
		{
			get { return concessionList; }
			set { concessionList = value; }
		}
        #region DISCOUNT_CONCESSION JoinType 1:N	list_in
        private IList<Workflow.Da.Domain.DiscountConcession> discountConcessionList;
        /// <summary>
        /// Source Table[CAMPAIGN] Column[ID] --> Target IList<Table[DISCOUNT_CONCESSION]> Column[CAMPAIGN_ID]
        /// PropertyComment	:DISCOUNT_CONCESSION:list
        /// JoinType 1:N	list_in
        /// </summary>
        public virtual IList<Workflow.Da.Domain.DiscountConcession> DiscountConcessionList
        {
            get { return discountConcessionList; }
            set { discountConcessionList = value; }
        }
        #endregion
	}
}
