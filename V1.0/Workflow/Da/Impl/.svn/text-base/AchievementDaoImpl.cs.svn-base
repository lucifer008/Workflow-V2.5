using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;
using Workflow.Support;
using System.Collections;
/// <summary>
/// 名    称: AchievementDaoImpl
/// 功能概要: 绩效管理接口IAchievementDao实现类
/// 作    者: 
/// 创建时间: 
/// 修正履历: 张晓林
/// 修正时间: 2009-02-07
///             调整代码
/// </summary>
namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table ACHIEVEMENT 对应的Dao 实现
	/// </summary>
    public class AchievementDaoImpl : Workflow.Da.Base.DaoBaseImpl<Achievement>, IAchievementDao
    {
        #region //业绩调整
        /// <summary>
        /// 业绩调整 删除旧业绩
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-11-2
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public void DeleteAchievementByOrdersId(Achievement achievement)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            achievement.CompanyId = user.CompanyId;
            achievement.BranchShopId = user.BranchShopId;
            base.sqlMap.Delete("Achievement.DeleteAchievementByOrdersId", achievement);
        }
        #endregion

        #region //业绩查询
        /// <summary>
        /// 业绩查询(分页)
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-11-3
        /// 修正履历:
        /// 修正时间:2009年1月5日10:04:15
        /// </remarks>
        public IList<Achievement> SearchAchievement(Hashtable achievement)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            achievement.Add("CompanyId",user.CompanyId);
            achievement.Add("BranchShopId", user.BranchShopId);
            achievement.Add("Status", Workflow.Support.Constants.ORDER_STATUS_SUCCESSED_VALUE);
            achievement.Add("NewOrderName", "PROCESS_CONTENT");//获取加工内容
            return base.sqlMap.QueryForList<Achievement>("Achievement.SearchAchievement", achievement);

        }

        /// <summary>
        /// 业绩查询总记录数
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年1月5日10:05:52
        /// 修正履历:
        /// 修正时间:
        /// </remarks>

        public long SearchAchievementRowCount(Hashtable achievement)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            if (!achievement.Contains("CompanyId"))
            {
                achievement.Add("CompanyId", user.CompanyId);
            }
            if (!achievement.Contains("BranchShopId"))
            {
                achievement.Add("BranchShopId", user.BranchShopId);
            }
            if (!achievement.Contains("Status"))
            {
                achievement.Add("Status", Workflow.Support.Constants.ORDER_STATUS_SUCCESSED_VALUE);
            }
            return base.sqlMap.QueryForObject<long>("Achievement.SelectAchievementRowCount", achievement);
        }
        /// <summary>
        /// 业绩查询(打印)
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年1月5日10:05:52
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public IList<Achievement> SearchAchievementPrint(Hashtable achievement) 
        {
            try
            {
                User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
                achievement.Add("CompanyId", user.CompanyId);
                achievement.Add("BranchShopId", user.BranchShopId);
                achievement.Add("Status", Workflow.Support.Constants.ORDER_STATUS_SUCCESSED_VALUE);
                achievement.Add("NewOrderName", "PROCESS_CONTENT");//获取加工内容
                return base.sqlMap.QueryForList<Achievement>("Achievement.SelectAchievementPrint", achievement);
            }
            catch(Exception ex)
            {
                throw ex;
                
            }
        }
        #endregion

        #region //工单业绩统计
        /// <summary>
        /// 工单业绩统计(分页)
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-11-3
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public IList<Achievement> GetAchievementCount(Hashtable achievement)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            achievement.Add("CompanyId", user.CompanyId);
            achievement.Add("BranchShopId", user.BranchShopId);
            return sqlMap.QueryForList<Achievement>("Achievement.GetOrderAchievementCount", achievement);
        }
        /// <summary>
        /// 工单业绩统计总记录数
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009-1-6
        /// 修正履历:
        /// 修正时间:2009年1月6日11:06:17
        /// </remarks>
        public long GetAchievementCountTotal(Hashtable achievement) 
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            achievement.Add("CompanyId", user.CompanyId);
            achievement.Add("BranchShopId", user.BranchShopId);
            return sqlMap.QueryForObject<long>("Achievement.GetOrderAchievementCountTotal", achievement);
        }

        /// <summary>
        /// 工单业绩统计(打印)
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009-1-6
        /// 修正履历:
        /// 修正时间:2009年1月6日11:06:17
        /// </remarks>
        public IList<Achievement> GetAchievementCountPrint(Hashtable achievement) 
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            achievement.Add("CompanyId", user.CompanyId);
            achievement.Add("BranchShopId", user.BranchShopId);
            return sqlMap.QueryForList<Achievement>("Achievement.GetOrderAchievementPrint", achievement);
        }
        #endregion

        #region //员工业绩统计
        /// <summary>
        /// 员工业绩统计(分页)
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-11-3
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public IList<Achievement> GetCustomerAchievementCount(Hashtable achievement)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            achievement.Add("CompanyId", user.CompanyId);
            achievement.Add("BranchShopId", user.BranchShopId);
            return sqlMap.QueryForList<Achievement>("Achievement.SelectCustomerAchievementCount", achievement);
        }
        /// <summary>
        /// 员工业绩统计总记录数
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年1月7日
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public long GetCustomerAchievementCountTotal(Hashtable achievement) 
        {
            //User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            //achievement.Add("CompanyId", user.CompanyId);
            //achievement.Add("BranchShopId", user.BranchShopId);
            return sqlMap.QueryForObject<long>("Achievement.SelectCustomerAchievementCountTotal", achievement);
        }

        /// <summary>
        /// 员工业绩统计(打印)
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年1月7日
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public IList<Achievement> GetCustomerAchievementCountPrint(Hashtable achievement) 
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            achievement.Add("CompanyId", user.CompanyId);
            achievement.Add("BranchShopId", user.BranchShopId);
            return sqlMap.QueryForList<Achievement>("Achievement.SelectCustomerAchievementCountPrint", achievement);
        }
        #endregion

        #region //员工业绩详情
        /// <summary>
        /// 员工业绩详情
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-11-５
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public IList<Achievement> GetCustomerAchievementDetail(Hashtable achievement)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            achievement.Add("CompanyId", user.CompanyId);
            achievement.Add("BranchShopId", user.BranchShopId);
            return sqlMap.QueryForList<Achievement>("Achievement.SelectCustomerAchievementDetail", achievement);
        }

        /// <summary>
        /// 员工业绩详情记录数
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 修正履历:2009年4月23日11:25:25
        /// 修正时间:
        /// </remarks>
        public long GetCustomerAchievementDetailRowCount(Hashtable achievement)
        {
            return sqlMap.QueryForObject<long>("Achievement.GetCustomerAchievementDetailRowCount", achievement);
        }

        /// <summary>
        /// 员工业绩详情(输出)
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年4月23日11:25:35
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public IList<Achievement> GetCustomerAchievementDetailPrint(Hashtable achievement)
        {
            return sqlMap.QueryForList<Achievement>("Achievement.GetCustomerAchievementDetailPrint", achievement);
        }
        #endregion

        #region 获取业绩详情通过工单明细和雇工id

        /// <summary>
        /// 获取业绩详情通过工单明细和雇工id
        /// </summary>
        /// <remarks>
        /// 作    者: 陈汝胤
        /// 创建时间: 2009-1-6
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public Achievement GetAchievement(long orderItemId, long employeeId)
        {
            Hashtable map=new Hashtable();
            map.Add("orderItemid",orderItemId);
            map.Add("employeeid", employeeId);
            return sqlMap.QueryForObject<Achievement>("Achievement.GetAchievementById",map);
        }

        #endregion

        /// <summary>
        /// 根据OrderId删除业绩
        /// </summary>
        /// <param name="orderId"></param>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月9日16:00:10
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public void DeleteAchievement(long orderId) 
        {
            Achievement achievement = new Achievement();
            achievement.OrdersId = orderId;
            achievement.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            achievement.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            achievement.InsertUser = Convert.ToInt64(Constants.POSITION_PROPHASE_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId));//前期
            achievement.UpdateUser = Convert.ToInt64(Constants.POSITION_ANAPHASE_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId));//后加工
            sqlMap.Delete("Achievement.DeleteAchievement", achievement);
        }

        /// <summary>
        /// 获取员工的业绩信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月9日17:06:39
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public Achievement GetOrderAchievementInfoByOrderIdOrEmployeeId(Hashtable condition)
        {
            condition.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            condition.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);            
            return sqlMap.QueryForObject<Achievement>("Achievement.GetOrderAchievementInfoByOrderIdOrEmployeeId", condition);
        }


        /// <summary>
        /// 根据工单号获取前期和后加工参与制作的工单明细信息
        /// </summary>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月11日13:41:37
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public IList<OrderItem> GetOrderItemByOrderNo(string orderNo) 
        {
            OrderItem orderItem = new OrderItem();
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            orderItem.BranchShopId = user.BranchShopId;
            orderItem.CompanyId = user.CompanyId;
            orderItem.Values = orderNo;
            orderItem.InsertUser = Convert.ToInt64(Constants.POSITION_PROPHASE_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId));//前期
            orderItem.UpdateUser = Convert.ToInt64(Constants.POSITION_ANAPHASE_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId));//后加工
            return base.sqlMap.QueryForList<OrderItem>("OrderItem.GetOrderItemByOrderNo", orderItem);
        }

        /// <summary>
        /// 店长经理绩效统计
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月23日14:33:36
        /// 修正履历:
        /// 修正时间:
        ///</remarks>
        public IList<Achievement> SearchAchievementByShoperAndManager(Achievement achievement) 
        {
            achievement.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            achievement.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            achievement.PositionId = Constants.POSITION_SHOP_MASTER_VALUE(ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);//店长
            achievement.UpdateUser = Convert.ToInt64(Constants.POSITION_MANAGER_VALUE(ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId));//经理
            return base.sqlMap.QueryForList<Achievement>("Achievement.SearchAchievementByShoperAndManager", achievement);
        }
    }
}
