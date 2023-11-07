using System;
using Workflow.Da.Domain.Base;

namespace Workflow.Da.Domain
{
	/// <summary>
	/// Table POSITION对应的DotNet Object
	/// </summary>
	[Serializable]
	public class Position : PositionBase
	{
		public Position()
		{
        }

        #region Add:Cry,Date:2009.1.14

        private int no;
        /// <summary>
        /// 编职务顺序号
        /// </summary>
        public int No
        {
            get { return no; }
            set { no = value; }
        }

        private string status;
        /// <summary>
        /// 状态
        /// </summary>
        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        private string insertUserName;
        /// <summary>
        /// 插入操作员名称
        /// </summary>
        public string InsertUserName
        {
            get { return insertUserName; }
            set { insertUserName = value; }
        }

        private string updateUserName;
        /// <summary>
        /// 更新操作员名称
        /// </summary>
        public string UpdateUserName
        {
            get { return updateUserName; }
            set { updateUserName = value; }
        }

        #endregion

        
	}
}
