using System;
using System.Collections.Generic;
using Workflow.Da.Domain;
using Workflow.Service.SystemMaintenance.PriceBaseData;
using Workflow.Action.SystemMaintenance.PriceBaseData.Model;
namespace Workflow.Action.SystemMaintenance.PriceBaseData
{
    /// <summary>
    /// 名   称:  SearchPriceBaseDataAction
    /// 功能概要: 基础价格数据查询Action
    /// 作    者: 张晓林
    /// 创建时间: 2009年4月28日15:18:54
    /// 修正履历:
    /// 修正时间:
    /// </summary>
    public class SearchPriceBaseDataAction
    {
        #region //注入Service
        private PriceBaseDataModel model = new PriceBaseDataModel();
        public PriceBaseDataModel Model
        {
            set { model = value; }
            get { return model; }
        }

        private ISearchPriceBaseService searchPriceBaseService;
        public ISearchPriceBaseService SearchPriceBaseService 
        {
            set { searchPriceBaseService = value; }
        }
        #endregion

        #region //获取业务类型列表
        /// <summary>
        /// 名称：GetBusniessTypeList
        /// 功能概要:获取业务类型列表
        /// 作者：张晓林
        /// 创建时间:2009年4月28日15:26:31
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void GetBusniessTypeLists()
        {
            model.BusinessTypeList = searchPriceBaseService.GetBusinessTypeList(model.BusinessType);
            model.BusinessTypeRowCount = searchPriceBaseService.GetBusinessTypeListRowCount(model.BusinessType);
        }
        #endregion

        #region //获取所有业务类型列表
        /// <summary>
        /// 名    称：GetAllBusinessTypeList
        /// 功能概要: 获取业务类型列表
        /// 作    者：张晓林
        /// 创建时间: 2009年4月30日9:45:47
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void GetAllBusinessTypeList() 
        {
            model.BusinessTypeTempList = searchPriceBaseService.GetAllBusinessTypeList();
        }
        #endregion

        #region //获取加工内容列表
        /// <summary>
        /// 名    称：GetProcessContentList
        /// 功能概要: 获取加工内容列表
        /// 作    者：张晓林
        /// 创建时间: 2009年4月30日9:45:47
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void GetProcessContentList() 
        {
            model.ProcessContentList = searchPriceBaseService.GetProcessContentList(model.ProcessContent);
            model.BusinessTypeRowCount = searchPriceBaseService.GetProcessContentListRowCount(model.ProcessContent);
        }
        #endregion

        #region//获取机器类型
        /// <summary>
        /// 名    称：SearchMachineType
        /// 功能概要: 获取机器类型列表
        /// 作    者：张晓林
        /// 创建时间: 2009年5月4日10:08:16
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void SearchMachineType() 
        {
            model.MachineTypeList = searchPriceBaseService.SearchMachineType(model.MachineType);
            model.BusinessTypeRowCount = searchPriceBaseService.SearchMachineTypeRowCount(model.MachineType);
        }
        #endregion

        #region//机器
        /// <summary>
        /// 名    称：SearchMachine
        /// 功能概要: 获取机器列表
        /// 作    者：张晓林
        /// 创建时间: 2009年5月4日14:16:51
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void SearchMachine() 
        {
            model.MachineList = searchPriceBaseService.SearchMachine(model.Machine);
            model.BusinessTypeRowCount = searchPriceBaseService.SearchMachineRowCount(model.Machine);
        }

        /// <summary>
        /// 名    称：SearchAllMachineType
        /// 功能概要: 获取获取所有机器类型列表
        /// 作    者：张晓林
        /// 创建时间: 2009年5月4日14:21:46
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void SearchAllMachineType() 
        {
            model.MachineTypeList = searchPriceBaseService.SearchAllMachineType();
        }
        #endregion

        #region//纸型

        /// <summary>
        /// 名    称: SearchPaperSecification
        /// 功能概要: 获取纸型列表
        /// 作    者：张晓林
        /// 创建时间: 2009年5月5日15:15:30
        /// 修正时间:
        /// </summary>
        public void SearchPaperSecification() 
        {
            model.PaperSecificationList = searchPriceBaseService.SearchPaperSecification(model.PaperSecification);
            model.BusinessTypeRowCount = searchPriceBaseService.SearchPaperSecificationRowCount(model.PaperSecification);
        }
        #endregion

        #region//纸质
        /// <summary>
        /// 名    称: SearchPaperType
        /// 功能概要: 获取纸质列表
        /// 作    者：张晓林
        /// 创建时间: 2009年5月6日9:53:28
        /// 修正时间:
        /// </summary>
        public void SearchPaperType() 
        {
            model.PaperTypeList = searchPriceBaseService.SearchPaperType(model.PaperType);
            model.BusinessTypeRowCount = searchPriceBaseService.SearchPaperTypeRowCount( model.PaperType);
        }
        #endregion

        #region//其他价格因素及值
        /// <summary>
        /// 名    称: GetAllPriceFactor
        /// 功能概要: 获取所有价格因素
        /// 作    者：张晓林
        /// 创建时间: 2009年5月6日15:01:35
        /// 修正时间:
        /// </summary>
        public void GetAllPriceFactor() 
        {
            model.PriceFactorList = searchPriceBaseService.GetAllPriceFactor();
        }

        /// <summary>
        /// 名    称: SearchFactorValue
        /// 功能概要: 获取所有因素值列表
        /// 作    者：张晓林
        /// 创建时间: 2009年5月6日15:01:35
        /// 修正时间:
        /// </summary>
        public void SearchFactorValue() 
        {
            model.FactorValueList = searchPriceBaseService.SearchFactorValue(model.FactorValue);
            model.BusinessTypeRowCount = searchPriceBaseService.SearchFactorValueRowCount(model.FactorValue);
        }

        /// <summary>
        /// 名    称: SearchPriceFactor
        /// 功能概要: 获取所有价格因素列表
        /// 作    者：张晓林
        /// 创建时间: 2009年5月6日17:38:56
        /// 修正时间:
        /// </summary>
        public void SearchPriceFactor() 
        {
            model.PriceFactorList = searchPriceBaseService.SearchPriceFactor(model.PriceFactor);
            model.BusinessTypeRowCount = searchPriceBaseService.SearchPriceFactorRowCount(model.PriceFactor);
        }

        /// <summary>
        /// 名    称: GetPriceFactorDetail
        /// 功能概要: 获取价格因素详情
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月12日16:00:46
        /// 修正履历：
        /// 修正时间:
        /// </summary>
        public void GetPriceFactorDetail() 
        {
            model.PriceFactor = searchPriceBaseService.GetPriceFactorDetail(model.PriceFactor.Id);
        }
        #endregion

        #region//业务类型包含的价格因素

        /// <summary>
        /// 名    称: SearchBusinessTypePriceFactor
        /// 功能概要: 获取业务类型包含的价格因素列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月13日10:01:27
        /// 修正履历：
        /// 修正时间:
        /// </summary>
        public void SearchBusinessTypePriceFactor()
        {
            model.BusinessTypePriceFactorList = searchPriceBaseService.SearchBusinessTypePriceFactor();
        }

        /// <summary>
        /// 名    称: SearchBusinessTypePriceFactor
        /// 功能概要: 获取业务类型包含的价格因素列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月13日10:01:27
        /// 修正履历：
        /// 修正时间:
        /// </summary>
        public void SearchBusinessTypePriceFactor(long businessTypeId)
        {
            model.BusinessTypePriceFactorList = searchPriceBaseService.SearchBusinessTypePriceFactor(businessTypeId);
        }

        /// <summary>
        /// 根据业务类型Id获取业务类型包含的价格因素
        /// </summary>
        /// <remarks>
        /// 创 建 人: 张晓林
        /// 创建时间: 2009年5月13日10:36:24
        /// 修正履历:
        /// 修 正 人:
        /// </remarks>
        public string[] GetBusniessTypePriceFactor(long businessTypeId)
        {
            string[] busniessTypeList = new string[2];
            int count = 0;
            foreach (BusinessTypePriceFactor bt in searchPriceBaseService.SearchBusinessTypePriceFactor())
            {
                if (businessTypeId == bt.BusinessTypeId)
                {
                    if (0 == count)
                    {
                        busniessTypeList[0] += bt.PriceFactorId;
                        busniessTypeList[1] += bt.PriceFactorText;
                    }
                    else
                    {
                        busniessTypeList[0] += "/" + bt.PriceFactorId;
                        busniessTypeList[1] += "/" + bt.PriceFactorText;
                    }
                    count++;
                }
            }
            return busniessTypeList;
        }
        #endregion

        #region//价格因素之间的依赖
        /// <summary>
        /// 名    称: SearchFactorRelation
        /// 功能概要: 获取因素之间的依赖列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月14日10:47:30
        /// 修正履历：
        /// 修正时间:
        /// </summary>
        public void SearchFactorRelation() 
        {
            model.FactorRelationList=searchPriceBaseService.SearchFactorRelation(model.FactorRelation);
            model.BusinessTypeRowCount = searchPriceBaseService.SearchFactorRelationRowCount(model.FactorRelation);
        }
        #endregion

        #region//价格因素依赖关系值
        /// <summary>
        /// 名    称: GetAllFactorRelationValue
        /// 功能概要: 获取所有因素之间的依赖列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月18日11:10:17
        /// 修正履历：
        /// 修正时间:
        /// </summary>
        public void GetAllFactorRelationValue() 
        {
            model.FactorRelationList = searchPriceBaseService.GetAllFactorRelationValue();
        }

        /// <summary>
        /// 名    称: SearchFactorRelationValue
        /// 功能概要: 获取因素依赖的关系值列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月18日11:10:17
        /// 修正履历：
        /// 修正时间:
        /// </summary>
        public void SearchFactorRelationValue() 
        {
            model.FactorRelationValueList = searchPriceBaseService.SearchFactorRelationValue(model.FactorRelationValue);
            model.BusinessTypeRowCount = searchPriceBaseService.SearchFactorRelationValueRowCount(model.FactorRelationValue);
        }

        /// <summary>
        /// 名    称: GetFactorRelationValueText
        /// 功能概要: 获取因素依赖的关系值文本
        /// 作    者: 张晓林
        /// 创建时间: 2009年7月20日13:28:14
        /// 修正履历：
        /// 修正时间:
        /// </summary>
        public void GetFactorRelationValueText(FactorRelationValue factorRelationValue) 
        {
            FactorRelationValueText factorRelationValueText = new FactorRelationValueText();
            FactorRelation factorRelation = searchPriceBaseService.GetFactorRelationById(factorRelationValue.FactorRelationId);
            PriceFactor priceFactor1 = searchPriceBaseService.GetPriceFactorById(factorRelation.PriceFactorId);//依赖因素
            PriceFactor priceFactor2 = searchPriceBaseService.GetPriceFactorById(factorRelation.PriceFactor.Id);//被依赖因素
            IList<PriceFactor> priceFactorList1 = searchPriceBaseService.GetPriceFactorValueList(priceFactor1);
            IList<PriceFactor> priceFactorList2 = searchPriceBaseService.GetPriceFactorValueList(priceFactor2);
            foreach(PriceFactor priceFactor in priceFactorList1)
            {
                if(priceFactor.Id==factorRelationValue.SourceValue)
                {
                    factorRelationValueText.SourceValueId = factorRelationValue.SourceValue;
                    factorRelationValueText.SourceValueText = priceFactor.Name;
                    break;
                }
            }
            foreach (PriceFactor priceFactor in priceFactorList2)
            {
                if(priceFactor.Id==factorRelationValue.TargetValue)
                {
                    factorRelationValueText.TargetValueId = Convert.ToInt32(priceFactor.Id);
                    factorRelationValueText.TargetValueText = priceFactor.Name;
                    break;
                }
            }
            model.FactorRelationValueText = factorRelationValueText;
        }
        #endregion
    }
}
