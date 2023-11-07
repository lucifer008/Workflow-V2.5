using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table REPORT_LOSS_MEMBER_CARD ��Ӧ��DotNet Object ����
	/// ������ǻ��࣬�������޸�
	/// </summary>
	[Serializable]
	public class ReportLossMemberCardBase : Workflow.Da.Domain.Base.MetaData 
	{
		/** ID [ID] */
		private long id;
		/** ��Ա��_ID [MEMBER_CARD_ID] */
		private long memberCardId;
		/** ���� [NAME] */
		private string name;
		/** �绰 [TEL_NO] */
		private string telNo;

		public ReportLossMemberCardBase()
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
		/// ��Ա��_ID [MEMBER_CARD_ID]
		/// </summary>
		public virtual long MemberCardId
		{
			get { return this.memberCardId; }
			set { this.memberCardId = value; }
		}
		/// <summary>
		/// ���� [NAME]
		/// </summary>
		public virtual string Name
		{
			get { return this.name; }
			set { this.name = value; }
		}
		/// <summary>
		/// �绰 [TEL_NO]
		/// </summary>
		public virtual string TelNo
		{
			get { return this.telNo; }
			set { this.telNo = value; }
		}

		private Workflow.Da.Domain.ReportLessMode reportLessMode;
		/// <summary>
		/// Source Table[REPORT_LOSS_MEMBER_CARD] Column[REPORT_LESS_MODE_ID] --> Target Table[REPORT_LESS_MODE] Column[ID]
		/// </summary>
		public virtual Workflow.Da.Domain.ReportLessMode ReportLessMode
		{
			get { return reportLessMode; }
			set { reportLessMode = value; }
		}

	}
}
