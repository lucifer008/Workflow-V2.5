using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table ID_GENERATOR ��Ӧ��Dao �ӿ�
	/// </summary>
    public interface IIdGeneratorDao : IDaoBase<IdGenerator>
    {
        IdGenerator NextId(long branchShopId, string flagno, int size);

        /// <summary>
        /// ��   ��:  SearchIdGenerator
        /// ���ܸ�Ҫ: ��ȡId�����б�
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��6��10:42:26
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        IList<IdGenerator> SearchIdGenerator(IdGenerator idGenerator);

        /// <summary>
        /// ��   ��:  SearchIdGeneratorRowCount
        /// ���ܸ�Ҫ: ��ȡId�����б����
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��6��10:42:26
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        long SearchIdGeneratorRowCount(IdGenerator idGenerator); 

        /// <summary>
        /// ��   ��:  GetAllUserTableName
        /// ���ܸ�Ҫ: ��ȡ���е��û����б�
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��6��13:23:36
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        IList<IdGenerator> GetAllUserTableName(); 

        /// <summary>
        /// ��   ��:  GetRecordRowCountByTableName
        /// ���ܸ�Ҫ: ���ݱ����ƻ�ȡ��ǰ���еļ�¼�� 
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��8��17:28:30
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        long GetRecordRowCountByTableName(string tableName); 

        /// <summary>
        /// ��   ��:  DeleteIdGenerator
        /// ���ܸ�Ҫ: ɾ�������û�Id
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��6��13:23:36
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        void DeleteIdGenerator();

        /// <summary>
        /// ��   ��:  InsertIdGenerator
        /// ���ܸ�Ҫ: ����һ��InsertIdGenerator
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��6��13:23:36
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        void InsertIdGenerator(IdGenerator idGenerator);
    }
}
