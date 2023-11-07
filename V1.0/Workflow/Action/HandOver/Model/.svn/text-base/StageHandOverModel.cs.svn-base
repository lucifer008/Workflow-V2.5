using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Action.Model
{
    public class StageHandOverModel
    {
        /// <summary>
        /// 交班信息
        /// </summary>
        private HandOver handOver;
        public HandOver HandOver
        {
            get { return handOver; }
            set { handOver = value; }
        }

        /// <summary>
        /// 新办卡一览
        /// </summary>
        private IList<HandOverMemberCard> handOverMemberCardList;
        public IList<HandOverMemberCard> HandOverMemberCardList
        {
            get { return handOverMemberCardList;    }
            set { handOverMemberCardList = value;   }
        }
        
        /// <summary>
        /// 正在处理的工单一览
        /// </summary>
        private IList<HandOverOrder> handOverOrderList;
        public IList<HandOverOrder> HandOverOrderList
        {
            get { return handOverOrderList;     }
            set { handOverOrderList = value;    }
        }

        /// <summary>
        /// 职员一览
        /// </summary>
        private IList<Workflow.Da.Domain.Employee> employeeList;
        public IList<Workflow.Da.Domain.Employee> EmployeeList
        {
            get { return employeeList;  }
            set { employeeList = value; }
        }

        /// <summary>
        /// 正在处理工单(初期显示)
        /// </summary>
        private IList<Order> orderList;
        public IList<Order> OrderList
        {
            get { return orderList; }
            set { orderList = value; }
        }

        /// <summary>
        /// 新办卡一览(初期显示)
        /// </summary>
        private IList<MemberCard> memberCardList;
        public IList<MemberCard> MemberCardList
        {
            get { return memberCardList; }
            set { memberCardList = value; }
        }

        private string strMemberCardList;
        public string StrMemberCardList 
        {
            set { strMemberCardList = value; }
            get { return strMemberCardList; }
        }
    }
}
