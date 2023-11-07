using System;
using System.Collections.Generic;
using Workflow.Service.SystemMaintenance.System;
using Workflow.Action.SystemMaintenance.System.Model;

namespace Workflow.Action.SystemMaintenance.System
{
    /// <summary>
    /// 名   称:  SystemAction
    /// 功能概要: 系统基础数据管理Action
    /// 作    者: 张晓林
    /// 创建时间: 2009年4月29日17:30:01
    /// 修正履历:
    /// 修正时间:
    /// </summary>
    public class SystemAction
    {
        #region//ClassMember
        private SystemModel model = new SystemModel();
        public SystemModel Model 
        {
            set { model = value; }
            get { return model; }
        }
        private ISystemService systemService;
        public ISystemService SystemService 
        {
            set { systemService = value; }
        }
        #endregion

        #region// Id维护

        /// <summary>
        /// 名    称：InitIdData
        /// 功能概要：初始化Id数据
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月6日13:46:34
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        public void InitIdData() 
        {
            systemService.InitIdData();
        }

        /// <summary>
        /// 名    称：UpdateIdGenerator
        /// 功能概要：更新Id生成器数据
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月6日16:19:48
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        public void UpdateIdGenerator()
        {
            systemService.UpdateIdGenerator(model.IdGenerator);
        }

          /// <summary>
        /// 名    称：DeleteIdGenerator
        /// 功能概要：删除Id生成器数据
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月6日16:19:48
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        public void DeleteIdGenerator() 
        {
            systemService.DeleteIdGenerator(model.IdGenerator.Id);
        }
        #endregion

        #region//应用程序参数维护
        /// <summary>
        /// 名    称：AddApplicationProperty
        /// 功能概要：添加应用程序参数
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月8日13:52:10
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        public void AddApplicationProperty() 
        {
            systemService.AddApplicationProperty(model.ApplicationProperty);
        }

        /// <summary>
        /// 名    称：UpdateApplicationProperty
        /// 功能概要：更新应用程序参数
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月8日13:52:10
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        public void UpdateApplicationProperty()
        {
            systemService.UpdateApplicationProperty(model.ApplicationProperty);
        }

        /// <summary>
        /// 名    称：LogicDeleteApplicationProperty
        /// 功能概要：逻辑删除应用程序参数
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月8日13:52:10
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        public void LogicDeleteApplicationProperty()
        {
            systemService.LogicDeleteApplicationProperty(model.ApplicationProperty.Id);
        }

        /// <summary>
        /// 名    称：InitApplicationPropertyData
        /// 功能概要：初始化应用程序参数
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月8日13:52:10
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        public void InitApplicationPropertyData() 
        {
            systemService.InitApplicationPropertyData();
        }
        #endregion

        #region//公司维护
        /// <summary>
        /// 名    称：AddCompany
        /// 功能概要：添加公司
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月9日14:31:19
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        public void AddCompany()
        {
            systemService.AddCompany(model.Company);
        }

        /// <summary>
        /// 名    称：UpdateCompany
        /// 功能概要：更新公司
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月9日14:31:19
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        public void UpdateCompany()
        {
            systemService.UpdateCompany(model.Company);
        }

        /// <summary>
        /// 名    称：LogicDeleteCompany
        /// 功能概要：逻辑删除公司
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月9日14:31:19
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        public void LogicDeleteCompany()
        {
            systemService.LogicDeleteCompany(model.Company.Id);
        }
        #endregion

        #region//分店信息维护
        /// <summary>
        /// 名    称：AddBranchShop
        /// 功能概要：添加分店信息
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月11日11:50:59
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        public void AddBranchShop() 
        {
            systemService.AddBranchShop(model.BranchShop);
        }

        /// <summary>
        /// 名    称：UpdateBranchShop
        /// 功能概要：修改分店信息
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月11日11:50:59
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        public void UpdateBranchShop()
        {
            systemService.UpdateBranchShop(model.BranchShop);
        }

        /// <summary>
        /// 名    称：LogicDeleteBranchShop
        /// 功能概要：逻辑删除分店信息
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月11日11:50:59
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        public void LogicDeleteBranchShop()
        {
            systemService.LogicDeleteBranchShop(model.BranchShop.Id);
        }
        #endregion

        #region//积分信息维护

        /// <summary>
        /// 名    称：AddMarkingSetting
        /// 功能概要：增加积分
        /// 作    者: 张晓林
        /// 创建时间: 2009年10月28日13:26:25
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        public void AddMarkingSetting() 
        {
            systemService.AddMarkingSetting(model.MarkingSetting);
        }
        /// <summary>
        /// 名    称：UpdateMarkingSetting
        /// 功能概要：更新积分
        /// 作    者: 张晓林
        /// 创建时间: 2009年10月28日13:26:25
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        public void UpdateMarkingSetting()
        {
            systemService.UpdateMarkingSetting(model.MarkingSetting);
        }

        /// <summary>
        /// 名    称：DeleteMarkingSetting
        /// 功能概要：删除积分
        /// 作    者: 张晓林
        /// 创建时间: 2009年10月28日13:26:25
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        public void DeleteMarkingSetting()
        {
            systemService.DeleteMarkingSetting(model.MarkingSetting);
        }
        #endregion
    }
}
