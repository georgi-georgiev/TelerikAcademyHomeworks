using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentsSystem.Repositories;
using StudentSystem.Model;
using StudentSystem.Services;
using StudentSystem.Services.Controllers;
using StudentSystem.Services.Models;
using Telerik.JustMock;

namespace StudentSystem.Services.Tests.Controllers
{
    [TestClass]
    public class StudentControllerTest
    {
        [TestMethod]
        public void TestAddCorrectStudent()
        {
            bool isItemAdded = false;
            var repository = Mock.Create<IRepository<Student>>();

            var studentModel = new StudentModel()
            {
                FirstName = "Pesho",
                LastName = "Peshov",
                Grade = 3
            };
            var studentEntity = new Student()
            {
                Id = 1,
                FirstName = studentModel.FirstName,
                LastName = studentModel.LastName,
                Grade = studentModel.Grade
            };
            Mock.Arrange(() => repository.Add(Arg.IsAny<Student>()))
                .DoInstead(() => isItemAdded = true)
                .Returns(studentEntity);

            var controller = new StudentController(repository);
            SetupController.Create(controller, "post", "student");

            var result = controller.Post(studentEntity);

            Assert.IsTrue(result.IsSuccessStatusCode);
            Assert.IsTrue(isItemAdded);
        }

        [TestMethod]
        public void TestGetByIdStudent()
        {
            var repository = Mock.Create<IRepository<Student>>();
            var student = new Student()
            {
                Id = 1,
                FirstName = "Pesho",
                LastName = "Peshov",
                Grade = 3
            };

            Mock.Arrange<Student>(
                () => repository.Get(student.Id))
                .IgnoreArguments()
                .Returns(student)
                .MustBeCalled();

            var controller = new StudentController(repository);
            SetupController.Create(controller, "get", "student");
            var result = controller.GetById(student.Id);
            Assert.AreEqual(result.Id, student.Id);
            Assert.AreEqual(result.FirstName, student.FirstName);
            Assert.AreEqual(result.LastName, student.LastName);
            Assert.AreEqual(result.Grade, student.Grade);
        }

        [TestMethod]
        public void TestUpdateStudent()
        {
            bool isItemAdded = false;
            var repository = Mock.Create<IRepository<Student>>();

            var studentModel = new StudentModel()
            {
                FirstName = "Pesho",
                LastName = "Peshov",
                Grade = 3
            };
            var studentEntity = new Student()
            {
                Id = 1,
                FirstName = studentModel.FirstName,
                LastName = studentModel.LastName,
                Grade = studentModel.Grade
            };
            Mock.Arrange(() => repository.Add(Arg.IsAny<Student>()))
                .DoInstead(() => isItemAdded = true)
                .Returns(studentEntity);

            var controller = new StudentController(repository);
            SetupController.Create(controller, "post", "student");


            bool isItemUpdated = false;
            var studentToUpdate = new Student()
            {
                Id = 1,
                FirstName = "Pesho2",
                LastName = "Peshov2",
                Grade = 5
            };

            Mock.Arrange<Student>(
                () => repository.Update(studentToUpdate.Id, studentToUpdate))
                .DoInstead(() => isItemUpdated = true)
                .Returns(studentToUpdate);


            SetupController.Create(controller, "put", "student");

            var result = controller.Put(studentToUpdate.Id, studentToUpdate);

            Assert.IsTrue(result.IsSuccessStatusCode);
            Assert.IsTrue(isItemUpdated);
        }

        [TestMethod]
        public void TestDeleteStudent()
        {
            bool isItemDeleted = false;
            bool isItemAdded = false;
            var repository = Mock.Create<IRepository<Student>>();

            var studentModel = new StudentModel()
            {
                FirstName = "Pesho",
                LastName = "Peshov",
                Grade = 3
            };
            var studentEntity = new Student()
            {
                Id = 1,
                FirstName = studentModel.FirstName,
                LastName = studentModel.LastName,
                Grade = studentModel.Grade
            };
            Mock.Arrange(() => repository.Add(Arg.IsAny<Student>()))
                .DoInstead(() => isItemAdded = true)
                .Returns(studentEntity);

            var controller = new StudentController(repository);
            SetupController.Create(controller, "post", "student");

            controller.Post(studentEntity);

            Mock.Arrange(() => repository.Delete(Arg.IsAny<Student>()))
                .DoInstead(() => isItemDeleted = true);


            SetupController.Create(controller, "delete", "student");

            controller.Delete(studentEntity.Id);

            Assert.IsFalse(isItemDeleted);
        }
    }
}
