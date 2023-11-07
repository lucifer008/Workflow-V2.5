using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da;
using Workflow.Util;
using Workflow.Support;

namespace Workflow.Service.Impl
{
    /// <summary>
    /// 名    称: Workflow.Service.Impl.ApplicationProperties
    /// 功能概要:
    /// 作    者: 祝新宾
    /// 创建时间: 2007-9-21
    /// 修正履历:
    /// 修正时间:
    /// </summary>
    public class ApplicationPropertyImpl : IApplicationProperty
    {
		private static readonly Common.Logging.ILog LOG = Common.Logging.LogManager.GetLogger(typeof(IApplicationProperty));

        private IApplicationPropertyDao applicationPropertyDao;

		public IApplicationPropertyDao ApplicationPropertyDao
        {
            get { return applicationPropertyDao; }
            set { applicationPropertyDao = value; }
        }
        #region IApplicationProperty 成员

        public string GetProperty(string key)
        {
			return applicationPropertyDao.GetValue(key);
        }

		private readonly string KEY_GET_CONCESSION_PRICE_BASE = "GET_CONCESSION_PRICE_BASE";
		public int GetConcessionPriceBaseRange()
		{
			string value = GetProperty(KEY_GET_CONCESSION_PRICE_BASE);

			int type = NumericUtils.ToInt(value, Constants.CONCESSION_PRICE_BASE_RANGE_BASE);

			switch (type)
			{
				case Constants.CONCESSION_PRICE_BASE_RANGE_BASE:
					return type;
				case Constants.CONCESSION_PRICE_BASE_RANGE_MEMBER:
					return type;
				case Constants.CONCESSION_PRICE_BASE_RANGE_TRADE:
					return type;
				case Constants.CONCESSION_PRICE_BASE_RANGE_LOWEST :
					return type;
				default :
					LOG.Warn("参加活动时使用的价格基准的设置不准确。");
					return Constants.CONCESSION_PRICE_BASE_RANGE_BASE;
			}
		}

		#endregion

        /// <summary>
        /// 获取预付款限制方式
        /// </summary>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-15
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        private readonly string KEY_GET_PREPAY_LIMIT_TYPE = "GET_PREPAY_LIMIT_TYPE";
        public string GetPrePayLimit()
        {
            if (StringUtils.IsEmpty(applicationPropertyDao.GetValue(KEY_GET_PREPAY_LIMIT_TYPE)))
            {
                return "N";
            }
            else
            {
                return applicationPropertyDao.GetValue(KEY_GET_PREPAY_LIMIT_TYPE);
            }
        }
	}
}
