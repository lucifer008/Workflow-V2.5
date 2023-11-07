using System;
using System.Text;
using System.Collections.Generic;
using Workflow.Da;
using Workflow.Support;
using Workflow.Da.Domain;
/// <summary>
/// 名    称: SelectActiveFactorServiceImpl
/// 功能概要: 价格因素 实现
/// 作    者: 付强
/// 创建时间: 2007-9-9
/// 修 正 人: 陈汝胤
/// 修正时间: 2009-1-21
/// 修正描述: 代码整理
/// </summary>

namespace Workflow.Service.SystemManege.PriceManage
{
    public class SelectActiveFactorServiceImpl:ISelectActiveFactorService
	{
		#region 注入

		#region 注入 businessTypeDao
		
		private IBusinessTypeDao businessTypeDao;
		/// <summary>
		/// 注入 businessTypeDao
		/// </summary>
		public IBusinessTypeDao BusinessTypeDao
		{
			set { businessTypeDao = value; }
		}
		#endregion

		#region 注入 machineDao

		private IMachineDao machineDao;
		/// <summary>
		/// 注入 machineDao
		/// </summary>
		public IMachineDao MachineDao
		{
			set { machineDao = value; }
		}

		#endregion

		#region 注入 machineTypeDao

		private IMachineTypeDao machineTypeDao;
		/// <summary>
		/// 注入 machineTypeDao
		/// </summary>
		public IMachineTypeDao MachineTypeDao
		{
			set { machineTypeDao = value; }
		}

		#endregion

		#region 注入 printDemandDao
		
		private IPrintDemandDao printDemandDao;
		/// <summary>
		/// 注入 printDemandDao
		/// </summary>
        public IPrintDemandDao PrintDemandDao
        {
            set { printDemandDao = value; }
        }
		#endregion

		#region 注入 printDemandDetailDao
		
		private IPrintDemandDetailDao printDemandDetailDao;
		/// <summary>
		/// 注入 printDemandDetailDao
		/// </summary>
        public IPrintDemandDetailDao PrintDemandDetailDao
        {
            set { printDemandDetailDao = value; }
        }
		#endregion

		#region 注入 printRequireDetailDao

		private IPrintRequireDetailDao printRequireDetailDao;
		/// <summary>
		/// 注入 printRequireDetailDao
		/// </summary>
        public IPrintRequireDetailDao PrintRequireDetailDao
        {
            set { printRequireDetailDao = value; }
        }
		#endregion

		#region 注入 priceFactorDao

		private IPriceFactorDao priceFactorDao;
		/// <summary>
		/// 注入 priceFactorDao
		/// </summary>
        public IPriceFactorDao PriceFactorDao
        {
            set { priceFactorDao = value; }
        }

		#endregion

		#region 注入 paperTypeDao
		
		private IPaperTypeDao paperTypeDao;
		/// <summary>
		/// 注入 paperTypeDao
		/// </summary>
        public IPaperTypeDao PaperTypeDao
        {
            set { paperTypeDao = value; }
        }
		#endregion

		#region 注入 paperSpecificationDao
		
		private IPaperSpecificationDao paperSpecificationDao;
		/// <summary>
		/// 注入 paperSpecificationDao
		/// </summary>
        public IPaperSpecificationDao PaperSpecificationDao
        {
            set { paperSpecificationDao = value; }
        }
		#endregion

		#region 注入 unitDao
		
		private IUnitDao unitDao;
		/// <summary>
		/// 注入 unitDao
		/// </summary>
        public IUnitDao UnitDao
        {
            set { unitDao = value; }
        }
		#endregion

		#region 注入 factorRelationDao
		
		private IFactorRelationDao factorRelationDao;
		/// <summary>
		/// 注入 factorRelationDao
		/// </summary>
        public IFactorRelationDao FactorRelationDao
        {
            set { factorRelationDao = value; }
        }
		#endregion

		#region 注入 factorRelationValueDao
		
		private IFactorRelationValueDao factorRelationValueDao;
		/// <summary>
		/// 注入 factorRelationValueDao
		/// </summary>
        public IFactorRelationValueDao FactorRelationValueDao
        {
            set { factorRelationValueDao = value; }
        }

		#endregion

		#region 注入 factorValueDao
		
		private IFactorValueDao factorValueDao;
		/// <summary>
		/// 注入 factorValueDao
		/// </summary>
        public IFactorValueDao FactorValueDao
        {
            set { factorValueDao = value; }
        }

		#endregion

		#endregion

		#region 业务类型

		/// <summary>
		/// 业务类型
		/// </summary>
		/// <returns>业务类型列表</returns>
		/// <remarks>
		/// 作    者: 付强
		/// 创建时间: 2007-9-9
		/// </remarks>
        public IList<BusinessType> GetbusinessType()
        {
            return businessTypeDao.SelectAll();
		}
		#endregion

		#region 机器

		/// <summary>
		/// 业务类型
		/// </summary>
		/// <returns>机器列表</returns>
		/// <remarks>
		/// 作    者: 付强
		/// 创建时间: 2007-9-9
		/// </remarks>
		public IList<Machine> GetMachine()
        {
            return machineDao.SelectAll();
		}
		#endregion

		#region 印制要求

		/// <summary>
		/// 印制要求
		/// </summary>
		/// <returns>印制要求列表</returns>
		/// <remarks>
		/// 作    者: 付强
		/// 创建时间: 2007-9-9
		/// </remarks>
		public IList<PrintDemand> GetPrintDemand()
        {
            return printDemandDao.SelectAll();
		}
		#endregion

		#region 印制要求明细

		/// <summary>
		/// 印制要求明细
		/// </summary>
		/// <returns>印制要求明细列表</returns>
		/// <remarks>
		/// 作    者: 付强
		/// 创建时间: 2007-9-9
		/// </remarks>
		public IList<PrintDemandDetail> GetPrintDemandDetail()
        {
            return printDemandDetailDao.SelectAll();
		}
		#endregion

		#region 制作要求

		/// <summary>
		/// 制作要求
		/// </summary>
		/// <returns>制作要求列表</returns>
		/// <remarks>
		/// 作    者: 付强
		/// 创建时间: 2007-9-9
		/// </remarks>
		public IList<PrintRequireDetail> GetPrintRequireDetail()
        {
            return printRequireDetailDao.SelectAll();
		}
		#endregion

		#region 获取所有价格因素

		/// <summary>
		/// 获取所有价格因素
		/// </summary>
		/// <returns>价格因素列表</returns>
		/// <remarks>
		/// 作    者: 付强
		/// 创建时间: 2007-9-9
		/// </remarks>
        public IList<PriceFactor>  GetPriceFactor()
        {
            return priceFactorDao.SelectByUsed();
		}
		#endregion

		#region 获取所有纸型

		/// <summary>
		/// 获取所有纸型
		/// </summary>
		/// <returns>纸型列表</returns>
		/// <remarks>
		/// 作    者: 付强
		/// 创建时间: 2007-9-9
		/// </remarks>
		public IList<PaperType> GetPaperType()
        {
            return paperTypeDao.SelectAll();
		}
		#endregion

		#region 获取所有纸质

		/// <summary>
		/// 获取所有纸质
		/// </summary>
		/// <returns>纸质列表</returns>
		/// <remarks>
		/// 作    者: 付强
		/// 创建时间: 2007-9-9
		/// </remarks>
		public IList<PaperSpecification> GetPaperSpecification()
        {
            return paperSpecificationDao.SelectAll();
		}
		#endregion

		#region 机器类型

		/// <summary>
		/// 机器类型
		/// </summary>
		/// <returns>机器类型列表</returns>
		/// <remarks>
		/// 作    者: 付强
		/// 创建时间: 2007-9-9
		/// </remarks>
		public IList<MachineType> GetMachineType()
        {
            return machineTypeDao.SelectAll();
		}
		#endregion

		#region 获取所有单位

		/// <summary>
		/// 获取所有单位
		/// </summary>
		/// <returns>单位列表</returns>
		/// <remarks>
		/// 作    者: 付强
		/// 创建时间: 2007-9-9
		/// </remarks>
		public IList<Unit> GetUnits()
        {
            return unitDao.SelectAll();
		}
		#endregion

		#region 获取因素关系

		/// <summary>
		/// 获取因素关系
		/// </summary>
		/// <returns>因素关系列表</returns>
		/// <remarks>
		/// 作    者: 付强
		/// 创建时间: 2007-9-9
		/// </remarks>
		public IList<FactorRelation> GetFactorRelation()
        {
            return factorRelationDao.SelectAll();
        }

		#endregion

		#region 获取因素关系的值

		/// <summary>
		/// 获取因素关系的值
		/// </summary>
		/// <returns>因素关系的值列表</returns>
		/// <remarks>
		/// 作    者: 付强
		/// 创建时间: 2007-9-9
		/// </remarks>
		public IList<FactorRelationValue> GetFactorRelationValue()
        {
            return factorRelationValueDao.SelectAll();
        }

		#endregion

		#region 获取活动因素的值

		/// <summary>
		/// 获取活动因素的值
		/// </summary>
		/// <returns>活动因素的值列表</returns>
		/// <remarks>
		/// 作    者: 付强
		/// 创建时间: 2007-9-9
		/// </remarks>
		public IList<FactorValue> GetFactorValue()
        {
            return factorValueDao.SelectAll();
        }

		#endregion

		#region 获取动态因素的相关值
		/// <summary>
        /// 名    称: GetRelatedPriceFactorBySourcePriceFactor
        /// 功能概要: 获取动态因素的相关值
        /// 作    者: 付强
        /// 创建时间: 2007-9-17
        /// 修正履历: 添加因素之间的过滤
        /// 修正时间: 2008-11-7
        /// </summary>
        /// <param name="factorRelation">必须包含指定的业务类型ID和源因素ID</param>
        /// <returns>FactorRelationID及PriceFactorId2对应的信息</returns>
        public IList<PriceFactor> GetRelatedPrice(FactorRelation factorRelation)
        {
            IList<PriceFactor> priceFactorList = new List<PriceFactor>();
            factorRelation.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            factorRelation.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            if (factorRelation.PriceFactorId == 0)
            {
                BusinessType businessType = businessTypeDao.SelectByPk(factorRelation.BusinessTypeId);
                foreach (PriceFactor pf in businessType.PriceFactorList)
                {
                    long id = 0;
                    if (pf.TargetTable.ToUpper() == "FACTOR_VALUE")
                    {
                        pf.TargetPriceFactorId = "Price_Factor_Id";
                    }
                    else if (pf.TargetTable.ToUpper() == "PROCESS_CONTENT")
                    {
                        id = pf.Id;
                        pf.TargetPriceFactorId = "Business_Type_Id";
                        pf.Id = factorRelation.BusinessTypeId;
                       
                    }
                    pf.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
                    pf.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
                    pf.FactorValueList = factorValueDao.GetFactorValueListByPriceFactor(pf);
                    if (id != 0)
                    {
                        pf.Id = id;
                    }
                    priceFactorList.Add(pf);
                }
            }
            else
            {
                IList<FactorRelation> factorRelatinoList = factorRelationDao.GetRelatedPriceFactorBySourcePriceFactor(factorRelation);

                foreach (FactorRelation fr in factorRelatinoList)
                {
                    PriceFactor pf = fr.PriceFactor;
                    fr.TargetTable = fr.PriceFactor.TargetTable;
                    fr.TargetValueColumn = fr.PriceFactor.TargetValueColumn;
                    fr.TargetTextColumn = fr.PriceFactor.TargetTextColumn;
                    fr.SourceValue = factorRelation.SourceValue;
                    fr.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
                    fr.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
                    pf.FactorValueList = factorRelationDao.GetFactorValueListByFactorRelation(fr);

                    priceFactorList.Add(pf);
                }
            }
            
            return priceFactorList;
        }
		
		#endregion

        #region ISelectActiveFactorService 成员


        IList<FactorRelation> ISelectActiveFactorService.GetRelatedPriceFactorBySourcePriceFactor(FactorRelation factorRelation)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IList<FactorValue> GetFactorValueListByFactorRelation(FactorRelation factorRelation)
        {
            return factorRelationDao.GetFactorValueListByFactorRelation(factorRelation);
        }

        #endregion
    }
}
