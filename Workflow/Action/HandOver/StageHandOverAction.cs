using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Common.Logging;
using Workflow.Service;
using Workflow.Support;
using Workflow.Support.Log;
using Workflow.Action.Model;
using Workflow.Support.Exception;
using Workflow.Service.OrderManage;
using Workflow.Service.MemberCardManager;
namespace Workflow.Action
{
    /// <summary>
    ////名    称:StageHandOverAction
    ////功能概要:前台交班Action
    /// 作    者:
    /// 创建时间:
    /// 修正履历:
    /// 修正时间:
    /// </summary>
    public class StageHandOverAction : BaseAction
    {
        //private static readonly ILog LOG = LogManager.GetLogger(typeof(StageHandOverAction));

        #region 成员变量的定义

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

        //订单管理
        private IOrderService orderService;
        public IOrderService OrderService
        {
            set { orderService = value; }
        }

        //会员卡管理
        private ISearchMemberCardService searchMemberCardService;
        public ISearchMemberCardService SearchMemberCardService
        {
            set { searchMemberCardService = value; }
        }

        //前台交班Model
        private StageHandOverModel model = new StageHandOverModel();
        public StageHandOverModel Model
        {
            get { return model; }
        }

        
        #endregion

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-09
        /// 修正履历: 
        /// 修正时间:
        public virtual void InitData()
        { 
            //初始化职员
            model.EmployeeList = masterDataService.GetEmployeeList();
            //初始化当日交班信息
            //初始化新办会员卡信息
            model.MemberCardList = searchMemberCardService.GetTodayNewMemberCardList();
            //初始化加订单信息
            model.OrderList = handOverService.GetStageHandOverOrderList();

        }


        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="condition">按指定条件初始化</param>
        /// 作    者: 朱静程
        /// 创建时间: 2008-11-04
        /// 修正履历: 
        /// 修正时间:
        public virtual void InitData(System.Collections.Hashtable condition)
        { 
            //初始化职员
            model.EmployeeList = handOverService.GetHandOverEmployeeList();
            //初始化当日交班信息
            //初始化新办会员卡信息
            model.MemberCardList = searchMemberCardService.GetSomeNewMemberCardList(condition); // .GetTodayNewMemberCardList();
            //初始化加订单信息
            model.OrderList = handOverService.GetFrontHandOverOrderList(condition); 
        
        }

        /// <summary>
        /// 保存交班信息
        /// </summary>
        /// <param name="model"></param>
        /// <remarks>
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-09
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public virtual long SaveHandOver(StageHandOverModel model)
        {
            try
            {
                handOverService.InsertHandOver(model.HandOver, model.HandOverMemberCardList, model.HandOverOrderList);
            }
            catch (WorkflowException ex)
            {
                LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            }

            return model.HandOver.Id;
        }

        /// <summary>
        /// 名    称:Work_Start_Time
        /// 功能概要:获取前台交班时间
        /// 作    者:
        /// 创建时间:
        /// 修正履历:张晓林
        /// 修正时间:2009年3月21日15:08:08
        /// 修正描述:获取上一次交班的时间
        /// </summary>
        /// <returns></returns>
        public string Stage_Work_Start_Time
        {
            get { return handOverService.Stage_Work_Start_Time(); }
        }

        /// <summary>
        /// 名    称:LastHandOverId
        /// 功能概要:获取当前用户为接班人的最近的交班Id
        /// 作    者:张晓林
        /// 创建时间:2009年4月12日17:37:16
        /// 修正时间:
        /// 修正履历:
        /// 修正描述:
        /// </summary>
        /// 
        public long LastHandOverId 
        {
            get { return handOverService.LastHandOverId(); }
        }
    }
}
