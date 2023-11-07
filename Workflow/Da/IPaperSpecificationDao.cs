using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// 名     称:IPaperSpecification
    /// 功能概要:IPaperSpecification接口
    /// 作    者:
    /// 创建时间:
    /// 修正履历:
    /// 修正时间:
	/// </summary>
    public interface IPaperSpecificationDao : IDaoBase<PaperSpecification>
    {
        #region //获取纸型数据
        /// <summary>
        /// 名    称: SearchPaperSecification
        /// 功能概要: 获取纸型列表
        /// 作    者：张晓林
        /// 创建时间: 2009年5月5日15:15:30
        /// 修正时间:
        /// </summary>
        IList<PaperSpecification> SearchPaperSecification(PaperSpecification paperSpecification);

        /// <summary>
        /// 名    称: SearchPaperSecificationRowCount
        /// 功能概要: 获取纸型记录数 
        /// 作    者：张晓林
        /// 创建时间: 2009年5月5日15:15:30
        /// 修正时间:
        /// </summary>
        long SearchPaperSecificationRowCount(PaperSpecification paperSpecification);
        #endregion

		#region 通过纸型名称获取纸型Id
		/// <summary>
		/// 名    称: SelectPaperSpecificationIdByName
		/// 功能概要: 通过纸型名称获取纸型
		/// 作    者：白晓宇
		/// 创建时间: 2010年5月7日
		/// 修正时间:
		/// </summary>
		/// <param name="name">纸型名称</param>
		long SelectPaperSpecificationIdByName(string name);
		#endregion
    }
}
