using System;
using System.Text;
using System.Collections.Generic;

namespace Workflow.Support.Attributes
{
    /// <summary>
    /// ��    ��: UpdatePermissionAttribute
    /// ���ܸ�Ҫ: ��������������������� (�û�����Ƿ��и���Ȩ��)
    /// ��    ��: ��ǿ
    /// ����ʱ��: 2008-12-4
    /// ��������: 
    /// ����ʱ��: 
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    [Serializable]
    public class UpdatePermissionAttribute:Attribute
    {
    }
}
