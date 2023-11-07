#region imports
using System;
using Workflow.Da.Domain.Base;
#endregion

namespace Workflow.Da.Domain
{
	/// <summary>
	/// Table PROCESS_CONTENT_ACHIEVEMENT_RATE (加工内容业绩比例) 对应的DotNet Object 实体类
	/// </summary>
	[Serializable]
	public class ProcessContentAchievementRate : ProcessContentAchievementRateBase
	{
		public ProcessContentAchievementRate()
		{
		}

        private string processContentName;
        public string ProcessContentName 
        {
            set { processContentName = value; }
            get { return processContentName; }
        }

        private long insertUser;
        public long InsertUser 
        {
            set { insertUser = value; }
            get { return insertUser; }
        }

        private long updateUser;
        public long UpdateUser 
        {
            set { updateUser = value; }
            get { return updateUser; }
        }
	}
}