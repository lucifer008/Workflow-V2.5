using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
namespace Workflow.Action.Model
{
    public class CashHandOverModel
    {
        /// <summary>
        /// 交班信息
        /// </summary>
        private HandOver handOver;
        public HandOver HandOver
        {
            get { return handOver;  }
            set { handOver = value; }
        }

        /// <summary>
        /// 收银交班信息
        /// </summary>
        private CashHandOver cashHandOver;
        public CashHandOver CashHandOver
        {
            get { return cashHandOver;  }
            set { cashHandOver = value; }
        }

        /// <summary>
        /// 预付定金的工单一览(查询)
        /// </summary>
        private IList<Order> orderList;
        public IList<Order> OrderList
        {
            get { return orderList;  }
            set { orderList = value; }
        }

        /// <summary>
        /// 职员一览
        /// </summary>
        private IList<Workflow.Da.Domain.Employee> employeeList;
        public IList<Workflow.Da.Domain.Employee> EmployeeList
        {
            get { return employeeList; }
            set { employeeList = value; }
        }

        /// <summary>
        /// 预付定金的工单一览(保存)
        /// </summary>
        private IList<CashHandOverOrder> cashHandOverOrderList;
        public IList<CashHandOverOrder> CashHandOverOrderList
        {
            get { return cashHandOverOrderList;  }
            set { cashHandOverOrderList = value; }
        }

        private string handOverDateTime;
        public string HandOverDateTime 
        {
            set { handOverDateTime = value; }
            get { return handOverDateTime; }
        }
    }
}
