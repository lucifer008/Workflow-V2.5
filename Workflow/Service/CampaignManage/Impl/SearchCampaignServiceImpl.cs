using System;
using System.Collections;
using System.Collections.Generic;
using Workflow.Da;
using Workflow.Da.Domain;

namespace Workflow.Service.CompaignManage
{
    /// <summary>
    /// 名    称: SearchCompaignServiceImpl
    /// 功能概要: 活动管理查询Service实现
    /// 作    者: 付强
    /// 创建时间: 2007-9-13
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    public class SearchCampaignServiceImpl:ISearchCampaignService
    {
        #region 类成员
        private ICampaignDao campaignDao;
        public ICampaignDao CampaignDao
        {
            set { campaignDao = value; }
        }

        private IConcessionDao concessionDao;
        public IConcessionDao ConcessionDao
        {
            set { concessionDao = value; }
        }
        private IConcessionDifferencePriceDao concessionDifferencePriceDao;
        public IConcessionDifferencePriceDao ConcessionDifferencePriceDao
        {
            set { concessionDifferencePriceDao = value; }
        }
        private IMasterDataService masterDataService;
        public IMasterDataService MasterDataService
        {
            set { masterDataService = value; }
        }

        #endregion

        #region 活动查询

        /// <summary>
        /// 查询所有的营销活动
        /// </summary>
        /// <param name="campaign"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: liuwei
        /// 创建时间: 2007-10-15
        /// 修正履历:
        /// 修正时间:
        /// </remarks>	
        public IList<Campaign> SelectAllCampaign() 
        {
            return campaignDao.SelectAll();
        }

        /// <summary>
        /// 名    称: SelectAllCampaign
        /// 功能概要: 按条件查询所有活动
        /// 作    者: 张晓林
        /// 创建时间: 2009年2月16日14:08:09
        /// 修 正 人: 
        /// 修正时间: 
        /// 描    述: 
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IList<Campaign> SelectAllCampaign(Hashtable condition)
        {
            return campaignDao.SelectAllCampaign(condition);
        }

        /// <summary>
        /// 按条件查询所有的营销活动记录数
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年2月16日13:22:42
        /// 修正履历:
        /// 修正时间:
        /// </remarks>	
        public long SelectAllCampaignRowCount() 
        {
            return campaignDao.SelectAllCampaignRowCount();
        }

        /// <summary>
        /// 名    称: SelectCampaignByCampaignId
        /// 功能概要: 通过ID选择活动
        /// 作    者: 
        /// 创建时间: 
        /// 修 正 人: 付强
        /// 修正时间: 2009-1-21
        /// 描    述: 代码整理
        /// </summary>
        /// <param name="Id">活动ID</param>
        /// <returns>优惠活动</returns>
        public Campaign SelectCampaignByCampaignId(long Id)
        {
            return campaignDao.SelectByPk(Id);
        }
        #endregion

        #region 活动下的具体优惠查询
         /// <summary>
        /// 名    称: SearchConcessionByCampaignId
        /// 功能概要: 通过CampaignId查询该活动具体信息
        /// 作    者: liuwei
        /// 创建时间: 2007-10-7
        /// 修正履历: 张晓林
        /// 修正时间: 2009年2月23日9:56:13
        /// 修正描述: 增加分页功能
        /// </summary>
        /// <param name="Id">CampaignId</param>
        /// <returns></returns>
        public IList<Concession> SearchConcessionByCampaignId(Hashtable condition)
        {
            return concessionDao.SearchConcessionByCampaignId(condition);
        }

        /// <summary>
        /// 名    称: SearchConcessionByCampaignIdRowCount
        /// 功能概要: 通过CampaignId查询Concession的信息记录数
        /// 作    者: 张晓林
        /// 创建时间: 2009年2月23日10:05:01
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public long SearchConcessionByCampaignIdRowCount(Hashtable condition)
        {
            return concessionDao.SearchConcessionByCampaignIdRowCount(condition);
        }

        /// <summary>
        /// 名    称: SeleteConcessionById
        /// 功能概要: 通过ConcessionId查询方案的信息
        /// 作    者: liuwei
        /// 创建时间: 2007-10-18
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="Id">ConcessionId</param>
        /// <returns></returns>
        public Concession SeleteConcessionById(long Id)
        {
            return concessionDao.SelectByPk(Id);
        }
        /// <summary>
        /// 名    称: SearchConcessionDifferencePriceByConcessionId
        /// 功能概要: 通过ConcessionId查询ConcessionDifferencePrice表中的相关信息
        /// 作    者: liuwei
        /// 创建时间: 2007-10-22
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="Id">ConcessionId</param>
        /// <returns></returns>
        public IList<ConcessionDifferencePrice> SearchConcessionDifferencePriceByConcessionId(long Id)
        {
            IList<ConcessionDifferencePrice> concessionDifferencePriceList = concessionDifferencePriceDao.SelectDifferencePriceByConcessionId(Id);

            int inti = 0, intj = 0, intk = 0;
            int intFoundPos = 0;
            bool blnFound;
            //门市价格设置List
            //IList<BaseBusinessTypePriceSet> baseBusinessTypePriceSetList;
            //baseBusinessTypePriceSetList = baseBusinessTypePriceSetDao.GetBaseBusinessTypePriceSetListCustomQuery(baseBusinessTypePriceSet);

            //价格因素
            IList<PriceFactor> priceFactorList;
            priceFactorList = masterDataService.GetPriceFactors();

            //因素值
            string strFactorValue = "";
            inti = concessionDifferencePriceList.Count;
            for (int i = 0; i < inti; i++)
            {
                intj = priceFactorList.Count;
                intk = concessionDifferencePriceList[i].BaseBusinessTypePriceSet.BusinessType.PriceFactorList.Count;
                //因素值数组
                string[] texts = new string[intj];
                //找到的位置
                intFoundPos = 0;
                for (int j = 0; j < intj; j++)
                {
                    blnFound = false;
                    for (int k = intFoundPos; k < intk; k++)
                    {
                        if (concessionDifferencePriceList[i].BaseBusinessTypePriceSet.BusinessType.PriceFactorList[k].Id == priceFactorList[j].Id)
                        {
                            //业务类型ID
                            priceFactorList[j].BusinessTypeId = concessionDifferencePriceList[i].BaseBusinessTypePriceSet.BusinessType.Id;
                            //因素值Id的设置
							priceFactorList[j].PriceValueId = concessionDifferencePriceList[i].BaseBusinessTypePriceSet[intFoundPos++];
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
                    strFactorValue = masterDataService.GetFactorValueText(priceFactorList[j]);
                    texts[j] = strFactorValue;
                }
                concessionDifferencePriceList[i].BaseBusinessTypePriceSet.Texts = texts;
            }

            return concessionDifferencePriceList;
        }
        /// <summary>
        /// 名    称: 
        /// 功能概要: 通过ConcessionId查询CampaignName
        /// 作    者: liuwei
        /// 创建时间: 2007-10-23
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="Id">ConcessionId</param>
        /// <returns></returns>
        public string SelectCampaignNameByConcessionId(long Id)
        {
            return concessionDao.SelectCampaignNameByConcessionId(Id);
        }

        /// <summary>
        /// 名    称: GetAllConcessionListInfo
        /// 功能概要: 按条件获取所有营销活动方案信息
        /// 作    者: 张晓林
        /// 创建时间: 2009年2月23日13:04:28
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public IList<Concession> GetAllConcessionListInfo(Hashtable condition) 
        {
            return concessionDao.GetAllConcessionListInfo(condition);
        }

        /// <summary>
        /// 名    称: GetAllConcessionListInfoRowCount
        /// 功能概要: 按条件获取所有营销活动方案信息记录数
        /// 作    者: 张晓林
        /// 创建时间: 2009年2月23日13:04:28
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public long GetAllConcessionListInfoRowCount(Hashtable condition) 
        {
            return concessionDao.GetAllConcessionListInfoRowCount(condition);
        }

        /// <summary>
        /// 名    称: CheckCampaignIdIsNotUse
        /// 功能概要: 检查该活动是否已经正在使用
        /// 作    者: 张晓林
        /// 创建时间: 2009年2月23日17:35:28
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public long CheckCampaignIdIsNotUse(int campaignId) 
        {
            return campaignDao.CheckCampaignIdIsNotUse(campaignId); 
        }

        /// <summary>
        /// 名    称: CheckCampaignNameIsNotUse
        /// 功能概要: 检查该活动名称是否可用
        /// 作    者: 张晓林
        /// 创建时间: 2009年2月23日17:35:28
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public long CheckCampaignNameIsNotUse(string campaignName) 
        {
            return campaignDao.CheckCampaignNameIsNotUse(campaignName);
        }

        /// <summary>
        /// 名    称:GetConcessionMemberCardLelvelInfo
        /// 功能概要:根据优惠方案Id获取优惠的卡级别
        /// 作    者:张晓林
        /// 创建时间:2009年3月16日14:19:16
        /// 修正时间:
        /// 描    述:
        /// </summary>
        /// <returns></returns>
        public IList<MemberCardLevel> GetConcessionMemberCardLelvelInfo(long concessionId) 
        {
            return campaignDao.GetConcessionMemberCardLelvelInfo(concessionId);
        }

        /// <summary>
        /// 名    称:GetConcessionInfo
        /// 功能概要:获取优惠方案信息
        /// 作    者:张晓林
        /// 创建时间:2009年3月16日14:19:16
        /// 修正时间:
        /// 描    述:
        /// </summary>
        /// <returns></returns>
        public Concession GetConcessionInfo(long concessionId) 
        {
            return campaignDao.GetConcessionInfo(concessionId);
        }
        #endregion
    }
}
