using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Sample.Entity;
using Sample.Repository;
using Sample.Web.Controllers;
using Sample.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Sample.Test
{
    [TestClass]
    public class HomeControllerTest  
    {
        [TestMethod]
         public void Index_Test()
         {
             var ctrl = new  HomeController();
             var result = ctrl.Index();
             Assert.AreNotEqual(null, result);
         }

        [TestMethod]
        public void Index_With_Data_Test()
        {
            List<People> peopleData = new List<People>();
            var people1 = new People()
            {
                FirstName = "FirstTest",
                LastName = "LastTest",
                Age = 38,
                Address = new PeopleAddress
                {
                    Street = "123 Test Street",
                    City = "Test City",
                    State = "Test State",
                    Zip = 12345
                },
                Interests = new List<PeopleInterests> {new PeopleInterests{
                    Interest="Swimming"
                } }
            };

            peopleData.Add(people1);

            var people2 = new People()
            {
                FirstName = "SecondTest",
                LastName = "SecondTest",
                Age = 38,
                Address = new PeopleAddress
                {
                    Street = "456 Test Street",
                    City = "New Test City",
                    State = "New Test State",
                    Zip = 67890
                },
                Interests = new List<PeopleInterests> {new PeopleInterests{
                    Interest="Dancing"
                },
                {new PeopleInterests{
                    Interest="Coading"
                }
                }
                }
            };

            peopleData.Add(people2);

            Mock<IPeopleRepository> repository = new Mock<IPeopleRepository>();
            repository.Setup(x => x.GetPeoples()).Returns(peopleData.AsQueryable());

            var ctrl = new HomeController();
            var result = ctrl.Index() as ViewResult;
            var model = result.ViewData.Model as List<People>;
            Assert.AreEqual(2, model.Count);

        }
        
        [TestMethod]
        public void AddPeople_Test()
        {
            var ViewModel = new PeopleViewModel();
            var people = new People()
            {
                FirstName = "FirstTest",
                LastName = "LastTest",
                Age = 38,
                Address = new PeopleAddress
                {
                    Street = "123 Test Street",
                    City = "Test City",
                    State = "Test State",
                    Zip = 12345
                },
                Interests = new List<PeopleInterests> {new PeopleInterests{
                    Interest="Swimming"
                } }
            };
            Mock<IPeopleRepository> repository = new Mock<IPeopleRepository>();
            var ctrl = new HomeController(repository.Object);
            System.Web.HttpPostedFileBase file = null;
            ViewModel.People = people;
            var result = ctrl.AddPeople(ViewModel, file) as ViewResult;
            repository.Verify(x => x.AddPeople(people), Times.Once());
            Assert.AreEqual("Index", result.ViewName);
        }
    }
}
