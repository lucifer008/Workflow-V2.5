using System;
using System.Collections.Generic;
using System.Text;

namespace Workflow.Util
{
    /// <summary>
    /// 名    称: 时间格式处理
    /// 功能概要: 
    /// 作    者: 付强
    /// 创建时间: 2008-12-1
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    public class DateUtils
    {
        public static DateTime ToDateTime(string value)
        {
            return DateTime.Parse(value);
        }
        public static string ToFormatDateTime(DateTime d,DateTimeFormatEnum df)
        {
            string returnValue = "";
            switch(df)
            {
                case DateTimeFormatEnum.DateFormat:
                    returnValue = d.ToString("yyyy-MM-dd");
                    break;
                case DateTimeFormatEnum.TimeFormat:
                    returnValue = d.ToString("HH:mm:ss");
                    break;
                case DateTimeFormatEnum.DateTimeFormat:
                    returnValue = d.ToString("yyyy-MM-dd HH:mm:ss");
                    break;
                case DateTimeFormatEnum.DateTimeNoSecondFormat:
                    returnValue = d.ToString("yyyy-MM-dd HH:mm");
                    break;
                default:
                    returnValue = d.ToString("yyyy-MM-dd HH:mm:ss");
                    break;
            }
            return returnValue;
        }
    }

    public enum DateTimeFormatEnum
    { 
        /// <summary>
        /// yyyy-MM-dd
        /// </summary>
        DateFormat,
        /// <summary>
        /// HH:mm:ss
        /// </summary>
        TimeFormat,
        /// <summary>
        /// yyyy-MM-dd HH:mm:ss
        /// </summary>
        DateTimeFormat,
        /// <summary>
        /// yyyy-MM-dd HH:mm
        /// </summary>
        DateTimeNoSecondFormat
    }
}
