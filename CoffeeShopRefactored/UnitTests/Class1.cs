using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests;
using NUnit.Framework;
using Repo;
using Pocos;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using Moq;
using NSubstitute; 

namespace UnitTests
{
    [TestFixture]
    public class Class1
    {
        TestClass testObject;
        Mock<Model1> context;
        Mock<DbSet<TestClass>> dbSetMock;
        Repository<TestClass> repository;
        [SetUp]
        public void Setup()
        {
            testObject = new TestClass();
            context = new Mock<Model1>();
            dbSetMock = new Mock<DbSet<TestClass>>();
            context.Setup(x => x.Set<TestClass>()).Returns(dbSetMock.Object);
            dbSetMock.Setup(x => x.Add(It.IsAny<TestClass>())).Returns(testObject);
            repository = new Repository<TestClass>(context.Object);
        }
        [Test]
        public void TestCreateNewEntity_AddAEntityToTheList_ReturnATableWithTheNewTable()
        {
            //Arrange

            //Act
            repository.CreateNewEntity(testObject);

            //Assert
            context.Verify(x => x.Set<TestClass>());
            dbSetMock.Verify(x => x.Add(It.Is<TestClass>(y => y == testObject)));
        }
        [Test]
        public void TestFindById_ReturnEntity_WhenCallWithAnIntPara()
        {
            //arrange
            var testObject = new TestClass() { Id = 1 };

            //act
            repository.FindById(1);
           

            //assert
            context.Verify(x => x.Set<TestClass>());
            dbSetMock.Verify(x => x.Find(It.IsAny<int>()));
        }
        [Test]
        public void TestDeleteEntity_RemoveEntity_WhenGiveId()
        {
            //arrange
            testObject = new TestClass() { Id = 1 };
            dbSetMock.Setup(x => x.Find(It.IsAny<int>())).Returns(testObject);
            
            //act
            repository.DeleteEntity(1);

            //assert
            context.Verify(x => x.Set<TestClass>());
            dbSetMock.Verify(x => x.Remove(It.Is<TestClass>(y => y == testObject)));
        }
        [Test]
        public void TestReadAll_ReturnAllTheList_WhenCalleda()
        {
            //arrange
            var contextMock = new Model1();

            var expected = new List<TestClass>
            {
                new TestClass { Id = 1 },
                new TestClass { Id = 2 },
                new TestClass { Id = 3 }
            };

            var data = new List<TestClass>
            {
                new TestClass { Id = 1 },
                new TestClass { Id = 2 },
                new TestClass { Id = 3 }
            };
            IQueryable<TestClass> queryableList = data.AsQueryable();

            var mockSet = new Mock<DbSet<TestClass>>();
            mockSet.As<IQueryable<TestClass>>().Setup(m => m.Provider).Returns(queryableList.Provider);
            mockSet.As<IQueryable<TestClass>>().Setup(m => m.Expression).Returns(queryableList.Expression);
            mockSet.As<IQueryable<TestClass>>().Setup(m => m.ElementType).Returns(queryableList.ElementType);
            mockSet.As<IQueryable<TestClass>>().Setup(m => m.GetEnumerator()).Returns(queryableList.GetEnumerator());
            contextMock.TestClasses = mockSet.Object;
          //  repository = new Repository<TestClass>(contextMock.TestClasses);

            //act
            var result = repository.ReadAll();

            //assert
            Assert.Equals(expected, result);

        }

    }
}
