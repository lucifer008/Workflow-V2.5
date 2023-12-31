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
    /// 名    称: SearchOrderAction
    /// 功能概要: 订单查询的Action
    /// 作    者: 付强
    /// 创建时间: 2009-1-19
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    public sealed class SearchOrderAction:BaseAction
    {

        #region 类成员 
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

        #region 订单查询
        /// <summary>
        /// 名    称: SearchOrderInfo
        /// 功能概要: 订单查询(分页)
        /// 作    者: 刘伟
        /// 创建时间: 2007-10-8
        /// 修 正 人: 付强
        /// 修正时间: 2009-1-21
        /// 描    述: 代码整理
		/// 
		/// 修 正 人: 白晓宇
		/// 修正时间: 2010-4-8
		/// 描    述: 订单号查询改为模糊查询
        /// </summary>
        /// <param name="currentPageIndex">当前页码</param>
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
        ///// 名    称: GetSearchOrderInfoCount
        ///// 功能概要: 获取订单总数(订单查询)
        ///// 作    者: 
        ///// 创建时间: 
        ///// 修 正 人: 付强
        ///// 修正时间: 2009-1-19       
        ///// </summary>
        ///// <returns>符合条件的订单总数</returns>
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
        ///// 名    称: SearchOrdersPrint
        ///// 功能概要: 按照条件查询订单(打印)
        ///// 作    者: 
        ///// 创建时间: 
        ///// 修 正 人: 付强
        ///// 修正时间: 2009-1-19       
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

        #region 通过订单号查询送货人
        /// <summary>
        /// 名    称: SearchDelivery
        /// 功能概要: 获取订单总数(订单查询)
        /// 作    者: 
        /// 创建时间: 
        /// 修 正 人: 付强
        /// 修正时间: 2009-1-21       
        /// </summary>
        /// <param name="OrderNo">订单号</param>
        public void SearchDelivery(string OrderNo)
        {
            model.Name = searchOrderService.SearchDelivery(OrderNo);
        }
        #endregion
    }
}
