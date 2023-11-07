using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table MEMBER_CARD_CONCESSION 对应的Dao 接口
	/// </summary>
    public interface IMemberCardConcessionDao : IDaoBase<MemberCardConcession>
    {
        /// <summary>
        /// 新卡号替换原卡号
        /// </summary>
        /// <param name="orderId">condition</param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 刘伟
        /// 创建时间: 2007-10-7
        /// 修正履历:
        /// 修正时间:
        /// </remarks>	

        void UpdateMemberCardId(System.Collections.Hashtable condition);
        /// <summary>
        /// 查找某一个会员卡下的优惠活动
        /// </summary>
        /// <param name="memberCardConcession">condition</param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-22
        /// 修正履历:
        /// 修正时间:
        /// </remarks>	
        IList<MemberCardConcession> SelectMemberCardConcessionByPriceIdAndConcessionId(MemberCardConcession memberCardConcession);
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
        void UpdateMemberCardConcessionById(MemberCardConcession memberCardConcession);

        ///// <summary>
        ///// 查询会员充值纪录
        ///// </summary>
        ///// <param>condition</param>
        ///// <returns></returns>
        ///// <remarks>
        ///// 作    者: 刘伟
        ///// 创建时间: 2007-10-23
        ///// 修正履历:
        ///// 修正时间:
        ///// </remarks>	
        //IList<MemberCardConcession> SelectChargeRecord(System.Collections.Hashtable condition);

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
        IList<MemberCardConcession> SearchChargeRecord(Hashtable condition);

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
        long SearchChargeRecordRowCount(Hashtable condition);


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
        MemberCardConcession GetMemberCardConcession(MemberCardConcession memberCardConcession); 

    }
}
