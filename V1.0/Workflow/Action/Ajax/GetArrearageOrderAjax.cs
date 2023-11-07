using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Support.Ajax;
using System.Collections.Specialized;
using Workflow.Util;
using Workflow.Action.Finance;
using Workflow.Action.Finance.Model;
using Workflow.Da.Domain;
using Workflow.Support;


namespace Workflow.Action.Ajax
{
    /// <summary>
    /// 获取价格
    /// </summary>
    /// <remarks>
    /// 作    者: 付强
    /// 创建时间: 2007-10-7
    /// 修正履历: 
    /// 修正时间:
    /// </remarks>
    public class GetArrearageOrderAjax : AjaxProcess
    {
        public FinanceAction financeAction;
        public FinanceAction FinanceAction
        {
            set { financeAction = value; }
        }
        public string DoProcess(NameValueCollection parameters)
        {
            if (!StringUtils.IsEmpty(parameters["CustomerId"]))
            {
                Order order = new Order();

                order.CustomerId = long.Parse(parameters["CustomerId"]);
                order.Status = Workflow.Support.Constants.ORDER_STATUS_SUCCESSED_VALUE;
                order.Status1 = int.Parse(Workflow.Support.Constants.CONCESSION_TYPE_ZERO_VALUE);
                order.Status2 = int.Parse(Workflow.Support.Constants.CONCESSION_TYPE_CONCESSION_VALUE);
                order.Status3 = int.Parse(Workflow.Support.Constants.CONCESSION_TYPE_RENDERUP_VALUE);
                //获取欠款---张晓林2009年4月13日17:39:33
                order.LastTelNo = Constants.PAY_KIND_CLOSED_VALUE;//结算款
                order.LinkManName = Constants.PAY_KIND_USE_PREPAY_VALUE;//预付款冲减
                order.Memo = Constants.PAY_KIND_ARREARAGE_VALUE;//应收款处理金额
                order.OrderWorking = Constants.PAY_KIND_MEMBERCARD_DIFF_VALUE;//会员卡冲减
                order.Address = Constants.PAY_KIND_USE_PRE_DEPOSITS_VALUE;//客户预存款冲减(结算)
                order.CashName = Constants.ACCOUNT_USE_PRE_DEPOSITS_VALUE;//客户预存款冲减(应收款处理:冲减的预存款)
                order.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
                order.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
                financeAction.Model.Orders = order;
                financeAction.SelectNotHaveBeenPaidOrder();
                financeAction.Model.PreDeposits = financeAction.GetCustomerPreDeposit(order.CustomerId);
                for (int i = 0; i < financeAction.Model.OrderList.Count; i++)
                {
                    financeAction.Model.OrderList[i].InsertDateTimeString = financeAction.Model.OrderList[i].InsertDateTime.ToString("yyyy-MM-dd HH:mm");
                    financeAction.Model.OrderList[i].BalanceDateTimeString = financeAction.Model.OrderList[i].BalanceDateTime.ToString("yyyy-MM-dd HH:mm");
                }
                IDictionary<Type, string> jsonDic = new Dictionary<Type, string>();
                jsonDic.Add(typeof(FinanceModel), "OrderList,PreDeposits");
                jsonDic.Add(typeof(Order), "Id,No,InsertDateTimeString,BalanceDateTimeString,SumAmount,PrepareMoneyAmount,PaidAmount,RealPaidAmount,Zero,Concession,RenderUp,ItemAmount,CustomerId");
                return JSONUtils.ToJSONString(financeAction.Model, jsonDic);
            }
            else
            {
                return "";
            }
        }
    }
}
