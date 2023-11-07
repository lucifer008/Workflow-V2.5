using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Support;

namespace Workflow.Da.Domain.Base
{
	[Serializable]
    public abstract class MetaData
    {
        private char deleted;

        public char Deleted
        {
            get { return deleted; }
            set { deleted = value; }
        }
        private int version;

        public int Version
        {
            get { return version; }
            set { version = value; }
        }
        private long insertUser;

        public long InsertUser
        {
            get { return insertUser; }
            set { insertUser = value; }
        }
        private DateTime insertDateTime;

        public DateTime InsertDateTime
        {
            get { return insertDateTime; }
            set { insertDateTime = value; }
        }
        private long updateUser;

        public long UpdateUser
        {
            get { return updateUser; }
            set { updateUser = value; }
        }
        private DateTime updateDateTime;

        public DateTime UpdateDateTime
        {
            get { return updateDateTime; }
            set { updateDateTime = value; }
        }
        private long companyId;

        public long CompanyId
        {
            get { return companyId; }
            set { companyId = value; }
        }
        private long branchShopId;

        public long BranchShopId
        {
            get { return branchShopId; }
            set { branchShopId = value; }
        }

        public string InserDateTimeStrings
        { 
            get{
                //if (InsertDateTime == null)
                //    return "";
                if (InsertDateTime == Constants.NULL_DATE_TIME || InsertDateTime == Constants.NULL_MIN_DATE_TIME)
                    return "";
                else
                    return InsertDateTime.ToString();
            }
        }
    }
}
