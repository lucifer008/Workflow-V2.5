using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da;
using Workflow.Support;
using Workflow.Service;
using Workflow.Da.Domain;
using Workflow.Da.Support;
using System.Collections;

namespace Workflow.Da.Impl
{
    /// <summary>
    /// ��    ��: OrderDaoImpl
    /// ���ܸ�Ҫ: ����Dao
    /// ��    ��: ��ǿ
    /// ����ʱ��: 
    /// ��������: ������
    /// ����ʱ��: 2009-02-06
    ///             ��������
    /// </summary>
    public class OrderDaoImpl : Workflow.Da.Base.DaoBaseImpl<Order>, IOrderDao
    {

         #region IOrderDao ��Ա

        public IList<Order> SelectDailyOrder(Order order)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            order.BranchShopId = user.BranchShopId;
            order.CompanyId = user.CompanyId;
            return base.sqlMap.QueryForList<Order>("Order.SelectDailyOrder", order);  
        }

        /// <summary>
        /// ����ҳ�ı��ն���
        /// ��ǿ
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public IList<Order> SelectDailyOrderPager(Order order)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            order.BranchShopId = user.BranchShopId;
            order.CompanyId = user.CompanyId;
            return base.sqlMap.QueryForList<Order>("Order.SelectDailyOrderPager", order);  

        }

        /// <summary>
        /// ��ȡ���ն�������
        /// ��ǿ
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public int GetDailyOrderCount(Order order)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            order.BranchShopId = user.BranchShopId;
            order.CompanyId = user.CompanyId;
            return (int)base.sqlMap.QueryForObject("Order.GetDailyOrderCount",order);

        }

        public void UpdateOrderStatusByOrderNo(Order order)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            order.BranchShopId = user.BranchShopId;
            order.CompanyId = user.CompanyId;
            base.sqlMap.Update("Order.UpdateTheOrderStatusToFacturing", order);
        }

        public void UpdatePrepayOrder(Order order)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            order.BranchShopId = user.BranchShopId;
            order.CompanyId = user.CompanyId;
            base.sqlMap.Update("Order.UpdatePrepayOrder", order);

        }

        public long SelectOrderIdByOrderNo(string strOrderNo)
        {
            Order order = new Order();
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            order.BranchShopId = user.BranchShopId;
            order.CompanyId = user.CompanyId;
            order.No = strOrderNo;
            Object obj=base.sqlMap.QueryForObject("Order.SelectOrderIdByOrderNo", order);
            if (null != obj)
            {
                return Int64.Parse(obj.ToString());
            }
            else
            {
                return -1;//û���ҵ�
            }
        }

        /// <summary>
        /// ��ȡ������ʵ����Ԥ����
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public decimal GetPrePayAmount(Order order)
        {
            return sqlMap.QueryForObject<decimal>("Order.GetPrePayAmount", order);

        }

        public void InsertOrder(Order order)
        {
            //lock (this)
            //{
            //    if (idGeneratorSupport == null)
            //    {
            //        idGeneratorSupport = (IdGeneratorSupport)springContext.GetObject("idGeneratorSupport");
            //    }
            //    order.Id = idGeneratorSupport.NextId(typeof(Order));
            //    order.No = noGenerator.GetOrderNo(order.Id);

            //}
            order.InsertDateTime = DateTime.Now;
            order.InsertUser = ThreadLocalUtils.CurrentUserContext.CurrentUser.Id;
            order.UpdateDateTime = DateTime.Now;
            order.UpdateUser = ThreadLocalUtils.CurrentUserContext.CurrentUser.Id;
            order.Version = 1;
            order.Deleted = '0';
            order.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            order.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            
            sqlMap.Insert("Order.InsertOrder", order);
        }

        public void UpdateOrder(Order order)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            order.UpdateUser= user.Id;
            order.UpdateDateTime = DateTime.Now;
            sqlMap.Update("Order.UpdateOrder", order);
        }

        public Order SelectOrderInfoByOrderId(long orderId)
        {
            Order order = new Order();
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            order.BranchShopId = user.BranchShopId;
            order.CompanyId = user.CompanyId;
            order.Id = orderId;
            return base.sqlMap.QueryForObject<Order>("Order.SelectOrderInfoByOrderId", order);
        }

        #region �ϲ��ͻ�ʱ����Orders�е�CustomerId
        /// <summary>
        /// �ϲ��ͻ�:�����ϲ��Ŀͻ����ѵĶ�����ӵ� �ºϲ��Ŀͻ�������
        /// </summary>
        /// <param name="linkman"></param>
        /// <remarks>
        ///  ��   �ߣ�
        ///  ����ʱ��:
        ///  ����������
        ///  ����ʱ��:
        /// </remarks>
        public void UpdateConbinationCustomerId(System.Collections.Hashtable linkman)
        {
            sqlMap.Update("Order.ConbinationUpdateCustomerId", linkman);
        }
        #endregion

        #region ������ѯ(��������)
        /// <summary>
        /// ������ѯ(��ҳ)
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IList<Order> SearchOrdersInfo(Hashtable condition)
        {
            condition.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            condition.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            condition.Add("POSITION_CASHER_VALUE", Constants.POSITION_CASHER_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId));
            condition.Add("Status", Constants.ORDER_STATUS_SUCCESSED_VALUE);//����״̬��Ϊ����ɵ�
            return sqlMap.QueryForList<Order>("Order.SearchOrdersInfo", condition);
        }

        /// <summary>
        /// ������ѯ����ӡ���ݣ�
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IList<Order> SearchOrdersInfoPrint(Hashtable condition)
        {
            return sqlMap.QueryForList<Order>("Order.SearchOrdersInfoPrint", condition); 
        }
        /// <summary>
        /// ��ȡ������ѯ��¼��
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public long GetSearchOrderInfoCount(Hashtable condition)
        {
            return (long)sqlMap.QueryForObject("Order.GetSearchOrderInfoCount", condition);
        }
        public long GetCustomerCount(Hashtable condition)
        {
            condition.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            condition.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            return (long)sqlMap.QueryForObject("Customer.GetCustomerCount", condition);
        }
        #endregion

		#region ������ѯ(�����ѯ)
		public IList<Order> SearchOrdersItem(Hashtable condition)
		{
			return sqlMap.QueryForList<Order>("Order.SelectOrdersItem", condition);
		}

		public int SearchOrdersItemCount(Hashtable condition)
		{
			return sqlMap.QueryForObject<int>("Order.SearchOrdersItemCount", condition);
		}

		public Order SearchOrdersItemAmount(Hashtable condition)
		{
			return sqlMap.QueryForObject<Order>("Order.SearchOrdersItemAmount", condition);
		}

		#endregion


        #region ͨ�������Ų�ѯ�ͻ���
        public string SearchDelivery(string NO)
        {
            Employee ep = new Employee();
            ep.No = NO;
            ep.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            ep.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            object obj = sqlMap.QueryForObject("Order.SelectDelivery", ep);
            return (string)obj;
        }
        #endregion

        #region ͨ��CustomerId��ѯ��Orders�е���
        /// <summary>
        /// ͨ��CustomerId��ѯ��Orders�е���
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-10-11
        /// ��������: ������
        /// ����ʱ��: 2009��2��13��
        /// ��������: ��Ӳ�ѯ���� ��˾�ͷֵ�      
        /// </remarks>
        public int SearchCustomerInOrder(long Id)
        {
            Hashtable condition = new Hashtable();
            condition.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            condition.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            condition.Add("CustomerId", Id);
            object obj = sqlMap.QueryForObject("Order.SelectCustomerInOrder", condition);

            return (int)obj;
        }
        #endregion

        /// <summary>
        /// ǰ̨����ʱ�Ӷ������ݳ�ȡ
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ���ٻ�
        /// ����ʱ��: 2007-10-13
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        public IList<Order> SelectStageHandOverOrder()
        {
            return sqlMap.QueryForList<Order>("Order.SelectStageHandOverOrder", null);
        }

        /// <summary>
        /// ǰ̨����ʱ�Ӷ������ݳ�ȡ2008-11-04
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: �쾲��
        /// ����ʱ��: 2008-11-04
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        public IList<Order> SelectFrontHandOverOrder(System.Collections.Hashtable condition)
        {
            //condition.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            //condition.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            return sqlMap.QueryForList<Order>("Order.SelectFrontHandOverOrder", condition);
        }

        /// <summary>
        /// ��������ʱ�Ӷ������ݳ�ȡ
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ���ٻ�
        /// ����ʱ��: 2007-10-13
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        public IList<Order> SelectCashHandOverOrder(Hashtable condition)
        {
            condition.Add("Status1", Constants.ORDER_STATUS_BLANKOUT_VALUE);//�ų����Ѿ����ϵĶ���
            condition.Add("PayType5", Workflow.Support.Constants.PAY_KIND_PREPAY_VALUE);
            condition.Add("PayType2", Constants.PAY_KIND_USE_PREPAY_VALUE);//Ԥ������
            return sqlMap.QueryForList<Order>("Order.SelectCashHandOverOrder", condition);
        }
        #endregion

        #region //���ҵȴ�����Ķ���

        /// <summary>
        /// ���ҵȴ�����Ķ���
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-10-16
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        public IList<Order> SelectUnClosedOrder(Order order)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            order.BranchShopId = user.BranchShopId;
            order.CompanyId = user.CompanyId;
            return sqlMap.QueryForList<Order>("Order.SelectUnClosedOrder", order);
        }
   
        /// <summary>
        /// ���ҵȴ�����Ķ���
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2008-11-24
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        public int SelectUnClosedOrderCount(Order order)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            order.BranchShopId = user.BranchShopId;
            order.CompanyId = user.CompanyId;
            return (int)sqlMap.QueryForObject("Order.SelectUnClosedOrderCount", order);
        }
        /// <summary>
        /// ͨ����Ա���Ų鶩����
        /// </summary>
        /// <param name="strMemberCardNo">��Ա����</param>
        /// <remarks>
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2010-1-26
        /// ��������:
        /// ����ʱ��:
        /// </remarks>	
        public string GetOrderNoByMemberCardNo(string strMemberCardNo)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            Order order = new Order();
            order.BranchShopId = user.BranchShopId;
            order.CompanyId = user.CompanyId;
            order.MemberCardNo = strMemberCardNo;
            return (string)sqlMap.QueryForObject("Order.GetOrderNoByMemberCardNo", order);
        }
        /// <summary>
        /// ͨ�����ֺ����ѯ�ͻ�ID
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// ��    �ߣ���ǿ
        /// ����ʱ��: 2010-1-8
        /// </remarks>
        public long GetCustomerIdByNo(Order order)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            order.BranchShopId = user.BranchShopId;
            order.CompanyId = user.CompanyId;
            object result=sqlMap.QueryForObject("Order.GetCustomerIdByNo", order);
            long customerId = -1;
            if (null!=result)
            {
                long.TryParse(result.ToString(), out customerId);
            }
            return customerId;
        }
        #endregion

        #region //����ʱ�޸Ķ���
        /// <summary>
        /// ����ʱ�޸Ķ���
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-10-17
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        public void UpdateOrderForClose(Order order)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            order.BranchShopId = user.BranchShopId;
            order.CompanyId = user.CompanyId;
            order.UpdateDateTime = DateTime.Now;
            order.UpdateUser = user.Id;
            sqlMap.Update("Order.UpdateOrderForClose", order);
        }
        #endregion

        #region //������Ƿ��Ķ���
        /// <summary>
        /// ������Ƿ��Ķ���
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-10-17
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        public IList<Order> SelectNotHaveBeenPaidOrder(Order order)
        {
            return sqlMap.QueryForList<Order>("Order.SelectNotHaveBeenPaidOrder", order);
        }
        #endregion


        #region //��Ӧ�տ�ʱ���¶�����
        /// <summary>
        /// ��Ӧ�տ�ʱ���¶�����
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-10-17
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        public void UpdateOrderForArearage(Order order)
        {
            sqlMap.Update("Order.UpdateOrderForArearage", order);
        }
        #endregion

        #region //�����Ա����ˢ������
        /// <summary>
        /// ͳ�ƻ�Ա��ˢ������
        /// </summary>
        /// <param name="MemberCardNo"></param>
        /// <returns></returns>
        public int SelectMemberCardBrushNumber(string MemberCardNo)
        {
            Hashtable condition = new Hashtable();
            condition.Add("BranchShopId",ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            condition.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            condition.Add("MemberCardNo",MemberCardNo);
            return sqlMap.QueryForObject<int>("MemberCard.SelectMemberCardBrushNumber", condition);
        }
        #endregion

        #region //���ݲ�ѯ������ȡ���䶩����Ϣ
        /// <summary>
        /// ���ݲ�ѯ������ȡ���䶩����Ϣ
        /// </summary>
        /// <remarks>
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-10-24
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        public IList<Order> GetAnalyzeDebt(Order order)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            order.BranchShopId = user.BranchShopId;
            order.CompanyId = user.CompanyId;
            return sqlMap.QueryForList<Order>("Order.AnalyzeDebtTime", order);
        }
        #endregion

        #region //���ݲ�ѯ������ȡ���䶩����Ϣ
        /// <summary>
        /// ���ݲ�ѯ������ȡ���䶩����Ϣ
        /// </summary>
        /// <remarks>
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-10-24
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        public IList<Order> GetAnalyzeAssistantDebt(Order order)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            order.BranchShopId = user.BranchShopId;
            order.CompanyId = user.CompanyId;
            return sqlMap.QueryForList<Order>("Order.AnalyzeAssistantDebtTime", order);
        }
        #endregion

		#region �ͻ����Ѳ�ѯ

		/// <summary>
		/// ��ȡĳ��ʱ�������пͻ����������
		/// </summary>
		/// <remarks>
		/// ��    ��: ��ǿ
		/// ����ʱ��: 2007-10-24
		/// ��������: 
		/// ����ʱ��:
		/// </remarks>
		public IList<Order> GetCustomerConsume(Order order)
		{
			User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
			order.BranchShopId = user.BranchShopId;
			order.CompanyId = user.CompanyId;
			order.Status = Constants.ORDER_STATUS_SUCCESSED_VALUE;
			return sqlMap.QueryForList<Order>("Order.SelectCustomerConsume", order);
		}

		/// <summary>
		/// ��ȡ�ͻ����Ѽ�¼��
		/// </summary>
		/// <param name="order"></param>
		/// <returns></returns>
		/// <remarks>
		/// ��    ��: ����ط
		/// ����ʱ��: 2007-10-24
		/// </remarks>
		public int GetCustomerConsumeCount(Order order)
		{
			User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
			order.BranchShopId = user.BranchShopId;
			order.CompanyId = user.CompanyId;
			order.Status = Constants.ORDER_STATUS_SUCCESSED_VALUE;
			return sqlMap.QueryForObject<int>("Order.SelectCustomerConsumeCount", order);
		}

		public Order GetCustomerConsumeAmount(Order order)
		{
			User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
			order.BranchShopId = user.BranchShopId;
			order.CompanyId = user.CompanyId;
			order.Status = Constants.ORDER_STATUS_SUCCESSED_VALUE;
			return sqlMap.QueryForObject<Order>("Order.SelectCustomerConsumeAmount", order);
		}

		#endregion

        #region //�ͻ����ʱ�Ŀͻ���Ϣ
        /// <summary>
        /// �ͻ����ʱ�Ŀͻ���Ϣ
        /// </summary>
        /// <remarks>
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-10-27
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        public IList<Order> GetCustomerHistory(Order order)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            order.BranchShopId = user.BranchShopId;
            order.CompanyId = user.CompanyId;
            return sqlMap.QueryForList<Order>("Order.SelectCustomerHistory", order);
        }

        #endregion

		#region //�ͻ����ʱ�Ķ�����Ϣ
		/// <summary>
		/// �ͻ����ʱ�Ķ�����Ϣ
		/// </summary>
		/// <remarks>
		/// ��    ��: ��ǿ
		/// ����ʱ��: 2007-10-27
		/// ��������: ����ط
		/// ����ʱ��: 2010.01.14
		/// </remarks>
		public IList<Order> GetCustomerOrdersHistory(string memberCardNo, string customerName, int beginRow, int endRow)
		{
			Hashtable map = new Hashtable();
			map.Add("beginRow", beginRow);
			map.Add("endRow", endRow);
			map.Add("memberCardNo", memberCardNo);
			map.Add("customerName", customerName);
			map.Add("orderStatus", Constants.ORDER_STATUS_SUCCESSED_VALUE);
			map.Add("payKind1", Constants.PAY_KIND_PREPAY_VALUE);
			map.Add("payKind2", Constants.PAY_KIND_RETURN_VALUE);
			map.Add("payKind3", Constants.PAY_KIND_INVALIDATE_VALUE);
			map.Add("concessionType1", Constants.CONCESSION_TYPE_ZERO_VALUE);
			map.Add("concessionType2", Constants.CONCESSION_TYPE_CONCESSION_VALUE);
			map.Add("concessionType3", Constants.CONCESSION_TYPE_RENDERUP_VALUE);
			map.Add("concessionType4", Constants.CONCESSION_TYPE_ROUND_NEGTIVE_VALUE);
			map.Add("concessionType5", Constants.CONCESSION_TYPE_ROUND_POSITIVE_VALUE);
			User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
			map.Add("branchShopId", user.BranchShopId);
			map.Add("companyId", user.CompanyId);
			return sqlMap.QueryForList<Order>("Order.SelectCustomerOrdersHistory", map);
		}

		public Order GetCustomerOrderHistoryTotalize(string memberCardNo, string customerName)
		{
			Hashtable map = new Hashtable();
			map.Add("memberCardNo", memberCardNo);
			map.Add("customerName", customerName);
			map.Add("orderStatus", Constants.ORDER_STATUS_SUCCESSED_VALUE);
			map.Add("payKind1", Constants.PAY_KIND_PREPAY_VALUE);
			map.Add("payKind2", Constants.PAY_KIND_RETURN_VALUE);
			map.Add("payKind3", Constants.PAY_KIND_INVALIDATE_VALUE);
			map.Add("concessionType1", Constants.CONCESSION_TYPE_ZERO_VALUE);
			map.Add("concessionType2", Constants.CONCESSION_TYPE_CONCESSION_VALUE);
			map.Add("concessionType3", Constants.CONCESSION_TYPE_RENDERUP_VALUE);
			map.Add("concessionType4", Constants.CONCESSION_TYPE_ROUND_NEGTIVE_VALUE);
			map.Add("concessionType5", Constants.CONCESSION_TYPE_ROUND_POSITIVE_VALUE);
			User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
			map.Add("branchShopId", user.BranchShopId);
			map.Add("companyId", user.CompanyId);
			return sqlMap.QueryForObject<Order>("Order.SelectCustomerOrdersHistoryTotalize", map);
		}

		public int GetCustomerOrdersHistoryCount(string memberCardNo, string customerName)
		{
			Hashtable map = new Hashtable();
			map.Add("memberCardNo", memberCardNo);
			map.Add("customerName", customerName);
			map.Add("orderStatus", Constants.ORDER_STATUS_SUCCESSED_VALUE);
			User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
			map.Add("branchShopId", user.BranchShopId);
			map.Add("companyId", user.CompanyId);
			return sqlMap.QueryForObject<int>("Order.SelectCustomerOrdersHistoryCount", map);
		}

		#endregion

        //#region //��Ա��������ͳ��
        ///// <summary>
        ///// ��Ա��������ͳ��
        ///// </summary>
        ///// <remarks>
        ///// ��    ��: ��ǿ
        ///// ����ʱ��: 2007-10-27
        ///// ��������: 
        ///// ����ʱ��:
        ///// </remarks>
        //public IList<Order> GetMemberCardConsume(Order order)
        //{
        //    User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
        //    order.BranchShopId = user.BranchShopId;
        //    order.CompanyId = user.CompanyId;
        //    return sqlMap.QueryForList<Order>("Order.SelectMemberCardConsume", order);
        //}
        //#endregion

        #region �쳣�۸񶩵�ͳ��
        /// <summary>
        /// �쳣�۸񶩵�ͳ��
        /// </summary>
        /// <remarks>
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-10-29
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        public IList<Order> GetExceptionPriceOrdes(Hashtable map)
        {
            return sqlMap.QueryForList<Order>("Order.ExceptionPriceOrders", map);
        }

		public int GetExceptionPriceOrdesCount(Hashtable map)
		{
			return sqlMap.QueryForObject<int>("Order.ExceptionPriceOrdesCount", map);
		}

		public Order GetExceptionPriceOrdesTotalize(Hashtable map)
		{
			return sqlMap.QueryForObject<Order>("Order.ExceptionPriceOrdesTotalize", map);
		}

        #endregion

        #region //���Ͽͻ�����ͳ��
        /// <summary>
        /// ���Ͽͻ�����ͳ��
        /// </summary>
        /// <remarks>
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-10-29
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        public IList<Order> GetNewAndOldCustomerConsumeCount(Hashtable map)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
			map.Add("branchShopId", user.BranchShopId);
			map.Add("companyId", user.CompanyId);
            return sqlMap.QueryForList<Order>("Order.SearchNewAndOldCusotmerConsumeCount", map);
        }
        #endregion

        #region //�쳣��Ա�ͻ�����ͳ��
        /// <summary>
        /// �쳣��Ա�ͻ�����ͳ��
        /// </summary>
        /// <remarks>
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-10-29
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        public IList<Order> GetExceptionMemberCustomerConsume(Order order)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            order.BranchShopId = user.BranchShopId;
            order.CompanyId = user.CompanyId;
            order.NewOrderName = Convert.ToString(Convert.ToDateTime(order.BalanceDateTimeString).AddYears(-1));
            order.CashName = Convert.ToString(Convert.ToDateTime(order.InsertDateTimeString).AddYears(-1));
            return sqlMap.QueryForList<Order>("Order.GetExceptionMemberCustomerConsume", order);
        }

        /// <summary>
        /// �쳣��Ա�ͻ�����ͳ�Ƽ�¼��
        /// </summary>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��12��21��9:47:19
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        public long GetExceptionMemberCustomerConsumeRowCount(Order order) 
        {
            return sqlMap.QueryForObject<long>("Order.GetExceptionMemberCustomerConsumeRowCount", order);
        }

        /// <summary>
        /// �쳣��Ա�ͻ�����ͳ���������
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2010��2��3��9:49:51
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        public IList<Order> GetExceptionMemberCustomerConsumePrint(Order order) 
        {
            return sqlMap.QueryForList<Order>("Order.GetExceptionMemberCustomerConsumePrint", order);
        }
        #endregion

        #region //�����ͻ�����ͳ��
        /// <summary>
        /// �����ͻ�����ͳ��
        /// </summary>
        /// <remarks>
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-10-29
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        public IList<Order> GetExceptionConsumeCustomer(Order order)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            order.BranchShopId = user.BranchShopId;
            order.CompanyId = user.CompanyId;
            order.NewOrderName = Convert.ToString(Convert.ToDateTime(order.BalanceDateTimeString).AddYears(-1));
            order.CashName = Convert.ToString(Convert.ToDateTime(order.InsertDateTimeString).AddYears(-1));
            return sqlMap.QueryForList<Order>("Customer.ExceptionConsumeCustomer", order);
        }
        /// <summary>
        /// �����ͻ�����ͳ�Ƽ�¼��
        /// </summary>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2010��2��23��14:48:09
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        public long GetExceptionConsumeCustomerRowCount(Order order) 
        {
            return sqlMap.QueryForObject<long>("Customer.GetExceptionConsumeCustomerRowCount", order);
        }

        /// <summary>
        /// �����ͻ�����ͳ���������
        /// </summary>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2010��2��23��14:47:37
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        public IList<Order> GetExceptionConsumeCustomerPrint(Order order) 
        {
            return sqlMap.QueryForList<Order>("Customer.GetExceptionConsumeCustomerPrint", order);
        }
        #endregion

        #region //��ȡ���в��붩����������Ա
        /// <summary>
        /// ��ȡ���в��붩����������Ա
        /// </summary>
        /// <remarks>
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-11-5
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        public IList<Order> GetOrderAllUserByOrdersId(Order order)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            order.BranchShopId = user.BranchShopId;
            order.CompanyId = user.CompanyId;
            return sqlMap.QueryForList<Order>("Order.SelectOrderAllUserByOrderId", order);
        }
        #endregion

        #region //��ȡ������������Ա
        /// <summary>
        /// ��ȡ������������Ա
        /// </summary>
        /// <remarks>
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-11-5
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        public IList<Order> GetOrderReceptionAndCashUserByOrderId(Order order)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            order.BranchShopId = user.BranchShopId;
            order.CompanyId = user.CompanyId;
            return sqlMap.QueryForList<Order>("Order.SelectOrderReceptionAndCashUserByOrderId", order);
        }
        #endregion

        #region //�����������
        /// <summary>
        /// ȡ��Ԥ������/����
        /// </summary>
        /// <param name="cashhandOver"></param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ���ٻ�
        /// ����ʱ��: 2007-10-25
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        public CashHandOver SelectDebtAmount(Hashtable condition)
        {
            condition.Add("PayType1", Constants.PAY_KIND_PREPAY_VALUE);//Ԥ����
            //condition.Add("PayType2",Constants.PAY_KIND_USE_PREPAY_VALUE);//Ԥ������
            return sqlMap.QueryForObject<CashHandOver>("Order.SelectDebtAmount", condition);
        }

        /// <summary>
        /// ȡ�ü��ʱ���/���ʽ��
        /// </summary>
        /// <param name="cashhandOver"></param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ���ٻ�
        /// ����ʱ��: 2007-10-25
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        public CashHandOver SelectKeepBusinessRecordAmount(Hashtable condition)
        {
            condition.Add("PayType", Constants.PAYMENT_TYPE_ACCOUNT_GET_VALUE);//ֻ���˼��˿ͻ�
            return sqlMap.QueryForObject<CashHandOver>("Order.SelectKeepBusinessRecordAmount", condition);
        }

        /// <summary>
        /// ȡ�÷�Ʊ����/��Ʊ���
        /// </summary>
        /// <param name="cashhandOver"></param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ���ٻ�
        /// ����ʱ��: 2007-10-25
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        public CashHandOver SelectTicketAmount(Hashtable condition)
        {
            condition.Add("Status2",Constants.ORDER_STATUS_SUCCESSED_VALUE);
            condition.Add("balanceTicket", Constants.BALANCE_TICKET_AMOUNT_KEY);
            return sqlMap.QueryForObject<CashHandOver>("Order.SelectTicketAmount", condition);
        }
		/// <summary>
		/// ��ѯ�ŵ�Ӫҵ��
		/// </summary>
		/// <param name="order"></param>
		/// <returns></returns>
		/// <remarks>
		/// ��    ��: ��ǿ
		/// ����ʱ��: 2007-10-26
		/// ��������: 
		/// ����ʱ��:
		/// </remarks>
		public IList<Order> SelectBranchShopTurnover(Order order)
		{
			User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
			order.BranchShopId = user.BranchShopId;
			order.CompanyId = user.CompanyId;
			return sqlMap.QueryForList<Order>("Order.SelectBranchShopTurnover", order);
		}

		public long GetOrderCount(Order order)
		{
			User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
			order.BranchShopId = user.BranchShopId;
			order.CompanyId = user.CompanyId;
			return sqlMap.QueryForObject<long>("Order.GetOrderCount", order);
		}

		#endregion

        #region //��ȡ������ҪԤ��������б�
        /// <summary>
        /// ��ȡ������ҪԤ��������б�
        /// </summary>
        /// <param name="iorder"></param>
        /// <returns></returns>
        public IList<Order> GetAllNeedPrePayOrders(Order iorder)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            iorder.BranchShopId = user.BranchShopId;
            iorder.CompanyId = user.CompanyId;
            iorder.Status = Constants.ORDER_STATUS_SUCCESSED_VALUE;
            iorder.Status1 = Constants.ORDER_STATUS_BLANKOUT_VALUE;
            return sqlMap.QueryForList<Order>("Order.SelectAllNeedPrePay", iorder);
        }
        #endregion

        #region //��ȡ������ҪԤ�����������
        /// <summary>
        /// ��ȡ������ҪԤ�����������
        /// </summary>
        /// <param name="iorder"></param>
        /// <returns></returns>
        public long GetAllNeedPrePayOrdersCount(Order iorder)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            iorder.BranchShopId = user.BranchShopId;
            iorder.CompanyId = user.CompanyId;
            iorder.Status = Constants.ORDER_STATUS_SUCCESSED_VALUE;
            iorder.Status1 = Constants.ORDER_STATUS_BLANKOUT_VALUE;
            return sqlMap.QueryForObject<int>("Order.SelectAllNeedPrePayCount", iorder);
        }

        /// <summary>
        /// �ϼƶ����ܽ���Ԥ�տ��ܽ��
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��4��11��9:03:24
        /// ��������: 
        /// ����ʱ��: 
        ///</remarks>
        public Order GetOrderPrepayAmountTotalAndSumAmountTotal(Order order) 
        {
            order.CompanyId=ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            order.BranchShopId=ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            order.Status = Constants.ORDER_STATUS_SUCCESSED_VALUE;
            order.Status1 = Constants.ORDER_STATUS_BLANKOUT_VALUE;
            return sqlMap.QueryForObject<Order>("Order.GetOrderPrepayAmountTotalAndSumAmountTotal",order);
        }
        #endregion

        #region //����ʱ���Ѿ�Ԥ�������order
        /// <summary>
        /// ����ʱ���Ѿ�Ԥ�������order
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public Order SelectOrderInfoByOrderIdPrePaid(long orderId)
        {
            return base.sqlMap.QueryForObject<Order>("Order.SelectByPk_PrePaid", orderId);
        }
        #endregion

        #region //Ӧ�տ�
        /// <summary>
        /// ��ѯӦ�տ�(��ҳ)
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-10-26
        /// ��������: ��Ф���ӷ�ҳ��
        /// ����ʱ��:2008-12-4
        /// </remarks>
        public IList<Order> SelectCustomerArrearage(Order order)
        {
            order.Status1 = int.Parse(Constants.CONCESSION_TYPE_ZERO_VALUE);
            order.Status2 = int.Parse(Constants.CONCESSION_TYPE_CONCESSION_VALUE);
            order.Status3 = int.Parse(Constants.CONCESSION_TYPE_RENDERUP_VALUE);
            order.Status4 = Convert.ToInt32(Constants.CONCESSION_TYPE_ROUND_NEGTIVE_VALUE);
            order.LastTelNo = Constants.PAY_KIND_CLOSED_VALUE;//�����
            order.LinkManName = Constants.PAY_KIND_USE_PREPAY_VALUE;//Ԥ������
            order.Memo = Constants.PAY_KIND_ARREARAGE_VALUE;//Ӧ�տ����
            order.OrderWorking = Constants.PAY_KIND_MEMBERCARD_DIFF_VALUE;//��Ա�����
            order.Address = Constants.PAY_KIND_USE_PRE_DEPOSITS_VALUE;//�ͻ�Ԥ�����(����)
            order.CashName = Constants.ACCOUNT_USE_PRE_DEPOSITS_VALUE;//�ͻ�Ԥ�����(Ӧ�տ��)
            order.OrderFinished = Constants.PAY_KIND_ORDER_DIFF_VALUE;//�������
            order.OrderNoDispatch = Constants.CONCESSION_TYPE_ROUND_POSITIVE_VALUE;//�������
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            order.BranchShopId = user.BranchShopId;
            order.CompanyId = user.CompanyId;
            order.PayType = Constants.PAYMENT_TYPE_ACCOUNT_GET_VALUE;
            return sqlMap.QueryForList<Order>("Order.SelectCustomerArrearage", order);
        }

        /// <summary>
        /// ��ѯӦ�տ���Ϣ��¼��
        /// </summary>
        /// <remarks>
        /// ��    ��: ��Ф
        /// ����ʱ��: 2008-12-4
        /// ��������: 
        /// ����ʱ��:
        /// </summary>
        /// <returns></returns>
        public long GetSelectCustomerArrearageCount(Order order)
        {
            order.Status1 = int.Parse(Constants.CONCESSION_TYPE_ZERO_VALUE);
            order.Status2 = int.Parse(Constants.CONCESSION_TYPE_CONCESSION_VALUE);
            order.Status3 = int.Parse(Constants.CONCESSION_TYPE_RENDERUP_VALUE);
            order.Status4 = Convert.ToInt32(Constants.CONCESSION_TYPE_ROUND_NEGTIVE_VALUE);
            order.LastTelNo = Constants.PAY_KIND_CLOSED_VALUE;//�����
            order.LinkManName = Constants.PAY_KIND_USE_PREPAY_VALUE;//Ԥ������
            order.Memo = Constants.PAY_KIND_ARREARAGE_VALUE;//Ӧ�տ����
            order.OrderWorking = Constants.PAY_KIND_MEMBERCARD_DIFF_VALUE;//��Ա�����
            order.Address = Constants.PAY_KIND_USE_PRE_DEPOSITS_VALUE;//�ͻ�Ԥ�����(����)
            order.CashName = Constants.ACCOUNT_USE_PRE_DEPOSITS_VALUE;//�ͻ�Ԥ�����(Ӧ�տ��)
            order.OrderFinished = Constants.PAY_KIND_ORDER_DIFF_VALUE;//�������
            order.OrderNoDispatch = Constants.CONCESSION_TYPE_ROUND_POSITIVE_VALUE;//�������
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            order.BranchShopId = user.BranchShopId;
            order.CompanyId = user.CompanyId;
            order.PayType = Constants.PAYMENT_TYPE_ACCOUNT_GET_VALUE;
            return sqlMap.QueryForObject<long>("Order.SelectCustomerArrearagePage", order);
        }

        /// <summary>
        /// ��ѯӦ�տ�(��ӡ����)
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-10-26
        /// ��������: ��Ф���ӷ�ҳ��
        /// ����ʱ��:2008-12-4
        /// </remarks>
        public IList<Order> GetaAllCustomerArrearage(Order order)
        {
            order.Status1 = int.Parse(Workflow.Support.Constants.CONCESSION_TYPE_ZERO_VALUE);
            order.Status2 = int.Parse(Workflow.Support.Constants.CONCESSION_TYPE_CONCESSION_VALUE);
            order.Status3 = int.Parse(Workflow.Support.Constants.CONCESSION_TYPE_RENDERUP_VALUE);
            order.Status4 = Convert.ToInt32(Constants.CONCESSION_TYPE_ROUND_NEGTIVE_VALUE);
            order.LastTelNo =Constants.PAY_KIND_CLOSED_VALUE;//�����
            order.LinkManName=Constants.PAY_KIND_USE_PREPAY_VALUE;//Ԥ������
            order.Memo = Constants.PAY_KIND_ARREARAGE_VALUE;//Ӧ�տ����
            order.OrderWorking = Constants.PAY_KIND_MEMBERCARD_DIFF_VALUE;//��Ա�����
            order.Address = Constants.PAY_KIND_USE_PRE_DEPOSITS_VALUE;//�ͻ�Ԥ�����
            order.CashName = Constants.ACCOUNT_USE_PRE_DEPOSITS_VALUE;//�ͻ�Ԥ�����(Ӧ�տ��)
            order.OrderFinished = Constants.PAY_KIND_ORDER_DIFF_VALUE;//�������
            order.OrderNoDispatch = Constants.CONCESSION_TYPE_ROUND_POSITIVE_VALUE;//�������
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            order.BranchShopId = user.BranchShopId;
            order.CompanyId = user.CompanyId;
            order.PayType = Constants.PAYMENT_TYPE_ACCOUNT_GET_VALUE;
            return sqlMap.QueryForList<Order>("Order.GetaAllCustomerArrearage", order);
        }
        #endregion

        #region //Ӧ�տ��ʱ��κϼ�
        /// <summary>
		/// Ӧ�տʱ��λ�ȡ��ѯ(��ҳ)
		/// </summary>
		/// <remarks>
		/// ��    ��: ������
		/// ����ʱ��: 2008-11-26
		/// ��������: 
		/// ����ʱ��:
		/// </remarks>
		public IList<Order> GetAccountReceviableAccordingToTimeSectTotal(Hashtable hashtable) 
		{
            hashtable.Add("Status1", Constants.CONCESSION_TYPE_ZERO_VALUE);
            hashtable.Add("Status2", Constants.CONCESSION_TYPE_CONCESSION_VALUE);
            hashtable.Add("Status3", Constants.CONCESSION_TYPE_RENDERUP_VALUE);
            hashtable.Add("Status4", Constants.CONCESSION_TYPE_ROUND_NEGTIVE_VALUE);
            hashtable.Add("PayTypeBalance", Constants.PAY_KIND_CLOSED_VALUE);//�����
            hashtable.Add("PayTypePreDiff", Constants.PAY_KIND_USE_PREPAY_VALUE);//Ԥ������
            hashtable.Add("PayTypeOwe", Constants.PAY_KIND_ARREARAGE_VALUE);//Ӧ�տ�
            hashtable.Add("PayTypeMemberCardDiff", Constants.PAY_KIND_MEMBERCARD_DIFF_VALUE);//��Ա�����
            hashtable.Add("PreDeposits", Constants.PAY_KIND_USE_PRE_DEPOSITS_VALUE);//�ͻ�Ԥ�����(����)
            hashtable.Add("AccountPreDepositsDiff",Constants.ACCOUNT_USE_PRE_DEPOSITS_VALUE);//�ͻ�Ԥ�����(Ӧ�տ��)
            hashtable.Add("Status5", Constants.CONCESSION_TYPE_ROUND_POSITIVE_VALUE);//�������
            hashtable.Add("PayTypeOrderDiff", Constants.PAY_KIND_ORDER_DIFF_VALUE);//�������
            hashtable.Add("PayType", Constants.PAYMENT_TYPE_ACCOUNT_GET_VALUE);//ֻ���˼��˿ͻ�
			return sqlMap.QueryForList<Order>("Order.SelectAccountReceviableAccordingToTimeSectTotal", hashtable);
		}
		/// <summary>
		/// ��ȡ Ӧ�տʱ���ͳ�Ƶĸ���
		/// </summary>
		/// <remarks>
		/// ��    ��: ������
		/// ����ʱ��: 2008-11-28
		/// ��������: 
		/// ����ʱ��:
		/// </remarks>
		public long GetSearchAccountReceviableInfoCount(Hashtable hashCondition) 
		{
            hashCondition.Add("Status1", Constants.CONCESSION_TYPE_ZERO_VALUE);
            hashCondition.Add("Status2", Constants.CONCESSION_TYPE_CONCESSION_VALUE);
            hashCondition.Add("Status3", Constants.CONCESSION_TYPE_RENDERUP_VALUE);
            hashCondition.Add("Status4", Constants.CONCESSION_TYPE_ROUND_NEGTIVE_VALUE);
            hashCondition.Add("PayTypeBalance", Constants.PAY_KIND_CLOSED_VALUE);//�����
            hashCondition.Add("PayTypePreDiff", Constants.PAY_KIND_USE_PREPAY_VALUE);//Ԥ������
            hashCondition.Add("PayTypeOwe", Constants.PAY_KIND_ARREARAGE_VALUE);//Ӧ�տ�
            hashCondition.Add("PayTypeMemberCardDiff", Constants.PAY_KIND_MEMBERCARD_DIFF_VALUE);//��Ա�����
            hashCondition.Add("PreDeposits", Constants.PAY_KIND_USE_PRE_DEPOSITS_VALUE);//�ͻ�Ԥ�����
            hashCondition.Add("AccountPreDepositsDiff", Constants.ACCOUNT_USE_PRE_DEPOSITS_VALUE);//�ͻ�Ԥ�����(Ӧ�տ��)
            hashCondition.Add("Status5", Constants.CONCESSION_TYPE_ROUND_POSITIVE_VALUE);//�������
            hashCondition.Add("PayTypeOrderDiff", Constants.PAY_KIND_ORDER_DIFF_VALUE);//�������
            hashCondition.Add("PayType", Constants.PAYMENT_TYPE_ACCOUNT_GET_VALUE);//ֻ���˼��˿ͻ�
			return sqlMap.QueryForObject<long>("Order.GetAccountRecivableTotalCount", hashCondition);
		}
		/// <summary>
		/// Ӧ�տʱ��λ�ȡ��Order(��ȡ��ӡ����)
		/// </summary>
		/// <remarks>
		/// ��    ��: ������
		/// ����ʱ��: 2008-11-29
		/// ��������: 
		/// ����ʱ��:
		/// </remarks>
		public IList<Order> GetAccountReceviableTotal(Hashtable hashCondition) 
		{
            hashCondition.Add("Status1", Workflow.Support.Constants.CONCESSION_TYPE_ZERO_VALUE);
            hashCondition.Add("Status2", Workflow.Support.Constants.CONCESSION_TYPE_CONCESSION_VALUE);
            hashCondition.Add("Status3", Workflow.Support.Constants.CONCESSION_TYPE_RENDERUP_VALUE);
            hashCondition.Add("Status4", Constants.CONCESSION_TYPE_ROUND_NEGTIVE_VALUE);
            hashCondition.Add("PayTypeBalance", Constants.PAY_KIND_CLOSED_VALUE);//�����
            hashCondition.Add("PayTypePreDiff", Constants.PAY_KIND_USE_PREPAY_VALUE);//Ԥ������
            hashCondition.Add("PayTypeOwe", Constants.PAY_KIND_ARREARAGE_VALUE);//Ӧ�տ�
            hashCondition.Add("PayTypeMemberCardDiff", Constants.PAY_KIND_MEMBERCARD_DIFF_VALUE);//��Ա�����
            hashCondition.Add("PreDeposits", Constants.PAY_KIND_USE_PRE_DEPOSITS_VALUE);//�ͻ�Ԥ�����
            hashCondition.Add("AccountPreDepositsDiff", Constants.ACCOUNT_USE_PRE_DEPOSITS_VALUE);//�ͻ�Ԥ�����(Ӧ�տ��)
            hashCondition.Add("Status5", Constants.CONCESSION_TYPE_ROUND_POSITIVE_VALUE);//�������
            hashCondition.Add("PayTypeOrderDiff", Constants.PAY_KIND_ORDER_DIFF_VALUE);//�������
            hashCondition.Add("PayType", Constants.PAYMENT_TYPE_ACCOUNT_GET_VALUE);//ֻ���˼��˿ͻ�
			return sqlMap.QueryForList<Order>("Order.SelectGetAccountRecivableTotal", hashCondition);
        }
        #endregion

        #region //�ձ�
        /// <summary>
		/// (�������ڲ�ѯ)�ձ�Order(��ҳ)
		/// </summary>
		/// <remarks>
		/// ��    ��: ������
		/// ����ʱ��: 2008-12-2
		/// ��������: 
		/// ����ʱ��:
		/// </remarks>
		public IList<Order> GetDailyPaper(Hashtable hashCondition)
		{
            return sqlMap.QueryForList<Order>("GatheringOrder.SelectDailyPaper", hashCondition);
		}

		/// <summary>
		/// (�������ڲ�ѯ)�ձ��ܼ�¼��
		/// </summary>
		/// <remarks>
		/// ��    ��: ������
		/// ����ʱ��: 2008-12-2
		/// ��������: 
		/// ����ʱ��:
		/// </remarks>
		public long GetDailyPaperTotal(Hashtable hashCondition) 
		{
            return sqlMap.QueryForObject<long>("GatheringOrder.SelectDailyPaperRowTotal", hashCondition);
		}

        /// <summary>
        /// (�������ڲ�ѯ)�ձ�(��ӡ)
        /// </summary>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2008-12-4
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        public IList<Order> GetDailyPaperPrint(Hashtable hashCondition)
        {
            return sqlMap.QueryForList<Order>("GatheringOrder.SelectDailyPaperPrint", hashCondition);
        }

        /// <summary>
        /// ͳ������������˰��
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��12��17��11:34:08
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        public decimal GetDailyScotAmount(Hashtable condition) 
        {
            return sqlMap.QueryForObject<decimal>("GatheringOrder.GetDailyScotAmount", condition);
        }
        #endregion

        #region //�±�
        ///// <summary>
        ///// (�����·ݲ�ѯ)�±�(��ҳ)
        ///// </summary>
        ///// <remarks>
        ///// ��    ��: ������
        ///// ����ʱ��: 2008-12-9
        ///// ��������: 
        ///// ����ʱ��:
        ///// </remarks>
        //public IList<Order> GetMonthPaper(Hashtable hashCondition) 
        //{
        //    return sqlMap.QueryForList<Order>("OrderItem.SelectMonthPaperPagination", hashCondition);
        //}

        /// <summary>
        /// (�����·ݲ�ѯ)�±�(��ӡ)
        /// </summary>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2008-12-9
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        public IList<Order> GetMonthPaperPrint(Hashtable hashCondition) 
        {
            return sqlMap.QueryForList<Order>("OrderItem.SelectMonthPaperPrint", hashCondition);
        }

        #endregion

		#region //��ѯ�ͻ�Ԥ�������
		/// <summary>
		/// ��ѯ�ͻ�Ԥ�������(��ҳ)
		/// </summary>
		/// <param name="order"></param>
		/// <returns></returns>
		/// <remarks>
		/// ��    ��: ��ǿ
		/// ����ʱ��: 2007-10-26
		/// ��������: 
		/// ����ʱ��:
		/// </remarks>
		public IList<Order> SelectCustomerPrepay(Order order)
		{
			User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
			order.BranchShopId = user.BranchShopId;
			order.CompanyId = user.CompanyId;
			order.StatusList.Add(Constants.ORDER_STATUS_SUCCESSED_VALUE.ToString());
			order.StatusList.Add(Constants.ORDER_STATUS_BLANKOUT_VALUE.ToString());
			order.PayType = int.Parse(Constants.PAY_KIND_PREPAY_VALUE);//Ԥ����
			return sqlMap.QueryForList<Order>("OrderItem.SelectCustomerPrepay", order);
		}
		/// <summary>
		/// ��ѯ�ͻ�Ԥ�������(��ӡ)
		/// </summary>
		/// <param name="order"></param>
		/// <returns></returns>
		/// <remarks>
		/// ��    ��: ������
		/// ����ʱ��: 2008-12-24
		/// ��������: 
		/// ����ʱ��:
		/// </remarks>
		public IList<Order> GetCustomerPrepayPrint(Order order)
		{
			User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
			order.BranchShopId = user.BranchShopId;
			order.CompanyId = user.CompanyId;
			order.Status = Constants.ORDER_STATUS_SUCCESSED_VALUE;
			order.Status1 = Constants.ORDER_STATUS_BLANKOUT_VALUE;
			order.PayType = int.Parse(Constants.PAY_KIND_PREPAY_VALUE);//Ԥ����
			return sqlMap.QueryForList<Order>("OrderItem.SelectCustomerPrepayPrint", order);
		}

		/// <summary>
		/// ��ѯ�ͻ�Ԥ������Ϣ���ܼ�¼��
		/// </summary>
		/// <param name="order"></param>
		/// <returns></returns>
		/// <remarks>
		/// ��    ��: ������
		/// ����ʱ��: 2008-12-24
		/// ��������: 
		/// ����ʱ��:
		/// </remarks>
		public int GetCustomerPrepayRowsCount(Order order)
		{
			User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
			order.BranchShopId = user.BranchShopId;
			order.CompanyId = user.CompanyId;
			order.StatusList.Add(Constants.ORDER_STATUS_SUCCESSED_VALUE.ToString());
			order.StatusList.Add(Constants.ORDER_STATUS_BLANKOUT_VALUE.ToString());
			order.PayType = int.Parse(Constants.PAY_KIND_PREPAY_VALUE);//Ԥ����
			return sqlMap.QueryForObject<int>("OrderItem.SelectCustomerPrepayRowsCount", order);
		}
		#endregion

        #region //���ն���Id��ѯ������Ϣ
        public Order SelectOrderByOrderNo(long orderId) 
        {
            Order order = new Order();
            order.Id = orderId;
            order.CompanyId=ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            order.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            order.Status = Constants.ORDER_STATUS_SUCCESSED_VALUE;
            order.Status1 = Constants.ORDER_STATUS_BLANKOUT_VALUE;
            return sqlMap.QueryForObject<Order>("Order.SelectOrderInfoByOrderNo", order);
        }
        #endregion

        #region //���ݶ����Ż�ȡ������
        /// <summary>
        ///���ݶ����Ż�ȡ������
        /// </summary>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        public string cashUserName(string orderNo)
        {
            Order order = new Order();
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            order.BranchShopId = user.BranchShopId;
            order.CompanyId = user.CompanyId;
            order.No = orderNo;
            order.Status = Constants.ORDER_STATUS_SUCCESSED_VALUE;
            order.Status1 = Constants.POSITION_CASHER_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId);//������Id
            return sqlMap.QueryForObject<string>("OrderItem.SelectCushUserNameByOrderNo", order);
        }
        #endregion

        #region //���ݿͻ����ƻ�ȡ�ͻ�Id
        /// <summary>
        /// ��    ��: GetCustomerIdByCustomerName
        /// ���ܸ�Ҫ: ���ݿͻ����ƻ�ȡ�ͻ�Id
        /// ��    ��: ������
        /// ����ʱ��: 2009��3��9��16:19:38
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public Customer GetCustomerInfoByName(string customerName)
        {
            Customer customer=new Customer();
            customer.CompanyId=ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            customer.BranchShopId=ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            customer.Name = customerName;
            return sqlMap.QueryForObject<Customer>("Customer.GetCustomerIdByCustomerName", customer);
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
			User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
			map.Add("companyid", user.CompanyId);
			map.Add("branchshopid", user.BranchShopId);
			return sqlMap.QueryForList<Order>("Order.GetOrderListByStatus", map);
		}

		#endregion


        /// <summary>
        /// ��    ��: GetCustomerPayTypeByCustomerId
        /// ���ܸ�Ҫ: ���ݿͻ�Id��ȡ�ͻ�֧����ʽ
        /// ��    ��: ������
        /// ����ʱ��: 2009��8��24��9:30:14
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public long GetCustomerPayTypeByCustomerId(long customerId) 
        {
            Customer customer = new Customer();
            customer.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            customer.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            customer.Id = customerId;
            return sqlMap.QueryForObject<long>("Customer.GetCustomerPayTypeByCustomerId", customer);
        }

        /// <summary>
        /// ���ض������ѵǼ�״̬
        /// </summary>
        /// <remarks>
        /// ����:������
        /// ����ʱ��:2009��10��12��10:57:17
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        public void UpdateOrderByReturnOrder(Order order) 
        {
            sqlMap.Update("Order.UpdateOrderByReturnOrder", order);
        }

        /// <summary>
        /// ȡ��Ƿ��Ʊ
        /// </summary>
        /// <param name="orderId"></param>
        /// <remarks>
        /// ��    ��:������
        /// ����ʱ��:2009��10��24��15:06:31
        /// ����������
        /// ����ʱ�䣺
        /// </remarks>
        public void CancelNotPaidTicket(Order order) 
        {
            order.BranchShopId = ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId;
            order.CompanyId = ThreadLocalUtils.CurrentSession.CurrentUser.CompanyId;
            sqlMap.Update("Order.CancelNotPaidTicket", order);
        }

        #region//��������
        /// <summary>
        /// ��    ��: GetAmendmentOrder
        /// ���ܸ�Ҫ: ��ȡҪ�����Ķ���
        /// ��    ��: ������
        /// ����ʱ��: 2009��11��17��13:10:40
        /// ��������:
        /// ����ʱ�䣺
        /// </summary>
        public Order GetAmendmentOrder(Order order) 
        {
            order.CompanyId=ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            order.BranchShopId=ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForObject<Order>("Order.GetAmendmentOrder", order);
        }

        /// <summary>
        /// �����Ѿ�����Ķ���
        /// </summary>
        /// <param name="order"></param>
        /// <remarks>
        /// ��    �ߣ�������
        /// ����ʱ��: 2009��11��19��9:22:24
        /// ����������
        /// ����ʱ��:
        /// </remarks>
        public void ReturnOrderForPay(Order order)
        {
            order.Status4 = Constants.INVALIDATE_KEY;//����˰�Ѽ�¼
            order.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            order.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            sqlMap.QueryForObject<long>("Order.ReturnOrderForPay", order);//���������ص�����ǰ��״̬
            sqlMap.QueryForObject<long>("Order.UpdateOrderForPayKind", order);//���ϸ�����ϸ,
            sqlMap.Update("Order.InvaliDatePayOrderScotRecord",order);
        }
        #endregion

		#region ��ȡ��Ҫ��������ж���


		public IList<Order> SelectNeedRecordMachineWatch(RecordMachineWatch lastRecordWath)
		{
			User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
			Hashtable map = new Hashtable();
			map.Add("companyid", user.CompanyId);
			map.Add("branchshopid", user.BranchShopId);
			if (lastRecordWath != null)
			{
				map.Add("dateTime", lastRecordWath.InsertDateTime);
			}
			return sqlMap.QueryForList<Order>("Order.SelectNeedRecordMachineWatch", map);
		}

		#endregion

		#region ��ȡ����

		public IList<Order> GetOrders(DateTime beginTime, DateTime endTime, int paymentType, int orderStatus, string userName)
		{
			Hashtable map = new Hashtable();
			map.Add("beginTime", beginTime);
			map.Add("endTime", endTime);
			map.Add("paymentType", paymentType);
			map.Add("orderStatus", orderStatus);
			User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
			map.Add("companyId", user.CompanyId);
			map.Add("branchShopId", user.BranchShopId);
			map.Add("userName", userName);
			map.Add("payKind", Constants.PAY_KIND_INVALIDATE_VALUE);
			return sqlMap.QueryForList<Order>("Order.GetOrders", map);
		}

		#endregion

        #region �����̶�������
        /// <summary>
        /// ��    ��: NewDispatchOrder
        /// ���ܸ�Ҫ: ������-���䶩��
        /// ��    ��: ������
        /// ����ʱ��: 2010��1��7��15:06:46
        /// ��������: 
        /// ����ʱ��: 
        /// </summary>
        public void NewDispatchOrder(Order order) 
        {
            sqlMap.Update("Order.NewDispatchOrder", order);
        }
        #endregion

        #region //������-������ӡ
        /// <summary>
        /// ��    ��: AdmendmentPrint
        /// ���ܸ�Ҫ: ������-������ӡ
        /// ��    ��: ������
        /// ����ʱ��: 2010��1��7��17:25:53
        /// ��������: 
        /// ����ʱ��: 
        /// </summary>
        public void AdmendmentPrint(Order order) 
        {
            sqlMap.Update("Order.AdmendmentPrint", order);
        }

        #endregion


        #region//������-���ض���
        /// <summary>
        /// ��    ��: ReturnOrder
        /// ���ܸ�Ҫ: ������-���ض���
        /// ��    ��: ������
        /// ����ʱ��: 2010��1��8��10:05:09
        /// ��������: 
        /// ����ʱ��: 
        /// </summary>
        public void ReturnOrder(Order order) 
        {
            sqlMap.Update("Order.AdmendmentPrint", order);
        }

        /// <summary>
        /// ��    ��: AddBarCodeToOrder
        /// ���ܸ�Ҫ: ������-�������������
        /// ��    ��: ������
        /// ����ʱ��: 2010��1��12��9:46:54
        /// ��������: 
        /// ����ʱ��: 
        /// </summary>
        public void AddBarCodeToOrder(Order order) 
        {
            sqlMap.Update("Order.AddBarCodeToOrder", order);
        }
        #endregion

		#region ��ȡ�ͻ������ж���


		public IList<Order> GetCustomerOrders(long customerId,int beginRow,int endRow)
		{
			Hashtable map = new Hashtable();
			map.Add("customerId", customerId);
			map.Add("status", Constants.ORDER_STATUS_SUCCESSED_VALUE);
			map.Add("beginRow", beginRow);
			map.Add("endRow", endRow);
			return sqlMap.QueryForList<Order>("Order.SelectCustomerOrders", map);
		}

		public int GetCustomerOrderCount(long customerId)
		{
			Hashtable map = new Hashtable();
			map.Add("customerId", customerId);
			map.Add("status", Constants.ORDER_STATUS_SUCCESSED_VALUE);
			return sqlMap.QueryForObject<int>("Order.SelectCustomerOrderCount", map);
		}

		#endregion
    }
}
