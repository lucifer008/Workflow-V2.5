/***********************************************
 * Copyrigth 2008 Phook All rigths reserved
 * 
 * File Name:           IClean.cs
 * Creator:             Kevin.Q.Fu
 * Create date:         2008-3-19
 * Last modifier:       Kevin.Q.Fu
 * Last modity date:    2008-4-8
 * Description:         find the available file
 * 
 * 
 *                      update GetFiles method                     
 ************************************************/

using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Workflow.FileCleaner.Const;

namespace Workflow.FileCleaner.LogClean
{
    public class DirectoryFile
    {
        private DirectoryFile() { }

        /// <summary>
        /// 获取符合条件的文件
        /// </summary>
        /// <param name="logFullName"></param>
        /// <param name="dateFormat"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static List<FileInfo> GetFiles(string logFullName,string dateFormat,int day,out string fileName)
        {
            string logFileName = Path.GetFileName(logFullName);
            string[] fNameArr = logFileName.Split('.');
            DirectoryInfo di = new DirectoryInfo(Path.GetDirectoryName(logFullName));
            DateTime dt = DateTime.Now;
            dt = dt.AddDays(-day);
            FileInfo[] fi=null;
            StringBuilder namePrefix = new StringBuilder();
            string newLogFullName = "";
            
            //fileName = fileName;
            for (int i = 0; i < fNameArr.Length; i++)
            {
                namePrefix.Append(fNameArr[i].ToString().Trim()+".");
                newLogFullName = namePrefix.ToString().Trim();// +dt.ToString(dateFormat) + ".*";
                fi = di.GetFiles(newLogFullName);
                if (fi.Length > 0)
                {
                    break;
                }
            }
            fileName = namePrefix.ToString().Trim() + "*";

            FileInfo[] fiAll = di.GetFiles();
            List<FileInfo> fAll = new List<FileInfo>();
            foreach (FileInfo f in fiAll)
            {
                fAll.Add(f);
            }

            List<FileInfo> fList = new List<FileInfo>();
            if (fi != null)
            {
                foreach (FileInfo f in fi)
                {
                    if (!fAll.Contains(f))
                    {
                        if (f.CreationTime.Date < dt.Date)
                        {
                            fList.Add(f);
                        }
                    }
                }
            }
            return fList;
        }
    }
}
