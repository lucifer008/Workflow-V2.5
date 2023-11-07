using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Action.Model
{
    public class HandOverQueryModel
    {   
        /// <summary>
        /// 交班查询条件
        /// </summary>
        private HandOver handOver;
        public HandOver HandOver
        {
            get { return handOver;  }
            set { handOver = value; }
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
        /// 部门一览
        /// </summary>
        private IList<Position> positionList;
        public IList<Position> PositionList
        {
            get { return positionList; }
            set { positionList = value; }
        }

        /// <summary>
        /// 交班一览
        /// </summary>
        private IList<HandOver> handOverList;
        public IList<HandOver> HandOverList
        {
            get { return handOverList;  }
            set { handOverList = value; }
        }

        private IList<MemberCard> memberCardList;
        public IList<MemberCard> MemberCardList 
        {
            set { memberCardList = value; }
            get { return memberCardList; }
        }

        private IList<Order> orderList;
        public IList<Order> OrderList 
        {
            set { orderList = value; }
            get { return orderList; }
        }

        private CashHandOver cashHandOver;
        public CashHandOver CashHandOver 
        {
            set { cashHandOver = value; }
            get { return cashHandOver; }
        }
    }
}
