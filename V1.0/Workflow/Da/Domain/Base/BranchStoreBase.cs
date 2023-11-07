using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table BRANCH_STORE ��Ӧ��DotNet Object ����
	/// ������ǻ��࣬�������޸�
	/// </summary>
	public class BranchStoreBase : Workflow.Da.Domain.Base.MetaData 
	{
		/** ID [ID] */
		private long id;
		/** ��˾_ID [COMPANY_ID] */
		private int companyId;
		/** ���� [NAME] */
		private string name;
		/** ��ַ [ADDRESS] */
		private string address;
		/** �绰 [TEL_NO] */
		private string telNo;
		/** ������ [PRINCIPLE] */
		private string principle;
		/** ��ע [REMARK] */
		private string remark;

		public BranchStoreBase()
		{
			
		}

		/// <summary>
		/// ID [ID]
		/// </summary>
		public long Id
		{
			get { return id; }
			set { id = value; }
		}
		/// <summary>
		/// ��˾_ID [COMPANY_ID]
		/// </summary>
		public int CompanyId
		{
			get { return companyId; }
			set { companyId = value; }
		}
		/// <summary>
		/// ���� [NAME]
		/// </summary>
		public string Name
		{
			get { return name; }
			set { name = value; }
		}
		/// <summary>
		/// ��ַ [ADDRESS]
		/// </summary>
		public string Address
		{
			get { return address; }
			set { address = value; }
		}
		/// <summary>
		/// �绰 [TEL_NO]
		/// </summary>
		public string TelNo
		{
			get { return telNo; }
			set { telNo = value; }
		}
		/// <summary>
		/// ������ [PRINCIPLE]
		/// </summary>
		public string Principle
		{
			get { return principle; }
			set { principle = value; }
		}
		/// <summary>
		/// ��ע [REMARK]
		/// </summary>
		public string Remark
		{
			get { return remark; }
			set { remark = value; }
		}

	}
}
