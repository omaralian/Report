using Report.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Report.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        void SaveChanges();
    }
}
