using System;
using System.Text;
using System.Configuration;
using System.Collections.Generic;
using Workflow.Util;
using Spring.Context;
using Spring.Context.Support;

namespace Workflow.Support
{
    /// <summary>
    /// ��    ��: Constants
    /// ���ܸ�Ҫ: ����
    /// ��    ��: ��ǿ
    /// ����ʱ��: 2007-9-13
    /// ��������: 
    /// ����ʱ��: 
    /// </summary>
    public class Constants
    {
        private static readonly Common.Logging.ILog LOG = Common.Logging.LogManager.GetLogger(typeof(Constants));

        #region �ͻ���ʽ ��ǿ
        public const int DELIVERY_TYPE_SELF_GET_VALUE = 1;
        public const String DELIVERY_TYPE_SELF_GET_LABEL = "��ȡ";
        public const int DELIVERY_TYPE_WAITFOR_GET_VALUE = 2;
        public const String DELIVERY_TYPE_WAITFOR_GET_LABEL = "����";
        public const int DELIVERY_TYPE_DELIVERY_VALUE = 3;
        public const String DELIVERY_TYPE_DELIVERY_LABEL = "�ͻ�";
        //ͨ��ID����ͻ���ʽ
        public static string GetDeliveryType(int value)
        {
            switch (value)
            {
                case 1:
                    return DELIVERY_TYPE_SELF_GET_LABEL;
                case 2:
                    return DELIVERY_TYPE_WAITFOR_GET_LABEL;
                case 3:
                    return DELIVERY_TYPE_DELIVERY_LABEL;
                default:
                    return "";
            }
        }
        #endregion

        #region ���ʽ ��ǿ
        /// <summary>
        /// ���ʽ �ֽ�
        /// </summary>
        public const int PAYMENT_TYPE_CASHER_GET_VALUE = 1;
        /// <summary>
        /// ���ʽ �ֽ�
        /// </summary>
        public const string PAYMENT_TYPE_CASHER_GET_LABEL = "�ֽ�";
        /// <summary>
        /// ���ʽ ����
        /// </summary>
        public const int PAYMENT_TYPE_ACCOUNT_GET_VALUE = 2;
        /// <summary>
        /// ���ʽ ����
        /// </summary>
        public const string PAYMENT_TYPE_ACCOUNT_GET_LABEL = "����";

        #endregion

        #region �������� ��ǿ
        /// <summary>
        /// Ԥ����
        /// </summary>
        public const string PAY_KIND_PREPAY_VALUE = "1";
        /// <summary>
        /// Ԥ����
        /// </summary>
        public const string PAY_KIND_PREPAY_LABEL = "Ԥ����";
        /// <summary>
        /// �����
        /// </summary>
        public const string PAY_KIND_CLOSED_VALUE = "2";
        /// <summary>
        /// �����
        /// </summary>
        public const string PAY_KIND_CLOSED_LABEL = "�����";
        /// <summary>
        /// Ӧ�տ�
        /// </summary>
        public const string PAY_KIND_ARREARAGE_VALUE = "3";
        /// <summary>
        /// Ӧ�տ�
        /// </summary>
        public const string PAY_KIND_ARREARAGE_LABEL = "Ӧ�տ�";
        /// <summary>
        /// ����
        /// </summary>
        public const string PAY_KIND_OTHERS_VALUE = "4";
        /// <summary>
        /// ����
        /// </summary>
        public const string PAY_KIND_OTHERS_LABEL = "����";
        /// <summary>
        /// ����
        /// </summary>
        public const string PAY_KIND_RETURN_VALUE = "5";
        /// <summary>
        /// ����
        /// </summary>
        public const string PAY_KIND_RETURN_LABEL = "����";
        /// <summary>
        /// Ԥ�տ���
        /// </summary>
        public const string PAY_KIND_USE_PREPAY_VALUE = "6";
        /// <summary>
        /// Ԥ�տ���
        /// </summary>
        public const string PAY_KIND_USE_PREPAY_LABEL = "Ԥ�տ���";
        /// <summary>
        /// ��Ա�����
        /// </summary>
        public const string PAY_KIND_MEMBERCARD_DIFF_LABEL = "��Ա�����";
        /// <summary>
        /// ��Ա�����
        /// </summary>
        public const string PAY_KIND_MEMBERCARD_DIFF_VALUE = "7";
        /// <summary>
        /// ��������-�ͻ�Ԥ�����
        /// </summary>
        public const string PAY_KIND_USE_Pre_DEPOSITS_LABEL = "Ԥ�����";
        /// <summary>
        /// ��������-�ͻ�Ԥ�����
        /// </summary>
        public const string PAY_KIND_USE_PRE_DEPOSITS_VALUE= "8";

        /// <summary>
        /// Ӧ�տ��-�ͻ�Ԥ�����
        /// </summary>
        public const string ACCOUNT_USE_PRE_DEPOSITS_LABEL = "Ԥ�����";
        /// <summary>
        /// Ӧ�տ��-�ͻ�Ԥ�����
        /// </summary>
        public const string ACCOUNT_USE_PRE_DEPOSITS_VALUE = "9";
        #endregion

        #region �Ż����� ��ǿ
        /// <summary>
        /// Ĩ��
        /// </summary>
        public const string CONCESSION_TYPE_ZERO_VALUE = "1";
        public const string CONSESSION_TYPE_ZERO_LABEL = "Ĩ��";
        /// <summary>
        /// �Ż�
        /// </summary>
        public const string CONCESSION_TYPE_CONCESSION_VALUE = "2";
        public const string CONSESSION_TYPE_CONCESSION_LABEL = "�Ż�";
        /// <summary>
        /// ����
        /// </summary>
        public const string CONCESSION_TYPE_RENDERUP_VALUE = "3";
        public const string CONSESSION_TYPE_RENDERUP_LABEL = "����";
        /// <summary>
        /// ��������
        /// </summary>
        public const string CONCESSION_TYPE_ROUND_NEGTIVE_VALUE = "4";
        public const string CONCESSION_TYPE_ROUND_NEGTIVE_LABEL = "��������";
        /// <summary>
        /// �������
        /// </summary>
        public const string CONCESSION_TYPE_ROUND_POSITIVE_VALUE = "5";
        public const string CONCESSION_TYPE_ROUND_POSITIVE_LABEL = "�������";

        #endregion

        #region ����״̬
        //1:����ǰ̨����
        //2:������������
        public const int HANDER_OVER_FRONT = 1;
        public const int HANDER_OVER_CASHER = 2;

        //ͨ��ID��ý�������
        public static string GetHandOverType(string value)
        {
            switch (value)
            {
                case "1":
                    return "ǰ̨����";
                case "2":
                    return "��������";
                default:
                    return "";
            }
        }
        #endregion

        #region Boolean ���� ��ǿ
        public const string TRUE = "Y";
        public const string FALSE = "N";
        #endregion

        #region ����״̬ ��ǿ
        /// <summary>
        /// δԤ��
        /// </summary>
        public const int ORDER_STATUS_NOPREPAY_VALUE = 1;
        public const string ORDER_STATUS_NOPREPAY_LABEL = "δԤ��";
        /// <summary>
        /// δ����
        /// </summary>
        public const int ORDER_STATUS_NODISPATCHED_VALUE = 2;
        public const string ORDER_STATUS_NODISPATCHED_LABEL = "δ����";
        /// <summary>
        /// ������
        /// </summary>
        public const int ORDER_STATUS_FACTURING_VALUE = 3;
        public const string ORDER_STATUS_FACTURING_LABEL = "������";
        /// <summary>
        /// ���깤
        /// </summary>
        public const int ORDER_STATUS_FINISHED_VALUE = 4;
        public const string ORDER_STATUS_FINISHED_LABEL = "���깤";
        /// <summary>
        /// �����
        /// </summary>
        public const int ORDER_STATUS_SUCCESSED_VALUE = 5;
        public const string ORDER_STATUS_SUCCESSED_LABEL = "�����";
        /// <summary>
        /// ������
        /// </summary>
        public const int ORDER_STATUS_BLANKOUT_VALUE = 6;
        public const string ORDER_STATUS_BLANKOUT_LABEL = "������";

        /// <summary>
        /// �ͻ���
        /// </summary>
        public const int ORDER_STATUS_DELIVERYING_VALUE = 7;
        public const string ORDER_STATUS_DELIVERYING_LABEL = "�ͻ���";

        /// <summary>
        /// ���ͳ�
        /// </summary>
        public const int ORDER_STATUS_DELIVERYED_VALUE = 8;
        public const string ORDER_STATUS_DELIVERYED_LABEL = "���ͳ�";
        /// <summary>
        /// ��ƴ��
        /// </summary>
        public const int ORDER_STATUS_NOPATCHUP_VALUE = 9;
        public const string ORDER_STATUS_NOPATCHUP_LABEL="��ƴ��";
        /// <summary>
        /// �ѵǼ�
        /// </summary>
        public const int ORDER_STATUS_NOBLANKOUTRECORD_VALUE=10;
        public const string ORDER_STATUS_NOBLANKOUTRECORD_LABEL="�ѵǼ�";


        //ͨ��ID��ù���״̬���ƣ�(���ӹ���״̬���жϣ�������˳��--������ 2009��3��20��17:26:19)
        public static string GetOrderStatus(int value)
        {
            switch (value)
            {
                case 1:
                    return ORDER_STATUS_NOPREPAY_LABEL;
                case 2:
                    return ORDER_STATUS_NODISPATCHED_LABEL;
                case 3:
                    return ORDER_STATUS_FACTURING_LABEL;
                case 4:
                    return ORDER_STATUS_FINISHED_LABEL;
                case 5:
                    return ORDER_STATUS_SUCCESSED_LABEL;
                case 6:
                    return ORDER_STATUS_BLANKOUT_LABEL;
                case 7:
                    return ORDER_STATUS_DELIVERYING_LABEL;
                case 8:
                    return ORDER_STATUS_DELIVERYED_LABEL;
                case 9:
                    return ORDER_STATUS_NOPATCHUP_LABEL;
                case 10:
                    return ORDER_STATUS_NOBLANKOUTRECORD_LABEL;
                default:
                    return "";
            }
        }



        #endregion
        
        #region  ְλ ��ǿ
        /// <summary>
        /// ǰ̨
        /// </summary>
        public static long POSITION_RECEPTION_VALUE(long branchShopId)
        {
            if (branchShopId <= 1)
            {
                return 1;
            }
            else
            {
                return (branchShopId - 1) * MAX_ID_BASE + 1;
            }
        }
        //public const int POSITION_RECEPTION_VALUE = 1;
        public const string POSITION_RECEPTION_TEXT = "ǰ̨";
        /// <summary>
        /// ǰ��
        /// </summary>
        public static long POSITION_PROPHASE_VALUE(long branchShopId)
        {
            if (branchShopId <= 1)
            {
                return 2;
            }
            else
            {
                return (branchShopId - 1) * MAX_ID_BASE + 2;
            }
        }
        //public const int POSITION_PROPHASE_VALUE = 2;
        public const string POSITION_PROPHASE_TEXT = "ǰ��";
        /// <summary>
        /// ��ӹ�
        /// </summary>
        public static long POSITION_ANAPHASE_VALUE(long branchShopId)
        {
            if (branchShopId <= 1)
            {
                return 3;
            }
            else
            {
                return (branchShopId - 1) * MAX_ID_BASE + 3;
            }
        }
        //public const int POSITION_ANAPHASE_VALUE = 3;
        public const string POSITION_ANAPHASE_TEXT = "��ӹ�";
        /// <summary>
        /// ����
        /// </summary>
        public static long POSITION_CASHER_VALUE(long branchShopId)
        {
            if (branchShopId <= 1)
            {
                return 4;
            }
            else
            {
                return (branchShopId - 1) * MAX_ID_BASE + 4;
            }
        }
        //public const int POSITION_CASHER_VALUE = 4;
        public const string POSITION_CASHER_TEXT = "����";
        /// <summary>
        /// �곤
        /// </summary>
        public static long POSITION_SHOP_MASTER_VALUE(long branchShopId)
        {
            if (branchShopId <= 1)
            {
                return 5;
            }
            else
            {
                return (branchShopId - 1) * MAX_ID_BASE + 5;
            }
        }
        //public const int POSITION_SHOP_MASTER_VALUE = 5;
        public const string POSITION_SHOP_MASTER_TEXT = "�곤";
        /// <summary>
        /// ����
        /// </summary>
        public static long POSITION_MANAGER_VALUE(long branchShopId)
        {
            if (branchShopId <= 1)
            {
                return 6;
            }
            else
            {
                return (branchShopId - 1) * MAX_ID_BASE + 6;
            }
        }
        //public const int POSITION_MANAGER_VALUE = 6;
        public const string POSITION_MANAGER_TEXT = "����";
        public static long POSITION_PUBLIC_ACCUNT_VALUE(long branchShopId)
        {
            if (branchShopId <= 1)
            {
                return 7;
            }
            else
            {
                return (branchShopId - 1) * MAX_ID_BASE + 7;
            }
        }
        //public const int POSITION_PUBLIC_ACCUNT_VALUE = 7;
        public const string PSOITION_PUBLIC_ACCUNT_TEXT = "�����˻�";
        #endregion

        #region ��ɫ ��ǿ
        /// <summary>
        /// ����Ա
        /// </summary>
        //public const int ROLE_ADMINISTRATOR_VALUE = 1;
        
        public const string ROLE_ADMINISTRATOR_TEXT = "����Ա";
        /// <summary>
        /// ǰ̨
        /// </summary>
        //public const int ROLE_RECEPTION_VALUE = 2;
        public const string ROLE_RECEPTION_TEXT = "ǰ̨";
        /// <summary>
        /// ����
        /// </summary>
        //public const int ROLE_CASHER_VALUE = 3;
        public const string ROLE_CASHER_TEXT = "����";
        /// <summary>
        /// �곤
        /// </summary>
        //public const int ROLE_MASTER_VALUE = 4;
        public const string ROLE_MASTER_TEXT = "�곤";

        /// <summary>
        /// ����Ա
        /// </summary>
        public static long ROLE_ADMINISTRATOR_VALUE(long branchShopId)
        {
            if (branchShopId <= 1)
            {
                return 1;
            }
            else
            {
                //return (branchShopId - 1) * MAX_ID_BASE + 6;
                return (branchShopId-1) * MAX_ID_BASE + 1;
            }
        }
        /// <summary>
        /// / ǰ̨
        /// </summary>
        public static long ROLE_RECEPTION_VALUE(long branchShopId)
        {
            if (branchShopId <= 1)
            {
                return 2;
            }
            else
            {
                //return (branchShopId - 1) * MAX_ID_BASE + 6;
                return (branchShopId-1) * MAX_ID_BASE + 2;
            }
        }


        /// <summary>
        /// ����
        /// </summary>
        public static long ROLE_CASHER_VALUE(long branchShopId)
        {
            if (branchShopId <= 1)
            {
                return 3;
            }
            else
            {
                //return (branchShopId - 1) * MAX_ID_BASE + 6;
                return (branchShopId-1) * MAX_ID_BASE + 3;
            }
        }

        /// <summary>
        /// �곤
        /// </summary>
        public static long ROLE_MASTER_VALUE(long branchShopId)
        {
            if (branchShopId <= 1)
            {
                return 4;
            }
            else
            {
                //return (branchShopId - 1) * MAX_ID_BASE + 6;
                return (branchShopId-1) * MAX_ID_BASE + 4;
            }
        }
        #endregion

        public const string AJAX_PROCESS_DEMO = "1";

        #region ����ѡ����Ĭ��ֵ ��ǿ
        /// <summary>
        /// Select��û�б�ѡ�е�ʱ�򣬶�Ӧ��ֵ
        /// </summary>
        public const string SELECT_VALUE_NOT_SELECTED_KEY = "-1";
        public const string SELECT_VALUE_NOT_SELECTED_TEXT = "��ѡ��";
        #endregion

        public const string KEY_CALLBACK = "cb";
        public const string DEFAULT_CALLBACK_SELECT_CUSTOMER = "selectCustomer";

        //�жϸ����ڣ�����Tag���
        public const string Tag = "1"; //��ʾ����������CustomerList.aspx,Tag������ֵ��ʾ����Order

        #region �۸����� ��ǿ
        //���м۸�
        public const int PRICE_TYPE_BASE = 0;
        //��Ա���۸�
        public const int PRICE_TYPE_MEMBER = 1;
        //��ҵ�۸�
        public const int PRICE_TYPE_TRADE = 2;
        //�����Ա�۸�
        public const int PRICE_TYPE_SPECIAL = 3;
        #endregion

        #region ��������
        public const int ACTION_INIT = 1;
        public const int ACTION_SEARCH = 2;
        public const int ACTION_INSERT = 3;
        public const int ACTION_UPDATE = 4;
        public const int ACTION_DELETE = 5;
        public const int ACTION_OTHER = 6;
        #endregion

        #region �������� ��ǿ
        public const int ORDER_OPERATOR_TAG_DISPATCH = 1;//��ʾ����
        public const int ORDER_OPERATOR_TAG_FINISHED = 2;//��ʾ�깤
        public const int ORDER_OPERATOR_TAG_REDO = 3;//��ʾ����
        public const int ORDER_OPERATOR_TAG_SUCCESSED = 4;//��ʾ���
        public const int ORDER_OPERATOR_TAG_BLANKOUT = 5;//��ʾ����
        public const int ORDER_OPERATOR_TAG_CANCELAFTERVERIFICATION = 6;//��ʾ�ͻ�
        public const int ORDER_OPERATOR_TAG_REALFACTURE = 7;//ʵ������
        #endregion 

        #region �ͻ�״̬ ��ǿ
        public const string DELIVERY_STATUS_FINISHED_VALUE = "1";
        public const string DELIVERY_STATUS_FINISHED_TEXT = "�����";
        public const string DELIVERY_STATUS_UNFINISHED_VALUE = "2";
        public const string DELIVERY_STATUS_UNFINISHED_TEXT = "δ���";
        #endregion

        #region ��ʱ�� ��ǿ
        public static readonly DateTime NULL_DATE_TIME = Convert.ToDateTime("9999-12-31 00:00:00");
        public static readonly DateTime NULL_MIN_DATE_TIME = Convert.ToDateTime("0001-01-01 00:00:00");
        #endregion 

		#region �μӻʱʹ�õļ۸��׼
		/// <summary>
		/// ���м۸�
		/// </summary>
		public const int CONCESSION_PRICE_BASE_RANGE_BASE = 1;
		/// <summary>
		/// ��Ա�۸�
		/// </summary>
		public const int CONCESSION_PRICE_BASE_RANGE_MEMBER = 2;
		/// <summary>
		/// ��ҵ�۸�
		/// </summary>
		public const int CONCESSION_PRICE_BASE_RANGE_TRADE = 3;
		/// <summary>
		/// ��ͼ۸�
		/// </summary>
		public const int CONCESSION_PRICE_BASE_RANGE_LOWEST = 4;
		#endregion

        #region �Ƿ���Ҫ��Ʊ     ��ΰ
        public const string NEED_TICKET_KEY = "Y";
        public const string NEED_TICKET_TEXT = "��Ҫ";

        public const string NEED_TICKET_NOT_KEY = "N";
        public const string NEED_TICKET_NOT_TEXT = "����Ҫ";
        #endregion

        #region ��Ʊ��ȡ״̬ ��ǿ
        /// <summary>
        /// Ƿ��Ʊ
        /// </summary>
        public const string TAKE_TICKET_STATUS_OWE = "Y";
        /// <summary>
        /// ��Ƿ ��Ʊ����
        /// </summary>
        public const string TAKE_TICKET_STATUS_NOT_OWE = "N";
        /// <summary>
        /// ����Ҫ����Ʊ
        /// </summary>
        public const string TAKE_TICKET_STATUS_NOT_GIVE = "F";
        #endregion

        #region ��״̬   ��ΰ
        public const string MEMBER_CARD_STATE_NATURAL_KEY = "1";
        public const string MEMBER_CARD_STATE_NATURAL_TEXT = "����";
        public const string MEMBER_CARD_STATE_REPORTLOSS_KEY = "2";
        public const string MEMBER_CARD_STATE_REPORTLOSS_TEXT = "��ʧ";
        public const string MEMBER_CARD_STATE_LOGOUT_KEY = "3";
        public const string MEMBER_CARD_STATE_LOGOUT_TEXT = "ע��";
        #endregion

        #region ��Ա������
        public const string MEMBER_CARD_OPERATE_GTANT_KEY = "1";
        public const string MEMBER_CARD_OPERATE_GTANT_TEXT = "����";
        public const string MEMBER_CARD_OPERATE_REPORTLOSS_KEY = "2";
        public const string MEMBER_CARD_OPERATE_REPORTLOSS_TEXT = "��ʧ";
        public const string MEMBER_CARD_OPERATE_LOGOUT_KEY = "3";
        public const string MEMBER_CARD_OPERATE_LOGOUT_TEXT = "ע��";
        public const string MEMBER_CARD_OPERATE_RECOVERY_KEY = "4";
        public const string MEMBER_CARD_OPERATE_RECOVERY_TEXT = "�ָ�";
        public const string MEMBER_CARD_OPERATE_REISSUE_KEY = "5";
        public const string MEMBER_CARD_OPERATE_REISSUE_TEXT = "����";
        public static string GetMemberCardOperateType(string key) 
        {
            switch(key)
            {
                case MEMBER_CARD_OPERATE_GTANT_KEY:
                    return MEMBER_CARD_OPERATE_GTANT_TEXT;
                case MEMBER_CARD_OPERATE_REPORTLOSS_KEY:
                    return MEMBER_CARD_OPERATE_REPORTLOSS_TEXT;
                case MEMBER_CARD_OPERATE_LOGOUT_KEY:
                    return MEMBER_CARD_OPERATE_LOGOUT_TEXT;
                case MEMBER_CARD_OPERATE_RECOVERY_KEY:
                    return MEMBER_CARD_OPERATE_RECOVERY_TEXT;
                case MEMBER_CARD_OPERATE_REISSUE_KEY:
                    return MEMBER_CARD_OPERATE_REISSUE_TEXT;
                default:
                    return "";
            }
        }
        #endregion

        #region �ͻ�״̬  ��ΰ
        public const string CUSTOMER_VALIDATE_STATUS_KEY = "1";
        public const string CUSTOMER_VALIDATE_STATUS_TEXT = "ȷ��";

        public const string CUSTOMER_NOT_VALIDATE_STATUS_KEY = "0";
        public const string CUSTOMER_NOT_VALIDATE_STATUS_TEXT = "δȷ��";

        #endregion
        
        #region Ԥ���������
        public const string PREPAY_CAN_OVER="Y";
        public const string PREPAY_CAN_NOOVER = "N";
        #endregion 

        #region ͨ�����ֻ����ɫ

        /// <summary>
        /// �ڰ�
        /// </summary>
        public const string COLOR_BLACKWHITE = "1";

        /// <summary>
        /// ��ɫ
        /// </summary>
        public const string COLOR_MULTICOLOR = "2";

		/// <summary>
		/// δָ��
		/// </summary>
		public const string COLOR_NOT_DEFINE ="3";

        public static string GetColorType(string value)
        {
            switch (value)
            {
                case "1":
                    return "�ڰ�";
                case "2":
                    return "��ɫ";
				case "3":
					return "δָ��";
                default:
                    return "";
            }
        }
        #endregion

        #region ��ѯ����(�ȴ�С)
        public static string QUERY_CONDITION_LESS_KEY = "0";
        public static string QUERY_CONDITION_LESS_VALUE = "<";
        public static string QUERY_CONDITION_LESS_TEXT = "С��";

        public static string QUERY_CONDITION_LESS_EQUAL_KEY = "1";
        public static string QUERY_CONDITION_LESS_EQUAL_VALUE = "<=";
        public static string QUERY_CONDITION_LESS_EQUAL_TEXT = "С�ڵ���";

        public static string QUERY_CONDITION_EQUAL_KEY = "2";
        public static string QUERY_CONDITION_EQUAL_VALUE = "=";
        public static string QUERY_CONDITION_EQUAL_TEXT = "����";

        public static string QUERY_CONDITION_GREATER_EQUAL_KEY = "3";
        public static string QUERY_CONDITION_GREATER_EQUAL_VALUE = ">=";
        public static string QUERY_CONDITION_GREATER_EQUAL_TEXT = "���ڵ���";

        public static string QUERY_CONDITION_GREATER_KEY = "4";
        public static string QUERY_CONDITION_GREATER_VALUE = ">";
        public static string QUERY_CONDITION_GREATER_TEXT = "����";

        #endregion

        #region �Ա� ��ǿ
        public const int SEX_MALE_VALUE = 0;
        public const string SEX_MALE_TEXT = "��";
        public const int SEX_FEMALE_VALUE = 1;
        public const string SEX_FEMALE_TEXT = "Ů";
        #endregion 

        #region ��ҳ��Ϣ ��ǿ
        /// <summary>
        /// ÿҳ����
        /// </summary>
        public const int ROW_COUNT_FOR_PAGER =20;
        /// <summary>
        /// ��ʾ��ҳ����
        /// </summary>
        public const int SHOW_PAGE_COUNT = 10;


        #endregion

        #region LoggerName ��ǿ
        public const string LOGGER_NAME = "Workflow.Web";

        #endregion

        #region ��˾���� ��ǿ
        public static long COMPANY_ID
        {
            get 
            {
                string companyId = ConfigurationManager.AppSettings["CompanyId"];
                if (StringUtils.IsEmpty(companyId))
                {
                    throw new ConfigurationErrorsException("��˾ID��������Ϊ��!");
                }
                else
                {
                    
                    long x = 0;
                    bool convertSuccess = long.TryParse(companyId, out x);
                    if (!convertSuccess)
                    {
                        throw new ConfigurationErrorsException("��˾ID����Ϊ����!");
                    }
                    return long.Parse(companyId);
                }
            }
        }
        #endregion

        #region ɢ�͹̶�id

        /// <summary>
        /// ɢ�͹̶�id
        /// </summary>
        //public const long scatteredClientId = 1;
        /// <summary>
        /// ɢ�͹̶�id
        /// </summary>
        /// <remarks>
        /// ��    ��:
        /// ����ʱ��:2009��8��7��9:54:09
        /// ��������:������
        /// ����ʱ��:2009��8��7��9:54:45
        /// ��������:����Ϊ��Ӧ����ɢ��Id�Ļ�ȡ
        /// </remarks>
        public static long scatteredClientId(long branchShopId)
        {
            if (branchShopId <= 1)
            {
                return 1;
            }
            else
            {
                return (branchShopId-1) * MAX_ID_BASE + 1;
            }
        }

        #endregion

        #region//ɢ�͵Ŀͻ�����Id
        /// <summary>
        /// ��ȡɢ�͵Ŀͻ�����Id
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��:������
        /// ����ʱ��:2009��8��12��10:16:40
        /// ��������:
        /// ����ʱ��:
        /// ��������:
        /// </remarks>
        public static long scatteredCustomerTypeId(long branchShopId) 
        {
            if (branchShopId <= 1)
            {
                return 1;
            }
            else
            {
                return (branchShopId - 1) * MAX_ID_BASE + 1;
            }
        }
        #endregion

        #region �����ϵı������
        /// <summary>
        /// M1
        /// </summary>
        public const int WATCH_TYPE_M1 = 1;
        /// <summary>
        /// M2
        /// </summary>
        public const int WATCH_TYPE_M2 = 2;
        /// <summary>
        /// M3
        /// </summary>
        public const int WATCH_TYPE_M3 = 3;
        /// <summary>
        /// M4
        /// </summary>
        public const int WATCH_TYPE_M4 = 4;
        #endregion 

        #region �ڳ���������е�Key ��ǿ
        /// <summary>
        /// ҵ�������ڳ���������е�Key
        /// </summary>
        public const string APPLICATION_ALLOT_RATE_KEY = "ACHIEVEMENT_ALLOT_RATE";
        /// <summary>
        /// ��������ʼʱ��
        /// </summary>
        public const string APPLICATION_START_TIME_KEY = "WORK_START_TIME";
        /// <summary>
        /// �����ս�ֹʱ��
        /// </summary>
        public const string APPLICATION_END_TIME_KEY = "WORK_END_TIME";
        /// <summary>
        /// ��ʾ�����ڹ���
        /// </summary>
        public const string APPLICATION_DISPLAY_ORDER_INNER_DAY_COUNT_KEY = "DISPLAY_ORDER_INNER_DAY_COUNT";

        /// <summary>
        /// ���ֵ����ID����
        /// </summary>
        public const long MAX_ID_BASE = 100000000;

        #endregion

        #region �Ƿ���Ҫ���� ������
        public const string NEED_IN_WATCH_KEY = "Y";
        public const string NEED_IN_WATCH_TEXT = "��Ҫ";

        public const string NEED_IN_WATCH_NOT_KEY = "N";
        public const string NEED_IN_WATCH_NOT_TEXT = "����Ҫ";

        public static string GetInWatchIsNot(string text) 
        {
            switch (text)
            {
                case "Y":
                    return NEED_IN_WATCH_TEXT;
                case "N":
                    return NEED_IN_WATCH_NOT_TEXT;
                default :
                    return "";
            }
        }
        #endregion

        #region ���ֵ���ɫ ������
        public const int COLOR_REPARTITION_NO_KEY = 0;
        public const string COLOR_REPARTITION_NO_TEXT = "δָ��";

        public const int COLOR_REPARTITION_BLACK_KEY = 1;
        public const string COLOR_REPARTITION_BLACK_TEXT = "��ɫ";

        public const int COLOR_REPARTITION_COLOUR_KEY = 2;
        public const string COLOR_REPARTITION_COLOUR_TEXT = "��ɫ";

        public static string GetRepartitionColor(int key)
        {
            switch (key)
            {
                case 0:
                    return COLOR_REPARTITION_NO_TEXT;
                case 1:
                    return COLOR_REPARTITION_BLACK_TEXT;
                case 2:
                    return COLOR_REPARTITION_COLOUR_TEXT;
                default:
                    return "";
            }
        }
        #endregion

        #region �۸����� ������
        /// <summary>
        /// �ֶ��Ƿ�ʹ��
        /// </summary>
        public const string IS_USED_KEY = "Y";
        /// <summary>
        /// �ֶ��Ƿ�ʹ��
        /// </summary>
        public const string IS_USED_TEXT = "��";

        /// <summary>
        /// �ֶ��Ƿ�ʹ��
        /// </summary>
        public const string NOT_USED_KEY = "N";
        /// <summary>
        /// �ֶ��Ƿ�ʹ��
        /// </summary>
        public const string NOT_USED_TEXT = "��";

        /// <summary>
        /// ��ȡ�۸�����ʹ��״̬
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetPriceFactorUsedStat(string key) 
        {
            switch(key)
            {
                case IS_USED_KEY:
                    return IS_USED_TEXT;
                case NOT_USED_KEY:
                    return NOT_USED_TEXT;
                default:
                    return "";
            }
        }

        /// <summary>
        /// �ֶ��Ƿ���ʾ
        /// </summary>
        public const string IS_DISPLAY_KEY = "Y";
        /// <summary>
        /// �ֶ��Ƿ���ʾ
        /// </summary>
        public const string IS_DISPLAY_TEXT = "��";

        /// <summary>
        /// �ֶ��Ƿ���ʾ
        /// </summary>
        public const string NOT_DISPLAY_KEY = "N";
        /// <summary>
        /// �ֶ��Ƿ���ʾ
        /// </summary>
        public const string NOT_DISPLAY_TEXT = "��";

        /// <summary>
        /// ��ȡ�۸�������ʾ״̬
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetPriceFactorDisplayStatus(string key) 
        {
            switch (key)
            {
                case IS_DISPLAY_KEY:
                    return IS_DISPLAY_TEXT;
                case NOT_DISPLAY_KEY:
                    return NOT_DISPLAY_TEXT;
                default:
                    return "";
            }
        }
        #endregion

        #region Ȩ����Ĳ���
        /// <summary>
        /// ����Ȩ��
        /// </summary>
        /// <param name="branchShopId"></param>
        /// <returns></returns>
        public static long PERMISSION_GROUP_OPERATE(long branchShopId)
        {
            if (branchShopId <= 1)
            {
                return 5;
            }
            else
            {
                return (branchShopId - 1) * MAX_ID_BASE + 5;
            }
        }
        #endregion

        #region �۸����ض�ѡ����ʾ�ı� ������
        /// <summary>
        /// �����ѡ�ļ۸�����
        /// </summary>
        public static string[] ARR_MORE_SEL_TEXT = new string[] { "����", "ֽ��", "���" };
        #endregion

        #region//
        /// <summary>
        /// ���ݷֵ��ȡҵ������Id(����ѡ��ҵ�����Ϳ�����ʱ)
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��:������
        /// ����ʱ��:2009��8��15��14:18:34
        /// ��������:
        /// ����ʱ��:
        /// ��������:
        /// </remarks>
        public static long BUSINESS_TYPE_ID(long branchShopId) 
        {
            if (branchShopId <= 1)
            {
                return 1;
            }
            else
            {
                return (branchShopId - 1) * MAX_ID_BASE + 1;
            }
        }
        #endregion
    }

}
