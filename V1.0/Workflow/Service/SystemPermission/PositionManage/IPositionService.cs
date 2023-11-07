using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Workflow.Da.Domain;
/// <summary>
/// ���ܸ�Ҫ: ��λ Service �ӿ�
/// ��    ��: ����ط
/// ����ʱ��: 2009-1-14
/// �� �� ��: 
/// ����ʱ��: 
/// ��������: 
/// </summary>

namespace Workflow.Service.SystemPermission.PositionManage
{
	public interface IPositionService
	{
		#region ��ȡȫ����λ
		
		/// <summary>
		/// ��ȡȫ����λ
		/// </summary>
		/// <returns>��λ�б�</returns>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009-1-14
		IList<Position> GetAllPositionList();

		#endregion

		#region �����λ��Ϣ

		/// <summary>
		/// �����λ��Ϣ
		/// </summary>
		/// <param name="position">��λ</param>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009-1-14
		void InsertPosition(Position position);

		#endregion

		#region ɾ����λ

		/// <summary>
		/// ɾ����λ
		/// </summary>
		/// <param name="positionId">��λId</param>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009-1-14
		void DeletePositionById(long positionId);
		
		#endregion

		#region ͨ����λid��ȡ��λ��Ϣ

		/// <summary>
		/// ͨ����λid��ȡ��λ��Ϣ
		/// </summary>
		/// <param name="positionId">��λId</param>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009-1-14
		Position GetPositionById(long positionId);

		#endregion

		#region ���¸�λ��Ϣ

		/// <summary>
		/// ���¸�λ��Ϣ
		/// </summary>
		/// <param name="position">��λ</param>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009-1-14
		void UpdatePosition(Position position);

		#endregion

        #region //���ݸ�λ��ȡ��Ա��Ϣ
        /// <summary>
        /// ���ݸ�λ��ȡ��Ա��Ϣ
        /// </summary>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��2��26��10:39:43
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        IList<Employee> GetEmployeeListByPositionId(Hashtable condition);
        #endregion
    }
}
