using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Workflow.Util
{
    public class NumericUtils
    {
        public static long ToLong(string value)
        {
            return Int64.Parse(value);
        }

        public static long ToLong(string value, long defaultValue)
        {
            try
            {
                return ToLong(value);
            }
            catch
            {
                return defaultValue;
            }
        }

		public static int ToInt(string value)
		{
			return Int32.Parse(value);
		}
		public static int ToInt(string value, int defaultValue)
		{
			try
			{
				return ToInt(value);
			}
			catch
			{
				return defaultValue;
			}
		}

        private const string NUMERIC_REX = @"^[1-9]*$";
        public static bool IsNumber(string number)
        {
            return Regex.IsMatch(number,NUMERIC_REX);
        }

        /// <summary>
        /// 格式化金额
        /// 付强
        /// 2008-12-1
        /// </summary>
        /// <param name="d">要格式化的金额</param>
        /// <returns></returns>
        public static string ToMoney(decimal d)
        {
            return string.Format("{0:N2}", d);
        }
        /// <summary>
        /// 格式化数量
        /// 付强
        /// 2008-12-1
        /// </summary>
        /// <param name="d">要格式化的数量</param>
        /// <returns></returns>
        public static string ToAmount(decimal d)
        {
            return string.Format("{0:N}", d);
        }

        /// <summary>
        /// 人民币小写转大写
        /// Author:Cry
        /// Date:2008-12-27
        /// </summary>
        /// <param name="money">小写</param>
        /// <returns>大写</returns>
        public static string ConversionMoney(string money)
        {
            string s = double.Parse(money).ToString("#L#E#D#C#K#E#D#C#J#E#D#C#I#E#D#C#H#E#D#C#G#E#D#C#F#E#D#C#.0B0A");//d + "\n" +
            string d = Regex.Replace(s, @"((?<=-|^)[^1-9]*)|((?'z'0)[0A-E]*((?=[1-9])|(?'-z'(?=[F-L\.]|$))))|((?'b'[F-L])(?'z'0)[0A-L]*((?=[1-9])|(?'-z'(?=[\.]|$))))", "${b}${z}");
            string chinaMoney=Regex.Replace(d, ".", delegate(Match m) { return "负元空零壹贰叁肆伍陆柒捌玖空空空空空空空分角拾佰仟万亿兆京垓秭穰"[m.Value[0] - '-'].ToString(); });
            if (string.IsNullOrEmpty(chinaMoney))
            {
                return "";
            }
            if ("元" == chinaMoney.Substring(chinaMoney.Length - 1))
            {
                chinaMoney += "整";
            }
            return chinaMoney;
        }

		

		/// <summary>
		/// 计算字符串公式
		/// </summary>
		/// <param name="expession">计算的公式</param>
		/// <returns></returns>
		private static Microsoft.JScript.Vsa.VsaEngine ve = Microsoft.JScript.Vsa.VsaEngine.CreateEngine();
		public static object Eval(string expession)
		{
			return Microsoft.JScript.Eval.JScriptEvaluate(expession, ve);
		}
    }
}
