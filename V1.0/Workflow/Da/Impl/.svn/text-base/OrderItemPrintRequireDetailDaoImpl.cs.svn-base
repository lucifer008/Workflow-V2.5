using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;
using Workflow.Support;
namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table ORDER_ITEM_PRINT_REQUIRE_DETAIL 对应的Dao 实现
	/// </summary>
    public class OrderItemPrintRequireDetailDaoImpl : Workflow.Da.Base.DaoBaseImpl<OrderItemPrintRequireDetail>, IOrderItemPrintRequireDetailDao
    {
        public IList<OrderItemPrintRequireDetail> GetOrderItemPrintRequireDetailByOrderNo(string strOrderNo)
        {
            OrderItemPrintRequireDetail orderItemPrintRequireDetail = new OrderItemPrintRequireDetail();
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            orderItemPrintRequireDetail.Id = user.BranchShopId;
            orderItemPrintRequireDetail.OrderItemId = user.CompanyId;
            orderItemPrintRequireDetail.Name = strOrderNo;
            return base.sqlMap.QueryForList<OrderItemPrintRequireDetail>("OrderItemPrintRequireDetail.SelectOrderItemPrintRequire", orderItemPrintRequireDetail);
        }
        public void DeleteOrderItemPrintRequireByOrderNo(string strOrderNo)
        {
            OrderItemPrintRequireDetail orderItemPrintRequireDetail = new OrderItemPrintRequireDetail();
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            orderItemPrintRequireDetail.Id = user.BranchShopId;
            orderItemPrintRequireDetail.OrderItemId = user.CompanyId;
            orderItemPrintRequireDetail.Name = strOrderNo;
            base.sqlMap.Delete("OrderItemPrintRequireDetail.DeleteOrderItemPrintRequireByOrderNo", orderItemPrintRequireDetail);
        }
    }
}
