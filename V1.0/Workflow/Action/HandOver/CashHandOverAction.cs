﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Common.Logging;
using Workflow.Service;
using Workflow.Da.Domain;
using Workflow.Action.Model;
using Workflow.Support.Exception;
using Workflow.Service.OrderManage;

namespace Workflow.Action
{

    /// <summary>
    //// 名    称:CashHandOverAction
    //// 功能概要:收银交班Action
    /// 作    者:
    /// 创建时间:
    /// 修正履历:
    /// 修正时间:
    /// </summary>
    public class CashHandOverAction : BaseAction
    {
       
        #region //成员变量定义
        private static readonly ILog LOG = LogManager.GetLogger(typeof(CashHandOverAction));
        //交班管理
        private IHandOverService handOverService;
        public IHandOverService HandOverService
        {
            set { handOverService = value; }
        }

        //基本信息管理
        private IMasterDataService masterDataService;
        public IMasterDataService MasterDataService
        {
            set { masterDataService = value; }
        }

        //工单管理
        private IOrderService orderService;
        public IOrderService OrderService
        {
            set { orderService = value; }
        }

        //收银交班Model
        private CashHandOverModel model = new CashHandOverModel();
        public CashHandOverModel Model
        {
            get { return model; }
        }
        #endregion

        #region//初始化数据
        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <remarks>
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-10
        /// 修正履历:张晓林
        /// 修正时间:2009年3月21日17:38:09
        /// 修正描述:按照交班的起始时间与当前用户统计交班数据信息
        /// </remarks>
        public virtual void InitData(Hashtable condition)
        {
            //初始化职员
            model.EmployeeList = handOverService.GetHandOverEmployeeList();
            //初始化加工单信息(含有预付款的工单明细)
            model.OrderList = handOverService.GetCashHandOverOrderList(condition);

            model.CashHandOver = new CashHandOver();
            CashHandOver cashHandOverResult =new CashHandOver();
            
            //发票金额
            cashHandOverResult = handOverService.GetTicketAmount(condition);
             model.CashHandOver.TicketAmountSum = cashHandOverResult.TicketAmountSum;//发票金额合计
             model.CashHandOver.TicketCount = cashHandOverResult.TicketCount;//发票笔数
            //结款金额
            cashHandOverResult = handOverService.GetPayForAmount(condition);
            model.CashHandOver.PayForAmountSum = cashHandOverResult.PayForAmountSum;
            //结款笔数
            model.CashHandOver.PayForCount = cashHandOverResult.PayForCount;
            //预付定金
            //cashHandOverResult = handOverService.GetDebtAmount(condition);
            //model.CashHandOver.PrepayMoneySum = cashHandOverResult.DebtAmountSum;

            //记帐合计
            cashHandOverResult = handOverService.GetKeepBusinessRecordAmount(condition);
            model.CashHandOver.KeepBusinessRecordAmountSum = cashHandOverResult.KeepBusinessRecordAmountSum;
            //记帐笔数
            model.CashHandOver.KeepBusinessRecordCount = cashHandOverResult.KeepBusinessRecordCount;

            //欠条金额
            cashHandOverResult = new CashHandOver();//handOverService.GetDebtAmount(null);
            model.CashHandOver.DebtAmountSum = 2000;//cashHandOverResult.DebtAmountSum;
            //欠条笔数
            model.CashHandOver.DebtCount = 10;//cashHandOverResult.DebtCount;
            //现金合计
            model.CashHandOver.CashAmount = model.CashHandOver.PayForAmountSum + cashHandOverResult.DebtAmountSum;
            //备用金
            model.CashHandOver.StandbyAmount=2000;
        }
        #endregion

        /// <summary>
        /// 保存交班信息
        /// </summary>
        /// <param name="model"></param>
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-09
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public virtual long SaveHandOver(CashHandOverModel model)
        {
            try
            {
                handOverService.InsertCashHandOver(model.HandOver, model.CashHandOver, model.CashHandOverOrderList);
            }
            catch (WorkflowException ex)
            {
                LOG.Error("", ex);
            }
            return model.HandOver.Id;
        }

        /// <summary>
        /// 获取收银交班的上次交班时间
        /// </summary>
        /// <param name="model"></param>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年3月21日17:28:48
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public string CashHandOverDateTime 
        {
            get { return handOverService.Cash_Work_Start_Time(); }
        }

        /// <summary>
        /// 按照日期获取该日期内最早交班的时间
        /// </summary>
        /// <param name="model"></param>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年3月27日16:57:44
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public string DailyPaperMinHandOverDateTime 
        {
            get
            {
                string handOverDataTime=handOverService.DailyPaperMinHandOverDateTime(model.HandOverDateTime);
                if (null != handOverDataTime)
                {
                    return handOverDataTime;
                }
                return model.HandOverDateTime;
            }
        }

        /// <summary>
        /// 按照月份获取本月最早交班的时间
        /// </summary>
        /// <param name="model"></param>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年3月30日9:33:32
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public HandOver MonthPaperMinHandOverDateTime
        {
            get { return handOverService.MonthPaperMinHandOverDateTime(model.HandOverDateTime); }
        }
    }
}
