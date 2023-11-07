using System;
using Workflow.Da.Domain.Base;
using System.Collections.Generic;

namespace Workflow.Da.Domain
{
	/// <summary>
	/// Table PERMISSION_GROUP��Ӧ��DotNet Object
	/// </summary>
	[Serializable]
	public class PermissionGroup : PermissionGroupBase
	{
		public PermissionGroup()
		{
		}

        private bool isChecked;
        /// <summary>
        /// �Ƿ�ѡ��
        /// </summary>
        public bool IsChecked
        {
            get { return isChecked; }
            set { isChecked = value; }
        }


        private long permissionId;
        /// <summary>
        /// ��ǰ��ɫ�Ѿ����ڵ�Ȩ�����,��Ŀǰ��ṹ.ÿ����ɫ��Ȩ�����µ�Ȩ�����ֻ������1��.
        /// </summary>
        public long PermissionId
        {
            get { return permissionId; }
            set { permissionId = value; }
        }

        public long UsedPermissionId
        {
            get { return 5; }
        }
	}
}
