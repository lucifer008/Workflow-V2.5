/***********************************************
 * Copyrigth 2008 Phook All rigths reserved
 * 
 * File Name:           Backup.cs
 * Creator:             Kevin.Q.Fu
 * Create date:         2008-12-8
 * Last modifier:       Kevin.Q.Fu
 * Last modity date:    2008-4-12
 * Description:         backup and delete log file
 * 
 * 
 *                      Update log content
 ************************************************/

using System;
using System.IO;
using System.Text;
using System.Security;
using System.Collections.Generic;
using Workflow.FileCleaner.Const;
using Workflow.FileCleaner.XmlParser;
using Workflow.FileCleaner.LogEntity;
using Workflow.FileCleaner.Log;

namespace Workflow.FileCleaner.LogClean
{
    public class Backup:IClean
    {

        public void Clean(LogFile lf)
        {
            bool isFoundAny = false;
            string fileName = String.Empty;
            List<FileInfo> backupFileList = new List<FileInfo>();
            List<FileInfo> foundFileList = new List<FileInfo>();
            string fName = String.Empty;
            string oneName = String.Empty;

            for (int i = 0; i < lf.CleanType.MaxDay ; i++)
            {

                List<FileInfo> fList = DirectoryFile.GetFiles(lf.FullName, lf.LogDateSuffixFormat, i, out fName);
                if (fList != null && fList.Count > 0)
                {
                    foreach (FileInfo f in fList)
                    {
                        foundFileList.Add(f);
                    }
                    oneName = fName;
                    isFoundAny = true;
                }
            }

            DirectoryInfo di = new DirectoryInfo(Path.GetDirectoryName(lf.FullName));
            FileInfo[] fAll = di.GetFiles(oneName);
            foreach(FileInfo f in fAll)
            {
                bool isContain=false;
                foreach (FileInfo fl in foundFileList)
                {
                    if (f.Name.Equals(fl.Name))
                    {
                        isContain = true;
                    }
                }
                if (!isContain)
                {
                    backupFileList.Add(f);
                }
            }

            if (backupFileList.Count <= 0)
            {
                LogHelper.WriteError(Constants.MESSAGE_NO_SUITED_TO_BACKUP, Constants.LOGGER_NAME);
                return;
            }

            foreach (FileInfo f in backupFileList)
            {
                try
                {
                    if (!Directory.Exists(lf.CleanType.BackupPath))
                    {
                        Directory.CreateDirectory(lf.CleanType.BackupPath);
                    }
                    f.CopyTo(lf.CleanType.BackupPath + @"\" + f.Name, true);
                    fileName = f.Name;
                    f.Delete();
                    LogHelper.WriteError(string.Format(Constants.MESSAGE_LOGFILE_BACKUP_SUCCESSFUL, fileName), Constants.LOGGER_NAME);
                }
                catch (ArgumentNullException ex)
                {
                    LogHelper.WriteError(Constants.MESSAGE_ARGUMENT_NULL_ERROR, ex, Constants.LOGGER_NAME);
                }
                catch (ArgumentException ex)
                {
                    LogHelper.WriteError(Constants.MESSAGE_ARGUMENT_ERROR, ex, Constants.LOGGER_NAME);
                }
                catch (NotSupportedException ex)
                {
                    LogHelper.WriteError(Constants.MESSAGE_NOT_SUPPORTED, ex, Constants.LOGGER_NAME);
                }
                catch (PathTooLongException ex)
                {
                    LogHelper.WriteError(Constants.MESSAGE_PATH_TOO_LONG, ex, Constants.LOGGER_NAME);
                }
                catch (DirectoryNotFoundException ex)
                {
                    LogHelper.WriteError(Constants.MESSAGE_DIRECTORY_NOT_FOUND, ex, Constants.LOGGER_NAME);
                }
                catch (SecurityException ex)
                {
                    LogHelper.WriteError(Constants.MESSAGE_SECURITY_EXCEPTION, ex, Constants.LOGGER_NAME);
                }
                catch (IOException ex)
                {
                    LogHelper.WriteError(Constants.MESSAGE_IO_FAILED, ex, Constants.LOGGER_NAME);
                }
                catch (UnauthorizedAccessException ex)
                {
                    LogHelper.WriteError(Constants.MESSAGE_UNAUTHORIZED_ACCESS, ex, Constants.LOGGER_NAME);
                }
                catch (Exception ex)
                {
                    LogHelper.WriteError(Constants.MESSAGE_DELETE_FILE_FAILED, ex, Constants.LOGGER_NAME);
                }
            }
            if (!isFoundAny)
            {
                isFoundAny = false;
                LogHelper.WriteError(string.Format(Constants.MESSAGE_FILE_NOT_FOUND, lf.FullName), Constants.LOGGER_NAME);
            }
        }
    }
}
