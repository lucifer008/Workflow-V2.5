using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Action.Permission.Model
{
	public class UserModel
	{
		private User user;
		public User User
		{
			set { user = value; }
			get { return user; }
		}

		private UserRole userRole;
		public UserRole UserRole
		{
			set { userRole = value; }
			get { return userRole; }
		}

        private UserConcessionRange userConcessionRanage;
        public UserConcessionRange UserConcessionRanage 
        {
            set { userConcessionRanage = value; }
            get { return userConcessionRanage; }
        }

        private Workflow.Da.Domain.Employee employee;
        public Workflow.Da.Domain.Employee Employee
        {
            set { employee = value; }
            get { return employee; }
        }

		private IList<Role> roleList;
		public IList<Role> RoleList
		{
			set { roleList = value; }
			get { return roleList; }
		}

		private IList<User> userList;
		public IList<User> UserList 
		{
			set { userList = value; }
			get { return userList; }
		}

		private IList<Position> positionList;
		public IList<Position> PositionList 
		{
			set { positionList = value; }
			get { return positionList; }
		}

        private IList<Workflow.Da.Domain.Employee> employeeList;
        public IList<Workflow.Da.Domain.Employee> EmployeeList
        {
            set { employeeList = value; }
            get { return employeeList; }
        }

        private IList<UserRole> userRoleList;
        public IList<UserRole> UserRoleList
        {
            set { userRoleList = value; }
            get { return userRoleList; }
        }

        private IList<UserConcessionRange> userConcessionRangeList;
        public IList<UserConcessionRange> UserConcessionRanageList 
        {
            set { userConcessionRangeList = value; }
            get { return userConcessionRangeList; }
        }
        private bool isNullUserConcessionRanage;
        public bool IsNullUserConcessionRanage 
        {
            set { isNullUserConcessionRanage = value; }
            get { return isNullUserConcessionRanage; }
        }
	}
}
