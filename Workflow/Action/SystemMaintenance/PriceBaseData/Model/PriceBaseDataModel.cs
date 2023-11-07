using System;
using System.Collections.Generic;
using Workflow.Da.Domain;
namespace Workflow.Action.SystemMaintenance.PriceBaseData.Model
{
    /// <summary>
    /// 名   称:  PriceBaseDataModel
    /// 功能概要: 基础价格数据管理Model
    /// 作    者: 张晓林
    /// 创建时间: 2009年4月28日15:18:54
    /// 修正履历:
    /// 修正时间:
    /// </summary>
    public class PriceBaseDataModel
    {
        private IList<BusinessType> businessTypeList;
        public IList<BusinessType> BusinessTypeList
        {
            set { businessTypeList = value; }
            get { return businessTypeList; }
        }

        private IList<BusinessType> businessTypeTempList;
        public IList<BusinessType> BusinessTypeTempList
        {
            set { businessTypeTempList = value; }
            get { return businessTypeTempList; }
        }

        private BusinessType businessType=new BusinessType();
        public BusinessType BusinessType 
        {
            set { businessType = value; }
            get { return businessType; }
        }

        private long businessTypeRowCount;
        public long BusinessTypeRowCount 
        {
            set { businessTypeRowCount = value; }
            get { return businessTypeRowCount; }
        }

        private ProcessContent processContent=new ProcessContent();
        public ProcessContent ProcessContent 
        {
            set { processContent = value; }
            get { return processContent; }
        }

        private IList<ProcessContent> processContentList;
        public IList<ProcessContent> ProcessContentList 
        {
            set { processContentList = value; }
            get { return processContentList; }
        }

        private Machine machine = new Machine();
        public Machine Machine 
        {
            set { machine = value; }
            get { return machine; }
        }
        private IList<Machine> machineList;
        public IList<Machine> MachineList 
        {
            set { machineList = value; }
            get { return machineList; }
        }

        private MachineType machineType = new MachineType();
        public MachineType MachineType 
        {
            set { MachineType = value; }
            get { return machineType; }
        }
        private IList<MachineType> machineTypeList;
        public IList<MachineType> MachineTypeList 
        {
            set { machineTypeList = value; }
            get { return machineTypeList; }
        }

        private PaperSpecification paperSecification=new PaperSpecification();
        public PaperSpecification PaperSecification 
        {
            set { paperSecification = value; }
            get { return paperSecification; }
        }

        private IList<PaperSpecification> paperSecificationList;
        public IList<PaperSpecification> PaperSecificationList
        {
            set { paperSecificationList = value; }
            get { return paperSecificationList; }
        }

        private PaperType paperType = new PaperType();
        public PaperType PaperType 
        {
            set { paperType = value; }
            get { return paperType; }
        }

        private IList<PaperType> paperTypeList;
        public IList<PaperType> PaperTypeList 
        {
            set { paperTypeList = value; }
            get { return paperTypeList; }
        }

        private PriceFactor priceFactor=new PriceFactor();
        public PriceFactor PriceFactor 
        {
            set { priceFactor = value; }
            get { return priceFactor; }
        }

        private IList<PriceFactor> priceFactorList;
        public IList<PriceFactor> PriceFactorList 
        {
            set { priceFactorList = value; }
            get { return priceFactorList; }
        }
        private IList<PriceFactor> priceFactorList2;
        public IList<PriceFactor> PriceFactorList2
        {
            set { priceFactorList2 = value; }
            get { return priceFactorList2; }
        }
        private FactorValue factorValue=new FactorValue();
        public FactorValue FactorValue 
        {
            set { factorValue = value; }
            get { return factorValue; }
        }

        private IList<FactorValue> factorValueList;
        public IList<FactorValue> FactorValueList 
        {
            set { factorValueList = value; }
            get { return factorValueList; }
        }

        private BusinessTypePriceFactor businessTypePriceFactor=new BusinessTypePriceFactor();
        public BusinessTypePriceFactor BusinessTypePriceFactor 
        {
            set { businessTypePriceFactor = value; }
            get { return businessTypePriceFactor; }
        }

        private IList<BusinessTypePriceFactor> businessTypePriceFactorList;
        public IList<BusinessTypePriceFactor> BusinessTypePriceFactorList 
        {
            set { businessTypePriceFactorList = value; }
            get { return businessTypePriceFactorList; }
        }

        private string[] priceFactorIds;
        public string[] PriceFactorIds 
        {
            set { priceFactorIds = value; }
            get { return priceFactorIds; }
        }

        private FactorRelation factorRelation=new FactorRelation();
        public FactorRelation FactorRelation 
        {
            set { factorRelation = value; }
            get { return factorRelation; }
        }

        private IList<FactorRelation> factorRelationList;
        public IList<FactorRelation> FactorRelationList 
        {
            set { factorRelationList = value; }
            get { return factorRelationList; }
        }

        private FactorRelationValue factorRelationValue=new FactorRelationValue();
        public FactorRelationValue FactorRelationValue 
        {
            set { factorRelationValue = value; }
            get { return factorRelationValue; }
        }

        private IList<FactorRelationValue> factorRelationValueList;
        public IList<FactorRelationValue> FactorRelationValueList 
        {
            set { factorRelationValueList = value; }
            get { return factorRelationValueList; }
        }

        private ProcessContentAchievementRate processContentAchievementRate = new ProcessContentAchievementRate();
        public ProcessContentAchievementRate ProcessContentAchievementRate
        {
            set { processContentAchievementRate = value; }
            get { return processContentAchievementRate; }
        }

        private FactorRelationValueText factorRelationValueText;
        public FactorRelationValueText FactorRelationValueText 
        {
            set { factorRelationValueText = value; }
            get { return factorRelationValueText; }
        }

    }
}
