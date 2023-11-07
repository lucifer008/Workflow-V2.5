/***********************************************
 * Copyrigth 2008 Phook All rigths reserved
 * 
 * File Name:           Program.cs
 * Creator:             Kevin.Q.Fu
 * Create date:         2008-12-8
 * Last modifier:       
 * Last modity date:    
 * Description:         the control application entry
 * 
 ************************************************/

using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Workflow.FileCleaner.Const;
using Workflow.FileCleaner.XmlParser;
using Workflow.FileCleaner.LogClean;
using Workflow.FileCleaner.LogEntity;
using Workflow.FileCleaner.Log;


namespace Workflow.FileCleaner
{
    class Program
    {
        static void Main(string[] args)
        {
            LogHelper.WriteInfo(Constants.MESSAGE_BEGIN_JOB, Constants.LOGGER_NAME);
            Parser parser = new Parser();
            IList<LogFile> lgFileList = null;
            lgFileList = parser.Parse("LogCleanSetting.xml");
            if (lgFileList == null)
            {
                LogHelper.WriteInfo(Constants.MESSAGE_CONFIGURATION_ERROR, Constants.LOGGER_NAME);
                LogHelper.WriteInfo(Constants.MESSAGE_END_JOB, Constants.LOGGER_NAME);
                return;
            }

            foreach (LogFile lf in lgFileList)
            {
                IClean clean = CleanFactory.GetInstance(lf.CleanType.CleanType);
                if (clean == null)
                {
                    continue;
                }
                clean.Clean(lf);
            }
            LogHelper.WriteInfo(Constants.MESSAGE_END_JOB, Constants.LOGGER_NAME);

        }
    }
}
