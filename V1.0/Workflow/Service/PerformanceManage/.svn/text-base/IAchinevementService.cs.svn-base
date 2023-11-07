using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using System.Collections;
namespace Workflow.Service
{
    public interface IAchinevementService
    {
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
        void AdjustAchievement(IList<Workflow.Da.Domain.Achievement> achievementList);
       

        /// <summary>
        /// 更新业绩数据
        /// </summary>
        /// <remarks>
        /// 作    者: 陈汝胤
        /// 创建时间: 2009-1-6
        /// 修正履历: 张晓林
        /// 修正时间: 2009年5月9日13:26:17
        /// 修正描述：同时更新工单明细信息
        /// </remarks>
        void UpdateAchievementInit(IList<Workflow.Da.Domain.Achievement> achievementList, IList<Employee> employeeList);

        /// <summary>
        /// 更新Achievement
        /// </summary>
        /// <remarks>
        /// 作    者: 陈汝胤
        /// 创建时间: 2009-1-6
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        void UpdateAchievement(Workflow.Da.Domain.Achievement achievementObj);

        /// <summary>
        /// 更新工单制作人员
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月7日11:55:31
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        void UpdateOrdersPerson(IList<Employee> employeeList);
    }
}
