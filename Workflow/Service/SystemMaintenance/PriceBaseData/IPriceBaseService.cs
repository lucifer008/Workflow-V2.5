using System;
using System.Collections.Generic;
using Workflow.Da.Domain;

namespace Workflow.Service.SystemMaintenance.PriceBaseData
{
    /// <summary>
    /// 名    称: IPriceBaseService
    /// 功能概要: 价格基础数据维护接口
    /// 作    者: 张晓林
    /// 创建时间: 2009年4月28日15:33:14
    /// 修 正 人: 
    /// 修正时间: 
    /// 修正描述: 
    /// </summary>
    public interface IPriceBaseService
    {
        #region //新增业务类型

        /// <summary>
        /// 名    称: AddBusinessType
        /// 功能概要: 添加业务类型
        /// 作    者: 张晓林
        /// 创建时间: 2009年4月28日17:06:43
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        void AddBusinessType(BusinessType businessType);
        #endregion

        #region //修改业务类型
        /// <summary>
        /// 名    称: UpdateBusinessType
        /// 功能概要: 修改业务类型
        /// 作    者: 张晓林
        /// 创建时间: 2009年4月28日17:06:43
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="businessTypeId"></param>
        void UpdateBusinessType(BusinessType businessType);
        #endregion

        #region //删除业务类型
        /// <summary>
        /// 名    称: DeleteBusinessType
        /// 功能概要: 删除业务类型
        /// 作    者: 张晓林
        /// 创建时间: 2009年4月28日17:06:43
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="businessTypeId"></param>
        void DeleteBusinessType(long businessTypeId);
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
        void AddProcessContent(ProcessContent processContent, ProcessContentAchievementRate processContentAchievementRate);

        /// <summary>
        /// 名    称:UpdateProcessContent
        /// 功能概要:修改加工内容
        /// 作    者:张晓林
        /// 创建时间:2009年4月30日10:23:38
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        void UpdateProcessContent(ProcessContent processContent, ProcessContentAchievementRate processContentAchievementRate);

        /// <summary>
        /// 名    称:DeleteProcessContent
        /// 功能概要:删除加工内容
        /// 作    者:张晓林
        /// 创建时间:2009年4月30日10:23:38
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        void DeleteProcessContent(long processContentId); 

        /// <summary>
        /// 名    称:GetProcessContentAchievementRate
        /// 功能概要:获取加工内容的业绩
        /// 作    者:张晓林
        /// 创建时间:2009年6月5日11:52:04
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        ProcessContentAchievementRate GetProcessContentAchievementRate(long processContentId); 
        #endregion

        #region//机器类型维护
        /// <summary>
        /// 名    称: AddMachineType
        /// 功能概要: 新增机器类型
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月4日10:31:46
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        void AddMachineType(MachineType machineType); 

         /// <summary>
        /// 名    称: UpdateMachineType
        /// 功能概要: 更新机器类型
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月4日10:35:23
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        void UpdateMachineType(MachineType machineType);

        /// <summary>
        /// 名    称: LogicDeleteMachineType
        /// 功能概要: 逻辑删除机器类型
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月4日10:35:23
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        void LogicDeleteMachineType(long machineTypeId);
        #endregion

        #region//机器维护
        /// <summary>
        /// 名    称: AddMachine
        /// 功能概要: 新增机器
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月4日14:55:53
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        void AddMachine(Machine machine);

        /// <summary>
        /// 名    称: UpdateMachine
        /// 功能概要: 更新机器
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月4日14:56:33
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        void UpdateMachine(Machine machine);

        /// <summary>
        /// 名    称: LogicDeleteMachine
        /// 功能概要: 逻辑删除机器
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月4日14:56:33
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        void LogicDeleteMachine(long machineId);
        #endregion

        #region//纸型维护

        /// <summary>
        /// 名    称: AddPaperSpecification
        /// 功能概要: 新增纸型
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月5日15:31:55
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        void AddPaperSpecification(PaperSpecification paperSpecification);

        /// <summary>
        /// 名    称: UpdateSpecification
        /// 功能概要: 更新纸型
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月5日15:31:55
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        void UpdateSpecification(PaperSpecification paperSpecification);

        /// <summary>
        /// 名    称: LogicDeleteSpecification
        /// 功能概要: 逻辑删除纸型
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月5日15:31:55
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        void LogicDeleteSpecification(long paperSpecificationId);
        #endregion

        #region//纸质维护
        /// <summary>
        /// 名    称: AddPaperType
        /// 功能概要: 新增纸质
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月6日10:14:51
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        void AddPaperType(PaperType paperType); 

        /// <summary>
        /// 名    称: UpdatePaperType
        /// 功能概要: 修改纸质
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月6日10:14:51
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        void UpdatePaperType(PaperType paperType); 

        /// <summary>
        /// 名    称: LogicDeletePaperType
        /// 功能概要: 逻辑删除纸质
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月6日10:14:51
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        void LogicDeletePaperType(long paperTypeId); 
        #endregion

        #region//其他价格因素及值维护
        /// <summary>
        /// 名    称: AddPriceFactor
        /// 功能概要: 新增价格因素
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月6日16:03:51
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        void AddPriceFactor(PriceFactor priceFactor);

        /// <summary>
        /// 名    称: UpdatePriceFactor
        /// 功能概要: 修改价格因素
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月6日16:03:51
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        void UpdatePriceFactor(PriceFactor priceFactor);

        /// <summary>
        /// 名    称: LogicDeletePriceFactor
        /// 功能概要: 逻辑删除价格因素
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月6日16:03:51
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        void LogicDeletePriceFactor(long priceFactorId);

        /// <summary>
        /// 名    称: AddFactorValue
        /// 功能概要: 新增价格因素值
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月6日16:03:51
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        void AddFactorValue(FactorValue factorValue);

        /// <summary>
        /// 名    称: UpdateFactorValue
        /// 功能概要: 更新价格因素值
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月6日16:03:51
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        void UpdateFactorValue(FactorValue factorValue);

        /// <summary>
        /// 名    称: LogicDeleteFactorValue
        /// 功能概要: 逻辑删除价格因素值
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月6日16:03:51
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        void LogicDeleteFactorValue(long factorValueId);

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
        void AddBusinessTypePriceFactor(BusinessTypePriceFactor businessTypePriceFactor,string[] priceFactorIds);

         /// <summary>
        /// 名    称: UpdateBusinessTypePriceFactor
        /// 功能概要: 修改 业务类型包含的价格因素
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月13日9:23:33
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        void UpdateBusinessTypePriceFactor(BusinessTypePriceFactor businessTypePriceFactor, string[] priceFactorIds);

        /// <summary>
        /// 名    称: DeleteBusinessTypePriceFactor
        /// 功能概要: 删除 业务类型包含的价格因素
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月13日9:23:33
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        void DeleteBusinessTypePriceFactor(long businessTypePriceFactorId);

        /// <summary>
        /// 名    称: DeleteBusinessTypePriceFactorByBusinessTypeId
        /// 功能概要: 根据业务类型Id删除与价格因素之间的依赖 
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月13日10:01:27
        /// 修正履历：
        /// 修正时间:
        /// </summary>
        void DeleteBusinessTypePriceFactorByBusinessTypeId(long businessTypeId);
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
       void AddFactorRelation(FactorRelation factorRelation,string[] priceFactorIds); 

        /// <summary>
        /// 名    称: UpdateFactorRelation
        /// 功能概要: 更新价格因素依赖
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月14日12:02:58
        /// 修正履历：
        /// 修正时间:
        /// </summary>
        void UpdateFactorRelation(FactorRelation factorRelation, string[] priceFactorIds);

        /// <summary>
        /// 名    称: LogicDeleteFactorRelation
        /// 功能概要: 逻辑删除价格因素依赖
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月14日12:02:58
        /// 修正履历：
        /// 修正时间:
        /// </summary>
        void LogicDeleteFactorRelation(FactorRelation factorRelation);
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
        void AddFactorRelationValue(FactorRelationValue factorRelationValue); 

        /// <summary>
        /// 名    称: UpdateFactorRelationValue
        /// 功能概要: 更新价格因素依赖关系值
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月18日13:24:37
        /// 修正履历：
        /// 修正时间:
        /// </summary>
        void UpdateFactorRelationValue(FactorRelationValue factorRelationValue);

        /// <summary>
        /// 名    称: LogicDeleteFactorRelationValue
        /// 功能概要: 逻辑删除价格因素依赖关系值
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月18日13:24:37
        /// 修正履历：
        /// 修正时间:
        /// </summary>
        void LogicDeleteFactorRelationValue(long factorRelationValueId);
        #endregion
    }
}
