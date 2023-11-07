using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;
using Workflow.Support;
using System.Collections;
namespace Workflow.Da.Impl
{
	/// <summary>
    /// ��    ��: MachineTypeDaoImpl
    /// ���ܸ�Ҫ����������Dao�ӿ�ʵ��
    /// ��    ��:
    /// ����ʱ��:
    /// ��������:
    /// ����ʱ�䣺
	/// </summary>
    public class MachineTypeDaoImpl : Workflow.Da.Base.DaoBaseImpl<MachineType>, IMachineTypeDao
    {
        #region //��������
        /// <summary>
        /// ��    �ƣ�SearchMachineType
        /// ���ܸ�Ҫ: ��ȡ���������б�
        /// ��    �ߣ�������
        /// ����ʱ��: 2009��5��4��10:08:21
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public IList<MachineType> SearchMachineType(MachineType machineType) 
        {
            machineType.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            machineType.BranchShopId =ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<MachineType>("MachineType.SearchMachineType",machineType);
        }

        /// <summary>
        /// ��    �ƣ�SearchMachineTypeRowCount
        /// ���ܸ�Ҫ: ��ȡ���������б��¼��
        /// ��    �ߣ�������
        /// ����ʱ��: 2009��5��4��10:08:21
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public long SearchMachineTypeRowCount(MachineType machineType)
        {
            return sqlMap.QueryForObject<long>("MachineType.SearchMachineTypeRowCount", machineType);
        }

        /// <summary>
        /// ��    �ƣ�CheckMachineTypeIsUse
        /// ���ܸ�Ҫ: �����������Ƿ�����ʹ��
        /// ��    �ߣ�������
        /// ����ʱ��: 2009��5��4��13:35:19
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public long CheckMachineTypeIsUse(long machineTypeId) 
        {
            MachineType machineType=new MachineType();
            machineType.Id=machineTypeId;
            machineType.BranchShopId=ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            machineType.CompanyId=ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            return sqlMap.QueryForObject<long>("MachineType.CheckMachineTypeIsUse",machineType);
        }
        #endregion

		#region ��ȡ������Ҫ����Ļ�������

		public IList<MachineType> SearchNeedRecordMachineType()
		{
			User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
			Hashtable map = new Hashtable();
			map.Add("companyid", user.CompanyId);
			map.Add("branchshopid", user.BranchShopId);
			map.Add("needrecordwatch", Constants.TRUE);
			return sqlMap.QueryForList<MachineType>("MachineType.SearchNeedRecordWarchMachine", map);
		}

		#endregion
	}
}
