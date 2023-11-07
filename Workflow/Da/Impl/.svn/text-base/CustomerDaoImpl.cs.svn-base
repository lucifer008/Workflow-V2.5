using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;
using Workflow.Support;
using System.Collections;
/// <summary>
/// 名    称: CustomerDaoImpl
/// 功能概要: 客户接口ICustomerDao实现类
/// 作    者: 
/// 创建时间: 
/// 修正履历: 张晓林
/// 修正时间: 2009-02-07
///             调整代码
/// </summary>
namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table CUSTOMER 对应的Dao 实现
	/// </summary>
    public class CustomerDaoImpl : Workflow.Da.Base.DaoBaseImpl<Customer>, ICustomerDao
    {
        #region 根据条件查询客户
        public IList<Customer> SearchCustomer(System.Collections.Hashtable customer)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            customer.Add("BranchShopId",user.BranchShopId);
            customer.Add("CompanyId", user.CompanyId);
            return sqlMap.QueryForList<Customer>("Customer.SearchCustomer", customer);
        }
        #endregion

        #region 根据客户一览中的条件进查询客户
        public IList<Customer> SearchCustomerCondition(System.Collections.Hashtable customer)
        {
            return sqlMap.QueryForList<Customer>("Customer.SearchCustomerList", customer);
        }
        #endregion

        #region 查询所有未确认的客户
        /// <summary>
        /// 查询所有未确认的客户
        /// </summary>
        /// <param name="hashCondition"></param>
        /// <returns></returns>
        public IList<Customer> SearchAllNotValidate(Hashtable hashCondition)
        {
            hashCondition.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            hashCondition.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            return sqlMap.QueryForList<Customer>("Customer.SelectAllNotValidate", hashCondition);
        }

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
        public long SearchAllNotValidateRowCount(Hashtable condition) 
        {
            condition.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            condition.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            return sqlMap.QueryForObject<long>("Customer.SelectAllNotValidateRowCount", condition);
        }
        #endregion

        #region 删除联系人
        public void DeleteLinkMan(long Id)
        {
            sqlMap.Delete("Customer.DeleteLinkMan", Id);
        }
        #endregion

        #region 更新客户状态
        public void UpdateValidateStatus(System.Collections.Hashtable condition)
        {
            sqlMap.Update("Customer.UpdateValidateStatus", condition);
        }
        #endregion

        #region //查询没有消费的客户
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
        public IList<Customer> SelectWithoutConsumeCustomer(Hashtable customer)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            customer.Add("CompanyId", user.CompanyId);
            customer.Add("BranchShopId", user.BranchShopId);
            return sqlMap.QueryForList<Customer>("Customer.SelectWithoutConsumeCustomer", customer);
        }
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
        public long GetWithoutConsumeCustomerRowCount(Hashtable customer) 
        {
            return sqlMap.QueryForObject<long>("Customer.GetWithoutConsumeCustomerRowCount", customer);
        }

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
        public IList<Customer> GetWithoutConsumeCustomerRowPrint(Hashtable customer) 
        {
            return sqlMap.QueryForList<Customer>("Customer.GetWithoutConsumeCustomerRowPrint", customer);
        }

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
        public void UpdateCustomerLinkManInfo(Customer customer)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            customer.CompanyId=user.CompanyId;
            customer.BranchShopId=user.BranchShopId;
            sqlMap.Update("Customer.UpdateCustomerLinkManInfo",customer);
        }
    
        #endregion

        #region 获取客户总数
        /// <summary>
        /// 名    称: GetCustomerCount
        /// 功能概要: 获取客户总数
        /// 作    者: 付强
        /// 创建时间: 2008-11-5
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public long GetCustomerCount(Hashtable condition)
        {
            condition.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            condition.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            return (long)sqlMap.QueryForObject("Customer.GetCustomerCount", condition);

        }
        #endregion

        #region //查询客户消费历史
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
        public IList<Order> SelectOrderByCustomerId(Hashtable condition) 
        {
            condition.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            condition.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            return sqlMap.QueryForList<Order>("Customer.SelectoOrderByCustomerId", condition);
        }

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
        public long SelectOrderRowCountByCustomerId(long Id) 
        {
            Hashtable condtion = new Hashtable();
            condtion.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            condtion.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            condtion.Add("CustomerId",Id);
            return sqlMap.QueryForObject<long>("Customer.SelectoOrderRowCountByCustomerId", condtion);
        }
        #endregion

        #region//保存客户预存款
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
        public void SavePreDeposit(Customer customer) 
        {
            long cuId = Constants.scatteredClientId(Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            if (cuId != customer.Id)
            {
                //customer.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
                //customer.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
                sqlMap.Update("Customer.SavePreDeposit", customer);
            }
        }
        #endregion

        #region//预存款冲减
        /// <summary>
        /// 名    称: DiffPreDeposits
        /// 功能概要: 客户预存款冲减
        /// 作    者: 张晓林
        /// 创建时间: 2009年11月4日10:47:15
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void DiffPreDeposits(Customer customer) 
        {
            sqlMap.Update("Customer.DiffPreDeposits", customer);
        }
        #endregion

		#region 获取用户信息

		public Customer GetCustomer(string memberCardNo, string customerName)
		{
			Hashtable map = new Hashtable();
			map.Add("memberCardNo", memberCardNo);
			map.Add("customerName", customerName);
			User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
			map.Add("branchShopId", user.BranchShopId);
			map.Add("companyId", user.CompanyId);
			return sqlMap.QueryForObject<Customer>("Customer.GetCustomer", map);
		}

		#endregion
    }
}
