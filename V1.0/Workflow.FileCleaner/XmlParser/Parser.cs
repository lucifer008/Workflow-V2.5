/***********************************************
 * Copyrigth 2008 Phook All rigths reserved
 * 
 * File Name:           Parser.cs
 * Creator:             Kevin.Q.Fu
 * Create date:         2008-12-6
 * Last modifier:       
 * Last modity date:    
 * Description:         parse the configuration file
 * 
 ************************************************/

using System;
using System.Text;
using System.Xml.XPath;
using System.Collections.Generic;
using Workflow.FileCleaner.LogEntity;
using Workflow.FileCleaner.Const;
using Workflow.FileCleaner.Log;
namespace Workflow.FileCleaner.XmlParser
{
    public sealed class Parser
    {
        public List<LogFile> Parse(string fullName)
        {
            List<LogFile> lgFileList=new List<LogFile>();
            try
            {
                XPathDocument doc = new XPathDocument(fullName);
                XPathNavigator nav = doc.CreateNavigator();
                XPathNodeIterator nodeIter= nav.Select(@"//LogFile[@Enable='true']");
                if (nodeIter.Count <= 0)
                {
                    return null;
                }
                while (nodeIter.MoveNext())
                {
                    XPathNodeIterator ndChild = nodeIter.Current.Select("child::Clean");
                    if (ndChild.Count <= 0)
                    {
                        continue;
                    }
                    ndChild.MoveNext();

                    LogFile lf = new LogFile();
                    LogFileOperation lp = new LogFileOperation();
                    lf.FullName = nodeIter.Current.GetAttribute("FullName", "");
                    lf.Enable = Convert.ToBoolean(nodeIter.Current.GetAttribute("Enable", ""));
                    lf.LogDateSuffixFormat=nodeIter.Current.GetAttribute("DateFormat","");
                    lp.BackupPath = ndChild.Current.GetAttribute("BackupPath", "");
                    lp.CleanType = ndChild.Current.GetAttribute("CleanType", "");
                    lp.MaxDay = Convert.ToInt32(ndChild.Current.GetAttribute("MaxDays", ""));
                    lf.CleanType = lp;
                    lgFileList.Add(lf);
                }
            }
            catch(XPathException ex)
            {
                LogHelper.WriteError(Constants.MESSAGE_XPATH_EXCEPTION,ex, Constants.LOGGER_NAME);
            }
            catch(Exception ex)
            {
                LogHelper.WriteError(Constants.MESSAGE_PARSE_XML_FAILED, ex, Constants.LOGGER_NAME);
            }
            return lgFileList;

        }
    }
}
