using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da;
using Workflow.Da.Domain;
using System.Collections;

namespace Workflow.Service
{
    public interface ICustomerService
    {
        
        /// <summary>
        /// ��    ��: InsertCustomer
        /// ���ܸ�Ҫ: �����¿ͻ�
        /// ��    ��: ��ΰ
        /// ����ʱ��: 2007-9-20
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        long InsertCustomer(Customer customer, LinkMan linkMan);
       
        /// <summary>
        /// ��    ��: DeleteCustomer
        /// ���ܸ�Ҫ: ɾ���ͻ�
        /// ��    ��: ��ΰ
        /// ����ʱ��: 2007-9-25
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// 
        void DeleteCustomer(long Id);
        /// <summary>
        /// ��    ��: UpdateCustomer
        /// ���ܸ�Ҫ: ���¿ͻ�
        /// ��    ��: ��ΰ
        /// ����ʱ��: 2007-9-26
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// 
        void UpdateCustomer(Customer customer);
      
        /// <summary>
        /// ��    ��: UpdateCustomerValidate
        /// ���ܸ�Ҫ: ���Ŀͻ�ȷ��״̬
        /// ��    ��: ��ΰ
        /// ����ʱ��: 2007-9-27
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// 
        void UpdateCustomerValidate(Customer customer);
        /// <summary>
        /// ��    ��: LogicDelete
        /// ���ܸ�Ҫ: �߼�ɾ���ͻ�
        /// ��    ��: ��ΰ
        /// ����ʱ��: 2007-9-28
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// 
        void LogicDelete(long Id);
        /// <summary>
        /// ��    ��: Update
        /// ���ܸ�Ҫ: ���¿ͻ�
        /// ��    ��: ��ΰ
        /// ����ʱ��: 2007-10-5
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// 
        void Update(Customer customer);

       
        /// <summary>
        /// ��    ��: InsertLinkMan
        /// ���ܸ�Ҫ: �������ϵ�˻������ϵ��
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-9-24
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        ///

        void InsertLinkMan(LinkMan linkMan);

      

        /// <summary>
        /// ��    ��: UpdateLinkMan
        /// ���ܸ�Ҫ: ������ϵ��
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-9-27
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        ///
        void UpdateLinkMan(LinkMan linkMan);
        /// <summary>
        /// ��    ��: DeleteLinkMan
        /// ���ܸ�Ҫ: ɾ����ϵ��
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-9-27
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        ///
        void DeleteLinkMan(long Id);
        /// <summary>
        /// ��    ��: UpdateConbinationCustomerId
        /// ���ܸ�Ҫ: �ϲ��ͻ�ʱ���Ŀͻ�Id
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-9-28
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        ///
        void UpdateConbinationCustomerId(System.Collections.Hashtable linkman);
       
    }
}
