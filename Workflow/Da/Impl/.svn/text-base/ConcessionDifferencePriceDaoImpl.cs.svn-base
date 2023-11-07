using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table CONCESSION_DIFFERENCE_PRICE 对应的Dao 实现
	/// </summary>
    public class ConcessionDifferencePriceDaoImpl : Workflow.Da.Base.DaoBaseImpl<ConcessionDifferencePrice>, IConcessionDifferencePriceDao
    {
        #region 通过ConcessionID 删除ConcessionDifferencePrice表中相关信息
        public void DeletedConcessionDifferencePriceByConcessionId(long Id)
        {
            sqlMap.Delete("ConcessionDifferencePrice.DeletedConcessionDifferencePriceByConcessionId", Id);
        }
        #endregion

        #region 通过CampaignID删除ConcessionDifferencePrice表中相关信息
        public void DeleteConcessionDifferencePriceByCampaignId(long Id)
        {
            sqlMap.Delete("ConcessionDifferencePrice.DeleteByCampaignId", Id);
        }
        #endregion

        #region 通过ConcessionId查询ConcessionDifferencePrice表中相关信息
        public IList<ConcessionDifferencePrice> SelectDifferencePriceByConcessionId(long Id)
        {
            return sqlMap.QueryForList<ConcessionDifferencePrice>("ConcessionDifferencePrice.SelectByConcessionId", Id);
        }
        #endregion
    }
}
