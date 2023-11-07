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
        /// 岗位一览
        /// </summary>
        public IList<Position> PositionList
        {
            get { return positionList; }
            set { positionList = value; }
        }

        private Position position;
        /// <summary>
        /// 岗位信息
        /// </summary>
        public Position Position
        {
            get { return position; }
            set { position = value; }
        }

        private long id;
        /// <summary>
        /// 岗位的id
        /// </summary>
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private string action;
        /// <summary>
        /// 当前动作
        /// </summary>
        public string Action
        {
            get { if(null==action)
                    return "添加";
                return action; 
                }
            set { action = value; }
        }

        private string nameValue;
        /// <summary>
        /// 默认名称的值
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
        /// 默认备注的值
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
