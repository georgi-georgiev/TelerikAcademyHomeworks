using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentsSystem.Repositories;
using StudentSystem.Data;
using StudentSystem.Model;
using StudentSystem.Services.Models;

namespace StudentSystem.Services.Controllers
{
    public class StudentController : ApiController
    {
        private IRepository<Student> studentRepository;

        public StudentController()
        {
            var context = new StudentSystemContext();
            this.studentRepository = new StudentRepository(context);
        }

        public StudentController(IRepository<Student> repository)
        {
            this.studentRepository = repository;
        }
        // GET api/mark
        public IEnumerable<StudentModel> GetAll()
        {
            var studentEntities = this.studentRepository.All().ToList();

            var studentModel =
                from studentEntity in studentEntities
                select new StudentModel()
                {
                    Id = studentEntity.Id,
                    FirstName = studentEntity.FirstName,
                    LastName = studentEntity.LastName,
                    Grade = studentEntity.Grade
                };

            if (studentModel == null)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(
                    HttpStatusCode.NotFound, "no items found"));
            }
            else
            {
                return studentModel.ToList();
            }
        }

        // GET api/mark/5
        public StudentFullModel GetById(int id)
        {
            var student = this.studentRepository.Get(id);
            if (student == null)
            {
                var errResponse = this.Request.CreateErrorResponse(
                    HttpStatusCode.NotFound, "no item found");
                throw new HttpResponseException(errResponse);
            }
            var studentModel = new StudentFullModel()
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Grade = student.Grade,
                Marks = (
                from marks in student.Marks
                select new MarkModel()
                {
                    Subject = marks.Subject,
                    Value = marks.Value
                }).ToList()
            };

            return studentModel;
        }

        // POST api/mark
        public HttpResponseMessage Post(Student model)
        {
            if (model.FirstName == null || model.LastName == null || model.Grade == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    "Mark must have first name, last name and grade");
            }
            else
            {
                var entity = this.studentRepository.Add(model);

                var response =
                    Request.CreateResponse(HttpStatusCode.Created, entity);

                response.Headers.Location = new Uri(Url.Link("DefaultApi",
                    new { id = entity.Id }));
                return response;
            }
        }

        // PUT api/mark/5
        public HttpResponseMessage Put(int id, Student model)
        {
            var entity = this.studentRepository.Update(id, model);

            var response =
                Request.CreateResponse(HttpStatusCode.Created, entity);

            response.Headers.Location = new Uri(Url.Link("DefaultApi",
                new { id = entity.Id }));
            return response;
            
        }

        // DELETE api/mark/5
        public void Delete(int id)
        {
            this.studentRepository.Delete(id);
        }
    }
}
