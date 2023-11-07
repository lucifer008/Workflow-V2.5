using System;
using Workflow.Service;
using Workflow.Action.Model;

namespace Workflow.Action
{
    /// <summary>
    /// 名    称:HandOverQueryAction
    /// 功能概要:交班查询Action
    /// 作    者:
    /// 创建时间:
    /// 修正履历:
    /// 修正时间：
    /// </summary>
    public class HandOverQueryAction : BaseAction
    {
        #region //ClassMember

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
        //交班Model
        private HandOverQueryModel model = new HandOverQueryModel();
        public HandOverQueryModel Model
        {
            get { return model; }
        }

        #endregion

        #region //初始化数据

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <remarks>
        /// 作    者:张晓林
        /// 创建时间:2009年3月26日9:57:47
        /// 修正履历:
        /// 修正时间：
        /// 修正描述:
        /// </remarks>
        public virtual void InitData()
        {
            //职员一览
            model.EmployeeList = handOverService.GetHandOverEmployeeList();
            //职位一览
            model.PositionList = handOverService.GetHandOverPositionList();
        }

        #endregion

        #region //查询交班信息

        /// <summary>
        /// 查询交班信息
        /// </summary>
        /// <remarks>
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-11
        /// 修正履历: 张晓林
        /// 修正时间:2009年3月26日9:54:02
        /// 修正描述:修改查询功能
        /// </remarks>
        public virtual void SearchHandOver()
        {
            model.HandOverList = handOverService.SearhHandOver(model.HandOver);
        }

        /// <summary>
        /// 获取交班信息记录数
        /// </summary>
        /// <remarks>
        /// 作    者:张晓林
        /// 创建时间:2009年3月26日9:57:47
        /// 修正履历:
        /// 修正时间：
        /// 修正描述:
        /// </remarks>
        public virtual long SearchHandOverRowCount() 
        {
            return handOverService.SearchHandOverRowCount(model.HandOver); 
        }

        /// <summary>
        /// 获取前台交班的会员卡信息
        /// </summary>
        /// <remarks>
        /// 作    者:张晓林
        /// 创建时间:2009年3月26日9:57:47
        /// 修正履历:
        /// 修正时间：
        /// 修正描述:
        /// </remarks>
        public virtual void GetHandOverMemberCard() 
        {
            model.MemberCardList = handOverService.GetHandOverMemberCard(model.HandOver);
        }

         /// <summary>
        /// 获取前台交班的工单信息
        /// </summary>
        /// <remarks>
        /// 作    者:张晓林
        /// 创建时间:2009年3月26日9:57:47
        /// 修正履历:
        /// 修正时间：
        /// 修正描述:
        /// </remarks>
        public virtual void GetHandOverOrders() 
        {
            model.OrderList = handOverService.GetHandOverOrders(model.HandOver);
        }

        /// <summary>
        /// 获取收银交班的款项详情
        /// </summary>
        /// <remarks>
        /// 作    者:张晓林
        /// 创建时间:2009年3月26日9:57:47
        /// 修正履历:
        /// 修正时间：
        /// 修正描述:
        /// </remarks>
        public virtual void GetFundDetail()
        {
            model.OrderList = handOverService.GetHandOverPreMoneyInfo(model.HandOver);
            model.CashHandOver = handOverService.GetHandOverOtherFundInfo(model.HandOver);
        }
        #endregion
    }
}
