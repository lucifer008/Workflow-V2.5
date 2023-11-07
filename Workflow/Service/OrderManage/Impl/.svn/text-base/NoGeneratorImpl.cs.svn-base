using System;
using System.Collections.Generic;
using System.Text;

namespace Workflow.Service.Impl
{
	public class NoGeneratorImpl : INoGenerator
	{
		private string prefix = "S";

		public string Prefix
		{
			set { prefix = value; }
		}
		#region INoGenerator 成员

        /// <summary>
        /// 名    称:
        /// 功能概要:
        /// 作    者:
        /// 创建时间:
        /// 修 正 人; 白晓宇
        /// 修正履历: 订单号修改为纯数字的 前两位代表分店
        ///           
        /// 修正时间: 2010年7月8日13:22:23
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="branchShopId"></param>
        /// <returns></returns>
		public string GetOrderNo(long orderId,int branchShopId)
		{
            //int pf = 83;
            //if (branchShopId > 1)
            //{
            //    pf = pf + branchShopId;
            //}
            //if (pf > 90)
            //    pf = pf - 26;

            //return (char)pf + orderId.ToString("0000000");
            string pf = branchShopId.ToString("00");

            return pf + orderId.ToString("0000000");
		}

		#endregion

	}
}
