using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Workflow.Da;
using Workflow.Da.Domain;


namespace Workflow.Service.OrderManage
{
    /// <summary>
    /// ��    ��: SearchOrderServiceImpl
    /// ���ܸ�Ҫ: ���������ж�����ѯ��Service
    /// ��    ��: ��ǿ
    /// ����ʱ��: 2009-1-19
    /// ��������: 
    /// ����ʱ��: 
    /// </summary>
    public class SearchOrderServiceImpl : ISearchOrderService
    {

        #region ���Ա
        private IOrderDao orderDao;
        public IOrderDao OrderDao
        {
            set { orderDao = value; }
        }
        #endregion

        #region ������ѯ

        /// <summary>
        /// ��    ��: SearchOrdersInfo
        /// ���ܸ�Ҫ: ������ѯ
        /// ��    ��: ��ΰ
        /// ����ʱ��: 2007-10-8
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// 
        public IList<Order> SearchOrdersInfo(System.Collections.Hashtable condition)
        {

            return orderDao.SearchOrdersInfo(condition);
        }
        /// <summary>
        /// ��    ��: SearchOrdersInfoNo
        /// ���ܸ�Ҫ: ������ѯ(��������)
        /// ��    ��: ��ΰ
        /// ����ʱ��: 2007-10-8
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="condition">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IList<Order> SearchOrdersPrint(System.Collections.Hashtable condition)
        {
            return orderDao.SearchOrdersInfoPrint(condition);
        }
        /// <summary>
        /// ��    ��: SearchDelivery
        /// ���ܸ�Ҫ: ͨ�������Ų�ѯ�ͻ���
        /// ��    ��: ��ΰ
        /// ����ʱ��: 2007-10-9
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="NO"></param>
        /// <returns></returns>
        public string SearchDelivery(string NO)
        {
            return orderDao.SearchDelivery(NO);
        }
        /// <summary>
        /// ��    ��: GetSearchOrderInfoCount
        /// ���ܸ�Ҫ: ��ѯ���������Ķ�������
        /// ��    ��: ��ΰ
        /// ����ʱ��: 2007-10-9
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="condition">��ѯ����</param>
        /// <returns>���������Ķ�������</returns>
        public long GetSearchOrderInfoCount(Hashtable condition)
        {
            //int SelectId = Convert.ToInt32(condition["SelectCondition"]);
            //switch (SelectId)
            //{
            //    case 0:
            //        {
            //            condition["SelectCondition"] = "<";
            //            break;
            //        }
            //    case 1:
            //        {
            //            condition["SelectCondition"] = "<=";
            //            break;
            //        }
            //    case 2:
            //        {
            //            condition["SelectCondition"] = "=";
            //            break;
            //        }
            //    case 3:
            //        {
            //            condition["SelectCondition"] = ">=";
            //            break;
            //        }
            //    case 4:
            //        {
            //            condition["SelectCondition"] = ">";
            //            break;
            //        }
            //}
            return orderDao.GetSearchOrderInfoCount(condition);
        }
        #endregion

		#region ��ȡ�����б�ͨ������״̬

		/// <summary>
		/// ��ȡ�����б�ͨ������״̬
		/// </summary>
		/// <returns>OrderList</returns>
		/// <remarks>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009.4.23
		/// </remarks>
		public IList<Order> GetOrderListByStatus(Hashtable map)
		{
			return orderDao.GetOrderListByStatus(map);
		}

		#endregion
	}
}
