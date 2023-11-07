using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Action.Positions
{
    public class PositionModel
    {
        private IList<Position> positionList;
        /// <summary>
        /// ��λһ��
        /// </summary>
        public IList<Position> PositionList
        {
            get { return positionList; }
            set { positionList = value; }
        }

        private Position position;
        /// <summary>
        /// ��λ��Ϣ
        /// </summary>
        public Position Position
        {
            get { return position; }
            set { position = value; }
        }

        private long id;
        /// <summary>
        /// ��λ��id
        /// </summary>
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private string action;
        /// <summary>
        /// ��ǰ����
        /// </summary>
        public string Action
        {
            get { if(null==action)
                    return "���";
                return action; 
                }
            set { action = value; }
        }

        private string nameValue;
        /// <summary>
        /// Ĭ�����Ƶ�ֵ
        /// </summary>
        public string NameValue
        {
            get
            {
                if (null == nameValue)
                    return "";
                return nameValue;
            }
            set { nameValue = value; }
        }

        private string memoValue;
        /// <summary>
        /// Ĭ�ϱ�ע��ֵ
        /// </summary>
        public string MemoValue
        {
            get {
                if (null == memoValue)
                    return "";
                return memoValue;
            }
            set { memoValue = value; }
        }
    }
}
