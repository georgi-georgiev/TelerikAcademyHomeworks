using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentsSystem.Repositories;
using StudentSystem.Model;
using StudentSystem.Services.Controllers;
using StudentSystem.Services.Models;
using Telerik.JustMock;

namespace StudentSystem.Services.Tests.Controllers
{
    [TestClass]
    public class SchoolControllerTest
    {
        [TestMethod]
        public void TestAddCorrectSchool()
        {
            bool isItemAdded = false;
            var repository = Mock.Create<IRepository<School>>();

            var schoolModel = new SchoolModel()
            {
                Name = "PMG",
                Location = "Sofia"
            };
            var schoolEntity = new School()
            {
                Id = 1,
                Name = schoolModel.Name,
                Location = schoolModel.Location
            };
            Mock.Arrange(() => repository.Add(Arg.IsAny<School>()))
                .DoInstead(() => isItemAdded = true)
                .Returns(schoolEntity);

            var controller = new SchoolController(repository);
            SetupController.Create(controller, "post", "school");

            var result = controller.PostSchool(schoolEntity);

            Assert.IsTrue(result.IsSuccessStatusCode);
            Assert.IsTrue(isItemAdded);
        }

        [TestMethod]
        public void TestGetByIdSchool()
        {
            var repository = Mock.Create<IRepository<School>>();
            var school = new School()
            {
                Id = 1,
                Name = "PMG",
                Location = "Sofia"
            };

            Mock.Arrange<School>(
                () => repository.Get(school.Id))
                .IgnoreArguments()
                .Returns(school)
                .MustBeCalled();

            var controller = new SchoolController(repository);
            SetupController.Create(controller, "get", "school");
            var result = controller.GetSchool(school.Id);
            Assert.AreEqual(result.Id, school.Id);
            Assert.AreEqual(result.Name, school.Name);
            Assert.AreEqual(result.Location, school.Location);
        }

        [TestMethod]
        public void TestUpdateSchool()
        {
            bool isItemAdded = false;
            var repository = Mock.Create<IRepository<School>>();

            var schoolModel = new SchoolModel()
            {
                Location = "Sofia",
                Name = "PMG"
            };
            var schoolEntity = new School()
            {
                Id = 1,
                Location = schoolModel.Location,
                Name = schoolModel.Name
            };
            Mock.Arrange(() => repository.Add(Arg.IsAny<School>()))
                .DoInstead(() => isItemAdded = true)
                .Returns(schoolEntity);

            var controller = new SchoolController(repository);
            SetupController.Create(controller, "post", "school");


            bool isItemUpdated = false;
            var schoolToUpdate = new School()
            {
                Id = 1,
                Name = "SMG",
                Location = "Sofia"
            };

            Mock.Arrange<School>(
                () => repository.Update(schoolToUpdate.Id, schoolToUpdate))
                .DoInstead(() => isItemUpdated = true)
                .Returns(schoolToUpdate);


            SetupController.Create(controller, "put", "school");

            var result = controller.PutSchool(schoolToUpdate.Id, schoolToUpdate);

            Assert.IsTrue(result.IsSuccessStatusCode);
            Assert.IsTrue(isItemUpdated);
        }

        [TestMethod]
        public void TestDeleteSchool()
        {
            bool isItemDeleted = false;
            bool isItemAdded = false;
            var repository = Mock.Create<IRepository<School>>();

            var schoolModel = new SchoolModel()
            {
                Location = "sofia",
                Name = "HMG"
            };
            var schoolEntity = new School()
            {
                Id = 1,
                Location = schoolModel.Location,
                Name = schoolModel.Name
            };
            Mock.Arrange(() => repository.Add(Arg.IsAny<School>()))
                .DoInstead(() => isItemAdded = true)
                .Returns(schoolEntity);

            var controller = new SchoolController(repository);
            SetupController.Create(controller, "post", "school");

            controller.PostSchool(schoolEntity);

            Mock.Arrange(() => repository.Delete(Arg.IsAny<School>()))
                .DoInstead(() => isItemDeleted = true);


            SetupController.Create(controller, "delete", "school");

            controller.DeleteSchool(schoolEntity.Id);

            Assert.IsFalse(isItemDeleted);
        }
    }
}
