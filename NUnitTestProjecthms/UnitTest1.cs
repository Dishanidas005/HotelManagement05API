using NUnit.Framework;
using System.Collections.Generic;
using hms.Models;
using System.Linq;
using Moq;
using Microsoft.EntityFrameworkCore;
using hms.Repository;
using hms.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace NUnitTestProjecthms
{
    public class Tests
    {
        hmsContext db = new hmsContext();


        [SetUp]
      
        
            public void Setup()

            {

                var Users = new List<Users>

      {

        new Users{ Email="prithwi97@gmail.com",FirstName="Prithiwman",LastName="Mazumdar" },

        new Users{ Email="thwi97@gmail.com",FirstName="Dishani",LastName="das" },

        new Users{Email="ab97@gmail.com",FirstName="thiwman",LastName="Mazumdar"}

      };

                var Usersdata = Users.AsQueryable();

                var mockSet = new Mock<DbSet<Users>>();

                mockSet.As<IQueryable<Users>>().Setup(m => m.Provider).Returns(Usersdata.Provider);

                mockSet.As<IQueryable<Users>>().Setup(m => m.Expression).Returns(Usersdata.Expression);

                mockSet.As<IQueryable<Users>>().Setup(m => m.ElementType).Returns(Usersdata.ElementType);

                mockSet.As<IQueryable<Users>>().Setup(m => m.GetEnumerator()).Returns(Usersdata.GetEnumerator());

                var mockContext = new Mock<hmsContext>();

                mockContext.Setup(c => c.Users).Returns(mockSet.Object);

                db = mockContext.Object;

            }




        

        [Test]
        

        public void GetUsers()

        {

            var repo = new Mock<UsersRep>(db);

            UsersController controller = new UsersController(repo.Object);

            var data = controller.Get();

            var result = data as ObjectResult;

            Assert.AreEqual(200, result.StatusCode);

        }
        [Test]
        public void GetByUsernamePositive()

        {

            var repo = new Mock<UsersRep>(db);

            UsersController controller = new UsersController(repo.Object);

            var data = controller.Get("prithwi97@gmail.com");

            var result = data as ObjectResult;

            Assert.AreEqual(200, result.StatusCode);

        }
        [Test]
        public void GetByUsernameNegative()

        {

            var repo = new Mock<UsersRep>(db);

            UsersController controller = new UsersController(repo.Object);

            var data = controller.Get("add@gmail.com");

            var result = data as ObjectResult;

            Assert.AreEqual(400, result.StatusCode);

        }
        [Test]
        public void PostUser()

        {

            var repo = new Mock<UsersRep>(db);

            UsersController controller = new UsersController(repo.Object);

            Users user = new Users { Email = "str@gmail.com", FirstName = "Prithwiman", LastName = "Mazumdar" };

            var data = controller.Post(user) as OkObjectResult;


            Assert.AreEqual(200, data.StatusCode);

        }
        [Test]
        public void PutUserPositive()

        {

            var repo = new Mock<UsersRep>(db);

            UsersController controller = new UsersController(repo.Object);

            Users user = new Users { FirstName = "Prithwi", LastName = "Mazumdar" };

            var data = controller.Put("prithwi97@gmail.com", user) as OkObjectResult;

            Assert.AreEqual(200, data.StatusCode);

        }
        [Test]

        public void DeleteUserPositive()

        {

            var repo = new Mock<UsersRep>(db);

            UsersController controller = new UsersController(repo.Object);

            var data = controller.Delete("ab97@gmail.com") as OkObjectResult;

            Assert.AreEqual(200, data.StatusCode);

        }

    }
    
}