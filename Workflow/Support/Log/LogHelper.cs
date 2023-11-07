using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Common.Logging;
using log4net.Config;

namespace Workflow.Support.Log
{
    /// <summary>
    /// 名    称: LogHelper
    /// 功能概要: 写日志的工具类
    /// 作    者: 付强
    /// 创建时间: 2008-11-19
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    public sealed class LogHelper
    {
        
        private static ILog LOG;

        #region 构造函数
        /// <summary>
        /// 名    称: CreateInstance
        /// 功能概要: 构造函数
        /// 作    者: 付强
        /// 创建时间: 2008-11-19
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        private static ILog CreateInstance(string className)
        {
            LOG = LogManager.GetLogger(className);
            return LOG;
        }
        #endregion

        #region 写Log 的方法 Error级别
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

        #region 写Log 的方法 Info级别
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
