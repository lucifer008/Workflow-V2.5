using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using System.Collections;

namespace Workflow.Service
{
    public interface IMasterDataService
    {
        /// <summary>
        /// 营销活动的基本数据
        /// </summary>
        /// <returns></returns>
        IList<Campaign> GetCampaign();
        /// <summary>
        /// 挂失方式的基本数据
        /// </summary>
        /// <returns></returns>
        IList<ReportLessMode> GetReportLessMode();
        /// <summary>
        /// 获取客户类型的基本数据
        /// </summary>
        /// <returns></returns>
        IList<CustomerType> GetCustomerTypes();

        /// <summary>
        /// 获取送货方式的基本数据
        /// </summary>
        /// <returns></returns>
        IList<LabelValue> GetDeliveryTypes();

        ///<summary>
        ///获取付款方式的基本数据
        ///</summary>
        ///<returns></returns>
        IList<LabelValue> GetPaymentTypes();

        ///<summary>
        ///业务类型的基本数据
        ///</summary>
        ///<returns></returns>
        IList<BusinessType> GetBusinessTypes();
       
        /// <summary>
        /// 获取客户级别的基本数据
        /// </summary>
        /// <returns></returns>
        IList<CustomerLevel> GetCustomerLevel();
        /// <summary>
        /// 获取行业信息
        /// </summary>
        /// <returns></returns>
        IList<MasterTrade> GetMasterTrade();
        /// <summary>
        /// 获取行业详细信息
        /// </summary>
        /// <returns></returns>
        IList<SecondaryTrade> GetSecondaryTrade();
        /// <summary>
        /// 获取印制要求
        /// </summary>
        /// <returns></returns>
        IList<PrintDemand> GetPrintDemandList();

        /// <summary>
        /// 获取价格因素
        /// </summary>
        /// <returns></returns>
        IList<PriceFactor> GetPriceFactors();

        /// <summary>
        /// 获取价格值一览
        /// </summary>
        /// <returns></returns>
        string GetFactorValueText(PriceFactor priceFactor);

        /// <summary>
        /// 获取雇员信息
        /// </summary>
        /// <returns></returns>
        IList<Employee> GetEmployeeList();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strOrderNo"></param>
        /// <returns></returns>
        IList<OrderItem> GetOrderItemIDByOrderNo(string strOrderNo);

        /// <summary>
        /// 获取卡级别一览
        /// </summary>
        /// <returns></returns>
        IList<MemberCardLevel> GetMemberCardLevels();
        /// <summary>
        /// 获得废张原因
        /// </summary>
        /// <returns></returns>
        IList<TrashReason> GetTrashReasonList();
        
        /// <summary>
        /// 获得职位一览
        /// </summary>
        /// <returns></returns>
        IList<Position> GetPositionList();

        /// <summary>
        /// 获得机器一览
        /// </summary>
        /// <returns></returns>
        IList<Machine> GetMachineList();

        /// <summary>
        /// 获得制质一览
        /// </summary>
        /// <returns></returns>
        IList<PaperType>GetPaperTypeList();

        /// <summary>
        /// 获得纸型一览
        /// </summary>
        /// <returns></returns>
        IList<PaperSpecification> GetPaperSpecificationList();

        /// <summary>
        /// 根据公司ID获取其下所有子公司
        /// </summary>
        /// <param name="companyId"></param>
        IList<BranchShop> GetAllBranchShopInfo(long companyId);

        /// <summary>
        /// 检查当前用户名与密码是否正确，并将结果做以返回，且在登陆成功后绑定当前用户信息到ThreadLocalUtils.CurrentSession.CurrentUser上
        /// </summary>
        /// <param name="user"></param>
        /// <returns>1:用户名或密码错误 2:用户已经登陆 3:登陆成功</returns>
        int CheckUserNameAndPassword(User user);
		
		/// <summary>
		/// 获取所有用户
		/// </summary>
		/// <returns></returns>
		IList<User> GetAllUser(User user);

	
        /// <summary>
        /// 检查是否有权限
        /// </summary>
        //bool GetPermission(User user);

        string GetEmployeeNameByUserId(User user);

        //void LogoutUser(User user);

        int LogoutLoginUser(User user);
        /// <summary>
        /// 获取所有雇员信息
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年1月8日
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        IList<Employee> SelectAllEmployee();


        /// <summary>
        /// 方法名称: GetUsedPriceFactors
        /// 功能概要: 获取当前正在使用的价格因素
        /// 作    者: 陈汝胤
        /// 创建时间: 2009-1-9
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        IList<PriceFactor> GetUsedPriceFactors(long businessTypeId);

        /// <summary>
        /// 获取所有雇员列表
        /// </summary>
        /// <returns></returns>
        IList<Role> GetRoleList();

        void ExitLogoutUser(User user);

        /// <summary>
        /// 添加用户授权记录
        /// </summary>
        /// <remarks>
        ///  作    者：张晓林
        ///  创建时间:2009年12月11日16:14:33
        ///  修正履历:
        ///  修正时间:
        /// </remarks>
        void InsertAccreditRecord(AccreditRecord accreditRecord);

        /// <summary>
        ///检查当前用户是否最高管理员 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作  者: 张晓林
        /// 日  期: 2010年5月8日17:05:04
        /// </remarks>
        bool CheckIsBestUser(User user);
    }
}
