using System;
using System.Text;
using System.Collections.Generic;
using Workflow.Service;
using Workflow.Action;
using Workflow.Support;
using System.Collections;
using Workflow.Da.Domain;
using Workflow.Action.Model;
using Workflow.Service.OrderManage;
using Workflow.Service.CustomerManager;
using Workflow.Action.Achievement.Model;
/// <summary>
/// 名    称: AdjustAchievementAction
/// 功能概要: 绩效调整的Action
/// 作    者: 付强
/// 创建时间: 2008-11-02
/// 修正履历: 张晓林
/// 修正时间: 2009-02-01
///             调整代码结构
/// </summary>
namespace Workflow.Action.Achievement
{
    public class AdjustAchievementAction:BaseAction
    {

        #region //ClassMember
        private AdjustAchievementModel model = new AdjustAchievementModel();
        public AdjustAchievementModel Model
        {
            set { model = value; }
            get { return model; }
        }
        private IAchinevementService achievementService;
        public IAchinevementService AchievementService
        {
            set { achievementService = value; }
            get { return achievementService; }
        }
        #endregion

        #region  //绩效调整

        /// <summary>
        /// 业绩调整
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-11-2
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public virtual void AdjustAchievement()
        {
            achievementService.AdjustAchievement(model.AchievementList);
        }
        #endregion

        #region //更新正确的员工业绩
        /// <summary>
        /// 更新正确的员工业绩
        /// </summary>
        /// <remarks>
        /// 作    者: 陈汝胤
        /// 创建时间: 2009-1-6
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public void UpdateJustAchievement()
        {
            achievementService.UpdateAchievementInit(model.AchievementList,model.EmployeeList);
        }
        #endregion

        #region//更新工单制作人员
        /// <summary>
        /// 更新工单制作人员
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月7日11:55:31
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public void UpdateOrdersPerson() 
        {
            achievementService.UpdateOrdersPerson(model.EmployeeList);
        }
        #endregion
    }
}
