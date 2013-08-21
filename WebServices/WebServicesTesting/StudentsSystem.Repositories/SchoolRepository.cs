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
    public class SchoolRepository:IRepository<School>
    {
        private DbContext dbContext;
        private DbSet<School> entitySet;

        public SchoolRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.entitySet = this.dbContext.Set<School>();
        }

        public School Add(School item)
        {
            entitySet.Add(item);
            dbContext.SaveChanges();
            return item;
        }

        public School Update(int id, School item)
        {
            var updatedSchool = new School()
            {
                Id = id,
                Name = item.Name,
                Location = item.Location,
                Students = item.Students
            };

            entitySet.Attach(updatedSchool);
            
            dbContext.SaveChanges();
            return updatedSchool;
        }

        public void Delete(int id)
        {
            this.entitySet.Remove(Get(id));
        }

        public void Delete(School item)
        {
            this.entitySet.Remove(item);
        }

        public School Get(int id)
        {
            return this.entitySet.Find(id);
        }

        public IQueryable<School> All()
        {
            return this.entitySet;
        }

        public IQueryable<School> Find(System.Linq.Expressions.Expression<Func<School, int, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
