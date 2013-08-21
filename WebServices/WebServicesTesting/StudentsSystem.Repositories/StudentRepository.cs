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
    public class StudentRepository:IRepository<Student>
    {
        private DbContext dbContext;
        private DbSet<Student> entitySet;

        public StudentRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.entitySet = this.dbContext.Set<Student>();
        }

        public Student Add(Student item)
        {
            entitySet.Add(item);
            dbContext.SaveChanges();
            return item;
        }

        public Student Update(int id, Student item)
        {
            var updatedStudent = new Student()
            {
                Id = id,
                FirstName = item.FirstName,
                LastName = item.LastName,
                Age = item.Age,
                Grade = item.Grade,
                School = item.School,
                Marks = item.Marks
            };

            entitySet.Attach(updatedStudent);
            dbContext.SaveChanges();
            return updatedStudent;
        }

        public void Delete(int id)
        {
            this.entitySet.Remove(Get(id));
        }

        public void Delete(Student item)
        {
            this.entitySet.Remove(item);
        }

        public Student Get(int id)
        {
            return this.entitySet.Find(id);
        }

        public IQueryable<Student> All()
        {
            return this.entitySet;
        }

        public IQueryable<Student> Find(System.Linq.Expressions.Expression<Func<Student, int, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
