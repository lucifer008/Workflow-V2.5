using System;
using System.Collections.Generic;
using System.Text;

namespace Workflow.Support.Attributes
{
    /// <summary>
    /// ��    ��: SelectPermissionAttribute
    /// ���ܸ�Ҫ: ��������������������� (�û�����Ƿ������Ȩ��)
    /// ��    ��: ��ǿ
    /// ����ʱ��: 2008-12-4
    /// ��������: 
    /// ����ʱ��: 
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    [Serializable]
    public class SelectPermissionAttribute:Attribute
    {

    }
}
