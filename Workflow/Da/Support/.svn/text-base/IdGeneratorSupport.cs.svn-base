using System;
using System.Collections.Generic;
using System.IO;
using System.Collections;
using System.Xml;
using System.Web;
using Workflow.Da.Domain;
using Workflow.Support;

namespace Workflow.Da.Support
{
    /// <summary>
    /// 名    称: Workflow.Da.Support.IdGeneratorSupport
    /// 功能概要: 根据提供的类型，获取ID
    /// 作    者: 祝新宾
    /// 创建时间: 2007-9-13
    /// 修正履历:
    /// 修正时间:
    /// </summary>
    public class IdGeneratorSupport
    {
        private static readonly string DEFAULT_FLAG_NO = "default";
        private static readonly string GLOBAL_FLAG_NO = "global";
        private static readonly long NOT_ID = -1;

        private IDictionary type2FlagNo = null;
        public IDictionary Type2FlagNo
        {
            set { type2FlagNo = value; }
        }

        private IDictionary parentFlagno2IdMap = new Hashtable();
        private int cacheSize = 1;

        public int CacheSize
        {
            set { cacheSize = value; }
        }

        private IIdGeneratorDao idGeneratorDao;
        public IIdGeneratorDao IdGeneratorDao
        {
            set { idGeneratorDao = value; }
        }

        public IdGeneratorSupport()
        {
            Hashtable hashtable = new Hashtable();

            hashtable.Add(typeof(Order), "order");
            hashtable.Add(typeof(OrderItem), "order");
            hashtable.Add(typeof(OrderItemFactorValue), "order");

            type2FlagNo = Hashtable.Synchronized(hashtable);
        }
        public long NextId(Type type)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            long branchShopId = NOT_ID;
            if (user != null)
                branchShopId = user.BranchShopId;

            string flagno = GetFlagNo(type.FullName);
            lock (flagno)
            {
                return GenerateNextId(flagno, branchShopId);
            }
        }

        private string GetFlagNo(string fullName)
        {
            string flagno = (string)type2FlagNo[fullName];
            if (flagno == null)
                return DEFAULT_FLAG_NO;
            else
                return flagno;
        }

        /// <summary>
        /// 名    称: Workflow.Da.Support.IdGeneratorSupport.GenerateNextId
        /// 功能概要: 根据branchShopId和flagno， 获取下一个ID。
        ///           branchShopId = -1,则表示全局的，即flagno必须为[global]。
        /// 作    者: 祝新宾
        /// 创建时间: 2007-9-13
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        private long GenerateNextId(String flagno, long branchShopId)
        {
            if (branchShopId == -1)
                flagno = GLOBAL_FLAG_NO;
            else if (flagno == GLOBAL_FLAG_NO)
                branchShopId = -1;

            IDictionary flagno2Id = null;
            MockSequence sequence = null;
            if (branchShopId != -1)
            {
                flagno2Id = (IDictionary)parentFlagno2IdMap[branchShopId];
                if (flagno2Id == null)
                {
                    flagno2Id = new Hashtable();
                    parentFlagno2IdMap.Add(branchShopId, flagno2Id);
                }
                sequence = (MockSequence)flagno2Id[flagno];
            }
            else 
            {
                sequence = (MockSequence)parentFlagno2IdMap[branchShopId];
            }

            if (sequence == null)
            {
                sequence = new MockSequence();
                if (branchShopId == -1)
                    parentFlagno2IdMap.Add(branchShopId, sequence);
                else
                    flagno2Id.Add(flagno, sequence);
            }

            if (sequence.New || sequence.CurrentId >= sequence.MaxId)
            {
                IdGenerator domain = idGeneratorDao.NextId(branchShopId, flagno, cacheSize);
                sequence.CurrentId = domain.CurrentValue;
                sequence.MaxId = domain.CurrentValue + cacheSize;
            }

            long returnValue = sequence.CurrentId;
            sequence.CurrentId++;
            return returnValue;
        }


    //    private string GetTableName(Type type)
    //    {
    //        string daoConfig = @"D:\vs2005\workflow\Workflow.Web\config\dao.config";
            

    //        XmlDocument doc = new XmlDocument();
    //        doc.Load(daoConfig);

    //        string xpathURL = "*//*[@id='idGeneratorSupport']//*[@name='type2FlagNo']//*//*[@key='"+type.FullName+"']";

    //        XmlNode node = doc.SelectSingleNode(xpathURL);

    //        string attrName = null;
    //        XmlAttributeCollection nodeAttribute = node.Attributes;

    //        for (int i = 0; i < nodeAttribute.Count; i++)
    //        {
    //            if (nodeAttribute[i].Name == "value")
    //            {
    //                attrName = nodeAttribute[i].Value;
    //            }
    //        }

    //        return attrName;
    //    }
    }
    /// <summary>
    /// 名    称: Workflow.Da.Support.MockSequence
    /// 功能概要: 记录目前的值及最大值
    /// 作    者: 祝新宾
    /// 创建时间: 2007-9-13
    /// 修正履历:
    /// 修正时间:
    /// </summary>
    class MockSequence
    {
        private long currentId;
        public long CurrentId
        {
          get { return currentId; }
          set { currentId = value; }
        }

        private long maxId;
        public long MaxId
        {
          get { return maxId; }
          set { maxId = value; }
        }

        public bool New
        {
            get { return currentId == 0;  }
        }
    }    

}
