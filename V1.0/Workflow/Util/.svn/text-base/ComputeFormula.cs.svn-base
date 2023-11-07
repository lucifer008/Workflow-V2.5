using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.JScript;
using Microsoft.JScript.Vsa;

namespace Workflow.Util
{   
    /// <summary>
    /// 名    称: Workflow.Util.ComputeFormula
    /// 功能概要:
    /// 作    者: 计算公式的值
    /// 创建时间: 2007-10-24
    /// 修正履历:
    /// 修正时间:
    /// </summary>
    public class ComputeFormula
    {
        private static VsaEngine ve = VsaEngine.CreateEngine();
        private static object Eval(string Expression)
        {
            return Microsoft.JScript.Eval.JScriptEvaluate(Expression,ve);
        }

        /// <summary>
        /// 计算表达式的值并转换成整形数
        /// </summary>
        /// <param name="Expression"></param>
        /// <returns></returns>
        public static int EvalToInt(string Expression)
        {
            return int.Parse(Eval(Expression).ToString());
        }
    }
}
