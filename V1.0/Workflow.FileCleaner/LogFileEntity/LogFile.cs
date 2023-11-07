/***********************************************
 * Copyrigth 2008 Phook All rigths reserved
 * 
 * File Name:           LogFile.cs
 * Creator:             Kevin.Q.Fu
 * Create date:         2008-12-8
 * Last modifier:       
 * Last modity date:    
 * Description:         LogFile class
 * 
 ************************************************/

using System;
using System.Text;
using System.Collections.Generic;
namespace Workflow.FileCleaner.LogEntity
{
    public class LogFile
    {
        private string fullName;
        /// <summary>
        /// fullname of the configuration file
        /// </summary>
        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }
        private bool enable;
        /// <summary>
        /// whether or not clean this log file
        /// </summary>
        public bool Enable
        {
            get { return enable; }
            set { enable = value; }
        }
        private LogFileOperation cleanType;
        /// <summary>
        /// clean type 
        /// </summary>
        public LogFileOperation CleanType
        {
            get { return cleanType; }
            set { cleanType = value; }
        }
        private string logDateSuffixFormat;
        /// <summary>
        /// the date suffix format of log flie
        /// </summary>
        public string LogDateSuffixFormat
        {
            get { return logDateSuffixFormat; }
            set { logDateSuffixFormat = value; }
        }

    }
}
