using System;
using System.Text;
using System.Collections;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using Spring.Transaction.Interceptor;
using Microsoft.CSharp;
using Workflow.Da;
using Workflow.Util;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Da.Domain.Base;
/// <summary>
/// 名    称: PriceServiceImpl
/// 功能概要: 价格获取 实现
/// 作    者: 
/// 创建时间: 
/// 修 正 人: 陈汝胤
/// 修正时间: 2009-1-21
/// 修正描述: 代码整理
/// </summary>

namespace Workflow.Service.SystemManege.PriceManage
{
    class PriceServiceImpl : IPriceService
    {
        #region 对象传递
        //价格因素信息
        private IPriceFactorDao priceFactorDao;
        public IPriceFactorDao PriceFactorDao
        {
            set { priceFactorDao = value; }
        }

        //业务类型包含的因素
        private IBusinessTypePriceFactorDao businessTypePriceFactorDao;
        public IBusinessTypePriceFactorDao BusinessTypePriceFactorDao
        {
            set { businessTypePriceFactorDao = value; }
        }

        //业务类型
        private IBusinessTypeDao businessTypeDao;
        public IBusinessTypeDao BusinessTypeDao
        {
            set { businessTypeDao = value; }
        }

        //门市价格
        private IBaseBusinessTypePriceSetDao baseBusinessTypePriceSetDao;
        public IBaseBusinessTypePriceSetDao BaseBusinessTypePriceSetDao
        {
            set { baseBusinessTypePriceSetDao = value; }
        }

        //业务价格
        private IBusinessTypePriceSetDao businessTypePriceSetDao;
        public IBusinessTypePriceSetDao BusinessTypePriceSetDao
        {
            set { businessTypePriceSetDao = value; }
        }

        //factorValueDao
        private IFactorValueDao factorValueDao;
        public IFactorValueDao FactorValueDao
        {
            set { factorValueDao = value; }
        }

        //MasterService
        private IMasterDataService masterDataService;
        public IMasterDataService MasterDataService
        {
            set { masterDataService = value; }
        }
        private IAmountSegmentDao amountSegmentDao;
        public IAmountSegmentDao AmountSegmentDao
        {
            set { amountSegmentDao = value; }
        }

        private IFactorRelationValueDao factorRelationValueDao;
        public IFactorRelationValueDao FactorRelationValueDao
        {
            set { factorRelationValueDao = value; }
            get { return factorRelationValueDao; }
        }
        #endregion 对象传递

        #region 业务类型设置
        #region 获得因素的基本信息
        /// <summary>
        /// 方法名称: GetPriceFactor
        /// 功能概要: 获得因素的基本信息
        /// 作    者: 麻少华
        /// 创建时间: 2007-9-9
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <returns></returns>
        public IList<PriceFactor> GetPriceFactor()
        {
            return priceFactorDao.SelectAll();
        }
        #endregion

        #region 获得业务类型包含的因素
        /// <summary>
        /// 方法名称: GetBusinessTypePriceFactor
        /// 功能概要: 获得业务类型包含的因素
        /// 作    者: 麻少华
        /// 创建时间: 2007-9-9
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <returns></returns>
        public IList<BusinessTypePriceFactor> getBusinessTypePriceFactor()
        {
            return businessTypePriceFactorDao.SelectAll();
        }
        #endregion

        #region 追加新的业务类型
        /// <summary>
        /// 方法名称: InsertBusinessType
        /// 功能概要: 追加新的业务类型
        /// 作    者: 麻少华
        /// 创建时间: 2007-9-11
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="businessType">业务类型</param>
        /// <param name="businessTypePriceFactor">业务类型包含的价格因素</param>
        
        [Transaction]
        public void InsertBusinessType(BusinessType businessType,IList<BusinessTypePriceFactor> businessTypePriceFactor)
        {
            //增加业务类型
            businessTypeDao.Insert(businessType);
            //增加业务类型所包含的价格因素
            for (int i=0;i<businessTypePriceFactor.Count;i++)
            {
                businessTypePriceFactor[i].BusinessTypeId = businessType.Id;
                businessTypePriceFactorDao.Insert(businessTypePriceFactor[i]);
            }
        }
        #endregion

        #region 编辑当前的业务类型

        /// <summary>
        /// 方法名称: UpdateBusinessType
        /// 功能概要: 编辑当前的业务类型
        /// 作    者: 麻少华
        /// 创建时间: 2007-9-11
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="businessType">业务类型</param>
        /// <param name="businessTypePriceFactor">业务类型包含的价格因素</param>
        [Transaction]
        public void UpdateBusinessType(BusinessType businessType,IList<BusinessTypePriceFactor> businessTypePriceFactor)
        { 
            //编辑业务类型
            businessType.NeedRecordMachine = "Y";
            businessTypeDao.Update(businessType);
            //删除业务类型所包含的价格因素
            businessTypePriceFactorDao.DeleteByBusinessTypeId(businessType.Id);
            //新增业务类型所包含的价格因素
            for (int i = 0; i < businessTypePriceFactor.Count; i++)
            {
                businessTypePriceFactorDao.Insert(businessTypePriceFactor[i]);
            }
        }
        #endregion

        #region 删除当前的业务类型
        /// <summary>
        /// 方法名称: DeleteBusinessType
        /// 功能概要: 删除当前的业务类型
        /// 作    者: 麻少华
        /// 创建时间: 2007-9-11
        /// 修正履历:
        /// 修正时间: 2008-11-06 增加是否允许删除判断
        /// </summary>
        /// <param name="businessType">业务类型</param>
        [Transaction]
        public void DeleteBusinessType(BusinessType businessType)
        {
            //删除业务类型之前,应该先判断是否能删除.
            IList<BusinessType> lst=businessTypeDao.DeleteCheck(businessType.Id);
            if (lst.Count > 0)
            {
                string errMsg = "";
                for (int i = 0; i < lst.Count; i++)
                {
                    errMsg += lst[i].Name + "\\" + "n";
                }

                throw new Exception(errMsg);
            }


            //删除业务类型所包含的价格因素
            businessTypePriceFactorDao.DeleteByBusinessTypeId(businessType.Id);
            //编辑业务类型
            businessTypeDao.Delete(businessType.Id);
        }
        #endregion

        #region 获得某一业务类型下包含的因素
        /// <summary>
        /// 方法名称: getBusinessTypePriceFactorList
        /// 功能概要: 获得业务类型包含的因素
        /// 作    者: 麻少华
        /// 创建时间: 2007-9-9
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="businessType">业务类型</param>
        /// <returns>IList<GetPriceFactorSetList></returns>
        public IList<PriceFactor> GetPriceFactorSetList(BusinessType businessType)
        {
            PriceFactor priceFactor = new PriceFactor();
            priceFactor.Id = businessType.Id;
            priceFactor.CompanyId = ThreadLocalUtils.CurrentSession.CurrentUser.CompanyId;
            priceFactor.BranchShopId = ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId;
            return priceFactorDao.SelectPriceFactorSetList(priceFactor);
        }


        #endregion

        #region 业务类型一览
        public IList<BusinessType> GetBusinessTypeList()
        {
            return businessTypeDao.SelectAll();
        }
        #endregion

        #region 业务类型自定义查询
        /// <summary>
        /// 方法名称: GetBusinessTypeListCustomQuery
        /// 功能概要: 
        /// 作    者: 麻少华
        /// 创建时间: 2007-9-18
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <returns></returns>
        public IList<BusinessType> GetBusinessTypeListCustomQuery(BusinessType bussinessType)
        {
            //return businessTypeDao.SelectByPk(bussinessType.Id);
            //bussinessType
            return businessTypeDao.SelectCustomerQueryBusinessTypeList(bussinessType);
        }




                /// <summary>
        /// 显示设置时需要显示的信息
        /// </summary>
        /// <param name="businessType"></param>
        /// <returns></returns>
        public IList<BusinessType> GetBusinessTypeListCustomQuery_Set(BusinessType businessType)
        {
            return businessTypeDao.SelectCustomerQueryBusinessTypeList_Set(businessType);
        }
        #endregion
        #endregion

        #region 门市价格设置

        /// <summary>
        /// 方法名称: GetBaseBusinessTypePriceSetList
        /// 功能概要: 获得门市价格设置一览
        /// 作    者: 麻少华
        /// 创建时间: 2007-9-19
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <returns></returns>
        public IList<BaseBusinessTypePriceSet> GetBaseBusinessTypePriceSetList()
        {
            int inti=0, intj=0, intk=0;
            int intFoundPos = 0;
            bool blnFound;
            //获取当前存在的：门市价格设置List
            IList<BaseBusinessTypePriceSet> baseBusinessTypePriceSetList;
            baseBusinessTypePriceSetList = baseBusinessTypePriceSetDao.SelectAll();

            //获取所有的价格因素
            IList<PriceFactor> priceFactorList;
            priceFactorList = masterDataService.GetPriceFactors();

            //因素值
            string strFactorValue="";
            inti = baseBusinessTypePriceSetList.Count;
            for (int i = 0; i < inti; i++)
            {
                intj = priceFactorList.Count;
                intk = baseBusinessTypePriceSetList[i].BusinessType.PriceFactorList.Count;
                //找到的位置
                intFoundPos = 0;
                //因素值数组
                string[] texts = new string[intj];
                for (int j = 0; j < intj; j++)
                {
                    blnFound = false;
                    for (int k= 0; k <intk; k++)
			        {
                        if (baseBusinessTypePriceSetList[i].BusinessType.PriceFactorList[k].Id == priceFactorList[j].Id)
                        {
                            //业务类型ID
                            priceFactorList[j].BusinessTypeId = baseBusinessTypePriceSetList[i].BusinessType.Id;
                            //因素值Id的设置
                            priceFactorList[j].PriceValueId = baseBusinessTypePriceSetList[i][intFoundPos++];
                            blnFound = true;
                            break;
                        }
			        }

                    //循环结束,还没有找到业务类型下因素值ID,说明当前业务类型下没有因素的设置(设置为-1用来标识)
                    if (!blnFound)
                    {
                        priceFactorList[j].PriceValueId = -1;
                    }
                    //对于因素值的取得,如果TargetTable中没有设置说明是从公共表中取得
                    if (priceFactorList[j].TargetTable == null || priceFactorList[j].TargetTable == "")
                    {   //因素Id的设置
                        priceFactorList[j].PriceFactorId = priceFactorList[j].Id;
                    }
                    else
                    {
                        //因素Id的设置
                        priceFactorList[j].PriceFactorId = 0;
                    }
                    //取得因素的值
                    strFactorValue = masterDataService.GetFactorValueText(priceFactorList[j]);
                    texts[j] = strFactorValue;
                }
                baseBusinessTypePriceSetList[i].Texts = texts;
			}
            return baseBusinessTypePriceSetList;
        }

        /// <summary>
        /// 方法名称: GetBaseBusinessTypePriceSetList
        /// 功能概要: 获得门市价格设置一览
        /// 作    者: 张晓林
        /// 创建时间: 2009年3月5日13:40:53
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <returns></returns>
        public IList<BaseBusinessTypePriceSet> GetBaseBusinessTypePriceSetList(BaseBusinessTypePriceSet baseBusinessTypePriceSet) 
        {
            int inti = 0, intj = 0, intk = 0;
            int intFoundPos = 0;
            bool blnFound;
            //门市价格设置List
            IList<BaseBusinessTypePriceSet> baseBusinessTypePriceSetList;
            baseBusinessTypePriceSetList = baseBusinessTypePriceSetDao.SearchBaseBuinessTypeSetInfo(baseBusinessTypePriceSet);//SelectAll();

            //价格因素
            IList<PriceFactor> priceFactorList;
            priceFactorList = masterDataService.GetPriceFactors();

            //因素值
            string strFactorValue = "";
            inti = baseBusinessTypePriceSetList.Count;
            for (int i = 0; i < inti; i++)
            {
                intj = priceFactorList.Count;
                intk = baseBusinessTypePriceSetList[i].BusinessType.PriceFactorList.Count;
                //找到的位置
                intFoundPos = 0;
                //因素值数组
                string[] texts = new string[intj];
                for (int j = 0; j < intj; j++)
                {
                    blnFound = false;
                    for (int k = 0; k < intk; k++)
                    {
                        if (baseBusinessTypePriceSetList[i].BusinessType.PriceFactorList[k].Id == priceFactorList[j].Id)
                        {
                            //业务类型ID
                            priceFactorList[j].BusinessTypeId = baseBusinessTypePriceSetList[i].BusinessType.Id;
                            //因素值Id的设置
                            priceFactorList[j].PriceValueId = baseBusinessTypePriceSetList[i][intFoundPos++];
                            blnFound = true;
                            break;
                        }
                    }

                    //循环结束,还没有找到业务类型下因素值ID,说明当前业务类型下没有因素的设置(设置为-1用来标识)
                    if (!blnFound)
                    {
                        priceFactorList[j].PriceValueId = -1;
                    }
                    //对于因素值的取得,如果TargetTable中没有设置说明是从公共表中取得
                    if (priceFactorList[j].TargetTable == null || priceFactorList[j].TargetTable == "")
                    {   //因素Id的设置
                        priceFactorList[j].PriceFactorId = priceFactorList[j].Id;
                    }
                    else
                    {
                        //因素Id的设置
                        priceFactorList[j].PriceFactorId = 0;
                    }
                    //取得因素的值
                    strFactorValue = masterDataService.GetFactorValueText(priceFactorList[j]);
                    texts[j] = strFactorValue;
                }
                baseBusinessTypePriceSetList[i].Texts = texts;
            }
            return baseBusinessTypePriceSetList;
        }

        /// <summary>
        /// 方法名称: SearchBaseBuinessTypeSetInfoRowCount
        /// 功能概要: 获得门市价格设置记录数
        /// 作    者: 张晓林
        /// 创建时间: 2009年3月5日13:40:53
        /// 修正履历: 
        /// 修正时间:
        /// </summary>
        /// <param name="baseBusinessTypePriceSet"></param>
        /// <returns></returns>
        public long SearchBaseBuinessTypeSetInfoRowCount(BaseBusinessTypePriceSet baseBusinessTypePriceSet) 
        {
            return baseBusinessTypePriceSetDao.SearchBaseBuinessTypeSetInfoRowCount(baseBusinessTypePriceSet);
        }

        /// <summary>
        /// 方法名称: GetBaseBusinessTypePriceSetById
        /// 功能概要: 根据ID取得单条门市价格设置的信息
        /// 作    者: 麻少华
        /// 创建时间: 2007-9-26
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="baseBusinessTypePriceSet"></param>
        /// <returns></returns>
        public BaseBusinessTypePriceSet GetBaseBusinessTypePriceSetById(BaseBusinessTypePriceSet baseBusinessTypePriceSet)
        {
            //门市价格
            baseBusinessTypePriceSet = baseBusinessTypePriceSetDao.SelectByPk(baseBusinessTypePriceSet.Id);

            //价格因素
            IList<PriceFactor> priceFactorList;
            priceFactorList = masterDataService.GetPriceFactors();

            //因素值
            string strFactorValue = "";

            //for (int i = 0; i < baseBusinessTypePriceSetList.Count; i++)
            //{
            //因素值数组
            string[] texts = new string[priceFactorList.Count];
            for (int j = 0; j < priceFactorList.Count; j++)
            {
                //业务类型ID
                priceFactorList[j].BusinessTypeId = baseBusinessTypePriceSet.BusinessType.Id;
                //因素值Id的设置
                priceFactorList[j].PriceValueId = baseBusinessTypePriceSet[j];
                //对于因素值的取得,如果TargetTable中没有设置说明是从公共表中取得
                if (priceFactorList[j].TargetTable == null || priceFactorList[j].TargetTable == "")
                {   //因素Id的设置
                    priceFactorList[j].PriceFactorId = priceFactorList[j].Id;
                }
                else
                {
                    //因素Id的设置
                    priceFactorList[j].PriceFactorId = 0;
                }
                //取得因素的值
                strFactorValue = masterDataService.GetFactorValueText(priceFactorList[j]);
                texts[j] = strFactorValue;
            }
            baseBusinessTypePriceSet.Texts = texts;
            //}
            return baseBusinessTypePriceSet;

            //return baseBusinessTypePriceSetDao.SelectByPk(baseBusinessTypePriceSet.Id);
        }

        /// <summary>
        /// 方法名称: GetBaseBusinessTypePriceSetListCustomQuery_Page
        /// 功能概要: 带分页功能获得门市价格设置一览(自定义查询)
        /// 作    者: 朱静程
        /// 创建时间: 2008-11-08
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="baseBusinessTypePriceSet"></param>
        /// <returns></returns>
        public IList<BaseBusinessTypePriceSet> GetBaseBusinessTypePriceSetListCustomQuery_Page(BaseBusinessTypePriceSet baseBusinessTypePriceSet)
        {
            int inti = 0, intj = 0, intk = 0;
            int intFoundPos = 0;
            bool blnFound;

            //门市价格设置List
            IList<BaseBusinessTypePriceSet> baseBusinessTypePriceSetList;
            baseBusinessTypePriceSetList = baseBusinessTypePriceSetDao.GetBaseBusinessTypePriceSetListCustomQuery_Page(baseBusinessTypePriceSet);

            //价格因素
            IList<PriceFactor> priceFactorList;
            priceFactorList = masterDataService.GetPriceFactors();

            //因素值
            string strFactorValue = "";
            inti = baseBusinessTypePriceSetList.Count;
            for (int i = 0; i < inti; i++)
            {
                intj = priceFactorList.Count;
                intk = baseBusinessTypePriceSetList[i].BusinessType.PriceFactorList.Count;
                //因素值数组
                string[] texts = new string[intj];
                //找到的位置
                intFoundPos = 0;
                for (int j = 0; j < intj; j++)
                {
                    blnFound = false;
                    for (int k = intFoundPos; k < intk; k++)
                    {
                        if (baseBusinessTypePriceSetList[i].BusinessType.PriceFactorList[k].Id == priceFactorList[j].Id)
                        {
                            //业务类型ID
                            priceFactorList[j].BusinessTypeId = baseBusinessTypePriceSetList[i].BusinessType.Id;
                            //因素值Id的设置
                            priceFactorList[j].PriceValueId = baseBusinessTypePriceSetList[i][intFoundPos++];
                            blnFound = true;
                            break;
                        }
                    }

                    //循环结束,还没有找到业务类型下因素值ID,说明当前业务类型下没有因素的设置(设置为-1用来标识)
                    if (!blnFound)
                    {
                        priceFactorList[j].PriceValueId = -1;
                    }
                    ////业务类型ID
                    //priceFactorList[j].BusinessTypeId = baseBusinessTypePriceSetList[i].BusinessType.Id;
                    ////因素值Id的设置
                    //priceFactorList[j].PriceValueId = baseBusinessTypePriceSetList[i].Item(j);
                    //对于因素值的取得,如果TargetTable中没有设置说明是从公共表中取得
                    if (priceFactorList[j].TargetTable == null || priceFactorList[j].TargetTable == "")
                    {   //因素Id的设置
                        priceFactorList[j].PriceFactorId = priceFactorList[j].Id;
                    }
                    else
                    {
                        //因素Id的设置
                        priceFactorList[j].PriceFactorId = 0;
                    }
                    //取得因素的值
                    //if (priceFactorList[j].IsDisplay == "Y")
                        strFactorValue = masterDataService.GetFactorValueText(priceFactorList[j]);
                    //else
                    //    strFactorValue = "";

                    texts[j] = strFactorValue;
                }
                baseBusinessTypePriceSetList[i].Texts = texts;
            }
            return baseBusinessTypePriceSetList;

        }

        public int GetBaseBusinessTypePriceSetListCustomQueryCount(BaseBusinessTypePriceSet baseBusinessTypePriceSet)
        {
            return baseBusinessTypePriceSetDao.GetBaseBusinessTypePriceSetListCustomQueryCount(baseBusinessTypePriceSet);
        }


        /// <summary>
        /// 方法名称: GetBaseBusinessTypePriceSetListCustomQuery
        /// 功能概要: 获得门市价格设置一览(自定义查询)
        /// 作    者: 朱静程
        /// 创建时间: 2008-11-08
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="baseBusinessTypePriceSet"></param>
        /// <returns></returns>
        public IList<BaseBusinessTypePriceSet> GetBaseBusinessTypePriceSetListCustomQuery(BaseBusinessTypePriceSet baseBusinessTypePriceSet)
        {
            return GetBaseBusinessTypePriceSetListCustomQuery_Page(baseBusinessTypePriceSet);
        }

        /// <summary>
        /// 方法名称: InsertBaseBusinessTypePriceSet
        /// 功能概要: 追加门市价格设置
        /// 作    者: 麻少华
        /// 创建时间: 2007-9-19
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="baseBusinessTypePriceSetList"></param>
        public void InsertBaseBusinessTypePriceSet(IList<BaseBusinessTypePriceSet> baseBusinessTypePriceSetList)
        {
            for (int i = 0; i < baseBusinessTypePriceSetList.Count; i++)
            {
                baseBusinessTypePriceSetDao.Insert(baseBusinessTypePriceSetList[i]);
            }
        }

        /// <summary>
        /// 方法名称: AddBaseBusinessTypePrice
        /// 功能概要: 门市价格 批量增加
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月23日15:15:13
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        [Transaction]
        public void AddBaseBusinessTypePrice(BaseBusinessTypePriceSet baseBusinessTypePriceSet) 
        {
            string strProcess = null;//加工内容
            string[] arrMachineNo = null;//型号;(多选)
            string[] arrPaperType = null;//纸质(多选)
            string[] arrPaperSec = null;//纸型/规格(多选)
            string strTicket = null;//发票
            string strMember = null;//会员
            string strAmount = null;//数量
            //int businessTypePriceFactorCount=0;//业务类型包含的价格因素数目
            IList<PriceFactor> priceFactorList = priceFactorDao.SelectAll();//获取所有价格因素
            foreach (LabelValue lv in baseBusinessTypePriceSet.StrPriceFactorList)
            {
                #region//获取因素
                if ("加工内容" == lv.Label)
                {
                    strProcess =lv.Value;
                }
                else if ("机器"==lv.Label) 
                {
                    arrMachineNo = lv.Value.Split(',');
                }
                else if ("纸质" == lv.Label)
                {
                    arrPaperType = lv.Value.Split(',');
                }
                else if ("规格" == lv.Label)
                {
                    arrPaperSec = lv.Value.Split(',');
                }
                else if ("发票" == lv.Label)
                {
                    strTicket = lv.Value;
                }
                else if ("会员" == lv.Label)
                {
                    strMember = lv.Value;
                }
                else if ("数量" == lv.Label)
                {
                    strAmount = lv.Value;
                }
                #endregion
            }

            #region//存储业务类型制约因素列表
            //获取机器,纸质，纸型Id
            long machineId=0, paperTypeId=0, paperSecId=0;
            
            bool booMpTypeFactorRelation = false;//机器是否制约纸质
            bool booMpSecFactorRelation = false;//机器是否制约纸型
            bool booPpFactorRelation = false;//纸质是否制约纸型
            foreach (PriceFactor priceFactor in priceFactorList)
            {
                if ("机器" == priceFactor.DisplayText)
                {
                    machineId = priceFactor.Id;
                }
                if ("纸质"==priceFactor.DisplayText)
                {
                    paperTypeId = priceFactor.Id;
                }
                if ("规格" == priceFactor.DisplayText)
                {
                    paperSecId = priceFactor.Id;
                }
            }
            FactorRelation factorRelation1 = new FactorRelation();
            factorRelation1.PriceFactorId = machineId;
            factorRelation1.PriceFactorId2 = paperTypeId;
            factorRelation1.BusinessTypeId = baseBusinessTypePriceSet.BusinessType.Id;
            if (factorRelationValueDao.GetFactorRelationId(factorRelation1) > 0)
            {
                booMpTypeFactorRelation = true;//机器制约纸质
            }
            factorRelation1.PriceFactorId = machineId;
            factorRelation1.PriceFactorId2 = paperSecId;
            factorRelation1.BusinessTypeId = baseBusinessTypePriceSet.BusinessType.Id;
            if (factorRelationValueDao.GetFactorRelationId(factorRelation1) > 0)
            {
                booMpSecFactorRelation = true;//机器制约纸型
            }
            factorRelation1.PriceFactorId = paperTypeId;
            factorRelation1.PriceFactorId2 = paperSecId;
            factorRelation1.BusinessTypeId = baseBusinessTypePriceSet.BusinessType.Id;
            if (factorRelationValueDao.GetFactorRelationId(factorRelation1) > 0)
            {
                booPpFactorRelation = true;//纸质制约纸型
            }

            List<BusinessTypeFactorRelation> btfrList = new List<BusinessTypeFactorRelation>();
            BusinessTypeFactorRelation btfr;
            if (null != arrMachineNo && null != arrPaperType && null != arrPaperSec)
            {
                #region//机器/纸质/纸型
                foreach (string strMachineNo in arrMachineNo)
                {
                    foreach (string strPaperType in arrPaperType)
                    {
                        foreach (string strPaperSec in arrPaperSec)
                        {
                            if (booMpTypeFactorRelation && booMpSecFactorRelation)//机器制约纸质，同时机器制约纸型
                            {
                                #region//获取存在制约关系的明细列表
                                //获取机器制约纸质Id
                                FactorRelation factorRelation = new FactorRelation();
                                factorRelation.PriceFactorId = machineId;
                                factorRelation.PriceFactorId2 = paperTypeId;
                                factorRelation.BusinessTypeId = baseBusinessTypePriceSet.BusinessType.Id;
                                long mpFactorRelationId = factorRelationValueDao.GetFactorRelationId(factorRelation);
                                
                                //获取机器制约纸型Id
                                factorRelation.PriceFactorId2 = paperSecId;
                                long ppFactorRelationId = factorRelationValueDao.GetFactorRelationId(factorRelation);
                                //判断选择价格因素列表是否存在这样的制约关系，若存在则添加这样
                                FactorRelationValue factorRelationValue = new FactorRelationValue();
                                factorRelationValue.FactorRelationId = mpFactorRelationId;
                                factorRelationValue.SourceValue = Convert.ToInt32(strMachineNo);
                                factorRelationValue.TargetValue = Convert.ToInt32(strPaperType);
                                bool booMp = CheckFactorRelationIsExist(factorRelationValue);//机器Id是否制约纸质

                                factorRelationValue.FactorRelationId = ppFactorRelationId;
                                factorRelationValue.SourceValue = Convert.ToInt32(strMachineNo);
                                factorRelationValue.TargetValue = Convert.ToInt32(strPaperSec);
                                bool booPp = CheckFactorRelationIsExist(factorRelationValue);//机器是否制约纸型 

                                if (booMp && booPp)
                                {
                                    btfr = new BusinessTypeFactorRelation();
                                    btfr.StrElementList.Add(strProcess);
                                    btfr.StrElementList.Add(strMachineNo);
                                    btfr.StrElementList.Add(strPaperType);
                                    btfr.StrElementList.Add(strPaperSec);
                                    if (null != strTicket)
                                    {
                                        btfr.StrElementList.Add(strTicket);
                                    }
                                    if (null != strMember)
                                    {
                                        btfr.StrElementList.Add(strMember);
                                    }
                                    if (null != strAmount)
                                    {
                                        btfr.StrElementList.Add(strAmount);
                                    }
                                    btfrList.Add(btfr);
                                }
                                #endregion
                            }
                            if(booMpTypeFactorRelation && booPpFactorRelation)//机器制约纸质，纸质制约纸型
                            {
                                #region//获取存在制约关系的明细列表
                                //获取机器制约纸质Id
                                FactorRelation factorRelation = new FactorRelation();
                                factorRelation.PriceFactorId = machineId;
                                factorRelation.PriceFactorId2 = paperTypeId;
                                factorRelation.BusinessTypeId = baseBusinessTypePriceSet.BusinessType.Id;
                                long mpFactorRelationId = factorRelationValueDao.GetFactorRelationId(factorRelation);

                                //获取纸质制约纸型Id
                                factorRelation.PriceFactorId = paperTypeId;
                                factorRelation.PriceFactorId2 = paperSecId;
                                long ppFactorRelationId = factorRelationValueDao.GetFactorRelationId(factorRelation);
                                //判断选择价格因素列表是否存在这样的制约关系，若存在则添加这样
                                FactorRelationValue factorRelationValue = new FactorRelationValue();
                                factorRelationValue.FactorRelationId = mpFactorRelationId;
                                factorRelationValue.SourceValue = Convert.ToInt32(strMachineNo);
                                factorRelationValue.TargetValue = Convert.ToInt32(strPaperType);
                                bool booMp = CheckFactorRelationIsExist(factorRelationValue);//机器Id是否制约纸质

                                factorRelationValue.FactorRelationId = ppFactorRelationId;
                                factorRelationValue.SourceValue = Convert.ToInt32(strPaperType);
                                factorRelationValue.TargetValue = Convert.ToInt32(strPaperSec);
                                bool booPp = CheckFactorRelationIsExist(factorRelationValue);//机器是否制约纸型 

                                if (booMp && booPp)
                                {
                                    btfr = new BusinessTypeFactorRelation();
                                    btfr.StrElementList.Add(strProcess);
                                    btfr.StrElementList.Add(strMachineNo);
                                    btfr.StrElementList.Add(strPaperType);
                                    btfr.StrElementList.Add(strPaperSec);
                                    if (null != strTicket)
                                    {
                                        btfr.StrElementList.Add(strTicket);
                                    }
                                    if (null != strMember)
                                    {
                                        btfr.StrElementList.Add(strMember);
                                    }
                                    if (null != strAmount)
                                    {
                                        btfr.StrElementList.Add(strAmount);
                                    }
                                    btfrList.Add(btfr);
                                }
                                #endregion
                            }
                        }
                    }
                }
                #endregion
            }
            else if (null != arrMachineNo && null == arrPaperType && null != arrPaperSec)
            {
                #region//机器制约纸型
                //获取机器制约纸型依赖关系Id
                FactorRelation factorRelation = new FactorRelation();
                factorRelation.PriceFactorId = machineId;
                factorRelation.PriceFactorId2 = paperSecId;
                factorRelation.BusinessTypeId = baseBusinessTypePriceSet.BusinessType.Id;
                long factorRelationId = factorRelationValueDao.GetFactorRelationId(factorRelation);
                foreach (string strMachineNo in arrMachineNo)
                {
                    foreach (string strPaperSec in arrPaperSec)
                    {
                        FactorRelationValue factorRelationValue = new FactorRelationValue();
                        factorRelationValue.FactorRelationId = factorRelationId;
                        factorRelationValue.SourceValue = Convert.ToInt32(strMachineNo);
                        factorRelationValue.TargetValue = Convert.ToInt32(strPaperSec);
                        if (CheckFactorRelationIsExist(factorRelationValue)) 
                        {
                            btfr = new BusinessTypeFactorRelation();
                            btfr.StrElementList.Add(strProcess);
                            btfr.StrElementList.Add(strMachineNo);
                            btfr.StrElementList.Add(strPaperSec);
                            if (null != strTicket)
                            {
                                btfr.StrElementList.Add(strTicket);
                            }
                            if (null != strMember)
                            {
                                btfr.StrElementList.Add(strMember);
                            }
                            if (null != strAmount)
                            {
                                btfr.StrElementList.Add(strAmount);
                            }
                            btfrList.Add(btfr);
                        }
                    }
                }
                #endregion
            }
            else if (null != arrMachineNo && null != arrPaperType && null == arrPaperSec)
            {
                #region//机器制约纸质
                //获取机器制约纸质依赖关系Id
                FactorRelation factorRelation = new FactorRelation();
                factorRelation.PriceFactorId = machineId;
                factorRelation.PriceFactorId2 =paperTypeId;
                factorRelation.BusinessTypeId = baseBusinessTypePriceSet.BusinessType.Id;
                long factorRelationId = factorRelationValueDao.GetFactorRelationId(factorRelation);
                foreach (string strMachineNo in arrMachineNo)
                {
                    foreach (string strPaperType in arrPaperType)
                    {
                        FactorRelationValue factorRelationValue = new FactorRelationValue();
                        factorRelationValue.FactorRelationId = factorRelationId;
                        factorRelationValue.SourceValue = Convert.ToInt32(strMachineNo);
                        factorRelationValue.TargetValue = Convert.ToInt32(strPaperType);
                        if (CheckFactorRelationIsExist(factorRelationValue))
                        {
                            btfr = new BusinessTypeFactorRelation();
                            btfr.StrElementList.Add(strProcess);
                            btfr.StrElementList.Add(strMachineNo);
                            btfr.StrElementList.Add(strPaperType);
                            if (null != strTicket)
                            {
                                btfr.StrElementList.Add(strTicket);
                            }
                            if (null != strMember)
                            {
                                btfr.StrElementList.Add(strMember);
                            }
                            if (null != strAmount)
                            {
                                btfr.StrElementList.Add(strAmount);
                            }
                            btfrList.Add(btfr);
                        }
                    }
                }
                #endregion
            }
            else
            {
                #region//其他情况
                if (null != arrPaperType && null != arrPaperSec)
                {
                    #region//纸质制约纸型
                    //获取纸质制约纸型依赖关系Id
                    FactorRelation factorRelation = new FactorRelation();
                    factorRelation.PriceFactorId = paperTypeId;
                    factorRelation.PriceFactorId2 = paperSecId;
                    factorRelation.BusinessTypeId = baseBusinessTypePriceSet.BusinessType.Id;
                    long factorRelationId = factorRelationValueDao.GetFactorRelationId(factorRelation);
                    foreach (string strPaperType in arrPaperType)
                    {
                        foreach (string strPaperSec in arrPaperSec)
                        {
                            FactorRelationValue factorRelationValue = new FactorRelationValue();
                            factorRelationValue.FactorRelationId = factorRelationId;
                            factorRelationValue.SourceValue = Convert.ToInt32(strPaperType);
                            factorRelationValue.TargetValue = Convert.ToInt32(strPaperSec);
                            if (CheckFactorRelationIsExist(factorRelationValue))
                            {
                                btfr = new BusinessTypeFactorRelation();
                                btfr.StrElementList.Add(strProcess);
                                btfr.StrElementList.Add(strPaperType);
                                btfr.StrElementList.Add(strPaperSec);
                                if (null != strTicket)
                                {
                                    btfr.StrElementList.Add(strTicket);
                                }
                                if (null != strMember)
                                {
                                    btfr.StrElementList.Add(strMember);
                                }
                                if (null != strAmount)
                                {
                                    btfr.StrElementList.Add(strAmount);
                                }
                                btfrList.Add(btfr);
                            }
                        }
                    }
                    #endregion
                }
                else if(null == arrPaperType && null != arrPaperSec)
                {
                    foreach (string strPaperSec in arrPaperSec)
                    {
                        btfr = new BusinessTypeFactorRelation();
                        btfr.StrElementList.Add(strProcess);
                        btfr.StrElementList.Add(strPaperSec);
                        if (null != strTicket)
                        {
                            btfr.StrElementList.Add(strTicket);
                        }
                        if (null != strMember)
                        {
                            btfr.StrElementList.Add(strMember);
                        }
                        if (null != strAmount)
                        {
                            btfr.StrElementList.Add(strAmount);
                        }
                        btfrList.Add(btfr);
                    }
                }
                else if (null != arrPaperType && null == arrPaperSec)
                {
                    foreach (string strPaperType in arrPaperType)
                    {
                        btfr = new BusinessTypeFactorRelation();
                        btfr.StrElementList.Add(strProcess);;
                        btfr.StrElementList.Add(strPaperType);
                        if (null != strTicket)
                        {
                            btfr.StrElementList.Add(strTicket);
                        }
                        if (null != strMember)
                        {
                            btfr.StrElementList.Add(strMember);
                        }
                        if (null != strAmount)
                        {
                            btfr.StrElementList.Add(strAmount);
                        }
                        btfrList.Add(btfr);
                    }
                }
                #endregion
            }
            #endregion

            BaseBusinessTypePriceSet bbtp=new BaseBusinessTypePriceSet();
            bbtp.BusinessType = new BusinessType();
            bbtp.BusinessType.Id = baseBusinessTypePriceSet.BusinessType.Id;
            bbtp.CostPrice = baseBusinessTypePriceSet.CostPrice;//成本价格
            bbtp.StandardPrice = baseBusinessTypePriceSet.StandardPrice;//标准价格
            bbtp.ActivityPrice = baseBusinessTypePriceSet.ActivityPrice; //活动价格
            bbtp.ReservePrice = baseBusinessTypePriceSet.ReservePrice;//备用价格
            
            //录入价格因素
            foreach (BusinessTypeFactorRelation busTyFRe in btfrList) 
            {
                int index=0;
                foreach(string str in busTyFRe.StrElementList)
                {
                    bbtp.SetItem(index, Convert.ToInt32(str));
                    index++;
                }
                baseBusinessTypePriceSetDao.Insert(bbtp);
            }
           
        }

        /// <summary>
        /// 方法名称: CheckFactorRelationIsExist
        /// 功能概要: 检查是否存在这样的关系依赖
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月25日17:13:16
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        public bool CheckFactorRelationIsExist(FactorRelationValue factorRelationValue) 
        {
            bool booExist = false;

            factorRelationValue.CompanyId= Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            factorRelationValue.BranchShopId=Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            int countBusPriceFactor = (int)factorRelationValueDao.CheckFactorIsRelation(factorRelationValue);
            if (countBusPriceFactor>0)
            {
                booExist = true;
            }
            return booExist;
        }

        /// <summary>
        /// 方法名称: UpdateBaseBusinessTypePriceSet
        /// 功能概要: 更新门市价格设置
        /// 作    者: 麻少华
        /// 创建时间: 2007-9-19
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="baseBusinessTypePriceSetList"></param>
        public void UpdateBaseBusinessTypePriceSet(IList<BaseBusinessTypePriceSet> baseBusinessTypePriceSetList)
        {
            for (int i = 0; i < baseBusinessTypePriceSetList.Count; i++)
            {
                baseBusinessTypePriceSetDao.Update(baseBusinessTypePriceSetList[i]);   
            }
        }
        /// <summary>
        /// 方法名称: DeleteBaseBusinessTypePriceSet
        /// 功能概要: 删除门市价格设置
        /// 作    者: 麻少华
        /// 创建时间: 2007-9-19
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="baseBusinessTypePriceSet"></param>
        public void DeleteBaseBusinessTypePriceSet(BaseBusinessTypePriceSet baseBusinessTypePriceSet)
        {
            baseBusinessTypePriceSetDao.Delete(baseBusinessTypePriceSet.Id);
        }

        /// <summary>
        /// 方法名称: GetRelatedPrice
        /// 功能概要: 得到业务类型关联的价格因素以及价格因素的数值
        /// 作    者: 麻少华
        /// 创建时间: 2007-9-24
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="factorRelation"></param>
        /// <param name="businessType"></param>
        /// <returns></returns>
        public IList<PriceFactor> GetRelatedPrice(FactorRelation factorRelation)
        {
            IList<PriceFactor> priceFactorList = new List<PriceFactor>();

            if (factorRelation.PriceFactorId == 0)
            {
                BusinessType businessType = businessTypeDao.SelectByPk(factorRelation.BusinessTypeId);
                if (null == businessType) return priceFactorList;
                foreach (PriceFactor pf in businessType.PriceFactorList)
                {
                    //if (pf.FactorValueList.Count == 0)
                    //    pf.FactorValueList = factorValueDao.GetFactorValueListByPriceFactor(pf);

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
            return priceFactorList;
        }
        #endregion
        
        #region 业务价格设置
        /// <summary>
        /// 方法名称: GetBusinessTypePriceSetList
        /// 功能概要: 获得业务价格设置一览
        /// 作    者: 麻少华
        /// 创建时间: 2007-9-19
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <returns></returns>
        public IList<BusinessTypePriceSet> GetBusinessTypePriceSetList()
        {
            int inti = 0, intj = 0, intk = 0;
            int intFoundPos = 0;
            bool blnFound;

            //门市价格设置List
            IList<BusinessTypePriceSet> businessTypePriceSetList;
            businessTypePriceSetList = businessTypePriceSetDao.SelectAll();

            //价格因素
            IList<PriceFactor> priceFactorList;
            priceFactorList = masterDataService.GetPriceFactors();

            //因素值
            string strFactorValue = "";

            inti = businessTypePriceSetList.Count;
            for (int i = 0; i < inti; i++)
            {
                intj = priceFactorList.Count;
                intk = businessTypePriceSetList[i].BusinessType.PriceFactorList.Count;
                //找到的位置
                intFoundPos = 0;
                //因素值数组
                string[] texts = new string[intj];
                for (int j = 0; j < intj; j++)
                {
                    blnFound = false;
                    for (int k = 0; k < intk; k++)
                    {
                        if (businessTypePriceSetList[i].BusinessType.PriceFactorList[k].Id == priceFactorList[j].Id)
                        {
                            //业务类型ID
                            priceFactorList[j].BusinessTypeId = businessTypePriceSetList[i].BusinessType.Id;
                            //因素值Id的设置
                            priceFactorList[j].PriceValueId = businessTypePriceSetList[i][intFoundPos++];
                            blnFound = true;
                            break;
                        }
                    }

                    //循环结束,还没有找到业务类型下因素值ID,说明当前业务类型下没有因素的设置(设置为-1用来标识)
                    if (!blnFound)
                    {
                        priceFactorList[j].PriceValueId = -1;
                    }
                    //对于因素值的取得,如果TargetTable中没有设置说明是从公共表中取得
                    if (priceFactorList[j].TargetTable == null || priceFactorList[j].TargetTable == "")
                    {   //因素Id的设置
                        priceFactorList[j].PriceFactorId = priceFactorList[j].Id;
                    }
                    else
                    {
                        //因素Id的设置
                        priceFactorList[j].PriceFactorId = 0;
                    }
                    //取得因素的值
                    strFactorValue = masterDataService.GetFactorValueText(priceFactorList[j]);
                    texts[j] = strFactorValue;
                }
                businessTypePriceSetList[i].Texts = texts;
            }
            return businessTypePriceSetList;
        }

        /// <summary>
        /// 方法名称: GetBusinessTypePriceSetById
        /// 功能概要: 根据ID取得单条业务价格设置的信息
        /// 作    者: 麻少华
        /// 创建时间: 2007-9-26
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="businessTypePriceSet"></param>
        /// <returns></returns>
        public BusinessTypePriceSet GetBusinessTypePriceSetById(BusinessTypePriceSet businessTypePriceSet)
        {
            return businessTypePriceSetDao.SelectByPk(businessTypePriceSet.Id);
        }
        /// <summary>
        /// 方法名称: GetBusinessTypePriceSetListCustomQuery
        /// 功能概要: 获得业务价格设置一览(自定义查询)
        /// 作    者: 麻少华
        /// 创建时间: 2007-9-19
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="businessTypePriceSet);"></param>
        /// <returns></returns>
        public IList<BusinessTypePriceSet> GetBusinessTypePriceSetListCustomQuery(BusinessTypePriceSet businessTypePriceSet)
        {
            int inti = 0, intj = 0, intk = 0;
            int intFoundPos = 0;
            bool blnFound;

            //门市价格设置List
            IList<BusinessTypePriceSet> businessTypePriceSetList;
            businessTypePriceSetList = businessTypePriceSetDao.GetBusinessTypePriceSetListCustomQuery(businessTypePriceSet);

            //价格因素
            IList<PriceFactor> priceFactorList;
            priceFactorList = masterDataService.GetPriceFactors();

            //因素值
            string strFactorValue = "";

            inti = businessTypePriceSetList.Count;
            for (int i = 0; i < inti; i++)
            {
                intj = priceFactorList.Count;
                intk = businessTypePriceSetList[i].BusinessType.PriceFactorList.Count;
                //找到的位置
                intFoundPos = 0;
                //因素值数组
                string[] texts = new string[intj];
                for (int j = 0; j < intj; j++)
                {
                    blnFound = false;
                    for (int k = 0; k < intk; k++)
                    {
                        if (businessTypePriceSetList[i].BusinessType.PriceFactorList[k].Id == priceFactorList[j].Id)
                        {
                            //业务类型ID
                            priceFactorList[j].BusinessTypeId = businessTypePriceSetList[i].BusinessType.Id;
                            //因素值Id的设置
                            priceFactorList[j].PriceValueId = businessTypePriceSetList[i][intFoundPos++];
                            blnFound = true;
                            break;
                        }
                    }

                    //循环结束,还没有找到业务类型下因素值ID,说明当前业务类型下没有因素的设置(设置为-1用来标识)
                    if (!blnFound)
                    {
                        priceFactorList[j].PriceValueId = -1;
                    }
                    //对于因素值的取得,如果TargetTable中没有设置说明是从公共表中取得
                    if (priceFactorList[j].TargetTable == null || priceFactorList[j].TargetTable == "")
                    {   //因素Id的设置
                        priceFactorList[j].PriceFactorId = priceFactorList[j].Id;
                    }
                    else
                    {
                        //因素Id的设置
                        priceFactorList[j].PriceFactorId = 0;
                    }
                    //取得因素的值
                    strFactorValue = masterDataService.GetFactorValueText(priceFactorList[j]);
                    texts[j] = strFactorValue;
                }
                businessTypePriceSetList[i].Texts = texts;
            }
            return businessTypePriceSetList;
        }

        /// <summary>
        /// 不论是否经过价格设置,都显示
        /// </summary>
        /// <param name="businessTypePriceSet"></param>
        /// <returns></returns>
        public IList<BusinessTypePriceSet> GetAllBusinessTypePriceSetListCustomQuery(BusinessTypePriceSet businessTypePriceSet)
        {

            int inti = 0, intj = 0, intk = 0;
            int intFoundPos = 0;
            bool blnFound;

            //门市价格设置List
            IList<BusinessTypePriceSet> businessTypePriceSetList;
            businessTypePriceSetList = businessTypePriceSetDao.GetAllBusinessTypePriceSetListCustomQuery (businessTypePriceSet);

            //价格因素
            IList<PriceFactor> priceFactorList;
            priceFactorList = masterDataService.GetPriceFactors();

            //因素值
            string strFactorValue = "";

            inti = businessTypePriceSetList.Count;
            for (int i = 0; i < inti; i++)
            {
                intj = priceFactorList.Count;
                intk = businessTypePriceSetList[i].BusinessType.PriceFactorList.Count;
                //找到的位置
                intFoundPos = 0;
                //因素值数组
                string[] texts = new string[intj];
                for (int j = 0; j < intj; j++)
                {
                    blnFound = false;
                    for (int k = 0; k < intk; k++)
                    {
                        if (businessTypePriceSetList[i].BusinessType.PriceFactorList[k].Id == priceFactorList[j].Id)
                        {
                            //业务类型ID
                            priceFactorList[j].BusinessTypeId = businessTypePriceSetList[i].BusinessType.Id;
                            //因素值Id的设置
                            priceFactorList[j].PriceValueId = businessTypePriceSetList[i][intFoundPos++];
                            blnFound = true;
                            break;
                        }
                    }

                    //循环结束,还没有找到业务类型下因素值ID,说明当前业务类型下没有因素的设置(设置为-1用来标识)
                    if (!blnFound)
                    {
                        priceFactorList[j].PriceValueId = -1;
                    }
                    //对于因素值的取得,如果TargetTable中没有设置说明是从公共表中取得
                    if (priceFactorList[j].TargetTable == null || priceFactorList[j].TargetTable == "")
                    {   //因素Id的设置
                        priceFactorList[j].PriceFactorId = priceFactorList[j].Id;
                    }
                    else
                    {
                        //因素Id的设置
                        priceFactorList[j].PriceFactorId = 0;
                    }
                    //取得因素的值
                    strFactorValue = masterDataService.GetFactorValueText(priceFactorList[j]);
                    texts[j] = strFactorValue;
                }
                businessTypePriceSetList[i].Texts = texts;
            }
            return businessTypePriceSetList;
        }


        /// <summary>
        /// 经过会员或行业价格设置的
        /// </summary>
        /// <param name="businessTypePriceSet"></param>
        /// <returns></returns>

        public IList<BusinessTypePriceSet> GetOnlyBusinessTypePriceSetListCustomQuery(BusinessTypePriceSet businessTypePriceSet)
        {

            int inti = 0, intj = 0, intk = 0;
            int intFoundPos = 0;
            bool blnFound;

            //门市价格设置List
            IList<BusinessTypePriceSet> businessTypePriceSetList;
            businessTypePriceSetList = businessTypePriceSetDao.GetOnlyBusinessTypePriceSetListCustomQuery(businessTypePriceSet);

            //价格因素
            IList<PriceFactor> priceFactorList;
            priceFactorList = masterDataService.GetPriceFactors();

            //因素值
            string strFactorValue = "";

            inti = businessTypePriceSetList.Count;
            for (int i = 0; i < inti; i++)
            {
                intj = priceFactorList.Count;
                intk = businessTypePriceSetList[i].BusinessType.PriceFactorList.Count;
                businessTypePriceSetList[i].TargetName = GetTargetName(businessTypePriceSetList[i]);
                //找到的位置
                intFoundPos = 0;
                //因素值数组
                string[] texts = new string[intj];
                for (int j = 0; j < intj; j++)
                {
                    blnFound = false;
                    for (int k = 0; k < intk; k++)
                    {
                        if (businessTypePriceSetList[i].BusinessType.PriceFactorList[k].Id == priceFactorList[j].Id)
                        {
                            //业务类型ID
                            priceFactorList[j].BusinessTypeId = businessTypePriceSetList[i].BusinessType.Id;
                            //因素值Id的设置
                            priceFactorList[j].PriceValueId = businessTypePriceSetList[i][intFoundPos++];
                            blnFound = true;
                            break;
                        }
                    }

                    //循环结束,还没有找到业务类型下因素值ID,说明当前业务类型下没有因素的设置(设置为-1用来标识)
                    if (!blnFound)
                    {
                        priceFactorList[j].PriceValueId = -1;
                    }
                    //对于因素值的取得,如果TargetTable中没有设置说明是从公共表中取得
                    if (priceFactorList[j].TargetTable == null || priceFactorList[j].TargetTable == "")
                    {   //因素Id的设置
                        priceFactorList[j].PriceFactorId = priceFactorList[j].Id;
                    }
                    else
                    {
                        //因素Id的设置
                        priceFactorList[j].PriceFactorId = 0;
                    }
                    //取得因素的值
                    strFactorValue = masterDataService.GetFactorValueText(priceFactorList[j]);
                    texts[j] = strFactorValue;
                }
                businessTypePriceSetList[i].Texts = texts;
            }
            return businessTypePriceSetList;
        }


        /// <summary>
        /// 获取BusinessTypePriceSet对应的会员卡级别或者行业名称
        /// </summary>
        /// <param name="bizPriceSet"></param>
        public string GetTargetName(BusinessTypePriceSet bizPriceSet)
        {
            return businessTypePriceSetDao.GetTargetName(bizPriceSet);
        }

        /// <summary>
        /// 不论是否经过价格设置,都统计
        /// </summary>
        /// <param name="businessTypePriceSet"></param>
        /// <returns></returns>
        public long GetAllBusinessTypePriceSetListCustomQueryCount(BusinessTypePriceSet businessTypePriceSet)
        {
            return businessTypePriceSetDao.GetAllBusinessTypePriceSetListCustomQueryCount(businessTypePriceSet);
        }

        /// <summary>
        /// 经过会员或行业价格设置的
        /// </summary>
        /// <param name="businessTypePriceSet"></param>
        /// <returns></returns>
        public long GetOnlyBusinessTypePriceSetListCustomQueryCount(BusinessTypePriceSet businessTypePriceSet)
        {
            return businessTypePriceSetDao.GetOnlyBusinessTypePriceSetListCustomQueryCount(businessTypePriceSet);
        }


        /// <summary>
        /// 方法名称: InsertBusinessTypePriceSet
        /// 功能概要: 追加业务价格设置
        /// 作    者: 麻少华
        /// 创建时间: 2007-9-19
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="businessTypePriceSet);"></param>
        public void InsertBusinessTypePriceSet(IList<BusinessTypePriceSet> businessTypePriceSet)
        {
            for (int i = 0; i < businessTypePriceSet.Count; i++)
            {
                businessTypePriceSetDao.Insert(businessTypePriceSet[i]);
            }
        }
        /// <summary>
        /// 方法名称: UpdateBusinessTypePriceSet
        /// 功能概要: 更新业务价格设置
        /// 作    者: 麻少华
        /// 创建时间: 2007-9-19
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="businessTypePriceSet);"></param>
        public void UpdateBusinessTypePriceSet(IList<BusinessTypePriceSet> businessTypePriceSet)
        {
            for (int i = 0; i < businessTypePriceSet.Count; i++)
            {
                businessTypePriceSetDao.Update(businessTypePriceSet[i]);
            }
        }
        /// <summary>
        /// 方法名称: DeleteBusinessTypePriceSet
        /// 功能概要: 删除业务价格设置
        /// 作    者: 麻少华
        /// 创建时间: 2007-9-19
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="businessTypePriceSet);"></param>
        public void DeleteBusinessTypePriceSet(BusinessTypePriceSet businessTypePriceSet)
        {
            businessTypePriceSetDao.Delete(businessTypePriceSet.Id);
        }
        #endregion

        #region 获取价格
        /// <summary>
        /// 获取价格
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强　
        /// 创建时间: 2007-10-6
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public BaseBusinessTypePriceSet GetPrice(BaseBusinessTypePriceSet baseBusinessTypePriceSet)
        {
            return baseBusinessTypePriceSetDao.GetTheLowerestPrice(baseBusinessTypePriceSet);
        }
        public BusinessTypePriceSet GetPrice(BusinessTypePriceSet businessTypePriceSet)
        {
            BusinessTypePriceSet btps =businessTypePriceSetDao.GetPrice(businessTypePriceSet);
            if (null==btps || -1 == btps.Id || -1==btps.StandardPrice)// || 0 == decimal.Parse(price.ToString()) || -1 == decimal.Parse(price.ToString()))
            {
                BaseBusinessTypePriceSet baseBusinessTypePriceSet = new BaseBusinessTypePriceSet();
                baseBusinessTypePriceSet.BusinessTypeId = businessTypePriceSet.BusinessTypeId;
                for (int i = 0; i < 19; i++)
                {
                    baseBusinessTypePriceSet[i] = businessTypePriceSet[i];
                }
                BaseBusinessTypePriceSet bbtps=baseBusinessTypePriceSetDao.GetTheLowerestPrice(baseBusinessTypePriceSet);
                btps.StandardPrice = bbtps.StandardPrice;
                btps.Id = bbtps.Id;
                return btps;
            }
            else
            {
                //如果找到非门市价格,则覆盖标准价格 新价格优先 ，如果没有设置新价格 则使用折扣
                if (btps.NewPrice > 0)
                {
                    btps.StandardPrice = btps.NewPrice;
                }
                else if (btps.PriceConcession > 0)
                {
                    btps.StandardPrice = btps.StandardPrice * btps.PriceConcession / 100;
                }
                return btps;//decimal.Parse(price.ToString()); 
            }
        }
        #endregion

        #region 获取数量段
        public IList<AmountSegment> GetAmountSegmentList()
        {
            return amountSegmentDao.SelectAll();
        }
        #endregion

		#region 获取市场价格带分页
		
		/// <summary>
        /// 方法名称: GetBaseBusinessTypePriceList
        /// 功能概要: 获取市场价格带分页
        /// 作    者: 陈汝胤
        /// 创建时间: 2009-1-9
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        public IList<BaseBusinessTypePriceSet> GetBaseBusinessTypePriceList(BaseBusinessTypePriceSet baseBusinessTypePriceSet)
        {
            int inti = 0, intj = 0, intk = 0;
            int intFoundPos = 0;
            bool blnFound;
            IList<BaseBusinessTypePriceSet> baseBusinessTypePriceSetList= baseBusinessTypePriceSetDao.GetBaseBusinessTypePriceSetDao(baseBusinessTypePriceSet);
            //价格因素
            IList<PriceFactor> priceFactorList;
            priceFactorList = masterDataService.GetPriceFactors();

            //因素值
            string strFactorValue = "";
            inti = baseBusinessTypePriceSetList.Count;
            for (int i = 0; i < inti; i++)
            {
                intj = priceFactorList.Count;
                intk = baseBusinessTypePriceSetList[i].BusinessType.PriceFactorList.Count;
                //因素值数组
                string[] texts = new string[intj];
                //找到的位置
                intFoundPos = 0;
                for (int j = 0; j < intj; j++)
                {
                    blnFound = false;
                    for (int k = intFoundPos; k < intk; k++)
                    {
                        if (baseBusinessTypePriceSetList[i].BusinessType.PriceFactorList[k].Id == priceFactorList[j].Id)
                        {
                            //业务类型ID
                            priceFactorList[j].BusinessTypeId = baseBusinessTypePriceSetList[i].BusinessType.Id;
                            //因素值Id的设置
                            priceFactorList[j].PriceValueId = baseBusinessTypePriceSetList[i][intFoundPos++];
                            blnFound = true;
                            break;
                        }
                    }

                    //循环结束,还没有找到业务类型下因素值ID,说明当前业务类型下没有因素的设置(设置为-1用来标识)
                    if (!blnFound)
                    {
                        priceFactorList[j].PriceValueId = -1;
                    }
                    ////业务类型ID
                    //priceFactorList[j].BusinessTypeId = baseBusinessTypePriceSetList[i].BusinessType.Id;
                    ////因素值Id的设置
                    //priceFactorList[j].PriceValueId = baseBusinessTypePriceSetList[i].Item(j);
                    //对于因素值的取得,如果TargetTable中没有设置说明是从公共表中取得
                    if (priceFactorList[j].TargetTable == null || priceFactorList[j].TargetTable == "")
                    {   //因素Id的设置
                        priceFactorList[j].PriceFactorId = priceFactorList[j].Id;
                    }
                    else
                    {
                        //因素Id的设置
                        priceFactorList[j].PriceFactorId = 0;
                    }
                    //取得因素的值
                    //if (priceFactorList[j].IsDisplay == "Y")
                    strFactorValue = masterDataService.GetFactorValueText(priceFactorList[j]);
                    //else
                    //    strFactorValue = "";

                    texts[j] = strFactorValue;
                }
                baseBusinessTypePriceSetList[i].Texts = texts;
            }
            return baseBusinessTypePriceSetList;
            
        }
		#endregion

    }
}
