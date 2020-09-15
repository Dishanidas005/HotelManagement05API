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

    class NUnit3

    {

        hmsContext db = new hmsContext();

        [SetUp]

        public void Setup()

        {

            var Booking = new List<Booking>

      {

        new Booking{ BookingId=1,emailId="sb@gmail.com",RoomID=1 },

        new Booking{ BookingId=2,emailId="dd@gmail.com",RoomID=2 },

        new Booking{ BookingId=3,emailId="bc@gmail.com",RoomID=3 }

      };

            var Bookingdata = Booking.AsQueryable();

            var mockSet = new Mock<DbSet<Booking>>();

            mockSet.As<IQueryable<Booking>>().Setup(m => m.Provider).Returns(Bookingdata.Provider);

            mockSet.As<IQueryable<Booking>>().Setup(m => m.Expression).Returns(Bookingdata.Expression);

            mockSet.As<IQueryable<Booking>>().Setup(m => m.ElementType).Returns(Bookingdata.ElementType);

            mockSet.As<IQueryable<Booking>>().Setup(m => m.GetEnumerator()).Returns(Bookingdata.GetEnumerator());

            var mockContext = new Mock<hmsContext>();

            mockContext.Setup(c => c.Bookings).Returns(mockSet.Object);

            db = mockContext.Object;

        }

        [Test]

        public void GetRoom()

        {

            var repo = new Mock<BookingRep>(db);

            BookingController controller = new BookingController(repo.Object);

            var data = controller.Get();

            var result = data as ObjectResult;

            Assert.AreEqual(200, result.StatusCode);

        }

        [Test]

        public void GetByBookingIdPositive()

        {

            var repo = new Mock<BookingRep>(db);

            BookingController controller = new BookingController(repo.Object);

            var data = controller.Get1(1);

            var result = data as ObjectResult;

            Assert.AreEqual(200, result.StatusCode);

        }

        [Test]

        public void GetByBookingIdNegative()

        {

            var repo = new Mock<BookingRep>(db);

            BookingController controller = new BookingController(repo.Object);

            var data = controller.Get1(5);

            var result = data as ObjectResult;

            Assert.AreEqual(400, result.StatusCode);

        }

        [Test]

        public void PostRoom()

        {

            var repo = new Mock<BookingRep>(db);

            BookingController controller = new BookingController(repo.Object);

            Booking booking = new Booking { BookingId = 4, emailId = "ac@gmail.com", RoomID = 4 };

            var data = controller.Post(booking) as OkObjectResult;

            Assert.AreEqual(200, data.StatusCode);

        }

        /*[Test]

        public void PutBoarderPositive()

        {

          var repo = new Mock<BoarderRep>(db);

          BoarderController controller = new BoarderController(repo.Object);

          Boarder boarder = new Boarder { FirstName = "Siddhartha", LastName = "Banerjee" };

          var data = controller.Put("sb@gmail.com", boarder) as OkObjectResult;

          Assert.AreEqual(200, data.StatusCode);

        }*/

        [Test]

        public void DeleteRoomPositive()

        {

            var repo = new Mock<BookingRep>(db);

            BookingController controller = new BookingController(repo.Object);

            var data = controller.Delete(3) as OkObjectResult;

            Assert.AreEqual(200, data.StatusCode);

        }

    }

}

