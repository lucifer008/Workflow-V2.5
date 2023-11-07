using System;
using System.Collections.Generic;
using System.Text;

namespace Workflow.Da
{
    public interface IDaoBase<T>
    {
        IList<T> SelectAll();
        T SelectByPk(long id);
        void Insert(T domain);
        void Update(T domain);
        void Delete(long id);
        void LogicDelete(long id);
    }
}
