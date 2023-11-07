using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Workflow.Util;
using Workflow.Support;
using Workflow.Service;
using Workflow.Da.Domain;
using Workflow.Action.Model;
using Workflow.Service.CustomerManager;
/// <summary>
/// 名    称: SelectCustomerAction
/// 功能概要: 客户查询Action
/// 作    者: 张晓林
/// 创建时间: 2009-02-04
/// 修正履历: 
/// 修正时间: 
/// </summary>
namespace Workflow.Action
{
    public class SelectCustomerAction
    {
        #region Model
        private SelectCustomerModel model = new SelectCustomerModel();

        /// <summary>
        /// Gets or sets the select customer model.
        /// </summary>
        /// <value>The select customer model.</value>
        public SelectCustomerModel Model
        {
            get { return model; }
        }
        #endregion

        #region 注入Service
        private ICustomerService customerService;
        /// <summary>
        /// Sets the customer service.
        /// </summary>
        /// <value>The customer service.</value>
        public ICustomerService CustomerService
        {
            set { customerService = value; }
        }

        private ISearchCustomerService searchCustomerService;
        /// <summary>
        /// Sets the customer service.
        /// </summary>
        /// <value>The customer service.</value>
        public ISearchCustomerService SearchCustomerService
        {
            set { searchCustomerService = value; }
        }

        private IMasterDataService masterDataService;
        public IMasterDataService MasterDataService
        {
            set { masterDataService = value; }
        }

        #endregion

        #region 显示页面要初始化的数据
        /// <summary>
        /// 方法名称: GetInitializtionInfo
        /// 功能概要: 显示页面要初始化的数据
        /// 作    者: liuwei
        /// 创建时间: 2007-9-11
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        public virtual void Init()
        {
            model.MasterTradeList = masterDataService.GetMasterTrade();
            model.CustomerTypeList = masterDataService.GetCustomerTypes();
            model.SecondaryTradeList = masterDataService.GetSecondaryTrade();
            model.CustomerLevelList = masterDataService.GetCustomerLevel();
        }
        #endregion

        #region 查询结果
        /// <summary>
        /// 方法名称: GetQueryCustomerInfo
        /// 功能概要: 查询结果
        /// 作    者: liuwei
        /// 创建时间: 2007-9-13
        /// 修正履历: 
        /// 修正时间: 2007-9-27
        /// </summary>
        public virtual void QueryCustomer(int currentPageIndex)
        {
            Hashtable condition = new Hashtable();
            ////判断是否应该写入
            if (!StringUtils.IsEmpty(model.Name))
            {
                condition.Add("Name", "%" + model.Name + "%");
            }
            if (model.SecondaryTradeId != long.Parse(Constants.SELECT_VALUE_NOT_SELECTED_KEY)
                && 0!=model.SecondaryTradeId)
            {
                condition.Add("SecondaryTradeId", model.SecondaryTradeId);
            }

            if (model.CustomerLevelId != long.Parse(Constants.SELECT_VALUE_NOT_SELECTED_KEY)
                && 0!=model.CustomerLevelId)
            {
                condition.Add("CustomerLevelId", model.CustomerLevelId);
            }

            if (model.CustomerTypeId != long.Parse(Constants.SELECT_VALUE_NOT_SELECTED_KEY)
                && 0!=model.CustomerTypeId)
            {
                condition.Add("CustomerTypeId", model.CustomerTypeId);
            }
            if(-1!=model.PayType && 0!=model.PayType)
            {
                condition.Add("PayType",model.PayType);
            }
            if (!StringUtils.IsEmpty(model.LinkMan))
            {
                condition.Add("LinkMan","%"+ model.LinkMan +"%");
            }

            if (!StringUtils.IsEmpty(model.BeginDate))
            {
                condition.Add("BeginDate", DateUtils.ToDateTime(model.BeginDate));
            }

            if (!StringUtils.IsEmpty(model.EndDate))
            {
                DateTime endDate = DateUtils.ToDateTime(model.EndDate);
                endDate.AddDays(1);
                condition.Add("EndDate", endDate);
            }

            if (!StringUtils.IsEmpty(model.LinkMan))
            {
                condition.Add("NeedLinkMan", "true");
            }
            if (!StringUtils.IsEmpty(model.MemberCardNo))
            {
                condition.Add("MemberCardNo",model.MemberCardNo);
            }
            condition.Add("RowCount", Constants.ROW_COUNT_FOR_PAGER);
            condition.Add("PagerCount", currentPageIndex);
            //是否显示客户：散客和学生
            if (null != model.IsNotDisplay)
            {
                condition.Add("IsNotDisplay", "true");
            }
            model.CustomerList = searchCustomerService.SearchCustomer(condition);
        }
        /// <summary>
        /// 获取客户记录数目
        /// </summary>
        /// <returns></returns>
        public long GetCustomerCount()
        {
            Hashtable condition = new Hashtable();
            ////判断是否应该写入
            if (!StringUtils.IsEmpty(model.Name))
            {
                condition.Add("Name", "%" + model.Name + "%");
            }
            if (model.SecondaryTradeId != long.Parse(Constants.SELECT_VALUE_NOT_SELECTED_KEY)
                && 0!= model.SecondaryTradeId)
            {
                condition.Add("SecondaryTradeId", model.SecondaryTradeId);
            }

            if (model.CustomerLevelId != long.Parse(Constants.SELECT_VALUE_NOT_SELECTED_KEY)
                && 0!=model.CustomerLevelId)
            {
                condition.Add("CustomerLevelId", model.CustomerLevelId);
            }

            if (model.CustomerTypeId != long.Parse(Constants.SELECT_VALUE_NOT_SELECTED_KEY)
                && 0 != model.CustomerTypeId)
            {
                condition.Add("CustomerTypeId", model.CustomerTypeId);
            }
            if (-1 != model.PayType && 0!=model.PayType)
            {
                condition.Add("PayType", model.PayType);
            }
            if (!StringUtils.IsEmpty(model.LinkMan))
            {
                condition.Add("LinkMan", "%" + model.LinkMan + "%");
            }

            if (!StringUtils.IsEmpty(model.BeginDate))
            {
                condition.Add("BeginDate", DateUtils.ToDateTime(model.BeginDate));
            }

            if (!StringUtils.IsEmpty(model.EndDate))
            {
                DateTime endDate = DateUtils.ToDateTime(model.EndDate);
                endDate.AddDays(1);
                condition.Add("EndDate", endDate);
            }

            if (!StringUtils.IsEmpty(model.LinkMan))
            {
                condition.Add("NeedLinkMan", "true");
            }
            //是否显示客户：散客和学生
            if (null != model.IsNotDisplay)
            {
                condition.Add("IsNotDisplay", "true");
            }
            if (!StringUtils.IsEmpty(model.MemberCardNo))
            {
                condition.Add("MemberCardNo", model.MemberCardNo);
            }
            return searchCustomerService.GetCustomerCount(condition);
        }
        #endregion
    }
}
