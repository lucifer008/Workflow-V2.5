using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Workflow.Util;
using Workflow.Service;
using Workflow.Action.Model;
using Workflow.Support;
using Workflow.Service.CustomerManager;
using Workflow.Service.MemberCardManager;
/// <summary>
/// 名    称: SearchMemberCardAction
/// 功能概要: 会员卡查询的Action
/// 作    者: 张晓林
/// 创建时间: 2009-01-23
/// 修正履历: 
/// 修正时间: 
/// </summary>
namespace Workflow.Action.Membercard
{
    public class SearchMemberCardAction
    {
        #region Model
        private MemberCardModel model = new MemberCardModel();
        public MemberCardModel Model
        {
            get { return model; }
        }
        #endregion 

        #region 注入Service

        private IMasterDataService masterDataService;
        /// <summary>
        /// Gets or sets the master date service
        /// </summary>
        /// <value>The master date service</value>
        public IMasterDataService MasterDataService
        {
            set { masterDataService = value; }
        }

        private ISearchMemberCardService searchMemberCardService;
        public ISearchMemberCardService SearchMemberCardService
        {
            set { searchMemberCardService = value; }
        }


        private ISearchCustomerService searchCustomerService;
        /// <summary>
        /// Gets or sets the customer service
        /// </summary>
        /// <value>The customer service</value>
        public ISearchCustomerService SearchCustomerService
        {
            set { searchCustomerService = value; }
        }
        #endregion

        #region 获得基本数据
        /// <summary>
        /// 方法名称: Init
        /// 功能概要: 获得基本数据
        /// 作    者: liuwei
        /// 创建时间: 2007-9-30
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param></param>
        /// 
        public virtual void Init()
        {
            model.MasterTradeList = masterDataService.GetMasterTrade();
            model.SecondaryTradeList = masterDataService.GetSecondaryTrade();
            model.CustomerLevelList = masterDataService.GetCustomerLevel();
            model.CustomerTypeList = masterDataService.GetCustomerTypes();
            model.PaymentTypes = masterDataService.GetPaymentTypes();
        }
        #endregion

        #region 得到会员卡级别
        /// <summary>
        /// 方法名称: GetMemberCardLevel
        /// 功能概要: 得到会员卡级别
        /// 作    者: liuwei
        /// 创建时间: 2007-9-29
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param></param>
        /// 
        public virtual void GetMemberCardLevel()
        {
            model.MemberCardLevelList = masterDataService.GetMemberCardLevels();
        }
        #endregion

        #region  //查询会员卡信息
        /// <summary>
        /// 方法名称: SearchMemberCard
        /// 功能概要: 查询会员卡信息
        /// 作    者: liuwei
        /// 创建时间: 2007-9-29
        /// 修正履历: 张晓林
        /// 修正时间: 2009年2月12日
        ///            增加分页功能
        /// </summary>
        /// <param></param>
        /// 
        public virtual void SearchMemberCard(int currentPageIndex)
        {
            System.Collections.Hashtable condition = new System.Collections.Hashtable();
            //判断是否应该写入
            condition.Add("PageIndex", currentPageIndex);
            condition.Add("RowCount", Constants.ROW_COUNT_FOR_PAGER);
            if (null != model.CustomerName && model.CustomerName != "")
            {
                condition.Add("CustomerName", model.CustomerName);
            }
            if (null != model.MemberState && model.MemberState != "-1")
            {
                condition.Add("MemberState", model.MemberState);
            }

            if (null != model.MemberCardNo && model.MemberCardNo != "")
            {
                condition.Add("MemberCardNo", model.MemberCardNo);
            }

            if (null != model.MemberCardLevel && model.MemberCardLevel.Id != -1)
            {
                condition.Add("MemberCardLevelId", model.MemberCardLevel.Id);
            }

            if (null != model.BeginDate && model.BeginDate != "")
            {
                condition.Add("BeginDate", DateUtils.ToDateTime(model.BeginDate));
            }

            if (null != model.EndDate && model.EndDate != "")
            {
                DateTime endDate = DateUtils.ToDateTime(model.EndDate);
                endDate.AddDays(1);
                condition.Add("EndDate", endDate);
            }
            if (condition.Count > 2)
            {
                model.MemberCardList = searchMemberCardService.SearchMemberCard(condition);
            }
        }

         /// <summary>
        /// 名    称: SearchMemberCardRowCount
        /// 功能概要: 查询会员卡信息记录数
        /// 作    者: 张晓林
        /// 创建时间: 2009-02-11
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public long SearchMemberCardRowCount() 
        {
            Hashtable condition = new Hashtable();
            if (null != model.CustomerName && model.CustomerName != "")
            {
                condition.Add("CustomerName", model.CustomerName);
            }
            if (null != model.MemberState && model.MemberState != "-1")
            {
                condition.Add("MemberState", model.MemberState);
            }

            if (null != model.MemberCardNo && model.MemberCardNo != "")
            {
                condition.Add("MemberCardNo", model.MemberCardNo);
            }

            if (null != model.MemberCardLevel && model.MemberCardLevel.Id != -1)
            {
                condition.Add("MemberCardLevelId", model.MemberCardLevel.Id);
            }

            if (null != model.BeginDate && model.BeginDate != "")
            {
                condition.Add("BeginDate", DateUtils.ToDateTime(model.BeginDate));
            }

            if (null != model.EndDate && model.EndDate != "")
            {
                DateTime endDate = DateUtils.ToDateTime(model.EndDate);
                endDate.AddDays(1);
                condition.Add("EndDate", endDate);
            }
            if (condition.Count > 0)
            {
                return searchMemberCardService.SearchMemberCardRowCount(condition);
            }
            else 
            {
                return 0;
            }
        } 
        #endregion

        #region 通过MemberCardNo查询会员卡信息(只查询正常状态的卡)
        /// <summary>
        /// 通过MemberCardNo查询会员卡信息
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: liuwei
        /// 创建时间: 2007-10-7
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public virtual void SearchMemberCardByCardNo()
        {
            model.MemberCard = searchMemberCardService.SearchMemberCardByCardNo(model.MemberCardNo);
            if (model.MemberCard != null)
            {
                model.Customer = searchCustomerService.SearchCustomerById(model.MemberCard.CustomerId);
            }
        }
        #endregion

        #region //根号一会员ID查询会员消费金额
        /// <summary>
        /// 根据会员Id查询会员消费金额 
        /// </summary>
        /// <param name="memberCardId">会员Id</param>
        /// <returns>会员消费金额</returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年4月6日9:46:35
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public decimal SearchMemberCardConsumeAmount(long memberCardId)
        {
            Workflow.Da.Domain.MemberCard memberCard=searchMemberCardService.SearchMemberCardConsumeAmount(memberCardId);
            if (null != memberCard) 
            {
                return memberCard.ConsumeAmount;
            }
            return 0;
        }
        #endregion

        #region  通过Id查询会员卡信息，并查询会员卡中持卡人信息
        /// <summary>
        /// 方法名称: SearchMemberCardAndCustomerById
        /// 功能概要: 通过Id查询会员卡信息，并查询会员卡中持卡人信息
        /// 作    者: liuwei
        /// 创建时间: 2007-9-29
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param></param>
        /// 
        public virtual void SearchMemberCardAndCustomerById()
        {
            model.MemberCard = searchMemberCardService.SearchMemberCardById(model.Id);
            long memberCardId = model.MemberCard.Id;
            model.MemberCard.ConsumeAmount = searchMemberCardService.SearchMemberCardConsumeAmount(memberCardId).ConsumeAmount;
            model.Customer = searchCustomerService.SearchCustomerById(model.MemberCard.CustomerId);
        }
        #endregion

        #region 通过Id查询会员卡信息
        /// <summary>
        /// 方法名称: SearchMemberCardById
        /// 功能概要: 通过Id查询会员卡信息
        /// 作    者: liuwei
        /// 创建时间: 2007-10-7
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param></param>
        /// 
        public virtual void SearchMemberCardById()
        {
            model.MemberCard = searchMemberCardService.SearchMemberCardById(model.Id);
        }

        /// <summary>
        /// 方法名称: SearchMemberById
        /// 功能概要: 通过Id查询会员信息
        /// 作    者: 张晓林
        /// 创建时间: 2009年2月12日
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param></param>
        /// 
        public void SearchMemberById()
        {
            model.MemberCard = searchMemberCardService.SearchMemberById(model.Id);
        }
        #endregion

        #region  通过IdentityCard查询MemberCard信息
        /// <summary>
        /// 方法名称: SearchMemberCardByIdentityCard
        /// 功能概要: 通过IdentityCard查询MemberCard信息
        /// 作    者: liuwei
        /// 创建时间: 2007-10-5
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param></param>
        /// 
        public virtual void SearchMemberCardByIdentityCard(Hashtable hashtable)
        {
            model.MemberCardList = searchMemberCardService.SearchMemberCardByIdentityCard(hashtable);
        }
        #endregion

        #region //会员卡详情查询
        /// <summary>
        /// 通过MemberCardNo查询会员卡信息
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: liuwei
        /// 创建时间: 2007-10-23
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public virtual void SearchAllMemberCardByCardNo()
        {
            model.MemberCard = searchMemberCardService.SearchAllMemberCardByCardNo(model.MemberCardNo);
            if (model.MemberCard != null)
            {
                long memberCardId = model.MemberCard.Id;
                model.MemberCard.ConsumeAmount = searchMemberCardService.SearchMemberCardConsumeAmount(memberCardId).ConsumeAmount;
                model.Customer = searchCustomerService.SearchCustomerById(model.MemberCard.CustomerId);
            }
        }

        /// <summary>
        /// 通过MemberCardNo查询该卡参加的营销活动名称
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: liuwei
        /// 创建时间: 2007-10-23
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public virtual void SearchCampaignNameByMemberCardNo()
        {
            model.CampaignNames = searchMemberCardService.SearchMemberCardCampaign(model.MemberCardNo);
        }
        #endregion

        #region //查询会员充值记录
        /// <summary>
        /// 查询会员充值记录
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: liuwei
        /// 创建时间: 2007-10-23
        /// 修正履历:张晓林
        /// 修正时间:2009年4月1日10:09:14
        /// </remarks>
        public virtual void SearchChargeRecord()
        {
            Hashtable condition = new Hashtable();

            if (!StringUtils.IsEmpty(model.BeginDate))
            {
                condition.Add("BeginDate", model.BeginDate);
            }

            if(!StringUtils.IsEmpty(model.EndDate))
            {
                condition.Add("EndDate", model.EndDate);
            }

            if (!StringUtils.IsEmpty(model.MemberCardNo))
            {
                condition.Add("MemberCardNo", model.MemberCardNo);
            }
            condition.Add("CurrentPageIndex",model.CurrentPageIndex-1);
            condition.Add("RowCount", model.RowCount);
            model.MemberCardConcessionList = searchMemberCardService.SearchChargeRecord(condition);
            model.MemberCardConcessionRecordCount = (int)searchMemberCardService.SearchChargeRecordRowCount(condition);
            ////会员充值
            //model.MemberCardConcessionList = searchMemberCardService.SearchCRMemberCardConcession(condition);
            ////会员卡
            //model.MemberCardList = searchMemberCardService.SearchCRMemberCard(condition);
            ////营销活动名称
            //model.CampaignNames = searchMemberCardService.GetCampaignNames(model.MemberCardConcessionList);
        }

        #endregion

        #region //查询会员卡操作记录
        /// <summary>
        /// 查询会员卡操作记录
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: liuwei
        /// 创建时间: 2007-10-24
        /// 修正履历:张晓林
        /// 修正时间:2009年4月6日11:35:55
        /// 修正描述:完善查询功能
        /// </remarks>
        public void SearchOperateLog()
        {
            Hashtable condition = new Hashtable();

            if (!StringUtils.IsEmpty(model.BeginDate))
            {
                condition.Add("BeginDate", model.BeginDate);
            }

            if(!StringUtils.IsEmpty(model.EndDate))
            {
                 condition.Add("EndDate", model.EndDate);
            }
            if (!StringUtils.IsEmpty(model.MemberCardNo))
            {
                condition.Add("MemberCardNo", "%"+model.MemberCardNo+"%");
            }
            condition.Add("RowCount",Constants.ROW_COUNT_FOR_PAGER);
            condition.Add("CurrentPageIndex", model.CurrentPageIndex - 1);
            model.MemberCardList = searchMemberCardService.SearchOperateLog(condition);
            model.MemberCardConcessionRecordCount = searchMemberCardService.SearchOperateLogRowCount(condition);
            model.MemberCardPrintList = searchMemberCardService.SearchOperateLogPrint(condition);
            //model.membercard
            //model.MemberOperateLogList = searchMemberCardService.SelectORMemberOperateLog(condition);
            //model.MemberCardList = searchMemberCardService.SelectORMemberCard(condition);

        }
        #endregion

        #region //查询会员卡换卡记录
        /// <summary>
        /// 查询会员卡换卡记录
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: liuwei
        /// 创建时间: 2007-10-24
        /// 修正履历:张晓林
        /// 修正时间:2009年4月2日10:09:29
        /// 描    述:完善查询功能，增加分页处理
        /// </remarks>
        public void SearchChangeMemberCard()
        {
            Hashtable condition = new Hashtable();

            if (!StringUtils.IsEmpty(model.BeginDate))
            {
                condition.Add("BeginDate", model.BeginDate);
            }
            if (!StringUtils.IsEmpty(model.EndDate))
            {
                 condition.Add("EndDate", model.EndDate);
            }

            if (!StringUtils.IsEmpty(model.MemberCardNo))
            {
                condition.Add("NewMemberCardNo", "%"+model.MemberCardNo+"%");
            }
            condition.Add("RowCount",Constants.ROW_COUNT_FOR_PAGER);
            condition.Add("CurrentPageIndex",model.CurrentPageIndex-1);
            model.ChangeMemberCardList = searchMemberCardService.SearchChangeMemberCard(condition);
            model.MemberCardConcessionRecordCount = searchMemberCardService.SearchChangeMemberCardRowCount(condition);
            model.ChangeMemberCardListPrint = searchMemberCardService.SearchChangeMemberCardPrint(condition);//获取打印输出记录
            //model.ChangeMemberCardList = searchMemberCardService.SelectCMCChangeMemberCard(condition);
            //model.MemberCardList = searchMemberCardService.SelectCMCMemberCard(condition);
        }
        #endregion

        #region 根据卡号和顾客Id 及卡状态判断卡号是否存在
        /// <summary>
        /// 根据卡号和顾客Id 及卡状态判断卡号是否存在
        /// </summary>
        /// <returns></returns>
        public void CheckMemberCardByNoAndCustomerId()
        {
            Hashtable hashCondition = new Hashtable();
            hashCondition.Add("MemberCardNo", model.MemberCard.MemberCardNo);
            hashCondition.Add("CustomerId", model.MemberCard.CustomerId);
            model.MemberCardList = searchMemberCardService.CheckMemberCardNo(hashCondition);
        }
        #endregion

        #region 获取挂失方式的信息
        /// <summary>
        /// 获取挂失方式的信息
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: liuwei
        /// 创建时间: 2007-10-6
        /// 修正履历:
        /// 修正时间:
        /// </remarks>	

        public virtual void GetReportLessMode()
        {
            model.ReportLessModeList = masterDataService.GetReportLessMode();
        }
        #endregion

        #region //会员消费统计
        /// <summary>
        /// 会员消费统计
        /// </summary>
        /// <remarks>
        /// 作    者: 
        /// 创建时间: 
        /// 修正履历:张晓林
        /// 修正时间:2009年4月3日10:50:13
        /// 描    述:完善查询功能，增加分页处理
        /// </remarks>
        public void GetMemberCardConsume()
        {
            model.OrderList = searchMemberCardService.GetMemberCardConsume(model.Order);
            model.MemberCardConcessionRecordCount = searchMemberCardService.GetMemberCardConsumeRowCount(model.Order);
            model.OrderTempList = searchMemberCardService.GetMemberCardConsumePrint(model.Order);
        }
        #endregion

        #region //获取会员参加优惠的业务类型类型列表
        /// <summary>
        /// 获取会员参加优惠的业务类型类型列表
        /// </summary>
        /// <remarks>
        /// 作    者: 
        /// 创建时间: 
        /// 修正履历:张晓林
        /// 修正时间:2009年4月15日13:54:16
        /// 描    述:
        /// </remarks>
        public void GetMemberCardConcessionBaseBusniessInfo(long memberCardId) 
        {
            model.MemberCardConcessionList = searchMemberCardService.GetMemberCardConcessionBaseBusniessInfo(memberCardId);
        }
        #endregion 

        #region //获取会员卡优惠方案业务明细
        /// <summary>
        /// 获取会员卡优惠方案业务明细
        /// </summary>
        /// <remarks>
        /// 作    者: 
        /// 创建时间: 
        /// 修正履历:张晓林
        /// 修正时间:2009年4月15日13:54:16
        /// 描    述:
        /// </remarks>
        public void GetMemberCardBaseBusniessList(long baseBusniessTypeId) 
        {
            model.BaseBusinessTypePriceSet= searchMemberCardService.GetMemberCardBaseBusniessSet(baseBusniessTypeId);
        }
        #endregion
    }
}
