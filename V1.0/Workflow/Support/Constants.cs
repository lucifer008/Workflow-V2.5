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
    /// 名    称: Constants
    /// 功能概要: 常量
    /// 作    者: 付强
    /// 创建时间: 2007-9-13
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    public class Constants
    {
        private static readonly Common.Logging.ILog LOG = Common.Logging.LogManager.GetLogger(typeof(Constants));

        #region 送货方式 付强
        public const int DELIVERY_TYPE_SELF_GET_VALUE = 1;
        public const String DELIVERY_TYPE_SELF_GET_LABEL = "自取";
        public const int DELIVERY_TYPE_WAITFOR_GET_VALUE = 2;
        public const String DELIVERY_TYPE_WAITFOR_GET_LABEL = "立等";
        public const int DELIVERY_TYPE_DELIVERY_VALUE = 3;
        public const String DELIVERY_TYPE_DELIVERY_LABEL = "送货";
        //通过ID获得送货方式
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

        #region 付款方式 付强
        /// <summary>
        /// 付款方式 现金
        /// </summary>
        public const int PAYMENT_TYPE_CASHER_GET_VALUE = 1;
        /// <summary>
        /// 付款方式 现金
        /// </summary>
        public const string PAYMENT_TYPE_CASHER_GET_LABEL = "现金";
        /// <summary>
        /// 付款方式 记账
        /// </summary>
        public const int PAYMENT_TYPE_ACCOUNT_GET_VALUE = 2;
        /// <summary>
        /// 付款方式 记账
        /// </summary>
        public const string PAYMENT_TYPE_ACCOUNT_GET_LABEL = "记账";

        #endregion

        #region 付款类型 付强
        /// <summary>
        /// 预付款
        /// </summary>
        public const string PAY_KIND_PREPAY_VALUE = "1";
        /// <summary>
        /// 预付款
        /// </summary>
        public const string PAY_KIND_PREPAY_LABEL = "预付款";
        /// <summary>
        /// 结算款
        /// </summary>
        public const string PAY_KIND_CLOSED_VALUE = "2";
        /// <summary>
        /// 结算款
        /// </summary>
        public const string PAY_KIND_CLOSED_LABEL = "结算款";
        /// <summary>
        /// 应收款
        /// </summary>
        public const string PAY_KIND_ARREARAGE_VALUE = "3";
        /// <summary>
        /// 应收款
        /// </summary>
        public const string PAY_KIND_ARREARAGE_LABEL = "应收款";
        /// <summary>
        /// 其他
        /// </summary>
        public const string PAY_KIND_OTHERS_VALUE = "4";
        /// <summary>
        /// 其他
        /// </summary>
        public const string PAY_KIND_OTHERS_LABEL = "其他";
        /// <summary>
        /// 找零
        /// </summary>
        public const string PAY_KIND_RETURN_VALUE = "5";
        /// <summary>
        /// 找零
        /// </summary>
        public const string PAY_KIND_RETURN_LABEL = "找零";
        /// <summary>
        /// 预收款冲减
        /// </summary>
        public const string PAY_KIND_USE_PREPAY_VALUE = "6";
        /// <summary>
        /// 预收款冲减
        /// </summary>
        public const string PAY_KIND_USE_PREPAY_LABEL = "预收款冲减";
        /// <summary>
        /// 会员卡冲减
        /// </summary>
        public const string PAY_KIND_MEMBERCARD_DIFF_LABEL = "会员卡冲减";
        /// <summary>
        /// 会员卡冲减
        /// </summary>
        public const string PAY_KIND_MEMBERCARD_DIFF_VALUE = "7";
        /// <summary>
        /// 工单结算-客户预存款冲减
        /// </summary>
        public const string PAY_KIND_USE_Pre_DEPOSITS_LABEL = "预存款冲减";
        /// <summary>
        /// 工单结算-客户预存款冲减
        /// </summary>
        public const string PAY_KIND_USE_PRE_DEPOSITS_VALUE= "8";

        /// <summary>
        /// 应收款处理-客户预存款冲减
        /// </summary>
        public const string ACCOUNT_USE_PRE_DEPOSITS_LABEL = "预存款冲减";
        /// <summary>
        /// 应收款处理-客户预存款冲减
        /// </summary>
        public const string ACCOUNT_USE_PRE_DEPOSITS_VALUE = "9";
        #endregion

        #region 优惠类型 付强
        /// <summary>
        /// 抹零
        /// </summary>
        public const string CONCESSION_TYPE_ZERO_VALUE = "1";
        public const string CONSESSION_TYPE_ZERO_LABEL = "抹零";
        /// <summary>
        /// 优惠
        /// </summary>
        public const string CONCESSION_TYPE_CONCESSION_VALUE = "2";
        public const string CONSESSION_TYPE_CONCESSION_LABEL = "优惠";
        /// <summary>
        /// 折让
        /// </summary>
        public const string CONCESSION_TYPE_RENDERUP_VALUE = "3";
        public const string CONSESSION_TYPE_RENDERUP_LABEL = "折让";
        /// <summary>
        /// 舍入少收
        /// </summary>
        public const string CONCESSION_TYPE_ROUND_NEGTIVE_VALUE = "4";
        public const string CONCESSION_TYPE_ROUND_NEGTIVE_LABEL = "舍入少收";
        /// <summary>
        /// 舍入多收
        /// </summary>
        public const string CONCESSION_TYPE_ROUND_POSITIVE_VALUE = "5";
        public const string CONCESSION_TYPE_ROUND_POSITIVE_LABEL = "舍入多收";

        #endregion

        #region 交班状态
        //1:代表前台交班
        //2:代表收银交班
        public const int HANDER_OVER_FRONT = 1;
        public const int HANDER_OVER_CASHER = 2;

        //通过ID获得交班类型
        public static string GetHandOverType(string value)
        {
            switch (value)
            {
                case "1":
                    return "前台交班";
                case "2":
                    return "收银交班";
                default:
                    return "";
            }
        }
        #endregion

        #region Boolean 常量 付强
        public const string TRUE = "Y";
        public const string FALSE = "N";
        #endregion

        #region 工单状态 付强
        /// <summary>
        /// 未预付
        /// </summary>
        public const int ORDER_STATUS_NOPREPAY_VALUE = 1;
        public const string ORDER_STATUS_NOPREPAY_LABEL = "未预付";
        /// <summary>
        /// 未分配
        /// </summary>
        public const int ORDER_STATUS_NODISPATCHED_VALUE = 2;
        public const string ORDER_STATUS_NODISPATCHED_LABEL = "未分配";
        /// <summary>
        /// 制作中
        /// </summary>
        public const int ORDER_STATUS_FACTURING_VALUE = 3;
        public const string ORDER_STATUS_FACTURING_LABEL = "制作中";
        /// <summary>
        /// 已完工
        /// </summary>
        public const int ORDER_STATUS_FINISHED_VALUE = 4;
        public const string ORDER_STATUS_FINISHED_LABEL = "已完工";
        /// <summary>
        /// 已完成
        /// </summary>
        public const int ORDER_STATUS_SUCCESSED_VALUE = 5;
        public const string ORDER_STATUS_SUCCESSED_LABEL = "已完成";
        /// <summary>
        /// 已作废
        /// </summary>
        public const int ORDER_STATUS_BLANKOUT_VALUE = 6;
        public const string ORDER_STATUS_BLANKOUT_LABEL = "已作废";

        /// <summary>
        /// 送货中
        /// </summary>
        public const int ORDER_STATUS_DELIVERYING_VALUE = 7;
        public const string ORDER_STATUS_DELIVERYING_LABEL = "送货中";

        /// <summary>
        /// 已送出
        /// </summary>
        public const int ORDER_STATUS_DELIVERYED_VALUE = 8;
        public const string ORDER_STATUS_DELIVERYED_LABEL = "已送出";
        /// <summary>
        /// 已拼版
        /// </summary>
        public const int ORDER_STATUS_NOPATCHUP_VALUE = 9;
        public const string ORDER_STATUS_NOPATCHUP_LABEL="已拼版";
        /// <summary>
        /// 已登记
        /// </summary>
        public const int ORDER_STATUS_NOBLANKOUTRECORD_VALUE=10;
        public const string ORDER_STATUS_NOBLANKOUTRECORD_LABEL="已登记";


        //通过ID获得工单状态名称：(增加工单状态的判断，并调整顺序--张晓林 2009年3月20日17:26:19)
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
        
        #region  职位 付强
        /// <summary>
        /// 前台
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
        public const string POSITION_RECEPTION_TEXT = "前台";
        /// <summary>
        /// 前期
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
        public const string POSITION_PROPHASE_TEXT = "前期";
        /// <summary>
        /// 后加工
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
        public const string POSITION_ANAPHASE_TEXT = "后加工";
        /// <summary>
        /// 收银
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
        public const string POSITION_CASHER_TEXT = "收银";
        /// <summary>
        /// 店长
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
        public const string POSITION_SHOP_MASTER_TEXT = "店长";
        /// <summary>
        /// 经理
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
        public const string POSITION_MANAGER_TEXT = "经理";
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
        public const string PSOITION_PUBLIC_ACCUNT_TEXT = "公共账户";
        #endregion

        #region 角色 付强
        /// <summary>
        /// 管理员
        /// </summary>
        //public const int ROLE_ADMINISTRATOR_VALUE = 1;
        
        public const string ROLE_ADMINISTRATOR_TEXT = "管理员";
        /// <summary>
        /// 前台
        /// </summary>
        //public const int ROLE_RECEPTION_VALUE = 2;
        public const string ROLE_RECEPTION_TEXT = "前台";
        /// <summary>
        /// 收银
        /// </summary>
        //public const int ROLE_CASHER_VALUE = 3;
        public const string ROLE_CASHER_TEXT = "收银";
        /// <summary>
        /// 店长
        /// </summary>
        //public const int ROLE_MASTER_VALUE = 4;
        public const string ROLE_MASTER_TEXT = "店长";

        /// <summary>
        /// 管理员
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
        /// / 前台
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
        /// 收银
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
        /// 店长
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

        #region 下拉选则款的默认值 付强
        /// <summary>
        /// Select中没有被选中的时候，对应的值
        /// </summary>
        public const string SELECT_VALUE_NOT_SELECTED_KEY = "-1";
        public const string SELECT_VALUE_NOT_SELECTED_TEXT = "请选择";
        #endregion

        public const string KEY_CALLBACK = "cb";
        public const string DEFAULT_CALLBACK_SELECT_CUSTOMER = "selectCustomer";

        //判断父窗口，传过Tag标记
        public const string Tag = "1"; //表示父窗口来自CustomerList.aspx,Tag的其他值表示来自Order

        #region 价格类型 付强
        //门市价格
        public const int PRICE_TYPE_BASE = 0;
        //会员卡价格
        public const int PRICE_TYPE_MEMBER = 1;
        //行业价格
        public const int PRICE_TYPE_TRADE = 2;
        //特殊会员价格
        public const int PRICE_TYPE_SPECIAL = 3;
        #endregion

        #region 动作分类
        public const int ACTION_INIT = 1;
        public const int ACTION_SEARCH = 2;
        public const int ACTION_INSERT = 3;
        public const int ACTION_UPDATE = 4;
        public const int ACTION_DELETE = 5;
        public const int ACTION_OTHER = 6;
        #endregion

        #region 订单操作 付强
        public const int ORDER_OPERATOR_TAG_DISPATCH = 1;//表示分配
        public const int ORDER_OPERATOR_TAG_FINISHED = 2;//表示完工
        public const int ORDER_OPERATOR_TAG_REDO = 3;//表示返工
        public const int ORDER_OPERATOR_TAG_SUCCESSED = 4;//表示完成
        public const int ORDER_OPERATOR_TAG_BLANKOUT = 5;//表示作废
        public const int ORDER_OPERATOR_TAG_CANCELAFTERVERIFICATION = 6;//表示送货
        public const int ORDER_OPERATOR_TAG_REALFACTURE = 7;//实际制作
        #endregion 

        #region 送货状态 付强
        public const string DELIVERY_STATUS_FINISHED_VALUE = "1";
        public const string DELIVERY_STATUS_FINISHED_TEXT = "已完成";
        public const string DELIVERY_STATUS_UNFINISHED_VALUE = "2";
        public const string DELIVERY_STATUS_UNFINISHED_TEXT = "未完成";
        #endregion

        #region 空时间 付强
        public static readonly DateTime NULL_DATE_TIME = Convert.ToDateTime("9999-12-31 00:00:00");
        public static readonly DateTime NULL_MIN_DATE_TIME = Convert.ToDateTime("0001-01-01 00:00:00");
        #endregion 

		#region 参加活动时使用的价格基准
		/// <summary>
		/// 门市价格
		/// </summary>
		public const int CONCESSION_PRICE_BASE_RANGE_BASE = 1;
		/// <summary>
		/// 会员价格
		/// </summary>
		public const int CONCESSION_PRICE_BASE_RANGE_MEMBER = 2;
		/// <summary>
		/// 行业价格
		/// </summary>
		public const int CONCESSION_PRICE_BASE_RANGE_TRADE = 3;
		/// <summary>
		/// 最低价格
		/// </summary>
		public const int CONCESSION_PRICE_BASE_RANGE_LOWEST = 4;
		#endregion

        #region 是否需要发票     刘伟
        public const string NEED_TICKET_KEY = "Y";
        public const string NEED_TICKET_TEXT = "需要";

        public const string NEED_TICKET_NOT_KEY = "N";
        public const string NEED_TICKET_NOT_TEXT = "不需要";
        #endregion

        #region 发票领取状态 付强
        /// <summary>
        /// 欠发票
        /// </summary>
        public const string TAKE_TICKET_STATUS_OWE = "Y";
        /// <summary>
        /// 不欠 发票付清
        /// </summary>
        public const string TAKE_TICKET_STATUS_NOT_OWE = "N";
        /// <summary>
        /// 不需要给发票
        /// </summary>
        public const string TAKE_TICKET_STATUS_NOT_GIVE = "F";
        #endregion

        #region 卡状态   刘伟
        public const string MEMBER_CARD_STATE_NATURAL_KEY = "1";
        public const string MEMBER_CARD_STATE_NATURAL_TEXT = "正常";
        public const string MEMBER_CARD_STATE_REPORTLOSS_KEY = "2";
        public const string MEMBER_CARD_STATE_REPORTLOSS_TEXT = "挂失";
        public const string MEMBER_CARD_STATE_LOGOUT_KEY = "3";
        public const string MEMBER_CARD_STATE_LOGOUT_TEXT = "注销";
        #endregion

        #region 会员卡操作
        public const string MEMBER_CARD_OPERATE_GTANT_KEY = "1";
        public const string MEMBER_CARD_OPERATE_GTANT_TEXT = "发卡";
        public const string MEMBER_CARD_OPERATE_REPORTLOSS_KEY = "2";
        public const string MEMBER_CARD_OPERATE_REPORTLOSS_TEXT = "挂失";
        public const string MEMBER_CARD_OPERATE_LOGOUT_KEY = "3";
        public const string MEMBER_CARD_OPERATE_LOGOUT_TEXT = "注销";
        public const string MEMBER_CARD_OPERATE_RECOVERY_KEY = "4";
        public const string MEMBER_CARD_OPERATE_RECOVERY_TEXT = "恢复";
        public const string MEMBER_CARD_OPERATE_REISSUE_KEY = "5";
        public const string MEMBER_CARD_OPERATE_REISSUE_TEXT = "补卡";
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

        #region 客户状态  刘伟
        public const string CUSTOMER_VALIDATE_STATUS_KEY = "1";
        public const string CUSTOMER_VALIDATE_STATUS_TEXT = "确认";

        public const string CUSTOMER_NOT_VALIDATE_STATUS_KEY = "0";
        public const string CUSTOMER_NOT_VALIDATE_STATUS_TEXT = "未确定";

        #endregion
        
        #region 预付款付款限制
        public const string PREPAY_CAN_OVER="Y";
        public const string PREPAY_CAN_NOOVER = "N";
        #endregion 

        #region 通过区分获得颜色

        /// <summary>
        /// 黑白
        /// </summary>
        public const string COLOR_BLACKWHITE = "1";

        /// <summary>
        /// 彩色
        /// </summary>
        public const string COLOR_MULTICOLOR = "2";

		/// <summary>
		/// 未指定
		/// </summary>
		public const string COLOR_NOT_DEFINE ="3";

        public static string GetColorType(string value)
        {
            switch (value)
            {
                case "1":
                    return "黑白";
                case "2":
                    return "彩色";
				case "3":
					return "未指定";
                default:
                    return "";
            }
        }
        #endregion

        #region 查询条件(比大小)
        public static string QUERY_CONDITION_LESS_KEY = "0";
        public static string QUERY_CONDITION_LESS_VALUE = "<";
        public static string QUERY_CONDITION_LESS_TEXT = "小于";

        public static string QUERY_CONDITION_LESS_EQUAL_KEY = "1";
        public static string QUERY_CONDITION_LESS_EQUAL_VALUE = "<=";
        public static string QUERY_CONDITION_LESS_EQUAL_TEXT = "小于等于";

        public static string QUERY_CONDITION_EQUAL_KEY = "2";
        public static string QUERY_CONDITION_EQUAL_VALUE = "=";
        public static string QUERY_CONDITION_EQUAL_TEXT = "等于";

        public static string QUERY_CONDITION_GREATER_EQUAL_KEY = "3";
        public static string QUERY_CONDITION_GREATER_EQUAL_VALUE = ">=";
        public static string QUERY_CONDITION_GREATER_EQUAL_TEXT = "大于等于";

        public static string QUERY_CONDITION_GREATER_KEY = "4";
        public static string QUERY_CONDITION_GREATER_VALUE = ">";
        public static string QUERY_CONDITION_GREATER_TEXT = "大于";

        #endregion

        #region 性别 付强
        public const int SEX_MALE_VALUE = 0;
        public const string SEX_MALE_TEXT = "男";
        public const int SEX_FEMALE_VALUE = 1;
        public const string SEX_FEMALE_TEXT = "女";
        #endregion 

        #region 分页信息 付强
        /// <summary>
        /// 每页行数
        /// </summary>
        public const int ROW_COUNT_FOR_PAGER =20;
        /// <summary>
        /// 显示的页码数
        /// </summary>
        public const int SHOW_PAGE_COUNT = 10;


        #endregion

        #region LoggerName 付强
        public const string LOGGER_NAME = "Workflow.Web";

        #endregion

        #region 公司参数 付强
        public static long COMPANY_ID
        {
            get 
            {
                string companyId = ConfigurationManager.AppSettings["CompanyId"];
                if (StringUtils.IsEmpty(companyId))
                {
                    throw new ConfigurationErrorsException("公司ID不能配置为空!");
                }
                else
                {
                    
                    long x = 0;
                    bool convertSuccess = long.TryParse(companyId, out x);
                    if (!convertSuccess)
                    {
                        throw new ConfigurationErrorsException("公司ID必须为数字!");
                    }
                    return long.Parse(companyId);
                }
            }
        }
        #endregion

        #region 散客固定id

        /// <summary>
        /// 散客固定id
        /// </summary>
        //public const long scatteredClientId = 1;
        /// <summary>
        /// 散客固定id
        /// </summary>
        /// <remarks>
        /// 作    者:
        /// 创建时间:2009年8月7日9:54:09
        /// 修正履历:张晓林
        /// 修正时间:2009年8月7日9:54:45
        /// 修正描述:修正为适应各店散客Id的获取
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

        #region//散客的客户类型Id
        /// <summary>
        /// 获取散客的客户类型Id
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者:张晓林
        /// 创建时间:2009年8月12日10:16:40
        /// 修正履历:
        /// 修正时间:
        /// 修正描述:
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

        #region 机器上的表的类型
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

        #region 在程序参数表中的Key 付强
        /// <summary>
        /// 业绩比例在程序参数表中的Key
        /// </summary>
        public const string APPLICATION_ALLOT_RATE_KEY = "ACHIEVEMENT_ALLOT_RATE";
        /// <summary>
        /// 工作日起始时间
        /// </summary>
        public const string APPLICATION_START_TIME_KEY = "WORK_START_TIME";
        /// <summary>
        /// 工作日截止时间
        /// </summary>
        public const string APPLICATION_END_TIME_KEY = "WORK_END_TIME";
        /// <summary>
        /// 显示几天内工单
        /// </summary>
        public const string APPLICATION_DISPLAY_ORDER_INNER_DAY_COUNT_KEY = "DISPLAY_ORDER_INNER_DAY_COUNT";

        /// <summary>
        /// 各分店最大ID个数
        /// </summary>
        public const long MAX_ID_BASE = 100000000;

        #endregion

        #region 是否需要抄表 张晓林
        public const string NEED_IN_WATCH_KEY = "Y";
        public const string NEED_IN_WATCH_TEXT = "需要";

        public const string NEED_IN_WATCH_NOT_KEY = "N";
        public const string NEED_IN_WATCH_NOT_TEXT = "不需要";

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

        #region 区分的颜色 张晓林
        public const int COLOR_REPARTITION_NO_KEY = 0;
        public const string COLOR_REPARTITION_NO_TEXT = "未指定";

        public const int COLOR_REPARTITION_BLACK_KEY = 1;
        public const string COLOR_REPARTITION_BLACK_TEXT = "黑色";

        public const int COLOR_REPARTITION_COLOUR_KEY = 2;
        public const string COLOR_REPARTITION_COLOUR_TEXT = "彩色";

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

        #region 价格因素 张晓林
        /// <summary>
        /// 字段是否使用
        /// </summary>
        public const string IS_USED_KEY = "Y";
        /// <summary>
        /// 字段是否使用
        /// </summary>
        public const string IS_USED_TEXT = "是";

        /// <summary>
        /// 字段是否使用
        /// </summary>
        public const string NOT_USED_KEY = "N";
        /// <summary>
        /// 字段是否使用
        /// </summary>
        public const string NOT_USED_TEXT = "否";

        /// <summary>
        /// 获取价格因素使用状态
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
        /// 字段是否显示
        /// </summary>
        public const string IS_DISPLAY_KEY = "Y";
        /// <summary>
        /// 字段是否显示
        /// </summary>
        public const string IS_DISPLAY_TEXT = "是";

        /// <summary>
        /// 字段是否显示
        /// </summary>
        public const string NOT_DISPLAY_KEY = "N";
        /// <summary>
        /// 字段是否显示
        /// </summary>
        public const string NOT_DISPLAY_TEXT = "否";

        /// <summary>
        /// 获取价格因素显示状态
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

        #region 权限组的操作
        /// <summary>
        /// 操作权限
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

        #region 价格因素多选相显示文本 张晓林
        /// <summary>
        /// 允许多选的价格因素
        /// </summary>
        public static string[] ARR_MORE_SEL_TEXT = new string[] { "机器", "纸质", "规格" };
        #endregion

        #region//
        /// <summary>
        /// 根据分店获取业务类型Id(当不选择业务类型开单的时)
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者:张晓林
        /// 创建时间:2009年8月15日14:18:34
        /// 修正履历:
        /// 修正时间:
        /// 修正描述:
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
