using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using System.Collections;
/// <summary>
/// 名    称: ICustomerDao
/// 功能概要: 客户接口
/// 作    者: 
/// 创建时间: 
/// 修正履历: 张晓林
/// 修正时间: 2009-02-07
///             调整代码
/// </summary>
namespace Workflow.Da
{
	/// <summary>
	/// Table CUSTOMER 对应的Dao 接口
	/// </summary>
    public interface ICustomerDao : IDaoBase<Customer>
    {
        /// <summary>
        /// 名    称: SearchCustomer
        /// 功能概要: 查询客户
        /// 作    者: liuwei
        /// 创建时间: 2007-9-24
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="customer">customer</param>
        /// <returns></returns>
        ///
        IList<Customer> SearchCustomer(System.Collections.Hashtable customer);
        /// <summary>
        /// 名    称: SearchCustomerCondition
        /// 功能概要: 查询客户(客户一览)
        /// 作    者: liuwei
        /// 创建时间: 2007-9-25
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="customer">customer</param>
        /// <returns></returns>
        ///
        IList<Customer> SearchCustomerCondition(System.Collections.Hashtable customer);
        /// <summary>
        /// 名    称: DeleteLinkMan
        /// 功能概要: 删除联系人
        /// 作    者: liuwei
        /// 创建时间: 2007-9-25
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="Id">Id</param>
        /// <returns></returns>
        ///
        void DeleteLinkMan(long Id);
        /// <summary>
        /// 名    称: SearchAllNotValidate
        /// 功能概要: 查询所有未确认客户
        /// 作    者: liuwei
        /// 创建时间: 2007-9-27
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        ///
        IList<Customer> SearchAllNotValidate(Hashtable condition);

         /// <summary>
        /// 名    称: SearchAllNotValidateRowCount
        /// 功能概要: 查询所有未确认客户 的记录数目
        /// 作    者: 张晓林
        /// 创建时间: 2009-02-09
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        ///
       long SearchAllNotValidateRowCount(Hashtable condition);

        /// <summary>
        /// 名    称: UpdateValidateStatus
        /// 功能概要: 更新客户状态
        /// 作    者: liuwei
        /// 创建时间: 2007-10-10
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        ///
        void UpdateValidateStatus(System.Collections.Hashtable condition);

        #region//查询没有消费的客户
        /// <summary>
        /// 名    称: SelectWithoutConsumeCustomer
        /// 功能概要: 查询没有消费的客户
        /// 作    者: 付强
        /// 创建时间: 2007-10-31
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IList<Customer> SelectWithoutConsumeCustomer(Hashtable customer);

        /// <summary>
        /// 名    称: GetWithoutConsumeCustomerRowCount
        /// 功能概要: 查询没有消费的客户记录数
        /// 作    者: 张晓林
        /// 创建时间: 2010年1月21日14:21:56
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        long GetWithoutConsumeCustomerRowCount(Hashtable customer);

        /// <summary>
        /// 名    称: GetWithoutConsumeCustomerRowPrint
        /// 功能概要: 查询没有消费的客户输出
        /// 作    者: 张晓林
        /// 创建时间: 2010年1月21日14:21:56
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IList<Customer> GetWithoutConsumeCustomerRowPrint(Hashtable customer);
        #endregion

        /// <summary>
        /// 名    称: UpdateCustomerLinkManInfo
        /// 功能概要: 通过客户ID更新客户最后一次联系人信息和联系人数量
        /// 作    者: 付强
        /// 创建时间: 2007-10-31
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        void UpdateCustomerLinkManInfo(Customer customer);

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
        /// 名    称: SearchOrderByCustomerId
        /// 功能概要: 通过CustomerId查询Order信息
        /// 作    者: liuwei
        /// 创建时间: 2007-9-28
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        ///
        IList<Order> SelectOrderByCustomerId(Hashtable condition);

        /// <summary>
        /// 名    称: SearchOrderByCustomerId
        /// 功能概要: 通过CustomerId查询Order信息
        /// 作    者: liuwei
        /// 创建时间: 2007-9-28
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        ///
        long SelectOrderRowCountByCustomerId(long Id);

        /// <summary>
        /// 名    称: SavePreDeposit
        /// 功能概要: 保存客户预存款
        /// 作    者: 张晓林
        /// 创建时间: 2009年11月3日14:15:57
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        void SavePreDeposit(Customer customer);

        /// <summary>
        /// 名    称: DiffPreDeposits
        /// 功能概要: 客户预存款冲减
        /// 作    者: 张晓林
        /// 创建时间: 2009年11月4日10:47:15
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        void DiffPreDeposits(Customer customer);

		#region 获取用户信息

		/// <summary>
		/// 获取用户信息
		/// </summary>
		/// <param name="memberCardNo">会员卡号</param>
		/// <param name="customerName">客户名称</param>
		/// <returns></returns>
		Customer GetCustomer(string memberCardNo, string customerName);

		#endregion
	}
}
