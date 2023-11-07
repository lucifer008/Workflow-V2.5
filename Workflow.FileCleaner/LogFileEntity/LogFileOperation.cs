/***********************************************
 * Copyrigth 2008 Phook All rigths reserved
 * 
 * File Name:           LogProcess.cs
 * Creator:             Kevin.Q.Fu
 * Create date:         2008-12-8
 * Last modifier:       
 * Last modity date:    
 * Description:         Clean task class
 * 
 ************************************************/

using System;
using System.Text;
using System.Collections.Generic;

namespace Workflow.FileCleaner.LogEntity
{
    public class LogFileOperation
    {
        private string cleanType;
        /// <summary>
        /// process type
        /// </summary>
        public string CleanType
        {
            get { return cleanType; }
            set { cleanType = value; }
        }

        private string backupPath;
        /// <summary>
        ///  backup folder
        /// </summary>
        public string BackupPath
        {
            get { return backupPath; }
            set { backupPath = value; }
        }

        private int maxDay;
        /// <summary>
        /// time interval
        /// </summary>
        public int MaxDay
        {
            get { return maxDay; }
            set { maxDay = value; }
        }
    }
}
