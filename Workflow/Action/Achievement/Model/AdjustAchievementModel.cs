using System;
using System.Text;
using System.Collections.Generic;
using Workflow.Da.Domain;
using Workflow.Service.Impl;

/// <summary>
/// 名    称: AdjustAchievementModel
/// 功能概要: 绩效调整的Model
/// 作    者: 付强
/// 创建时间: 2008-11-02
/// 修正履历: 张晓林
/// 修正时间: 2009-02-01
///             调整代码结构
/// </summary>
namespace Workflow.Action.Achievement.Model
{

    public class AdjustAchievementModel
    {
        #region Class Member
        public AdjustAchievementModel()
        {
        }

        private int searchDate;
        public int SearchDate 
        {
            set { searchDate = value; }
            get { return searchDate; }
        }

        private Workflow.Da.Domain.Achievement newAchievement=new Workflow.Da.Domain.Achievement();
        public Workflow.Da.Domain.Achievement NewAchievement 
        {
            set { newAchievement = value; }
            get { return newAchievement; }
        }

        private IList<Workflow.Da.Domain.Achievement> achievementList = new List<Workflow.Da.Domain.Achievement>();
        public IList<Workflow.Da.Domain.Achievement> AchievementList
        {
            set { achievementList = value; }
            get { return achievementList; }
        }
        private IList<Workflow.Da.Domain.Achievement> achievementTempList = new List<Workflow.Da.Domain.Achievement>();
        public IList<Workflow.Da.Domain.Achievement> AchievementTempList
        {
            set { achievementTempList = value; }
            get { return achievementTempList; }
        }

        private IList<Workflow.Da.Domain.Employee> employeeList = new List<Workflow.Da.Domain.Employee>();
        public IList<Workflow.Da.Domain.Employee> EmployeeList
        {
            set { employeeList = value; }
            get { return employeeList; }
        }
        private IList<Position> positionList=new List<Position>();
        public IList<Position> PositionList
        {
            set { positionList = value; }
            get { return positionList; }
        }
        private string beginDateTimeString;
        public string BeginDateTimeString
        {
            set { beginDateTimeString = value; }
            get { return beginDateTimeString; }
        }
        private string endDateTimeString;
        public string EndDateTimeString
        {
            set { endDateTimeString = value;}
            get { return endDateTimeString; }
        }
        private long positionId;
        public long PositionId
        {
            set { positionId = value; }
            get { return positionId; }
        }
        private long employeeId;
        public long EmployeeId
        {
            set { employeeId = value; }
            get { return employeeId; }
        }

        private decimal achievementValueTotal;
        public decimal AchievementValueTotal 
        {
            set { achievementValueTotal = value; }
            get { return achievementValueTotal; }
        }

        private decimal wastePaperTotal;
        public decimal WastePaperTotal 
        {
            set { wastePaperTotal = value; }
            get { return wastePaperTotal; }
        }
        #endregion

        #region 订单号

        private long orderId;
        /// <summary>
        /// 订单号
        /// </summary>
        public long OrderId
        {
            get { return orderId; }
            set { orderId = value; }
        }

        #endregion

        #region 订单号

        private string no;
        /// <summary>
        /// 订单号
        /// </summary>
        public string No
        {
            get { return no; }
            set { no = value; }
        }

        #endregion

        #region 顾客名称

        private string customerName;
        /// <summary>
        /// 顾客名称
        /// </summary>
        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }

        #endregion

        #region 项目名称

        private string projectName;
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjectName
        {
            get { return projectName; }
            set { projectName = value; }
        }

        #endregion

        #region 总金额

        private decimal sumMoney;
        /// <summary>
        /// 总金额
        /// </summary>
        public decimal SumMoney
        {
            get { return sumMoney; }
            set { sumMoney = value; }
        }

        #endregion

        #region MyRegion

        private IList<OrderItem> orderItemList;
        /// <summary>
        /// MyRegion
        /// </summary>
        public IList<OrderItem> OrderItemList
        {
            get { return orderItemList; }
            set { orderItemList = value; }
        }

        #endregion
    }
}
