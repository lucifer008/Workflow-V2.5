using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Action.Model
{
    public class TakeWorkModel
    {
        private IList<TakeWork> takeWorkList;
        /// <summary>
        /// Gets or sets the take work list
        /// </summary>
        /// <value>The take work list.</value>
        public IList<TakeWork> TakeWorkList
        {
            get { return takeWorkList; }
            set { takeWorkList = value; }
        }

        private TakeWork takeWork;
        /// <summary>
        /// Gets or sets the take work
        /// </summary>
        /// <value>The take work.</value>
        public TakeWork TakeWork
        {
            get { return takeWork; }
            set { takeWork = value; }
        }

        private IList<Workflow.Da.Domain.Employee> employeeList;
        /// <summary>
        /// Gets or sets the employee list
        /// </summary>
        /// <value>The employee list.</value>
        public IList<Workflow.Da.Domain.Employee> EmployeeList
        {
            get { return employeeList; }
            set { employeeList = value; }
        }

        private long id;
        //ID
        public long Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
