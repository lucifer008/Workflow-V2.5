using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;
using Workflow.Support;
namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table ORDER_ITEM_EMPLOYEE 对应的Dao 实现
	/// </summary>
    public class OrderItemEmployeeDaoImpl : Workflow.Da.Base.DaoBaseImpl<OrderItemEmployee>, IOrderItemEmployeeDao
    {
        #region IOrderItemEmployeeDao 成员
        public void DeleteOrderItemEmployeeByOrderNo(OrderItemEmployee orderItemEmployee)
        {
            //OrderItemEmployee orderItemEmployee = new OrderItemEmployee();
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            orderItemEmployee.Id = user.BranchShopId;
            orderItemEmployee.OrderItemId = user.CompanyId;
            //orderItemEmployee.No = strOrderNo;
            //orderItemEmployee.PositionId = positionId;
            
            base.sqlMap.Delete("OrderItemEmployee.DeleteOrderItemEmployeeByOrderNo", orderItemEmployee);
        }
        public void DispatchDeleteOrderItemEmployeeByOrderNo(string strOrderNo)
        {
            OrderItemEmployee orderItemEmployee = new OrderItemEmployee();
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            orderItemEmployee.Id = user.BranchShopId;
            orderItemEmployee.OrderItemId = user.CompanyId;
            orderItemEmployee.No = strOrderNo;
            orderItemEmployee.PositionId = Constants.POSITION_RECEPTION_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId);
            base.sqlMap.Delete("OrderItemEmployee.DispatchDeleteOrderItemEmployeeByOrderNo", orderItemEmployee);
        }
        public IList<OrderItemEmployee> SelectOldEmployee(OrderItemEmployee orderItemEmployee)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            orderItemEmployee.Id = user.BranchShopId;
            orderItemEmployee.OrderItemId = user.CompanyId;
            return base.sqlMap.QueryForList<OrderItemEmployee>("OrderItemEmployee.SelectOldEmployee", orderItemEmployee);
        }
        /// <summary>
        /// 名    称: 
        /// 功能概要: 查找工单明细的相关人员
        /// 作    者: 付强
        /// 创建时间: 2007-11-2
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="orderItemEmployee"></param>
        /// <returns></returns>
        public IList<OrderItemEmployee> SelectOrderItemEmployee(OrderItemEmployee orderItemEmployee)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            orderItemEmployee.Id = user.BranchShopId;
            orderItemEmployee.OrderItemId = user.CompanyId;
            
            return base.sqlMap.QueryForList<OrderItemEmployee>("OrderItemEmployee.SelectOrderItemEmployee", orderItemEmployee);

        }
        /// <summary>
        /// 名    称: 
        /// 功能概要: 查找工单明细的参与人员
        /// 作    者: 付强
        /// 创建时间: 2008-11-2
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="strOrderNo"></param>
        /// <returns></returns>
        public IList<OrderItemEmployee> GetOrderItemEmployeeByOrderNo(string strOrderNo)
        {
            return base.sqlMap.QueryForList<OrderItemEmployee>("OrderItemEmployee.GetOrderItemEmployeeByOrderNo", strOrderNo);
        }


        public IList<OrderItemEmployee> GetOrderItemEmployeeByOrderNo2(string strOrderNo)
        {
            return base.sqlMap.QueryForList<OrderItemEmployee>("OrderItemEmployee.GetOrderItemEmployeeByOrderNo2", strOrderNo);
        }


        /// <summary>
        /// 名    称: GetEmployeeEmployeeByOrderItemIdOrEmployeeId
        /// 功能概要: 根据EmployeeId和OrderItemId获取检查是否存在这样的OrderItemEmployee
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月7日13:38:29
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="orderItemEmployee"></param>
        /// <returns></returns>
        public bool GetEmployeeEmployeeByOrderItemIdOrEmployeeId(OrderItemEmployee orderItemEmployee) 
        {
            bool isExist=false;
            OrderItemEmployee isExistOrderItemEmployee = sqlMap.QueryForObject<OrderItemEmployee>("OrderItemEmployee.GetEmployeeEmployeeByOrderItemIdOrEmployeeId", orderItemEmployee);
            if (null != isExistOrderItemEmployee)
            {
                isExist = true;
            }
            return isExist;
        }

        /// <summary>
        /// 名    称: DeleteOrderItemEmployee
        /// 功能概要: 根据orderId删除OrderItemEmployee
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月7日13:38:29
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        public void DeleteOrderItemEmployee(long orderId) 
        {
            sqlMap.Delete("OrderItemEmployee.DeleteOrderItemEmployee", orderId);
        }
        #endregion
    }
}
