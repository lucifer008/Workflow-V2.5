#region imports
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
#endregion

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table LINK_MAN (联系人) 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class LinkManBase : Workflow.Da.Domain.Base.MetaData	{

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

		#region CustomerId
		/* 客户_ID [CUSTOMER_ID] */
		private long customerId;
		/// <summary>
		/// 客户_ID [CUSTOMER_ID]
		/// </summary>
		public virtual long CustomerId
		{
			get { return customerId ;	}
			set { customerId=value;		}	
		}
		#endregion

		#region Name
		/* 姓名 [NAME] */
		private string name;
		/// <summary>
		/// 姓名 [NAME]
		/// </summary>
		public virtual string Name
		{
			get { return name ;	}
			set { name=value;		}	
		}
		#endregion

		#region Sex
		/* 性别 [SEX] */
		private string sex;
		/// <summary>
		/// 性别 [SEX]
		/// </summary>
		public virtual string Sex
		{
			get { return sex ;	}
			set { sex=value;		}	
		}
		#endregion

		#region Age
		/* 年龄 [AGE] */
		private int age;
		/// <summary>
		/// 年龄 [AGE]
		/// </summary>
		public virtual int Age
		{
			get { return age ;	}
			set { age=value;		}	
		}
		#endregion

		#region Position
		/* 职务 [POSITION] */
		private string position;
		/// <summary>
		/// 职务 [POSITION]
		/// </summary>
		public virtual string Position
		{
			get { return position ;	}
			set { position=value;		}	
		}
		#endregion

		#region Hobby
		/* 爱好 [HOBBY] */
		private string hobby;
		/// <summary>
		/// 爱好 [HOBBY]
		/// </summary>
		public virtual string Hobby
		{
			get { return hobby ;	}
			set { hobby=value;		}	
		}
		#endregion

		#region CompanyTelNo
		/* 单位电话 [COMPANY_TEL_NO] */
		private string companyTelNo;
		/// <summary>
		/// 单位电话 [COMPANY_TEL_NO]
		/// </summary>
		public virtual string CompanyTelNo
		{
			get { return companyTelNo ;	}
			set { companyTelNo=value;		}	
		}
		#endregion

		#region MobileNo
		/* 手机 [MOBILE_NO] */
		private string mobileNo;
		/// <summary>
		/// 手机 [MOBILE_NO]
		/// </summary>
		public virtual string MobileNo
		{
			get { return mobileNo ;	}
			set { mobileNo=value;		}	
		}
		#endregion

		#region Qq
		/* QQ [QQ] */
		private string qq;
		/// <summary>
		/// QQ [QQ]
		/// </summary>
		public virtual string Qq
		{
			get { return qq ;	}
			set { qq=value;		}	
		}
		#endregion

		#region Email
		/* EMAIL [EMAIL] */
		private string email;
		/// <summary>
		/// EMAIL [EMAIL]
		/// </summary>
		public virtual string Email
		{
			get { return email ;	}
			set { email=value;		}	
		}
		#endregion

		#region Address
		/* 地址 [ADDRESS] */
		private string address;
		/// <summary>
		/// 地址 [ADDRESS]
		/// </summary>
		public virtual string Address
		{
			get { return address ;	}
			set { address=value;		}	
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

		#region IdentityCardNo
		/* 身份证 [IDENTITY_CARD_NO] */
		private string identityCardNo;
		/// <summary>
		/// 身份证 [IDENTITY_CARD_NO]
		/// </summary>
		public virtual string IdentityCardNo
		{
			get { return identityCardNo ;	}
			set { identityCardNo=value;		}	
		}
		#endregion
	}
}