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
    /// 名    称: MachineTypeDaoImpl
    /// 功能概要：机器类型Dao接口实现
    /// 作    者:
    /// 创建时间:
    /// 修正履历:
    /// 修正时间：
	/// </summary>
    public class MachineTypeDaoImpl : Workflow.Da.Base.DaoBaseImpl<MachineType>, IMachineTypeDao
    {
        #region //机器类型
        /// <summary>
        /// 名    称：SearchMachineType
        /// 功能概要: 获取机器类型列表
        /// 作    者：张晓林
        /// 创建时间: 2009年5月4日10:08:21
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public IList<MachineType> SearchMachineType(MachineType machineType) 
        {
            machineType.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            machineType.BranchShopId =ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<MachineType>("MachineType.SearchMachineType",machineType);
        }

        /// <summary>
        /// 名    称：SearchMachineTypeRowCount
        /// 功能概要: 获取机器类型列表记录数
        /// 作    者：张晓林
        /// 创建时间: 2009年5月4日10:08:21
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public long SearchMachineTypeRowCount(MachineType machineType)
        {
            return sqlMap.QueryForObject<long>("MachineType.SearchMachineTypeRowCount", machineType);
        }

        /// <summary>
        /// 名    称：CheckMachineTypeIsUse
        /// 功能概要: 检查机器类型是否正在使用
        /// 作    者：张晓林
        /// 创建时间: 2009年5月4日13:35:19
        /// 修正履历:
        /// 修正时间:
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

		#region 获取所有需要抄表的机器类型

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
