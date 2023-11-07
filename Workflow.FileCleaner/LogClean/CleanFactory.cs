/***********************************************
 * Copyrigth 2008 Phook All rigths reserved
 * 
 * File Name:           CleanFactory.cs
 * Creator:             Kevin.Q.Fu
 * Create date:         2008-12-8
 * Last modifier:       
 * Last modity date:    
 * Description:         class factory
 * 
 ************************************************/

using System;
using System.Text;
using System.Collections.Generic;
namespace Workflow.FileCleaner.LogClean
{
    public class CleanFactory
    {
        private CleanFactory() { }
        public static IClean GetInstance(string cleanType)
        {
            IClean clean = null; 
            switch(cleanType.ToLower())
            {
                case "backup":
                    clean = new Backup();
                    break;
                case "delete":
                    clean = new Deletion();
                    break;
                default:
                    clean = null; 
                    break;
            }
            return clean;

        }
    }
}
