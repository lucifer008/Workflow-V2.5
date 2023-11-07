/***********************************************
 * Copyrigth 2008 Phook All rigths reserved
 * 
 * File Name:           Constants.cs
 * Creator:             Kevin.Q.Fu
 * Create date:         2008-12-8
 * Last modifier:       
 * Last modity date:    
 * Description:         Constant class
 * 
 ************************************************/

using System;
using System.Text;
using System.Configuration;
using System.Collections.Generic;

namespace Workflow.FileCleaner.Const
{
    public class Constants
    {
        public const string LOGGER_NAME = "Workflow.FileCleaner";

        public const string MESSAGE_FILE_NOT_FOUND = " File {0} Not Found.";
        public const string MESSAGE_LOGFILE_BACKUP_SUCCESSFUL = "{0} LogFile Backup Succeeded.";
        public const string MESSAGE_ARGUMENT_NULL_ERROR = "Argument Null Error:{0};{1}.";
        public const string MESSAGE_ARGUMENT_ERROR = "Argument Error:{0};{1}.";
        public const string MESSAGE_NOT_SUPPORTED = "Not Supported:{0};{1}.";
        public const string MESSAGE_PATH_TOO_LONG = "Path Too Long:{0};{1}.";
        public const string MESSAGE_DIRECTORY_NOT_FOUND = "Directory Not Found:{0};{1}.";
        public const string MESSAGE_SECURITY_EXCEPTION = "Security Exception:{0};{1}.";
        public const string MESSAGE_IO_FAILED = "IO Failed:{0};{1}.";
        public const string MESSAGE_UNAUTHORIZED_ACCESS = "Unauthorized Access:{0};{1}.";
        public const string MESSAGE_DELETE_FILE_FAILED = "Delete File Failed:{0};{1}.";
        public const string MESSAGE_LOGFILE_DELETE_SUCCESSFUL = "LogFile Delete Succeeded.";
        public const string MESSAGE_XPATH_EXCEPTION = "XPath Exception:{0};{1}.";
        public const string MESSAGE_PARSE_XML_FAILED = "Parse Xml File Failed:{0};{1}.";
        public const string MESSAGE_CONFIGURATION_ERROR = "Configuration Error.";
        public const string MESSAGE_BEGIN_JOB = "Begin Job.";
        public const string MESSAGE_END_JOB = "End Job.";
        public const string MESSAGE_NO_SUITED_TO_BACKUP = "There is not suited item to backup.";
        public const string MESSAGE_NO_SUITED_TO_DELETE = "There is not suited item to delete.";

    }

    public enum CleanDateType
    { 
        CreateDateTime,
        LogDateTime
    }
}
