using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using StudentSystem.Model;
using StudentSystem.Data;
using StudentsSystem.Repositories;
using StudentSystem.Services.Models;

namespace StudentSystem.Services.Controllers
{
    public class SchoolController : ApiController
    {
        private IRepository<School> schoolRepository;

        public SchoolController()
        {
            var context = new StudentSystemContext();
            this.schoolRepository = new SchoolRepository(context);
        }

        public SchoolController(IRepository<School> repository)
        {
            this.schoolRepository = repository;
        }

        // GET api/School
        public IEnumerable<SchoolModel> GetSchools()
        {
            var schoolEntities = this.schoolRepository.All();
            var schoolsModel =
                from school in schoolEntities
                select new SchoolModel()
                {
                    Id = school.Id,
                    Name = school.Name,
                    Location = school.Location
                };
            return schoolsModel.ToList();
        }

        // GET api/School/5
        public School GetSchool(int id)
        {
            var school = this.schoolRepository.Get(id);
            if (school == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return school;
        }

        // PUT api/School/5
        public HttpResponseMessage PutSchool(int id, School school)
        {
            if (ModelState.IsValid && id == school.Id)
            {
                this.schoolRepository.Update(id, school);

                var response =
                    Request.CreateResponse(HttpStatusCode.Created, school);

                response.Headers.Location = new Uri(Url.Link("DefaultApi",
                    new { id = school.Id }));

                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/School
        public HttpResponseMessage PostSchool(School school)
        {
            this.schoolRepository.Add(school);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, school);
            response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = school.Id }));
            return response;
        }

        // DELETE api/School/5
        public void DeleteSchool(int id)
        {
            this.schoolRepository.Delete(id);
        }
    }
}