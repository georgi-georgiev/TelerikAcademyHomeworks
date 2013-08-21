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
    public class MarkController : ApiController
    {
        private IRepository<Mark> markRepository;

        public MarkController()
        {
            var context = new StudentSystemContext();
            this.markRepository = new MarkRepository(context);
        }

        public MarkController(IRepository<Mark> repository)
        {
            this.markRepository = repository;
        }
        // GET api/mark
        public IEnumerable<MarkModel> GetAll()
        {
            var markEntities = this.markRepository.All().ToList();

            var markModel =
                from markEntity in markEntities
                select new MarkModel()
                {
                    Id = markEntity.Id,
                    Subject = markEntity.Subject,
                    Value = markEntity.Value
                };

            if (markModel == null)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(
                    HttpStatusCode.NotFound, "no items found"));
            }
            else
            {
                return markModel.ToList();
            }
        }

        // GET api/mark/5
        public MarkFullModel GetById(int id)
        {
            var mark = this.markRepository.Get(id);
            if (mark == null)
            {
                var errResponse = this.Request.CreateErrorResponse(
                    HttpStatusCode.NotFound, "no item found");
                throw new HttpResponseException(errResponse);
            }
            var markModel = new MarkFullModel()
            {
                Id = mark.Id,
                Subject = mark.Subject,
                Value = mark.Value,
                Students = (
                from students in mark.Students
                select new StudentModel()
                {
                    FirstName = students.FirstName,
                    LastName = students.LastName
                }).ToList()
            };

            return markModel;
        }

        // POST api/mark
        public HttpResponseMessage Post(Mark model)
        {
            if (model.Subject == null || model.Value == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    "Mark must have subject and value");
            }
            else
            {
                var entity = this.markRepository.Add(model);

                var response =
                    Request.CreateResponse(HttpStatusCode.Created, entity);

                response.Headers.Location = new Uri(Url.Link("DefaultApi",
                    new { id = entity.Id }));
                return response;
            }
        }

        // PUT api/mark/5
        public HttpResponseMessage Put(int id, Mark model)
        {
            var entity = this.markRepository.Update(id, model);

            var response =
                Request.CreateResponse(HttpStatusCode.Created, entity);

            response.Headers.Location = new Uri(Url.Link("DefaultApi",
                new { id = entity.Id }));
            return response;
        }

        // DELETE api/mark/5
        public void Delete(int id)
        {
            this.markRepository.Delete(id);
        }
    }
}