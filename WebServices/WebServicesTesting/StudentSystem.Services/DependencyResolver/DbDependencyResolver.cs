using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using StudentsSystem.Repositories;
using StudentSystem.Data;
using StudentSystem.Services.Controllers;


namespace MusicStore.Client.DependencyResolver
{
    public class DbDependencyResolver : IDependencyResolver
    {
        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            var dbContext = new StudentSystemContext();

            if (serviceType == typeof(MarkController))
            {
                var markRepository = new MarkRepository(dbContext);
                return new MarkController(markRepository);
            }
            else if (serviceType == typeof(SchoolController))
            {
                var schoolRepository = new SchoolRepository(dbContext);
                return new SchoolController(schoolRepository);
            }
            else if (serviceType == typeof(StudentController))
            {
                var studentRepository = new StudentRepository(dbContext);
                return new StudentController(studentRepository);
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }

        public void Dispose()
        {
        }
    }
}