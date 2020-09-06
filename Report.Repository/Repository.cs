using Microsoft.EntityFrameworkCore;
using Report.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Report.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext context;
        private DbSet<T> entities;
        public Repository(ApplicationDbContext context)
        {
            this.context = context;
            this.entities = context.Set<T>();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
