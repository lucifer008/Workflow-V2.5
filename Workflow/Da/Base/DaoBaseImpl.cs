using System;
using System.Collections.Generic;
using System.Text;
using IBatisNet.DataMapper;
using Workflow.Da.Domain.Base;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Da.Support;

namespace Workflow.Da.Base
{
    public class DaoBaseImpl<T> : IDaoBase<T>, Spring.Context.IApplicationContextAware
    {
        protected ISqlMapper sqlMap;
        private Type type;
        protected string typeSimpleName;
        protected string typeBaseSimpleName;
        private IdGeneratorSupport idGeneratorSupport;

        public IdGeneratorSupport IdGeneratorSupport
        {
            set { idGeneratorSupport = value; }
        }

        public DaoBaseImpl()
        {
            type = typeof(T);
            typeSimpleName = type.Name + ".";
            typeBaseSimpleName = type.Name + "Base" + ".";
        }
        public ISqlMapper SqlMap
        {
            set { sqlMap = value;  }
        }


        #region IDaoBase<T> 成员

        /// <summary>
        /// 获取数据库中的该表的所有数据。
        /// </summary>
        /// <returns></returns>
        public IList<T> SelectAll()
        {
            T domain = default(T);
            T obj = (T)typeof(T).Assembly.CreateInstance(typeof(T).FullName);
            if (obj is MetaData)
            {
                domain = (T)typeof(T).GetConstructor(new Type[] { }).Invoke(null);
                User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
                MetaData metaData = (MetaData)(Object)domain;

                metaData.CompanyId = user.CompanyId;
                metaData.BranchShopId = user.BranchShopId;
            }
            return sqlMap.QueryForList<T>(typeBaseSimpleName + "SelectAll", domain);
        }

        /// <summary>
        /// 通过表的主键选取对应的数据。
        /// </summary>
        /// <param name="id">表的主键</param>
        /// <returns></returns>
        public T SelectByPk(long id)
        {
            return sqlMap.QueryForObject<T>(typeBaseSimpleName + "SelectByPk", id);
        }

        /// <summary>
        /// 将表对应的实体插入数据库。
        /// </summary>
        /// <param name="domain"></param>
        public void Insert(T domain)
        {
            if (domain is MetaData)
            {
                MetaData metaData = (MetaData)(Object)domain;
                User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
                metaData.InsertUser = ThreadLocalUtils.CurrentUserContext.CurrentUser.Id;
                metaData.InsertDateTime = DateTime.Now;
                metaData.UpdateDateTime = DateTime.Now;
                metaData.Version = 1;
                metaData.Deleted = '0';
                if (metaData.CompanyId < 1)
                    metaData.CompanyId = user.CompanyId;
                if (metaData.BranchShopId < 1)
                    metaData.BranchShopId = user.BranchShopId;
            }
            Type type = typeof(T);
            if (idGeneratorSupport == null)
            {
                lock (this)
                {
                    if (idGeneratorSupport == null)
                    {
                        idGeneratorSupport = (IdGeneratorSupport)springContext.GetObject("idGeneratorSupport");
                    }
                }
            }
            long id = idGeneratorSupport.NextId(type);

            //Support.IdGeneratorSupport idGS = new IdGeneratorSupport();

            //long id = idGS.NextId(type);

            type.GetProperty("Id").GetSetMethod().Invoke(domain, new object[] { id });
            sqlMap.Insert(typeBaseSimpleName + "Insert", domain);
        }

        /// <summary>
        /// 将表对应的实体更新到数据库。
        /// </summary>
        /// <param name="domain"></param>
        public void Update(T domain)
        {
            if (domain is MetaData)
            {
                MetaData metaData = (MetaData)(Object)domain;
                User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
                metaData.UpdateUser = user.Id;
                metaData.UpdateDateTime = DateTime.Now;
            }
            sqlMap.Update(typeBaseSimpleName + "Update", domain);
        }

        /// <summary>
        /// 通过表的主键删除对应的数据。
        /// </summary>
        /// <param name="id"></param>
        public void Delete(long id)
        {
            sqlMap.Delete(typeBaseSimpleName + "Delete", id);
        }
        /// <summary>
        /// 通过表的主键逻辑删除对应的数据。
        /// </summary>
        /// <param name="id"></param>
        public void LogicDelete(long id)
        {
            sqlMap.Update(typeBaseSimpleName + "LogicDelete", id);
        }

        #endregion

        /// <summary>
        /// 为指定的MetaData填充信息
        /// </summary>
        /// <param name="domain"></param>
        protected void MakeMetaData(MetaData metaData)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;

            metaData.InsertUser = user.Id;
            metaData.InsertDateTime = DateTime.Now;
            metaData.UpdateUser = user.Id;
            metaData.UpdateDateTime = DateTime.Now;

            metaData.CompanyId = user.CompanyId;
            metaData.BranchShopId = user.BranchShopId;
        }

        #region IApplicationContextAware 成员

        

        private Spring.Context.IApplicationContext springContext;
        public Spring.Context.IApplicationContext ApplicationContext
        {
            get { return springContext; }
            set { springContext = value; }
        }

        #endregion
    }
}
