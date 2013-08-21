using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Telerik.JustMock;
using StudentsSystem.Repositories;
using StudentSystem.Services.Models;
using StudentSystem.Model;
using StudentSystem.Services.Controllers;

namespace StudentSystem.Services.Tests.Controllers
{
    [TestClass]
    public class MarkControllerTest
    {
        [TestMethod]
        public void TestAddCorrectMark()
        {
            bool isItemAdded = false;
            var repository = Mock.Create<IRepository<Mark>>();

            var markModel = new MarkModel()
            {
                Value = 5,
                Subject = "Math"
            };
            var markEntity = new Mark()
            {
                Id = 1,
                Value = markModel.Value,
                Subject = markModel.Subject
            };
            Mock.Arrange(() => repository.Add(Arg.IsAny<Mark>()))
                .DoInstead(() => isItemAdded = true)
                .Returns(markEntity);

            var controller = new MarkController(repository);
            SetupController.Create(controller, "post", "mark");

            var result = controller.Post(markEntity);

            Assert.IsTrue(result.IsSuccessStatusCode);
            Assert.IsTrue(isItemAdded);
        }

        [TestMethod]
        public void TestGetByIdMark()
        {
            var repository = Mock.Create<IRepository<Mark>>();
            var mark = new Mark()
            {
                Id = 1,
                Subject = "Psycho",
                Value = 3
            };

            Mock.Arrange<Mark>(
                () => repository.Get(mark.Id))
                .IgnoreArguments()
                .Returns(mark)
                .MustBeCalled();

            var controller = new MarkController(repository);
            SetupController.Create(controller, "get", "mark");
            var result = controller.GetById(mark.Id);
            Assert.AreEqual(result.Id, mark.Id);
            Assert.AreEqual(result.Subject, mark.Subject);
            Assert.AreEqual(result.Value, mark.Value);
        }

        [TestMethod]
        public void TestUpdateMark()
        {
            bool isItemAdded = false;
            var repository = Mock.Create<IRepository<Mark>>();

            var markModel = new MarkModel()
            {
                Value = 5,
                Subject = "Math"
            };
            var markEntity = new Mark()
            {
                Id = 1,
                Value = markModel.Value,
                Subject = markModel.Subject
            };
            Mock.Arrange(() => repository.Add(Arg.IsAny<Mark>()))
                .DoInstead(() => isItemAdded = true)
                .Returns(markEntity);

            var controller = new MarkController(repository);
            SetupController.Create(controller, "post", "mark");


            bool isItemUpdated = false;
            var markToUpdate = new Mark()
            {
                Id = 1,
                Subject = "FVS",
                Value = 6
            };

            Mock.Arrange<Mark>(
                () => repository.Update(markToUpdate.Id, markToUpdate))
                .DoInstead(() => isItemUpdated = true)
                .Returns(markToUpdate);


            SetupController.Create(controller, "put", "mark");

            var result = controller.Put(markToUpdate.Id, markToUpdate);

            Assert.IsTrue(result.IsSuccessStatusCode);
            Assert.IsTrue(isItemUpdated);
        }

        [TestMethod]
        public void TestDeleteMark()
        {
            bool isItemDeleted = false;
            bool isItemAdded = false;
            var repository = Mock.Create<IRepository<Mark>>();

            var markModel = new MarkModel()
            {
                Value = 5,
                Subject = "Math"
            };
            var markEntity = new Mark()
            {
                Id = 1,
                Value = markModel.Value,
                Subject = markModel.Subject
            };
            Mock.Arrange(() => repository.Add(Arg.IsAny<Mark>()))
                .DoInstead(() => isItemAdded = true)
                .Returns(markEntity);

            var controller = new MarkController(repository);
            SetupController.Create(controller, "post", "mark");

            controller.Post(markEntity);

            Mock.Arrange(() => repository.Delete(Arg.IsAny<Mark>()))
                .DoInstead(() => isItemDeleted = true);

            
            SetupController.Create(controller, "delete", "mark");

            controller.Delete(markEntity.Id);

            Assert.IsFalse(isItemDeleted);
        }
    }
}
