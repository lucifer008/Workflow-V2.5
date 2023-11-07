using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Workflow.Support;
using Workflow.Action.Model;
using Workflow.Service.OrderManage;
using Workflow.Service.CustomerManager;
namespace Workflow.Action
{
    /// <summary>
    /// ��    ��: SearchOrderAction
    /// ���ܸ�Ҫ: ������ѯ��Action
    /// ��    ��: ��ǿ
    /// ����ʱ��: 2009-1-19
    /// ��������: 
    /// ����ʱ��: 
    /// </summary>
    public sealed class SearchOrderAction:BaseAction
    {

        #region ���Ա 
        private ISearchOrderService searchOrderService;
        public ISearchOrderService SearchOrderService
        {
            set { searchOrderService = value; }
        }
        private OrderModel model = new OrderModel();
        public OrderModel Model
        {
            get { return model; }
        }
        #endregion

        #region ������ѯ
        /// <summary>
        /// ��    ��: SearchOrderInfo
        /// ���ܸ�Ҫ: ������ѯ(��ҳ)
        /// ��    ��: ��ΰ
        /// ����ʱ��: 2007-10-8
        /// �� �� ��: ��ǿ
        /// ����ʱ��: 2009-1-21
        /// ��    ��: ��������
		/// 
		/// �� �� ��: ������
		/// ����ʱ��: 2010-4-8
		/// ��    ��: �����Ų�ѯ��Ϊģ����ѯ
        /// </summary>
        /// <param name="currentPageIndex">��ǰҳ��</param>
        /// <returns></returns>
        /// 
        public void SearchOrderInfo(int currentPageIndex)
        {
            System.Collections.Hashtable condition = new System.Collections.Hashtable();

            if (!string.IsNullOrEmpty(model.NewOrder.No))
            {
              //  condition.Add("NO",model.NewOrder.No);
				condition.Add("NO", "%"+ model.NewOrder.No +"%");
            }

            if (!string.IsNullOrEmpty(model.NewOrder.MemberCardNo))
            {
                condition.Add("MemberCardNo",model.NewOrder.MemberCardNo);
            }

            if (!string.IsNullOrEmpty(model.NewOrder.CustomerName))
            {
                condition.Add("CustomerName","%"+model.NewOrder.CustomerName+"%");
            }

            if (!string.IsNullOrEmpty(model.NewOrder.BeginBalanceDate))
            {
                condition.Add("BeginDate", model.NewOrder.BeginBalanceDate);
            }

            if (!string.IsNullOrEmpty(model.NewOrder.EndBalanceDate))
            {
                condition.Add("EndDate", model.NewOrder.EndBalanceDate);
            }

            if (model.NewOrder.SumAmount != 0)
            {
                condition.Add("Money", model.NewOrder.SumAmount);
            }
            if(!string.IsNullOrEmpty(model.Name))
            {
                condition.Add("Mobile",model.Name+"%");
            }
            if(!string.IsNullOrEmpty(model.CustomerName))
            {
                condition.Add("QQ",model.CustomerName+"%");
            }
            if(!string.IsNullOrEmpty(model.BiJiao))
            {
                condition.Add("Email",model.BiJiao+"%");
            }
            if (!string.IsNullOrEmpty(model.ComporeCondition)) 
            {
                condition.Add("IdentityNo",model.ComporeCondition+"%");
            }
            condition.Add("SelectCondition", model.NewOrder.ComporeCondition);
            condition.Add("RowCount", Constants.ROW_COUNT_FOR_PAGER);
            condition.Add("PagerCount", currentPageIndex);
            model.OrderList = searchOrderService.SearchOrdersInfo(condition);
            model.NeedPrePayOrdersCount = searchOrderService.GetSearchOrderInfoCount(condition);
            if (model.IsPrint) model.OrderTempList = searchOrderService.SearchOrdersPrint(condition);
        }

        ///// <summary>
        ///// ��    ��: GetSearchOrderInfoCount
        ///// ���ܸ�Ҫ: ��ȡ��������(������ѯ)
        ///// ��    ��: 
        ///// ����ʱ��: 
        ///// �� �� ��: ��ǿ
        ///// ����ʱ��: 2009-1-19       
        ///// </summary>
        ///// <returns>���������Ķ�������</returns>
        //public long GetSearchOrderInfoCount()
        //{
        //    Hashtable condition = new Hashtable();

        //    if (!string.IsNullOrEmpty(model.NewOrder.No))
        //    {
        //        condition.Add("NO",model.NewOrder.No);
        //    }

        //    if (!string.IsNullOrEmpty(model.NewOrder.MemberCardNo))
        //    {
        //        condition.Add("MemberCardNo",model.NewOrder.MemberCardNo);
        //    }

        //    if (!string.IsNullOrEmpty(model.NewOrder.CustomerName))
        //    {
        //        condition.Add("CustomerName",model.NewOrder.CustomerName);
        //    }

        //    if (!string.IsNullOrEmpty(model.NewOrder.BeginBalanceDate))
        //    {
        //        condition.Add("BeginDate", model.NewOrder.BeginBalanceDate);
        //    }

        //    if (!string.IsNullOrEmpty(model.NewOrder.EndBalanceDate))
        //    {
        //        condition.Add("EndDate", model.NewOrder.EndBalanceDate);
        //    }

        //    if (model.NewOrder.SumAmount != 0)
        //    {
        //        condition.Add("Money", model.NewOrder.SumAmount);
        //    }

        //    condition.Add("SelectCondition", model.NewOrder.ComporeCondition);


        //    return searchOrderService.GetSearchOrderInfoCount(condition);
        //}
        ///// <summary>
        ///// ��    ��: SearchOrdersPrint
        ///// ���ܸ�Ҫ: ����������ѯ����(��ӡ)
        ///// ��    ��: 
        ///// ����ʱ��: 
        ///// �� �� ��: ��ǿ
        ///// ����ʱ��: 2009-1-19       
        ///// </summary>
        //public void SearchOrdersPrint()
        //{
        //    Hashtable condition = new Hashtable();

        //    if (!string.IsNullOrEmpty(model.NewOrder.No))
        //    {
        //        condition.Add("NO",model.NewOrder.No);
        //    }

        //    if (!string.IsNullOrEmpty(model.NewOrder.MemberCardNo))
        //    {
        //        condition.Add("MemberCardNo",model.NewOrder.MemberCardNo);
        //    }

        //    if (!string.IsNullOrEmpty(model.NewOrder.CustomerName))
        //    {
        //        condition.Add("CustomerName",model.NewOrder.CustomerName);
        //    }

        //    if (!string.IsNullOrEmpty(model.NewOrder.BeginBalanceDate))
        //    {
        //        condition.Add("BeginDate", model.NewOrder.BeginBalanceDate);
        //    }

        //    if (!string.IsNullOrEmpty(model.NewOrder.EndBalanceDate))
        //    {
        //        condition.Add("EndDate", model.NewOrder.EndBalanceDate);
        //    }

        //    if (model.NewOrder.SumAmount != 0)
        //    {
        //        condition.Add("Money", model.NewOrder.SumAmount);
        //    }
        //    condition.Add("SelectCondition", model.NewOrder.ComporeCondition);
            
        //}
        #endregion

        #region ͨ�������Ų�ѯ�ͻ���
        /// <summary>
        /// ��    ��: SearchDelivery
        /// ���ܸ�Ҫ: ��ȡ��������(������ѯ)
        /// ��    ��: 
        /// ����ʱ��: 
        /// �� �� ��: ��ǿ
        /// ����ʱ��: 2009-1-21       
        /// </summary>
        /// <param name="OrderNo">������</param>
        public void SearchDelivery(string OrderNo)
        {
            model.Name = searchOrderService.SearchDelivery(OrderNo);
        }
        #endregion
    }
}