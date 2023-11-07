using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using System.Collections;
namespace Workflow.Da
{
    /// <summary>
    /// ��    ��: IOrderDao
    /// ���ܸ�Ҫ: ����Dao�ӿ�
    /// ��    ��: ��ǿ
    /// ����ʱ��: 
    /// ��������: ������
    /// ����ʱ��: 2009-02-07
    ///             ��������
    /// </summary>
    public interface IOrderDao : IDaoBase<Order>
    {
        /// <summary>
        /// ѡ��δ��������ж���
        /// ��ǿ
        /// </summary>
        /// <returns></returns>
        IList<Order> SelectDailyOrder(Order order);

        /// <summary>
        /// ѡ��δ��������ж��� ����ҳ
        /// ��ǿ
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        IList<Order> SelectDailyOrderPager(Order order);

        /// <summary>
        /// ��ȡ������ʵ����Ԥ����
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        decimal GetPrePayAmount(Order order);

        void InsertOrder(Order order);

        void UpdateOrder(Order order);
        /// <summary>
        /// ��ȡ���ն�������
        /// ��ǿ
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        int GetDailyOrderCount(Order order);
        /// <summary>
        /// ���Ķ���״̬Ϊ������
        /// ��ǿ
        /// </summary>
        /// <param name="strOrderNo"></param>
        void UpdateOrderStatusByOrderNo(Order order);

        void UpdatePrepayOrder(Order order);

        long SelectOrderIdByOrderNo(string OrderNo);

        Order SelectOrderInfoByOrderId(long orderId);
        /// <summary>
        /// ��    ��: UpdateConbinationCustomerId
        /// ���ܸ�Ҫ: �ϲ��ͻ�:�����ϲ��ͻ�����ϵ����ӵ��¿ͻ�������
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-9-28
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="linkman"></param>
        /// <returns></returns>
        ///
        void UpdateConbinationCustomerId(System.Collections.Hashtable linkman);

        #region //���ն���-������ѯ
        /// <summary>
        /// ������ѯ
        /// </summary>
        /// <param name="condition">��ѯ����</param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-10-8
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        IList<Order> SearchOrdersInfoPrint(Hashtable condition);
        long GetSearchOrderInfoCount(Hashtable condition);
        IList<Order> SearchOrdersInfo(Hashtable condition);
        #endregion

        #region //��������ͳ��

        //IList<Order> SearchOrdersInfoNo(System.Collections.Hashtable condition);
		/// <summary>
		/// ������ѯ(�������)
		/// </summary>
		/// <param name="condition">��ѯ����</param>
		/// <returns></returns>
		/// <remarks>
		/// ��    ��: liuwei
		/// ����ʱ��: 2007-10-25
		/// ��������:
		/// ����ʱ��:
		/// </remarks>
		IList<Order> SearchOrdersItem(Hashtable condition);

		int SearchOrdersItemCount(Hashtable condition);

		Order SearchOrdersItemAmount(Hashtable condition);

		#endregion

        /// <summary>
        /// ͨ�������Ų�ѯ�ͻ���
        /// </summary>
        /// <param name="condition">��ѯ����</param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-10-8
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        string SearchDelivery(string NO);
        /// <summary>
        /// ͨ��CustomerId��ѯ��Orders�е���
        /// </summary>
        /// <param name="Id">CustoemrId</param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-10-11
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        int SearchCustomerInOrder(long Id);
        
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
        IList<Order> SelectStageHandOverOrder();


        /// <summary>
        /// ��������ʱ�䣩��ǰ̨����ʱ�Ӷ������ݳ�ȡ
        /// </summary>
        /// <param name="condition">��ѯ����</param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: �쾲��
        /// ����ʱ��: 2008-11-04
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        IList<Order> SelectFrontHandOverOrder(System.Collections.Hashtable condition);

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
        IList<Order> SelectCashHandOverOrder(Hashtable condition);
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
        IList<Order> SelectUnClosedOrder(Order order);
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
        int SelectUnClosedOrderCount(Order order);
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
        string GetOrderNoByMemberCardNo(string strMemberCardNo);
        /// <summary>
        /// ͨ�����ֺ����ѯ�ͻ�ID
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// ��    �ߣ���ǿ
        /// ����ʱ��: 2010-1-8
        /// </remarks>
        long GetCustomerIdByNo(Order order);
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
        void UpdateOrderForClose(Order order);
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
        IList<Order> SelectNotHaveBeenPaidOrder(Order order);

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
        void UpdateOrderForArearage(Order order);
        /// <summary>
        /// �����Ա����ˢ������
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ��ΰ
        /// ����ʱ��: 2007-10-23
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        int SelectMemberCardBrushNumber(string MemberCardNo);
        /// <summary>
        /// ���ݲ�ѯ������ȡ���䶩����Ϣ
        /// </summary>
        /// <remarks>
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-10-24
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        IList<Order> GetAnalyzeDebt(Order order);
        /// <summary>
        /// ���ݲ�ѯ������ȡ���䶩����Ϣ
        /// </summary>
        /// <remarks>
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-10-24
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        IList<Order> GetAnalyzeAssistantDebt(Order order);

		#region �ͻ��������

		/// <summary>
		/// ��ȡĳ��ʱ�������пͻ����������
		/// </summary>
		/// <remarks>
		/// ��    ��: ��ǿ
		/// ����ʱ��: 2007-10-24
		/// ��������: 
		/// ����ʱ��:
		/// </remarks>
		IList<Order> GetCustomerConsume(Order order);

		/// <summary>
		/// ��ȡ�ͻ����Ѽ�¼��
		/// </summary>
		/// <param name="order"></param>
		/// <returns></returns>
		/// <remarks>
		/// ��    ��: ����ط
		/// ����ʱ��: 2007-10-24
		/// </remarks>
		int GetCustomerConsumeCount(Order order);

		/// <summary>
		/// ��ȡ�ͻ������ܼ�
		/// </summary>
		/// <param name="order"></param>
		/// <returns></returns>
		Order GetCustomerConsumeAmount(Order order);

		#endregion

        /// <summary>
        /// �ͻ����ʱ�Ŀͻ���Ϣ
        /// </summary>
        /// <remarks>
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-10-27
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        IList<Order> GetCustomerHistory(Order order);
		/// <summary>
		/// �ͻ����ʱ�Ķ�����Ϣ
		/// </summary>
		/// <remarks>
		/// ��    ��: ��ǿ
		/// ����ʱ��: 2007-10-27
		/// ��������: 
		/// ����ʱ��:
		/// </remarks>
		IList<Order> GetCustomerOrdersHistory(string memberCardNo, string customerName, int beginRow, int endRow);

		/// <summary>
		/// �ͻ����ʱ�Ķ�����Ϣ�ܼ�
		/// </summary>
		/// <param name="memberCardNo"></param>
		/// <param name="customerName"></param>
		/// <returns></returns>
		/// <remarks>
		/// ��    ��: ����ط
		/// ����ʱ��: 2010-01-15
		/// </remarks>
		Order GetCustomerOrderHistoryTotalize(string memberCardNo, string customerName);

		/// <summary>
		/// �ͻ����ʱ�Ķ�����Ϣ����
		/// </summary>
		/// <param name="memberCardNo"></param>
		/// <param name="customerName"></param>
		/// <returns></returns>
		/// <remarks>
		/// ��    ��: ����ط
		/// ����ʱ��: 2010-01-14
		/// </remarks>
		int GetCustomerOrdersHistoryCount(string memberCardNo, string customerName);

		#region MyRegion

		/// <summary>
        /// �쳣�۸񶩵�ͳ��
        /// </summary>
        /// <remarks>
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-10-29
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        IList<Order> GetExceptionPriceOrdes(Hashtable map);

		int GetExceptionPriceOrdesCount(Hashtable map);

		Order GetExceptionPriceOrdesTotalize(Hashtable map);

		#endregion

        /// <summary>
        /// ���Ͽͻ�����ͳ��
        /// </summary>
        /// <remarks>
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-10-29
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        IList<Order> GetNewAndOldCustomerConsumeCount(Hashtable map);

        #region//�쳣��Ա�ͻ�����ͳ��
        /// <summary>
        /// �쳣��Ա�ͻ�����ͳ��
        /// </summary>
        /// <remarks>
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-10-29
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        IList<Order> GetExceptionMemberCustomerConsume(Order order);

        /// <summary>
        /// �쳣��Ա�ͻ�����ͳ�Ƽ�¼��
        /// </summary>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��12��21��9:47:19
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        long GetExceptionMemberCustomerConsumeRowCount(Order order);

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
        IList<Order> GetExceptionMemberCustomerConsumePrint(Order order);
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
        IList<Order> GetExceptionConsumeCustomer(Order order);

        /// <summary>
        /// �����ͻ�����ͳ�Ƽ�¼��
        /// </summary>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2010��2��23��14:48:09
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        long GetExceptionConsumeCustomerRowCount(Order order);

        /// <summary>
        /// �����ͻ�����ͳ���������
        /// </summary>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2010��2��23��14:47:37
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        IList<Order> GetExceptionConsumeCustomerPrint(Order order);
        #endregion

        /// <summary>
        /// ��ȡ���в��붩����������Ա
        /// </summary>
        /// <remarks>
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-11-5
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        IList<Order> GetOrderAllUserByOrdersId(Order order);
        /// <summary>
        /// ��ȡ������������Ա
        /// </summary>
        /// <remarks>
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-11-5
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        IList<Order> GetOrderReceptionAndCashUserByOrderId(Order order);

        #region �����������
        /// <summary>
        ///  ȡ��Ԥ������/����
        /// </summary>
        /// <param name="cashhandOver"></param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ���ٻ�
        /// ����ʱ��: 2007-10-25
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        CashHandOver SelectDebtAmount(Hashtable condition);

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
        CashHandOver SelectKeepBusinessRecordAmount(Hashtable condition);

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
        CashHandOver SelectTicketAmount(Hashtable condition);
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
        IList<Order> SelectBranchShopTurnover(Order order);
        /// <summary>
        /// ��ѯ�ͻ�Ƿ�����
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-10-26
        /// ��������: ��Ф���ӷ�ҳ��
        /// ����ʱ��:
        /// </remarks>
        IList<Order> SelectCustomerArrearage(Order order);
        //����������
        IList<Order> GetaAllCustomerArrearage(Order order);
       
        #endregion


        /// <summary>
        /// ��ȡ������ҪԤ����Ķ���
        /// </summary>
        /// <param name="iorder"></param>
        /// <returns></returns>
        IList<Order> GetAllNeedPrePayOrders(Order iorder);

        /// <summary>
        /// ��ȡ������ҪԤ����Ķ���������
        /// </summary>
        /// <param name="iorder"></param>
        /// <returns></returns>
        long GetAllNeedPrePayOrdersCount(Order iorder);

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
        Order GetOrderPrepayAmountTotalAndSumAmountTotal(Order order);

        /// <summary>
        /// ����ʱ���Ѿ�Ԥ�������order
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Order SelectOrderInfoByOrderIdPrePaid(long orderId);
       
		/// <summary>
		/// Ӧ�տʱ��κϼ�(���Ʋ�ѯ������)
		/// </summary>
		/// <param name="hashtable"></param>
		/// <returns></returns>
		IList<Order> GetAccountReceviableAccordingToTimeSectTotal(Hashtable hashtable);
		long GetSearchAccountReceviableInfoCount(Hashtable hashCondition);
		/// <summary>
		/// Ӧ�տʱ��κϼ�(û���޶�������)
		/// </summary>
		/// <param name="hashCondition"></param>
		/// <returns></returns>
		IList<Order> GetAccountReceviableTotal(Hashtable hashCondition);

		/// <summary>
		/// (�������ڲ�ѯ)�ձ�(����������)
		/// </summary>
		/// <param name="NowDate"></param>
		/// <returns></returns>
		IList<Order> GetDailyPaper(Hashtable hashCondition);

		/// <summary>
		/// (�������ڲ�ѯ)�ձ�
		/// </summary>
		/// <param name="NowDate"></param>
		/// <returns></returns>
		long GetDailyPaperTotal(Hashtable hashCondition);

        /// <summary>
        /// �������ڲ�ѯ�ձ�(��ӡ)
        /// </summary>
        /// <param name="hashCondition"></param>
        /// <returns></returns>
        IList<Order> GetDailyPaperPrint(Hashtable hashCondition);

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
        decimal GetDailyScotAmount(Hashtable condition);

        ///// <summary>
        ///// (�����·ݲ�ѯ)�±�(����������)
        ///// </summary>
        ///// <param name="NowDate"></param>
        ///// <returns></returns>
        //IList<Order> GetMonthPaper(Hashtable hashCondition);

        /// <summary>
        /// �����·�ͳ��(�±�)---��ӡ
        /// </summary>
        /// <param name="hashCondition"></param>
        /// <returns></returns>
        IList<Order> GetMonthPaperPrint(Hashtable hashCondition);

        ///// <summary>
        ///// �����·�ͳ��(�±�)�ܼ�¼��
        ///// </summary>
        ///// <param name="hashCondition"></param>
        ///// <returns></returns>
        //long GetMonthPaperTotal(Hashtable hashCondition);

        /// <summary>
        /// ����Ƿ��ͻ���Ϣ�����������ڷ�ҳ��
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        long GetSelectCustomerArrearageCount(Order order);

        /// <summary>
        /// ���ݶ����Ų�ѯ ������Ϣ
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Order SelectOrderByOrderNo(long orderId);

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
        IList<Order> SelectCustomerPrepay(Order order);

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
        IList<Order> GetCustomerPrepayPrint(Order order);

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
        int GetCustomerPrepayRowsCount(Order order);

        /// <summary>
        ///���ݶ����Ż�ȡ������
        /// </summary>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        string cashUserName(string orderNo);

        /// <summary>
        /// ��    ��: GetCustomerIdByCustomerName
        /// ���ܸ�Ҫ: ���ݿͻ����ƻ�ȡ�ͻ�Id
        /// ��    ��: ������
        /// ����ʱ��: 2009��3��9��16:19:38
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        Customer GetCustomerInfoByName(string customerName);

		#region ��ȡ�����б�ͨ������״̬

		/// <summary>
		/// ��ȡ�����б�ͨ������״̬
		/// </summary>
		/// <returns>OrderList</returns>
		/// <remarks>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009.4.23
		/// </remarks>
		IList<Order> GetOrderListByStatus(Hashtable map);
		#endregion

        /// <summary>
        /// ��    ��: GetCustomerPayTypeByCustomerId
        /// ���ܸ�Ҫ: ���ݿͻ�Id��ȡ�ͻ�֧����ʽ
        /// ��    ��: ������
        /// ����ʱ��: 2009��8��24��9:30:14
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        long GetCustomerPayTypeByCustomerId(long customerId);

        /// <summary>
        /// ���ض������ѵǼ�״̬
        /// </summary>
        /// <remarks>
        /// ����:������
        /// ����ʱ��:2009��10��12��10:57:17
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        void UpdateOrderByReturnOrder(Order order);

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
        void CancelNotPaidTicket(Order order);

        /// <summary>
        /// ��    ��: GetAmendmentOrder
        /// ���ܸ�Ҫ: ��ȡҪ�����Ķ���
        /// ��    ��: ������
        /// ����ʱ��: 2009��11��17��13:10:40
        /// ��������:
        /// ����ʱ�䣺
        /// </summary>
        Order GetAmendmentOrder(Order order);

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
        void ReturnOrderForPay(Order order);

		#region ��ȡ��Ҫ��������ж���
		
		/// <summary>
		/// ��ȡ��Ҫ��������ж���
		/// </summary>
		/// <param name="lastRecordWath"></param>
		/// <returns></returns>
		/// <remarks>
		/// ��    �ߣ�����ط
		/// ����ʱ��: 2009��12��15��
		/// ����������
		/// ����ʱ��:
		/// </remarks>
		IList<Order> SelectNeedRecordMachineWatch(RecordMachineWatch lastRecordWath);
		#endregion


		#region ��ȡ����

		/// <summary>
		/// ��ȡ����
		/// </summary>
		/// <param name="beginTime">��ʼʱ��</param>
		/// <param name="endTime">����ʱ��</param>
		/// <param name="paymentType">֧������</param>
		/// <returns></returns>
		IList<Order> GetOrders(DateTime beginTime, DateTime endTime, int paymentType,int orderStatus,string userName);

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
        void NewDispatchOrder(Order order);
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
        void AdmendmentPrint(Order order);
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
        void ReturnOrder(Order order);

        /// <summary>
        /// ��    ��: AddBarCodeToOrder
        /// ���ܸ�Ҫ: ������-�������������
        /// ��    ��: ������
        /// ����ʱ��: 2010��1��12��9:46:54
        /// ��������: 
        /// ����ʱ��: 
        /// </summary>
        void AddBarCodeToOrder(Order order);
        #endregion

		#region ��ȡ��������

		/// <summary>
		/// ��ȡ��������
		/// </summary>
		/// <param name="order">��������</param>
		/// <returns></returns>
		long GetOrderCount(Order order);

		#endregion

		#region ��ȡ�ͻ������ж���

		/// <summary>
		/// ��ȡ�ͻ������ж���
		/// </summary>
		/// <param name="customerId">�ͻ�id</param>
		/// <returns></returns>
		IList<Order> GetCustomerOrders(long customerId,int beginRow,int endRow);

		int GetCustomerOrderCount(long customerId);

		#endregion
	}
}
