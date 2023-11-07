using System;
using System.Collections.Generic;
using System.Text;
using Spring.Objects.Factory;
using IBatisNet.DataMapper;
using System.Xml;
using IBatisNet.DataMapper.Configuration;
using Workflow.Util;
namespace Workflow.Da.IBatis
{
    /// <summary>
    /// iBatis SqlMap 的Spring Factory的实现
    /// </summary>
    public class SqlMapClientFactoryBean : IFactoryObject, IInitializingObject
    {

        private ISqlMapper sqlMap;
        private String configFile;
        #region IInitializingObject 成员

        public void AfterPropertiesSet()
        {
            XmlDocument xmldoc = new XmlDocument();
            string path = AppDomain.CurrentDomain.BaseDirectory;
            try
            {
                xmldoc.Load(path + "SqlMap.config");
                sqlMap = BuildSqlMap(xmldoc);
            }
            catch(Exception ex)
            {
                if (!StringUtils.IsEmpty(configFile))
                {
                    xmldoc.Load(configFile);
                    sqlMap = BuildSqlMap(xmldoc);
                }
                else
                {
                    throw ex;
                }
            }
        }

        #endregion

        #region IFactoryObject 成员

        public object GetObject()
        {
            return sqlMap;
        }

        public bool IsSingleton
        {
            get { return true; }
        }

        public Type ObjectType
        {
            get { return sqlMap == null ? typeof(ISqlMapper) : sqlMap.GetType(); }
        }

        #endregion

        protected ISqlMapper BuildSqlMap(XmlDocument xmldoc) 
        {
            DomSqlMapBuilder builder = new DomSqlMapBuilder();
            return builder.Configure(xmldoc);          

	    }

        public String ConfigFile
        {
            set { configFile = value; }
        }
    }
}
