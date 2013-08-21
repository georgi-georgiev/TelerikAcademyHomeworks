using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentSystem.Model;

namespace StudentsSystem.Repositories
{
    public class MarkRepository : IRepository<Mark>
    {
        private DbContext dbContext;
        private DbSet<Mark> entitySet;

        public MarkRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.entitySet = this.dbContext.Set<Mark>();
        }

        public Mark Add(Mark item)
        {
            entitySet.Add(item);
            dbContext.SaveChanges();
            return item;
        }

        public Mark Update(int id, Mark item)
        {
            var updatedMark = new Mark()
            {
                Id = item.Id,
                Subject = item.Subject,
                Value = item.Value
            };
            entitySet.Attach(updatedMark);
            dbContext.SaveChanges();
            return updatedMark;
        }

        public void Delete(int id)
        {
            this.entitySet.Remove(Get(id));
            dbContext.SaveChanges();
        }

        public void Delete(Mark item)
        {
            this.entitySet.Remove(item);
            dbContext.SaveChanges();
        }

        public Mark Get(int id)
        {
            return this.entitySet.Find(id);
        }

        public IQueryable<Mark> All()
        {
            return this.entitySet;
        }

        public IQueryable<Mark> Find(System.Linq.Expressions.Expression<Func<Mark, int, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
