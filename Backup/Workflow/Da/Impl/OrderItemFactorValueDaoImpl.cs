using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;
using Workflow.Support;

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table ORDER_ITEM_FACTOR_VALUE ��Ӧ��Dao ʵ��
	/// </summary>
    public class OrderItemFactorValueDaoImpl : Workflow.Da.Base.DaoBaseImpl<OrderItemFactorValue>, IOrderItemFactorValueDao
    {
        public void DeleteOrderItemFactorValueByOrderNo(string strOrderNo)
        {
            OrderItemFactorValue orderItemFactorValue = new OrderItemFactorValue();
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            orderItemFactorValue.Id = user.BranchShopId;
            orderItemFactorValue.OrderItemId = user.CompanyId;
            orderItemFactorValue.Value = strOrderNo;
            base.sqlMap.Delete("OrderItemFactorValue.DeleteOrderItemFactorValueByOrderNo", orderItemFactorValue);
        }

        /// <summary>
        /// ��    ��: GetOrderItemFactorValueListByOrderNO
        /// ���ܸ�Ҫ: ���ݶ����Ż�ȡ������ϸ����ֵ�б�
        /// ��    �ߣ�������
        /// ����ʱ��: 2009��11��23��13:26:05
        /// ����������
        /// ����ʱ�䣺
        /// </summary>
        public IList<OrderItemFactorValue> GetOrderItemFactorValueListByOrderNO(string orderNo) 
        {
            OrderItemFactorValue orderItemFactorValue = new OrderItemFactorValue();
            orderItemFactorValue.Value = orderNo;
            orderItemFactorValue.PriceFactorId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            orderItemFactorValue.OrderItemId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<OrderItemFactorValue>("OrderItemFactorValue.GetOrderItemFactorValueListByOrderNO", orderItemFactorValue);
        }
    }
}
