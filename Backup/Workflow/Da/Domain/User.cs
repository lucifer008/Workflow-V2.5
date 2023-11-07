using System;
using Workflow.Da.Domain.Base;

namespace Workflow.Da.Domain
{
	/// <summary>
	/// Table USERS对应的DotNet Object
	/// </summary>
	[Serializable]
	public class User : UserBase
	{
		public User()
		{
		}

        private bool success;
        public bool Success
        {
            set { success = value; }
            get { return success; }
        }

        //private string userName;
        //public string UserName 
        //{
        //    set { userName = value; }
        //    get { return userName; }
        //}
        private long roleId;
        public long RoleId
        {
            set { roleId = value; }
            get { return roleId; }
        }
        private long permissionType;
        public long PermissionType
        {
            get { return permissionType; }
            set { permissionType = value; }
        }
        private string isUsed;
        public string IsUsed
        {
            get { return isUsed; }
            set { isUsed = value; }
        }
        private string permissionName;
        public string PermissionName
        {
            get { return permissionName ; }
            set { permissionName = value; }
        }
        private string employeeName;
        public string EmployeeName
        {
            get { return employeeName; }
            set { employeeName = value; }
        }

        private string lastVisitedUrl;
        public string LastVisitedUrl
        {
            get { return lastVisitedUrl; }
            set { lastVisitedUrl = value; }
        }

        private decimal concessionMin;
        public decimal ConcessionMin
        {
            get { return concessionMin; }
            set { concessionMin = value; }
        }
        private decimal concessionMax;
        public decimal ConcessionMax
        {
            get { return concessionMax; }
            set { concessionMax = value; }
        }
        private decimal renderUpMin;
        public decimal RenderUpMin
        {
            get { return renderUpMin; }
            set { renderUpMin = value; }
        }
        private decimal renderUpMax;
        public decimal RenderUpMax
        {
            get { return renderUpMax; }
            set { renderUpMax = value; }
        }
        private decimal zeroMin;
        public decimal ZeroMin
        {
            get { return zeroMin; }
            set { zeroMin = value; }
        }
        private decimal zeroMax;
        public decimal ZeroMax
        {
            get { return zeroMax; }
            set { zeroMax = value; }
        }
        private long positionId;
        public long PositionId
        {
            get { return positionId; }
            set { positionId = value; }
        }
        private bool isNullUserConcessionRanage;
        public bool IsNullUserConcessionRanage
        {
            set { isNullUserConcessionRanage = value; }
            get { return isNullUserConcessionRanage; }
        }
	    private string updateUserString;
        public string UpdateUserString 
        {
            set { updateUserString = value; }
            get { return updateUserString; }
        }

        private string insertUserString;
        public string InsertUserString 
        {
            set { insertUserString=value; }
            get { return insertUserString; }
        }

        private string userRole;
        public string UserRole 
        {
            set { userRole = value; }
            get { return userRole; }
        }

        private int currentPageIndex;
        public int CurrentPageIndex 
        {
            set { currentPageIndex = value; }
            get { return currentPageIndex; }
        }

        private int rowCount;
        public int RowCount 
        {
            set { rowCount = value; }
            get { return rowCount; }
        }

        /// <summary>
        /// 是否是后台
        /// </summary>
        private bool isSystemMaintenance;
        /// <summary>
        /// 是否是后台用户
        /// </summary>
        public bool IsSystemMaintenance 
        {
            set { isSystemMaintenance = value; }
            get { return isSystemMaintenance; }
        }

        private string concessionTypeZero;
        public string ConcessionTypeZero 
        {
            set { concessionTypeZero = value; }
            get { return concessionTypeZero; }
        }

        private string concessionTypeCon;
        public string ConcessionTypeCon 
        {
            set { concessionTypeCon = value; }
            get { return concessionTypeCon; }
        }

        private string concessionTypeRenderUp;
        public string ConcessionTypeRenderUp 
        {
            set { concessionTypeRenderUp = value; }
            get { return concessionTypeRenderUp; }
        }
    }
}
