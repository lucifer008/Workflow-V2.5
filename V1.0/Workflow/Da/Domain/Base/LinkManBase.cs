using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table LINK_MAN ��Ӧ��DotNet Object ����
	/// ������ǻ��࣬�������޸�
	/// </summary>
	[Serializable]
	public class LinkManBase : Workflow.Da.Domain.Base.MetaData 
	{
		/** ID [ID] */
		private long id;
		/** �ͻ�_ID [CUSTOMER_ID] */
		private long customerId;
		/** ���� [NAME] */
		private string name;
		/** �Ա� [SEX] */
		private string sex;
		/** ���� [AGE] */
		private int age;
		/** ְ�� [POSITION] */
		private string position;
		/** ���� [HOBBY] */
		private string hobby;
		/** ��λ�绰 [COMPANY_TEL_NO] */
		private string companyTelNo;
		/** �ֻ� [MOBILE_NO] */
		private string mobileNo;
		/** QQ [QQ] */
		private string qq;
		/** EMAIL [EMAIL] */
		private string email;
		/** ��ַ [ADDRESS] */
		private string address;
		/** ��ע [MEMO] */
		private string memo;

		public LinkManBase()
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
		/// �ͻ�_ID [CUSTOMER_ID]
		/// </summary>
		public virtual long CustomerId
		{
			get { return this.customerId; }
			set { this.customerId = value; }
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
		/// �Ա� [SEX]
		/// </summary>
		public virtual string Sex
		{
			get { return this.sex; }
			set { this.sex = value; }
		}
		/// <summary>
		/// ���� [AGE]
		/// </summary>
		public virtual int Age
		{
			get { return this.age; }
			set { this.age = value; }
		}
		/// <summary>
		/// ְ�� [POSITION]
		/// </summary>
		public virtual string Position
		{
			get { return this.position; }
			set { this.position = value; }
		}
		/// <summary>
		/// ���� [HOBBY]
		/// </summary>
		public virtual string Hobby
		{
			get { return this.hobby; }
			set { this.hobby = value; }
		}
		/// <summary>
		/// ��λ�绰 [COMPANY_TEL_NO]
		/// </summary>
		public virtual string CompanyTelNo
		{
			get { return this.companyTelNo; }
			set { this.companyTelNo = value; }
		}
		/// <summary>
		/// �ֻ� [MOBILE_NO]
		/// </summary>
		public virtual string MobileNo
		{
			get { return this.mobileNo; }
			set { this.mobileNo = value; }
		}
		/// <summary>
		/// QQ [QQ]
		/// </summary>
		public virtual string Qq
		{
			get { return this.qq; }
			set { this.qq = value; }
		}
		/// <summary>
		/// EMAIL [EMAIL]
		/// </summary>
		public virtual string Email
		{
			get { return this.email; }
			set { this.email = value; }
		}
		/// <summary>
		/// ��ַ [ADDRESS]
		/// </summary>
		public virtual string Address
		{
			get { return this.address; }
			set { this.address = value; }
		}
		/// <summary>
		/// ��ע [MEMO]
		/// </summary>
		public virtual string Memo
		{
			get { return this.memo; }
			set { this.memo = value; }
		}


	}
}
