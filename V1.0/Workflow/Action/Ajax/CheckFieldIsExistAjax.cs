using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Workflow.Support;
using Workflow.Support.Log;
using Workflow.Support.Ajax;
using Workflow.Da.Domain;
using Workflow.Service;
using Workflow.Service.CompaignManage;
using Workflow.Service.SystemPermission.UserMangae;
using Workflow.Service.SystemPermission.EmployeeManage;
using Workflow.Service.SystemPermission.PermissionManage;
namespace Workflow.Action.Ajax
{
    /// <summary>
    /// ��    ��: CheckFieldIsExistAjax
    /// ���ܸ�Ҫ: ����ֶε�ֵ�Ƿ����(���Ѿ�ɾ��������)
    /// ��    ��: ������
    /// ����ʱ��: 2009��2��13��
    /// ��������: 
    /// ����ʱ��: 
    /// </summary>
    class CheckFieldIsExistAjax : AjaxProcess
    {
        #region ����ע��Service
        private IUserService userService;
        public IUserService UserService 
        {
            set { userService = value; }
        }

        private IEmployeeService employeeService;
        public IEmployeeService EmployeeService 
        {
            set { employeeService = value; }
        }

        private ISearchCampaignService searchCampaignService;
        public ISearchCampaignService SearchCampaignService 
        {
            set { searchCampaignService = value; }
        }

        private IPermissionService permissionService;
        public IPermissionService PermissionService 
        {
            set { permissionService = value; }
        }
        #endregion

        public string DoProcess(NameValueCollection parameters)
        {
            try
            {
                long count = 0;
                if (null == parameters["Tag"]) return null;
                if ("1"==parameters["Tag"])//�ж��û����Ƿ��Ѿ�����
                {
                    if (null == parameters["userName"]) return null;
                    User user = new User();
                    user.UserName = parameters["userName"];
                    count=userService.CheckUserNameIsExist(user);
                }
                else if ("2"==parameters["Tag"])//�жϹ�Ա�����Ƿ�����ʹ��
                {
                    if (null == parameters["EmployeeId"]) return null;
                    else 
                    {
                        count = employeeService.CheckEmployeeIsNotUse(Convert.ToInt32(parameters["EmployeeId"]));
                    }
                    
                }
                else if("3"==parameters["Tag"])//���Ӫ����Ƿ�����ʹ��
                {
                    if (null == parameters["CampaignId"]) return null;
                    else
                    {
                        count = searchCampaignService.CheckCampaignIdIsNotUse(Convert.ToInt32(parameters["campaignId"]));
                    }
                }
                else if ("4" == parameters["Tag"])//���Ӫ��������Ƿ����
                {
                    if (null == parameters["CampaignName"]) return null;
                    else 
                    {
                        count = searchCampaignService.CheckCampaignNameIsNotUse(parameters["CampaignName"].Trim());
                    }
                }
                else if ("5" == parameters["Tag"])//����û��Ƿ����Żݷ�Χ
                {
                    if (null == parameters["UserId"]) return null;
                    else
                    {
                        count = userService.CheckUserIsNotConcessionRange(Convert.ToInt32(parameters["UserId"]));//user.CheckCampaignNameIsNotUse(parameters["CampaignName"].Trim());
                    }
                }
                else if("6"==parameters["Tag"])//���Ȩ�����Ƿ�����ʹ��
                {
                    if (null == parameters["PermissionGroupId"]) return null;
                    else 
                    {
                        long permissionGroupId = Convert.ToInt32(parameters["PermissionGroupId"]);
                        count = permissionService.CheckPermissionGroupIsUsed(permissionGroupId);
                    }
                }
                else if("7"==parameters["Tag"])//�����ӵĹ�Ա�����Ƿ��Ѿ�����
                {
                    if (null == parameters["EmployeeName"]) return null;
                    else
                    {
                        string strName = parameters["EmployeeName"].Trim();
                        count = employeeService.checkEmployeeNameIsExist(strName);
                    }
                }
                return Convert.ToString(count);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex, Constants.LOGGER_NAME);
                throw ex;
            }
        }

    }
}
