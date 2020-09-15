using hms.Controllers;
using hms.Models;
using hms.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NUnitTestProjecthms
{
    class NUnit2
    {
        hmsContext db = new hmsContext();


        [SetUp]


        public void Setup()

        {

            var Rooms = new List<Rooms>

      {

        new Rooms{ RoomId=01,RoomType="AC",price=2250 },

        new Rooms{ RoomId=02,RoomType="NON AC",price=2250 },
        new Rooms{ RoomId=03,RoomType="SUITE",price=225 },

      };

            var Roomsdata = Rooms.AsQueryable();

            var mockSet = new Mock<DbSet<Rooms>>();

            mockSet.As<IQueryable<Rooms>>().Setup(m => m.Provider).Returns(Roomsdata.Provider);

            mockSet.As<IQueryable<Rooms>>().Setup(m => m.Expression).Returns(Roomsdata.Expression);

            mockSet.As<IQueryable<Rooms>>().Setup(m => m.ElementType).Returns(Roomsdata.ElementType);

            mockSet.As<IQueryable<Rooms>>().Setup(m => m.GetEnumerator()).Returns(Roomsdata.GetEnumerator());

            var mockContext = new Mock<hmsContext>();

            mockContext.Setup(c => c.Rooms).Returns(mockSet.Object);

            db = mockContext.Object;

        }






        [Test]


        public void GetUsers()

        {

            var repo = new Mock<RoomsRep>(db);

            RoomsController controller = new RoomsController(repo.Object);

            var data = controller.Get();

            var result = data as ObjectResult;

            Assert.AreEqual(200, result.StatusCode);

        }
        [Test]
        public void GetByUsernamePositive()

        {

            var repo = new Mock<RoomsRep>(db);

            RoomsController controller = new RoomsController(repo.Object);

            var data = controller.Get1(02);

            var result = data as ObjectResult;

            Assert.AreEqual(200, result.StatusCode);

        }
        [Test]
        public void GetByUsernameNegative()

        {

            var repo = new Mock<RoomsRep>(db);

            RoomsController controller = new RoomsController(repo.Object);

            var data = controller.Get1(08);

            var result = data as ObjectResult;

            Assert.AreEqual(400, result.StatusCode);

        }
        [Test]
        public void PostUser()

        {

            var repo = new Mock<RoomsRep>(db);

            RoomsController controller = new RoomsController(repo.Object);

            Rooms user = new Rooms { RoomId = 02, RoomType = "NON AC", price = 2250 };

            var data = controller.Post(user) as OkObjectResult;


            Assert.AreEqual(200, data.StatusCode);

        }
       
        [Test]

        public void DeleteUserPositive()

        {

            var repo = new Mock<RoomsRep>(db);

            RoomsController controller = new RoomsController(repo.Object);

            var data = controller.Delete(01) as OkObjectResult;

            Assert.AreEqual(200, data.StatusCode);

        }

    }
}

