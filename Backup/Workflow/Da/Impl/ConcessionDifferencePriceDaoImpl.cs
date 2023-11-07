using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table CONCESSION_DIFFERENCE_PRICE ��Ӧ��Dao ʵ��
	/// </summary>
    public class ConcessionDifferencePriceDaoImpl : Workflow.Da.Base.DaoBaseImpl<ConcessionDifferencePrice>, IConcessionDifferencePriceDao
    {
        #region ͨ��ConcessionID ɾ��ConcessionDifferencePrice���������Ϣ
        public void DeletedConcessionDifferencePriceByConcessionId(long Id)
        {
            sqlMap.Delete("ConcessionDifferencePrice.DeletedConcessionDifferencePriceByConcessionId", Id);
        }
        #endregion

        #region ͨ��CampaignIDɾ��ConcessionDifferencePrice���������Ϣ
        public void DeleteConcessionDifferencePriceByCampaignId(long Id)
        {
            sqlMap.Delete("ConcessionDifferencePrice.DeleteByCampaignId", Id);
        }
        #endregion

        #region ͨ��ConcessionId��ѯConcessionDifferencePrice���������Ϣ
        public IList<ConcessionDifferencePrice> SelectDifferencePriceByConcessionId(long Id)
        {
            return sqlMap.QueryForList<ConcessionDifferencePrice>("ConcessionDifferencePrice.SelectByConcessionId", Id);
        }
        #endregion
    }
}
