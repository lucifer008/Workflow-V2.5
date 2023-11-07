using System;
using System.Collections.Generic;
using System.Text;
using log4net.Config;
using System.IO;
using log4net;

namespace Workflow.FileCleaner.Log
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
        private static string LOCAL_LOG_CONFIG_NAME = "log.config";
        //private static string PARENT_LOG_CONFIG_NAME = "log4net.config";

        private static ILog CreateInstance(string className)
        {
            LOG = LogManager.GetLogger(className);
            return LOG;
        }

        public static void WriteError(System.Exception ex,string LoggerName)
        {
            if (null == LOG)
                CreateInstance(LoggerName);
            LOG.Error("", ex);
        }
        public static void WriteError(System.Exception ex, object o)
        {
            string LoggerName = o.GetType().BaseType.Name;
            if (null == LOG)
                CreateInstance(LoggerName);
            LOG.Error("", ex);
        }
        public static void WriteError(string errMsg, System.Exception ex, object o)
        {
            string LoggerName = o.GetType().BaseType.Name;
            if (null == LOG)
                CreateInstance(LoggerName);
            LOG.Error(errMsg, ex);
        }
        public static void WriteError(string msg, object o)
        {
            string LoggerName = o.GetType().BaseType.Name;
            if (null == LOG)
                CreateInstance(LoggerName);
            LOG.Error(msg);

        }
        public static void WriteInfo(System.Exception ex, string loggerName)
        {
            if (null == LOG)
                CreateInstance(loggerName);
            LOG.Info("", ex);
        }
        //public static void WriteInfo(System.Exception ex, object o)
        //{
        //    string LoggerName = o.GetType().BaseType.Name;
        //    if (null == LOG)
        //        CreateInstance(LoggerName);
        //    LOG.Info("", ex);
        //}
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

    }
}
