using System;
using Workflow.Da.Domain.Base;

namespace Workflow.Da.Domain
{
	/// <summary>
	/// Table EMPLOYEE_POSITION��Ӧ��DotNet Object
	/// </summary>
	[Serializable]
	public class EmployeePosition : EmployeePositionBase
	{
		public EmployeePosition()
		{
		}

        private string positionName;
        /// <summary>
        /// ��ȡ��������ְλ����
        /// </summary>
        public string PositionName 
        {
            set { positionName = value; }
            get { return positionName; }
        }
	}
}
