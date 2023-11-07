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
	/// Table RECORD_MACHINE_WATCH ��Ӧ��Dao ʵ��
	/// </summary>
    public class RecordMachineWatchDaoImpl : Workflow.Da.Base.DaoBaseImpl<RecordMachineWatch>, IRecordMachineWatchDao
    {
        public RecordMachineWatch SelectLastTimeRecordMachineWatch(RecordMachineWatch recordMachineWatch)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;

            recordMachineWatch.CompanyId = user.CompanyId;
            recordMachineWatch.BranchShopId = user.BranchShopId;
            return sqlMap.QueryForObject<RecordMachineWatch>("RecordMachineWatch.SelectLastTimeRecordMachineWatch", recordMachineWatch);
        }

		#region ��ȡһ�����õĳ����¼

		/// <summary>
		/// ��ȡһ�����õĳ����¼
		/// ������ʱ��ŵ�ǰ�ĳ�����Ϣ,������Ϣ���к�ʵ�����Ч
		/// </summary>
		/// <returns>RecordMachineWatch</returns>
		/// <remarks>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009.4.24
		/// </remarks>
		public RecordMachineWatch SelectCompleteRecordMachineWatch()
		{
			User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
			Hashtable map = new Hashtable();
			map.Add("companyid", user.CompanyId);
			map.Add("branchshopid", user.BranchShopId);
			map.Add("isconfirmed", Constants.FALSE);
			return sqlMap.QueryForObject<RecordMachineWatch>("RecordMachineWatch.SelectCompleteRecordMachineWatch", map);
		}

		#endregion

		#region ���¿��õĳ����¼

		/// <summary>
		/// ���¿��õĳ����¼(��1�θ���ʱ��ʼ������)
		/// </summary>
		public void UpdateCanUsedRecordMachineWatch()
		{
			User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
			Hashtable map = new Hashtable();
			map.Add("companyid", user.CompanyId);
			map.Add("branchshopid", user.BranchShopId);
			map.Add("isconfirmed", Constants.TRUE);
			map.Add("confirmed", Constants.FALSE);
			sqlMap.Update("RecordMachineWatch.UpdateCanUsedRecordMachineWatch", map);
		}

		#endregion


		#region ��ȡ���һ�γ����¼

		/// <summary>
		/// ��ȡ���һ�γ����¼
		/// </summary>
		/// <returns>RecordMachineWatch</returns>
		/// <remarks>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009.4.28
		/// </remarks>
		public RecordMachineWatch SelectLastRecordMachineWatch()
		{
			User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
			Hashtable map = new Hashtable();
			map.Add("companyid", user.CompanyId);
			map.Add("branchshopid", user.BranchShopId);
			map.Add("isconfirmed", Constants.TRUE);
			return sqlMap.QueryForObject<RecordMachineWatch>("RecordMachineWatch.SelectLastRecordMachineWatch", map);
		}

		#endregion

		#region ��ȡ��ʵ����,��ɵĶ�������ֽ��,ͨ���ϴγ���ʱ��,����id,ֽ��id

		/// <summary>
		/// ��ȡ��ʵ����,��ɵĶ�������ֽ��,ͨ���ϴγ���ʱ��,����id,ֽ��id
		/// </summary>
		/// <returns>����</returns>
		/// <remarks>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009.5.4
		/// </remarks>
		public int GetVerifyRecordWatchCompleteOrderUsedCount(Hashtable map)
		{
			User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
			map.Add("companyid", user.CompanyId);
			map.Add("branchshopid", user.BranchShopId);
			return sqlMap.QueryForObject<int>("RecordMachineWatch.GetVerifyRecordWatchCompleteOrderUsedCount", map);
		}

		#endregion

		#region ���³����¼��ȷ��״̬

		/// <summary>
		/// ���³����¼��ȷ��״̬
		/// </summary>
		/// <param name="recordMachineWatchId">�����¼״̬</param>
		/// <param name="status">״̬</param>
		/// <remarks>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009.5.7
		/// </remarks>
		public void UpdateIsConfirmedById(long recordMachineWatchId, string status)
		{
			Hashtable map = new Hashtable();
			map.Add("id", recordMachineWatchId);
			map.Add("status", status);
			sqlMap.Update("RecordMachineWatch.UpdateIsConfirmedById", map);
		}

		#endregion

		#region ��ȡ�����¼

		public IList<RecordMachineWatch> GetRecordMachineWatch(int beginRow, int endRow, string beginDate, string endDate)
		{
			User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
			Hashtable map = new Hashtable();
			map.Add("beginRow", beginRow);
			map.Add("endRow", endRow);
			map.Add("beginDate", beginDate);
			map.Add("endDate", endDate);
			map.Add("companyId", user.CompanyId);
			map.Add("branchshopId", user.BranchShopId);
			map.Add("isconfirmed", Constants.TRUE);
			return sqlMap.QueryForList<RecordMachineWatch>("RecordMachineWatch.GetRecordMachineWatch", map);
		}

		#endregion

		#region ��ȡ��Ч�ĳ�����

		public int GetRecordMachineWatchCount(string beginDate, string endDate)
		{
			User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
			Hashtable map = new Hashtable();
			map.Add("companyId", user.CompanyId);
			map.Add("branchshopId", user.BranchShopId);
			map.Add("isconfirmed", Constants.TRUE);

			map.Add("beginDate", beginDate);
			map.Add("endDate", endDate);
			return sqlMap.QueryForObject<int>("RecordMachineWatch.GetRecordMachineWatchCount", map);
		}

		#endregion
	}
}
