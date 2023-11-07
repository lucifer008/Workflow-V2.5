using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table CHANGE_MEMBER_CARD 对应的Dao 接口
	/// </summary>
    public interface IChangeMemberCardDao : IDaoBase<ChangeMemberCard>
    {
        ///// <summary>
        ///// 查询换卡纪录
        ///// </summary>
        ///// <param name="condition"></param>
        ///// <returns></returns>
        ///// <remarks>
        ///// 作    者: liuwei
        ///// 创建时间: 2007-10-24
        ///// 修正履历:
        ///// 修正时间:
        ///// </remarks>
        //IList<ChangeMemberCard> SelectChangMemberCard(System.Collections.Hashtable condition);

        #region //会员卡换卡记录
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
        IList<ChangeMemberCard> SearchChangeMemberCard(Hashtable condition);


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
        long SearchChangeMemberCardRowCount(Hashtable condition);

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
        IList<ChangeMemberCard> SearchChangeMemberCardPrint(Hashtable condition);
        #endregion
    }
}
