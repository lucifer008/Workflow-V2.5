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
        /// 名    称: InsertCustomer
        /// 功能概要: 插入新客户
        /// 作    者: 刘伟
        /// 创建时间: 2007-9-20
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        long InsertCustomer(Customer customer, LinkMan linkMan);
       
        /// <summary>
        /// 名    称: DeleteCustomer
        /// 功能概要: 删除客户
        /// 作    者: 刘伟
        /// 创建时间: 2007-9-25
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// 
        void DeleteCustomer(long Id);
        /// <summary>
        /// 名    称: UpdateCustomer
        /// 功能概要: 更新客户
        /// 作    者: 刘伟
        /// 创建时间: 2007-9-26
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// 
        void UpdateCustomer(Customer customer);
      
        /// <summary>
        /// 名    称: UpdateCustomerValidate
        /// 功能概要: 更改客户确认状态
        /// 作    者: 刘伟
        /// 创建时间: 2007-9-27
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// 
        void UpdateCustomerValidate(Customer customer);
        /// <summary>
        /// 名    称: LogicDelete
        /// 功能概要: 逻辑删除客户
        /// 作    者: 刘伟
        /// 创建时间: 2007-9-28
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// 
        void LogicDelete(long Id);
        /// <summary>
        /// 名    称: Update
        /// 功能概要: 更新客户
        /// 作    者: 刘伟
        /// 创建时间: 2007-10-5
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// 
        void Update(Customer customer);

       
        /// <summary>
        /// 名    称: InsertLinkMan
        /// 功能概要: 新添加联系人或更改联系人
        /// 作    者: liuwei
        /// 创建时间: 2007-9-24
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        ///

        void InsertLinkMan(LinkMan linkMan);

      

        /// <summary>
        /// 名    称: UpdateLinkMan
        /// 功能概要: 更新联系人
        /// 作    者: liuwei
        /// 创建时间: 2007-9-27
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        ///
        void UpdateLinkMan(LinkMan linkMan);
        /// <summary>
        /// 名    称: DeleteLinkMan
        /// 功能概要: 删除联系人
        /// 作    者: liuwei
        /// 创建时间: 2007-9-27
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        ///
        void DeleteLinkMan(long Id);
        /// <summary>
        /// 名    称: UpdateConbinationCustomerId
        /// 功能概要: 合并客户时更改客户Id
        /// 作    者: liuwei
        /// 创建时间: 2007-9-28
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        ///
        void UpdateConbinationCustomerId(System.Collections.Hashtable linkman);
       
    }
}
