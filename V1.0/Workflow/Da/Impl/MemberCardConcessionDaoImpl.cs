using System;
using System.Collections;
using System.Collections.Generic;
using Workflow.Da;
using Workflow.Support;
using Workflow.Da.Domain;
namespace Workflow.Da.Impl
{
	/// <summary>
    /// 名    称：MemberCardConcessionDaoImpl
    /// 功能概要:会员卡充值Dao实现类
    /// 作    者：
    /// 创建时间:
    /// 修正履历:
    /// 修正时间:
	/// </summary>
    public class MemberCardConcessionDaoImpl : Workflow.Da.Base.DaoBaseImpl<MemberCardConcession>, IMemberCardConcessionDao
    {
        #region 新卡号替换原卡号
        public void UpdateMemberCardId(System.Collections.Hashtable condition)
        {
            sqlMap.Update("MemberCardConcession.UpdateMemberCardId", condition);
        }
        #endregion

        #region //查找某一个会员卡下的优惠活动
        /// <summary>
        /// 查找某一个会员卡下的优惠活动
        /// </summary>
        /// <param name="orderId">condition</param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-22
        /// 修正履历:
        /// 修正时间:
        /// </remarks>	
        public IList<MemberCardConcession> SelectMemberCardConcessionByPriceIdAndConcessionId(MemberCardConcession memberCardConcession)
        {
            return sqlMap.QueryForList<MemberCardConcession>("MemberCardConcession.SelectMemberCardConcession", memberCardConcession);
        }
        #endregion

        #region //会员卡消费　更新剩余印张数
        /// <summary>
        /// 会员卡消费　更新剩余印张数
        /// </summary>
        /// <param name="memberCardConcession">condition</param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-22
        /// 修正履历:
        /// 修正时间:
        /// </remarks>	
        public void UpdateMemberCardConcessionById(MemberCardConcession memberCardConcession)
        {
            sqlMap.Update("MemberCardConcession.UpdateMemberCardConcessionRestPaperCount", memberCardConcession);
        }
        #endregion

        #region 查询会员充值信息

        //public IList<MemberCardConcession> SelectChargeRecord(Hashtable condition)
        //{
        //    return sqlMap.QueryForList<MemberCardConcession>("MemberCardConcession.SelectChargeRecord", condition);
        //}

        /// <summary>
        /// 查询会员卡充值记录
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// 作    者: 张晓林
        /// 创建时间: 2009年4月3日11:39:40
        /// 修正履历:
        /// 修正时间:
        /// 
        public IList<MemberCardConcession> SearchChargeRecord(Hashtable condition) 
        {
            //condition.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            //condition.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            return sqlMap.QueryForList<MemberCardConcession>("MemberCard.SearchChargeRecord", condition);
        }

        /// <summary>
        /// 查询会员卡充值记录数
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// 作    者: 张晓林
        /// 创建时间: 2009年4月3日11:39:40
        /// 修正履历:
        /// 修正时间:
        /// 
        public long SearchChargeRecordRowCount(Hashtable condition)
        {
            //condition.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            //condition.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            return sqlMap.QueryForObject<long>("MemberCard.SearchChargeRecordRowCount", condition);
        }
        #endregion

        /// <summary>
        /// 获取匹配的会员参加优惠信息
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年4月17日14:56:27
        /// 修正履历:
        /// 修正时间:
        /// 描    述:
        /// </remarks>
        public MemberCardConcession GetMemberCardConcession(MemberCardConcession memberCardConcession) 
        {
            Hashtable condition=new Hashtable();
            condition.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            condition.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            condition.Add("BaseBusinessTypePriceSetId", memberCardConcession.Id);//BaseBusinessTypePriceSetId
            condition.Add("MemberCardId", memberCardConcession.MemberCardId);
            return sqlMap.QueryForObject<MemberCardConcession>("MemberCardConcession.GetMemberCardConcession", condition);
        }
    }
}
