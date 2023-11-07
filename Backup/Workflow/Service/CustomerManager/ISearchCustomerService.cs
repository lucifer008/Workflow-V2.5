using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Workflow.Da;
using Workflow.Da.Domain;

namespace Workflow.Service.CustomerManager
{
    public interface ISearchCustomerService
    {
        /// <summary>
        /// 名    称: SearchCustomer
        /// 功能概要: 根据条件查询客户信息
        /// 作    者: 祝新宾
        /// 创建时间: 2007-9-19
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IList<Customer> SearchCustomer(System.Collections.Hashtable condition);

        /// <summary>
        /// 名    称: SearchCustomerById
        /// 功能概要: 查询客户信息,通过Id
        /// 作    者: 刘伟
        /// 创建时间: 2007-9-20
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        Customer SearchCustomerById(long Id);
        /// <summary>
        /// 名    称: SearchAllCustomer
        /// 功能概要: 查询所有客户
        /// 作    者: 刘伟
        /// 创建时间: 2007-9-24
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// 
        IList<Customer> SearchAllCustomer();
        /// <summary>
        /// 名    称: SearchCustomerCondition
        /// 功能概要: 查询客户(客户一览)
        /// 作    者: 刘伟
        /// 创建时间: 2007-9-25
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// 
        IList<Customer> SearchCustomerCondition(System.Collections.Hashtable condition);
        /// <summary>
        /// 名    称: SearchLinkManByCustomerId
        /// 功能概要: 查询联系人，通过CustomerId
        /// 作    者: 刘伟
        /// 创建时间: 2007-9-25
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// 
        IList<LinkMan> SearchLinkManByCustomerId(long Id);

        /// <summary>
        /// 名    称: SearchAllNotValidate
        /// 功能概要: 查询所有未确认客户
        /// 作    者: 刘伟
        /// 创建时间: 2007-9-27
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// 
        IList<Customer> SearchAllNotValidate(Hashtable hashCondition);

        /// <summary>
        /// 名    称: SearchAllNotValidateRowCount
        /// 功能概要: 查询所有未确认客户记录数
        /// 作    者: 张晓林
        /// 创建时间: 2009-02-09
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// 
        long SearchAllNotValidateRowCount(Hashtable condition);

        /// <summary>
        /// 名    称: GetCustomerCount
        /// 功能概要: 获取客户总数
        /// 作    者: 付强
        /// 创建时间: 2008-11-5
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        long GetCustomerCount(Hashtable condition);

        /// <summary>
        /// 名    称: SearchLinkManByPk
        /// 功能概要: 通过Id查询linkman
        /// 作    者: liuwei
        /// 创建时间: 2007-9-27
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        ///
        LinkMan SearchLinkManByPk(long Id);

        ///// <summary>
        ///// 名    称: SearchLinkManCount
        ///// 功能概要: 通过CustomerId查询联系人数
        ///// 作    者: liuwei
        ///// 创建时间: 2007-10-10
        ///// 修正履历:
        ///// 修正时间:
        ///// </summary>
        ///// <param name="condition"></param>
        ///// <returns></returns>
        /////
        //int SearchLinkManCount(long Id);

        /// <summary>
        /// 通过CustomerId查询联系人
        /// </summary>
        /// <param name="Id">CusotmerId</param>
        /// <returns>LinkManList</returns>
        /// <remarks>
        /// 作    者: liuwei
        /// 创建时间: 2007-10-15
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        IList<LinkMan> SelectLinkManByCustomerId(long Id);

        /// <summary>
        /// 通过订单明细id获取订单明细下所有的雇工
        /// </summary>
        /// <remarks>
        /// 作    者: 陈汝胤
        /// 创建时间: 2009-1-6
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        IList<Employee> GetOrderItemEmployeeByOrderItemId(long orderItemId);

        #region 通过Customer_Id查询Orders信息
        /// <summary>
        /// 名    称: SearchOrderByCustomerId
        /// 功能概要: 通过Customer_Id查询Orders信息
        /// 作    者: 刘伟
        /// 创建时间: 2007-9-28
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="Id">CustomerId</param>
        /// <returns>符合条件的订单列表</returns>
        IList<Order> SearchOrderByCustomerId(Hashtable condition);

        /// <summary>
        /// 方法名称: SearchOrderRowCountByCustomerId
        /// 功能概要: 通过CustomerId查询Order信息记录数
        /// 作    者: 张晓林
        /// 创建时间: 2009-02-09
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="model"></param>
        /// 
        long SearchOrderRowCountByCustomerId(long customerId); 
        #endregion

        #region 通过会员卡号查找相关客户信息
        /// <summary>
        /// 名    称: SelectCustomerInfoByMemberCardNo
        /// 功能概要: 通过会员卡号查找相关客户信息
        /// 作    者: 付强
        /// 创建时间: 2007-10-23
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <returns>返回会员信息</returns>
        MemberCard SelectCustomerInfoByMemberCardNo(string memberCardNo);
        #endregion

    }
}
