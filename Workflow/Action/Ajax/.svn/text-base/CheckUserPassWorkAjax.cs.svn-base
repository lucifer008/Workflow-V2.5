using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Support.Ajax;
using Workflow.Service.SystemPermission.UserMangae;
using Workflow.Da.Domain;
using Workflow.Support.Encrypt;

namespace Workflow.Action.Ajax
{
	class CheckUserPassWorkAjax :  AjaxProcess
	{
		#region ×¢Èë userService

		private IUserService userService;
		public IUserService UserService
		{
			set { userService = value; }
		}

		#endregion

		#region AjaxProcess ³ÉÔ±

		public string DoProcess(System.Collections.Specialized.NameValueCollection parameters)
		{
			string userId=parameters["id"];
			string passWork = parameters["pwd"];

			if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(passWork))
			{
				return "1,''";
			}
			else
			{
				try
				{
					User user = userService.GetUserById(long.Parse(userId));
					if(user.Password.Equals(EncryptUtils.HexMD5(passWork)))
					{
						return "1,'ok'";
					}
					else
					{
						return "1,''";
					}

				}
				catch
				{
					return "1,''";
				}
			}
		}

		#endregion
	}
}
