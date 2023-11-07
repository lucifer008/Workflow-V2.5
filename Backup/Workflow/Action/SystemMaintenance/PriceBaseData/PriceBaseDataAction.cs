using System;
using System.Collections.Generic;
using Workflow.Service.SystemMaintenance.PriceBaseData;
using Workflow.Action.SystemMaintenance.PriceBaseData.Model;

namespace Workflow.Action.SystemMaintenance.PriceBaseData
{
    /// <summary>
    /// 名   称:  PriceBaseDataAction
    /// 功能概要: 基础价格数据管理Action
    /// 作    者: 张晓林
    /// 创建时间: 2009年4月28日15:18:54
    /// 修正履历:
    /// 修正时间:
    /// </summary>
    public class PriceBaseDataAction
    {
        #region //注入Service
        private PriceBaseDataModel model = new PriceBaseDataModel();
        public PriceBaseDataModel Model
        {
            set { model = value; }
            get { return model; }
        }

        private IPriceBaseService priceBaseService;
        public IPriceBaseService PriceBaseService 
        {
            set { priceBaseService = value; }
        }
        #endregion

        #region //业务类型维护
        /// <summary>
        /// 名    称：AddBusinessType
        /// 功能概要: 新增业务类型
        /// 作    者: 张晓林
        /// 创建时间: 2009年4月28日17:13:34
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void AddBusinessType()
        {
            priceBaseService.AddBusinessType(model.BusinessType);
        }

        /// <summary>
        /// 名    称：UpdateBusinessType
        /// 功能概要: 修改业务类型
        /// 作    者: 张晓林
        /// 创建时间: 2009年4月28日17:13:34
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void UpdateBusinessType()
        {
            priceBaseService.UpdateBusinessType(model.BusinessType);
        }

        /// <summary>
        /// 名    称：DeleteBusinessType
        /// 功能概要: 删除业务类型
        /// 作    者: 张晓林
        /// 创建时间: 2009年4月28日17:13:34
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void DeleteBusinessType()
        {
            priceBaseService.DeleteBusinessType(model.BusinessType.Id);
        }
        #endregion

        #region //加工内容维护
        /// <summary>
        /// 名    称:AddProcessContent
        /// 功能概要:新增加工内容
        /// 作    者:张晓林
        /// 创建时间:2009年4月30日10:23:38
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void AddProcessContent() 
        {
            priceBaseService.AddProcessContent(model.ProcessContent,model.ProcessContentAchievementRate);
        }

        /// <summary>
        /// 名    称:UpdateProcessContent
        /// 功能概要:修改加工内容
        /// 作    者:张晓林
        /// 创建时间:2009年4月30日10:23:38
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void UpdateProcessContent() 
        {
            priceBaseService.UpdateProcessContent(model.ProcessContent, model.ProcessContentAchievementRate);
        }

        /// <summary>
        /// 名    称:DeleteProcessContent
        /// 功能概要:删除加工内容
        /// 作    者:张晓林
        /// 创建时间:2009年4月30日10:23:38
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void DeleteProcessContent() 
        {
            priceBaseService.DeleteProcessContent(model.ProcessContent.Id);
        }

        /// <summary>
        /// 名    称:GetProcessContentAchievementRate
        /// 功能概要:获取加工内容的业绩
        /// 作    者:张晓林
        /// 创建时间:2009年6月5日11:52:04
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void GetProcessContentAchievementRate() 
        {
            model.ProcessContentAchievementRate = priceBaseService.GetProcessContentAchievementRate(model.ProcessContent.Id);
        }
        #endregion

        #region//机器类型
        /// <summary>
        /// 名    称: AddMachineType
        /// 功能概要: 新增机器类型
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月4日10:31:46
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void AddMachineType() 
        {
            priceBaseService.AddMachineType(model.MachineType);
        }

        /// <summary>
        /// 名    称: UpdateMachineType
        /// 功能概要: 更新机器类型
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月4日10:35:23
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void UpdateMachineType()
        {
            priceBaseService.UpdateMachineType(model.MachineType);
        }

        /// <summary>
        /// 名    称: LogicDeleteMachineType
        /// 功能概要: 逻辑删除机器类型
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月4日10:35:23
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void LogicDeleteMachineType() 
        {
            priceBaseService.LogicDeleteMachineType(model.MachineType.Id);
        }
        #endregion

        #region//机器
        /// <summary>
        /// 名    称: AddMachine
        /// 功能概要: 新增机器
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月4日14:54:15
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void AddMachine()
        {
            priceBaseService.AddMachine(model.Machine);
        }

        /// <summary>
        /// 名    称: UpdateMachine
        /// 功能概要: 更新机器类型
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月4日14:54:15
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void UpdateMachine()
        {
            priceBaseService.UpdateMachine(model.Machine);
        }

        /// <summary>
        /// 名    称: LogicDeleteMachine
        /// 功能概要: 逻辑删除机器
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月4日14:54:15
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void LogicDeleteMachine()
        {
            priceBaseService.LogicDeleteMachine(model.Machine.Id);
        }
        #endregion

        #region//纸型

        /// <summary>
        /// 名    称: AddPaperSpecification
        /// 功能概要: 新增纸型
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月5日15:31:55
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void AddPaperSpecification() 
        {
            priceBaseService.AddPaperSpecification(model.PaperSecification);
        }

        /// <summary>
        /// 名    称: UpdateSpecification
        /// 功能概要: 更新纸型
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月5日15:31:55
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void UpdateSpecification() 
        {
            priceBaseService.UpdateSpecification(model.PaperSecification);
        }

        /// <summary>
        /// 名    称: LogicDeleteSpecification
        /// 功能概要: 逻辑删除纸型
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月5日15:31:55
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void LogicDeleteSpecification() 
        {
            priceBaseService.LogicDeleteSpecification(model.PaperSecification.Id);
        }
        #endregion

        #region//纸质
        /// <summary>
        /// 名    称: AddPaperType
        /// 功能概要: 新增纸质
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月6日10:14:51
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void AddPaperType() 
        {
            priceBaseService.AddPaperType(model.PaperType);
        }

        /// <summary>
        /// 名    称: UpdatePaperType
        /// 功能概要: 修改纸质
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月6日10:14:51
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void UpdatePaperType() 
        {
            priceBaseService.UpdatePaperType(model.PaperType);
        }

        /// <summary>
        /// 名    称: LogicDeletePaperType
        /// 功能概要: 逻辑删除纸质
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月6日10:14:51
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void LogicDeletePaperType() 
        {
            priceBaseService.LogicDeletePaperType(model.PaperType.Id);
        }
        #endregion

        #region//其他价格因素及值
        /// <summary>
        /// 名    称: AddPriceFactor
        /// 功能概要: 新增价格因素
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月6日16:03:51
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void AddPriceFactor() 
        {
            priceBaseService.AddPriceFactor(model.PriceFactor);
        }

        /// <summary>
        /// 名    称: UpdatePriceFactor
        /// 功能概要: 修改价格因素
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月6日16:03:51
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void UpdatePriceFactor()
        {
            priceBaseService.UpdatePriceFactor(model.PriceFactor);
        }

        /// <summary>
        /// 名    称: LogicDeletePriceFactor
        /// 功能概要: 逻辑删除价格因素
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月6日16:03:51
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void LogicDeletePriceFactor()
        {
            priceBaseService.LogicDeletePriceFactor(model.PriceFactor.Id);
        }

        /// <summary>
        /// 名    称: AddFactorValue
        /// 功能概要: 新增价格因素值
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月6日16:03:51
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void AddFactorValue()
        {
            priceBaseService.AddFactorValue(model.FactorValue);
        }

        /// <summary>
        /// 名    称: UpdateFactorValue
        /// 功能概要: 更新价格因素值
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月6日16:03:51
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void UpdateFactorValue()
        {
            priceBaseService.UpdateFactorValue(model.FactorValue);
        }

        /// <summary>
        /// 名    称: LogicDeleteFactorValue
        /// 功能概要: 逻辑删除价格因素值
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月6日16:03:51
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void LogicDeleteFactorValue()
        {
            priceBaseService.LogicDeleteFactorValue(model.FactorValue.Id);
        }
        #endregion

        #region//业务类型包含的价格因素
        /// <summary>
        /// 名    称: AddBusinessTypePriceFactor
        /// 功能概要: 添加业务类型包含的价格因素
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月13日9:23:33
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void AddBusinessTypePriceFactor() 
        {
            priceBaseService.AddBusinessTypePriceFactor(model.BusinessTypePriceFactor,model.PriceFactorIds);
        }

        /// <summary>
        /// 名    称: UpdateBusinessTypePriceFactor
        /// 功能概要: 修改 业务类型包含的价格因素
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月13日9:23:33
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void UpdateBusinessTypePriceFactor() 
        {
            priceBaseService.UpdateBusinessTypePriceFactor(model.BusinessTypePriceFactor,model.PriceFactorIds);
        }

        /// <summary>
        /// 名    称: DeleteBusinessTypePriceFactor
        /// 功能概要: 删除 业务类型包含的价格因素
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月13日9:23:33
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void DeleteBusinessTypePriceFactor() 
        {
            priceBaseService.DeleteBusinessTypePriceFactor(model.BusinessTypePriceFactor.Id);
        }

        /// <summary>
        /// 名    称: DeleteBusinessTypePriceFactorByBusinessTypeId
        /// 功能概要: 根据业务类型Id删除与价格因素之间的依赖 
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月13日10:01:27
        /// 修正履历：
        /// 修正时间:
        /// </summary>
        public void DeleteBusinessTypePriceFactorByBusinessTypeId() 
        {
            priceBaseService.DeleteBusinessTypePriceFactorByBusinessTypeId(model.BusinessTypePriceFactor.BusinessTypeId);
        }
        #endregion

        #region//价格因素之间的依赖
        /// <summary>
        /// 名    称: AddFactorRelation
        /// 功能概要: 新增价格因素依赖
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月14日12:02:58
        /// 修正履历：
        /// 修正时间:
        /// </summary>
        public void AddFactorRelation() 
        {
            priceBaseService.AddFactorRelation(model.FactorRelation,model.PriceFactorIds);
        }

        /// <summary>
        /// 名    称: UpdateFactorRelation
        /// 功能概要: 更新价格因素依赖
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月14日12:02:58
        /// 修正履历：
        /// 修正时间:
        /// </summary>
        public void UpdateFactorRelation()
        {
            priceBaseService.UpdateFactorRelation(model.FactorRelation, model.PriceFactorIds);
        }

        /// <summary>
        /// 名    称: LogicDeleteFactorRelation
        /// 功能概要: 逻辑删除价格因素依赖
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月14日12:02:58
        /// 修正履历：
        /// 修正时间:
        /// </summary>
        public void LogicDeleteFactorRelation()
        {
            priceBaseService.LogicDeleteFactorRelation(model.FactorRelation);
        }
        #endregion

        #region//价格因素依赖关系值
        /// <summary>
        /// 名    称: AddFactorRelationValue
        /// 功能概要: 添加价格因素依赖关系值
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月18日13:24:37
        /// 修正履历：
        /// 修正时间:
        /// </summary>
        public void AddFactorRelationValue() 
        {
            priceBaseService.AddFactorRelationValue(model.FactorRelationValue);
        }

        /// <summary>
        /// 名    称: UpdateFactorRelationValue
        /// 功能概要: 更新价格因素依赖关系值
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月18日13:24:37
        /// 修正履历：
        /// 修正时间:
        /// </summary>
        public void UpdateFactorRelationValue()
        {
            priceBaseService.UpdateFactorRelationValue(model.FactorRelationValue);
        }

        /// <summary>
        /// 名    称: LogicDeleteFactorRelationValue
        /// 功能概要: 逻辑删除价格因素依赖关系值
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月18日13:24:37
        /// 修正履历：
        /// 修正时间:
        /// </summary>
        public void LogicDeleteFactorRelationValue()
        {
            priceBaseService.LogicDeleteFactorRelationValue(model.FactorRelationValue.Id);
        }
        #endregion
    }
}
