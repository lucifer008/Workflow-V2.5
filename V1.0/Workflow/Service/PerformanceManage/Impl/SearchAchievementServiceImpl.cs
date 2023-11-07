using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Workflow.Da;
using Workflow.Da.Domain;
namespace Workflow.Service.Impl
{
    public class SearchAchievementServiceImpl : ISearchAchievementService
    {
        #region //����ע��Dao

        private IAchievementDao achievementDao;
        public IAchievementDao AchievementDao
        {
            set { achievementDao = value; }
            get { return achievementDao; }
        }
        private IEmployeeDao employeeDao;
        public IEmployeeDao EmployeeDao
        {
            set { employeeDao = value; }
            get { return employeeDao; }
        }
        private IPositionDao positionDao;
        public IPositionDao PositionDao
        {
            set { positionDao = value; }
            get { return positionDao; }
        }
        #endregion

        /// <summary>
        /// ���Ա���б�
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-11-2
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        public IList<Employee> GetEmployeeList()
        {
            return employeeDao.GetEmployeeList();
        }
        /// <summary>
        /// ��ò����б�
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-11-2
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        public IList<Position> GetPositionList()
        {
            return positionDao.SelectAll();
        }
        /// <summary>
        /// ҵ����ѯ
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-11-3
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        public IList<Achievement> SearchAchievement(Hashtable achievement)
        {
            return achievementDao.SearchAchievement(achievement);
        }
        /// <summary>
        /// ҵ��ͳ���ܼ�¼��
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
            return achievementDao.SearchAchievementRowCount(achievement);
        }

        /// <summary>
        /// ҵ��ͳ��(��ӡ)
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
            return achievementDao.SearchAchievementPrint(achievement);
        }

        /// <summary>
        /// ����ҵ��ͳ��
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
            return achievementDao.GetAchievementCount(achievement);
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
            return achievementDao.GetAchievementCountTotal(achievement);
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
            return achievementDao.GetAchievementCountPrint(achievement);
        }

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
            return achievementDao.GetCustomerAchievementCount(achievement);
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
            return achievementDao.GetCustomerAchievementCountTotal(achievement);
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
            return achievementDao.GetCustomerAchievementCountPrint(achievement);
        }
        /// <summary>
        /// Ա��ҵ������
        /// </summary>.
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-11-3
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        public IList<Achievement> GetCustomerAchievementDetail(Hashtable achievement)
        {
            return achievementDao.GetCustomerAchievementDetail(achievement);
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
            return achievementDao.GetCustomerAchievementDetailRowCount(achievement);
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
            return achievementDao.GetCustomerAchievementDetailPrint(achievement);
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
            return achievementDao.GetOrderAchievementInfoByOrderIdOrEmployeeId(condition);
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
            return achievementDao.GetOrderItemByOrderNo(orderNo);
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
            return achievementDao.SearchAchievementByShoperAndManager(achievement);
        }
    }
}
