using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table BRANCH_STORE 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	public class BranchStoreBase : Workflow.Da.Domain.Base.MetaData 
	{
		/** ID [ID] */
		private long id;
		/** 公司_ID [COMPANY_ID] */
		private int companyId;
		/** 名称 [NAME] */
		private string name;
		/** 地址 [ADDRESS] */
		private string address;
		/** 电话 [TEL_NO] */
		private string telNo;
		/** 负责人 [PRINCIPLE] */
		private string principle;
		/** 备注 [REMARK] */
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
		/// 公司_ID [COMPANY_ID]
		/// </summary>
		public int CompanyId
		{
			get { return companyId; }
			set { companyId = value; }
		}
		/// <summary>
		/// 名称 [NAME]
		/// </summary>
		public string Name
		{
			get { return name; }
			set { name = value; }
		}
		/// <summary>
		/// 地址 [ADDRESS]
		/// </summary>
		public string Address
		{
			get { return address; }
			set { address = value; }
		}
		/// <summary>
		/// 电话 [TEL_NO]
		/// </summary>
		public string TelNo
		{
			get { return telNo; }
			set { telNo = value; }
		}
		/// <summary>
		/// 负责人 [PRINCIPLE]
		/// </summary>
		public string Principle
		{
			get { return principle; }
			set { principle = value; }
		}
		/// <summary>
		/// 备注 [REMARK]
		/// </summary>
		public string Remark
		{
			get { return remark; }
			set { remark = value; }
		}

	}
}
