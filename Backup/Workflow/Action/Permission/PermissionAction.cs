using System;
using System.Collections.Generic;
using Workflow.Service;
using Workflow.Support;
using Workflow.Action.Permission.Model;
using Workflow.Service.SystemPermission.PermissionManage;
/// <summary>
/// ��    ��: PermissionAction
/// ���ܸ�Ҫ: ��������Action
/// ��    ��: ������
/// ����ʱ��: 2009��1��16��
/// ��������: 
/// ����ʱ��:            
/// </summary>
namespace Workflow.Action.Permission
{
    public class PermissionAction
    {
        #region Model
        private PermissionModel model = new PermissionModel();
        public PermissionModel Model
        {
            get { return model; }
        }
        #endregion

        #region ע�� permissionService

        private IPermissionService permissionService;
        public IPermissionService PermissionService 
        {
            set { permissionService = value; }
        }
        #endregion

        #region //��Ӳ���
        /// <summary>
        /// ��Ӳ���
        /// </summary>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��1��16��
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        public void AddPermissionInfo() 
        {
            permissionService.AddPermissionInfo(Model.Permission);
        }
        #endregion

        #region //��ȡ���������б�
        /// <summary>
        /// ��ȡ���������б� 
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        /// <remarks>
        /// ������:������
        /// ����ʱ��:2009��1��16��
        /// ��������:
        /// ������:
        /// </remarks>
        public void SearchPermissionInfo()
        {
            model.PermissionList = permissionService.SearchPermissionInfo(Model.Permission);
        }
        #endregion

        #region //��ȡ���������б����
        /// <summary>
        /// ��ȡ���������б����
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        /// <remarks>
        /// ������:������
        /// ����ʱ��:2009��1��16��
        /// ��������:
        /// ������:
        /// </remarks>
        public long SearchPermissionInfoRowCount()
        {
            return permissionService.SearchPermissionInfoRowCount(Model.Permission);
        }
        #endregion

        #region //���ݲ���Idɾ��������Ϣ
        /// <summary>
        /// ���ݲ���Idɾ��������Ϣ
        /// </summary>
        /// <param name="permissionId"></param>
        /// <remarks>
        /// ������:������
        /// ����ʱ��:2009��1��16��
        /// ��������:
        /// ������:
        /// </remarks>
        public void DeletePermissionInfo(long permissionId) 
        {
            permissionService.DeletePermissionInfo(permissionId);
        }
        #endregion

        #region //���ݲ���Id���²�����Ϣ
        /// <summary>
        /// ���ݲ���Id���²�����Ϣ
        /// </summary>
        /// <param name="permissionId"></param>
        /// <remarks>
        /// ������:������
        /// ����ʱ��:2009��1��16��
        /// ��������:
        /// ������:
        /// </remarks>
        public void UpdatePermissionInfo() 
        {
            permissionService.UpdatePermissionInfo(model.Permission);
        }
        #endregion

        #region//Ȩ�������

        /// <summary>
        /// ���Ȩ����
        /// </summary>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��15��10:21:32
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        public void AddPermissionGroup() 
        {
            permissionService.AddPermissionGroup(model.PermissionGroup);
        }

        /// <summary>
        /// �޸�Ȩ����
        /// </summary>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��15��10:21:32
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        public void UpdatePermissionGroup()
        {
            permissionService.UpdatePermissionGroup(model.PermissionGroup);
        }

        /// <summary>
        /// ��ȡȨ�����б�
        /// </summary>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��15��10:21:32
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        public void GetPermissionGroup()
        {
            model.PermissionGroupList = permissionService.GetPermissionGroup(model.PermissionGroup);
            model.RowCount = permissionService.GetPermissionGroupRowCount(model.PermissionGroup);
        }

        /// <summary>
        /// ɾ��Ȩ�����б�
        /// </summary>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��15��14:17:56
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        public void LogicDeletePermissionGroup() 
        {
            permissionService.LogicDeletePermissionGroup(model.PermissionGroup);
        }
        #endregion
    }
}
