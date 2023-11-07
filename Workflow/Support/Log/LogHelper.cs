using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Common.Logging;
using log4net.Config;

namespace Workflow.Support.Log
{
    /// <summary>
    /// ��    ��: LogHelper
    /// ���ܸ�Ҫ: д��־�Ĺ�����
    /// ��    ��: ��ǿ
    /// ����ʱ��: 2008-11-19
    /// ��������: 
    /// ����ʱ��: 
    /// </summary>
    public sealed class LogHelper
    {
        
        private static ILog LOG;

        #region ���캯��
        /// <summary>
        /// ��    ��: CreateInstance
        /// ���ܸ�Ҫ: ���캯��
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2008-11-19
        /// ��������: 
        /// ����ʱ��: 
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        private static ILog CreateInstance(string className)
        {
            LOG = LogManager.GetLogger(className);
            return LOG;
        }
        #endregion

        #region дLog �ķ��� Error����
        public static void WriteError(System.Exception ex,string loggerName)
        {
            if (null == LOG)
                CreateInstance(loggerName);
            LOG.Error("", ex);
        }
        public static void WriteError(string errMsg, System.Exception ex, string loggerName)
        {
            if (null == LOG)
                CreateInstance(loggerName);
            LOG.Error(errMsg, ex);
        }
        public static void WriteError(string msg, string loggerName)
        {
            if (null == LOG)
                CreateInstance(loggerName);
            LOG.Error(msg);

        }
        #endregion

        #region дLog �ķ��� Info����
        public static void WriteInfo(System.Exception ex, string loggerName)
        {
            if (null == LOG)
                CreateInstance(loggerName);
            LOG.Info("", ex);
        }

        public static void WriteInfo(string errMsg, System.Exception ex, string loggerName)
        {
            if (null == LOG)
                CreateInstance(loggerName);
            LOG.Info(errMsg, ex);
        }
        public static void WriteInfo(string msg, string loggerName)
        {
            if (null == LOG)
                CreateInstance(loggerName);
            LOG.Info(msg);

        }
        #endregion

    }
}
