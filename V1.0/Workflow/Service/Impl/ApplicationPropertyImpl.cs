using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da;
using Workflow.Util;
using Workflow.Support;

namespace Workflow.Service.Impl
{
    /// <summary>
    /// ��    ��: Workflow.Service.Impl.ApplicationProperties
    /// ���ܸ�Ҫ:
    /// ��    ��: ף�±�
    /// ����ʱ��: 2007-9-21
    /// ��������:
    /// ����ʱ��:
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
        #region IApplicationProperty ��Ա

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
					LOG.Warn("�μӻʱʹ�õļ۸��׼�����ò�׼ȷ��");
					return Constants.CONCESSION_PRICE_BASE_RANGE_BASE;
			}
		}

		#endregion

        /// <summary>
        /// ��ȡԤ�������Ʒ�ʽ
        /// </summary>
        /// <remarks>
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-10-15
        /// ��������:
        /// ����ʱ��:
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
