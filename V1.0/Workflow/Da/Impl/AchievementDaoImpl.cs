using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;
using Workflow.Support;
using System.Collections;
/// <summary>
/// ��    ��: AchievementDaoImpl
/// ���ܸ�Ҫ: ��Ч����ӿ�IAchievementDaoʵ����
/// ��    ��: 
/// ����ʱ��: 
/// ��������: ������
/// ����ʱ��: 2009-02-07
///             ��������
/// </summary>
namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table ACHIEVEMENT ��Ӧ��Dao ʵ��
	/// </summary>
    public class AchievementDaoImpl : Workflow.Da.Base.DaoBaseImpl<Achievement>, IAchievementDao
    {
        #region //ҵ������
        /// <summary>
        /// ҵ������ ɾ����ҵ��
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-11-2
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        public void DeleteAchievementByOrdersId(Achievement achievement)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            achievement.CompanyId = user.CompanyId;
            achievement.BranchShopId = user.BranchShopId;
            base.sqlMap.Delete("Achievement.DeleteAchievementByOrdersId", achievement);
        }
        #endregion

        #region //ҵ����ѯ
        /// <summary>
        /// ҵ����ѯ(��ҳ)
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-11-3
        /// ��������:
        /// ����ʱ��:2009��1��5��10:04:15
        /// </remarks>
        public IList<Achievement> SearchAchievement(Hashtable achievement)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            achievement.Add("CompanyId",user.CompanyId);
            achievement.Add("BranchShopId", user.BranchShopId);
            achievement.Add("Status", Workflow.Support.Constants.ORDER_STATUS_SUCCESSED_VALUE);
            achievement.Add("NewOrderName", "PROCESS_CONTENT");//��ȡ�ӹ�����
            return base.sqlMap.QueryForList<Achievement>("Achievement.SearchAchievement", achievement);

        }

        /// <summary>
        /// ҵ����ѯ�ܼ�¼��
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��1��5��10:05:52
        /// ��������:
        /// ����ʱ��:
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
        /// ҵ����ѯ(��ӡ)
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��1��5��10:05:52
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        public IList<Achievement> SearchAchievementPrint(Hashtable achievement) 
        {
            try
            {
                User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
                achievement.Add("CompanyId", user.CompanyId);
                achievement.Add("BranchShopId", user.BranchShopId);
                achievement.Add("Status", Workflow.Support.Constants.ORDER_STATUS_SUCCESSED_VALUE);
                achievement.Add("NewOrderName", "PROCESS_CONTENT");//��ȡ�ӹ�����
                return base.sqlMap.QueryForList<Achievement>("Achievement.SelectAchievementPrint", achievement);
            }
            catch(Exception ex)
            {
                throw ex;
                
            }
        }
        #endregion

        #region //����ҵ��ͳ��
        /// <summary>
        /// ����ҵ��ͳ��(��ҳ)
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-11-3
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        public IList<Achievement> GetAchievementCount(Hashtable achievement)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            achievement.Add("CompanyId", user.CompanyId);
            achievement.Add("BranchShopId", user.BranchShopId);
            return sqlMap.QueryForList<Achievement>("Achievement.GetOrderAchievementCount", achievement);
        }
        /// <summary>
        /// ����ҵ��ͳ���ܼ�¼��
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009-1-6
        /// ��������:
        /// ����ʱ��:2009��1��6��11:06:17
        /// </remarks>
        public long GetAchievementCountTotal(Hashtable achievement) 
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            achievement.Add("CompanyId", user.CompanyId);
            achievement.Add("BranchShopId", user.BranchShopId);
            return sqlMap.QueryForObject<long>("Achievement.GetOrderAchievementCountTotal", achievement);
        }

        /// <summary>
        /// ����ҵ��ͳ��(��ӡ)
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009-1-6
        /// ��������:
        /// ����ʱ��:2009��1��6��11:06:17
        /// </remarks>
        public IList<Achievement> GetAchievementCountPrint(Hashtable achievement) 
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            achievement.Add("CompanyId", user.CompanyId);
            achievement.Add("BranchShopId", user.BranchShopId);
            return sqlMap.QueryForList<Achievement>("Achievement.GetOrderAchievementPrint", achievement);
        }
        #endregion

        #region //Ա��ҵ��ͳ��
        /// <summary>
        /// Ա��ҵ��ͳ��(��ҳ)
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-11-3
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        public IList<Achievement> GetCustomerAchievementCount(Hashtable achievement)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            achievement.Add("CompanyId", user.CompanyId);
            achievement.Add("BranchShopId", user.BranchShopId);
            return sqlMap.QueryForList<Achievement>("Achievement.SelectCustomerAchievementCount", achievement);
        }
        /// <summary>
        /// Ա��ҵ��ͳ���ܼ�¼��
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��1��7��
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        public long GetCustomerAchievementCountTotal(Hashtable achievement) 
        {
            //User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            //achievement.Add("CompanyId", user.CompanyId);
            //achievement.Add("BranchShopId", user.BranchShopId);
            return sqlMap.QueryForObject<long>("Achievement.SelectCustomerAchievementCountTotal", achievement);
        }

        /// <summary>
        /// Ա��ҵ��ͳ��(��ӡ)
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��1��7��
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        public IList<Achievement> GetCustomerAchievementCountPrint(Hashtable achievement) 
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            achievement.Add("CompanyId", user.CompanyId);
            achievement.Add("BranchShopId", user.BranchShopId);
            return sqlMap.QueryForList<Achievement>("Achievement.SelectCustomerAchievementCountPrint", achievement);
        }
        #endregion

        #region //Ա��ҵ������
        /// <summary>
        /// Ա��ҵ������
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-11-��
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        public IList<Achievement> GetCustomerAchievementDetail(Hashtable achievement)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            achievement.Add("CompanyId", user.CompanyId);
            achievement.Add("BranchShopId", user.BranchShopId);
            return sqlMap.QueryForList<Achievement>("Achievement.SelectCustomerAchievementDetail", achievement);
        }

        /// <summary>
        /// Ա��ҵ�������¼��
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ������
        /// ��������:2009��4��23��11:25:25
        /// ����ʱ��:
        /// </remarks>
        public long GetCustomerAchievementDetailRowCount(Hashtable achievement)
        {
            return sqlMap.QueryForObject<long>("Achievement.GetCustomerAchievementDetailRowCount", achievement);
        }

        /// <summary>
        /// Ա��ҵ������(���)
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��4��23��11:25:35
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        public IList<Achievement> GetCustomerAchievementDetailPrint(Hashtable achievement)
        {
            return sqlMap.QueryForList<Achievement>("Achievement.GetCustomerAchievementDetailPrint", achievement);
        }
        #endregion

        #region ��ȡҵ������ͨ��������ϸ�͹͹�id

        /// <summary>
        /// ��ȡҵ������ͨ��������ϸ�͹͹�id
        /// </summary>
        /// <remarks>
        /// ��    ��: ����ط
        /// ����ʱ��: 2009-1-6
        /// ��������:
        /// ����ʱ��:
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
        /// ����OrderIdɾ��ҵ��
        /// </summary>
        /// <param name="orderId"></param>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��9��16:00:10
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        public void DeleteAchievement(long orderId) 
        {
            Achievement achievement = new Achievement();
            achievement.OrdersId = orderId;
            achievement.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            achievement.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            achievement.InsertUser = Convert.ToInt64(Constants.POSITION_PROPHASE_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId));//ǰ��
            achievement.UpdateUser = Convert.ToInt64(Constants.POSITION_ANAPHASE_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId));//��ӹ�
            sqlMap.Delete("Achievement.DeleteAchievement", achievement);
        }

        /// <summary>
        /// ��ȡԱ����ҵ����Ϣ
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��9��17:06:39
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        public Achievement GetOrderAchievementInfoByOrderIdOrEmployeeId(Hashtable condition)
        {
            condition.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            condition.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);            
            return sqlMap.QueryForObject<Achievement>("Achievement.GetOrderAchievementInfoByOrderIdOrEmployeeId", condition);
        }


        /// <summary>
        /// ���ݹ����Ż�ȡǰ�ںͺ�ӹ����������Ĺ�����ϸ��Ϣ
        /// </summary>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��11��13:41:37
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        public IList<OrderItem> GetOrderItemByOrderNo(string orderNo) 
        {
            OrderItem orderItem = new OrderItem();
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            orderItem.BranchShopId = user.BranchShopId;
            orderItem.CompanyId = user.CompanyId;
            orderItem.Values = orderNo;
            orderItem.InsertUser = Convert.ToInt64(Constants.POSITION_PROPHASE_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId));//ǰ��
            orderItem.UpdateUser = Convert.ToInt64(Constants.POSITION_ANAPHASE_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId));//��ӹ�
            return base.sqlMap.QueryForList<OrderItem>("OrderItem.GetOrderItemByOrderNo", orderItem);
        }

        /// <summary>
        /// �곤����Чͳ��
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��23��14:33:36
        /// ��������:
        /// ����ʱ��:
        ///</remarks>
        public IList<Achievement> SearchAchievementByShoperAndManager(Achievement achievement) 
        {
            achievement.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            achievement.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            achievement.PositionId = Constants.POSITION_SHOP_MASTER_VALUE(ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);//�곤
            achievement.UpdateUser = Convert.ToInt64(Constants.POSITION_MANAGER_VALUE(ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId));//����
            return base.sqlMap.QueryForList<Achievement>("Achievement.SearchAchievementByShoperAndManager", achievement);
        }
    }
}
