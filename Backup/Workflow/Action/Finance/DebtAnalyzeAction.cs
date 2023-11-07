using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Service.OrderManage;
using Workflow.Support;

namespace Workflow.Action.Finance
{
	public class DebtAnalyzeAction
	{
		private DebtAnalyzeModel model=new DebtAnalyzeModel();
		public DebtAnalyzeModel Model
		{
			get { return model; }
		}

		#region inject

		#region orderService
		
		private IOrderService orderService;
		/// <summary>
		/// orderService
		/// </summary>
		public IOrderService OrderService
		{
			get { return orderService; }
			set { orderService = value; }
		}
		#endregion

		#endregion

		#region 创建分析帐龄的时间段

		private void GetDebtAnalyTimes()
		{
			AnalyzeTime val = new AnalyzeTime();
			val.BeginTime = DateTime.Now;
			val.EndTime=DateTime.Now.AddDays(-10);
			model.AnalyzeTimes.Add(val);

			val = new AnalyzeTime();
			val.BeginTime = DateTime.Now.AddDays(-10);
			val.EndTime = DateTime.Now.AddDays(-30);
			model.AnalyzeTimes.Add(val);

			val = new AnalyzeTime();
			val.BeginTime = DateTime.Now.AddDays(-30);
			val.EndTime = DateTime.Now.AddDays(-60);
			model.AnalyzeTimes.Add(val);

			val = new AnalyzeTime();
			val.BeginTime = DateTime.Now.AddDays(-60);
			val.EndTime = DateTime.Now.AddDays(-90);
			model.AnalyzeTimes.Add(val);

			val = new AnalyzeTime();
			val.BeginTime = DateTime.Now.AddDays(-90);
			val.EndTime = DateTime.Now.AddDays(-120);
			model.AnalyzeTimes.Add(val);

			val = new AnalyzeTime();
			val.BeginTime = DateTime.Now.AddDays(-120);
			val.EndTime = DateTime.Parse("1900-1-1");
			model.AnalyzeTimes.Add(val);
		}

		#endregion

		#region 获取帐龄分析

		public void GetDebtAnalyze()
		{
			GetDebtAnalyTimes();
			int index = 0;
			foreach (AnalyzeTime val in model.AnalyzeTimes)
			{
				GetDebtAnalyzeByDateTime(val.BeginTime, val.EndTime, index);
				index++;
			}
		}

		#endregion


		#region 获取一定时间段内的帐龄分析结果

		private void GetDebtAnalyzeByDateTime(DateTime beginTime, DateTime endTime, int index)
		{
			IList<Order> orders = orderService.GetOrders(beginTime, endTime, Constants.PAYMENT_TYPE_ACCOUNT_GET_VALUE, Constants.ORDER_STATUS_SUCCESSED_VALUE, model.UserName);
			foreach (Order val in orders)
			{
				AnalyzeData data = null;
				if (val.SumAmount != val.RealPaidAmount + val.ConcessionAmount)
				{
					decimal oweAmount = val.SumAmount - val.RealPaidAmount - val.ConcessionAmount;
					if (model.Map[val.CustomerId] == null)
					{
						data = new AnalyzeData();
						data.CustomerName = val.CustomerName;
						data.Result[index] += oweAmount;
						data.Result[6] += oweAmount;
						model.Map.Add(val.CustomerId, data);
					}
					else
					{
						data = (AnalyzeData)model.Map[val.CustomerId];
						data.Result[index] += oweAmount;
						data.Result[6] += oweAmount;
					}
					model.ResultSum[index] += oweAmount;  //小结
					model.ResultSum[6] += oweAmount;      //总结
				}
			}
		}

		#endregion

	}
}
