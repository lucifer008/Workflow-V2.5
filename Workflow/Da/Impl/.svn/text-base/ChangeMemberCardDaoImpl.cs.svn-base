using System;
using System.Collections;
using System.Collections.Generic;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Da;

namespace Workflow.Da.Impl
{
	/// <summary>
    /// 名    称：ChangeMemberCardDaoImpl
    /// 功能概要:IChangeMemberCardDao接口实现
    /// 作    者:
    /// 创建时间:
    /// 修正履历：
    /// 修正时间:
	/// </summary>
    public class ChangeMemberCardDaoImpl : Workflow.Da.Base.DaoBaseImpl<ChangeMemberCard>, IChangeMemberCardDao
    {
        #region //查询换卡纪录
        //public IList<ChangeMemberCard> SelectChangMemberCard(System.Collections.Hashtable condition)
        //{
        //    return sqlMap.QueryForList<ChangeMemberCard>("ChangeMemberCard.SelectChageMemberCard", condition);
        //}

        /// <summary>
        /// 查询会员卡会卡记录
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年4月2日10:24:42
        /// 修正履历:
        /// 修正时间: 
        ///</remarks>
        public IList<ChangeMemberCard> SearchChangeMemberCard(Hashtable condition)
        {
            condition.Add("CompanyId",ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            condition.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            return sqlMap.QueryForList<ChangeMemberCard>("ChangeMemberCard.SearchChangeMemberCard", condition);
        }

        /// <summary>
        /// 查询会员卡会卡记录数
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年4月2日10:24:42
        /// 修正履历:
        /// 修正时间: 
        ///</remarks>
        public long SearchChangeMemberCardRowCount(Hashtable condition) 
        {
            return sqlMap.QueryForObject<long>("ChangeMemberCard.SearchChangeMemberCardRowCount", condition);
        }

        /// <summary>
        /// 查询会员卡会卡记录(打印)
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年4月2日10:24:42
        /// 修正履历:
        /// 修正时间: 
        ///</remarks>
        public IList<ChangeMemberCard> SearchChangeMemberCardPrint(Hashtable condition) 
        {
            return sqlMap.QueryForList<ChangeMemberCard>("ChangeMemberCard.SearchChangeMemberCardPrint", condition);
        }
        #endregion
    }
}
